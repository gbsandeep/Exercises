using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Learning.StackQueue {
    [TestClass]
    public class UTSortWithStack {
        [TestMethod]
        public void TestMethod1() {
            var sortWithStack = new SortWithStack<int>(new int[] { 2, 4, 1, 3});
            sortWithStack.Sort();
        }
    }

    public class SortWithStack<T> where T : IComparable<T> {
        Stack<T> main;
        Stack<T> temp;
        public SortWithStack(T[] data) {
            main = new Stack<T>();
            foreach (var value in data) {
                main.Push(value);
            }
        }

        public void Sort() {
            if (main == null || main.Count <= 1) return;
            if (temp == null && main.Count > 1) {
                temp = new Stack<T>();
            }
            var notSorted = true;
            do {
                notSorted = SingleSort(main, temp);
                SwapStacks(main, temp);
            }
            while (notSorted);
            if (main.Count == 0) SwapStacks(main, temp);
        }

        void SwapStacks(Stack<T> t1, Stack<T> t2) {
            var t = t1;
            t1 = t2;
            t2 = t;
        }

        bool SingleSort(Stack<T> t1, Stack<T> t2) {
            bool notSorted = false;
            while (t1.Count > 0) {
                var val1 = t1.Pop();
                notSorted |= PopAndPushTop(t2, val1);
            }
            return notSorted;
        }

        bool PopAndPushTop(Stack<T> stack, T element) {
            bool swap = false;
            var top = default(T);
            if (stack.Count > 0) {
                if(stack.Peek() 
                top = stack.Pop();
            }

            return swap;
        }
    }
}
