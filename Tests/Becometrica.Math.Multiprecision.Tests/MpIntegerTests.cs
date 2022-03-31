using FluentAssertions;
using Xunit;

namespace Becometrica.Math.Multiprecision.Tests;

public class MpIntegerTests
{
    [Fact]
    public void Parse()
    {
        // Arrange
        const string expected = "1234567890";

        // Act
        MpInteger a = MpInteger.Parse(expected);

        // Assert
        a.ToInt64().Should().Be(1234567890);
        a.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(-10, -1)]
    [InlineData(10, 1)]
    [InlineData(0, 0)]
    [InlineData(null, 0)]
    public void Sign(int? value, int sign)
    {
        // Arrange
        MpInteger a = value ?? default;

        // Assert
        a.Sign().Should().Be(sign);
    }

    [Theory]
    [InlineData(-10, false, true)]
    [InlineData(10, false, true)]
    [InlineData(0, false, true)]
    [InlineData(-7, true, false)]
    [InlineData(7, true, false)]
    [InlineData(null, false, true)]
    public void OddAndEven(int? value, bool isOdd, bool isEven)
    {
        // Arrange
        MpInteger a = value ?? default;

        // Assert
        a.IsOdd().Should().Be(isOdd);
        a.IsEven().Should().Be(isEven);
    }

    [Fact]
    public void CompareWithUInt32()
    {
        // Arrange
        MpInteger a = 100;
        const uint b = 10;

        // Act
        bool result = a > b;

        // Assert
        result.Should().BeTrue();
    }
}
