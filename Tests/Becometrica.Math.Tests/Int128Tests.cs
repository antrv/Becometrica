using FluentAssertions;
using Xunit;

namespace Becometrica.Math.Tests;

public class Int128Tests
{
    [Theory]
    [InlineData(0uL, 0L, "0")]
    [InlineData(1uL, 0L, "1")]
    [InlineData(ulong.MaxValue, long.MinValue, "-1")]
    [InlineData(10000000000000000000uL, 0, "10000000000000000000")]
    [InlineData(ulong.MaxValue - 10000000000000000000uL + 1, long.MinValue, "-10000000000000000000")]
    public void ConversionToString(ulong low, long high, string expected)
    {
        Int128 v = new(low, high);
        v.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData((sbyte)0, 0UL, 0L)]
    [InlineData((sbyte)1, 1UL, 0L)]
    [InlineData((sbyte)-1, ulong.MaxValue, -1L)]
    [InlineData((sbyte)-2, ulong.MaxValue - 1, -1L)]
    [InlineData((sbyte)-120, ulong.MaxValue - 119, -1L)]
    [InlineData((sbyte)120, 120uL, 0L)]
    [InlineData(sbyte.MinValue, ulong.MaxValue - 127, -1L)]
    [InlineData(sbyte.MaxValue, 127uL, 0L)]
    public void ConversionFromInt8(sbyte value, ulong low, long high)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData((byte)0, 0uL)]
    [InlineData((byte)1, 1uL)]
    [InlineData((byte)120, 120uL)]
    [InlineData(byte.MaxValue, 255uL)]
    public void ConversionFromUInt8(byte value, ulong low)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0L);
    }

    [Theory]
    [InlineData((short)0, 0UL, 0L)]
    [InlineData((short)1, 1UL, 0L)]
    [InlineData((short)-1, ulong.MaxValue, -1L)]
    [InlineData((short)-2, ulong.MaxValue - 1, -1L)]
    [InlineData((short)-120, ulong.MaxValue - 119, -1L)]
    [InlineData((short)120, 120UL, 0L)]
    [InlineData((short)-1200, ulong.MaxValue - 1199, -1L)]
    [InlineData((short)1200, 1200UL, 0L)]
    [InlineData((short)-12000, ulong.MaxValue - 11999, -1L)]
    [InlineData((short)12000, 12000UL, 0L)]
    [InlineData(short.MinValue, ulong.MaxValue - 32767, -1L)]
    [InlineData(short.MaxValue, 32767UL, 0L)]
    public void ConversionFromInt16(short value, ulong low, long high)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData((ushort)0, 0UL)]
    [InlineData((ushort)1, 1UL)]
    [InlineData((ushort)120, 120UL)]
    [InlineData((ushort)1200, 1200UL)]
    [InlineData((ushort)12000, 12000UL)]
    [InlineData(ushort.MaxValue, 65535UL)]
    public void ConversionFromUInt16(ushort value, ulong low)
    {
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0L);
    }

    [Theory]
    [InlineData(0, 0UL, 0L)]
    [InlineData(1, 1UL, 0L)]
    [InlineData(-1, ulong.MaxValue, -1L)]
    [InlineData(-2, ulong.MaxValue - 1, -1L)]
    [InlineData(-120, ulong.MaxValue - 119, -1L)]
    [InlineData(120, 120UL, 0L)]
    [InlineData(-1200, ulong.MaxValue - 1199, -1L)]
    [InlineData(1200, 1200UL, 0L)]
    [InlineData(-12000, ulong.MaxValue - 11999, -1L)]
    [InlineData(12000, 12000UL, 0L)]
    [InlineData(-12000000, ulong.MaxValue - 11999999, -1L)]
    [InlineData(12000000, 12000000UL, 0L)]
    [InlineData(int.MinValue, ulong.MaxValue - int.MaxValue, -1L)]
    [InlineData(int.MaxValue, (ulong)int.MaxValue, 0L)]
    public void ConversionFromInt32(int value, ulong low, long high)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData(0u, 0UL)]
    [InlineData(1u, 1UL)]
    [InlineData(120u, 120UL)]
    [InlineData(1200u, 1200UL)]
    [InlineData(12000u, 12000UL)]
    [InlineData(12000000u, 12000000UL)]
    [InlineData(uint.MaxValue, (ulong)uint.MaxValue)]
    public void ConversionFromUInt32(uint value, ulong low)
    {
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0L);
    }

    [Theory]
    [InlineData(0L, 0UL, 0L)]
    [InlineData(1L, 1UL, 0L)]
    [InlineData(-1L, ulong.MaxValue, -1L)]
    [InlineData(-2L, ulong.MaxValue - 1, -1L)]
    [InlineData(-120L, ulong.MaxValue - 119, -1L)]
    [InlineData(120L, 120UL, 0L)]
    [InlineData(-1200L, ulong.MaxValue - 1199, -1L)]
    [InlineData(1200L, 1200UL, 0L)]
    [InlineData(-12000L, ulong.MaxValue - 11999, -1L)]
    [InlineData(12000L, 12000UL, 0L)]
    [InlineData(-12000000L, ulong.MaxValue - 11999999, -1L)]
    [InlineData(12000000L, 12000000UL, 0L)]
    [InlineData(-12000000000000L, ulong.MaxValue - 11999999999999, -1L)]
    [InlineData(12000000000000L, 12000000000000UL, 0L)]
    [InlineData(long.MinValue, ulong.MaxValue - long.MaxValue, -1L)]
    [InlineData(long.MaxValue, (ulong)long.MaxValue, 0L)]
    public void ConversionFromInt64(long value, ulong low, long high)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData(0uL, 0UL)]
    [InlineData(1uL, 1UL)]
    [InlineData(120uL, 120UL)]
    [InlineData(1200uL, 1200UL)]
    [InlineData(12000uL, 12000UL)]
    [InlineData(12000000uL, 12000000UL)]
    [InlineData(12000000000000uL, 12000000000000UL)]
    [InlineData(ulong.MaxValue, ulong.MaxValue)]
    public void ConversionFromUInt64(ulong value, ulong low)
    {
        Int128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0L);
    }

    [Fact]
    public void Equality()
    {
        new Int128(0, 0).Equals(new Int128(0, 0)).Should().BeTrue();
        new Int128(0x12345678901234, 0x1234567890).Equals(new Int128(0x12345678901234, 0x1234567890)).Should().BeTrue();
        new Int128(0x12345678901234, 0x1234567890).Equals(new Int128(0x12345678901235, 0x1234567890)).Should().BeFalse();
        new Int128(0x12345678901234, 0x1234567890).Equals(new Int128(0x12345678901234, 0x1234567891)).Should().BeFalse();
        new Int128(0x12345678901234, 0x1234567890).Equals(new Int128(0x12345678901235, 0x1234567891)).Should().BeFalse();
    }

    [Fact]
    public void Comparison()
    {
        new Int128(0, 0).CompareTo(new Int128(0, 0)).Should().Be(0);

        new Int128(0x123, 5).CompareTo(new Int128(0x123, 5)).Should().Be(0);
        new Int128(0x123, 5).CompareTo(new Int128(0x123, 6)).Should().Be(-1);
        new Int128(0x123, 5).CompareTo(new Int128(0x123, 4)).Should().Be(1);

        new Int128(0x123, 5).CompareTo(new Int128(0x123, -5)).Should().Be(1);
        new Int128(0x123, 5).CompareTo(new Int128(0x123, -6)).Should().Be(1);
        new Int128(0x123, 5).CompareTo(new Int128(0x123, -4)).Should().Be(1);

        new Int128(0x123, -5).CompareTo(new Int128(0x123, -5)).Should().Be(0);
        new Int128(0x123, -5).CompareTo(new Int128(0x123, -6)).Should().Be(1);
        new Int128(0x123, -5).CompareTo(new Int128(0x123, -4)).Should().Be(-1);

        new Int128(0x123, -5).CompareTo(new Int128(0x123, 5)).Should().Be(-1);
        new Int128(0x123, -5).CompareTo(new Int128(0x123, 6)).Should().Be(-1);
        new Int128(0x123, -5).CompareTo(new Int128(0x123, 4)).Should().Be(-1);

        new Int128(0x123, 5).CompareTo(new Int128(0x123, 5)).Should().Be(0);
        new Int128(0x123, 5).CompareTo(new Int128(0x124, 5)).Should().Be(-1);
        new Int128(0x123, 5).CompareTo(new Int128(0x122, 5)).Should().Be(1);

        new Int128(0x123, -5).CompareTo(new Int128(0x123, -5)).Should().Be(0);
        new Int128(0x123, -5).CompareTo(new Int128(0x124, -5)).Should().Be(-1);
        new Int128(0x123, -5).CompareTo(new Int128(0x122, -5)).Should().Be(1);
    }

    [Fact]
    public void Negation()
    {
        (-new Int128(0x123, -5)).Should().Be(new Int128(ulong.MaxValue - 0x123, 5));
    }
}
