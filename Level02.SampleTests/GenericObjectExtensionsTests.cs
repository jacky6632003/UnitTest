using FluentAssertions;
using Level02.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level02.SampleTests
{
    [TestClass()]
    public class GenericObjectExtensionsTests
    {
        [TestMethod()]
        [Owner("Kevin")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "Deserialize")]
        public void Deserialize_反序列化JSON字串為CommunityModel()
        {
            // arrange
            var target = "{\"BuildingID\":7712,\"BuildingName\":\"歌林新銳大廈\",\"PublicSquare\":\"\",\"ManageType\":\"\",\"ManageFee\":2800,\"ElevatorShow\":\"2部電梯\"}";

            var expected = new CommunityModel()
            {
                BuildingID = 7712,
                BuildingName = "歌林新銳大廈",
                PublicSquare = "",
                ManageType = "",
                ManageFee = 2800,
                ElevatorShow = "2部電梯"
            };

            // act
            var actual = GenericObjectExtensions.Deserialize<CommunityModel>(target);

            // assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        [Owner("Kevin")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "Serialize")]
        public void SerializeTest_序列化()
        {
            // arrange
            var target = new CommunityModel()
            {
                BuildingID = 7712,
                BuildingName = "歌林新銳大廈",
                PublicSquare = "",
                ManageType = "",
                ManageFee = 2800,
                ElevatorShow = "2部電梯"
            };

            var expected = "{\"BuildingID\":7712,\"BuildingName\":\"歌林新銳大廈\",\"PublicSquare\":\"\",\"ManageType\":\"\",\"ManageFee\":2800,\"ElevatorShow\":\"2部電梯\"}";

            // act
            var actual = target.Serialize<CommunityModel>();

            // assert
            actual.Should().NotBeNull()
                  .And.NotBeNullOrWhiteSpace()
                  .And.Be(expected)
                  .And.NotBeSameAs(expected);
        }
    }
}