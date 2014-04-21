using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UT_StringFromCharMatrix {
        [TestMethod]
        public void TestMethod1() {
            //Assert.AreEqual(true, StringFromCharMatrix.StringCanBeFormed("follow".ToCharArray()));
        }

        [TestMethod]
        public void TestMethod2() {
            Assert.AreEqual(false, StringFromCharMatrix.StringCanBeFormed("fawk".ToCharArray()));
        }

        [TestMethod]
        public void TestMethod3() {
            Assert.AreEqual(false, StringFromCharMatrix.StringCanBeFormed("bar".ToCharArray()));
        }
    }

    static class StringFromCharMatrix {
        internal static bool StringCanBeFormed(char[] input) {
            int MAXROW = 3, MAXCOLUMN = 4;
            bool found = true;
            var matrix = new char[][] { 
                new char[]{ 'o', 'f', 'a', 's' },
                new char[]{ 'l', 'l', 'q', 'w' },
                new char[]{ 'z', 'o', 'w', 'k' }
            };
            for (int row = 0; row < MAXROW; row++) {
                for (int column = 0; column < MAXCOLUMN; column++) {
                    if (matrix[row][column] == input[0]) {
                        // start path
                    }
                    else {
                        found = false;
                    }
                }
            }
            return found;
        }


    }
}
