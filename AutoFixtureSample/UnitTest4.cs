using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 MyClass 物件
            // 使用 CreateMany 方法，讓物件集合有 5 個物件

            var fixture = new Fixture();

            var collection = fixture.CreateMany<MyClass>(5);

            collection.Should().HaveCount(5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 MyClass 物件
            // 使用 With 方法，讓物件的屬性 Orders 有 3 個 Order 物件

            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                    .With(x => x.Orders, fixture.CreateMany<Order>(3).ToList())
                                    .Create();

            actual.Orders.Should().HaveCount(3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 MyClass 物件
            // 使用 Do 方法，讓物件的屬性 Orders 有 3 個 Order 物件

            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .Do(x => x.Orders.AddRange(fixture.CreateMany<Order>(3)))
                                .Create();

            actual.Orders.Should().HaveCount(3);
        }
    }
}