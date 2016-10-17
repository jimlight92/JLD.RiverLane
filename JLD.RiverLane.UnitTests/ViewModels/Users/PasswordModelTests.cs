using Xunit;
using FluentValidation.TestHelper;
using JLD.RiverLane.ViewModels.Users;

namespace JLD.RiverLane.UnitTests.ViewModels.Users
{
    public class PasswordModelTests : ValidatorTest<PasswordModelValidator>
    {
        protected override PasswordModelValidator Validator
        {
            get
            {
                return new PasswordModelValidator();
            }
        }

        [Theory]
        [InlineData("password")]
        [InlineData("Password")]
        [InlineData("password1")]
        [InlineData("pass")]
        [InlineData("Pass1")]
        public void Password_DoesNotMatchRegex_Fails(string password)
        {
            Validator.ShouldHaveValidationErrorFor(x => x.Password, password);
        }

        [Fact]
        public void Password_MatchesRegex_Passes()
        {
            Validator.ShouldNotHaveValidationErrorFor(x => x.Password, "Password1");
        }

        [Fact]
        public void ConfirmPassword_PasswordsDoNotMatch_Fails()
        {
            Validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, new PasswordModel()
            {
                Password = "Password1",
                ConfirmPassword = "Password2"
            });
        }

        [Fact]
        public void ConfirmPassword_PasswordsMatch_Passes()
        {
            Validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword, new PasswordModel()
            {
                Password = "Password1",
                ConfirmPassword = "Password1"
            });
        }
    }
}
