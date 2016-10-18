using JLD.RiverLane.Models;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Models
{
    public class SettingsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_ContactEmailIsNull_Throws(string contactEmail)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Settings(contactEmail, "any", null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_ContactNumberIsNull_Throws(string contactNumber)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Settings("any", contactNumber, null));
        }

        [Fact]
        public void Constructor_AddressIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Settings("any", "any", null));
        }
    }
}
