using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using School.Api;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.Tests.Api
{
    public class TestHost : ITestHost
    {
        private readonly Task<IHost> _host;

        public TestHost(string env = "Testing")
        {
            _host = Host.CreateDefaultBuilder()
                .UseEnvironment(env)
                .ConfigureWebHostDefaults(builder =>
                    builder.UseTestServer().UseStartup<Startup>())
                .StartAsync();
        }

        public async Task<TestServer> GetServerAsync()
        {
            var host = await _host;
            return host.GetTestServer();
        }

        public async Task<HttpClient> GetClientAsync()
        {
            var server = await GetServerAsync();
            return server.CreateClient();
        }
    }
}