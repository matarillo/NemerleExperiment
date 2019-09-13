namespace Nemerle.Compiler
{
    public abstract class FixedType : TypeVar
    {
        public sealed class Class : FixedType
        {
        }
        public sealed class StaticTypeVarRef : FixedType
        {
        }
        public sealed class Fun : FixedType
        {
        }
        public sealed class Tuple : FixedType
        {
        }
        public sealed class Array : FixedType
        {
        }
        public sealed class Ref : FixedType
        {
        }
        public sealed class Out : FixedType
        {
        }
        public sealed class Void : FixedType
        {
        }
        public sealed class Intersection : FixedType
        {
        }
    }
}