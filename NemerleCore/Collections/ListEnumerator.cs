using Nemerle.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nemerle.Collections
{
    /// <summary>
    ///   <para>The state of a list enumerator.</para>
    /// </summary>
    internal enum ListEnumState
    {
        BeforeFirst,
        Correct,
        AfterLast
    }

    /// <summary>
    ///   <para>An enumerator for lists.</para>
    /// </summary>
    public struct ListEnumerator<T> : IEnumerator, IDisposable, IEnumerator<T>, ICovariantEnumerator<T>
    {
        // -- PRIVATE FIELDS ----------------------------------------------------

        private list<T> _list;

        private T _current;

        private list<T> _rest;

        private ListEnumState _state;

        // -- PUBLIC CONSTRUCTORS -----------------------------------------------

        public ListEnumerator(list<T> list)
        {
            _list = list;
            _current = default(T);
            _rest = _list;
            _state = ListEnumState.BeforeFirst;
        }

        void IDisposable.Dispose()
        {
        }

        private bool DoMove()
        {
            list<T>.Cons cons = this._list as list<T>.Cons;
            if (cons != null)
            {
                T hd = cons.hd;
                list<T> tl = cons.tl;
                this._current = hd;
                this._rest = tl;
                return true;
            }
            else
            {
                this._state = ListEnumState.AfterLast;
                return false;
            }
        }

        // -- PUBLIC METHODS ----------------------------------------------------

        public bool MoveNext()
        {
            switch (_state)
            {
                case ListEnumState.BeforeFirst:
                    _state = ListEnumState.Correct;
                    return DoMove();
                case ListEnumState.Correct:
                    return DoMove();
                case ListEnumState.AfterLast:
                    return false;
                default:
                    throw new MatchFailureException();
            }
        }

        public void Reset()
        {
            _rest = _list;
            _state = ListEnumState.BeforeFirst;
        }

        // -- PUBLIC PROPERTIES -------------------------------------------------

        public T Current => _current;

        object IEnumerator.Current
        {
            get
            {
                switch (_state)
                {
                    case ListEnumState.Correct:
                        return _current;
                    case ListEnumState.BeforeFirst:
                        throw new InvalidOperationException("Enumeration has not started.");
                    case ListEnumState.AfterLast:
                        throw new InvalidOperationException("Enumeration already finished.");
                    default:
                        throw new MatchFailureException();
                }
            }
        }
    }
}
