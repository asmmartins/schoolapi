using FluentAssertions;
using Newtonsoft.Json;
using School.Application.UseCases.ObterTotalEventosSensor;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Api.Endpoints
{
    public class ObterTotalEventosSensorEndpointTests
    {
        private readonly ITestHost _testHost;

        public ObterTotalEventosSensorEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Fact]
        public async Task Shouldnot_ObterTotalEventosSensorPorRegiao_Returns404NotFound()
        {
            var route = $"sensores";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<TotalEventosSensorResponse>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            content.Should().BeNullOrEmpty();
        }
    }
}