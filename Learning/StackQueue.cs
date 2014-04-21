using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UTStack {
        [TestMethod]
        public void TestSinglePush() {
            var stack = new MyStack<int>(null);
            stack.Push(2);
            Assert.AreEqual(2, (int)stack.Peek());
            Assert.AreEqual(2, (int)stack.Pop());
            Assert.IsNull(stack.Peek());
            Assert.AreEqual(0, stack.Pop());
        }

        [TestMethod]
        public void TestMultiplePush() {
            var stack = new MyStack<int>(null);
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, (int)stack.Peek());
            Assert.AreEqual(2, (int)stack.Pop());
            stack.Push(3);
            Assert.AreEqual(3, (int)stack.Peek());
            Assert.AreEqual(3, (int)stack.Pop());
            Assert.AreEqual(1, (int)stack.Peek());
            Assert.AreEqual(1, (int)stack.Pop());
            Assert.IsNull(stack.Peek());
            Assert.AreEqual(0, stack.Pop());
        }

        [TestMethod]
        public void TestMinValue() {
            var minStack = new MyStack<int>(null);
            var stack = new MyStack<int>(minStack);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);
            Assert.AreEqual(1, stack.Min);
        }

        [TestMethod]
        public void TestMinAfterPop() {
            var stack = new MyStack<int>(null);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);
            stack.Pop();
            stack.Pop();
            Assert.AreEqual(2, stack.Min);
        }
    }

    class MyStack<T> where T : IComparable {
        Node<T> top;
        MyStack<T> minStack;
        public MyStack(MyStack<T> minStack) {
            this.minStack = minStack;
        }

        public T Min {
            get { return minStack.Peek(); }
            private set {
                if (minStack.Peek().CompareTo(default(T)) >= 0) {
                    minStack.Push(value);
                }
            }
        }

        public void Push(T data) {
            var newNode = new Node<T>(data, null);
            newNode.NextNode = top;
            top = newNode;
            Min = top.Data;
        }

        public T Pop() {
            if (top != null) {
                var obj = top;
                top = obj.NextNode;
                obj.NextNode = null;
                if (minStack.Peek().CompareTo(obj.Data) == 0) {
                    minStack.Pop();
                }
                return obj.Data;
            }
            return default(T);
        }

        public T Peek() {
            return top != null ? top.Data : default(T);
        }
    }

    class MyQueue<T> where T : IComparable {
        Node<T> first, last;
        public void EnQueue(T data) {
            var newNode = new Node<T>(data, null);
            if (last == null) {
                last = newNode;
                first = last;
            }
            else {
                last.NextNode = newNode;
                last = last.NextNode;
            }
        }

        public Object DeQueue() {
            if (first != null) {
                var data = first.Data;
                first = first.NextNode;
                if (first == null) {
                    last = null;
                }
                return data;
            }
            return null;
        }

        public Object Peek() {
            return first.Data;
        }
    }
}
