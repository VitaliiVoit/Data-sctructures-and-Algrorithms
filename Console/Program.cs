using DataStructures;
using DataStructures.LinkedLists;
using DataStructures.Node;

var linkedList = new SingleLinkedList<int>(Enumerable.Range(1, 5));
linkedList.Remove(5);
linkedList.Remove(4);
linkedList.Remove(3);
linkedList.Remove(2);
linkedList.Remove(1);

Console.ReadLine();