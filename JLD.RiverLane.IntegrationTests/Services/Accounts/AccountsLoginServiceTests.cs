using BaseClasses.Security;
using JLD.RiverLane.Services.Accounts;
using JLD.RiverLane.ViewModels.Accounts;
using Moq;
using Xunit;

namespace JLD.RiverLane.IntegrationTests.Services.Accounts
{
    public class AccountsLoginServiceTests : DatabaseTest
    {
        [Fact]
        public void Get_Called_ReturnsLoginModel()
        {
            // Arrange
            var sut = new AccountsLoginService(Context, new Mock<IAuthenticationProvider>().Object);

            // Act
            var result = sut.Get();

            // Assert
            Assert.IsType<LoginModel>(result);
        }

        [Theory]
        [InlineData(AuthenticationResult.Success)]
        [InlineData(AuthenticationResult.InvalidCredentials)]
        public void Post_Called_ReturnsResultOfValidateCredentials(AuthenticationResult returned)
        {
            // Arrange
            var mockProvider = new Mock<IAuthenticationProvider>();
            mockProvider.Setup(x => x.ValidateCredentials(It.IsAny<string>(), It.IsAny<string>())).Returns(returned);
            var sut = new AccountsLoginService(Context, mockProvider.Object);

            // Act
            var result = sut.Post(new LoginModel());

            // Assert
            Assert.Equal(returned, result);
        }
    }

}
