using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Livecode.Tests.Fixtures;

public class AutoFixtureAttribute : AutoDataAttribute
{
    public AutoFixtureAttribute() : base(() =>
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        return fixture;
    })
    { }
}
