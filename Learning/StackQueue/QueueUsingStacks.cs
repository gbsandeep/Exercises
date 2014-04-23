using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Learning.StackQueue {
    [TestClass]
    public class UTQueueUsingStacks {
        [TestMethod]
        public void CountGTOne() {
            var queue = new QueueUsingStacks<int>();
            queue.Queue(1);
            queue.Queue(2);
            queue.Queue(3);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }

        [TestMethod]
        public void ZeroElements() {
            var queue = new QueueUsingStacks<int>();
            Assert.AreEqual(default(int), queue.Dequeue());
        }
    }

    public class QueueUsingStacks<T> {
        Stack<T> Front { get; set; }
        Stack<T> Back { get; set; }

        public QueueUsingStacks() {
            Front = new Stack<T>();
            Back = new Stack<T>();
        }

        public void Queue(T data) {
            Front.Push(data);
        }

        public T Dequeue() {
            T retValue = default(T);
            CopyElements(Front, Back);
            if (Back.Count > 0) { retValue = Back.Pop(); }
            CopyElements(Back, Front);
            return retValue;
        }

        private void CopyElements(Stack<T> source, Stack<T> destination) {
            while (source.Count > 0) {
                var value = source.Pop();
                destination.Push(value);
            }
        }
    }
}
