using DataStructures.LinkedLists;

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
        var result = list.Remove(data);
        var contains = list.Contains(data);

        // Assert
        Assert.That(contains, Is.False);
    }

    [Test]
    public void RemoveFirstTest()
    {
        // Arrange
        var firstData = list.Head?.Data;

        // Act
        var result = list.RemoveFirst();

        // Assert
        Assert.That(result, Is.EqualTo(firstData));
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
        var firstData = list.Head?.Data;

        // Act
        var result = list.RemoveFirst();

        // Assert
        Assert.That(result, Is.EqualTo(firstData));
    }

    [Test]
    public void RemoveLastTest()
    {
        // Arrange
        var lastData = list.Tail?.Data;

        // Act
        var result = list.RemoveLast();

        // Assert
        Assert.That(result, Is.EqualTo(lastData));
    }
}