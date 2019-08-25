using System;

namespace Nemerle.Builtins
{
    internal static class Lambda
    {
        internal static Function<T, TResult> New<T, TResult>(Func<T, TResult> func) => new Impl<T, TResult>(func);
        private sealed class Impl<T, TResult> : Function<T, TResult>
        {
            private readonly Func<T, TResult> lambda;

            internal Impl(Func<T, TResult> lambda) => this.lambda = lambda;

            public override TResult apply(T arg) => lambda(arg);
        }

        internal static Function<T> New<T>(Func<T> func) => new Impl<T>(func);
        private sealed class Impl<T> : Function<T>
        {
            private readonly Func<T> lambda;

            internal Impl(Func<T> lambda) => this.lambda = lambda;

            public override T apply() => lambda();
        }

        internal static Function<T1, T2, TResult> New<T1, T2, TResult>(Func<T1, T2, TResult> func) => new Impl<T1, T2, TResult>(func);
        private sealed class Impl<T1, T2, TResult> : Function<T1, T2, TResult>
        {
            private readonly Func<T1, T2, TResult> lambda;

            internal Impl(Func<T1, T2, TResult> lambda) => this.lambda = lambda;

            public override TResult apply(T1 p1, T2 p2) => lambda(p1, p2);
        }


        internal static FunctionVoid New(Action action) => new VoidImpl(action);
        private sealed class VoidImpl : FunctionVoid
        {
            private readonly Action lambda;

            internal VoidImpl(Action lambda) => this.lambda = lambda;

            public override void apply_void() => lambda();
        }

        internal static FunctionVoid<T> New<T>(Action<T> action) => new VoidImpl<T>(action);
        private sealed class VoidImpl<T> : FunctionVoid<T>
        {
            private readonly Action<T> lambda;

            internal VoidImpl(Action<T> lambda) => this.lambda = lambda;

            public override void apply_void(T p1) => lambda(p1);
        }
    }
}
