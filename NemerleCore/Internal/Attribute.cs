using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Nemerle.Internal
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class ExtensionPatternEncodingAttribute : NemerleAttribute
    {
        public string Name { get; }

        public string Identifiers {get ;}

        public string Pattern {get;}

        public override string ToString()
        {
            return string.Concat(new string[]
            {
                Convert.ToString(base.GetType().Name),
                ": ",
                Convert.ToString(this.Name),
                ", Pattern:(",
                Convert.ToString(this.Pattern),
                "), Identifiers:(",
                Convert.ToString(this.Identifiers),
                ")"
            });
        }

        [RecordCtor]
        public ExtensionPatternEncodingAttribute([MappedMember("Name")] string name, [MappedMember("Identifiers")] string identifiers, [MappedMember("Pattern")] string pattern)
        {
            this.Name = name;
            this.Identifiers = identifiers;
            this.Pattern = pattern;
        }
    }

    /// <summary>
    ///   <para>Marks a constant Nemerle variant option</para>
    /// </summary>
    public sealed class ConstantVariantOptionAttribute : NemerleAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : NemerleAttribute
    {
    }

    /// <summary>
    ///   <para>Marks an immutable field</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ImmutableAttribute : NemerleAttribute
    {
    }

	[AttributeUsage(AttributeTargets.All)]
	public sealed class MacroAttribute : NemerleAttribute
	{
		public readonly string name;

		public readonly int global_ctx;

		public readonly string parameters;

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				Convert.ToString(base.GetType().Name),
				": ",
				Convert.ToString(this.name),
				" (",
				Convert.ToString(this.parameters),
				")"
			});
		}

		[RecordCtor]
		public MacroAttribute([MappedMember("name")] string name, [MappedMember("global_ctx")] int global_ctx, [MappedMember("parameters")] string parameters)
		{
			this.name = name;
			this.global_ctx = global_ctx;
			this.parameters = parameters;
		}
	}


    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class MappedMemberAttribute : Attribute
    {
        public string Name { get; }

        [RecordCtor]
        public MappedMemberAttribute([MappedMember("Name")] string name)
        {
            this.Name = name;
        }
    }

    public class NemerleAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class RecordCtorAttribute : Attribute
    {
    }

    /// <summary>
    ///   <para>Container for type aliases.</para>
    /// </summary>
    public sealed class TypeAliasAttribute : NemerleAttribute
    {
        public string AliasedType { get; }

        public override string ToString()
        {
            return Convert.ToString(base.GetType().Name) + ": " + Convert.ToString(this.AliasedType);
        }

        /// <summary>
        ///   <para>Container for type aliases.</para>
        /// </summary>
        [RecordCtor]
        public TypeAliasAttribute([MappedMember("AliasedType")] string aliasedType)
        {
            this.AliasedType = aliasedType;
        }
    }

    /// <summary>
    ///   <para>Marks a Nemerle variant type
    /// </para>
    /// </summary>
    public sealed class VariantAttribute : NemerleAttribute
    {
        public string VariantOptions { get; }

        public override string ToString()
        {
            return Convert.ToString(base.GetType().Name) + ": " + Convert.ToString(this.VariantOptions);
        }

        /// <summary>
        ///   <para>Marks a Nemerle variant type
        /// </para>
        /// </summary>
        [RecordCtor]
        public VariantAttribute([MappedMember("VariantOptions")] string variantOptions)
        {
            this.VariantOptions = variantOptions;
        }
    }

    /// <summary>
    ///   <para>Marks a Nemerle variant option</para>
    /// </summary>
    public sealed class VariantOptionAttribute : NemerleAttribute
    {
    }
}
