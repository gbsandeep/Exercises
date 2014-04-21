using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UTReverseString {
        [TestMethod]
        public void NullString() {
            Assert.AreEqual(null, ReverseString.Reverse(null));
        }
        [TestMethod]
        public void EmptyString() {
            Assert.AreEqual(string.Empty, ReverseString.Reverse(string.Empty));
        }
        [TestMethod]
        public void StringWithOddChars() {
            Assert.AreEqual("rac", ReverseString.Reverse("car"));
        }
        [TestMethod]
        public void StringWithEvenChars() {
            Assert.AreEqual("ekib", ReverseString.Reverse("bike"));
        }
    }

    static class ReverseString {
        public static string Reverse(string input) {
            if (input == null || input.Length == 0)
                return input;
            char[] output = input.ToCharArray();
            for (var index = 0; index < (output.Length / 2); index++) {
                var temp = output[index];
                output[index] = output[output.Length - 1 - index];
                output[output.Length - 1 - index] = temp;
            }
            return new string(output);
        }
    }
}
