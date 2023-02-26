using DataStructures.Node;
using System.Collections;

namespace DataStructures.LinkedLists;

public sealed class SingleLinkedList<T> : IEnumerable<T>
    where T: IComparable<T>, IEquatable<T>
{
    public Node<T>? Head { get; private set; }
    public Node<T>? Tail { get; private set; }
    public int Count { get; private set; }

    public SingleLinkedList()
    {

    }

    public SingleLinkedList(T data)
    {
        SetHeadAndTail(data);
    }

    public SingleLinkedList(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            AddAtEnd(item);
    }

    private void SetHeadAndTail(T data)
    {
        Head = Tail = new Node<T>(data);
        Count = 1;
    }

    public void Clear()
    {
        Head = Tail = null;
        Count = 0;
    }

    public void AddAtFront(T data)
    {
        if (Head is null)
        {
            SetHeadAndTail(data);
            return;
        }

        var node = new Node<T>(data, Head);
        Head = node;
        Count++;
    }

    public void AddAtEnd(T data)
    {
        if (Tail is null)
        {
            SetHeadAndTail(data);
            return;
        }

        Tail.Next = new Node<T>(data);
        Tail = Tail.Next;
        Count++;
    }

    public Node<T>? Find(T data)
    {
        if (Head is null) throw new NullReferenceException("List is empty");

        var current = Head;
        while (current is not null && !current.Data.Equals(data))
            current = current.Next;

        return current;
    }

    public void Remove(T data)
    {
        if (Head is null) throw new NullReferenceException("List is empty");
        if (!this.Contains(data)) throw new InvalidDataException("List doesn't have this element");

        if (Head.Data.Equals(data)) 
        {
            RemoveFirst();
            return;
        }

        var current = Head.Next;
        var prev = Head;
        while (current is not null && !current.Data.Equals(data))
        {
            prev = current;
            current = current.Next;
        }
        prev.Next = current?.Next;
        if (current == Tail) Tail = prev; // Change Tail element
        Count--;
    }

    public void RemoveFirst()
    {
        if (Head is null) throw new NullReferenceException("List is empty");

        Head = Head.Next;
        Count--;
        if (Head is null) Tail = Head;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
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
        return string.Join(" -> ", this) + " -> ";
    }
}

public sealed class DoubleLinkedList<T> : IEnumerable<T>
    where T : IComparable<T>, IEquatable<T>
{
    /// <summary>
    /// First element
    /// </summary>
    public DoubleNode<T>? Head { get; private set; }
    
    /// <summary>
    /// Last element
    /// </summary>
    public DoubleNode<T>? Tail { get; private set; }

    public int Count { get; private set; }

    public DoubleLinkedList() { }

    public DoubleLinkedList(T data)
    {
        SetHeadAndTail(data);
    }

    public DoubleLinkedList(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            AddAtEnd(item);
    }

    private void SetHeadAndTail(T data)
    {
        Head = Tail = new DoubleNode<T>(data);
        Count = 1;
    }

    public void AddAtFront(T data)
    {
        if (Head is null)
        {
            SetHeadAndTail(data);
            return;
        }

        Head.Previous = new DoubleNode<T>(data, Head);
        Head = Head.Previous;
        Count++;

    }

    public void AddAtEnd(T data)
    {
        if (Tail is null)
        {
            SetHeadAndTail(data);
            return;
        }

        Tail.Next = new DoubleNode<T>(data, previous: Tail);
        Tail = Tail.Next;
        Count++;
    }

    public void Remove(T data)
    {
        if (Head is null || Tail is null) throw new NullReferenceException("List is empty");
        if (!this.Contains(data)) throw new InvalidDataException("Don`t have this data");

        if (Head.Data.Equals(data)) { RemoveFirst(); return; }
        if (Tail.Data.Equals(data)) { RemoveLast(); return; }

        var current = Head;
        while (current is not null && !current.Data.Equals(data))
            current = current.Next;

        current!.Previous!.Next = current.Next;
        current!.Next!.Previous = current.Previous;
        Count--;
    }

    public void RemoveFirst()
    {
        if (Head is null) throw new NullReferenceException("List is empty");

        Head = Head.Next;
        Count--;

        if (Head is not null) Head.Previous = null;
        if (Head is null) Tail = Head;
    }

    public void RemoveLast()
    {
        if (Tail is null) throw new NullReferenceException("List is empty");

        Tail = Tail.Previous;
        Count--;

        if (Tail is not null) Tail.Next = null;
        if (Tail is null) Head = Tail;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
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
        return "<->" + string.Join(" <-> ", this) + " <->";
    }
}