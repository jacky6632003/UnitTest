using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFixtureSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 String

            var fixture = new Fixture();

            var actual = fixture.Create<string>();

            actual.Should().NotBeEmpty();
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 String
            // 使用 Inject 給予預設值

            var fixture = new Fixture();
            fixture.Inject("test");

            var actual = fixture.Create<string>();

            actual.Should().NotBeNullOrEmpty();
            actual.Should().Be("test");
        }
    }
}