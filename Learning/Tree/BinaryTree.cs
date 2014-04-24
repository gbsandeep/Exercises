using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UTBinaryTree {
        [TestMethod]
        public void BalancedTree() {
            var root = new Node('a', new Node('b', new Node('d', null, null), new Node('e', null, null)), new Node('c', null, null));
            var bt = new BinaryTree(root);
            Assert.AreEqual(true, bt.IsBalanced());
        }

        [TestMethod]
        public void NonBalancedTree() {
            var root = new Node('a', new Node('b', new Node('d', null, null), new Node('e', new Node('f', null, null), null)), new Node('c', null, null));
            var bt = new BinaryTree(root);
            Assert.AreEqual(false, bt.IsBalanced());
        }
    }

    class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public char Value { get; set; }
        public Node() : this(' ', null, null) {
        }

        public Node(char value, Node left, Node right) {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }

    class BinaryTree {
        Node root;
        public BinaryTree(Node root) {
            this.root = root;
        }
        bool isBalanced { get; set; }
        public bool IsBalanced() {
            isBalanced = true;
            Depth(root);
            return isBalanced;
        }

        private int Depth(Node node) {
            var leftDepth = node.Left == null ? 0 : Depth(node.Left);
            var rightDepth = node.Right == null ? 0 : Depth(node.Right);
            if (Math.Abs(leftDepth - rightDepth) > 1) { isBalanced = false; }
            return Math.Max(leftDepth, rightDepth) + 1;
        }

    }
}
