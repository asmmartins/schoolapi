using System.Collections.Generic;

namespace School.Domain.Shared.ValueObjects.Addresses
{
    public partial class Address : ValueObject
    {
        public string ZipCode { get; private set; }
        public string BaseAddress { get; private set; }
        public string ComplementAddress { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public State State { get; private set;  }

        protected override IEnumerable<object> GetEqualsProperties()
        {
            yield return ZipCode;
            yield return BaseAddress;
            yield return ComplementAddress;
            yield return Neighborhood;
            yield return City;
            yield return State;
        }
    }
}
