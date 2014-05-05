using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Bit {
    [TestClass]
    public class UTBit {
        [TestMethod]
        public void Get() {
            Assert.AreEqual(true, Bit.Get(13, 3));
            Assert.AreEqual(false, Bit.Get(13, 4));
        }

        [TestMethod]
        public void Set() {
            Assert.AreEqual(13, Bit.Set(13, 3));
            Assert.AreEqual(29, Bit.Set(13, 4));
        }

        [TestMethod]
        public void Clear() {
            Assert.AreEqual(21, Bit.Clear(29, 3));
            Assert.AreEqual(21, Bit.Clear(21, 3));
        }

        [TestMethod]
        public void ClearMSBThrough() {
            Assert.AreEqual(5, Bit.ClearMSBThrough(29, 3));
            Assert.AreEqual(1, Bit.ClearMSBThrough(21, 2));
        }

        [TestMethod]
        public void ClearIndexThrough() {
            Assert.AreEqual(24, Bit.ClearIndexThrough(29, 3));
            Assert.AreEqual(20, Bit.ClearIndexThrough(21, 2));
        }

        [TestMethod]
        public void UpdateBit() {
            Assert.AreEqual(61, Bit.UpdateBit(29, 5));
            Assert.AreEqual(29, Bit.UpdateBit(21, 3));
        }

        [TestMethod]
        public void FitMInN() {
            Assert.AreEqual(170, Bit.FitMInN(138, 10, 2, 6));
        }
    }

    public static class Bit {
        public static bool Get(int n, sbyte index) {
            return (n & (1 << index)) != 0;
        }

        public static int Set(int n, sbyte index) {
            return n | (1 << index);
        }

        public static int Clear(int n, sbyte index) {
            return n & ~(1 << index);
        }

        public static int ClearMSBThrough(int n, sbyte index) {
            var mask = (int.MaxValue >> (31-index));
            return n & mask;
        }

        public static int ClearIndexThrough(int n, sbyte index) {
            var mask = (int.MaxValue << index);
            return n & mask;
        }

        public static int UpdateBit(int n, sbyte index) { 
            return n | (1 << index);
        }

        public static int FitMInN(int n, int m, sbyte i, sbyte j) { 
            var adjustedM = m << i;
            var adjustedN = ClearMSBThrough(n, (sbyte)(i + j));
            adjustedN = adjustedN | ClearIndexThrough(n, i);
            return adjustedN | adjustedM;
        }
    }
}
