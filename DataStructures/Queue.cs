using DataStructures.Node;
using System.Collections;

namespace DataStructures;

public sealed class Queue<T> : IEnumerable<T>
    where T : IComparable<T>, IEquatable<T>
{
    /// <summary>
    /// First element
    /// </summary>
    public Node<T>? Front { get; private set; }

    /// <summary>
    /// Last element
    /// </summary>
    public Node<T>? Back { get; private set; }
    public int Count { get; private set; }

    public Queue() { }

    public Queue(T data)
    {
        SetFrontAndBack(data);
    }

    public Queue(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            Enqueue(item);
    }

    private void SetFrontAndBack(T data)
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

    /// <summary>
    /// Add new element to queue
    /// </summary>
    /// <param name="data">Some data</param>
    public void Enqueue(T data)
    {
        if (Back is null)
        {
            SetFrontAndBack(data);
            return;
        }

        Back.Next = new Node<T>(data);
        Back = Back.Next;
        Count++;
    }

    /// <summary>
    /// Remove element from queue
    /// </summary>
    /// <param name="value"> return value </param>
    /// <exception cref="NullReferenceException"></exception>
    public void Dequeue(out T value)
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        value = Peek();
        InternalDequeue();
    }

    /// <summary>
    /// Remove element from queue
    /// </summary>
    /// <exception cref="NullReferenceException"></exception>
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
    /// <summary>
    /// Return data from first element in queue
    /// </summary>
    /// <returns> first element data </returns>
    /// <exception cref="NullReferenceException"></exception>
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
