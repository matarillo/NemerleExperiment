using System;
using System.Collections.Generic;
using System.Diagnostics;

using Nemerle.Builtins;
using Nemerle.Core;
using Nemerle.Internal;

namespace Nemerle.Collections
{
    [Extension]
    [DebuggerNonUserCode]
    public static class NList
    {
        /// <summary>
        ///   <para>Tests equality of two lists.  Uses Equal method of
        ///  objects to test wether they are the same.
        ///
        /// </para>
        /// </summary>
        public static bool Equals<T>(list<T> x, list<T> y)
        {
            return x == y;
        }

        /// <summary>
        ///   <para>Compare two lists lexicographically over the order defined on
        ///  their elements with function [cmp].  Returns [-1] if [l1] is smaller,
        ///  [1] if [l2] is smaller, and [0] if they equal.
        ///
        /// </para>
        /// </summary>
        public static int Compare<T>(list<T> l1, list<T> l2, Function<T, T, int> cmp)
        {
            int arg_E7_0;
            while (l1 != list<T>.Nil._N_constant_object)
            {
                if (l2 != list<T>.Nil._N_constant_object)
                {
                    if (l1 is list<T>.Cons)
                    {
                        if (l2 is list<T>.Cons)
                        {
                            T hd = ((list<T>.Cons)l1).hd;
                            list<T> list = (list<T>)((list<T>.Cons)l1).tl;
                            T hd2 = ((list<T>.Cons)l2).hd;
                            list<T> list2 = (list<T>)((list<T>.Cons)l2).tl;
                            int num = cmp.apply(hd, hd2);
                            if (num == 0)
                            {
                                list<T> arg_C5_0 = (list<T>)list;
                                list<T> arg_C3_0 = (list<T>)list2;
                                l2 = arg_C3_0;
                                l1 = arg_C5_0;
                                continue;
                            }
                            arg_E7_0 = num;
                            return arg_E7_0;
                        }
                    }
                    throw new ArgumentException("NList.Compare called for null list");
                }
                arg_E7_0 = 1;
                return arg_E7_0;
            }
            arg_E7_0 = ((l2 != list<T>.Nil._N_constant_object) ? -1 : 0);
            return arg_E7_0;
        }

        /// <summary>
        ///   <para>Compare two lists lexicographically over the order defined on
        ///  their elements.  Returns [-1] if [l1] is smaller, [1] if [l2]
        ///  is smaller, and [0] if they equal.
        ///
        /// </para>
        /// </summary>
        public static int Compare<T>(list<T> l1, list<T> l2) where T : IComparable<T>
        {
            return NList.Compare<T>(l1, l2, Lambda.New<T, T, int>((x, y) => x.CompareTo(y)));
        }

