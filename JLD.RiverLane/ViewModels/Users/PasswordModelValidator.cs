using FluentValidation;

namespace JLD.RiverLane.ViewModels.Users
{
    public class PasswordModelValidator : ViewModelValidator<PasswordModel>
    {
        public PasswordModelValidator()
        {
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}.*$")
                .WithMessage("The password entered does not satisfy the password strength criteria. It must be 8 or more characters long and contain: a lowercase character, an uppercase character and a number.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("The Password and Confirm Password fields must match.");
        }
    }
}