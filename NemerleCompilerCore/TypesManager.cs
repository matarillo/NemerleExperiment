using System;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Reflection;
using System.Security;
using Emit = System.Reflection.Emit;

namespace Nemerle.Compiler
{
    public class TypesManager : System.IDisposable
    {
        /* -- PRIVATE FIELDS --------------------------------------------------- */

        private System.Reflection.AssemblyName _assembly_name;
        private Emit.AssemblyBuilder _assembly_builder;
        internal Emit.ModuleBuilder _module_builder;
        public ISymbolWriter _debug_emit;
        internal bool contains_nemerle_specifics = false;

        internal bool _need_entry_point;

        /** updated when method with static Main signature is met */
        internal Option<MethodInfo> _entry_point;

        private string _OutputFileName;
        private int _cgil_phase;

        // workaround MS.NET bugs with some specific value / generic types hierarchy
        private Assembly resolve_hack(object _, System.ResolveEventArgs __)
        {
            //Message.Debug ($ "resolve_hack: $(args.Name)");
            return _assembly_builder;
        }

        public TypesManager(ManagerClass man)
        {
            Manager = man;
            _OutputFileName = Manager.Options.OutputFileName;

            if (!Manager.Options.TargetIsLibrary)
            {
                _need_entry_point = true;
                _entry_point = None();
            }

            if (!Manager.IsIntelliSenseMode)
                System.AppDomain.CurrentDomain.TypeResolve += resolve_hack;
        }

        public void Dispose()
        {
            if (!Manager.IsIntelliSenseMode)
                System.AppDomain.CurrentDomain.TypeResolve -= resolve_hack;
        }

        public void CreateAssembly()
        {
            // we need to process global assembly attributes before creating assembly name
            _assembly_name = CreateAssemblyName();

            _assembly_name.Name = Path.GetFileNameWithoutExtension(_OutputFileName);

            var assembly_requirements =
                (Manager.Options.CompileToMemory)
                    ? Emit.AssemblyBuilderAccess.Run
                    : Emit.AssemblyBuilderAccess.Save;

            var dir = Path.GetDirectoryName(Path.GetFullPath(_OutputFileName));
            if (!Directory.Exists(dir))
                Message.FatalError($"specified output directory `$dir' does not exist");

            PermissionSet required;
            PermissionSet optional;
            PermissionSet refused;

            foreach ((action, perm_set) in Manager.AttributeCompiler.GetPermissionSets(assembly_attributes))
            {
                switch (action)
                {
                    case Permissions.SecurityAction.RequestMinimum:
                        required = perm_set;
                        break;
                    case Permissions.SecurityAction.RequestOptional:
                        optional = perm_set;
                        break;
                    case Permissions.SecurityAction.RequestRefuse:
                        refused = perm_set;
                        break;
                    default:
                        Message.FatalError($"$action is not valid here");
                        break;
                }
            }

            /* define a dynamic assembly */
            this._assembly_builder =
                System.AppDomain.CurrentDomain.DefineDynamicAssembly
                (this._assembly_name,
                    assembly_requirements,
                    dir, required, optional, refused);

            GetInformationalAssemblyAttributes().Iter(this._assembly_builder.SetCustomAttribute);

            if (_assembly_name.Name == "")
                Message.FatalError("name of output assembly cannot be empty");

            /* create a dynamic module */
            this._module_builder =
                (Manager.Options.CompileToMemory)
                    // we cannot give output filename if we are compiling only to Run
                    ? this._assembly_builder.DefineDynamicModule(_assembly_name.Name, Manager.Options.EmitDebug)
                    : this._assembly_builder.DefineDynamicModule(_assembly_name.Name,
                        Path.GetFileName(_OutputFileName),
                        Manager.Options.EmitDebug);

            if (Manager.Options.EmitDebug)
                _debug_emit = _module_builder.GetSymWriter();
        }

        public bool IsEmitting
        {
            get
            {
                _assembly_builder != null;
            }
        }

