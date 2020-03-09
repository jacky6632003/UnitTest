using Microsoft.VisualStudio.TestTools.UnitTesting;
using Level05.Sample.Service;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NSubstitute;
using Level05.Sample.Repository;

namespace Level05.Sample.Service.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        private IProfileRepository _profileRepository;
        private IHashTokenService _hashTokenService;
        private ILog _log;

        [TestInitialize]
        public void TestInitialize()
        {
            this._profileRepository = Substitute.For<IProfileRepository>();
            this._hashTokenService = Substitute.For<IHashTokenService>();
            this._log = Substitute.For<ILog>();
        }

        private AuthenticationService GetSystemUnderTest()
        {
            var sut = new AuthenticationService(this._profileRepository, this._hashTokenService, this._log);
            return sut;
        }

        [TestMethod()]
        public void IsValid_驗證為True的情境()
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
            this._log.DidNotReceive().Save(Arg.Any<string>());
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
            this._log.Received(1).Save(Arg.Is<string>(x => x.Contains(account)));
        }
    }
}