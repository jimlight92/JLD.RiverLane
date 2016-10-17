using FluentValidation;
using JLD.RiverLane.Infrastructure.FluentValidation;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.ViewModels.Users
{
    public class UserCreateModelValidator : ViewModelValidator<UserCreateModel>
    {
        public UserCreateModelValidator(IContextFactory factory)
        {
            Check.NotNull(factory, nameof(factory));

            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(1, 50);
        }
    }
}