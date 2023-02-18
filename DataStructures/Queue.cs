using DataStructures.Node;
using System.Collections;

namespace DataStructures;

public class Queue<T> : IEnumerable<T>
    where T : IComparable<T>, IEquatable<T>
{
    public Node<T>? Front { get; private set; }
    public Node<T>? Back { get; private set; }
    public int Count { get; private set; }

    public Queue() { }

    public Queue(T data)
    {
        SetFront(data);
    }

    public Queue(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            Enqueue(item);
    }

    private void SetFront(T data)
    {
        Front = Back = new Node<T>(data);
        Count = 1;
    }

    public void Clear() => Front = Back = null;

    public bool Contains(T data) => Find(data) is not null;

    public Node<T>? Find(T data)
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        var current = Front;
        while (current is not null && !current.Data.Equals(data))
            current = current.Next;

        return current;
    }

    public void Enqueue(T data)
    {
        if (Back is null)
        {
            SetFront(data);
            return;
        }

        Back.Next = new Node<T>(data);
        Back = Back.Next;
        Count++;
    }

    public void Dequeue(out T value)
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        value = Front.Data;
        InternalDequeue();
    }

    public void Dequeue()
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        InternalDequeue();
    }

    private void InternalDequeue()
    {
        Front = Front?.Next;
        Count--;
        if (Front is null) Back = null;
    }

    public T Peek()
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        return Front.Data;

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
        return string.Join(" <- ", this);
    }
}
