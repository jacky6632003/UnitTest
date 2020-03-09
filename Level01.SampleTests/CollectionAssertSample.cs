using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level01.SampleTests
{
    [TestClass]
    public class CollectionAssertSample
    {
        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內是否包含特定值()
        {
            // arrange
            var item = 1;
            var actual = new int[] { 1, 3, 5, 7, 9 };

            // assert
            CollectionAssert.Contains(actual, item);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內是否不包含特定值()
        {
            // arrange
            var item = 2;
            var actual = new int[] { 1, 3, 5, 7, 9 };

            // assert
            CollectionAssert.DoesNotContain(actual, item);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內按照順序_每個項目是否相等()
        {
            // arrange
            var expected = new int[] { 1, 3, 5 };
            var actual = new int[] { 1, 3, 5 };

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內按照順序_每個項目是否不相等()
        {
            // arrange
            var expected = new int[] { 1, 3, 5, 7 };
            var actual = new int[] { 7, 5, 3, 1 };

            // assert
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內容是否對等()
        {
            // arrange
            // 兩個集合個數一樣，順序不一樣
            var expected = new int[] { 1, 3, 5, 7 };
            var actual = new int[] { 7, 5, 3, 1 };

            // assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內容是否不對等()
        {
            // arrange
            var expected = new int[] { 2, 4, 6 };
            var actual = new int[] { 1, 3, 5 };

            // assert
            CollectionAssert.AreNotEquivalent(expected, actual);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_是否為子集合()
        {
            // arrange
            var superset = new int[] { 1, 3, 5 };
            var subset = new int[] { 5, 3 };

            // assert
            CollectionAssert.IsSubsetOf(subset, superset);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_是否不為子集合()
        {
            // arrange
            var superset = new int[] { 1, 3, 5 };
            var subset = new int[] { 2, 3 };

            // assert
            CollectionAssert.IsNotSubsetOf(subset, superset);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內項目是否唯一_應為true()
        {
            // arrange
            var actual = new int[] { 1, 3, 5 };

            // assert
            CollectionAssert.AllItemsAreUnique(actual);
        }
    }
}