        void add_resources_to_assembly()
        {
            (string, string) escape_resource(string x)
            {
                var cp = x.IndexOf(',');
                return (cp != -1)
                    ? (x.Substring(0, cp), x.Substring(cp + 1))
                    // change name from /bar/bar/file.png to file.png namespace
                    : (x, Path.GetFileName(x));
            }

            /* we can embed resources only on mono or .NET 2.0 */
            foreach (var element in Manager.Options.EmbeddedResources)
            {
                var (file, name) = escape_resource(element);
                try
                {
                    if (File.Exists(file))
                    {
                        var fs = File.OpenRead(file);
                        var meth = _module_builder.GetType().GetMethod("DefineManifestResource");
                        if (meth == null)
                        {
                            try
                            {
                                var res = new byte[(int) fs.Length];
                                int pos = 0;
                                while (res.Length < pos)
                                {
                                    pos += fs.Read(res, pos, res.Length - pos);
                                }

                                var meth2 = _assembly_builder.GetType()
                                    .GetMethod("EmbedResource", BindingFlags.NonPublic | BindingFlags.Instance);
                                if (meth2 == null)
                                    Message.Error("cannot find API for saving resources");
                                else
                                    meth2.Invoke(_assembly_builder,
                                        new object[] {name, res, ResourceAttributes.Public});
                            }
                            finally
                            {
                                fs.Dispose();
                            }
                        }
                        else
                        {
                            // this method does the Dispose for us
                            meth.Invoke(_module_builder, new object[] {name, fs, ResourceAttributes.Public});
                        }
                    }
                    else
                        Message.Error("Could not find resource " + file);
                }
                catch (Exception e)
                {
                    Message.Error("Could not embed resource: " + e.Message);
                }
            }

            foreach (var element in Manager.Options.LinkedResources)
            {
                var (file, name) = escape_resource(element);
                try
                {
                    _assembly_builder.AddResourceFile(name, file);
                }
                catch (FileNotFoundException)
                {
                    Message.Error("Could not find resource " + file);
                }
                catch (System.ArgumentException e)
                {
                    Message.Error("Could not link resource: " + e.Message);
                }
            }

            var uresource = Manager.Options.UnmanagedResource;
            if (uresource != null)
            {
                try
                {
                    _module_builder.DefineUnmanagedResource(uresource);
                }
                catch (FileNotFoundException)
                {
                    Message.Error("Could not find resource" + uresource);
                }
                catch (System.ArgumentException e)
                {
                    Message.Error($"Could not embed unmanaged resource {uresource}: {e.Message}");
                }
            }
            else
            {
                this._assembly_builder.DefineVersionInfoResource();
            }
        }

        /**
         *
         */
        public void EmitAuxDecls()
        {
            compile_all_tyinfos(true);
        }

        /**
         *
         */
        public void EmitDecls()
        {
            Manager.Solver.Enqueue(() =>
            {
                compile_all_tyinfos(false);
                foreach (var (attr, shouldEmit) in Manager.AttributeCompiler.GetCompiledAssemblyAttributes(
                    assembly_attributes))
                {
                    if (shouldEmit)
                    {
                        _assembly_builder.SetCustomAttribute(attr);
                    }
                }

                // emit debug attributes
                if (Manager.Options.EmitDebug)
                {
                    var attr = Manager.AttributeCompiler.MakeEmittedAttribute(SystemTypeCache.DebuggableAttribute,
                        new[] {SystemTypeCache.DebuggableAttribute_DebuggingModes},
                        DebuggableAttribute.DebuggingModes.DisableOptimizations |
                        DebuggableAttribute.DebuggingModes.Default);
                    _assembly_builder.SetCustomAttribute(attr);
                }

                // do not require string literals interning
                var attr2 = Manager.AttributeCompiler.MakeEmittedAttribute(
                    SystemTypeCache.CompilationRelaxationsAttribute, 8);
                _assembly_builder.SetCustomAttribute(attr2);

                // wrap non exception throws
                /* uncomment it after we get dependency upon mono 1.1.10, since mono 1.1.9.x do not support this attribute
                */
            });
        }

        /**
         * Returns generated assembly for runtime instantations of its types
         */
        public Assembly GeneratedAssembly => _assembly_builder;

        /**
         * Saves the constructed assembly to a file
         */
        public void SaveAssembly()
        {
            add_resources_to_assembly();

            // if there are some nemerle specific metadata encoded in attributes
            if (contains_nemerle_specifics)
            {
                var attr = Manager.AttributeCompiler.MakeEmittedAttribute(
                    SystemTypeCache.Reflection_AssemblyConfigurationAttribute, "ContainsNemerleTypes");
                this._assembly_builder.SetCustomAttribute(attr);
            }

            // set the entry point
            if (_need_entry_point)
            {
                if (Option.IsSome(_entry_point, out var entry_point_method_info))
                {
                    _assembly_builder.SetEntryPoint(entry_point_method_info,
                        (Manager.Options.TargetIsWinexe)
                            ? Emit.PEFileKinds.WindowApplication
                            : Emit.PEFileKinds.ConsoleApplication);
                }
                else
                {
                    Message.Error("no suitable entry point (Main function) found");
                }
            }

            // save the assembly
            try
            {
                var (portableExecutableKind, imageFileMachine) = make_platform_flags(Manager.Options.Platform);
                _assembly_builder.Save(Path.GetFileName(_OutputFileName), portableExecutableKind, imageFileMachine);
                //when (_debug_emit != null) _debug_emit.Close ();
            }
            catch (System.UnauthorizedAccessException e)
            {
                Message.Error($"could not write to output file `$(this._OutputFileName)' -- `$(e.Message)'");
            }
            catch (IOException e)
            {
                Message.Error($"could not write to output file `$(this._OutputFileName)' -- `$(e.Message)'");
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Message.Error($"Problems saving assembly: $(e.Message)");
            }
            catch (System.ApplicationException e)
            {
                Message.Error(e.Message);
            }
        }

