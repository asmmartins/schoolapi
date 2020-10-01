using FluentAssertions;
using School.Domain.Groups;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.Repository
{
    public class GroupRepositoryTests
    {
        private readonly IRepository<Group> _groupRepository;

        public GroupRepositoryTests(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [Theory]
        [InlineData("Turma 3", "UERJ", "22763040", "Praça IV, 25", "Lote 10", "Maracanã", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]        
        public async Task Should_SaveAndGetAllGroupInDbContext(string name, string namePublicSchool, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            var address = Domain.Shared.ValueObjects.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);
            var publicSchool = PublicSchool.Create(namePublicSchool, address);
            var group = Group.Create(name, publicSchool);
            
            await _groupRepository.Save(group);
            var eventosSensores = _groupRepository.GetAll();

            eventosSensores.Should().NotBeNull();
        }
    }
}
