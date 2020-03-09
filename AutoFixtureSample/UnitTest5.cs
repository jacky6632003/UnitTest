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
    public class UnitTest5
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 已在 Person 類別的屬性加上 DataAnnotation Attribute
            // 驗證 AutoFixture 所建立的物件署性值是否複合限制

            var fixture = new Fixture();

            var actual = fixture.Create<Person>();

            actual.Name.Length.Should().Be(10);
            actual.Age.Should().BeInRange(10, 80);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 使用 CreateMany 方法，建立多個物件
            // 指定 Person 的 Age 在 30 ~ 50 之間

            var fixture = new Fixture();

            var random = new Random();

            var actual = fixture.Build<Person>()
                                .With(x => x.Age, random.Next(30, 50))
                                .CreateMany(10);

            // 驗證每個 Person 物件的 Age 都必須在 30 ~ 50 之間
            actual.Select(x => x.Age).ToList()
                  .ForEach(x => x.Should().BeInRange(30, 50));
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 使用 AutoFixture 建立 Person 物件
            // 使用 CreateMany 方法，建立多個物件
            // 指定 Person 的 Age 在 30 ~ 50 之間
            // 指定 CreateTime 在 2019-10-01 ~ 2019-10-31 之間

            var fixture = new Fixture();

            var random = new Random();

            var minDate = new DateTime(2019, 10, 1);
            var maxDate = new DateTime(2019, 10, 31);

            fixture.Customizations.Add(new RandomDateTimeSequenceGenerator(minDate, maxDate));

            var actual = fixture.Build<Person>()
                                .With(x => x.Age, random.Next(30, 50))
                                .CreateMany(10);

            // 驗證每個 Person 物件的 Age 都必須在 30 ~ 50 之間
            actual.Select(x => x.Age).ToList()
                  .ForEach(x => x.Should().BeInRange(30, 50));

            // 驗證每個 Person 物件的 CreateTime 都必須在 2019.10.01 ~ 2019.10.31 之間
            actual.Select(x => x.CreateTime).ToList()
                  .ForEach(x => x.Should().BeOnOrAfter(minDate).And.BeOnOrBefore(maxDate));
        }
    }
}