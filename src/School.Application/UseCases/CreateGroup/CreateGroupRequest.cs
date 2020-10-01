using System;

namespace School.Application.UseCases.CreateGroup
{
    public class CreateGroupRequest
    {
        public string Name { get; set; }
        public Guid PublicSchoolId { get; set; }
    }
}