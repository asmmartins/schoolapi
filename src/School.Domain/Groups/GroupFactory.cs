using FluentValidation;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System;

namespace School.Domain.Groups
{
    public partial class Group : IAggregateRoot
    {
        public static Group Create(string name, PublicSchool publicSchool)
        {
            var Group = new Group()
            {
                Id = Guid.NewGuid(),
                Name = name?.Trim(),
                PublicSchool = publicSchool
            };

            Validate(Group);

            return Group;
        }

        public Group Update(PublicSchool publicSchool)
        {            
            PublicSchool = publicSchool;

            Validate(this);

            return this;
        }

        private static void Validate(Group Group)
        {
            var validator = new GroupValidator();
            validator.ValidateAndThrow(Group);
        }
    }
}
