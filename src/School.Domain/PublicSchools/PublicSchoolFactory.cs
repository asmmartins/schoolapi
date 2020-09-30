using School.Domain.Shared;
using School.Domain.Shared.ValueObjects.Addresses;
using System;

namespace School.Domain.PublicSchools
{
    public partial class PublicSchool : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}
