using FluentValidation;

namespace School.Domain.Shared.ValueObjects.Addresses
{
    public partial class Address : ValueObject
    {
        public static Address Create(string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, State state)
        {
            var address = new Address()
            {
                ZipCode = zipCode,
                BaseAddress = baseAddress,
                ComplementAddress = complementAddress,
                Neighborhood = neighborhood,
                City = city,
                State = state
            };

            Validate(address);

            return address;
        }

        private static void Validate(Address address)
        {
            var validator = new AddressValidator();
            validator.ValidateAndThrow(address);
        }
    }
}
