using DataStructures.LinkedLists;
using DataStructures.Node;

DataStructures.Stack<int> stack = new DataStructures.Stack<int>(Enumerable.Range(1, 5));

stack.Push(2);
stack.Push(4);
stack.Push(1);

stack.Pop(out int value);

var result = stack.Find(3);

Console.WriteLine(result is null);
Console.WriteLine(value);

Console.WriteLine(stack);
Console.ReadLine();