using AutoMapper;
using School.Application.UseCases.GetPublicSchools;
using School.Application.UseCases.Shared.Dtos;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.UseCases.GetPublicSchools
{
    public class GetPublicSchoolsUseCase : IGetPublicSchoolsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PublicSchool> _publicSchoolRepository;

        public GetPublicSchoolsUseCase(
            IMapper mapper,
            IRepository<PublicSchool> publicSchoolRepository)
        {
            _mapper = mapper;
            _publicSchoolRepository = publicSchoolRepository;
        }

        public async Task<IEnumerable<PublicSchoolDto>> Execute()
        {
            var publicSchools = await _publicSchoolRepository.GetAll();
            return _mapper.Map<IEnumerable<PublicSchoolDto>>(publicSchools);
        }
    }
}
