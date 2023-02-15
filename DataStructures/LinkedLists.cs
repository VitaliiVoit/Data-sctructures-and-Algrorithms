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

    public bool Contains(T data) => Find(data) is not null;

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
        if (!Contains(data)) throw new ArgumentException("Don't have such element");

        if (Head.Data.Equals(data)) 
        {
            RemoveFirst();
            return;
        }

        var current = Head;
        while (current.Next is not null && !current.Next.Data.Equals(data))
            current = current.Next;
        var removeNode = current.Next;
        if (removeNode?.Next is null) Tail = current; // Change Tail element
        current.Next = removeNode?.Next;
        Count--; 
    }

    public void RemoveFirst()
    {
        if (Head is null) throw new NullReferenceException("List is empty");

        Head = Head.Next;
        Count--;
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
}