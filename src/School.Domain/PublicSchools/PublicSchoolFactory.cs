using FluentValidation;
using School.Domain.Shared;
using School.Domain.Shared.ValueObjects.Addresses;
using System;

namespace School.Domain.PublicSchools
{
    public partial class PublicSchool : IAggregateRoot
    {
        public static PublicSchool Create(string inep, string name, Address address)
        {
            var publicSchool = new PublicSchool()
            {
                Id = Guid.NewGuid(),
                Inep = inep?.Trim(),
                Name = name?.Trim(),
                Address = address
            };

            Validate(publicSchool);

            return publicSchool;
        }

        private static void Validate(PublicSchool publicSchool)
        {
            var validator = new PublicSchoolValidator();
            validator.ValidateAndThrow(publicSchool);
        }
    }
}
