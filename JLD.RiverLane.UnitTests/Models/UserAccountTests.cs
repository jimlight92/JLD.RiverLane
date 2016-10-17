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
            Assert.Throws<ArgumentNullException>(() => new UserAccount(username));
        }

        [Fact]
        public void PasswordIsMatch_PasswordMatches_True()
        {
            // Arrange
            var sut = new TestableUserAccount("password", "password");

            // Act
            var result = sut.PasswordIsMatch("any");

            // Act
            Assert.True(result);
        }

        [Fact]
        public void PasswordIsMatch_PasswordsDoNotMatch_False()
        {
            // Arrange
            var sut = new TestableUserAccount("password1", "password2");

            // Act
            var result = sut.PasswordIsMatch("any");

            // Act
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ChangePassword_PasswordIsNullOrEmpty_Throws(string password)
        {
            // Arrange 
            var sut = new TestableUserAccount();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.ChangePassword(password));
        }

        [Fact]
        public void ChangePassword_PasswordNotNullOrEmpty_Changes()
        {
            // Arrange 
            var sut = new TestableUserAccount("oldHash", "newHash");

            // Act
            sut.ChangePassword("any");

            // Assert
            Assert.Equal("newHash", sut.PasswordHash);
        }

        private class TestableUserAccount : UserAccount
        {
            private string returnedHash;

            public TestableUserAccount()
            {
            }
            
            public TestableUserAccount(string passwordHash, string returnedHash)
            {
                PasswordHash = passwordHash;
                this.returnedHash = returnedHash;
            }

            protected override IHashProvider Provider
            {
                get
                {
                    var provider = new Mock<IHashProvider>();
                    provider.Setup(x => x.GenerateHash(It.IsAny<string>(), It.IsAny<string>())).Returns(returnedHash);
                    provider.Setup(x => x.GenerateHashAndSalt(It.IsAny<string>())).Returns(new HashSaltPair(returnedHash, "salt"));
                    return provider.Object;
                }
            }
        }
    }
}
