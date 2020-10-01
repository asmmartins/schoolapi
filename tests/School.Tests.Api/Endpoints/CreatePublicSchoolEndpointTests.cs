using FluentAssertions;
using School.Application.UseCases.CreateGroup;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.Shared.Dtos;
using School.Domain.Shared.Extensions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Api.Endpoints
{
    public class CreatePublicSchoolEndpointTests
    {
        private readonly ITestHost _testHost;

        public CreatePublicSchoolEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Theory]
        [InlineData("58963214", "Escola Municipal S", "22368957", "Praça IV, 25", "Apt 915", "Centro", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]
        public async Task Should_CreatePublicSchoolController_Returns204(string inep, string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            CreatePublicSchoolRequest createPublicSchoolRequest = new CreatePublicSchoolRequest()
            {
                Inep = inep,
                Name = name,
                Address = new AddressDto()
                {
                    ZipCode = zipCode,
                    BaseAddress = baseAddress,
                    ComplementAddress = complementAddress,
                    Neighborhood = neighborhood,
                    City = city,
                    State = state
                }
            };

            var route = $"public-schools";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createPublicSchoolRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Should_CreateGroupInSchool_Returns204(inep);
        }

        private async Task Should_CreateGroupInSchool_Returns204(string inep)
        {
            CreateGroupRequest createGroupRequest = new CreateGroupRequest()
            {
                Inep = inep,
                Name = "Escola Novo Amanhã",              
            };

            var route = $"public-schools/{inep}/groups";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createGroupRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
