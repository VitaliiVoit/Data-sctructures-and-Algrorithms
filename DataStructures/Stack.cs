using DataStructures.Node;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures;

public class Stack<T> : IEnumerable<T>
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

    public void Pop(out T value)
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");

        value = Top.Data;
        Top = Top.Next;
        Count--;
    }

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
