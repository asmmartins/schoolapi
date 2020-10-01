using AutoMapper;
using School.Application.UseCases.GetPublicSchool;
using School.Application.UseCases.Shared.Dtos;
using School.Domain.Groups;
using School.Domain.PublicSchools;
using School.Domain.Shared.ValueObjects.Addresses;

namespace School.Infra.Ioc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreatePublicSchoolMap();
            CreateAddressMap();
            CreateGroupMap();
        }

        private void CreateAddressMap()
        {
            CreateMap<Address, AddressDto>();
        }

        private void CreatePublicSchoolMap()
        {
            CreateMap<PublicSchool, GetPublicSchoolResponse>();

            CreateMap<PublicSchool, PublicSchoolDto>();                
        }

        private void CreateGroupMap()
        {
            CreateMap<Group, GroupDto>();
        }
    }
}
