using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Api
{
    public class EnvironmentTests
    {
        [Fact]
        public async Task ShouldStartServer_AsTest()
        {
            var host = new TestHost();
            var server = await host.GetServerAsync();
            var env = (IWebHostEnvironment)server.Services.GetService(typeof(IWebHostEnvironment));

            // Asserts
            env.Should().NotBeNull();
            env.IsEnvironment("Testing").Should().BeTrue();
        }

        [Fact]
        public async Task ShouldStartServer_AsDevelopment()
        {
            var host = new TestHost("Development");
            var server = await host.GetServerAsync();
            var env = (IWebHostEnvironment)server.Services.GetService(typeof(IWebHostEnvironment));

            // Asserts
            env.Should().NotBeNull();
            env.IsDevelopment().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldStartServer_AsStaging()
        {
            var host = new TestHost("Staging");
            var server = await host.GetServerAsync();
            var env = (IWebHostEnvironment)server.Services.GetService(typeof(IWebHostEnvironment));

            // Asserts
            env.Should().NotBeNull();
            env.IsStaging().Should().BeTrue();
        }


        [Fact]
        public async Task ShouldStartServer_AsProduction()
        {
            var host = new TestHost("Production");
            var server = await host.GetServerAsync();
            var env = (IWebHostEnvironment)server.Services.GetService(typeof(IWebHostEnvironment));

            // Asserts
            env.Should().NotBeNull();
            env.IsProduction().Should().BeTrue();
        }
    }
}
