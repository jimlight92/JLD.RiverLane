using Moq;
using System;
using BaseClasses.Models;
using BaseClasses.Security;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Security;
using Xunit;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.UnitTests.Security
{
    public class RiverLaneFormsAuthenticationProviderTests
    {
        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RiverLaneFormsAuthenticationProvider(null));
        }

        [Fact]
        public void GetAuthenticationResult_UserIsNull_ReturnsInvalidCredentials()
        {
            // Arrange
            UserAccount user = null;
            var sut = GetSut();

            // Act
            var result = sut.GetAuthenticationResultExposed(user);

            // Assert
            Assert.Equal(AuthenticationResult.InvalidCredentials, result);
        }

        private static TestableFormsAuthenticationProvider GetSut()
        {
            return new TestableFormsAuthenticationProvider(new Mock<RiverLaneContext>().Object);
        }

        [Fact]
        public void GetAuthenticationResult_UserIsNotNull_ReturnsSuccess()
        {
            // Arrange
            UserAccount user = new TestableUserAccount();
            var sut = GetSut();

            // Act
            var result = sut.GetAuthenticationResultExposed(user);

            // Assert
            Assert.Equal(AuthenticationResult.Success, result);
        }

        private class TestableFormsAuthenticationProvider : RiverLaneFormsAuthenticationProvider
        {
            public TestableFormsAuthenticationProvider(RiverLaneContext context) : base(context)
            {
            }

            public AuthenticationResult GetAuthenticationResultExposed(UserAccount user)
            {
                return GetAuthenticationResult(user);
            }
        }

        private class TestableUserAccount : UserAccount
        {
        }
    }
}
