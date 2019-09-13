using System.Collections.Generic;

namespace Nemerle.Compiler
{
    public abstract class MemberBuilder : MemberInfo, IMember, System.IEquatable<IMember>
    {
        public bool IsConstructor { get; }
        public FixedType GetMemType()
        {
            throw new System.NotImplementedException();
        }

        public Location Location { get; }
        public bool CanAccess(TypeInfo source)
        {
            throw new System.NotImplementedException();
        }

        public bool CanAccess(TypeInfo memberTypeInfo, TypeInfo currentTypeInfo, bool isThisAccess)
        {
            throw new System.NotImplementedException();
        }

        public bool IsObsolete { get; }
        public bool IsPrivate { get; }
        public TypeInfo DeclaringType { get; }
        public string Name { get; }
        public Location NameLocation { get; }
        public MemberKinds MemberKind { get; }
        public bool IsStatic { get; }
        public bool HasBeenUsed { get; set; }
        public bool IsConditional { get; }
        public IList<string> GetConditions()
        {
            throw new System.NotImplementedException();
        }

        public NemerleModifiers Attributes { get; }
        public System.Reflection.MemberInfo GetHandle()
        {
            throw new System.NotImplementedException();
        }

        public AttributesAndModifiers GetModifiers()
        {
            throw new System.NotImplementedException();
        }

        public bool IsCustomAttributeDefined(string attributeFullName)
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(IMember other)
        {
            throw new System.NotImplementedException();
        }
    }
}