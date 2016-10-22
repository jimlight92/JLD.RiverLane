using FluentValidation;
using JLD.RiverLane.DataAccess;

namespace JLD.RiverLane.ViewModels.Addresses
{
    public class AddressModelValidator : ViewModelValidator<AddressModel>
    {
        public AddressModelValidator(RiverLaneContext context) : base(context)
        {
        }

        protected override void SetRules(RiverLaneContext context)
        {
            RuleFor(x => x.HouseName)
                .Must((model, property) => BePresentIfNothingElseIs(model)).WithMessage("You must specify at least one address field")
                .Length(1, 50);

            RuleFor(x => x.Street)
                .Must((model, property) => BePresentIfNothingElseIs(model)).WithMessage("You must specify at least one address field")
                .Length(1, 50);

            RuleFor(x => x.Town)
                .Must((model, property) => BePresentIfNothingElseIs(model)).WithMessage("You must specify at least one address field")
                .Length(1, 50);

            RuleFor(x => x.City)
                .Must((model, property) => BePresentIfNothingElseIs(model)).WithMessage("You must specify at least one address field")
                .Length(1, 50);

            RuleFor(x => x.Postcode)
                .Must((model, property) => BePresentIfNothingElseIs(model)).WithMessage("You must specify at least one address field")
                .Length(1, 10);

        }

        private bool BePresentIfNothingElseIs(AddressModel model)
        {
            return !string.IsNullOrEmpty(model.HouseName) ||
                   !string.IsNullOrEmpty(model.Street) ||
                   !string.IsNullOrEmpty(model.Town) ||
                   !string.IsNullOrEmpty(model.City) ||
                   !string.IsNullOrEmpty(model.Postcode);
        }
    }
}