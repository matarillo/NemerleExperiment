using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security;
using Nemerle.Builtins;
using Nemerle.Internal;

namespace Nemerle.Core
{
    /// <summary>
    ///   <para>The optional value variant.</para>
    /// </summary>
    [Variant("Nemerle.Core.option.None,Nemerle.Core.option.Some")]
    [DebuggerNonUserCode]
    [Serializable]
    public abstract class option<T> : IEquatable<option<T>>
    {
        [ConstantVariantOption, DebuggerNonUserCode]
        [Serializable]
        public class None : option<T>, IObjectReference
        {
            public static readonly option<T>.None _N_constant_object;

            public static option<T>.None _N_constant_object_generator()
            {
                return option<T>.None._N_constant_object;
            }

            [SecurityCritical]
            public object GetRealObject(StreamingContext _N_wildcard_3400)
            {
                return option<T>.None._N_constant_object;
            }

            static None()
            {
                option<T>.None._N_constant_object = new option<T>.None();
            }

            public override int _N_GetVariantCode()
            {
                return 0;
            }

            [RecordCtor]
            private None()
            {
            }
        }

        [VariantOption, DebuggerNonUserCode]
        [Serializable]
        public class Some : option<T>
        {
            public readonly T val;

            public override int _N_GetVariantCode()
            {
                return 1;
            }

            [RecordCtor]
            public Some([MappedMember("val")] T val)
            {
                this.val = val;
            }
        }

        public bool IsSome
        {
            get
            {
                return this is option<T>.Some;
            }
        }

        public bool IsNone
        {
            get
            {
                return this == option<T>.None._N_constant_object;
            }
        }

        public bool HasValue
        {
            get
            {
                return this is option<T>.Some;
            }
        }

        public T Value
        {
            get
            {
                if (this is option<T>.Some)
                {
                    return ((option<T>.Some)this).val;
                }
                if (this == option<T>.None._N_constant_object)
                {
                    throw new ArgumentException("option.Value");
                }
                throw new MatchFailureException();
            }
        }

        /// <summary>
        ///   <para>Pretty prints the optional value.</para>
        /// </summary>
        public override string ToString()
        {
            string arg_84_0;
            if (this is option<T>.Some)
            {
                T val = ((option<T>.Some)this).val;
                if (val == null)
                {
                    arg_84_0 = "Some()";
                }
                else
                {
                    val = ((option<T>.Some)this).val;
                    arg_84_0 = "Some (" + val.ToString() + ")";
                }
            }
            else
            {
                if (this != option<T>.None._N_constant_object)
                {
                    throw new MatchFailureException();
                }
                arg_84_0 = "None";
            }
            return arg_84_0;
        }

        /// <summary>
        ///   <para>Typesafe equality checks.</para>
        /// </summary>
        public bool Equals(option<T> o)
        {
            return Option.Equals<T>(this, o);
        }

        /// <summary>
        ///   <para>Structural HashCode provider</para>
        /// </summary>
        public override int GetHashCode()
        {
            int arg_4A_0;
            if (this == option<T>.None._N_constant_object)
            {
                arg_4A_0 = 0;
            }
            else
            {
                if (!(this is option<T>.Some))
                {
                    throw new MatchFailureException();
                }
                T val = ((option<T>.Some)this).val;
                arg_4A_0 = val.GetHashCode();
            }
            return arg_4A_0;
        }

        public T GetValueOrDefault()
        {
            T arg_46_0;
            if (this is option<T>.Some)
            {
                T val = ((option<T>.Some)this).val;
                arg_46_0 = val;
            }
            else
            {
                if (this != option<T>.None._N_constant_object)
                {
                    throw new MatchFailureException();
                }
                arg_46_0 = default(T);
            }
            return arg_46_0;
        }

        public T WithDefault(T defaultValue)
        {
            T arg_3E_0;
            if (this is option<T>.Some)
            {
                T val = ((option<T>.Some)this).val;
                arg_3E_0 = val;
            }
            else
            {
                if (this != option<T>.None._N_constant_object)
                {
                    throw new MatchFailureException();
                }
                arg_3E_0 = defaultValue;
            }
            return arg_3E_0;
        }

