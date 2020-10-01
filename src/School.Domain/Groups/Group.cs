
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System;

namespace School.Domain.Groups
{
    public partial class Group : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public PublicSchool PublicSchool { get; private set; }

        protected Group() { }
    }
}