        /// <summary>
        ///   <para>Returns [l] with duplicates removed with respect to Equals method
        ///  It is assumed that equal elements of [l] are next to each other,
        ///  or that the list is sorted.
        ///
        /// </para>
        /// </summary> <remarks><para>Example:
        ///
        /// </para> <para>def result = RemoveDuplicates ([1, 2, 2, 3, 4, 4]);
        ///      // result = [1, 2, 3, 4]
        ///
        /// </para></remarks>
        public static list<T> RemoveDuplicates<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> lst)
        {
            if (lst == null)
            {
                throw new ArgumentNullException("lst", "The ``NotNull'' contract of parameter ``lst'' has been violated. See lib\\list.n:767:51:767:54: .");
            }
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<T> list = lst;
            list<T> list2 = list<T>.Nil._N_constant_object;
            list<T> arg_129_0;
            while (list != list<T>.Nil._N_constant_object)
            {
                if (!(list is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd;
                if (((list<T>.Cons)list).tl == list<T>.Nil._N_constant_object)
                {
                    hd = ((list<T>.Cons)list).hd;
                    arg_129_0 = new list<T>.Cons(hd, list2).Reverse();
                    return arg_129_0;
                }
                if (!(((list<T>.Cons)list).tl is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                hd = ((list<T>.Cons)list).hd;
                list<T>.Cons cons = (list<T>.Cons)((list<T>.Cons)list).tl;
                T hd2 = ((list<T>.Cons)((list<T>.Cons)list).tl).hd;
                if (@default.Equals(hd, hd2))
                {
                    list<T> arg_F8_0 = (list<T>)cons;
                    list = arg_F8_0;
                }
                else
                {
                    list<T> arg_112_0 = (list<T>)cons;
                    list2 = (list<T>)new list<T>.Cons(hd, list2);
                    list = arg_112_0;
                }
            }
            arg_129_0 = list2.Reverse();
            return arg_129_0;
        }

        /// <summary>
        ///   <para>Converts an array into a list.
        ///
        /// </para>
        /// </summary>
        public static list<T> FromArray<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] T[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "The ``NotNull'' contract of parameter ``source'' has been violated. See lib\\list.n:791:37:791:43: .");
            }
            checked
            {
                int num = source.Length - 1;
                list<T> list = list<T>.Nil._N_constant_object;
                while (num >= 0)
                {
                    int arg_47_0 = num - 1;
                    list = (list<T>)new list<T>.Cons(source[num], list);
                    num = arg_47_0;
                }
                return list;
            }
        }

        [Extension]
        public static list<T> ToListRev<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this IEnumerable<T> seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq", "The ``NotNull'' contract of parameter ``seq'' has been violated. See lib\\list.n:803:41:803:44: .");
            }
            list<T> list = (list<T>)list<T>.Nil._N_constant_object;
            IEnumerator<T> enumerator = seq.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    T current = enumerator.Current;
                    T hd = current;
                    list = new list<T>.Cons(hd, list);
                }
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return list;
        }

        [Extension]
        public static list<T> ToListRev<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this IEnumerable<T> seq, Function<T, bool> filter)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq", "The ``NotNull'' contract of parameter ``seq'' has been violated. See lib\\list.n:813:42:813:45: .");
            }
            list<T> list = (list<T>)list<T>.Nil._N_constant_object;
            IEnumerator<T> enumerator = seq.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    T current = enumerator.Current;
                    T t2 = current;
                    if (filter.apply(t2))
                    {
                        list = new list<T>.Cons(t2, list);
                    }
                }
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return list;
        }

        public static list<T> ToList<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] IEnumerable<T> seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq", "The ``NotNull'' contract of parameter ``seq'' has been violated. See lib\\list.n:824:34:824:37: .");
            }
            return seq.ToListRev<T>().Rev();
        }

        [Extension]
        public static list<T> AsList<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "The ``NotNull'' contract of parameter ``source'' has been violated. See lib\\list.n:829:39:829:45: .");
            }
            list<T> list = (list<T>)list<T>.Nil._N_constant_object;
            checked
            {
                for (int num = source.Count - 1; num >= 0; num--)
                {
                    list = new list<T>.Cons(source[num], list);
                }
                return list;
            }
        }

        public static list<T> ToList<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] IList<T> source, Function<T, bool> filter)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "The ``NotNull'' contract of parameter ``source'' has been violated. See lib\\list.n:839:32:839:38: .");
            }
            list<T> list = (list<T>)list<T>.Nil._N_constant_object;
            checked
            {
                for (int num = source.Count - 1; num >= 0; num--)
                {
                    T t2 = source[num];
                    if (filter.apply(t2))
                    {
                        list = new list<T>.Cons(t2, list);
                    }
                }
                return list;
            }
        }

        public static list<T> ToList<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] IEnumerable<T> seq, Function<T, bool> filter)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq", "The ``NotNull'' contract of parameter ``seq'' has been violated. See lib\\list.n:853:32:853:35: .");
            }
            return seq.ToListRev(filter).Rev();
        }

        /// <summary>
        ///   <para>Returns true if the given list is empty of null.
        ///
        /// </para>
        /// </summary>
        public static bool IsEmpty<T>(list<T> lst)
        {
            int arg_23_0;
            if (lst != list<T>.Nil._N_constant_object)
            {
                if ((object)lst != null)
                {
                    arg_23_0 = 0;
                    return arg_23_0 != 0;
                }
            }
            arg_23_0 = 1;
            return arg_23_0 != 0;
        }

        /// <summary>
        ///   <para>Returns length of given list. Time O(n), Mem O(1).
        ///
        /// </para>
        /// </summary>
        public static int Length<T>(list<T> x)
        {
            int num = 0;
            list<T> list = x;
            while (list is list<T>.Cons)
            {
                list = (list<T>)((list<T>.Cons)list).tl;
                int arg_2A_0 = checked(num + 1);
                num = arg_2A_0;
            }
            return num;
        }

        /// <summary>
        ///   <para>Returns head (first element) of list.
        ///  Given empty list throws System.ArgumentException.
        ///
        /// </para>
        /// </summary>
        public static T Head<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:885:32:885:33: .");
            }
            return l.Head;
        }

        /// <summary>
        ///   <para>Alias for l.Head.
        ///
        /// </para>
        /// </summary>
        public static T Hd<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:888:30:888:31: .");
            }
            return l.Head;
        }

        /// <summary>
        ///   <para>Returns tail (all elements except first one) of list.
        ///
        /// </para>
        /// </summary>
        public static list<T> Tail<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:893:31:893:32: .");
            }
            return l.Tail;
        }

        /// <summary>
        ///   <para>Alias for Tail(l).
        ///
        /// </para>
        /// </summary>
        public static list<T> Tl<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:900:29:900:30: .");
            }
            return l.Tail;
        }

        /// <summary>
        ///   <para>Returns n-th element of list, where 0-th is head.
        ///  Throws InvalidArgument exception when given too short list.
        ///  Works in time O(n) and memory O(1).
        ///
        /// </para>
        /// </summary>
        public static T Nth<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, int n)
        {
            checked
            {
                while (l != null)
                {
                    if (l is list<T>.Cons)
                    {
                        T hd = ((list<T>.Cons)l).hd;
                        list<T> list = (list<T>)((list<T>.Cons)l).tl;
                        if (n == 0)
                        {
                            return hd;
                        }
                        list<T> arg_65_0 = (list<T>)list;
                        n--;
                        l = arg_65_0;
                    }
                    else
                    {
                        if (l == list<T>.Nil._N_constant_object)
                        {
                            throw new ArgumentOutOfRangeException("NList.Nth");
                        }
                        throw new MatchFailureException();
                    }
                }
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:909:30:909:31: .");
            }
        }

        /// <summary>
        ///   <para>Returns last element of list.
        ///  Given empty list throws InvalidArgument exception.
        ///  Works in time O(n) and memory O(1).
        ///
        /// </para>
        /// </summary>
        public static T Last<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            while (l != null)
            {
                if (l is list<T>.Cons)
                {
                    if (((list<T>.Cons)l).tl == list<T>.Nil._N_constant_object)
                    {
                        return ((list<T>.Cons)l).hd;
                    }
                    list<T> list = (list<T>)((list<T>.Cons)l).tl;
                    l = (list<T>)list;
                }
                else
                {
                    if (l == list<T>.Nil._N_constant_object)
                    {
                        throw new ArgumentException("NList.Last called for empty list");
                    }
                    throw new MatchFailureException();
                }
            }
            throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:925:31:925:32: .");
        }

        /// <summary>
        ///   <para>Returns reversed list, i.e. Rev([1, 2, 3]) = [3, 2, 1].
        ///  Works in time and memory O(n).
        ///
        /// </para>
        /// </summary>
        public static list<T> Rev<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:938:30:938:31: .");
            }
            list<T> list = list<T>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                list<T> arg_66_0 = (list<T>)new list<T>.Cons(hd, list);
                list = arg_66_0;
            }
            if (list2 == list<T>.Nil._N_constant_object)
            {
                return list;
            }
            throw new MatchFailureException();
        }

        /// <summary>
        ///   <para>Returns list made from appending list y at end of list x.
        ///  Original list are not modified.
        ///  Works in time and memory O(length(x)).
        ///
        /// </para>
        /// </summary>
        public static list<T> Append<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> x, list<T> y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:953:33:953:34: .");
            }
            return NList.RevAppend<T>(NList.Rev<T>(x), y);
        }

        /// <summary>
        ///   <para>Equivalent to Append(Rev(x),y).
        ///
        /// </para>
        /// </summary>
        public static list<T> RevAppend<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> x, list<T> y)
        {
            while (x != null)
            {
                if (x is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)x).hd;
                    list<T> list = (list<T>)((list<T>.Cons)x).tl;
                    list<T> arg_5F_0 = (list<T>)list;
                    y = (list<T>)new list<T>.Cons(hd, y);
                    x = arg_5F_0;
                }
                else
                {
                    if (x == list<T>.Nil._N_constant_object)
                    {
                        return y;
                    }
                    throw new MatchFailureException();
                }
            }
            throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:961:36:961:37: .");
        }

        /// <summary>
        ///   <para>Makes list one level more flat, i.e. Concat([[1, 2], [3, 4]]) = [1, 2, 3, 4].
        ///  Does not work deeper, i.e. Concat([[[1, 2], [3]], [[4]]]) = [[1, 2], [3], [4]].
        ///
        /// </para>
        /// </summary>
        [Extension]
        public static list<T> Concat<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<list<T>> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:970:37:970:38: .");
            }
            return NList.Rev<T>(NList.ConcatRev<T>(l));
        }

        /// <summary>
        ///   <para>Equivalent to Concat(Rev(l))
        ///
        /// </para>
        /// </summary>
        public static list<T> ConcatRev<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<list<T>> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:976:35:976:36: .");
            }
            list<T> acc = list<T>.Nil._N_constant_object;
            Function<list<T>, list<T>, list<T>> f = Lambda.New<list<T>, list<T>, list<T>>((l2, acc2) =>
            {
                Function<T, list<T>, list<T>> f2 = Lambda.New<T, list<T>, list<T>>((p, q) => new list<T>.Cons(p, q));
                return NList.FoldLeft(l2, acc2, f2);
            });
            return NList.FoldLeft<list<T>, list<T>>(l, acc, f);
        }

        /// <summary>
        ///   <para>Alias for Concat(l).
        ///
        /// </para>
        /// </summary>
        [Extension]
        public static list<T> Flatten<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<list<T>> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:982:38:982:39: .");
            }
            return l.Concat<T>();
        }

        /// <summary>
        ///   <para>Returns list l without elements equal to x.
        ///
        /// </para>
        /// </summary>
        public static list<T> Remove<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, T x)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:990:33:990:34: .");
            }
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<T> list = list<T>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 != list<T>.Nil._N_constant_object)
            {
                if (!(list2 is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                list<T> arg_97_0 = (list<T>)((!@default.Equals(hd, x)) ? new list<T>.Cons(hd, list) : list);
                list = arg_97_0;
            }
            return NList.Rev<T>(list);
        }

        /// <summary>
        ///   <para>Returns a list without its last element and the list's last element
        ///
        /// </para>
        /// </summary>
        public static Nemerle.Builtins.Tuple<list<T>, T> DivideLast<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1008:38:1008:39: .");
            }
            list<T> list = l;
            list<T> list2 = list<T>.Nil._N_constant_object;
            while (list is list<T>.Cons)
            {
                T hd;
                if (((list<T>.Cons)list).tl == list<T>.Nil._N_constant_object)
                {
                    hd = ((list<T>.Cons)list).hd;
                    return new Nemerle.Builtins.Tuple<list<T>, T>(NList.Rev<T>(list2), hd);
                }
                hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                list<T> arg_98_0 = (list<T>)list;
                list2 = (list<T>)new list<T>.Cons(hd, list2);
                list = arg_98_0;
            }
            throw new ArgumentException("NList.DivideLast called for empty list");
        }

        public static void Iter<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, FunctionVoid<T> f)
        {
            while (l != null)
            {
                if (l is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)l).hd;
                    list<T> list = (list<T>)((list<T>.Cons)l).tl;
                    f.apply_void(hd);
                    list<T> arg_60_0 = (list<T>)list;
                    l = arg_60_0;
                }
                else
                {
                    if (l == list<T>.Nil._N_constant_object)
                    {
                        return;
                    }
                    throw new MatchFailureException();
                }
            }
            throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1025:31:1025:32: .");
        }

        public static list<TOut> MapFiltered<T, TOut>(list<T> lst, Function<T, bool> predicate, Function<T, TOut> convert)
        {
            list<TOut>.Cons cons = null;
            list<TOut>.Cons cons2 = null;
            list<T> list = lst;
            while (list is list<T>.Cons)
            {
                T t2 = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                if (predicate.apply(t2))
                {
                    list<TOut>.Cons cons3 = new list<TOut>.Cons(convert.apply(t2), list<TOut>.Nil._N_constant_object);
                    if (cons == null)
                    {
                        cons = cons3;
                        cons2 = cons3;
                    }
                    else
                    {
                        cons2.tl = cons3;
                        cons2 = cons3;
                    }
                }
            }
            return (!(cons == null)) ? (list<TOut>)cons : list<TOut>.Nil._N_constant_object;
        }

        public static list<TOut> Map<T, TOut>(list<T> lst, Function<T, TOut> convert)
        {
            list<TOut>.Cons cons = null;
            list<TOut>.Cons cons2 = null;
            list<T> list = lst;
            while (list is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                list<TOut>.Cons cons3 = new list<TOut>.Cons(convert.apply(hd), list<TOut>.Nil._N_constant_object);
                if (cons == null)
                {
                    cons = cons3;
                    cons2 = cons3;
                }
                else
                {
                    cons2.tl = cons3;
                    cons2 = cons3;
                }
            }
            return (!(cons == null)) ? (list<TOut>)cons : list<TOut>.Nil._N_constant_object;
        }

        public static list<TOut> RevMap<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, TOut> convert)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1042:39:1042:40: .");
            }
            list<TOut> list = list<TOut>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                list<TOut> arg_6C_0 = (list<TOut>)new list<TOut>.Cons(convert.apply(hd), list);
                list = arg_6C_0;
            }
            if (list2 == list<T>.Nil._N_constant_object)
            {
                return list;
            }
            throw new MatchFailureException();
        }

        public static list<TOut> RevMapFiltered<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> predicate, Function<T, TOut> convert)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1056:47:1056:48: .");
            }
            list<TOut> list = list<TOut>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                if (predicate.apply(hd))
                {
                    list<TOut> arg_78_0 = (list<TOut>)new list<TOut>.Cons(convert.apply(hd), list);
                    list = arg_78_0;
                }
                else
                {
                    list<TOut> arg_8B_0 = (list<TOut>)list;
                    list = arg_8B_0;
                }
            }
            if (list2 == list<T>.Nil._N_constant_object)
            {
                return list;
            }
            throw new MatchFailureException();
        }

        public static TOut FoldLeft<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, TOut acc, Function<T, TOut, TOut> f)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1066:41:1066:42: .");
            }
            for (list<T> list = l; list != list<T>.Nil._N_constant_object;)
            {
                if (!(list is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                acc = f.apply(hd, acc);
            }
            return acc;
        }

        public static TOut FoldRight<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, TOut acc, Function<T, TOut, TOut> f)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1076:42:1076:43: .");
            }
            TOut arg_76_0;
            if (l == list<T>.Nil._N_constant_object)
            {
                arg_76_0 = acc;
            }
            else
            {
                if (!(l is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd = ((list<T>.Cons)l).hd;
                list<T> l2 = (list<T>)((list<T>.Cons)l).tl;
                arg_76_0 = f.apply(hd, NList.FoldRight<T, TOut>(l2, acc, f));
            }
            return arg_76_0;
        }

        public static list<TOut> MapFromArray<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] T[] x, Function<T, TOut> f)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:1083:45:1083:46: .");
            }
            list<TOut>.Cons cons = null;
            list<TOut>.Cons cons2 = null;
            checked
            {
                for (int i = 0; i < x.Length; i++)
                {
                    T n_wildcard_ = x[i];
                    list<TOut>.Cons cons3 = new list<TOut>.Cons(f.apply(n_wildcard_), list<TOut>.Nil._N_constant_object);
                    if (cons == null)
                    {
                        cons = cons3;
                        cons2 = cons3;
                    }
                    else
                    {
                        cons2.tl = cons3;
                        cons2 = cons3;
                    }
                }
                return (!(cons == null)) ? (list<TOut>)cons : list<TOut>.Nil._N_constant_object;
            }
        }

        public static void Iter2<T, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> a, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TOut> b, FunctionVoid<T, TOut> f)
        {
            while (b != null)
            {
                if (a == null)
                {
                    throw new ArgumentNullException("a", "The ``NotNull'' contract of parameter ``a'' has been violated. See lib\\list.n:1090:38:1090:39: .");
                }
                if (a == list<T>.Nil._N_constant_object)
                {
                    if (b == list<TOut>.Nil._N_constant_object)
                    {
                        return;
                    }
                }
                else if (a is list<T>.Cons)
                {
                    if (b is list<TOut>.Cons)
                    {
                        T hd = ((list<T>.Cons)a).hd;
                        list<T> list = (list<T>)((list<T>.Cons)a).tl;
                        TOut hd2 = ((list<TOut>.Cons)b).hd;
                        list<TOut> list2 = (list<TOut>)((list<TOut>.Cons)b).tl;
                        f.apply_void(new Nemerle.Builtins.Tuple<T, TOut>(hd, hd2));
                        list<T> arg_E8_0 = (list<T>)list;
                        list<TOut> arg_E6_0 = (list<TOut>)list2;
                        b = arg_E6_0;
                        a = arg_E8_0;
                        continue;
                    }
                }
                throw new ArgumentException("NList.Iter2");
            }
            throw new ArgumentNullException("b", "The ``NotNull'' contract of parameter ``b'' has been violated. See lib\\list.n:1090:62:1090:63: .");
        }

        public static list<TOut> Map2<T, TSecond, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> x, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> y, Function<T, TSecond, TOut> f)
        {
            if (y == null)
            {
                throw new ArgumentNullException("y", "The ``NotNull'' contract of parameter ``y'' has been violated. See lib\\list.n:1098:70:1098:71: .");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:1098:46:1098:47: .");
            }
            if (x == list<T>.Nil._N_constant_object)
            {
                if (y == list<TSecond>.Nil._N_constant_object)
                {
                    list<TOut>.Nil arg_F3_0 = list<TOut>.Nil._N_constant_object;
                    return arg_F3_0;
                }
            }
            else if (x is list<T>.Cons)
            {
                if (y is list<TSecond>.Cons)
                {
                    T hd = ((list<T>.Cons)x).hd;
                    list<T> x2 = (list<T>)((list<T>.Cons)x).tl;
                    TSecond hd2 = ((list<TSecond>.Cons)y).hd;
                    list<TSecond> y2 = (list<TSecond>)((list<TSecond>.Cons)y).tl;
                    list<TOut> arg_F3_0 = new list<TOut>.Cons(f.apply(hd, hd2), NList.Map2<T, TSecond, TOut>(x2, y2, f));
                    return arg_F3_0;
                }
            }
            throw new ArgumentException("NList.Map2");
        }

        public static list<TOut> RevMap2<T, TSecond, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> x, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> y, Function<T, TSecond, TOut> f)
        {
            if (y == null)
            {
                throw new ArgumentNullException("y", "The ``NotNull'' contract of parameter ``y'' has been violated. See lib\\list.n:1106:73:1106:74: .");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:1106:49:1106:50: .");
            }
            list<TOut> list = list<TOut>.Nil._N_constant_object;
            list<T> list2 = x;
            list<TSecond> list3 = y;
            while (list2 != list<T>.Nil._N_constant_object)
            {
                if (list2 is list<T>.Cons)
                {
                    if (list3 is list<TSecond>.Cons)
                    {
                        T hd = ((list<T>.Cons)list2).hd;
                        list2 = (list<T>)((list<T>.Cons)list2).tl;
                        TSecond hd2 = ((list<TSecond>.Cons)list3).hd;
                        list3 = (list<TSecond>)((list<TSecond>.Cons)list3).tl;
                        list<TOut> arg_F4_0 = (list<TOut>)new list<TOut>.Cons(f.apply(hd, hd2), list);
                        list<T> arg_F3_0 = (list<T>)list2;
                        list2 = arg_F3_0;
                        list = arg_F4_0;
                        continue;
                    }
                }
                goto IL_6F;
            }
            if (list3 == list<TSecond>.Nil._N_constant_object)
            {
                return list;
            }
        IL_6F:
            throw new ArgumentException("NList.RevMap2");
        }

        [Extension]
        public static TOut FoldLeft2<TFirst, TSecond, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<TFirst> a, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> b, TOut acc, Function<TFirst, TSecond, TOut, TOut> f)
        {
            while (b != null)
            {
                if (a == null)
                {
                    throw new ArgumentNullException("a", "The ``NotNull'' contract of parameter ``a'' has been violated. See lib\\list.n:1119:61:1119:62: .");
                }
                if (a == list<TFirst>.Nil._N_constant_object)
                {
                    if (b == list<TSecond>.Nil._N_constant_object)
                    {
                        return acc;
                    }
                }
                else if (a is list<TFirst>.Cons)
                {
                    if (b is list<TSecond>.Cons)
                    {
                        TFirst hd = ((list<TFirst>.Cons)a).hd;
                        list<TFirst> list = (list<TFirst>)((list<TFirst>.Cons)a).tl;
                        TSecond hd2 = ((list<TSecond>.Cons)b).hd;
                        list<TSecond> list2 = (list<TSecond>)((list<TSecond>.Cons)b).tl;
                        list<TFirst> arg_E7_0 = (list<TFirst>)list;
                        list<TSecond> arg_E5_0 = (list<TSecond>)list2;
                        TOut arg_E3_0 = f.apply(hd, hd2, acc);
                        acc = arg_E3_0;
                        b = arg_E5_0;
                        a = arg_E7_0;
                        continue;
                    }
                }
                throw new ArgumentException("NList.FoldLeft2");
            }
            throw new ArgumentNullException("b", "The ``NotNull'' contract of parameter ``b'' has been violated. See lib\\list.n:1120:45:1120:46: .");
        }

        [Extension]
        public static TOut FoldRight2<TFirst, TSecond, TOut>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<TFirst> a, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> b, TOut c, Function<TFirst, TSecond, TOut, TOut> f)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b", "The ``NotNull'' contract of parameter ``b'' has been violated. See lib\\list.n:1132:47:1132:48: .");
            }
            if (a == null)
            {
                throw new ArgumentNullException("a", "The ``NotNull'' contract of parameter ``a'' has been violated. See lib\\list.n:1131:62:1131:63: .");
            }
            if (a == list<TFirst>.Nil._N_constant_object)
            {
                if (b == list<TSecond>.Nil._N_constant_object)
                {
                    TOut arg_EB_0 = c;
                    return arg_EB_0;
                }
            }
            else if (a is list<TFirst>.Cons)
            {
                if (b is list<TSecond>.Cons)
                {
                    TFirst hd = ((list<TFirst>.Cons)a).hd;
                    list<TFirst> a2 = (list<TFirst>)((list<TFirst>.Cons)a).tl;
                    TSecond hd2 = ((list<TSecond>.Cons)b).hd;
                    list<TSecond> b2 = (list<TSecond>)((list<TSecond>.Cons)b).tl;
                    TOut arg_EB_0 = f.apply(hd, hd2, a2.FoldRight2(b2, c, f));
                    return arg_EB_0;
                }
            }
            throw new ArgumentException("NList.FoldRight2");
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
        public static bool ForAll<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> lst, Function<T, bool> predicate)
        {
            while (lst != null)
            {
                bool arg_89_0;
                if (lst is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)lst).hd;
                    list<T> list = (list<T>)((list<T>.Cons)lst).tl;
                    if (predicate.apply(hd))
                    {
                        list<T> arg_65_0 = (list<T>)list;
                        lst = arg_65_0;
                        continue;
                    }
                    arg_89_0 = false;
                }
                else
                {
                    if (lst != list<T>.Nil._N_constant_object)
                    {
                        throw new MatchFailureException();
                    }
                    arg_89_0 = true;
                }
                return arg_89_0;
            }
            throw new ArgumentNullException("lst", "The ``NotNull'' contract of parameter ``lst'' has been violated. See lib\\list.n:1156:33:1156:36: .");
        }

        public static bool Equals<T1, TSecond>(list<T1> lst1, list<TSecond> lst2, Function<T1, TSecond, bool> compare)
        {
            while (lst1 is list<T1>.Cons)
            {
                int arg_C9_0;
                if (lst2 is list<TSecond>.Cons)
                {
                    T1 hd = ((list<T1>.Cons)lst1).hd;
                    list<T1> list = (list<T1>)((list<T1>.Cons)lst1).tl;
                    TSecond hd2 = ((list<TSecond>.Cons)lst2).hd;
                    list<TSecond> list2 = (list<TSecond>)((list<TSecond>.Cons)lst2).tl;
                    if (compare.apply(hd, hd2))
                    {
                        list<T1> arg_8B_0 = (list<T1>)list;
                        list<TSecond> arg_89_0 = (list<TSecond>)list2;
                        lst2 = arg_89_0;
                        lst1 = arg_8B_0;
                        continue;
                    }
                    arg_C9_0 = 0;
                }
                else
                {
                    goto IL_98;
                }
                return arg_C9_0 != 0;
            }
            if (lst1 != list<T1>.Nil._N_constant_object)
            {
                goto IL_98;
            }
            if (lst2 == list<TSecond>.Nil._N_constant_object)
            {
                int arg_C9_0 = 1;
                return arg_C9_0 != 0;
            }
        IL_98:
            return false;
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
        public static bool Exists<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> f)
        {
            while (l != null)
            {
                bool arg_8E_0;
                if (l == list<T>.Nil._N_constant_object)
                {
                    arg_8E_0 = false;
                }
                else
                {
                    if (!(l is list<T>.Cons))
                    {
                        throw new MatchFailureException();
                    }
                    T hd = ((list<T>.Cons)l).hd;
                    list<T> list = (list<T>)((list<T>.Cons)l).tl;
                    if (!f.apply(hd))
                    {
                        list<T> arg_7C_0 = (list<T>)list;
                        l = arg_7C_0;
                        continue;
                    }
                    arg_8E_0 = true;
                }
                return arg_8E_0;
            }
            throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1184:33:1184:34: .");
        }

        public static bool ForAll2<T, TSecond>(list<T> a, list<TSecond> b, Function<T, TSecond, bool> f)
        {
            while (a != list<T>.Nil._N_constant_object)
            {
                int arg_C9_0;
                if (a is list<T>.Cons)
                {
                    if (b is list<TSecond>.Cons)
                    {
                        T hd = ((list<T>.Cons)a).hd;
                        list<T> list = (list<T>)((list<T>.Cons)a).tl;
                        TSecond hd2 = ((list<TSecond>.Cons)b).hd;
                        list<TSecond> list2 = (list<TSecond>)((list<TSecond>.Cons)b).tl;
                        if (f.apply(hd, hd2))
                        {
                            list<T> arg_AD_0 = (list<T>)list;
                            list<TSecond> arg_AB_0 = (list<TSecond>)list2;
                            b = arg_AB_0;
                            a = arg_AD_0;
                            continue;
                        }
                        arg_C9_0 = 0;
                        return arg_C9_0 != 0;
                    }
                }
                goto IL_32;
            }
            if (b == list<TSecond>.Nil._N_constant_object)
            {
                int arg_C9_0 = 1;
                return arg_C9_0 != 0;
            }
        IL_32:
            return false;
        }

        public static bool Exists2<T, TSecond>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> a, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> b, Function<T, TSecond, bool> f)
        {
            while (b != null)
            {
                if (a == null)
                {
                    throw new ArgumentNullException("a", "The ``NotNull'' contract of parameter ``a'' has been violated. See lib\\list.n:1201:43:1201:44: .");
                }
                if (a == list<T>.Nil._N_constant_object)
                {
                    if (b == list<TSecond>.Nil._N_constant_object)
                    {
                        int arg_10A_0 = 0;
                        return arg_10A_0 != 0;
                    }
                }
                else if (a is list<T>.Cons)
                {
                    if (b is list<TSecond>.Cons)
                    {
                        T hd = ((list<T>.Cons)a).hd;
                        list<T> list = (list<T>)((list<T>.Cons)a).tl;
                        TSecond hd2 = ((list<TSecond>.Cons)b).hd;
                        list<TSecond> list2 = (list<TSecond>)((list<TSecond>.Cons)b).tl;
                        if (f.apply(hd, hd2))
                        {
                            int arg_10A_0 = 1;
                            return arg_10A_0 != 0;
                        }
                        list<T> arg_EF_0 = (list<T>)list;
                        list<TSecond> arg_ED_0 = (list<TSecond>)list2;
                        b = arg_ED_0;
                        a = arg_EF_0;
                        continue;
                    }
                }
                throw new ArgumentException("NList.Exists2");
            }
            throw new ArgumentNullException("b", "The ``NotNull'' contract of parameter ``b'' has been violated. See lib\\list.n:1201:67:1201:68: .");
        }

        /// <summary>
        ///   <para>NList membership test, using the `Equals' method to compare objects.
        ///
        /// </para>
        /// </summary>
        public static bool Member<T>(list<T> l, T a)
        {
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<T> list = l;
            int arg_5F_0;
            while (list is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list).hd;
                if (@default.Equals(hd, a))
                {
                    arg_5F_0 = 1;
                    return arg_5F_0 != 0;
                }
                list = (list<T>)((list<T>.Cons)list).tl;
            }
            arg_5F_0 = 0;
            return arg_5F_0 != 0;
        }

        /// <summary>
        ///   <para>NList membership test, using the reference equality.
        ///
        /// </para>
        /// </summary> <remarks><para>Returns true if and only if list [Collection] contains object with reference
        ///  equal to [Obj] object
        ///
        /// </para></remarks>
        public static bool ContainsRef<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> Collection, T Obj) where T : class
        {
            while (Collection != null)
            {
                bool arg_8E_0;
                if (Collection is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)Collection).hd;
                    list<T> list = (list<T>)((list<T>.Cons)Collection).tl;
                    if (hd != Obj)
                    {
                        list<T> arg_6B_0 = (list<T>)list;
                        Collection = arg_6B_0;
                        continue;
                    }
                    arg_8E_0 = true;
                }
                else
                {
                    if (Collection != list<T>.Nil._N_constant_object)
                    {
                        throw new MatchFailureException();
                    }
                    arg_8E_0 = false;
                }
                return arg_8E_0;
            }
            throw new ArgumentNullException("Collection", "The ``NotNull'' contract of parameter ``Collection'' has been violated. See lib\\list.n:1229:39:1229:49: .");
        }

        /// <summary>
        ///   <para>NList membership test, using the `Equals' method to compare objects.
        ///
        /// </para>
        /// </summary> <remarks><para>This is an alias for the `Member' method.
        ///
        /// </para></remarks>
        public static bool Contains<T>(list<T> l, T a)
        {
            return NList.Member<T>(l, a);
        }

        /// <summary>
        ///   <para>Finds the first elements for which a predicate is true.
        ///
        /// </para>
        /// </summary>
        public static option<T> Find<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> pred)
        {
            while (l != null)
            {
                option<T> arg_97_0;
                if (l is list<T>.Cons)
                {
                    T hd = ((list<T>.Cons)l).hd;
                    list<T> list = (list<T>)((list<T>.Cons)l).tl;
                    if (!pred.apply(hd))
                    {
                        list<T> arg_70_0 = (list<T>)list;
                        l = arg_70_0;
                        continue;
                    }
                    arg_97_0 = new option<T>.Some(hd);
                }
                else
                {
                    if (l != list<T>.Nil._N_constant_object)
                    {
                        throw new MatchFailureException();
                    }
                    arg_97_0 = option<T>.None._N_constant_object;
                }
                return arg_97_0;
            }
            throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1255:32:1255:33: .");
        }

        /// <summary>
        ///   <para>Returns the number of elements for which a predicate is true.
        ///
        /// </para>
        /// </summary>
        public static int FilteredLength<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> f)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1269:42:1269:43: .");
            }
            list<T> list = l;
            int num = 0;
            while (list != list<T>.Nil._N_constant_object)
            {
                if (!(list is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                list<T> arg_7C_0 = (list<T>)list;
                num = ((!f.apply(hd)) ? num : checked(num + 1));
                list = arg_7C_0;
            }
            return num;
        }

        /// <summary>
        ///   <para>Removes elements for which predicate is false
        ///
        /// </para>
        /// </summary>
        public static list<T> Filter<T>(list<T> l, Function<T, bool> f)
        {
            list<T>.Cons cons = null;
            list<T>.Cons cons2 = null;
            list<T> list = l;
            while (list is list<T>.Cons)
            {
                T t2 = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                if (f.apply(t2))
                {
                    list<T>.Cons cons3 = new list<T>.Cons(t2, list<T>.Nil._N_constant_object);
                    if (cons == null)
                    {
                        cons = cons3;
                        cons2 = cons3;
                    }
                    else
                    {
                        cons2.tl = cons3;
                        cons2 = cons3;
                    }
                }
            }
            return (!(cons == null)) ? (list<T>)cons : list<T>.Nil._N_constant_object;
        }

        /// <summary>
        ///   <para>Removes elements for which predicate is false.
        ///  The resulting list is reversed (operation is faster this way).
        ///
        /// </para>
        /// </summary>
        public static list<T> RevFilter<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> f)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1297:37:1297:38: .");
            }
            list<T> list = list<T>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                if (f.apply(hd))
                {
                    list<T> arg_72_0 = (list<T>)new list<T>.Cons(hd, list);
                    list = arg_72_0;
                }
                else
                {
                    list<T> arg_85_0 = (list<T>)list;
                    list = arg_85_0;
                }
            }
            if (list2 == list<T>.Nil._N_constant_object)
            {
                return list;
            }
            throw new MatchFailureException();
        }

        /// <summary>
        ///   <para>This is an alias for ``Filter''
        ///
        /// </para>
        /// </summary>
        public static list<T> FindAll<T>(list<T> l, Function<T, bool> f)
        {
            return NList.Filter<T>(l, f);
        }

        /// <summary>
        ///   <para>Partitions a list into two sublists according to a predicate.
        ///
        /// </para>
        /// </summary>
        public static Nemerle.Builtins.Tuple<list<T>, list<T>> Partition<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, bool> pred)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1325:36:1325:37: .");
            }
            list<T> list = l;
            list<T> list2 = list<T>.Nil._N_constant_object;
            list<T> list3 = list<T>.Nil._N_constant_object;
            while (list is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list).hd;
                list = (list<T>)((list<T>.Cons)list).tl;
                if (pred.apply(hd))
                {
                    list<T> arg_82_0 = (list<T>)list;
                    list<T> arg_81_0 = (list<T>)new list<T>.Cons(hd, list2);
                    list2 = arg_81_0;
                    list = arg_82_0;
                }
                else
                {
                    list<T> arg_A4_0 = (list<T>)list;
                    list<T> arg_A3_0 = (list<T>)list2;
                    list3 = (list<T>)new list<T>.Cons(hd, list3);
                    list2 = arg_A3_0;
                    list = arg_A4_0;
                }
            }
            if (list == list<T>.Nil._N_constant_object)
            {
                return new Nemerle.Builtins.Tuple<list<T>, list<T>>(NList.Rev<T>(list2), NList.Rev<T>(list3));
            }
            throw new MatchFailureException();
        }

        /// <summary>
        ///   <para>Groups equal element into lists</para>
        /// </summary>
        public static list<list<T>> Group<T>(list<T> l, Function<T, T, int> cmp)
        {
            Func<list<T>, list<T>, list<list<T>>> walk = null;
            walk = (l, acc) =>
            {
                T h = NList.Head(acc);
                if (l is list<T>.Cons)
                {
                    T e = ((list<T>.Cons)l).hd;
                    list<T> rest = ((list<T>.Cons)l).tl;
                    if (cmp.apply(e, h) == 0)
                    {
                        return walk(rest, new list<T>.Cons(e, acc));
                    }
                    else
                    {
                        return new list<list<T>>.Cons(acc, walk(rest, new list<T>.Cons(e, list<T>.Nil._N_constant_object)));
                    }
                }
                else
                {
                    return new list<list<T>>.Cons(acc, list<list<T>>.Nil._N_constant_object);
                }
            };

            if (NList.IsEmpty<T>(l))
            {
                return list<list<T>>.Nil._N_constant_object;
            }
            else
            {
                list<T> sorted = NList.Sort(l, cmp);
                return walk(NList.Tail(sorted), new list<T>.Cons(NList.Head(sorted), list<T>.Nil._N_constant_object));
            }
        }

        public static option<TSecond> Assoc<T, TSecond>(list<Nemerle.Builtins.Tuple<T, TSecond>> l, T key)
        {
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<Nemerle.Builtins.Tuple<T, TSecond>> list = l;
            option<TSecond>.Some arg_8C_0;
            while (list is list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)
            {
                T field = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list).hd.Field0;
                TSecond field2 = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list).hd.Field1;
                if (@default.Equals(key, field))
                {
                    arg_8C_0 = new option<TSecond>.Some(field2);
                    return arg_8C_0;
                }
                list = (list<Nemerle.Builtins.Tuple<T, TSecond>>)((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list).tl;
            }
            return option<TSecond>.None._N_constant_object;
        }

        public static bool MemAssoc<T, TSecond>(list<Nemerle.Builtins.Tuple<T, TSecond>> l, T key)
        {
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<Nemerle.Builtins.Tuple<T, TSecond>> list = l;
            int arg_64_0;
            while (list is list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)
            {
                T field = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list).hd.Field0;
                if (@default.Equals(key, field))
                {
                    arg_64_0 = 1;
                    return arg_64_0 != 0;
                }
                list = (list<Nemerle.Builtins.Tuple<T, TSecond>>)((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list).tl;
            }
            arg_64_0 = 0;
            return arg_64_0 != 0;
        }

        public static list<Nemerle.Builtins.Tuple<T, TSecond>> RemoveAssoc<T, TSecond>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<Nemerle.Builtins.Tuple<T, TSecond>> l, T key)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1396:48:1396:49: .");
            }
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            list<Nemerle.Builtins.Tuple<T, TSecond>> list = list<Nemerle.Builtins.Tuple<T, TSecond>>.Nil._N_constant_object;
            list<Nemerle.Builtins.Tuple<T, TSecond>> list2 = l;
            while (list2 is list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)
            {
                T field = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list2).hd.Field0;
                TSecond field2 = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list2).hd.Field1;
                list2 = (list<Nemerle.Builtins.Tuple<T, TSecond>>)((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list2).tl;
                if (@default.Equals(key, field))
                {
                    list<Nemerle.Builtins.Tuple<T, TSecond>> arg_98_0 = (list<Nemerle.Builtins.Tuple<T, TSecond>>)list;
                    list = arg_98_0;
                }
                else
                {
                    list<Nemerle.Builtins.Tuple<T, TSecond>> arg_B8_0 = (list<Nemerle.Builtins.Tuple<T, TSecond>>)new list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons(new Nemerle.Builtins.Tuple<T, TSecond>(field, field2), list);
                    list = arg_B8_0;
                }
            }
            if (list2 == list<Nemerle.Builtins.Tuple<T, TSecond>>.Nil._N_constant_object)
            {
                return NList.Rev<Nemerle.Builtins.Tuple<T, TSecond>>(list);
            }
            throw new MatchFailureException();
        }

        [Extension]
        public static Nemerle.Builtins.Tuple<list<T>, list<TSecond>> Split<T, TSecond>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<Nemerle.Builtins.Tuple<T, TSecond>> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1417:46:1417:47: .");
            }
            list<T> list = list<T>.Nil._N_constant_object;
            list<TSecond> list2 = list<TSecond>.Nil._N_constant_object;
            list<Nemerle.Builtins.Tuple<T, TSecond>> list3 = l;
            while (list3 is list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)
            {
                T field = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list3).hd.Field0;
                TSecond field2 = ((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list3).hd.Field1;
                list3 = (list<Nemerle.Builtins.Tuple<T, TSecond>>)((list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons)list3).tl;
                list<T> arg_A0_0 = (list<T>)new list<T>.Cons(field, list);
                list<TSecond> arg_9F_0 = (list<TSecond>)new list<TSecond>.Cons(field2, list2);
                list2 = arg_9F_0;
                list = arg_A0_0;
            }
            if (list3 == list<Nemerle.Builtins.Tuple<T, TSecond>>.Nil._N_constant_object)
            {
                return new Nemerle.Builtins.Tuple<list<T>, list<TSecond>>(NList.Rev<T>(list), NList.Rev<TSecond>(list2));
            }
            throw new MatchFailureException();
        }

        [Extension]
        public static list<Nemerle.Builtins.Tuple<T, TSecond>> Combine<T, TSecond>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<T> a, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<TSecond> b)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b", "The ``NotNull'' contract of parameter ``b'' has been violated. See lib\\list.n:1428:73:1428:74: .");
            }
            if (a == null)
            {
                throw new ArgumentNullException("a", "The ``NotNull'' contract of parameter ``a'' has been violated. See lib\\list.n:1428:49:1428:50: .");
            }
            list<Nemerle.Builtins.Tuple<T, TSecond>> list = list<Nemerle.Builtins.Tuple<T, TSecond>>.Nil._N_constant_object;
            list<T> list2 = a;
            list<TSecond> list3 = b;
            while (list2 is list<T>.Cons)
            {
                if (!(list3 is list<TSecond>.Cons))
                {
                    goto IL_CD;
                }
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                TSecond hd2 = ((list<TSecond>.Cons)list3).hd;
                list3 = (list<TSecond>)((list<TSecond>.Cons)list3).tl;
                list<Nemerle.Builtins.Tuple<T, TSecond>> arg_C7_0 = (list<Nemerle.Builtins.Tuple<T, TSecond>>)new list<Nemerle.Builtins.Tuple<T, TSecond>>.Cons(new Nemerle.Builtins.Tuple<T, TSecond>(hd, hd2), list);
                list<T> arg_C6_0 = (list<T>)list2;
                list2 = arg_C6_0;
                list = arg_C7_0;
            }
            if (list2 != list<T>.Nil._N_constant_object)
            {
                goto IL_CD;
            }
            if (list3 == list<TSecond>.Nil._N_constant_object)
            {
                return NList.Rev<Nemerle.Builtins.Tuple<T, TSecond>>(list);
            }

        IL_CD:
            throw new ArgumentException("NList.Combine");
        }

        private static list<T> MergeSort<T>(Function<T, T, int> cmp, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1442:51:1442:52: .");
            }
            checked
            {
                list<T> arg_22A_0;
                if (l != list<T>.Nil._N_constant_object)
                {
                    if (l is list<T>.Cons)
                    {
                        if (((list<T>.Cons)l).tl == list<T>.Nil._N_constant_object)
                        {
                            goto IL_3B;
                        }
                    }
                    list<T> list = l;
                    list<T> list2 = list<T>.Nil._N_constant_object;
                    int num = NList.Length<T>(l) / 2;
                    while (num != 0)
                    {
                        if (list is list<T>.Cons)
                        {
                            T hd = ((list<T>.Cons)list).hd;
                            list = (list<T>)((list<T>.Cons)list).tl;
                            list<T> arg_D6_0 = (list<T>)list;
                            list<T> arg_D5_0 = (list<T>)new list<T>.Cons(hd, list2);
                            num--;
                            list2 = arg_D5_0;
                            list = arg_D6_0;
                        }
                        else
                        {
                            if (list != list<T>.Nil._N_constant_object)
                            {
                                throw new MatchFailureException();
                            }
                            list<T> arg_F7_0 = (list<T>)list;
                            list<T> arg_F6_0 = (list<T>)list2;
                            num = 0;
                            list2 = arg_F6_0;
                            list = arg_F7_0;
                        }
                    }
                    Nemerle.Builtins.Tuple<list<T>, list<T>> tuple = new Nemerle.Builtins.Tuple<list<T>, list<T>>(NList.Rev<T>(list2), list);
                    list = (list<T>)tuple.Field0;
                    list2 = (list<T>)tuple.Field1;
                    list = NList.MergeSort<T>(cmp, list);
                    list2 = NList.MergeSort<T>(cmp, list2);
                    list<T> list3 = list<T>.Nil._N_constant_object;
                    while (list != list<T>.Nil._N_constant_object)
                    {
                        if (list2 == list<T>.Nil._N_constant_object)
                        {
                            arg_22A_0 = NList.RevAppend<T>(list3, list);
                            goto IL_220;
                        }
                        if (!(list is list<T>.Cons))
                        {
                            throw new MatchFailureException();
                        }
                        if (!(list2 is list<T>.Cons))
                        {
                            throw new MatchFailureException();
                        }
                        T hd = ((list<T>.Cons)list).hd;
                        list<T> list4 = (list<T>)((list<T>.Cons)list).tl;
                        T hd2 = ((list<T>.Cons)list2).hd;
                        list<T> list5 = (list<T>)((list<T>.Cons)list2).tl;
                        if (cmp.apply(hd, hd2) <= 0)
                        {
                            list<T> arg_1EC_0 = (list<T>)list4;
                            list<T> arg_1EB_0 = (list<T>)list2;
                            list3 = (list<T>)new list<T>.Cons(hd, list3);
                            list2 = arg_1EB_0;
                            list = arg_1EC_0;
                        }
                        else
                        {
                            list<T> arg_20E_0 = (list<T>)list;
                            list<T> arg_20D_0 = (list<T>)list5;
                            list3 = (list<T>)new list<T>.Cons(hd2, list3);
                            list2 = arg_20D_0;
                            list = arg_20E_0;
                        }
                    }
                    arg_22A_0 = NList.RevAppend<T>(list3, list2);
                IL_220:
                    return arg_22A_0;
                }
            IL_3B:
                arg_22A_0 = l;
                return arg_22A_0;
            }
        }

        public static list<T> Sort<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l, Function<T, T, int> cmp)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1479:31:1479:32: .");
            }
            return NList.MergeSort<T>(cmp, l);
        }

        public static list<T> Copy<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("l", "The ``NotNull'' contract of parameter ``l'' has been violated. See lib\\list.n:1485:31:1485:32: .");
            }
            list<T> list = list<T>.Nil._N_constant_object;
            list<T> list2 = l;
            while (list2 is list<T>.Cons)
            {
                T hd = ((list<T>.Cons)list2).hd;
                list2 = (list<T>)((list<T>.Cons)list2).tl;
                list<T> arg_66_0 = (list<T>)new list<T>.Cons(hd, list);
                list = arg_66_0;
            }
            if (list2 == list<T>.Nil._N_constant_object)
            {
                return NList.Rev<T>(list);
            }
            throw new MatchFailureException();
        }

        /// <summary>
        ///   <para>Assumes that [prod] is a product of n - 1 lists, and extends
        ///  product by adding every possible element of [x] to these lists.
        ///
        /// </para>
        /// </summary>
        private static list<list<T>> Product<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> x, [Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<list<T>> prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException("prod", "The ``NotNull'' contract of parameter ``prod'' has been violated. See lib\\list.n:1503:20:1503:24: .");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x", "The ``NotNull'' contract of parameter ``x'' has been violated. See lib\\list.n:1502:20:1502:21: .");
            }
            list<T> list = x;
            list<list<T>> list2 = prod;
            list<list<T>> list3 = list<list<T>>.Nil._N_constant_object;
            while (list2 != list<list<T>>.Nil._N_constant_object)
            {
                if (!(list2 is list<list<T>>.Cons))
                {
                    throw new MatchFailureException();
                }
                list<T> lst = (list<T>)((list<list<T>>.Cons)list2).hd;
                list2 = (list<list<T>>)((list<list<T>>.Cons)list2).tl;
                list<T> arg_9F_0 = (list<T>)list;
                list<list<T>> arg_9E_0 = (list<list<T>>)list2;
                list3 = (list<list<T>>)(NList._N_extend_20778<T>(list, lst, list<list<T>>.Nil._N_constant_object) + list3);
                list2 = arg_9E_0;
                list = arg_9F_0;
            }
            return list3;
        }

        /// <summary>
        ///   <para>Returns a product of lists stored in list [list].  Elements of
        ///  result are lists of the same length = NList.Length (list).
        ///
        /// </para>
        /// </summary> <remarks><para>E.g.:
        ///     Product ([[1, 2], [3, 4, 5]]) =
        ///   [[1, 3],
        ///    [1, 4],
        ///    [1, 5],
        ///    [2, 3],
        ///    [2, 4],
        ///    [2, 5]]
        ///
        /// </para>    <para>Product ([[1, 2], [3, 4, 5], []]) = []
        ///
        /// </para></remarks>
        [Extension]
        public static list<list<T>> Product<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] this list<list<T>> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list", "The ``NotNull'' contract of parameter ``list'' has been violated. See lib\\list.n:1544:25:1544:29: .");
            }
            list<list<T>> arg_D3_0;
            list<list<T>> list3;
            if (list == list<list<T>>.Nil._N_constant_object)
            {
                arg_D3_0 = list<list<T>>.Nil._N_constant_object;
            }
            else
            {
                if (!(list is list<list<T>>.Cons))
                {
                    throw new MatchFailureException();
                }
                list<T> list2 = (list<T>)((list<list<T>>.Cons)list).hd;
                list3 = (list<list<T>>)((list<list<T>>.Cons)list).tl;
                Function<T, list<T>> instance = Lambda.New<T, list<T>>(a => new list<T>.Cons(a, list<T>.Nil._N_constant_object));
                list<list<T>> list4 = NList.Map<T, list<T>>(list2, instance);
                while (list3 != list<list<T>>.Nil._N_constant_object)
                {
                    if (!(list3 is list<list<T>>.Cons))
                    {
                        throw new MatchFailureException();
                    }
                    list2 = (list<T>)((list<list<T>>.Cons)list3).hd;
                    list3 = (list<list<T>>)((list<list<T>>.Cons)list3).tl;
                    list<list<T>> arg_BC_0 = (list<list<T>>)list3;
                    list4 = (list<list<T>>)NList.Product<T>(list2, list4);
                    list3 = arg_BC_0;
                }
                arg_D3_0 = list4;
            }
            list3 = arg_D3_0;
            return NList.Map<list<T>, list<T>>(list3, Lambda.New<list<T>, list<T>>(a => NList.Rev(a)));
        }

        /// <summary>
        ///   <para>Return a list of all possible partitions of [set] into [count] subsets.
        ///
        /// </para>
        /// </summary>
        public static list<list<list<T>>> SubsetsPartitions<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> set, int count)
        {
            if (set == null)
            {
                throw new ArgumentNullException("set", "The ``NotNull'' contract of parameter ``set'' has been violated. See lib\\list.n:1571:20:1571:23: .");
            }
            list<T> list = set;
            list<list<T>> list2 = list<list<T>>.Nil._N_constant_object;
            int num = count;
            checked
            {
                while (num != 0)
                {
                    list<list<T>> arg_61_0 = (list<list<T>>)new list<list<T>>.Cons(list<T>.Nil._N_constant_object, (list<list<T>>)list2);
                    num--;
                    list2 = arg_61_0;
                }
                list<list<T>> hd = (list<list<T>>)list2;
                list<list<list<T>>> list3 = new list<list<list<T>>>.Cons(hd, list<list<list<T>>>.Nil._N_constant_object);
                while (list != list<T>.Nil._N_constant_object)
                {
                    if (!(list is list<T>.Cons))
                    {
                        throw new MatchFailureException();
                    }
                    T hd2 = ((list<T>.Cons)list).hd;
                    list = (list<T>)((list<T>.Cons)list).tl;
                    list<T> arg_CB_0 = (list<T>)list;
                    list3 = (list<list<list<T>>>)NList._N_extend_20891<T>(hd2, list3, list<list<list<T>>>.Nil._N_constant_object);
                    list = arg_CB_0;
                }
                return list3;
            }
        }

        public static list<list<T>> Singletons<T>([Macro("Nemerle.Assertions.NotNull:param:postadd", 0, "")] list<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list", "The ``NotNull'' contract of parameter ``list'' has been violated. See lib\\list.n:1620:38:1620:42: .");
            }
            return NList.RevMap<T, list<T>>(list, Lambda.New<T, list<T>>(a => new list<T>.Cons(a, list<T>.Nil._N_constant_object)));
        }

        /// <summary>
        ///   <para>Return list of all possible [n]-element subsets of set [list].
        ///
        /// </para>
        /// </summary>
        public static list<list<T>> SizeSubsets<T>(list<T> list, int n)
        {
            list<list<T>> arg_107_0;
            if (n == 0)
            {
                arg_107_0 = list<list<T>>.Nil._N_constant_object;
            }
            else if (list == list<T>.Nil._N_constant_object)
            {
                arg_107_0 = list<list<T>>.Nil._N_constant_object;
            }
            else if (n == 1)
            {
                arg_107_0 = NList.Singletons<T>(list);
            }
            else
            {
                if (!(list is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T t2 = ((list<T>.Cons)list).hd;
                list<T> list2 = (list<T>)((list<T>.Cons)list).tl;
                list<list<T>> list3 = NList.SizeSubsets<T>(list2, checked(n - 1));
                list<list<T>> list4 = list<list<T>>.Nil._N_constant_object;
                while (list3 != list<list<T>>.Nil._N_constant_object)
                {
                    if (!(list3 is list<list<T>>.Cons))
                    {
                        throw new MatchFailureException();
                    }
                    list<T> tl = (list<T>)((list<list<T>>.Cons)list3).hd;
                    list3 = (list<list<T>>)((list<list<T>>.Cons)list3).tl;
                    T arg_DF_0 = t2;
                    list<list<T>> arg_DE_0 = (list<list<T>>)list3;
                    list4 = (list<list<T>>)new list<list<T>>.Cons(new list<T>.Cons(t2, tl), list4);
                    list3 = arg_DE_0;
                    t2 = arg_DF_0;
                }
                list<list<T>> x = list4;
                arg_107_0 = NList.RevAppend<list<T>>(x, NList.SizeSubsets<T>(list2, n));
            }
            return arg_107_0;
        }

        /// <summary>
        ///   <para>Return list consisting of [count] references to [elem].
        /// </para>
        /// </summary>
        public static list<T> Repeat<T>(T elem, int count)
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
            if (step == 0)
            {
                throw new ArgumentException("Range () step argument must not be zero");
            }
            checked
            {
                list<int> arg_AE_0;
                if ((beg < end && step < 0) || (beg > end && step > 0) || beg == end)
                {
                    arg_AE_0 = list<int>.Nil._N_constant_object;
                }
                else
                {
                    int num = (end < 0) ? (end + 1) : (end - 1);
                    list<int> tl = list<int>.Nil._N_constant_object;
                    num -= (num - beg) % step;
                    while (num != beg)
                    {
                        list<int> arg_A1_0 = (list<int>)new list<int>.Cons(num, tl);
                        num -= step;
                        tl = arg_A1_0;
                    }
                    arg_AE_0 = new list<int>.Cons(num, tl);
                }
                return arg_AE_0;
            }
        }

        /// <summary>
        ///   <para>Return a list of characters from 'a' to [end], excluding [end].
        /// </para>
        /// </summary>
        public static list<char> Range(char end)
        {
            return NList.Range('a', end, 1);
        }

        /// <summary>
        ///   <para>Return a list of characters, which values are incremented by [step],
        ///  beginning with [beg], up/down to [end], excluding [end] itself.
        ///
        /// </para>
        /// </summary>
        public static list<char> Range(char b, char e, int step = 1)
        {
            if (step == 0)
            {
                throw new ArgumentException("Range () step argument must not be zero");
            }
            checked
            {
                list<char> arg_B1_0;
                if ((b < e && step < 0) || (b > e && step > 0) || b == e)
                {
                    arg_B1_0 = list<char>.Nil._N_constant_object;
                }
                else
                {
                    int num = (int)((step <= 0) ? (e + '\u0001') : (e - '\u0001'));
                    list<char> tl = list<char>.Nil._N_constant_object;
                    num -= (num - (int)b) % step;
                    while (num != (int)b)
                    {
                        list<char> arg_A3_0 = (list<char>)new list<char>.Cons((char)num, tl);
                        num -= step;
                        tl = arg_A3_0;
                    }
                    arg_B1_0 = new list<char>.Cons((char)num, tl);
                }
                return arg_B1_0;
            }
        }

        public static list<Result> Filter2<T1, T2, Result>(list<T1> list1, list<T2> list2, Function<T1, T2, Nemerle.Builtins.Tuple<bool, Result>> convert)
        {
            int capacity = 0;
            list<T1> list3 = list1;
            list<T2> list4 = list2;
            if (list1 != null)
            {
                capacity = list1.Length;
            }
            List<Result> list5 = new List<Result>(capacity);
            Function<T1, T2, Nemerle.Builtins.Tuple<bool, Result>> function = convert;
            while (list3 is list<T1>.Cons)
            {
                if (!(list4 is list<T2>.Cons))
                {
                    goto IL_EF;
                }
                T1 hd = ((list<T1>.Cons)list3).hd;
                list3 = (list<T1>)((list<T1>.Cons)list3).tl;
                T2 hd2 = ((list<T2>.Cons)list4).hd;
                list4 = (list<T2>)((list<T2>.Cons)list4).tl;
                Nemerle.Builtins.Tuple<bool, Result> tuple = function.apply(hd, hd2);
                if (tuple.Field0)
                {
                    Result field = tuple.Field1;
                    list5.Add(field);
                }
                list<T1> arg_E9_0 = (list<T1>)list3;
                list<T2> arg_E8_0 = (list<T2>)list4;
                List<Result> arg_E7_0 = (List<Result>)list5;
                function = (Function<T1, T2, Nemerle.Builtins.Tuple<bool, Result>>)convert;
                list5 = arg_E7_0;
                list4 = arg_E8_0;
                list3 = arg_E9_0;
            }
            list<Result> arg_140_0;
            if (list3 == list<T1>.Nil._N_constant_object)
            {
                if (list4 != list<T2>.Nil._N_constant_object)
                {
                    goto IL_EF;
                }
                arg_140_0 = list5.NToList<Result>();
            }
            else
            {
                if ((object)list4 != null)
                {
                    goto IL_EF;
                }
                arg_140_0 = list<Result>.Nil._N_constant_object;
            }
            return arg_140_0;

        IL_EF:
            throw new ArgumentException("The list1 and list2 has different Length");
        }

        private static list<list<T>> _N_extend_20778<T>(list<T> a, list<T> lst, list<list<T>> result)
        {
            while (a != list<T>.Nil._N_constant_object)
            {
                if (!(a is list<T>.Cons))
                {
                    throw new MatchFailureException();
                }
                T hd = ((list<T>.Cons)a).hd;
                list<T> list = (list<T>)((list<T>.Cons)a).tl;
                list<T> arg_65_0 = (list<T>)list;
                list<T> arg_63_0 = (list<T>)lst;
                result = (list<list<T>>)new list<list<T>>.Cons(new list<T>.Cons(hd, lst), result);
                lst = arg_63_0;
                a = arg_65_0;
            }
            return result;
        }

        private static list<list<list<T>>> _N_push_20882<T>(T elem, list<list<T>> list, list<list<T>> left, list<list<list<T>>> result)
        {
            while (list != list<list<T>>.Nil._N_constant_object)
            {
                if (!(list is list<list<T>>.Cons))
                {
                    throw new MatchFailureException();
                }
                list<T> list2 = (list<T>)((list<list<T>>.Cons)list).hd;
                list<list<T>> list3 = (list<list<T>>)((list<list<T>>.Cons)list).tl;
                T arg_7F_0 = elem;
                list<list<T>> arg_7D_0 = (list<list<T>>)list3;
                list<list<T>> arg_7B_0 = (list<list<T>>)new list<list<T>>.Cons(list2, left);
                result = (list<list<list<T>>>)new list<list<list<T>>>.Cons(left + new list<list<T>>.Cons(new list<T>.Cons(elem, list2), list<list<T>>.Nil._N_constant_object) + list3, result);
                left = arg_7B_0;
                list = arg_7D_0;
                elem = arg_7F_0;
            }
            return result;
        }

        private static list<list<list<T>>> _N_extend_20891<T>(T elem, list<list<list<T>>> list, list<list<list<T>>> result)
        {
            while (list != list<list<list<T>>>.Nil._N_constant_object)
            {
                if (!(list is list<list<list<T>>>.Cons))
                {
                    throw new MatchFailureException();
                }
                list<list<T>> list2 = (list<list<T>>)((list<list<list<T>>>.Cons)list).hd;
                list<list<list<T>>> list3 = (list<list<list<T>>>)((list<list<list<T>>>.Cons)list).tl;
                T arg_65_0 = elem;
                list<list<list<T>>> arg_63_0 = (list<list<list<T>>>)list3;
                result = (list<list<list<T>>>)(NList._N_push_20882<T>(elem, list2, list<list<T>>.Nil._N_constant_object, list<list<list<T>>>.Nil._N_constant_object) + result);
                list = arg_63_0;
                elem = arg_65_0;
            }
            return result;
        }
    }
}
