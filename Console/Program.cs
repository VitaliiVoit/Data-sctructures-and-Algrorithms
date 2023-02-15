using DataStructures.LinkedLists;
using DataStructures.Node;

var linkedList = new SingleLinkedList<int>();


linkedList.AddAtFront(1);
linkedList.AddAtEnd(5);
linkedList.AddAtEnd(3);

Console.WriteLine("Element is :" + linkedList.Find(7));

foreach (var item in linkedList)
{
    Console.Write($"{item} -> ");
}


Console.WriteLine();
Console.ReadLine();