using DataStructures.Node;
using System.Collections;

namespace DataStructures;

public class Deque<T> : IEnumerable<T>
    where T : IComparable<T>, IEquatable<T>
{
    /// <summary>
    /// Front element
    /// </summary>
    public DoubleNode<T>? Front { get; private set; }

    /// <summary>
    /// Back element
    /// </summary>
    public DoubleNode<T>? Back { get; private set; }

    public int Count { get; set; }

    public Deque() { }

    public Deque(T data)
    {
        SetFrontAndBack(data);
    }

    public Deque(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            PushBack(item);
    }

    private void SetFrontAndBack(T data)
    {
        Front = Back = new DoubleNode<T>(data);
        Count = 1;
    }

    public T PeekFront()
    {
        if (Front is null) throw new NullReferenceException("Deque is empty");

        return Front.Data;
    }

    public T PeekBack()
    {
        if (Back is null) throw new NullReferenceException("Deque is empty");

        return Back.Data;
    }

    public void PopFront()
    {
        if (Front is null) throw new NullReferenceException("Deque is empty");
        InternalPopFront();
    }

    public void PopFront(out T value)
    {
        if (Front is null) throw new NullReferenceException("Deque is empty");

        value = PeekFront();
        InternalPopFront();
    }

    private void InternalPopFront()
    {
        Front = Front?.Next;
        Count--;

        if (Front is not null) Front.Previous = null;
        if (Front is null) Back = Front;
    }

    public void PopBack()
    {
        if (Back is null) throw new NullReferenceException("Deque is empty");

        InternalPopBack();
    }

    public void PopBack(out T value)
    {
        if (Back is null) throw new NullReferenceException("Deque is empty");

        value = PeekBack();
        InternalPopBack();
    }

    private void InternalPopBack()
    {
        Back = Back?.Previous;
        Count--;

        if (Back is not null) Back.Next = null;
        if (Back is null) Front = Back;
    }

    public void PushFront(T data)
    {
        if (Front is null)
        {
            SetFrontAndBack(data);
            return;
        }

        Front.Previous = new DoubleNode<T>(data, Front);
        Front = Front.Previous;
        Count++;
    }

    public void PushBack(T data)
    {
        if (Back is null)
        {
            SetFrontAndBack(data);
            return;
        }

        Back.Next = new DoubleNode<T>(data, previous: Back);
        Back = Back.Next;
        Count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Front;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" | ", this);
    }
}
