using Level02.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Level02.SampleTests
{
    [TestClass]
    public class CalculateTest
    {
        [TestMethod]
        public void TestPrivateAdd()
        {
            var calculate = new Calculate();
            var method = typeof(Calculate).GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic);
            var expected = 3;

            var actual = method?.Invoke(calculate, new object[] { 1, 2 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInternalStaticAdd()
        {
            var calculate = new Calculate();
            var method = typeof(Calculate).GetMethod("AddStatic", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            var expected = 3;

            var actual = method?.Invoke(calculate, new object[] { 1, 2 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInternalMix()
        {
            // 使用 PrivateObject 類別，測試靜態Internal方法 Mix
            //PrivateObject po = new PrivateObject(new Calculate());

            var calculate = new Calculate();

            var method = typeof(Calculate).GetMethod("Mix", BindingFlags.Instance | BindingFlags.NonPublic);

            var expected = 1;

            var actual = method?.Invoke(calculate, new object[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void TestinternalMix_by_InternalsVisibleTo()
        //{
        //    // 使用 InternalsVisableTo，測試靜態Internal方法 Mix
        //    var sut = new Calculate();
        //    var expected = 1;
        //    var first = 1;
        //    var second = 2;
        //    var third = 3;

        //    var actual = sut.Mix(first, second, third);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}