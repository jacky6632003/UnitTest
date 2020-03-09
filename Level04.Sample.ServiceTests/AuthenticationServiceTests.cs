using FluentAssertions;
using Level04.Sample.Repository;
using Level04.Sample.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level04.Sample.ServiceTests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            // arrange
            var profileRepository = new StubProfileRepository();
            var hashTokenService = new StubHashTokenService();

            var account = "kevin";
            var validateCode = "000111";

            var sut = new AuthenticationService(profileRepository, hashTokenService);

            // act
            var actual = sut.IsValid(account, validateCode);

            // assert
            actual.Should().BeTrue();
        }
    }

    public class StubProfileRepository : IProfileRepository
    {
        public string GetPassword(string account)
        {
            return "000";
        }
    }

    public class StubHashTokenService : IHashTokenService
    {
        public string GetRandom(string account)
        {
            return "111";
        }
    }
}