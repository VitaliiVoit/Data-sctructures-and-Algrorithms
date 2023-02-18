namespace DataStructuresTests;

[TestFixture]
public class QueueTests
{
    private DataStructures.Queue<int> queue;

    [SetUp]
    public void SetUp()
    {
        queue = new DataStructures.Queue<int>(Enumerable.Range(1, 5));
    }

    [Test, TestCase(6)]
    public void EnqueueTest(int data)
    {
        // Act 
        queue.Enqueue(data);

        // Assert
        Assert.That(data, Is.EqualTo(queue.Back?.Data));
    }

    [Test]
    public void DequeueTest()
    {
        // Arrange
        var frontData = queue.Peek();

        // Act
        queue.Dequeue(out int result);

        //Assert
        Assert.That(frontData, Is.EqualTo(result));
    }
}
