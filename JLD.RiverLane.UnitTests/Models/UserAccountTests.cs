using JLD.RiverLane.Models;
using System;
using Xunit;
using JLD.RiverLane.Security;
using Moq;

namespace JLD.RiverLane.UnitTests.Models
{
    public class UserAccountTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_UsernameIsNullOrEmpty_Throws(string username)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserAccount(username, "any"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_PasswordIsNullOrEmpty_Throws(string password)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserAccount("any", password));
        }

        private class TestableUserAccount : UserAccount
        {
            protected override IHashProvider GetHashProvider()
            {
                return new Mock<IHashProvider>().Object;
            }
        }
    }
}
