using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level01.SampleTests
{
    [TestClass()]
    public class CollectionAssertSample_FluentAssertions
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
            actual.Should().Contain(item);
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
            actual.Should().NotContain(item);
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
            actual.Should().Equal(expected); // 注意使用的是 Equal 而不是 Equals
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
            actual.Should().NotEqual(expected);
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
            actual.Should().BeEquivalentTo(expected);
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
            actual.Should().NotBeSameAs(expected);
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
            subset.Should().BeSubsetOf(superset);
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
            subset.Should().NotBeSubsetOf(superset);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("CollectionAssertSample")]
        public void 驗證Collection_集合內項目是否唯一_應為true()
        {
            // arrange
            var actual = new int[] { 1, 3, 5 };

            // assert
            actual.Should().OnlyHaveUniqueItems();
        }

        [TestMethod()]
        [Owner("User_Name")]
        public void 驗證Collection_集合內項目是否為Ascending排序()
        {
            // arrange
            var actual = new int[] { 1, 3, 5, 6, 7, 8, 9 };

            // assert
            actual.Should().BeInAscendingOrder();
        }

        [TestMethod()]
        [Owner("User_Name")]
        public void 驗證Collection_集合內項目是否為Descending排序()
        {
            // arrange
            var actual = new int[] { 10, 8, 5, 4, 3, 2, 1 };

            // assert
            actual.Should().BeInDescendingOrder();
        }

        [TestMethod()]
        public void 驗證Collection_集合項目的數量是否如預期()
        {
            // arrange
            var actual = new int[] { 1, 2, 3, 4, 5 };

            // assert
            actual.Should().HaveCount(5);
        }

        [TestMethod]
        public void 驗證Collecion_兩個集合項目的數量是否相同()
        {
            // arrange
            var actual = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var expected = new int[] { 2, 4, 6, 8, 10, 12, 14, 16 };

            // assert
            actual.Should().HaveSameCount(expected);
        }
    }
}