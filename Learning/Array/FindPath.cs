using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UT_FindPath {
        [TestMethod]
        public void TestMethod1() {
            Assert.AreEqual(true, FindPath.PathExists(0, 1, new int[6]));
        }

        [TestMethod]
        public void TestMethod2() {
            Assert.AreEqual(true, FindPath.PathExists(0, 4, new int[6]));
        }

        [TestMethod]
        public void TestMethod3() {
            Assert.AreEqual(false, FindPath.PathExists(2, 5, new int[6]));
        }

        [TestMethod]
        public void TestMethod4() {
            Assert.AreEqual(false, FindPath.PathExists(4, 0, new int[6]));
        }
    }

    static class FindPath {
        static int[,] matrix = new int[,] { 
            {0, 1, 1, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 1, 0, 0}, 
            {0, 0, 0, 0, 1, 0}, 
            {0, 0, 1, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 0} };
        internal static bool PathExists(int source, int destination, int[] visited) {
            var exists = false;
            if (source != destination) {
                for (var column = 0; column < 6; column++) {
                    if (matrix[source, column] == 1 && visited[column] != 1) {
                        visited[column] = 1;
                        if (PathExists(column, destination, visited)) {
                            exists = true;
                            break;
                        }
                    }
                }
            }
            else {
                exists = true;
            }
            return exists;
        }
    }
}
