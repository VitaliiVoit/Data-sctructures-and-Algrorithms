using DataStructures.Node;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures;

public sealed class Stack<T> : IEnumerable<T>
    where T: IComparable<T>, IEquatable<T>
{
    public Node<T>? Top { get; private set; }
    public int Count { get; private set; }

    public Stack()
    {

    }

    public Stack(T data)
    {
        SetTop(data);
    }

    public Stack(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        foreach (var item in values)
            Push(item);
    }

    private void SetTop(T data)
    {
        Top = new Node<T>(data);
        Count = 1;
    }

    public void Clear()
    {
        Top = null;
        Count = 0;
    }
    public bool Contains(T data) => Find(data) is not null;

    public Node<T>? Find(T data)
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");

        var current = Top;
        while (current is not null && !current.Data.Equals(data))
            current = current.Next;

        return current;
    }

    /// <summary>
    /// Add new element to stack
    /// </summary>
    /// <param name="data"> some data </param>
    public void Push(T data)
    {
        if (Top is null)
        {
            SetTop(data);
            return;
        }

        Top = new Node<T>(data) { Next = Top };
        Count++;
    }

    /// <summary>
    /// Remove element from stack
    /// </summary>
    /// <param name="value"> return value </param>
    /// <exception cref="NullReferenceException"></exception>
    public void Pop(out T value)
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");

        value = Top.Data;
        InternalPop();
    }

    /// <summary>
    /// Remove element from stack
    /// </summary>
    /// <exception cref="NullReferenceException"></exception>
    public void Pop()
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");

        InternalPop();
    }

    private void InternalPop()
    {
        Top = Top?.Next;
        Count--;
    }

    /// <summary>
    /// Return data from top element in stack
    /// </summary>
    /// <returns> top element data </returns>
    /// <exception cref="NullReferenceException"></exception>
    public T Peek()
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");

        return Top.Data;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Top;
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
        return string.Join("|", this) + "]";
    }
}
