using FluentAssertions;
using FluentValidation;
using System.Linq;

namespace School.Tests.Integration.Shared
{
    public static class ValidationExceptionExtension
    {
        public static void AssertErrorMessage(this ValidationException ex, string errorMessage)
        {
            ex.Should().NotBeNull();
            ex.Errors.Should().NotBeNullOrEmpty();
            ex.Errors.FirstOrDefault().ErrorMessage.Should().Be(errorMessage);
        }
    }
}
