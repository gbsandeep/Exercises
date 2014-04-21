using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Learning {
    [TestClass]
    public class UTTowersOfHanoi {
        [TestMethod]
        public void TestMethod1() {
            var toh = new TowersOfHanoi<char>("abc".ToCharArray());
            toh.Move();
        }

        [TestMethod]
        public void SimpleToH() {
            SimpleTowersOfHanoi.PlayRecursiveToH("Source", "Inter", "Dest", 3);
        }
    }


    public class TowersOfHanoi<T> {
        StackWithName<T> tower1, tower2, tower3;
        int size;

        class StackWithName<Type> : Stack<Type> {
            public string Name { get; private set; }
            public StackWithName(string name    ) {
                this.Name = name;
            }
        }
        
        public TowersOfHanoi(T[] initialValues) {
            tower1 = new StackWithName<T>("Source");
            this.size = initialValues.Length;
            foreach (var value in initialValues) {
                tower1.Push(value);
            }
            tower2 = new StackWithName<T>("Inter");
            tower3 = new StackWithName<T>("Dest");
        }

        public void Move() {
            MainMoveAll(tower1, tower2, tower3, size);
        }

        void MainMoveAll(StackWithName<T> source, StackWithName<T> intermediate, StackWithName<T> destination, int count) {
            if (count > 1) {
                MainMoveAll(source, destination, intermediate, count - 1);
            }
            var last = source.Pop();
            destination.Push(last);
            Console.WriteLine("Moving peg {0} from {1} to {2}", last.ToString(), source.Name, destination.Name);
            if (count > 1) {
                MainMoveAll(intermediate, source, destination, count - 1);
            }
        }
    }

    public static class SimpleTowersOfHanoi {
        public static void PlayRecursiveToH(string source, string intermediate, string destination, int count) {
            if (count > 1) {
                PlayRecursiveToH(source, destination, intermediate, count - 1);
            }
            Console.WriteLine("Moving a peg from {0} to {1}", source, destination);
            if (count > 1) {
                PlayRecursiveToH(intermediate, source, destination, count - 1);
            }
        }
    }
}