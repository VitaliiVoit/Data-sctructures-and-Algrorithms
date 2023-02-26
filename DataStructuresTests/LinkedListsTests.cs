using DataStructures.LinkedLists;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructuresTests;

[TestFixture]
public class SingleLinkedListTests
{
    private SingleLinkedList<int> list;
    [SetUp]
    public void SetUp()
    {
        list = new SingleLinkedList<int>(Enumerable.Range(1, 5));
    }

    [Test, TestCase(12)]
    public void AddAtFrontTest(int data)
    {
        // Act
        list.AddAtFront(data);

        // Assert

        Assert.That(data, Is.EqualTo(list.Head?.Data));
    }

    [Test, TestCase(26)]
    public void AddAtEndTest(int data)
    {
        // Act
        list.AddAtEnd(data);

        // Assert
        Assert.That(data, Is.EqualTo(list.Tail?.Data));
    }

    [Test, TestCase(4)]
    public void RemoveTest(int data)
    {
        // Act
        list.Remove(data);
        var contains = list.Contains(data);

        // Assert
        Assert.That(contains, Is.False);
    }

    [Test]
    public void RemoveFirstTest()
    {
        // Arrange
        var firstData = list.Head!.Data;

        // Act
        list.RemoveFirst();
        var contains = list.Contains(firstData);

        // Assert
        Assert.That(contains, Is.False);
    }
}

[TestFixture]
public class DoubleLinkedListTests
{
    private DoubleLinkedList<int> list;
    [SetUp]
    public void SetUp()
    {
        list = new DoubleLinkedList<int>(Enumerable.Range(1, 5));
    }

    [Test, TestCase(12)]
    public void AddAtFrontTest(int data)
    {
        // Act
        list.AddAtFront(data);

        // Assert

        Assert.That(data, Is.EqualTo(list.Head?.Data));
    }

    [Test, TestCase(26)]
    public void AddAtEndTest(int data)
    {
        // Act
        list.AddAtEnd(data);

        // Assert
        Assert.That(data, Is.EqualTo(list.Tail?.Data));
    }

    [Test, TestCase(4)]
    public void RemoveTest(int data)
    {
        // Act
        list.Remove(data);
        var contains = list.Contains(data);

        // Assert
        Assert.That(contains, Is.False);
    }

    [Test]
    public void RemoveFirstTest()
    {
        // Arrange
        var firstData = list.Head!.Data;

        // Act
        list.RemoveFirst();
        var result = list.Contains(firstData);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveLastTest()
    {
        // Arrange
        var lastData = list.Tail!.Data;

        // Act
        list.RemoveLast();
        var result = list.Contains(lastData);

        // Assert
        Assert.That(result, Is.False);
    }
}