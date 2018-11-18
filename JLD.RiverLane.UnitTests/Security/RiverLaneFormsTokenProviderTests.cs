using Moq;
using System;
using System.Security.Principal;
using BaseClasses.Models;
using BaseClasses.Security;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Security;
using Xunit;

namespace JLD.RiverLane.UnitTests.Security
{
    public class RiverLaneFormsTokenProviderTests
    {
        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RiverLaneFormsTokenProvider(null));
        }

        [Fact]
        public void GetPrincipalFromUserAccount_UserIsNull_Throws()
        {
            // Arrange
            UserAccount user = null;
            var sut = GetSut();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.GetPrincipalFromUserAccountExposed(user));
        }

        private static TestableFormsTokenProvider GetSut()
        {
            return new TestableFormsTokenProvider(new Mock<RiverLaneContext>().Object);
        }

        [Fact]
        public void GetPrincipalFromUserAccount_UserIsUserAccount_ReturnsRipaPrincipal()
        {
            // Arrange
            UserAccount user = new UserAccount("name");
            var sut = GetSut();

            // Act
            var result = sut.GetPrincipalFromUserAccountExposed(user);

            // Assert
            Assert.True(result is JLDPrincipal);
        }

        private class TestableFormsTokenProvider : RiverLaneFormsTokenProvider
        {
            public TestableFormsTokenProvider(RiverLaneContext context) : base(context)
            {
            }

            public IPrincipal GetPrincipalFromUserAccountExposed(UserAccount user)
            {
                return GetPrincipalFromUserAccount(user);
            }
        }
    }
}
