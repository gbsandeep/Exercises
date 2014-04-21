using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UTPivotLinkedList {
        [TestMethod]
        public void MiddleItem() {
            
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
    
    class Node {
        public int Data { get; set; }
        public Node NextNode { get; set; }
        public Node(int data, Node nextNode) {
            this.Data = data;
            this.NextNode = nextNode;
        }
    }

    class SinglyLinkedList {
        public Node Head { get; set; }
        public SinglyLinkedList(int[] data) {
            Node tail = null;
            for (var index = 0; index < data.Length; index++) {
                var newNode = new Node(data[index], null);
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

        public void Pivot(int pivotValue) {
            if (this.Head == null) return;
            var pivotNode = GetPivotNode(pivotValue);
            // NO PIVOT FOUND
            if (pivotNode == null) return;

            // PARSE THE LIST AGAIN ?
            var newHead = this.Head;
            var previousNode = this.Head;
            while (previousNode != null && previousNode.NextNode != null) {
                if (previousNode.NextNode.Data >= pivotValue) {
                    MoveRight(previousNode, pivotNode);
                }
                else {
                    MoveLeft(previousNode, pivotNode);
                }
                previousNode = previousNode.NextNode;
            }
            this.Head = newHead;
        }

        private void MoveLeft(Node previousNode, Node pivotNode) {
            var currentNode = previousNode.NextNode;
            var nextNode = currentNode.NextNode;
            currentNode.NextNode = pivotNode.NextNode;
            pivotNode.NextNode = currentNode;
            previousNode.NextNode = currentNode.NextNode;
        }

        private void MoveRight(Node previousNode, Node pivotNode) {
            var currentNode = previousNode.NextNode;
            var nextNode = currentNode.NextNode;
            currentNode.NextNode = pivotNode.NextNode;
            pivotNode.NextNode = currentNode;
            previousNode.NextNode = currentNode.NextNode;
        }

        private Node GetPivotNode(int pivotValue) {
            var pivotNode = this.Head;
            // PARSE THE LIST TO REACH NODE THE PIVOT
            while (pivotNode != null && pivotNode.Data != pivotValue) {
                pivotNode = pivotNode.NextNode;
            }
            return pivotNode;
        }
    }
}
