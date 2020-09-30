using FluentValidation;

namespace School.Domain.Shared.ValueObjects.Addresses
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            AddZipCodeRules();
            AddBaseAddressRules();
            AddComplementAddressRules();
            AddNeighborhoodRules();
            AddCityRules();
            AddStateRules();
        }

        private void AddZipCodeRules()
        {
            RuleFor(address => address.ZipCode).NotNull();
            RuleFor(address => address.ZipCode).NotEmpty();
            RuleFor(address => address.ZipCode).Length(8, 8);
            RuleFor(address => address.ZipCode).Matches("^[0-9]+$");
        }

        private void AddBaseAddressRules()
        {
            RuleFor(address => address.BaseAddress).NotNull();
            RuleFor(address => address.BaseAddress).NotEmpty();
            RuleFor(address => address.BaseAddress).MinimumLength(1);
            RuleFor(address => address.BaseAddress).MaximumLength(150);
        }

        private void AddComplementAddressRules()
        {                     
            RuleFor(address => address.ComplementAddress).MaximumLength(50);
        }

        private void AddNeighborhoodRules()
        {
            RuleFor(address => address.Neighborhood).NotNull();
            RuleFor(address => address.Neighborhood).NotEmpty();
            RuleFor(address => address.Neighborhood).MinimumLength(1);
            RuleFor(address => address.Neighborhood).MaximumLength(50);
        }

        private void AddCityRules()
        {
            RuleFor(address => address.City).NotNull();
            RuleFor(address => address.City).NotEmpty();
            RuleFor(address => address.City).MinimumLength(1);
            RuleFor(address => address.City).MaximumLength(50);
        }

        private void AddStateRules()
        {
            RuleFor(address => address.State).NotNull();
            RuleFor(address => address.State).IsInEnum();
        }
    }
}