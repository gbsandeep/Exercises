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

        [TestMethod]
        public void CommonAncestor() {
            var root = new Node('a', new Node('b', new Node('d', null, null), new Node('e', new Node('f', null, null), null)), new Node('c', null, null));
            var bt = new BinaryTree(root);
            bt.FindCommonAncestor('e', 'c');
            Assert.AreEqual('a', bt.CommonAncestor.Value);
            bt.FindCommonAncestor('e', 'd');
            Assert.AreEqual('b', bt.CommonAncestor.Value);
            bt.FindCommonAncestor('f', 'd');
            Assert.AreEqual('b', bt.CommonAncestor.Value);
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

        public Node CommonAncestor { get; private set; }
        public void FindCommonAncestor(char node1, char node2) {
            CommonAncestor = null;
            RecursiveCommonAncestor(root, node1, node2);
        }
        int RecursiveCommonAncestor(Node node, char node1, char node2) {
            var found = 0;
            if (node == null) return found;
            if (node.Left != null) { found += RecursiveCommonAncestor(node.Left, node1, node2); }
            if (node.Left != null) {found += RecursiveCommonAncestor(node.Right, node1, node2);}
            if (found == 2 && CommonAncestor == null) CommonAncestor = node;
            if (node.Value == node1 || node.Value == node2) found +=1;
            return found;
        }
    }
}
