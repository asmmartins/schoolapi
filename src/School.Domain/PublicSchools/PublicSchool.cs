using School.Domain.Shared;
using System;

namespace School.Domain.Sensores
{
    public partial class PublicSchool : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }                
    }
}