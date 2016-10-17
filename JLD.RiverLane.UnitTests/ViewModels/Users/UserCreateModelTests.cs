using FluentValidation.TestHelper;
using JLD.RiverLane.ViewModels.Users;
using Xunit;

namespace JLD.RiverLane.UnitTests.ViewModels.Users
{
    public class UserCreateModelTests : ValidatorTest<UserCreateModelValidator>
    {
        protected override UserCreateModelValidator Validator
        {
            get
            {
                var mockFactory = CreateFactory(x => x.Users);
                return new UserCreateModelValidator(mockFactory.Object);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Username_NullOrEmpty_Fails(string username)
        {
            Validator.ShouldHaveValidationErrorFor(x => x.Username, username);
        }
    }
}
