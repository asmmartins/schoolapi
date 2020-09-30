using FluentAssertions;
using School.Application.UseCases.CapturarEventoSensor;
using School.Domain.Shared.Extensions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Api.Endpoints
{
    public class CapturarEventoSensorEndpointTests
    {
        private readonly ITestHost _testHost;

        public CapturarEventoSensorEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Theory]
        [InlineData(1597258595, "brasil.sudeste.sensor12", "68409")]
        [InlineData(1597258595, "brasil.centrooeste.sensor59", "SUB635165")]
        public async Task Should_CapturarEventoSensorController_Returns204(long timestamp, string fullTag, string value)
        {
            var capturarEventoSensorRequest = new CapturarEventoSensorRequest() { Timestamp = timestamp, Tag = fullTag, Value = value };

            var route = $"sensores";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = capturarEventoSensorRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
