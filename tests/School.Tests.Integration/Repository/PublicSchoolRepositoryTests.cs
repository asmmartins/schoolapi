using FluentAssertions;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.Repository
{
    public class PublicSchoolRepositoryTests
    {
        private readonly IRepository<PublicSchool> _publicSchoolRepository;

        public PublicSchoolRepositoryTests(IRepository<PublicSchool> publicSchoolRepository)
        {
            _publicSchoolRepository = publicSchoolRepository;
        }

        [Theory]
        [InlineData("13088575", "Escola Municipal Piox", "22763040", "Praça IV, 25", "Apt 915", "Centro", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]        
        public async Task Should_SaveAndGetAllPublicSchoolInDbContext(string inep, string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            var address = Domain.Shared.ValueObjects.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);
            var publicSchool = PublicSchool.Create(inep, name, address);
            
            await _publicSchoolRepository.Save(publicSchool);
            var eventosSensores = _publicSchoolRepository.GetAll();

            eventosSensores.Should().NotBeNull();
        }
    }
}