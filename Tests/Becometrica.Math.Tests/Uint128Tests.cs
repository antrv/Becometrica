using FluentAssertions;
using Xunit;

namespace Becometrica.Math.Tests;

public class Uint128Tests
{
    [Theory]
    [InlineData((sbyte)0, 0uL, 0uL)]
    [InlineData((sbyte)1, 1uL, 0uL)]
    [InlineData((sbyte)-1, ulong.MaxValue, ulong.MaxValue)]
    [InlineData((sbyte)-2, ulong.MaxValue - 1, ulong.MaxValue)]
    [InlineData((sbyte)-120, ulong.MaxValue - 119, ulong.MaxValue)]
    [InlineData((sbyte)120, 120uL, 0uL)]
    [InlineData(sbyte.MinValue, ulong.MaxValue - 127, ulong.MaxValue)]
    [InlineData(sbyte.MaxValue, 127uL, 0uL)]
    public void ConversionFromInt8(sbyte value, ulong low, ulong high)
    {
        UInt128 v = (UInt128)value;
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
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0uL);
    }

    [Theory]
    [InlineData((short)0, 0uL, 0uL)]
    [InlineData((short)1, 1uL, 0uL)]
    [InlineData((short)-1, ulong.MaxValue, ulong.MaxValue)]
    [InlineData((short)-2, ulong.MaxValue - 1, ulong.MaxValue)]
    [InlineData((short)-120, ulong.MaxValue - 119, ulong.MaxValue)]
    [InlineData((short)120, 120uL, 0uL)]
    [InlineData((short)-1200, ulong.MaxValue - 1199, ulong.MaxValue)]
    [InlineData((short)1200, 1200uL, 0uL)]
    [InlineData((short)-12000, ulong.MaxValue - 11999, ulong.MaxValue)]
    [InlineData((short)12000, 12000uL, 0uL)]
    [InlineData(short.MinValue, ulong.MaxValue - 32767, ulong.MaxValue)]
    [InlineData(short.MaxValue, 32767uL, 0uL)]
    public void ConversionFromInt16(short value, ulong low, ulong high)
    {
        UInt128 v = (UInt128)value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData((ushort)0, 0uL)]
    [InlineData((ushort)1, 1uL)]
    [InlineData((ushort)120, 120uL)]
    [InlineData((ushort)1200, 1200uL)]
    [InlineData((ushort)12000, 12000uL)]
    [InlineData(ushort.MaxValue, 65535uL)]
    public void ConversionFromUInt16(ushort value, ulong low)
    {
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0uL);
    }

    [Theory]
    [InlineData(0, 0uL, 0uL)]
    [InlineData(1, 1uL, 0uL)]
    [InlineData(-1, ulong.MaxValue, ulong.MaxValue)]
    [InlineData(-2, ulong.MaxValue - 1, ulong.MaxValue)]
    [InlineData(-120, ulong.MaxValue - 119, ulong.MaxValue)]
    [InlineData(120, 120uL, 0uL)]
    [InlineData(-1200, ulong.MaxValue - 1199, ulong.MaxValue)]
    [InlineData(1200, 1200uL, 0uL)]
    [InlineData(-12000, ulong.MaxValue - 11999, ulong.MaxValue)]
    [InlineData(12000, 12000uL, 0uL)]
    [InlineData(-12000000, ulong.MaxValue - 11999999, ulong.MaxValue)]
    [InlineData(12000000, 12000000uL, 0uL)]
    [InlineData(int.MinValue, ulong.MaxValue - int.MaxValue, ulong.MaxValue)]
    [InlineData(int.MaxValue, (ulong)int.MaxValue, 0uL)]
    public void ConversionFromInt32(int value, ulong low, ulong high)
    {
        UInt128 v = (UInt128)value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData(0u, 0uL)]
    [InlineData(1u, 1uL)]
    [InlineData(120u, 120uL)]
    [InlineData(1200u, 1200uL)]
    [InlineData(12000u, 12000uL)]
    [InlineData(12000000u, 12000000uL)]
    [InlineData(uint.MaxValue, (ulong)uint.MaxValue)]
    public void ConversionFromUInt32(uint value, ulong low)
    {
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0uL);
    }

    [Theory]
    [InlineData(0L, 0uL, 0uL)]
    [InlineData(1L, 1uL, 0uL)]
    [InlineData(-1L, ulong.MaxValue, ulong.MaxValue)]
    [InlineData(-2L, ulong.MaxValue - 1, ulong.MaxValue)]
    [InlineData(-120L, ulong.MaxValue - 119, ulong.MaxValue)]
    [InlineData(120L, 120uL, 0uL)]
    [InlineData(-1200L, ulong.MaxValue - 1199, ulong.MaxValue)]
    [InlineData(1200L, 1200uL, 0uL)]
    [InlineData(-12000L, ulong.MaxValue - 11999, ulong.MaxValue)]
    [InlineData(12000L, 12000uL, 0uL)]
    [InlineData(-12000000L, ulong.MaxValue - 11999999, ulong.MaxValue)]
    [InlineData(12000000L, 12000000uL, 0uL)]
    [InlineData(-12000000000000L, ulong.MaxValue - 11999999999999, ulong.MaxValue)]
    [InlineData(12000000000000L, 12000000000000uL, 0uL)]
    [InlineData(long.MinValue, ulong.MaxValue - long.MaxValue, ulong.MaxValue)]
    [InlineData(long.MaxValue, (ulong)long.MaxValue, 0uL)]
    public void ConversionFromInt64(long value, ulong low, ulong high)
    {
        UInt128 v = (UInt128)value;
        v.Low.Should().Be(low);
        v.High.Should().Be(high);
    }

    [Theory]
    [InlineData(0uL, 0uL)]
    [InlineData(1uL, 1uL)]
    [InlineData(120uL, 120uL)]
    [InlineData(1200uL, 1200uL)]
    [InlineData(12000uL, 12000uL)]
    [InlineData(12000000uL, 12000000uL)]
    [InlineData(12000000000000uL, 12000000000000uL)]
    [InlineData(ulong.MaxValue, ulong.MaxValue)]
    public void ConversionFromUInt64(ulong value, ulong low)
    {
        UInt128 v = value;
        v.Low.Should().Be(low);
        v.High.Should().Be(0uL);
    }
}
