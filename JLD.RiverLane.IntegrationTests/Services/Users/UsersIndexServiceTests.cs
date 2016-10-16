using JLD.RiverLane.Services.Users;
using System.Linq;
using Xunit;

namespace JLD.RiverLane.IntegrationTests.Services.Users
{
    public class UsersIndexServiceTests : DatabaseTest
    {

        [Fact]
        public void Get_UserExists_ReturnsUserInList()
        {
            // Arrange
            var user = ModelFactory.User("username");
            Context.Users.Add(user);
            Context.SaveChanges();

            var sut = GetSut();

            // Act
            var result = sut.Get();

            // Assert
            Assert.Equal("username", result.Users.Single().Username);
        }

        private UsersIndexService GetSut()
        {
            return new UsersIndexService(Context, Mapper);
        }
    }
}
