using FluentAssertions;
using Xunit;

namespace Becometrica.Math.Multiprecision.Tests;

public class MpFloatTests
{
    [Fact]
    public void Parse()
    {
        MpFloat.Parse("0.125").ToString().Should().Be("0.125");
        MpFloat.Parse("-0.125").ToString().Should().Be("-0.125");
        MpFloat.Parse("125").ToString().Should().Be("0.125E3");
    }

    [Fact]
    public void OneSeventh()
    {
        MpFloat f = new(Precision.Create(128));
        MpRational r = new(1, 7);
        f.Set(r);
        f.ToString().Should().Be("0.1428571428571428571428571428571428571429");
    }
}
