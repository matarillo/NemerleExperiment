using System;
using System.Collections.Generic;
using Nemerle.Builtins;
using Nemerle.Core;

namespace Nemerle.Collections
{
    public static class NCollectionsExtensions
    {
        public static To[] MapToArray<From, To>(this IEnumerable<From> source, Function<From, To> convert)
        {
            throw new NotImplementedException();
        }

        public static list<T> NToList<T>(this List<T> source)
        {
            checked
            {
                int num = source.Count - 1;
                list<T> list = list<T>.Nil._N_constant_object;
                while (num >= 0)
                {
                    int arg_31_0 = num - 1;
                    list = (list<T>)new list<T>.Cons(source[num], list);
                    num = arg_31_0;
                }
                return list;
            }
        }
    }
}
