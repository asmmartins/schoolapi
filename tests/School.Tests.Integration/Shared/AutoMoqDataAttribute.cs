using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace School.Tests.Integration
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new CompositeCustomization(new AutoMoqCustomization(), new SupportMutableValueTypesCustomization())))
        {
        }
    }
}