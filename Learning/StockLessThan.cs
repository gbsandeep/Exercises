using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1 {
    [TestClass]
    public class UT_StockLessThan {
        [TestMethod]
        public void TestMethod1() {
            ArrayEqual(new []{ 0,1,2,3,2,0}, StockLessThan.CalculateStock(new []{2,4,6,9,5,1} ));
        }
        [TestMethod]
        public void TestMethod2() {
            ArrayEqual(new[] { 0, 1, 2 }, StockLessThan.CalculateStock(new[] { 2, 4, 6 }));
            //Assert.AreEqual(new[] { 0, 1, 2 }, StockPrice.CalculateStock(new[] { 2, 4, 6}));
        }

        void ArrayEqual(int[] arr1, int[] arr2) {
            var query = arr1.Where((b, i) => b == arr2[i]);
            Assert.AreEqual(arr1.Length, query.Count());
        }
    }

    static class StockLessThan { 
        internal static int[] CalculateStock(int [] input){
            int[] lesser = new int[input.Length];
            for (int index = 0; index < input.Length; index++) {
                int lessIndex = index - 1;
                for (; lessIndex >= 0; lessIndex--) {
                    if (input[lessIndex] <= input[index]) {
                        lesser[index] = lesser[lessIndex] + 1;
                        break;
                    }
                }
                if (lessIndex < 0) {
                    lesser[index] = 0;
                }
            }
            return lesser;
        }
    }
}
