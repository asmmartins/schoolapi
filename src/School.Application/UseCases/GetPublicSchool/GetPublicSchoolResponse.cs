using School.Application.UseCases.Shared.Dtos;
using System;

namespace School.Application.UseCases.GetPublicSchool
{
    public class GetPublicSchoolResponse
    {
        public Guid Id { get; set; }
        public string Inep { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}