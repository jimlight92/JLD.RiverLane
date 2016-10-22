using FluentValidation;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Infrastructure.FluentValidation;
using JLD.RiverLane.ViewModels.Addresses;

namespace JLD.RiverLane.ViewModels.Settings
{
    public class SettingsEditModelValidator : ViewModelValidator<SettingsEditModel>
    {
        public SettingsEditModelValidator(IContextFactory factory) : base(factory)
        {
        }

        protected override void SetRules(RiverLaneContext context)
        {
            RuleFor(x => x.ContactEmail)
                .NotEmpty()
                .Length(1, 200);

            RuleFor(x => x.ContactNumber)
                .NotEmpty()
                .Length(1, 30);

            RuleFor(x => x.Address)
                .SetValidator(new AddressModelValidator(context));
        }
    }
}