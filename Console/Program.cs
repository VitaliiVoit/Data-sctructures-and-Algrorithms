using DataStructures;
using DataStructures.LinkedLists;
using DataStructures.Node;

var doubleList = new DoubleLinkedList<int>(3);
doubleList.AddAtEnd(1);
doubleList.RemoveLast();


Console.WriteLine(doubleList);
Console.ReadLine();