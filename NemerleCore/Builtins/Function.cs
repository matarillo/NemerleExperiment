using System;
using System.Diagnostics;

namespace Nemerle.Builtins
{
    [DebuggerNonUserCode]
    public abstract class Function<T, TResult>
    {
        public abstract TResult apply(T arg);

        public static Function<T, TResult> op_RightShift<B>(Function<T, B> fab, Function<B, TResult> fbc)
            => Lambda.New<T, TResult>(a => fbc.apply(fab.apply(a)));

        public static Function<TResult> op_RightShift<B>(Function<B> fab, Function<B, TResult> fbc)
            => Lambda.New<TResult>(() => fbc.apply(fab.apply()));

        public static FunctionVoid<T> op_RightShift<B>(Function<T, B> fab, FunctionVoid<B> fbc)
            => Lambda.New<T>(a => fbc.apply_void(fab.apply(a)));

        public static FunctionVoid op_RightShift<B>(Function<B> fab, FunctionVoid<B> fbc)
            => Lambda.New(() => fbc.apply_void(fab.apply()));

        public static Function<T, TResult> op_LeftShift<B>(Function<B, TResult> fbc, Function<T, B> fab)
            => Lambda.New<T, TResult>(a => fbc.apply(fab.apply(a)));

        public static Function<TResult> op_LeftShift<B>(Function<B, TResult> fbc, Function<B> fab)
            => Lambda.New<TResult>(() => fbc.apply(fab.apply()));

        public static FunctionVoid<T> op_LeftShift<B>(FunctionVoid<B> fbc, Function<T, B> fab)
            => Lambda.New<T>(a => fbc.apply_void(fab.apply(a)));

        public static FunctionVoid op_LeftShift<B>(FunctionVoid<B> fbc, Function<B> fab)
            => Lambda.New(() => fbc.apply_void(fab.apply()));

        public static TResult op_RightPipe(T a, Function<T, TResult> fac) => fac.apply(a);

        public static void op_RightPipe(T a, FunctionVoid<T> fac) => fac.apply_void(a);

        public static TResult op_LeftPipe(Function<T, TResult> fac, T a) => fac.apply(a);

        public static void op_LeftPipe(FunctionVoid<T> fac, T a) => fac.apply_void(a);
    }

    [DebuggerNonUserCode]
    public abstract class Function<T> : Function<object, T>
    {
        public abstract T apply();

        public override T apply(object _) => apply();
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, TResult> : Function<Tuple<T1, T2>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2);

        public override TResult apply(Tuple<T1, T2> o)
        {
            return this.apply(o.Field0, o.Field1);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, TResult> : Function<Tuple<T1, T2, T3>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3);

        public override TResult apply(Tuple<T1, T2, T3> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, TResult> : Function<Tuple<T1, T2, T3, T4>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4);

        public override TResult apply(Tuple<T1, T2, T3, T4> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, TResult> : Function<Tuple<T1, T2, T3, T4, T5>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17, o.Field18);
        }
    }

    [DebuggerNonUserCode]
    public abstract class Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult> : Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>, TResult>
    {
        public abstract TResult apply(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20);

        public override TResult apply(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> o)
        {
            return this.apply(o.Field0, o.Field1, o.Field2, o.Field3, o.Field4, o.Field5, o.Field6, o.Field7, o.Field8, o.Field9, o.Field10, o.Field11, o.Field12, o.Field13, o.Field14, o.Field15, o.Field16, o.Field17, o.Field18, o.Field19);
        }
    }
}
