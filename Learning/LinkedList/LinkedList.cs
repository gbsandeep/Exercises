using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1 {
    [TestClass]
    public class UTPivotLinkedList {
        [TestMethod]
        public void PivotedList() {
            var compare = (new SinglyLinkedList(new int[] { 1, 2, 3, 4, 5 }).Pivot(3)).CompareTo(new SinglyLinkedList(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(0, compare);
        }

        [TestMethod]
        public void MiddleItemList() {
            var compare = (new SinglyLinkedList(new int[] { 4, 5, 3, 1, 2 }).Pivot(3)).CompareTo(new SinglyLinkedList(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(0, compare);
        }

        [TestMethod]
        public void LastItemList() {
            var compare = (new SinglyLinkedList(new int[] { 3, 2, 1 }).Pivot(3)).CompareTo(new SinglyLinkedList(new int[] { 2, 1, 3 }));
            Assert.AreEqual(0, compare);
        }

        [TestMethod]
        public void SingleItemList() {
            var compare = (new SinglyLinkedList(new int[] { 3 }).Pivot(3)).CompareTo(new SinglyLinkedList(new int[] { 3 }));
            Assert.AreEqual(0, compare);
        }

        [TestMethod]
        public void EmptyList() {
            var compare = (new SinglyLinkedList(new int[] { }).Pivot(3)).CompareTo(new SinglyLinkedList(new int[] { }));
            Assert.AreEqual(0, compare);
        }
    }

    [TestClass]
    public class UTPalindromeLinkedList {
        [TestMethod]
        public void PalindromeWithOddValues() {
            Assert.AreEqual(true, new SinglyLinkedList(new int[] { 1, 2, 1 }).IsPaliandromeUsingStack());
        }

        [TestMethod]
        public void PalindromeWithEvenValues() {
            Assert.AreEqual(true, new SinglyLinkedList(new int[] { 1, 2, 2, 1 }).IsPaliandromeUsingStack());
        }

        [TestMethod]
        public void PalindromeWithNoValues() {
            Assert.AreEqual(true, new SinglyLinkedList(new int[] { }).IsPaliandromeUsingStack());
        }

        [TestMethod]
        public void PalindromeWithOneValues() {
            Assert.AreEqual(true, new SinglyLinkedList(new int[] { 1 }).IsPaliandromeUsingStack());
        }

        [TestMethod]
        public void NonPalindromeWithOddValues() {
            Assert.AreEqual(false, new SinglyLinkedList(new int[] { 1, 2, 3 }).IsPaliandromeUsingStack());
        }

        [TestMethod]
        public void NonPalindromeWithEvenValues() {
            Assert.AreEqual(false, new SinglyLinkedList(new int[] { 1, 2, 3, 4 }).IsPaliandromeUsingStack());
        }
    }

    [TestClass]
    public class UTSinglyLinkedList {
        [TestMethod]
        public void CreateListWithThreeElements() {
            var newList = new SinglyLinkedList(new int[] { 1, 2, 3 });
            Assert.AreEqual(1, newList.Head.Data);
            Assert.AreEqual(2, newList.Head.NextNode.Data);
            Assert.AreEqual(3, newList.Head.NextNode.NextNode.Data);
            Assert.AreEqual(null, newList.Head.NextNode.NextNode.NextNode);
        }

        [TestMethod]
        public void CreateListWithZeroElements() {
            var newList = new SinglyLinkedList(new int[] { });
            Assert.AreEqual(null, newList.Head);
        }

        [TestMethod]
        public void CreateListWithOneElement() {
            var newList = new SinglyLinkedList(new int[] { 1 });
            Assert.AreEqual(1, newList.Head.Data);
            Assert.AreEqual(null, newList.Head.NextNode);
        }
    }

    class Node<T> where T : IComparable {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }
        public Node(T data, Node<T> nextNode) {
            this.Data = data;
            this.NextNode = nextNode;
        }
    }

    class SinglyLinkedList : IComparable<SinglyLinkedList> {
        public Node<int> Head { get; set; }
        public SinglyLinkedList(int[] data) {
            Node<int> tail = null;
            for (var index = 0; index < data.Length; index++) {
                var newNode = new Node<int>(data[index], null);
                if (Head == null) Head = newNode;
                if (tail == null) {
                    tail = Head;
                }
                else {
                    tail.NextNode = newNode;
                    tail = newNode;
                }
            }
        }

        public SinglyLinkedList Pivot(int pivotValue) {
            if (this.Head == null) return this;

            Node<int> lessValueHead = null;
            Node<int> pivotNodeHead = null;
            Node<int> greaterValueHead = null;
            var index = this.Head;

            while (index != null) {
                var temp = index.NextNode;
                index.NextNode = null;
                if (index.Data == pivotValue) {
                    pivotNodeHead = AddNode(pivotNodeHead, index);
                }
                if (index.Data < pivotValue) {
                    lessValueHead = AddNode(lessValueHead, index);
                }
                if (index.Data > pivotValue) {
                    greaterValueHead = AddNode(greaterValueHead, index);
                }
                index = temp;
            }
            // NO PIVOT FOUND
            if (pivotNodeHead == null) return this;
            // COMBINE LESS THAN, PIVOT AND GREATER THAN LISTS
            this.Head = Join(Join(lessValueHead, pivotNodeHead), greaterValueHead);
            return this;
        }

        private static Node<int> Join(Node<int> leftListHead, Node<int> rightListHead) {
            var head = leftListHead;
            var leftTail = GetTail(leftListHead);
            if (leftTail == null) return rightListHead;
            leftTail.NextNode = rightListHead;
            return leftListHead;
        }

        private static Node<int> GetTail(Node<int> head) {
            var previous = head;
            while (previous != null && previous.NextNode != null) {
                previous = previous.NextNode;
            }
            return (previous == null || previous.NextNode == null) ? previous : previous.NextNode;
        }

        private Node<int> AddNode(Node<int> head, Node<int> newNode) {
            var tail = GetTail(head);
            if (tail == null) {
                head = newNode;
            }
            else {
                tail.NextNode = newNode;
            }
            return head;
        }

        private Node<int> GetPivotNode(int pivotValue) {
            var pivotNode = this.Head;
            // PARSE THE LIST TO REACH Node<int> THE PIVOT
            while (pivotNode != null && pivotNode.Data != pivotValue) {
                pivotNode = pivotNode.NextNode;
            }
            return pivotNode;
        }

        public int CompareTo(SinglyLinkedList other) {
            var index1 = this.Head;
            var index2 = other.Head;
            var output = 0;
            while (index1 != null && index2 != null) {
                output = index1.Data - index2.Data;
                if (output != 0) break;
                index1 = index1.NextNode;
                index2 = index2.NextNode;
            }
            if (index1 != null && output == 0) output = index1.Data;
            if (index2 != null && output == 0) output = -index2.Data;
            return output;
        }

        public bool IsPaliandromeUsingStack() {
            var isPaliandrome = true;
            var stack = new MyStack<int>(null);
            var fastPointer = this.Head;
            var slowpointer = this.Head;
            while (fastPointer != null) {
                stack.Push(slowpointer.Data);
                slowpointer = slowpointer.NextNode;
                fastPointer = fastPointer.NextNode == null ? null : fastPointer.NextNode.NextNode;
                if (fastPointer != null && fastPointer.NextNode == null) {
                    slowpointer = slowpointer.NextNode;
                    break;
                }
            }
            while (slowpointer != null) {
                if (slowpointer.Data != stack.Pop()) {
                    isPaliandrome = false;
                    break;
                }
                slowpointer = slowpointer.NextNode;
            }
            return isPaliandrome;
        }
    }
}
