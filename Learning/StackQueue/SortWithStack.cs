using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Learning.StackQueue {
    [TestClass]
    public class UTSortWithStack {
        [TestMethod]
        public void TestMethod1() {
            var sortWithStack = new SortWithStack<int>(new int[] { 2, 4, 1, 3});
            sortWithStack.Sort();
            SortAndCompare(sortWithStack, new List<int> { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void ZeroElements() {
            var sortWithStack = new SortWithStack<int>(new int[] { });
            SortAndCompare(sortWithStack, new List<int> { });
        }

        [TestMethod]
        public void OneElement() {
            var sortWithStack = new SortWithStack<int>(new int[] { 1 });
            SortAndCompare(sortWithStack, new List<int> { 1 });
        }

        private static void SortAndCompare(SortWithStack<int> sortWithStack, List<int> expectedSortedList) {
            sortWithStack.Sort();
            var actualSortedList = sortWithStack.ConvertStackToList();
            var expectedDiffActual = expectedSortedList.Except(actualSortedList);
            var actualDiffExpected = actualSortedList.Except(expectedSortedList);
            Assert.AreEqual(0, expectedDiffActual.Count());
            Assert.AreEqual(0, actualDiffExpected.Count());
        }
    }

    public class SortWithStack<T> where T : IComparable<T> {
        Stack<T> initialStack;
        Stack<T> sortedStack;
        public SortWithStack(T[] data) {
            initialStack = new Stack<T>();
            foreach (var value in data) {
                initialStack.Push(value);
            }
        }

        public void Sort() {
            if (initialStack == null || initialStack.Count < 1) return;
            if (sortedStack == null) sortedStack = new Stack<T>();
            while (initialStack.Count > 0) {
                var element = initialStack.Pop();
                var notInserted = true;
                while (notInserted) {
                    if (sortedStack.Count == 0 || sortedStack.Peek().CompareTo(element) >= 0) {
                        sortedStack.Push(element);
                        notInserted = false;
                    }
                    else {
                        var element2 = sortedStack.Pop();
                        initialStack.Push(element2);
                    }
                }
            }
        }

        public List<T> ConvertStackToList() {
            var list = new List<T>();
            while (sortedStack != null && sortedStack.Count > 0) {
                list.Add(sortedStack.Pop());
            }
            for (int index = list.Count - 1; index >= 0; index--) {
                sortedStack.Push(list[index]);
            }
            return list;
        }
    }
}
