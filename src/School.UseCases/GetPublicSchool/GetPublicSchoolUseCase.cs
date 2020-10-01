using AutoMapper;
using School.Application.UseCases.GetPublicSchool;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.GetPublicSchool
{
    public class GetPublicSchoolUseCase : IGetPublicSchoolUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PublicSchool> _publicSchoolRepository;

        public GetPublicSchoolUseCase(
            IMapper mapper,
            IRepository<PublicSchool> publicSchoolRepository)
        {
            _mapper = mapper;
            _publicSchoolRepository = publicSchoolRepository;
        }

        public async Task<GetPublicSchoolResponse> Execute(string inep)
        {
            var publicSchool = await GetPublicSchoolByInep(inep);
            return _mapper.Map<GetPublicSchoolResponse>(publicSchool);
        }

        private async Task<PublicSchool> GetPublicSchoolByInep(string inep)
        {
            var publicSchools = await _publicSchoolRepository.GetAll();
            return publicSchools?.FirstOrDefault(ps => ps.Inep == inep?.Trim());
        }
    }
}