        /* -- PRIVATE METHODS -------------------------------------------------- */

        /**
         * - create S.R.E.TypeBuilders for entire hierarchy of program
         * - add members to those TypeBuilders (only stubs for methods)
         * - emit bodies of methods
         * - finalize value types
         * - finalize all types
         */
        protected virtual void compile_all_tyinfos(bool aux_phase)
        {
            bool allow_it(TypeBuilder ti) => !ti.IsFinalized && is_aux_decl(ti) == aux_phase;

            void create_type_emit_builder(TypeBuilder ti)
            {
                if (allow_it(ti))
                {
                    //Message.Debug ("make type builder for " + ti.FullName);
                    ti.CreateEmitBuilder();

                    if (ti.Attributes && NemerleModifiers.Macro)
                    {
                        var attr = Manager.AttributeCompiler.MakeEmittedAttribute(
                            SystemTypeCache.ContainsMacroAttribute,
                            ti.GetTypeBuilder().FullName);
                        _assembly_builder.SetCustomAttribute(attr);
                    }
                }
            }

            // create members' declarations in SRE.TypeBuilders
            void emit_decls(TypeBuilder ti)
            {
                if (allow_it(ti))
                {
                    // Message.Debug ("generating declarations " + ti.FullName);
                    ti.CreateEmitDeclarations();
                }
            }

            void emit_impl(TypeBuilder ti)
            {
                if (allow_it(ti))
                {
                    //Message.Debug ("generating code for " + ti.FullName);
                    Manager.MarkTypeBuilderCompiled();
                    ti.EmitImplementation();
                }
            }

            if (!aux_phase)
                _cgil_phase = 1;

            Iter(create_type_emit_builder);
            Iter(tb =>
                {
                    if (allow_it(tb)) tb.UpdateEmittedInheritance();
                });

            if (!aux_phase)
                _cgil_phase = 2;

            // first emit fields of enum types as it is required to compute their sizes,
            // when they are used as fields
            IterConditionally(emit_decls, (TypeBuilder x) => x.IsEnum);
            IterConditionally(emit_decls, (TypeBuilder x) => !x.IsEnum);

            if (!aux_phase)
                _cgil_phase = 3;

            // we first finalize value types, because MS.NET runtime requires so
            IterConditionally(emit_impl,
                (TypeBuilder x) => x.IsValueType && x.DeclaringType == null);

            // now we can finalize everything else
            Iter(emit_impl);

            // MaybeBailout inteferes with the Code Completion Engine
            //unless (Manager.IsIntelliSenseMode)
            //  Message.MaybeBailout ();

            if (!aux_phase)
                _cgil_phase = 4;
        }

        internal void EnsureEmitProgress(TypeBuilder ti)
        {
            // Message.Debug ($"ma: $ti -> $mem ");
            if (_cgil_phase >= 1)
            {
                ti.CreateEmitBuilder();
                ti.UpdateEmittedInheritance();
            }
        }

        internal void MaybeCompile(TypeBuilder ti, MemberBuilder mem)
        {
            mem.CreateEmitBuilder(ti.GetTypeBuilder());

            if (_cgil_phase >= 3)
                ti.DoBeforeFinalization(() => mem.Compile())
        }

        /**
         * Check if declaration is auxiliary, used internally etc.
         */
        private static bool is_aux_decl(TypeBuilder ti) => ti.FullName.StartsWith("Nemerle.Internal.");

        private static (PortableExecutableKinds, ImageFileMachine) make_platform_flags(string platform)
        {
            switch (platform)
            {
                case "x86":
                    return (PortableExecutableKinds.ILOnly | PortableExecutableKinds.Required32Bit,
                        ImageFileMachine.I386);
                case "x64":
                    return (PortableExecutableKinds.ILOnly | PortableExecutableKinds.PE32Plus, ImageFileMachine.AMD64);
                case "":
                case "anycpu":
                    return (PortableExecutableKinds.ILOnly, ImageFileMachine.I386);
                case "ia64":
                    return (PortableExecutableKinds.ILOnly | PortableExecutableKinds.PE32Plus, ImageFileMachine.IA64);
                default:
                    //assert(false);
                    throw new ArgumentException();
            }
        }
    }
}
