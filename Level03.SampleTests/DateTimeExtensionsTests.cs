using Microsoft.VisualStudio.TestTools.UnitTesting;
using Level03.Sample;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level03.Sample.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestInitialize]
        public void MyInitialize()
        {
            SystemTime.SetToday = () => DateTime.Today;
        }

        [TestCleanup]
        public void MyCleanup()
        {
            SystemTime.SetToday = () => DateTime.Today;
        }

        [TestMethod()]
        public void ToFullTaiwanDateTest()
        {
            // arrange
            var expected = "民國 103 年 5 月 6 日";
            SystemTime.SetToday = () => new DateTime(2014, 5, 6);

            // act
            var actual = SystemTime.Today.ToFullTaiwanDate();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToSimpleTaiwanDateTest()
        {
            // arrange
            var expected = "103/5/6";
            SystemTime.SetToday = () => new DateTime(2014, 5, 6);

            // act
            var actual = SystemTime.Today.ToSimpleTaiwanDate();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}