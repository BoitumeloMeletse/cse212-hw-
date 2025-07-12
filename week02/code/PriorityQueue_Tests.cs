using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 elements of different priorities and remove them
    // Expected Result: highest priority first
    // Defect(s) Found: Dequeue did not actually remove items; only returned value
    public void TestPriorityQueue_DifferentPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("medium", 3);
        pq.Enqueue("high", 5);

        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("medium", pq.Dequeue());
        Assert.AreEqual("low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple elements with same priority
    // Expected Result: FIFO order for same priority
    // Defect(s) Found: Did not properly check all elements for highest priority
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("first", 10);
        pq.Enqueue("second", 10);
        pq.Enqueue("third", 10);

        Assert.AreEqual("first", pq.Dequeue());
        Assert.AreEqual("second", pq.Dequeue());
        Assert.AreEqual("third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Exception
    // Defect(s) Found: No defect after fix
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}