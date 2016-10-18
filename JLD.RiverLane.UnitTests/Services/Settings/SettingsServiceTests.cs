using JLD.RiverLane.Services.Settings;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Settings
{
    public class UsersServiceTests
    {
        private readonly ISettingsService dummyEdit;

        public UsersServiceTests()
        {
            dummyEdit = new Mock<ISettingsService>().Object;
        }

        [Fact]
        public void Constructor_EditIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SettingsService(null));
        }
    }
}
