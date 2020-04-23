using System;
using System.Linq;
using NUnit.Framework;
using static FindMaximumTask.ArrayExtension;

namespace FindMaximumTask.Tests
{
    public class ArrayExtensionTests
    {
        private int[] _array;
        private int _max;
        
        [SetUp]
        public void Setup()
        {
            _max = 100_000_000;
            _array = Enumerable.Range(1, _max).ToArray();
        }
        
        [Order(1)]
        [TestCase(new int[] { 0, 50 }, ExpectedResult = 50)]
        [TestCase(new int[] { 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MinValue, 50 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 50)]
        [TestCase(new int[] { 25, 25, 10, 25, 25, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 500)]
        [TestCase(new int[] { -50, -25, -20, -5, -500, -100 }, ExpectedResult = -5)]
        [TestCase(new int[] { -50, -25, -20, 0, -500, -100 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 1, 0, 0, 0, 0 }, ExpectedResult = 1)]
        public int FindMaximumItem_Return_Index_Of_Maximum_Element(int[] array) => FindMaximum(array);

        [Test]
        public void FindMaximum_Throw_ArgumentNullException_If_Array_Is_Null() =>
            Assert.Throws<ArgumentNullException>(() => FindMaximum(null),
                message: "array can not be null.");
        [Test]
        public void FindMaximum_Throw_ArgumentException_Array_Is_Empty() =>
            Assert.Throws<ArgumentException>(() => FindMaximum(new int[] { }),
                message: "array can not be empty.");
        
        [Test]
        [Order(0)]
        [Timeout(10_000)]
        public void FindMaximum_Test_For_Large_Array()
        {
            int expected = _max;
            int actual = FindMaximum(_array);
            Assert.AreEqual(expected, actual);
        }
    }
}