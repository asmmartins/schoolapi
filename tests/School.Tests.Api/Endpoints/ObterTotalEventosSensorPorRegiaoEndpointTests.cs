using FluentAssertions;
using Newtonsoft.Json;
using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Api.Endpoints
{
    public class ObterTotalEventosSensorPorRegiaoEndpointTests
    {
        private readonly ITestHost _testHost;

        public ObterTotalEventosSensorPorRegiaoEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Fact]
        public async Task Shouldnot_ObterTotalEventosSensorPorRegiao_Returns404NotFound()
        {
            var route = $"sensores-regionais";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<TotalEventosSensorPorRegiaoResponse>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            content.Should().BeNullOrEmpty();
        }
    }
}