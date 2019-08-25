using System;
using System.Diagnostics;

namespace Nemerle.Builtins
{
    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, TResult> : Function<T1, T2, TResult>
    {
        private readonly Function<Tuple<T1, T2>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2)
        {
            return this.fn.apply(new Tuple<T1, T2>(a1, a2));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, TResult> : Function<T1, T2, T3, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3)
        {
            return this.fn.apply(new Tuple<T1, T2, T3>(a1, a2, a3));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, TResult> : Function<T1, T2, T3, T4, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4>(a1, a2, a3, a4));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, TResult> : Function<T1, T2, T3, T4, T5, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5>(a1, a2, a3, a4, a5));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, TResult> : Function<T1, T2, T3, T4, T5, T6, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6>(a1, a2, a3, a4, a5, a6));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7>(a1, a2, a3, a4, a5, a6, a7));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(a1, a2, a3, a4, a5, a6, a7, a8));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(a1, a2, a3, a4, a5, a6, a7, a8, a9));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18, T19 a19)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19));
        }
    }

    [DebuggerNonUserCode]
    public class FunctionFromTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult> : Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>
    {
        private readonly Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>, TResult> fn;

        public FunctionFromTuple(Function<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>, TResult> f)
        {
            this.fn = f;
        }

        public override TResult apply(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16, T17 a17, T18 a18, T19 a19, T20 a20)
        {
            return this.fn.apply(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20));
        }
    }
}
