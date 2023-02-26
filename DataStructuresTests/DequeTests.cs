using DataStructures;

namespace DataStructuresTests;

[TestFixture]
public class DequeTests
{
    private Deque<int> deque;

    [SetUp]
    public void SetUp()
    {
        deque = new Deque<int>(Enumerable.Range(2, 5));
    }

    [Test, TestCase(2)]
    public void PushFrontTest(int data)
    {
        deque.PushFront(data);

        Assert.That(data, Is.EqualTo(deque.PeekFront()));
    }

    [Test, TestCase(7)]
    public void PushBackTest(int data)
    {
        deque.PushBack(data);

        Assert.That(data, Is.EqualTo(deque.PeekBack()));
    }

    [Test]
    public void PopFrontTest()
    {
        var frontData = deque.PeekFront();

        deque.PopFront(out int value);

        Assert.That(frontData, Is.EqualTo(value));
    }

    [Test]
    public void PopBackTest()
    {
        var backFront = deque.PeekBack();

        deque.PopBack(out int value);

        Assert.That(backFront, Is.EqualTo(value));
    }
}
