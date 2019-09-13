using System.Collections.Generic;

namespace Nemerle.Compiler
{
    public interface IMember
    {
        bool IsConstructor { get; }
        FixedType GetMemType();
        Location Location { get; }
        bool CanAccess (TypeInfo source);
        bool CanAccess(TypeInfo memberTypeInfo, TypeInfo currentTypeInfo, bool isThisAccess);
        bool IsObsolete { get; }
        bool IsPrivate { get; }

        TypeInfo DeclaringType { get; }
        string Name  { get; }
        Location NameLocation { get; }
        MemberKinds MemberKind  { get; }

        bool IsStatic { get; } // types are always static
        bool HasBeenUsed { get; set; } // for the 'unused' warnings
        bool IsConditional { get; }
        IList<string> GetConditions();
        NemerleModifiers Attributes { get; }

        System.Reflection.MemberInfo GetHandle();
        AttributesAndModifiers GetModifiers ();
        bool IsCustomAttributeDefined(string attributeFullName);
    }
}