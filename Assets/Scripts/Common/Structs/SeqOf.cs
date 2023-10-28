using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// represents a immutable sequence of any thing
/// </summary>
/// <typeparam name="T"></typeparam>
public struct SeqOf<T> : IReadOnlyList<T>
{
    T[] _items;

    public SeqOf(IEnumerable<T> items)
    {
        _items = items.ToArray();

    }

    public SeqOf(params T[] items)
    {
        _items = items;
    }

    public int count
    {
        get
        {
            if (_items == null)
            {
                return 0;
            }
            return _items.Length;
        }
    }

    int IReadOnlyCollection<T>.Count
    {
        get
        {
            return count;
        }
    }

    public T this[int index]
    {
        get
        {
            return _items[index];
        }
    }


    public override bool Equals(object obj)
    {
        if (obj is SeqOf<T>)
        {
            var other = (SeqOf<T>)obj;
            if (other.count != count)
                return false;
            for (int i = 0; i < count; i++)
            {
                if (!Equals(this[i], other[i]))
                    return false;
            }
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        if (_items == null || _items.Length == 0)
        {
            return 0;
        }

        int hash = 17;
        for (int i = 0; i < count; i++)
        {
            hash = hash * 23 + this[i]?.GetHashCode() ?? 0;
        }
        return hash;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}