using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Nemerle.Internal;

namespace Nemerle.Builtins
{
    [DebuggerDisplay("({Field0}, {Field1})")]
    [DebuggerNonUserCode]
    [Serializable]
    public struct Tuple<T0, T1> : IEquatable<Tuple<T0, T1>>, IStructuralEquatable
    {
        public T0 Field0;
        public T1 Field1;

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1)
        {
            this.Field0 = field0;
            this.Field1 = field1;
        }

        public bool Equals(Tuple<T0, T1> other) => EqualsImpl(other);

        public bool Equals(object other, IEqualityComparer comparer) => Equals(other);

        public int GetHashCode(IEqualityComparer comparer) => GetHashCode();

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other) => other is Tuple<T0, T1> && EqualsImpl((Tuple<T0, T1>)other);

        private bool EqualsImpl(Tuple<T0, T1> other)
            => EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1)
                && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);

        public static bool operator !=(Tuple<T0, T1> first, Tuple<T0, T1> second) => !(first == second);

        public static bool operator ==(Tuple<T0, T1> first, Tuple<T0, T1> second) => first.Equals(second);
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2})")]
    [DebuggerNonUserCode]
    [Serializable]
    public struct Tuple<T0, T1, T2> : IEquatable<Tuple<T0, T1, T2>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public int GetHashCode(IEqualityComparer comparer) => GetHashCode();

        public bool Equals(object other, IEqualityComparer comparer) => Equals(other);

        public static bool operator !=(Tuple<T0, T1, T2> first, Tuple<T0, T1, T2> second) => !(first == second);

        public static bool operator ==(Tuple<T0, T1, T2> first, Tuple<T0, T1, T2> second) => first.Equals(second);

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other) => other is Tuple<T0, T1, T2> && EqualsImpl((Tuple<T0, T1, T2>)other);

        public bool Equals(Tuple<T0, T1, T2> other) => EqualsImpl(other);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2> other)
            => EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2)
                && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1)
                && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3> : IEquatable<Tuple<T0, T1, T2, T3>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3> first, Tuple<T0, T1, T2, T3> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3> first, Tuple<T0, T1, T2, T3> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3> && this.EqualsImpl((Tuple<T0, T1, T2, T3>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3> other)
        {
            return (object)other != null && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4> : IEquatable<Tuple<T0, T1, T2, T3, T4>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4> first, Tuple<T0, T1, T2, T3, T4> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4> first, Tuple<T0, T1, T2, T3, T4> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4> other)
        {
            return (object)other != null && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5> first, Tuple<T0, T1, T2, T3, T4, T5> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5> first, Tuple<T0, T1, T2, T3, T4, T5> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5> other)
        {
            return (object)other != null && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6> first, Tuple<T0, T1, T2, T3, T4, T5, T6> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6> first, Tuple<T0, T1, T2, T3, T4, T5, T6> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6> other)
        {
            return (object)other != null && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7> other)
        {
            return (object)other != null && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8> other)
        {
            return (object)other != null && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> other)
        {
            return (object)other != null && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other)
        {
            return (object)other != null && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other)
        {
            return (object)other != null && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other)
        {
            return (object)other != null && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other)
        {
            return (object)other != null && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other)
        {
            return (object)other != null && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14}, {Field15})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public readonly T15 Field15;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T15>.Default.GetHashCode(this.Field15);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field15);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other)
        {
            return (object)other != null && EqualityComparer<T15>.Default.Equals(this.Field15, other.Field15) && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14, [MappedMember("Field15")] T15 field15)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
            this.Field15 = field15;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14}, {Field15}, {Field16})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public readonly T15 Field15;

        public readonly T16 Field16;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T15>.Default.GetHashCode(this.Field15);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T16>.Default.GetHashCode(this.Field16);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field15);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field16);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other)
        {
            return (object)other != null && EqualityComparer<T16>.Default.Equals(this.Field16, other.Field16) && EqualityComparer<T15>.Default.Equals(this.Field15, other.Field15) && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14, [MappedMember("Field15")] T15 field15, [MappedMember("Field16")] T16 field16)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
            this.Field15 = field15;
            this.Field16 = field16;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14}, {Field15}, {Field16}, {Field17})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public readonly T15 Field15;

        public readonly T16 Field16;

        public readonly T17 Field17;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T15>.Default.GetHashCode(this.Field15);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T16>.Default.GetHashCode(this.Field16);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T17>.Default.GetHashCode(this.Field17);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field15);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field16);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field17);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> other)
        {
            return (object)other != null && EqualityComparer<T17>.Default.Equals(this.Field17, other.Field17) && EqualityComparer<T16>.Default.Equals(this.Field16, other.Field16) && EqualityComparer<T15>.Default.Equals(this.Field15, other.Field15) && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14, [MappedMember("Field15")] T15 field15, [MappedMember("Field16")] T16 field16, [MappedMember("Field17")] T17 field17)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
            this.Field15 = field15;
            this.Field16 = field16;
            this.Field17 = field17;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14}, {Field15}, {Field16}, {Field17}, {Field18})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public readonly T15 Field15;

        public readonly T16 Field16;

        public readonly T17 Field17;

        public readonly T18 Field18;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T15>.Default.GetHashCode(this.Field15);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T16>.Default.GetHashCode(this.Field16);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T17>.Default.GetHashCode(this.Field17);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T18>.Default.GetHashCode(this.Field18);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field15);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field16);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field17);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field18);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> other)
        {
            return (object)other != null && EqualityComparer<T18>.Default.Equals(this.Field18, other.Field18) && EqualityComparer<T17>.Default.Equals(this.Field17, other.Field17) && EqualityComparer<T16>.Default.Equals(this.Field16, other.Field16) && EqualityComparer<T15>.Default.Equals(this.Field15, other.Field15) && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14, [MappedMember("Field15")] T15 field15, [MappedMember("Field16")] T16 field16, [MappedMember("Field17")] T17 field17, [MappedMember("Field18")] T18 field18)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
            this.Field15 = field15;
            this.Field16 = field16;
            this.Field17 = field17;
            this.Field18 = field18;
        }
    }

    [DebuggerDisplay("({Field0}, {Field1}, {Field2}, {Field3}, {Field4}, {Field5}, {Field6}, {Field7}, {Field8}, {Field9}, {Field10}, {Field11}, {Field12}, {Field13}, {Field14}, {Field15}, {Field16}, {Field17}, {Field18}, {Field19})"), DebuggerNonUserCode]
    [Serializable]
    public sealed class Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : IEquatable<Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>>, IStructuralEquatable
    {
        public readonly T0 Field0;

        public readonly T1 Field1;

        public readonly T2 Field2;

        public readonly T3 Field3;

        public readonly T4 Field4;

        public readonly T5 Field5;

        public readonly T6 Field6;

        public readonly T7 Field7;

        public readonly T8 Field8;

        public readonly T9 Field9;

        public readonly T10 Field10;

        public readonly T11 Field11;

        public readonly T12 Field12;

        public readonly T13 Field13;

        public readonly T14 Field14;

        public readonly T15 Field15;

        public readonly T16 Field16;

        public readonly T17 Field17;

        public readonly T18 Field18;

        public readonly T19 Field19;

        public int GetHashCode(IEqualityComparer _comparer)
        {
            return this.GetHashCode();
        }

        public bool Equals(object other, IEqualityComparer _comparer)
        {
            return this.Equals(other);
        }

        public static bool operator !=(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> second)
        {
            return !(first == second);
        }

        public static bool operator ==(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> first, Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> second)
        {
            return ((object)first != null) ? first.Equals(second) : ((object)second == null);
        }

        public override int GetHashCode()
        {
            int num = 0;
            num += EqualityComparer<T0>.Default.GetHashCode(this.Field0);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T1>.Default.GetHashCode(this.Field1);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T2>.Default.GetHashCode(this.Field2);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T3>.Default.GetHashCode(this.Field3);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T4>.Default.GetHashCode(this.Field4);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T5>.Default.GetHashCode(this.Field5);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T6>.Default.GetHashCode(this.Field6);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T7>.Default.GetHashCode(this.Field7);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T8>.Default.GetHashCode(this.Field8);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T9>.Default.GetHashCode(this.Field9);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T10>.Default.GetHashCode(this.Field10);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T11>.Default.GetHashCode(this.Field11);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T12>.Default.GetHashCode(this.Field12);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T13>.Default.GetHashCode(this.Field13);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T14>.Default.GetHashCode(this.Field14);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T15>.Default.GetHashCode(this.Field15);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T16>.Default.GetHashCode(this.Field16);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T17>.Default.GetHashCode(this.Field17);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T18>.Default.GetHashCode(this.Field18);
            num += num << 10;
            num = (num ^ num >> 6) + EqualityComparer<T19>.Default.GetHashCode(this.Field19);
            num += num << 10;
            return num ^ num >> 6;
        }

        public override bool Equals(object other)
        {
            return other is Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> && this.EqualsImpl((Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>)other);
        }

        public bool Equals(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> other)
        {
            return this.EqualsImpl(other);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            StringBuilder stringBuilder2 = stringBuilder.Append(this.Field0);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field1);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field2);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field3);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field4);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field5);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field6);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field7);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field8);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field9);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field10);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field11);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field12);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field13);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field14);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field15);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field16);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field17);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field18);
            stringBuilder2 = stringBuilder.Append(", ");
            stringBuilder2 = stringBuilder.Append(this.Field19);
            stringBuilder2 = stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private bool EqualsImpl(Tuple<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> other)
        {
            return (object)other != null && EqualityComparer<T19>.Default.Equals(this.Field19, other.Field19) && EqualityComparer<T18>.Default.Equals(this.Field18, other.Field18) && EqualityComparer<T17>.Default.Equals(this.Field17, other.Field17) && EqualityComparer<T16>.Default.Equals(this.Field16, other.Field16) && EqualityComparer<T15>.Default.Equals(this.Field15, other.Field15) && EqualityComparer<T14>.Default.Equals(this.Field14, other.Field14) && EqualityComparer<T13>.Default.Equals(this.Field13, other.Field13) && EqualityComparer<T12>.Default.Equals(this.Field12, other.Field12) && EqualityComparer<T11>.Default.Equals(this.Field11, other.Field11) && EqualityComparer<T10>.Default.Equals(this.Field10, other.Field10) && EqualityComparer<T9>.Default.Equals(this.Field9, other.Field9) && EqualityComparer<T8>.Default.Equals(this.Field8, other.Field8) && EqualityComparer<T7>.Default.Equals(this.Field7, other.Field7) && EqualityComparer<T6>.Default.Equals(this.Field6, other.Field6) && EqualityComparer<T5>.Default.Equals(this.Field5, other.Field5) && EqualityComparer<T4>.Default.Equals(this.Field4, other.Field4) && EqualityComparer<T3>.Default.Equals(this.Field3, other.Field3) && EqualityComparer<T2>.Default.Equals(this.Field2, other.Field2) && EqualityComparer<T1>.Default.Equals(this.Field1, other.Field1) && EqualityComparer<T0>.Default.Equals(this.Field0, other.Field0);
        }

        [RecordCtor]
        public Tuple([MappedMember("Field0")] T0 field0, [MappedMember("Field1")] T1 field1, [MappedMember("Field2")] T2 field2, [MappedMember("Field3")] T3 field3, [MappedMember("Field4")] T4 field4, [MappedMember("Field5")] T5 field5, [MappedMember("Field6")] T6 field6, [MappedMember("Field7")] T7 field7, [MappedMember("Field8")] T8 field8, [MappedMember("Field9")] T9 field9, [MappedMember("Field10")] T10 field10, [MappedMember("Field11")] T11 field11, [MappedMember("Field12")] T12 field12, [MappedMember("Field13")] T13 field13, [MappedMember("Field14")] T14 field14, [MappedMember("Field15")] T15 field15, [MappedMember("Field16")] T16 field16, [MappedMember("Field17")] T17 field17, [MappedMember("Field18")] T18 field18, [MappedMember("Field19")] T19 field19)
        {
            this.Field0 = field0;
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
            this.Field4 = field4;
            this.Field5 = field5;
            this.Field6 = field6;
            this.Field7 = field7;
            this.Field8 = field8;
            this.Field9 = field9;
            this.Field10 = field10;
            this.Field11 = field11;
            this.Field12 = field12;
            this.Field13 = field13;
            this.Field14 = field14;
            this.Field15 = field15;
            this.Field16 = field16;
            this.Field17 = field17;
            this.Field18 = field18;
            this.Field19 = field19;
        }
    }
}
