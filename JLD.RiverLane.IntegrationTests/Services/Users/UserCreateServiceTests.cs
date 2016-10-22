using JLD.RiverLane.Services.Users;
using JLD.RiverLane.ViewModels.Users;
using System.Linq;
using Xunit;

namespace JLD.RiverLane.IntegrationTests.Services.Users
{
    public class UserCreateServiceTests : DatabaseTest
    {
        [Fact]
        public void Get_CalledWithoutModel_ReturnsNewModel()
        {
            // Arrange
            var sut = GetSut();

            // Act
            var result = sut.Get();

            // Assert
            Assert.IsType<UserCreateModel>(result);
        }

        private UserCreateService GetSut()
        {
            return new UserCreateService(Context);
        }

        [Fact]
        public void Get_CalledWithModel_ReturnsSameModel()
        {
            // Arrange
            var model = new UserCreateModel() { Username = "Username" };
            var sut = GetSut();

            // Act
            var result = sut.Get(model);

            // Assert
            Assert.Equal("Username", result.Username);
        }

        [Fact]
        public void Post_CalledWithModel_AddsUserToDatabase()
        {
            // Arrange
            var model = new UserCreateModel()
            {
                Username = "Username",
                PasswordDetails = new PasswordModel()
                {
                    Password = "Password"
                }
            };
            var sut = GetSut();

            // Act
            var result = sut.Post(model);

            // Assert
            Assert.Equal("Username", Context.Users.Single().Username);
        }
    }
}
