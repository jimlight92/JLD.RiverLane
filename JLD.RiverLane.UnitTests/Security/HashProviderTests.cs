using JLD.RiverLane.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JLD.RiverLane.UnitTests.Security
{
    public class HashProviderTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GenerateHashAndSalt_PasswordIsNullOrEmpty_Throws(string password)
        {
            // Arrange
            var sut = GetSut();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.GenerateHashAndSalt(password));
        }

        private static IHashProvider GetSut()
        {
            return new HashProvider();
        }

        [Fact]
        public void GenerateHashAndSalt_PasswordProvided_ReturnsCorrectHash()
        {
            // Arrange
            var password = "The quick brown fox jumped over the lazy dog";
            var salt = "salt";
            var sut = GetSut(salt);

            // Act
            var result = sut.GenerateHashAndSalt(password);

            // Assert
            Assert.Equal("4efT11FKAqwKicBcmDSKY4C290Im5RJE61yqA1nOBvo=", result.Hash);
            Assert.Equal("c2FsdA==", result.Salt);
        }

        private static IHashProvider GetSut(string saltToUse)
        {
            return new TestableHashProvider(saltToUse);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GenerateHash_PasswordIsNullOrEmpty_Throws(string password)
        {
            // Arrange
            var sut = new HashProvider();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.GenerateHash(password, "any"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GenerateHash_SaltIsNullOrEmpty_Throws(string salt)
        {
            // Arrange
            var sut = new HashProvider();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.GenerateHash("any", salt));
        }

        [Fact]
        public void GenerateHash_PasswordAndSaltProvided_ReturnsCorrectHash()
        {
            // Arrange
            var password = "The quick brown fox jumped over the lazy dog";
            var sut = GetSut();

            // Act
            var result = sut.GenerateHash(password, "c2FsdA==");

            // Assert
            Assert.Equal("4efT11FKAqwKicBcmDSKY4C290Im5RJE61yqA1nOBvo=", result);
        }

        private class TestableHashProvider : HashProvider
        {
            private string saltToUse;

            public TestableHashProvider(string saltToUse)
            {
                this.saltToUse = saltToUse;
            }

            protected override byte[] GenerateSalt(int saltSize)
            {
                return Encoding.UTF8.GetBytes(saltToUse);
            }
        }
    }
}
