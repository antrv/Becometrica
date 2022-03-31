using System.Numerics;
using System.Runtime.CompilerServices;

namespace Becometrica.Math;

/// <summary>
/// Represents a 128-bit unsigned integer.
/// </summary>
[Serializable]
public readonly struct UInt128: IEquatable<UInt128>, IComparable<UInt128>
{
    private readonly ulong _low;
    private readonly ulong _high;

    public UInt128(ulong low, ulong high)
    {
        _low = low;
        _high = high;
    }

    // TODO: conversion from/to decimal, float, double
    public static explicit operator UInt128(sbyte v) => new((ulong)v, (ulong)(v >> 7));
    public static implicit operator UInt128(byte v) => new(v, 0);
    public static implicit operator UInt128(char v) => new(v, 0);
    public static explicit operator UInt128(short v) => new((ulong)v, (ulong)(v >> 15));
    public static implicit operator UInt128(ushort v) => new(v, 0);
    public static explicit operator UInt128(int v) => new((ulong)v, (ulong)(v >> 31));
    public static implicit operator UInt128(uint v) => new(v, 0);
    public static explicit operator UInt128(long v) => new((ulong)v, (ulong)(v >> 63));
    public static implicit operator UInt128(ulong v) => new(v, 0);

    public static explicit operator UInt128(BigInteger v)
    {
        Span<byte> buffer = stackalloc byte[16];
        v.TryWriteBytes(buffer, out int bytesWritten, isBigEndian: !BitConverter.IsLittleEndian);
        if (bytesWritten < 16 && v.Sign < 0)
        {
            for (int i = bytesWritten; i < 16; i++)
                buffer[i] = 0xFF;
        }

        Ptr<ulong> ptr = Ptr.FromRef(ref buffer[0]).Cast<ulong>();
        return new(ptr[0], ptr[1]);
    }

    public static explicit operator sbyte(UInt128 v) => (sbyte)v._low;
    public static explicit operator byte(UInt128 v) => (byte)v._low;
    public static explicit operator short(UInt128 v) => (short)v._low;
    public static explicit operator ushort(UInt128 v) => (ushort)v._low;
    public static explicit operator int(UInt128 v) => (int)v._low;
    public static explicit operator uint(UInt128 v) => (uint)v._low;
    public static explicit operator long(UInt128 v) => (long)v._low;
    public static explicit operator ulong(UInt128 v) => v._low;
    public static explicit operator Int128(UInt128 v) => new (v._low, (long)v._high);
    public static implicit operator BigInteger(UInt128 v) => ((BigInteger)v._high << 64) + v._low;

    public static bool operator ==(UInt128 a, UInt128 b) => (a._low == b._low) & (a._high == b._high);
    public static bool operator !=(UInt128 a, UInt128 b) => (a._low != b._low) | (a._high != b._high);

    public static bool operator <(UInt128 a, UInt128 b) =>
        (a._high < b._high) || ((a._high == b._high) & (a._low < b._low));

    public static bool operator <=(UInt128 a, UInt128 b) =>
        (a._high < b._high) || ((a._high == b._high) & (a._low <= b._low));

    public static bool operator >(UInt128 a, UInt128 b) =>
        (a._high > b._high) || ((a._high == b._high) & (a._low > b._low));

    public static bool operator >=(UInt128 a, UInt128 b) =>
        (a._high > b._high) || ((a._high == b._high) & (a._low >= b._low));

    public static UInt128 operator >>(UInt128 a, int b) => (b & 127) switch
    {
        0 => a,
        < 64 => new((a._low >> b) | (a._high << (64 - b)), a._high >> b),
        _ => new(a._high >> b, 0),
    };

    public static UInt128 operator <<(UInt128 a, int b) => (b & 127) switch
    {
        0 => a,
        < 64 => new(a._low << b, (a._low >> (64 - b)) | (a._high << b)),
        _ => new(0, a._high << b),
    };

    public static UInt128 operator +(UInt128 v) => v;

    public static UInt128 operator +(UInt128 a, ulong b)
    {
        ulong low = a._low + b;
        return new(low, a._high + Conversion.UnsafeBooleanToUInt64((low < a._low) | (low < b)));
    }

    public static UInt128 operator +(ulong a, UInt128 b)
    {
        ulong low = a + b._low;
        return new(low, b._high + Conversion.UnsafeBooleanToUInt64((low < a) | (low < b._low)));
    }

    public static UInt128 operator +(UInt128 a, UInt128 b)
    {
        ulong low = a._low + b._low;
        return new(low, a._high + b._high + Conversion.UnsafeBooleanToUInt64((low < a._low) | (low < b._low)));
    }

    public static UInt128 operator ++(UInt128 a)
    {
        ulong low = a._low + 1;
        return new(low, a._high + Conversion.UnsafeBooleanToUInt64(low == 0));
    }

    public static UInt128 operator -(UInt128 a, ulong b) => new(a._low - b,
        a._high - Conversion.UnsafeBooleanToUInt64(a._low < b));

    public static UInt128 operator -(UInt128 a, UInt128 b) => new(a._low - b._low,
        a._high - b._high - Conversion.UnsafeBooleanToUInt64(a._low < b._low));

    public static UInt128 operator --(UInt128 a) =>
        new(a._low - 1, a._high - Conversion.UnsafeBooleanToUInt64(a._low == 0));

    public static UInt128 operator *(UInt128 a, ulong b)
    {
        ulong high = System.Math.BigMul(a._low, b, out ulong low);
        return new(low, high + a._high * b);
    }

    public static UInt128 operator *(ulong a, UInt128 b)
    {
        ulong high = System.Math.BigMul(a, b._low, out ulong low);
        return new(low, high + a * b._high);
    }

    public static UInt128 operator *(UInt128 a, UInt128 b)
    {
        ulong high = System.Math.BigMul(a._low, b._low, out ulong low);
        return new(low, high + a._low * b._high + a._high * b._low);
    }

    public static (UInt128 Quotient, ulong Remainder) DivRem(UInt128 dividend, ulong divisor)
    {
        (ulong high, ulong r) = System.Math.DivRem(dividend._high, divisor);
        r = (r << 32) | (dividend._low >> 32);
        ulong low;
        (low, r) = System.Math.DivRem(r, divisor);
        r = (r << 32) | (dividend._low & uint.MaxValue);
        (ulong q, r) = System.Math.DivRem(r, divisor);
        return (new((low << 32) | q, high), r);
    }

    public static UInt128 operator /(UInt128 dividend, ulong divisor) => DivRem(dividend, divisor).Quotient;
    public static ulong operator %(UInt128 dividend, ulong divisor) => DivRem(dividend, divisor).Remainder;

    public static (UInt128 Quotient, UInt128 Remainder) DivRem(UInt128 dividend, UInt128 divisor)
    {
        // https://www.codeproject.com/Tips/785014/UInt-Division-Modulus
        // https://skanthak.homepage.t-online.de/integer.html
        if (dividend < divisor)
            return (default, dividend);

        ulong tmp;
        if (divisor._high == 0)
        {
            UInt128 quotient;
            (quotient, tmp) = DivRem(dividend, divisor._low);
            return (quotient, tmp);
        }

        int index = BitOperations.Log2(divisor._high);
        ulong high = ShiftLeft128(divisor._low, divisor._high, 63 - index);
        ulong low;
        if (high > dividend._high)
        {
            low = dividend % high;
            low = ShiftLeft128(low, 0, 63 - index);
        }
        else // prevent overflow
        {
            low = new UInt128(dividend._low, dividend._high - high) % high;
            low = ShiftLeft128(low, 1, 63 - index);
        }

        ulong quotientLow = low;
        tmp = low * divisor._high;
        high = System.Math.BigMul(low, divisor._low, out low) + tmp;

        if (high < tmp // quotient * divisor >= 2**128 > dividend
            || high > dividend._high // quotient * divisor > dividend
            || high == dividend._high && low > dividend._low)
        {
            quotientLow--;
            high = System.Math.BigMul(quotientLow, divisor._low, out low) + quotientLow * divisor._high;
        }

        return (new(quotientLow, 0),
            new(dividend._high - (high + Conversion.UnsafeBooleanToUInt64(dividend._low < low)), dividend._low - low));
    }

    public static UInt128 operator /(UInt128 dividend, UInt128 divisor) => DivRem(dividend, divisor).Quotient;
    public static UInt128 operator %(UInt128 dividend, UInt128 divisor) => DivRem(dividend, divisor).Remainder;

    /// <summary>
    /// Lower 64-bit part.
    /// </summary>
    public ulong Low => _low;

    /// <summary>
    /// Higher 64-bit part.
    /// </summary>
    public ulong High => _high;

    /// <inheritdoc />
    public bool Equals(UInt128 other) => (_low == other._low) & (_high == other._high);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is UInt128 a && Equals(a);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(_low, _high);

    /// <inheritdoc />
    public int CompareTo(UInt128 other) => BitUtils.Conditional(_high == other._high,
        BitUtils.Compare(_low, other._low),
        (Conversion.UnsafeBooleanToInt32(_high > other._high) << 1) - 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong ShiftLeft128(ulong low, ulong high, int shift) => (low >> (64 - shift)) | (high << shift);
}
