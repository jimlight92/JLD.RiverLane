using JLD.RiverLane.Services.Accounts;
using Moq;
using System;
using BaseClasses.Security;
using Xunit;

namespace JLD.RiverLane.UnitTests.Services.Accounts
{
    public class AccountsUserServiceTests
    {
        private readonly ITokenProvider dummyTokenProvider;

        public AccountsUserServiceTests()
        {
            dummyTokenProvider = new Mock<ITokenProvider>().Object;
        }
        
        [Fact]
        public void Constructor_ProviderIsNull_Throws()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountsUserService(null));
        }
    }
}
