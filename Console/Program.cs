using DataStructures.LinkedLists;
using DataStructures.Node;

var linkedList = new SingleLinkedList<int>();


linkedList.AddAtFront(1);
linkedList.AddAtEnd(5);
linkedList.AddAtEnd(3);

var result = linkedList.Find(7) is null;
Console.WriteLine("Element is :" + result);

foreach (var item in linkedList)
{
    Console.Write($"{item} -> ");
}
Console.WriteLine();

Console.WriteLine(linkedList);

Console.WriteLine();
Console.ReadLine();