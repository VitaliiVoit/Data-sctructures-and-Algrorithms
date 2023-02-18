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
        bool result = list.Remove(data);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void RemoveFirstTest()
    {
        // Act
        bool result = list.RemoveFirst();

        // Assert
        Assert.That(result, Is.True);
    }
}
