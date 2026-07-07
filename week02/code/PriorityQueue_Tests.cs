using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and then dequeue them.
    // Expected Result: The highest-priority item is removed first, then the next highest, and so on.
    // Defect(s) Found: The implementation was not selecting the highest-priority item correctly.
    public void TestPriorityQueue_DequeueReturnsHighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alpha", 1);
        priorityQueue.Enqueue("Bravo", 3);
        priorityQueue.Enqueue("Charlie", 2);

        Assert.AreEqual("Bravo", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
        Assert.AreEqual("Alpha", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The earliest item with that priority is removed first, following FIFO order.
    // Defect(s) Found: The implementation did not preserve FIFO order for equal-priority items.
    public void TestPriorityQueue_TiesUseFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 1);
        priorityQueue.Enqueue("Fourth", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: The implementation did not throw the required exception for an empty queue.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}