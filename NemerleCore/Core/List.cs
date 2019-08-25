using Nemerle.Builtins;
using Nemerle.Collections;
using Nemerle.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace Nemerle.Core
{
    /// <summary>
    /// <para>
    /// The core datastructure allowing easy manipulating of small
    /// and medium sized collections of elements.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// It has a builtin syntax [] for empty list, x :: xs for creating list
    /// from head element and tail.
    /// </para>
    /// </remarks>
    [Extension]
    [Variant("Nemerle.Core.list.Cons,Nemerle.Core.list.Nil")]
    [DebuggerDisplay("Length = {Length}: {ToString()}")]
    [DebuggerNonUserCode]
    [ComVisible(false)]
    [Serializable]
    public abstract class list<T> : IEnumerable, IEnumerable<T>, ICovariantList<T>, IEquatable<list<T>>
    {
        [VariantOption]
        [DebuggerNonUserCode]
        [Serializable]
        public class Cons : list<T>
        {
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public readonly T hd;

            [Immutable, DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public list<T> tl;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public T[] AsArray2
            {
                get
                {
                    T[] nToArray = this.NToArray;
                    return base.ToArray();
                }
            }

            public override int _N_GetVariantCode()
            {
                return 0;
            }

            [RecordCtor]
            public Cons([MappedMember("hd")] T hd, [MappedMember("tl")] list<T> tl)
            {
                this.hd = hd;
                this.tl = tl;
            }
        }

        [ConstantVariantOption]
        [DebuggerNonUserCode]
        [Serializable]
        public class Nil : list<T>, IObjectReference
        {
            public static readonly list<T>.Nil _N_constant_object;

            public static list<T>.Nil _N_constant_object_generator()
            {
                return list<T>.Nil._N_constant_object;
            }

            [SecurityCritical]
            public object GetRealObject(StreamingContext _N_wildcard_3400)
            {
                return list<T>.Nil._N_constant_object;
            }

            static Nil()
            {
                list<T>.Nil._N_constant_object = new list<T>.Nil();
            }

            public override string ToString()
            {
                return "[]";
            }

            public override int _N_GetVariantCode()
            {
                return 1;
            }

            [RecordCtor]
            private Nil()
            {
            }
        }

        public ICovariantList<T> CovariantTail
        {
            get
            {
                return this.Tail;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Length
        {
            get
            {
                return NList.Length<T>(this);
            }
        }

        /// <summary>
        ///   <para>Returns true if the given list is empty.
        ///
        /// </para>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsEmpty
        {
            get
            {
                return NList.IsEmpty<T>(this);
            }
        }

        /// <summary>
        ///   <para>Returns head (first element) of list.
        ///  Given empty list throws System.ArgumentException.
        ///
        /// </para>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public T Head
        {
            get
            {
                if (this is list<T>.Cons)
                {
                    return ((list<T>.Cons)this).hd;
                }
                if (this == list<T>.Nil._N_constant_object)
                {
                    throw new ArgumentException("NList.Head called with empty list");
                }
                throw new MatchFailureException();
            }
        }

        /// <summary>
        ///   <para>Returns tail (all elements except the first one) of list.
        ///
        /// </para>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public list<T> Tail
        {
            get
            {
                if (this is list<T>.Cons)
                {
                    return (list<T>)((list<T>.Cons)this).tl;
                }
                if (this == list<T>.Nil._N_constant_object)
                {
                    throw new ArgumentException("NList.Tail called for empty list");
                }
                throw new MatchFailureException();
            }
        }

        /// <summary>
        ///   <para>Returns last element of list.
        ///  Given empty list throws InvalidArgument exception.
        ///  Works in time O(n) and memory O(1).
        ///
        /// </para>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public T Last
        {
            get
            {
                return NList.Last<T>(this);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        protected T[] NToArray
        {
            get
            {
                return this.ToArray();
            }
        }

        public override string ToString()
        {
            return "[" + this.ToString(", ") + "]";
        }

        public string ToString(string separator)
        {
            return string.Join(separator, this.MapToArray(Lambda.New<T, string>(x => Convert.ToString(x))));
        }

        public static bool operator ==(list<T> x, list<T> y)
        {
            return (!object.ReferenceEquals(null, x)) ? x.Equals(y) : object.ReferenceEquals(x, y);
        }

        public static bool operator !=(list<T> x, list<T> y)
        {
            return (!object.ReferenceEquals(null, x)) ? (!x.Equals(y)) : (!object.ReferenceEquals(x, y));
        }

        public bool Equals(list<T> other)
        {
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<T> list = this;
            list<T> list2 = other;
            int arg_E0_0;
            while (!object.ReferenceEquals(list, list2))
            {
                if (list is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    if (list2 is list<T>.Cons)
                    {
                        T hd2 = ((list<T>.Cons)list2).hd;
                        list2 = (list<T>)((list<T>.Cons)list2).tl;
                        if (@default.Equals(hd, hd2))
                        {
                            list<T> arg_A1_0 = (list<T>)list;
                            list = arg_A1_0;
                            continue;
                        }
                    }
                    arg_E0_0 = 0;
                }
                else
                {
                    arg_E0_0 = (((list != list<T>.Nil._N_constant_object) ? object.ReferenceEquals(null, list2) : (list2 == list<T>.Nil._N_constant_object)) ? 1 : 0);
                }
                return arg_E0_0 != 0;
            }
            arg_E0_0 = 1;
            return arg_E0_0 != 0;
        }

        public bool Equals<TSecond>(list<TSecond> lst2, Function<T, TSecond, bool> compare)
        {
            return NList.Equals<T, TSecond>(this, lst2, compare);
        }

        public override int GetHashCode()
        {
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<T> list = this;
            int num = 842801;
            while (list is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                list<T> arg_59_0 = (list<T>)list;
                num = 757927 * num + @default.GetHashCode(hd);
                list = arg_59_0;
            }
            return num;
        }

        public Type GetElementType()
        {
            return typeof(T);
        }

        /// <summary>
        ///   <para>Creates enumerator for elements of list.
        ///
        /// </para>
        /// </summary>
        public ListEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        public static list<T> operator +(list<T> x, list<T> y)
        {
            return NList.Append<T>(x, y);
        }

        /// <summary>
        ///   <para>Returns first n elements of the list.
        ///  Works in time and memory O(n).
        ///
        /// </para>
        /// </summary>
        public list<T> FirstN(int n)
        {
            int num = n;
            list<T> list = list<T>.Nil._N_constant_object;
            list<T> list2 = this;
            while (num != 0)
            {
                if (list2 is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)list2).hd;
                    list2 = (list<T>)((list<T>.Cons)list2).tl;
                    int arg_6A_0 = checked(num - 1);
                    list<T> arg_69_0 = (list<T>)new list<T>.Cons(hd, list);
                    list = arg_69_0;
                    num = arg_6A_0;
                }
                else
                {
                    if (list2 == list<T>.Nil._N_constant_object)
                    {
                        throw new ArgumentException("NList.FirstN called for too short list");
                    }
                    throw new MatchFailureException();
                }
            }
            return NList.Rev<T>(list);
        }

        /// <summary>
        ///   <para>Return [this] without first [n] elements. Works in time O(n)
        ///   and constant memory. Throws ArgumentException when called on
        ///   too short list.
        /// </para>
        /// </summary>
        public list<T> ChopFirstN(int n)
        {
            int num = n;
            list<T> list = this;
            while (num != 0)
            {
                if (list is list<T>.Cons)
                {
                    list = (list<T>)((list<T>.Cons)list).tl;
                    int arg_39_0 = checked(num - 1);
                    num = arg_39_0;
                }
                else
                {
                    if (list == list<T>.Nil._N_constant_object)
                    {
                        throw new ArgumentException("NList.ChopFirstN called for too short list");
                    }
                    throw new MatchFailureException();
                }
            }
            return list;
        }

        public list<T> LastN(int n)
        {
            int length = this.Length;
            if (n > length)
            {
                throw new ArgumentException("NList.LastN called for too short list");
            }
            return this.ChopFirstN(checked(length - n));
        }

        public T Nth(int n)
        {
            return NList.Nth<T>(this, n);
        }

        /// <summary>
        ///   <para>Returns reversed list, i.e. [1,2,3].Reverse().Equals ([3,2,1]).
        ///  Works in time and memory O(n).
        ///
        /// </para>
        /// </summary>
        public list<T> Reverse()
        {
            return NList.Rev<T>(this);
        }

        /// <summary>
        ///   <para>Returns list made from appending list y at end of list x.
        ///  Original list are not modified.
        ///  Works in time and memory O(length(x)).
        ///
        /// </para>
        /// </summary>
        public list<T> Append(list<T> y)
        {
            return NList.RevAppend<T>(this.Reverse(), y);
        }

        /// <summary>
        ///   <para>Equivalent to Reverse().Append(y), but faster.
        ///
        /// </para>
        /// </summary>
        public list<T> RevAppend(list<T> y)
        {
            return NList.RevAppend<T>(this, y);
        }

        /// <summary>
        ///   <para>Returns current list without elements equal to x.
        ///  Equals method is used to compare elements.
        ///
        /// </para>
        /// </summary>
        public list<T> Remove(T x)
        {
            return NList.Remove<T>(this, x);
        }

        /// <summary>
        ///   <para>Returns a list without its last element and the list's last element
        ///
        /// </para>
        /// </summary>
        public Nemerle.Builtins.Tuple<list<T>, T> DivideLast()
        {
            return NList.DivideLast<T>(this);
        }

        public void Iter(FunctionVoid<T> f)
        {
            NList.Iter<T>(this, f);
        }

        public void IterI(int acc, FunctionVoid<int, T> f)
        {
            list<T> list = this;
            checked
            {
                while (list is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    f.apply_void(new Nemerle.Builtins.Tuple<int, T>(acc, hd));
                    acc++;
                }
            }
        }

        public list<TOut> Map<TOut>(Function<T, TOut> convert)
        {
            return NList.Map<T, TOut>(this, convert);
        }

        public list<TOut> MapIRev<TOut>(Function<int, T, TOut> convert)
        {
            list<T> list = this;
            list<TOut> list2 = list<TOut>.Nil._N_constant_object;
            int num = 0;
            checked
            {
                while (list != list<T>.Nil._N_constant_object)
                {
                    if (!(list is list<T>.Cons))
                    {
                        throw new MatchFailureException();
                    }
                    T hd = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    list<T> arg_6E_0 = (list<T>)list;
                    list<TOut> arg_6D_0 = (list<TOut>)new list<TOut>.Cons(convert.apply(num, hd), list2);
                    num++;
                    list2 = arg_6D_0;
                    list = arg_6E_0;
                }
                return list2;
            }
        }

        public list<TOut> MapI<TOut>(Function<int, T, TOut> convert)
        {
            return this.MapIRev<TOut>(convert).Reverse();
        }

        public list<Nemerle.Builtins.Tuple<T, TSecond>> Zip<TSecond>(list<TSecond> second)
        {
            if (this is list<T>.Cons)
            {
                if (second is list<TSecond>.Cons)
                {
                    T hd = ((list<T>.Cons)this).hd;
                    list<T> list = (list<T>)((list<T>.Cons)this).tl;
                    TSecond hd2 = ((list<TSecond>.Cons)second).hd;
                    list<TSecond> second2 = (list<TSecond>)((list<TSecond>.Cons)second).tl;
                    list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons arg_F6_0 = new list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons(new Nemerle.Builtins.Tuple<T, TSecond>(hd, hd2), list.Zip<TSecond>(second2));
                    return arg_F6_0;
                }
                if ((object)second != null)
                {
                    goto IL_9B;
                }
            }
            else
            {
                if (this != list<T>.Nil._N_constant_object)
                {
                    throw new ArgumentNullException("this");
                }
                if (second == list<TSecond>.Nil._N_constant_object)
                {
                    list<Nemerle.Builtins.Tuple<T, TSecond>> arg_F6_0 = list<Nemerle.Builtins.Tuple<T, TSecond>>.Nil._N_constant_object;
                    return arg_F6_0;
                }
                if ((object)second != null)
                {
                    goto IL_9B;
                }
            }
            throw new ArgumentNullException("second");
        IL_9B:
            throw new ArgumentException("list[T].Zip(): Collections mast have same", "second");
        }

        public list<TOut> MapFiltered<TOut>(Function<T, bool> predicate, Function<T, TOut> convert)
        {
            return NList.MapFiltered<T, TOut>(this, predicate, convert);
        }

        public list<TOut> RevMap<TOut>(Function<T, TOut> f)
        {
            return NList.RevMap<T, TOut>(this, f);
        }

        public TOut FoldLeft<TOut>(TOut acc, Function<T, TOut, TOut> f)
        {
            return NList.FoldLeft<T, TOut>(this, acc, f);
        }

        public TOut FoldRight<TOut>(TOut acc, Function<T, TOut, TOut> f)
        {
            return NList.FoldRight<T, TOut>(this, acc, f);
        }

        public list<list<T>> Group(Function<T, T, int> cmp)
        {
            return NList.Group<T>(this, cmp);
        }

        /// <summary>
        ///   <para>Returns 'true' if all of the 'l' list's elements satisfy
        ///  the condition 'f'.
        ///
        /// </para>
        /// </summary> <remarks><para>Example of use:
        ///
        /// </para>   <para>NList.ForAll ([2, 4, 6, 8], fun (x) { x % 2 == 0 })
        ///
        /// </para> <para>evaluates to 'true' as all the list's elements are even.
        ///
        /// </para></remarks>
        public bool ForAll(Function<T, bool> f)
        {
            return NList.ForAll<T>(this, f);
        }

        public bool ForAll2<TSecond>(list<TSecond> lst2, Function<T, TSecond, bool> predicate)
        {
            return NList.ForAll2<T, TSecond>(this, lst2, predicate);
        }

        /// <summary>
        ///   <para>Returns 'true' if at least one of the 'l' list's elements
        ///  satisfies the condition 'f'.
        ///
        /// </para>
        /// </summary> <remarks><para>Example of use:
        ///
        /// </para>   <para>NList.Exists (["a", "b", "abc", "d", "e"], fun (x) { x.Length &gt; 2 })
        ///
        /// </para> <para>evaluates to 'true' as there is one string of length 3 on the list.
        ///
        /// </para></remarks>
        public bool Exists(Function<T, bool> f)
        {
            return NList.Exists<T>(this, f);
        }

        /// <summary>
        ///   <para>NList membership test, using the `Equals' method to compare objects.
        ///
        /// </para>
        /// </summary>
        public bool Contains(T a)
        {
            return NList.Member<T>(this, a);
        }

        /// <summary>
        ///   <para>Finds the first elements for which a predicate is true.
        ///
        /// </para>
        /// </summary>
        public option<T> Find(Function<T, bool> pred)
        {
            return NList.Find<T>(this, pred);
        }

        /// <summary>
        ///   <para>Finds the first elements for which a predicate is true.
        ///
        /// </para>
        /// </summary>
        public T FindWithDefault(T @default, Function<T, bool> pred)
        {
            list<T> list = this;
            while (list is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                if (pred.apply(hd))
                {
                    T arg_6E_0 = hd;
                    return arg_6E_0;
                }
            }
            if (list == list<T>.Nil._N_constant_object)
            {
                T arg_6E_0 = @default;
                return arg_6E_0;
            }
            throw new MatchFailureException();
        }

        /// <summary>
        ///   <para>Returns the number of elements for which a predicate is true.
        ///
        /// </para>
        /// </summary>
        public int FilteredLength(Function<T, bool> f)
        {
            return NList.FilteredLength<T>(this, f);
        }

        /// <summary>
        ///   <para>Removes elements for which predicate is false
        ///
        /// </para>
        /// </summary>
        public list<T> Filter(Function<T, bool> f)
        {
            return NList.Filter<T>(this, f);
        }

        /// <summary>
        ///   <para>Removes elements for which predicate is false.
        ///  The resulting list is reversed (operation is faster this way).
        ///
        /// </para>
        /// </summary>
        public list<T> RevFilter(Function<T, bool> f)
        {
            return NList.RevFilter<T>(this, f);
        }

        /// <summary>
        ///   <para>Return list, reversed or not, with elements not fulfilling [f] removed.
        ///  Avoid allocation if possible.
        ///
        /// </para>
        /// </summary>
        public list<T> RevFilterWhenNeeded(Function<T, bool> f)
        {
            return (!NList.ForAll<T>(this, f)) ? NList.RevFilter<T>(this, f) : this;
        }

        /// <summary>
        ///   <para>This is an alias for ``Filter''
        ///
        /// </para>
        /// </summary>
        public list<T> FindAll(Function<T, bool> f)
        {
            return this.Filter(f);
        }

        /// <summary>
        ///   <para>Partitions a list into two sublists according to a predicate.
        ///
        /// </para>
        /// </summary>
        public Nemerle.Builtins.Tuple<list<T>, list<T>> Partition(Function<T, bool> pred)
        {
            return NList.Partition<T>(this, pred);
        }

        public list<list<T>> Singletons()
        {
            return NList.Singletons<T>(this);
        }

        /// <summary>
        ///   <para>Return list of all possible [n]-element subsets of set [list].
        ///
        /// </para>
        /// </summary>
        public list<list<T>> SizeSubsets(int n)
        {
            return NList.SizeSubsets<T>(this, n);
        }

        /// <summary>
        ///   <para>Return list consisting of [count] references to [elem].
        /// </para>
        /// </summary>
        public static list<T> Repeat(T elem, int count)
        {
            list<T> list = list<T>.Nil._N_constant_object;
            int num = count;
            checked
            {
                while (num > 0)
                {
                    list<T> arg_2A_0 = (list<T>)new list<T>.Cons(elem, list);
                    num--;
                    list = arg_2A_0;
                }
                return list;
            }
        }

        /// <summary>
        ///   <para>Return a list of integers from 0 to [end], excluding [end].
        /// </para>
        /// </summary>
        public static list<int> Range(int end)
        {
            return NList.Range(0, end, 1);
        }

        /// <summary>
        ///   <para>Return a list of values incremented by [step], beginning
        ///  with [beg], up/down to [end], excluding [end] itself.
        ///
        /// </para>
        /// </summary>
        public static list<int> Range(int beg, int end, int step = 1)
        {
            return NList.Range(beg, end, step);
        }

        /// <summary>
        ///   <para>Return a list of characters from 'a' to [end], excluding [end].
        /// </para>
        /// </summary>
        public static list<char> Range(char end)
        {
            return NList.Range(end);
        }

        /// <summary>
        ///   <para>Return a list of characters, which values are incremented by [step],
        ///  beginning with [beg], up/down to [end], excluding [end] itself.
        ///
        /// </para>
        /// </summary>
        public static list<char> Range(char b, char e, int step = 1)
        {
            return NList.Range(b, e, step);
        }

        /// <summary>
        ///   <para>Returns reversed list, i.e. Rev([1,2,3]) = [3,2,1].
        ///  Works in time and memory O(n).
        ///
        /// </para>
        /// </summary>
        public list<T> Rev()
        {
            return NList.Rev<T>(this);
        }

        public list<T> Sort(Function<T, T, int> cmp)
        {
            return NList.Sort<T>(this, cmp);
        }

        public list<T> RemoveDuplicates()
        {
            return NList.RemoveDuplicates<T>(this);
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Length];
            this.CopyTo(array);
            return array;
        }

        /// <summary>
        ///   <para>Copies first [len] elements from current list to specified array beginning with index 0
        ///
        /// </para>
        /// </summary>
        public void CopyTo(T[] dest, int len)
        {
            int num = 0;
            list<T> list = this;
            checked
            {
                while (list is list<T>.Cons)
                {
                    T t2 = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    if (num >= len)
                    {
                        break;
                    }
                    dest[num] = t2;
                    num++;
                }
                if (num < len)
                {
                    throw new ArgumentException("insufficient amount of elements in current list: expected " + Convert.ToString(len) + ", has " + Convert.ToString(num));
                }
            }
        }

        /// <summary>
        ///   <para>Copies all elements from current list to specified array beginning with index 0
        ///
        /// </para>
        /// </summary>
        public void CopyTo(T[] dest)
        {
            int num = 0;
            list<T> list = this;
            checked
            {
                while (list is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    dest[num] = hd;
                    num++;
                }
            }
        }

        public TOut[] MapToArray<TOut>(Function<T, TOut> f)
        {
            TOut[] array = new TOut[this.Length];
            int num = 0;
            list<T> list = this;
            checked
            {
                while (list is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    array[num] = f.apply(hd);
                    num++;
                }
                return array;
            }
        }

        public list<TOut> Flatten<TOut>(FunctionVoid<T, List<TOut>> selector)
        {
            List<TOut> list = new List<TOut>();
            list<T> list2 = this;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                selector.apply_void(new Nemerle.Builtins.Tuple<T, List<TOut>>(hd, (List<TOut>)list));
            }
            return list.NToList<TOut>();
        }

        public list<TOut> Flatten<TOut>(Function<T, IEnumerable<TOut>> selector)
        {
            List<TOut> list = new List<TOut>();
            list<T> list2 = this;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                list.AddRange(selector.apply(hd));
            }
            return list.NToList<TOut>();
        }

        public list<Result> Filter2<T2, Result>(list<T2> list2, Function<T, T2, Nemerle.Builtins.Tuple<bool, Result>> convert)
        {
            return NList.Filter2<T, T2, Result>(this, list2, convert);
        }

        public list<TResult> OfTypeRevert<TResult>()
        {
            list<TResult> list = (list<TResult>)list<TResult>.Nil._N_constant_object;
            list<T> list2 = this;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                if (hd is TResult)
                {
                    list = new list<TResult>.Cons((TResult)((object)hd), list);
                }
            }
            return list;
        }

        public list<TResult> OfType<TResult>()
        {
            List<TResult> list = new List<TResult>(this.Length);
            list<T> list2 = this;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                if (hd is TResult)
                {
                    list.Add((TResult)((object)hd));
                }
            }
            return list.NToList<TResult>();
        }

        public override bool Equals(object other)
        {
            return object.ReferenceEquals(this, other) || (other is list<T> && this.Equals((list<T>)other));
        }

        /// <summary>
        ///   <para>The core datastructure allowing easy manipulating of small
        /// and medium sized collections of elements.
        ///
        /// </para>
        /// </summary>      <remarks><para>It has a builtin syntax [] for empty list, x :: xs for creating list
        /// from head element and tail.
        ///
        /// </para></remarks>
        public abstract int _N_GetVariantCode();

        public static int _N_GetVariantCodeSafe(list<T> x)
        {
            return ((object)x != null) ? x._N_GetVariantCode() : -1;
        }

        public static int _N_GetVariantCodeObject(object x)
        {
            return (!(x is list<T>)) ? -1 : ((list<T>)x)._N_GetVariantCode();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///   <para>Creates enumerator for elements of list.
        ///
        /// </para>
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    [DebuggerNonUserCode]
    internal static class ListExtensions
    {
        [Extension]
        public static bool IsOrdered<TSecond>(this list<TSecond> lst, Function<TSecond, TSecond, bool> great)
        {
            /*
            TSecond tSecond = default(TSecond);
            TSecond tSecond2 = default(TSecond);
            while (lst is list<TSecond>.Cons)
            {
                bool arg_D2_0;
                if (((list<TSecond>.Cons)lst).tl is list<TSecond>.Cons)
                {
                    TSecond hd = ((list<TSecond>.Cons)lst).hd;
                    list<TSecond>.Cons cons = (list<TSecond>.Cons)((list<TSecond>.Cons)lst).tl;
                    TSecond hd2 = ((list<TSecond>.Cons)((list<TSecond>.Cons)lst).tl).hd;
                    if (!great.apply(hd, hd2))
                    {
                        list<TSecond> arg_8B_0 = (list<TSecond>)cons;
                        great = (Function<TSecond, TSecond, bool>)great;
                        lst = arg_8B_0;
                        continue;
                    }
                    arg_D2_0 = false;
                }
                else
                {
                    if (((list<TSecond>.Cons)lst).tl != list<TSecond>.Nil._N_constant_object)
                    {
                        throw new MatchFailureException();
                    }
                IL_AC:
                    arg_D2_0 = true;
                }
                return arg_D2_0;
            }
            if (lst == list<TSecond>.Nil._N_constant_object)
            {
                goto IL_AC;
            }
            goto IL_AC;
            */
            throw new NotImplementedException();
        }

        [Extension]
        public static bool IsOrdered<TSecond>(this list<TSecond> lst) where TSecond : IComparable<TSecond>
        {
            return IsOrdered(lst, Lambda.New<TSecond, TSecond, bool>((x, y) => x.CompareTo(y) > 0));
        }
    }
}
