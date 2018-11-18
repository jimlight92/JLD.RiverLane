using JLD.RiverLane.Services.Accounts;
using System;
using BaseClasses.Security;
using Xunit;
using JLD.RiverLane.DataAccess;
using Moq;

namespace JLD.RiverLane.UnitTests.Services.Accounts
{
    public class AccountsLoginServiceTests
    {
        private readonly RiverLaneContext dummyContext;
        private readonly IAuthenticationProvider dummyAuthenticationProvider;

        public AccountsLoginServiceTests()
        {
            dummyContext = new Mock<RiverLaneContext>().Object;
            dummyAuthenticationProvider = new Mock<IAuthenticationProvider>().Object;
        }

        [Fact]
        public void Constructor_ContextIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountsLoginService(null, dummyAuthenticationProvider));
        }

        [Fact]
        public void Constructor_ProviderIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountsLoginService(dummyContext, null));
        }
    }
}
