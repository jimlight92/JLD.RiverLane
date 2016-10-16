using JLD.RiverLane.Services.Users;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Users
{
    public class UserCreateServiceTests
    {
        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserCreateService(null));
        }
    }
}
