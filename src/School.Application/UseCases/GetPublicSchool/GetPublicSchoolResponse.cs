using School.Application.UseCases.Shared.Dtos;

namespace School.Application.UseCases.GetPublicSchool
{
    public class GetPublicSchoolResponse
    {

        public string Inep { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}