using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Level01.SampleTests
{
    [TestClass()]
    public class FluentAssertions_Sample
    {
        [TestMethod]
        public void StringTest()
        {
            var actual = "ABCDEFGHI";

            actual.Should().StartWith("AB")
                  .And.EndWith("HI")
                  .And.Contain("EF")
                  .And.HaveLength(9);

            var theString = "";
            theString.Should().NotBeNull();

            theString.Should().BeEmpty();

            theString.Should().HaveLength(0);
            theString.Should().BeNullOrWhiteSpace();

            theString = "This is a String";
            theString.Should().Be("This is a String");
            theString.Should().NotBe("This is another String");
            theString.Should().BeEquivalentTo("THIS IS A STRING");

            theString.Should().Contain("is a");
            theString.Should().NotContain("is aa");
            theString.Should().ContainEquivalentOf("THIS IS A STRING");
            theString.Should().NotContainEquivalentOf("HeRe ThE CaSiNg Is IgNoReD As WeLl");

            theString.Should().StartWith("This");
            theString.Should().NotStartWith("That");
            theString.Should().StartWithEquivalent("this");
            theString.Should().NotStartWithEquivalentOf("that");

            theString.Should().EndWith("a String");
            theString.Should().NotEndWith("a Numeric");
            theString.Should().EndWithEquivalent("a string");
            theString.Should().NotEndWithEquivalentOf("a numeric");
        }

        [TestMethod()]
        public void NullableTest()
        {
            short? theShort = null;
            theShort.Should().NotHaveValue();

            int? theInt = 3;
            theInt.Should().HaveValue();

            DateTime? theDate = null;
            theDate.Should().NotHaveValue();
        }

        [TestMethod()]
        public void BooleanTest()
        {
            var otherBoolean = true;

            var theBoolean = false;
            theBoolean.Should().BeFalse("it's set to false");

            theBoolean = true;
            theBoolean.Should().BeTrue();
            theBoolean.Should().Be(otherBoolean);
        }

        [TestMethod()]
        public void NumericTest()
        {
            var theInt = 5;

            theInt.Should().BeGreaterOrEqualTo(5);
            theInt.Should().BeGreaterOrEqualTo(3);
            theInt.Should().BeGreaterThan(4);
            theInt.Should().BeLessOrEqualTo(5);
            theInt.Should().BeLessThan(6);
            theInt.Should().BePositive();
            theInt.Should().Be(5);
            theInt.Should().NotBe(10);
            theInt.Should().BeInRange(1, 10);

            theInt = -8;
            theInt.Should().BeNegative();

            int? nullableInt = 3;
            nullableInt.Should().Be(3);

            var theDouble = 5.1;
            theDouble.Should().BeGreaterThan(5);

            byte theByte = 2;
            theByte.Should().Be(2);
        }

        [TestMethod()]
        public void DateTimeTest()
        {
            var theDatetime = new DateTime(2015, 3, 25, 13, 30, 0);

            theDatetime.Should().BeAfter(new DateTime(2015, 1, 1));
            theDatetime.Should().BeBefore(new DateTime(2016, 1, 1));
            theDatetime.Should().BeOnOrAfter(new DateTime(2015, 3, 25));

            theDatetime.Should().Be(DateTime.Parse("2015/3/25 13:30"));
            theDatetime.Should().NotBe(DateTime.Parse("2015/3/25"));

            theDatetime.Should().HaveDay(25);
            theDatetime.Should().HaveMonth(3);
            theDatetime.Should().HaveYear(2015);
            theDatetime.Should().HaveHour(13);
            theDatetime.Should().HaveMinute(30);
            theDatetime.Should().HaveSecond(0);
        }

        [TestMethod]
        public void CollectionsTest()
        {
            IEnumerable collection = new[] { 1, 2, 5, 8 };

            collection.Should().NotBeEmpty()
                      .And.HaveCount(4)
                      .And.ContainInOrder(new[] { 2, 5 })
                      .And.ContainItemsAssignableTo<int>();

            collection.Should().Equal(new List<int> { 1, 2, 5, 8 });
            collection.Should().Equal(1, 2, 5, 8);
            collection.Should().BeEquivalentTo(new int[] { 8, 2, 1, 5 });
            collection.Should().NotBeEquivalentTo(new int[] { 8, 2, 3, 5 });

            collection.Should().HaveCount(c => c > 3).And.OnlyHaveUniqueItems();
            collection.Should().HaveSameCount(new[] { 6, 2, 0, 5 });

            collection.Should().StartWith(1);
            collection.Should().EndWith(8);

            collection.Should().BeSubsetOf(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, });

            var otherCollection = new int[] { 1, 3, 5, 7 };
            collection.Should().IntersectWith(otherCollection);

            otherCollection = new int[] { 11, 13, 15 };
            collection.Should().NotIntersectWith(otherCollection);

            collection.Should().BeInAscendingOrder();
            collection.Should().NotBeDescendingInOrder();

            collection.Should().NotContain(82);
            collection.Should().NotContainNulls();
        }

        [TestMethod]
        public void DictionaryTest()
        {
            var dictionary1 = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };

            var dictionary2 = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };

            var dictionary3 = new Dictionary<int, string>
            {
                { 3, "Three" },
            };

            dictionary1.Should().ContainKey(1);
            dictionary1.Should().NotContainKey(9);

            dictionary1.Should().Equal(dictionary2);
            dictionary1.Should().NotEqual(dictionary3);
        }
    }
}