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
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Create 方法

            var fixture = new Fixture();

            var actual = fixture.Create<MyClass>();

            actual.Should().NotBeNull()
                  .And.BeOfType<MyClass>();
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Create 方法
            // 設定 Inject 給予預設值

            var fixture = new Fixture();
            fixture.Inject("test");

            var actual = fixture.Create<MyClass>();

            actual.Name.Should().StartWith("test");
            actual.Orders.Select(x => x.Name).All(x => x.StartsWith("test")).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 OmitAutoProperties

            var expected = new MyClass();

            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .OmitAutoProperties()
                                .Create();

            actual.Name.Should().BeNullOrEmpty();
            actual.Age.Should().Be(0);
            actual.Orders.Any().Should().BeFalse();
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 MyClass 類別的物件
            // 使用 Build 方法以及 Without 和 With

            var expected = new MyClass();

            var fixture = new Fixture();

            var actual = fixture.Build<MyClass>()
                                .With(x => x.Name, "evertrust")
                                .Without(x => x.Age)
                                .Create();

            actual.Name.Should().Be("evertrust");
            actual.Age.Should().Be(0);
        }
    }
}