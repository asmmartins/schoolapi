using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using School.Api.Configuration.Options;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace School.Tests.Unit.Api.Configuration.Options
{
    public class RequestLocalizationOptionsFactoryTests
    {
        [Theory, AutoMoqData]
        public void Create_ReturnsRequestLocalizationOptions(RequestLocalizationOptions options)
        {
            var requestCulture = new RequestCulture("pt-BR");
            var supportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
            var action = RequestLocalizationOptionsFactory.Create();

            action.Invoke(options);

            // Asserts
            options.DefaultRequestCulture.Should().BeEquivalentTo(requestCulture);
            options.SupportedCultures.Should().BeEquivalentTo(supportedCultures);
        }
    }
}
