using System;

namespace Nemerle.Collections
{
    public interface ICovariantList<out T>
    {
        bool IsEmpty { get; }

        T Head { get; }

        ICovariantList<T> CovariantTail { get; }
    }

    public interface ICovariantEnumerable<out T>
    {
        ICovariantEnumerator<T> GetEnumerator();
    }

    public interface ICovariantEnumerator<out T>
    {
        T Current
        {
            get;
        }

        bool MoveNext();

        void Reset();
    }
}
