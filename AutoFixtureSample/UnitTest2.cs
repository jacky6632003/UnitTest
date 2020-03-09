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
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 String Collection

            var fixture = new Fixture();

            var collection = fixture.CreateMany<string>();

            collection.Any().Should().BeTrue();
            collection.Count().Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 Inject 給予預設值

            var fixture = new Fixture();
            fixture.Inject("test");

            var collection = fixture.CreateMany<string>();

            collection.Any().Should().BeTrue();
            collection.All(x => x.StartsWith("test")).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 CreateMany 方法的 Count 參數，讓 Collection 裡有 10 個 String

            var fixture = new Fixture();

            var collection = fixture.CreateMany<string>(10);

            collection.Any().Should().BeTrue();
            collection.Should().HaveCount(10);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法

            var collection = new List<string>();

            var fixture = new Fixture();

            fixture.AddManyTo(collection);

            collection.Any().Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod5()
        {
            // 使用 AutoFixture 建立 String Collection
            // 使用 AddManyTo 方法並給予 repeatCount 參數，讓 Collection 裡有 10 個 String

            var collection = new List<string>();

            var fixture = new Fixture();
            fixture.AddManyTo(collection, 10);

            collection.Any().Should().BeTrue();
            collection.Should().HaveCount(10);
        }
    }
}