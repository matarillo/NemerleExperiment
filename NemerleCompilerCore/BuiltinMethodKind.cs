namespace Nemerle.Compiler
{
    public abstract class BuiltinMethodKind
    {
        public sealed class NotBuiltin : BuiltinMethodKind
        {
        }
        public sealed class OpCode : BuiltinMethodKind
        {
            public string checked_opcode { get; }
            public  string unchecked_opcode { get; }
            public OpCode(string checkedOpcode, string uncheckedOpcode)
            {
                this.checked_opcode = checkedOpcode;
                this.unchecked_opcode = uncheckedOpcode;
            }
        }
        public sealed class CallWithCast : BuiltinMethodKind
        {
        }
        public sealed class ValueTypeConversion : BuiltinMethodKind
        {
        }
        public sealed class ExtensionMethod : BuiltinMethodKind
        {
        }
    }
}