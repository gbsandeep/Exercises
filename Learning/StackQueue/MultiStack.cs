using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Learning.StackQueue {
    [TestClass]
    public class UTMultiStack {
        [TestMethod]
        public void PeekSingleStack() {
            var multiStack = new MultiStack<int>(2, new[] {1});
            Assert.AreEqual(1, multiStack.Peek());
            Assert.AreEqual(1, multiStack.StackCount);
        }

        [TestMethod]
        public void MorethanSizePush() {
            var multiStack = new MultiStack<int>(2, new[] { 1, 2 });
            multiStack.Push(3);
            Assert.AreEqual(2, multiStack.StackCount);
            Assert.AreEqual(3, multiStack.Peek());
        }

        [TestMethod]
        public void EqualToSizePush() {
            var multiStack = new MultiStack<int>(2, new[] { 1, 2, 3, 4, 5 });
            multiStack.Push(6);
            Assert.AreEqual(3, multiStack.StackCount);
            Assert.AreEqual(6, multiStack.Peek());
        }

        [TestMethod]
        public void SingleStackPop() {
            var multiStack = new MultiStack<char>(2, "ab".ToCharArray());
            Assert.AreEqual('b', multiStack.Pop());
            Assert.AreEqual('a', multiStack.Peek());
            Assert.AreEqual(1, multiStack.StackCount);
        }
    }

    public class MultiStack<T> {
        List<Stack<T>> stacks = null;
        public int StackCount { get { return stacks.Count; } }
        int size;
        public MultiStack(int size, T[] data) {
            this.size = size;
            this.stacks = new List<Stack<T>>();
            foreach (var d in data) {
                Push(d);
            }
        }

        public void Push(T value) {
            var availableStack = NextAvailableStack();
            availableStack.Push(value);
        }

        private Stack<T> NextAvailableStack() {
            Stack<T> availableStack = null;
            foreach (var stack in stacks) {
                if (stack.Count < this.size) {
                    availableStack = stack;
                    break;
                }
            }
            if (availableStack == null) {
                availableStack = new Stack<T>();
                stacks.Add(availableStack);
            }
            return availableStack;
        }

        public T Peek() {
            var avaialableStack = LastStack();
            return avaialableStack.Peek();
        }

        public T Pop() {
            var avaialableStack = LastStack();
            var value = avaialableStack.Pop();
            RemoveStack(avaialableStack);
            return value;
        }

        private void RemoveStack(Stack<T> stack) {
            if (stack.Count == 0) {
                stacks.Remove(stack);
            }
        }

        private Stack<T> LastStack() {
            Stack<T> lastStack = null;
            foreach (var stack in stacks) {
                if (stack.Count <= size) {
                    lastStack = stack;
                }
            }
            return lastStack;
        }
    }
}
