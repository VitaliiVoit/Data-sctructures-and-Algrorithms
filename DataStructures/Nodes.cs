namespace DataStructures.Node;

/// <summary>
/// Single Node
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
    where T : IComparable<T>, IEquatable<T>
{
    public T Data { get; init; }

    public Node<T>? Next { get; set; }

    public Node(T data, Node<T>? next = null)
        => (Data, Next) = (data, next);

    public override string? ToString() => Data.ToString();
}