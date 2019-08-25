using Nemerle.Internal;

namespace Nemerle.Core
{
    public static class ValueOptionStatic
    {
        public static ValueOption<T> VSome<T>(T value)
        {
            return new ValueOption<T>(value);
        }

        public static ValueOption<T> VNone<T>()
        {
            return default(ValueOption<T>);
        }
    }

    [ExtensionPatternEncoding("VNone", "", "ValueOption where HasValue = false")]
    [ExtensionPatternEncoding("VSome", "value", "ValueOption where (HasValue = true, Value = value)")]
    public struct ValueOption<T>
    {
        private readonly T _value;

        public readonly bool HasValue;

        public T Value
        {
            get
            {
                if (this.HasValue)
                {
                    return this._value;
                }
                throw new AssertionException("lib\\option.n", 234, "", "try use Value when it not set");
            }
        }

        public bool IsSome
        {
            get
            {
                return this.HasValue;
            }
        }

        public bool IsNone
        {
            get
            {
                return !this.HasValue;
            }
        }

        public T GetValueOrDefault()
        {
            return this._value;
        }

        public T WithDefault(T defaultValue)
        {
            return (!this.HasValue) ? defaultValue : this.Value;
        }

        public ValueOption(T value)
        {
            this._value = value;
            this.HasValue = true;
        }

        public static ValueOption<T> None()
        {
            return default(ValueOption<T>);
        }

        public static ValueOption<T> Some(T value)
        {
            return new ValueOption<T>(value);
        }

        public static ValueOption<TFrom> op_Implicit<TFrom>(TFrom? value) where TFrom : struct
        {
            if ((!value.HasValue))
            {
                return ValueOption<TFrom>.None();
            }
            else
            {
                return ValueOption<TFrom>.Some(value.Value);
            }
        }
    }
}
