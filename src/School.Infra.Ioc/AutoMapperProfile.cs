using AutoMapper;
using School.Application.UseCases.GetPublicSchool;
using School.Application.UseCases.Shared.Dtos;
using School.Domain.PublicSchools;
using School.Domain.Shared.ValueObjects.Addresses;

namespace School.Infra.Ioc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateAddressMap();
            CreatePublicSchoolMap();
        }

        private void CreateAddressMap()
        {
            CreateMap<Address, AddressDto>();
        }

        private void CreatePublicSchoolMap()
        {
            CreateMap<PublicSchool, GetPublicSchoolResponse>();
        }
    }   
}