        public static option<TFrom> op_Implicit<TFrom>(TFrom? value) where TFrom : struct
        {
            if (!value.HasValue)
            {
                return option<TFrom>.None._N_constant_object;
            }
            else
            {
                return new option<TFrom>.Some(value.Value);
            }
        }

        /// <summary>
        ///   <para>Typesafe equality checks.</para>
        /// </summary>
        public override bool Equals(object other)
        {
            return other == this || (other is option<T> && this.Equals((option<T>)other));
        }

        /// <summary>
        ///   <para>The optional value variant.</para>
        /// </summary>
        public abstract int _N_GetVariantCode();

        public static int _N_GetVariantCodeSafe(option<T> x)
        {
            return ((object)x != null) ? x._N_GetVariantCode() : -1;
        }

        public static int _N_GetVariantCodeObject(object x)
        {
            return (!(x is option<T>)) ? -1 : ((option<T>)x)._N_GetVariantCode();
        }
    }

    /// <summary>
    ///   <para>Operations on optional values</para>
    /// </summary>
    [Extension]
    public static class Option
    {
        /// <summary>
        ///   <para>Safe equality check</para>
        /// </summary>
        public static bool Equals<T>(option<T> x, option<T> y)
        {
            int arg_A2_0;
            if (x is option<T>.Some)
            {
                if (y is option<T>.Some)
                {
                    T val = ((option<T>.Some)x).val;
                    T val2 = ((option<T>.Some)y).val;
                    arg_A2_0 = (val.Equals(val2) ? 1 : 0);
                    return arg_A2_0 != 0;
                }
            }
            else if (x == option<T>.None._N_constant_object)
            {
                if (y == option<T>.None._N_constant_object)
                {
                    arg_A2_0 = 1;
                    return arg_A2_0 != 0;
                }
            }
            else if ((object)y == null)
            {
                throw new ArgumentException("option can't be null");
            }
            arg_A2_0 = 0;
            return arg_A2_0 != 0;
        }

        /// <summary>
        ///   <para>Safe optional value mapping.</para>
        /// </summary>
        [Extension]
        public static option<TTo> Map<T, TTo>(this option<T> x, Function<T, TTo> f)
        {
            option<TTo> arg_4E_0;
            if (x is option<T>.Some)
            {
                T val = ((option<T>.Some)x).val;
                arg_4E_0 = new option<TTo>.Some(f.apply(val));
            }
            else
            {
                if ((object)x == null)
                {
                    throw new ArgumentException("option can't be null");
                }
                arg_4E_0 = option<TTo>.None._N_constant_object;
            }
            return arg_4E_0;
        }

        /// <summary>
        ///   <para>Same as ignore (Map (x, f)).</para>
        /// </summary>
        [Extension]
        public static void Iter<T>(this option<T> x, FunctionVoid<T> f)
        {
            if (x is option<T>.Some)
            {
                T val = ((option<T>.Some)x).val;
                f.apply_void(val);
            }
            else if ((object)x == null)
            {
            }
        }

        /// <summary>
        ///   <para>Checks if the optional value is present.</para>
        /// </summary>
        public static bool IsSome<T>(option<T> x)
        {
            return x is option<T>.Some;
        }

        /// <summary>
        ///   <para>Returns `true' if the optional value is not present.</para>
        /// </summary>
        public static bool IsNone<T>(option<T> x)
        {
            bool arg_29_0;
            if (x == option<T>.None._N_constant_object)
            {
                arg_29_0 = true;
            }
            else
            {
                if ((object)x == null)
                {
                    throw new ArgumentException("option can't be null");
                }
                arg_29_0 = false;
            }
            return arg_29_0;
        }

        /// <summary>
        ///   <para>Unwraps an optional value; throws an argument exception if the value is not present.</para>
        /// </summary>
        [Extension]
        public static T UnSome<T>(this option<T> x)
        {
            if (x is option<T>.Some)
            {
                return ((option<T>.Some)x).val;
            }
            throw new ArgumentException("Option.UnSome");
        }

        /// <summary>
        ///   <para>Converts nullable value to optional value.</para>
        /// </summary>
        [Extension]
        public static option<T> ToOption<T>(this T? x) where T : struct
        {
            return option<T>.op_Implicit(x);
        }
    }
}
