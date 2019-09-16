using System;

namespace Nemerle
{
    public static class Option
    {
        public static Option<T> Some<T>(T value) => new Option<T>.Some(value);
        public static Option<T> None<T>() => new Option<T>.None();

        public static bool IsSome<T>(Option<T> o, out T value)
        {
            Option<T>.Some some = o as Option<T>.Some;
            value = (some != null) ? some.Value : default(T);
            return (some != null);
        }
    }

    public abstract class Option<T>
    {
        public abstract bool HasValue { get; }
        public abstract T Value { get; }
        
        internal sealed class Some : Option<T>
        {
            private T value;
            internal Some(T value) => this.value = value;
            public override bool HasValue => true;
            public override T Value => this.value;
        }

        internal class None : Option<T>
        {
            public override bool HasValue => false;
            public override T Value => throw new InvalidOperationException();
        }
    }
}