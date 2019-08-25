using System;
using System.Diagnostics;

namespace Nemerle.Builtins
{
    [DebuggerNonUserCode]
    public abstract class FunctionVoid : Function<object>
    {
        public abstract void apply_void();

        public override object apply()
        {
            this.apply_void();
            return null;
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T> : Function<T, object>
    {
        public abstract void apply_void(T p1);

        public override object apply(T p1)
        {
            this.apply_void(p1);
            return null;
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2> : FunctionVoid<Tuple<T1, T2>>
    {
        public abstract void apply_void(T1 p1, T2 p2);

        public override void apply_void(Tuple<T1, T2> o)
        {
            this.apply_void(o.Field0, o.Field1);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3> : FunctionVoid<Tuple<T1, T2, T3>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3);

        public override void apply_void(Tuple<T1, T2, T3> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4> : FunctionVoid<Tuple<T1, T2, T3, T4>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4);

        public override void apply_void(Tuple<T1, T2, T3, T4> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5> : FunctionVoid<Tuple<T1, T2, T3, T4, T5>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17, o.Field18);
        }
    }

    [DebuggerNonUserCode]
    public abstract class FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> : FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>>
    {
        public abstract void apply_void(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20);

        public override void apply_void(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> o)
        {
            this.apply_void(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17, o.Field18, o.Field19);
        }
    }
}
