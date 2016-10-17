using JLD.RiverLane.Services.Users;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Users
{
    public class UsersServiceTests
    {
        private readonly IUsersIndexService dummyIndex;
        private readonly IUserCreateService dummyCreate;

        public UsersServiceTests()
        {
            dummyIndex = new Mock<IUsersIndexService>().Object;
            dummyCreate = new Mock<IUserCreateService>().Object;
        }

        [Fact]
        public void Constructor_IndexIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersService(null, dummyCreate));
        }

        [Fact]
        public void Constructor_CreateIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersService(dummyIndex, null));
        }
    }
}
