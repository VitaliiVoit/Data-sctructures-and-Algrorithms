namespace DataStructuresTests;

[TestFixture]
public class StackTests
{
    private DataStructures.Stack<int> stack;
    [SetUp]
    public void SetUp()
    {
        stack = new(Enumerable.Range(1, 5));
    }

    [Test, TestCase(10)]
    public void PushTest(int data)
    {
        // Act
        stack.Push(data);

        //Assert
        Assert.That(data, Is.EqualTo(stack.Peek()));
    }

    [Test]
    public void PopTest()
    {
        // Arrange
        var topData = stack.Peek();

        // Act
        stack.Pop(out int value);

        // Assert
        Assert.That(topData, Is.EqualTo(value));
    }
}
