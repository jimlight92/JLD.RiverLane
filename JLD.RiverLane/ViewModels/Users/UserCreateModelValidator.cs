using FluentValidation;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Infrastructure.FluentValidation;

namespace JLD.RiverLane.ViewModels.Users
{
    public class UserCreateModelValidator : ViewModelValidator<UserCreateModel>
    {
        public UserCreateModelValidator(IContextFactory factory) : base(factory)
        {
        }

        protected override void SetRules(RiverLaneContext context)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(1, 50);

            RuleFor(x => x.PasswordDetails)
                .SetValidator(new PasswordModelValidator(context));
        }
    }
}