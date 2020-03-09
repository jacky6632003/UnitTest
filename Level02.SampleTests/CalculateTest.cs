using Level02.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level02.SampleTests
{
    [TestClass]
    public class CalculateTest
    {
        [TestMethod]
        public void TestPrivateAdd()
        {
            // 使用 PrivateObject 類別，測試私有方法 Add
            PrivateObject po = new PrivateObject(new Calculate());

            var expected = 3;

            var actual = po.Invoke("Add", 1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInternalStaticAdd()
        {
            // 使用 PrivateType 類別，測試靜態Internal方法 AddStatic
            PrivateType po = new PrivateType(typeof(Calculate));

            var expected = 3;

            var actual = po.InvokeStatic("AddStatic", 1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInternalMix()
        {
            // 使用 PrivateObject 類別，測試靜態Internal方法 Mix
            PrivateObject po = new PrivateObject(new Calculate());

            var expected = 1;

            var actual = po.Invoke("Mix", 1, 2, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestinternalMix_by_InternalsVisibleTo()
        {
            // 使用 InternalsVisableTo，測試靜態Internal方法 Mix
            var sut = new Calculate();
            var expected = 1;
            var first = 1;
            var second = 2;
            var third = 3;

            var actual = sut.Mix(first, second, third);

            Assert.AreEqual(expected, actual);
        }
    }
}