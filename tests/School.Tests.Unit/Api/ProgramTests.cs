using FluentAssertions;
using School.Api;
using System;
using Xunit;

namespace School.Tests.Unit.Api
{
    public class ProgramTests
    {
        [Fact]
        public void CreateHost_ShouldNotThrow()
        {
            Action action = () => Program.CreateHostBuilder(null).Build();

            // Asserts
            action.Should().NotThrow();
        }
    }
}
