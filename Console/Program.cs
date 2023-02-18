using DataStructures;
using DataStructures.LinkedLists;
using DataStructures.Node;

DataStructures.Queue<int> queue = new DataStructures.Queue<int>(2);
queue.Enqueue(1);
queue.Enqueue(3);

queue.Dequeue(out int _);

DataStructures.Queue<int> queue1 = new(Enumerable.Range(1, 5));
Console.WriteLine(queue1);
Console.ReadLine();