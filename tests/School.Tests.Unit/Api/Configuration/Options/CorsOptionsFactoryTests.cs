using FluentAssertions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using School.Api.Configuration.Options;
using Xunit;

namespace School.Tests.Unit.Api.Configuration.Options
{
    public class CorsOptionsFactoryTests
    {
        [Theory, AutoMoqData]
        public void Create_ReturnsCorsOptions(CorsOptions options)
        {
            var action = CorsOptionsFactory.Create();

            action.Invoke(options);

            // Asserts
            options.GetPolicy("CorsPolicy").Should().NotBeNull();
        }
    }
}
