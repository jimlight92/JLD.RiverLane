using JLD.RiverLane.Services.Accounts;
using Moq;
using System;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Accounts
{
    public class AccountsServiceTests
    {
        private readonly IAccountsLoginService dummyLogin;
        private readonly IAccountsUserService dummyUser;

        public AccountsServiceTests()
        {
            dummyLogin = new Mock<IAccountsLoginService>().Object;
            dummyUser = new Mock<IAccountsUserService>().Object;
        }

        [Fact]
        public void Constructor_UserIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountsService(null, dummyUser));
        }

        [Fact]
        public void Constructor_LoginIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountsService(dummyLogin, null));
        }
    }
}
