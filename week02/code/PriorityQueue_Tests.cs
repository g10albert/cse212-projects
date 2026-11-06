using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority (highest number first).
    // Defect(s) Found: Loop bounds skipped the last item, and items were never removed from the queue list.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("High Priority", 10);
        priorityQueue.Enqueue("Medium Priority", 5);

        Assert.AreEqual("High Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Medium Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Low Priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items that share the exact same priority level.
    // Expected Result: Items are dequeued following FIFO order (the one closest to the front is removed first).
    // Defect(s) Found: The comparison used >= instead of >, which incorrectly selected the later item instead of the first inserted item.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Added", 3);
        priorityQueue.Enqueue("Second Added", 3);
        priorityQueue.Enqueue("Third Added", 3);

        Assert.AreEqual("First Added", priorityQueue.Dequeue());
        Assert.AreEqual("Second Added", priorityQueue.Dequeue());
        Assert.AreEqual("Third Added", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to call Dequeue on an empty priority queue.
    // Expected Result: Throws an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None (handled correctly by existing check).
    public void TestPriorityQueue_Empty()
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
    }
}