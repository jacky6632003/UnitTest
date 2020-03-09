using Microsoft.VisualStudio.TestTools.UnitTesting;
using Level03.Sample;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level03.Sample.Tests
{
    [TestClass()]
    public class HolidayTests
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
        public void IsTodayXmas_今天不是耶誕節()
        {
            // arrange
            var expected = "Today is not Xmas";
            Holiday sut = new Holiday();

            // act
            var actual = sut.IsTodayXmas();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsTodayXmas_今天是耶誕節()
        {
            // arrange
            var expected = "Merry Xmas!!";
            Holiday sut = new Holiday();

            SystemTime.SetToday = () => new DateTime(2014, 12, 25);

            // act
            var actual = sut.IsTodayXmas();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}