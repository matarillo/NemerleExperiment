using System;
using System.Diagnostics;

namespace Nemerle.Builtins
{
    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2> : FunctionVoid<T1, T2>
    {
        private readonly FunctionVoid<Tuple<T1, T2>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2)
        {
            this.fn.apply_void(new Tuple<T1, T2>(a1, a2));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3> : FunctionVoid<T1, T2, T3>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3>(a1, a2, a3));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4> : FunctionVoid<T1, T2, T3, T4>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4>(a1, a2, a3, a4));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5> : FunctionVoid<T1, T2, T3, T4, T5>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5>(a1, a2, a3, a4, a5));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6> : FunctionVoid<T1, T2, T3, T4, T5, T6>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6>(a1, a2, a3, a4, a5, a6));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7>(a1, a2, a3, a4, a5, a6, a7));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(a1, a2, a3, a4, a5, a6, a7, a8));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(a1, a2, a3, a4, a5, a6, a7, a8, a9));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18, T19 a19)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionVoidFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> : FunctionVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>
    {
        private readonly FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> fn;

        public FunctionVoidFromTuple(FunctionVoid<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> f)
        {
            this.fn = f;
        }

        public override void apply_void(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18, T19 a19, T20 a20)
        {
            this.fn.apply_void(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20));
        }
    }
}
