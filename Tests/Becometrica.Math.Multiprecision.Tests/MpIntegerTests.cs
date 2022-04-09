using System;
using System.Numerics;
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

    [Theory]
    [InlineData(1, 1, 1, 0)]
    [InlineData(49, 7, 7, 0)]
    [InlineData(49, -7, -7, 0)]
    [InlineData(-49, 7, -7, 0)]
    [InlineData(-49, -7, 7, 0)]
    [InlineData(50, 7, 7, 1)]
    [InlineData(50, -7, -7, 1)]
    [InlineData(-50, 7, -7, -1)]
    [InlineData(-50, -7, 7, -1)]
    public void Division(int dividend, int divisor, int quotient, int remainder)
    {
        // Arrange
        using MpInteger a = dividend;
        using MpInteger b = divisor;
        using MpInteger q = quotient;
        using MpInteger r = remainder;

        // Act & Assert
        (a / b).Should().Be(q);
        (a % b).Should().Be(r);

        (a / divisor).Should().Be(q);
        (a % divisor).Should().Be(r);

        MpInteger.Divide(a, b).Should().Be(q);
        MpInteger.Remainder(a, b).Should().Be(r);

        MpInteger.Divide(a, divisor).Should().Be(q);
        MpInteger.Remainder(a, divisor).Should().Be(r);

        MpInteger.DivRem(a, b).Should().Be((q, r));
        MpInteger.DivRem(a, divisor).Should().Be((q, r));
    }

    [Fact]
    public void DivisionByZero()
    {
        // Arrange
        using MpInteger a = 10;
        using MpInteger b = 0;
        Func<MpInteger> div = () => a / b;
        Func<MpInteger> rem = () => a % b;
        Func<MpInteger> div2 = () => a / 0;
        Func<MpInteger> rem2 = () => a % 0;

        // Act & Assert
        div.Should().Throw<DivideByZeroException>();
        rem.Should().Throw<DivideByZeroException>();
        div2.Should().Throw<DivideByZeroException>();
        rem2.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void ConversionToAndFromBigInteger()
    {
        // Arrange
        BigInteger zero = BigInteger.Zero;
        BigInteger sevenPow100 = BigInteger.Pow(7, 100);
        BigInteger negativeSevenPow100 = -sevenPow100;

        // Act
        MpInteger zeroMp = zero;
        MpInteger sevenPow100Mp = sevenPow100;
        MpInteger negativeSevenPow100Mp = negativeSevenPow100;

        // Assert
        zeroMp.ToBigInteger().Should().Be(zero);
        sevenPow100Mp.ToBigInteger().Should().Be(sevenPow100);
        negativeSevenPow100Mp.ToBigInteger().Should().Be(negativeSevenPow100);
    }

    [Fact]
    public void ConversionFromLong()
    {
        // Act
        MpInteger a = ulong.MaxValue;
        MpInteger b = a + 1;

        // Assert
        a.FitsUInt64().Should().BeTrue();
        a.ToUInt64().Should().Be(ulong.MaxValue);
        b.FitsUInt64().Should().BeFalse();
        b.ToUInt64().Should().Be(0UL);
    }
}
