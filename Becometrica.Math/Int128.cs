using System.Numerics;

namespace Becometrica.Math;

/// <summary>
/// Represents a 128-bit signed integer.
/// </summary>
[Serializable]
public readonly struct Int128: IEquatable<Int128>, IComparable<Int128>
{
    private readonly ulong _low;
    private readonly long _high;

    public Int128(ulong low, long high)
    {
        _low = low;
        _high = high;
    }

    /// <summary>
    /// Represents the smallest possible value of an <see cref="Int128"/>.
    /// </summary>
    public static Int128 MinValue => new(0, long.MinValue);

    /// <summary>
    /// Represents the largest possible value of an <see cref="Int128"/>.
    /// </summary>
    public static Int128 MaxValue => new(ulong.MaxValue, long.MaxValue);

    /// <inheritdoc />
    public bool Equals(Int128 other) => (_low == other._low) & (_high == other._high);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Int128 v && Equals(v);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(_low, _high);

    /// <inheritdoc />
    public int CompareTo(Int128 other)
    {
        if (_high == other._high)
        {
            if (_low == other._low)
                return 0;

            return _low > other._low ? 1 : -1;
        }

        return _high > other._high ? 1 : -1;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        // max length: -340282366920938463463374607431768211456
        const int maxLength = 40;
        Span<char> span = stackalloc char[maxLength];
        int position = maxLength;

        const int d = 1000000000;

        Int128 v = this;
        while (v._high != 0 || v._low != 0)
        {
            int rem;
            (v, rem) = DivRem(v, d);
            rem = System.Math.Abs(rem);
            for (int i = 0; i < 9; i++)
            {
                position--;
                span[position] = (char)(rem % 10 + '0');
                rem /= 10;
            }
        }

        if (position == maxLength)
        {
            position--;
            span[position] = '0';
        }
        else
        {
            while (position < maxLength - 1 && span[position] == '0')
                position++;
        }

        if (_high < 0)
        {
            position--;
            span[position] = '-';
        }

        return new(span.Slice(position, maxLength - position));
    }

    // TODO: conversion from/to BigInteger, decimal, float, double
    public static implicit operator Int128(sbyte v) => new((ulong)v, v >> 7);
    public static implicit operator Int128(byte v) => new(v, 0);
    public static implicit operator Int128(char v) => new(v, 0);
    public static implicit operator Int128(short v) => new((ulong)v, v >> 15);
    public static implicit operator Int128(ushort v) => new(v, 0);
    public static implicit operator Int128(int v) => new((ulong)v, v >> 31);
    public static implicit operator Int128(uint v) => new(v, 0);
    public static implicit operator Int128(long v) => new((ulong)v, v >> 63);
    public static implicit operator Int128(ulong v) => new(v, 0);

    public static explicit operator sbyte(Int128 v) => (sbyte)v._low;
    public static explicit operator byte(Int128 v) => (byte)v._low;
    public static explicit operator short(Int128 v) => (short)v._low;
    public static explicit operator ushort(Int128 v) => (ushort)v._low;
    public static explicit operator int(Int128 v) => (int)v._low;
    public static explicit operator uint(Int128 v) => (uint)v._low;
    public static explicit operator long(Int128 v) => (long)v._low;
    public static explicit operator ulong(Int128 v) => v._low;
    public static implicit operator BigInteger(Int128 v) => ((BigInteger)v._high << 64) + v._low;

    public static Int128 operator +(Int128 v) => v;

    public static Int128 operator -(Int128 v)
    {
        ulong low = ~v._low + 1;
        return new(low, ~v._high + Conversion.UnsafeBooleanToInt64(low == 0));
    }

    public static Int128 operator +(Int128 a, Int128 b)
    {
        ulong low = a._low + b._low;
        long high = a._high + b._high + Conversion.UnsafeBooleanToInt64((low < a._low) | (low < b._low));
        return new(low, high);
    }

    public static Int128 operator -(Int128 a, Int128 b)
    {
        ulong low = a._low - b._low;
        long high = a._high - b._high - Conversion.UnsafeBooleanToInt64(a._low < b._low);
        return new(low, high);
    }

    public static Int128 operator *(Int128 a, Int128 b)
    {
        ulong high = System.Math.BigMul(a._low, b._low, out ulong low) +
            (ulong)a._high * b._low + a._low * (ulong)b._high;

        return new(low, (long)high);
    }

    public static Int128 operator <<(Int128 a, int b) =>
        (b & 127) switch
        {
            0 => a,
            >= 64 => new(0, (long)(a._low << b)),
            _ => new(a._low << b, (a._high << b) | (long)(a._low >> -b))
        };

    public static Int128 operator >>(Int128 a, int b) =>
        (b & 127) switch
        {
            0 => a,
            >= 64 => new((ulong)(a._high >> b), a._high >> 63),
            _ => new((a._low >> b) | (ulong)(a._high << -b), a._high >> b)
        };

    public static (Int128 Quotient, int Remainder) DivRem(Int128 dividend, int divider)
    {
        (long high, long rem) = System.Math.DivRem(dividend._high, divider);
        rem = (rem << 32) | (long)(dividend._low >> 32);
        long q;
        (q, rem) = System.Math.DivRem(rem, divider);
        ulong low = dividend._low & 0x00000000FFFFFFFFuL;
        rem = (rem << 32) | (long)low;
        low |= (ulong)q << 32;
        (q, rem) = System.Math.DivRem(rem, divider);
        low = (low & 0xFFFFFFFF00000000uL) | (ulong)q;
        return (new Int128(low, high), (int)rem);
    }

    /// <summary>
    /// Lower 64-bit part.
    /// </summary>
    public ulong Low => _low;

    /// <summary>
    /// Higher 64-bit part.
    /// </summary>
    public long High => _high;
}
