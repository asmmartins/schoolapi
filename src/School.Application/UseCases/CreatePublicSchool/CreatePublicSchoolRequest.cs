﻿using School.Application.UseCases.Shared.Dtos;

namespace School.Application.UseCases.CreatePublicSchool
{
    public class CreatePublicSchoolRequest
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}