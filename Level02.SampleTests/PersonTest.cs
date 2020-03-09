using FluentAssertions;
using Level02.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level02.SampleTests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Test_比對兩個Person型別的物件()
        {
            // 建立兩個 Person 類別的物件，然後分別使用 AreEquals 與 AreSame 做測試
            var person1 = new Person { ID = 1, Name = "1" };
            var person2 = new Person { ID = 1, Name = "1" };

            //Assert.AreEqual(person1, person2);
            //Assert.AreSame(person1, person2);

            Assert.AreNotEqual(person1, person2);
            Assert.AreNotSame(person1, person2);

            person1.Should().BeEquivalentTo(person2);
        }
    }
}