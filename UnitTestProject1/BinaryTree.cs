using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UTBinaryTree {
        [TestMethod]
        public void TestMethod1() {
        }
    }

    class BinaryTreeNode : IComparable<BinaryTreeNode> {
        public BinaryTreeNode() {

        }

        public int CompareTo(BinaryTreeNode other) {
            throw new NotImplementedException();
        }
    }

    class BinaryTree : IComparable<BinaryTree> {

        public int CompareTo(BinaryTree other) {
            throw new NotImplementedException();
        }
    }
}
