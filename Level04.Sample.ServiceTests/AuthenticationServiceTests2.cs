using FluentAssertions;
using Level04.Sample.Repository;
using Level04.Sample.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.ServiceTests
{
    [TestClass()]
    public class AuthenticationServiceTests2
    {
        private IProfileRepository _profileRepository;

        private IHashTokenService _hashTokenService;

        [TestInitialize]
        public void TestInitialize()
        {
            this._profileRepository = Substitute.For<IProfileRepository>();
            this._hashTokenService = Substitute.For<IHashTokenService>();
        }

        private AuthenticationService GetSystemUnderTest()
        {
            var sut = new AuthenticationService(this._profileRepository, this._hashTokenService);
            return sut;
        }

        [TestMethod()]
        public void IsValidTest()
        {
            // arrange
            var account = "kevin";
            var validateCode = "000111";

            this._profileRepository.GetPassword(account).Returns("000");
            this._hashTokenService.GetRandom(account).Returns("111");

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.IsValid(account, validateCode);

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        public void IsValid_驗證為False的情境()
        {
            // arrange
            var account = "kevin";
            var validateCode = "000222";

            this._profileRepository.GetPassword(account).Returns("000");
            this._hashTokenService.GetRandom(account).Returns("111");

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.IsValid(account, validateCode);

            // assert
            actual.Should().BeFalse();
        }
    }
}