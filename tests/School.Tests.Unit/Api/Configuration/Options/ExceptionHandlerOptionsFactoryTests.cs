using FluentAssertions;
using Microsoft.AspNetCore.Http;
using School.Api.Configuration.Options;
using System.Net.Mime;
using Xunit;

namespace School.Tests.Unit.Api.Configuration.Options
{
    public class ExceptionHandlerOptionsFactoryTests
    {
        [Fact]
        public void Create_ReturnsExceptionHandlerOptions()
        {
            var options = ExceptionHandlerOptionsFactory.Create();

            // Asserts
            options.ExceptionHandler.Should().NotBeNull().And.BeAssignableTo<RequestDelegate>();
        }

        [Theory, AutoMoqData]
        public void ExceptionHandler_ShouldInvokeDelegatedHandle(DefaultHttpContext http)
        {
            var options = ExceptionHandlerOptionsFactory.Create();
            var action = options.ExceptionHandler;

            action.Invoke(http);

            // Asserts
            http.Response.StatusCode.Should().Be(StatusCodes.Status422UnprocessableEntity);
            http.Response.ContentType.Should().Be(MediaTypeNames.Application.Json);
        }
    }
}
