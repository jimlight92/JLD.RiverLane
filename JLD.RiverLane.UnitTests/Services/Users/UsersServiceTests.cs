using JLD.RiverLane.Services.Users;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Users
{
    public class UsersServiceTests
    {
        private readonly IUsersIndexService dummyIndex;

        public UsersServiceTests()
        {
            dummyIndex = new Mock<IUsersIndexService>().Object;
        }

        [Fact]
        public void Constructor_IndexIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersService(null));
        }
    }
}
