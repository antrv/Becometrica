using System.Globalization;
using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;
using System;

namespace Becometrica.Math;

partial struct MpFloat
{
    public string ToString(int @base, uint digits = 0)
    {
        if ((@base < -36 || @base > -2) && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (_f is null)
            return "0";

        nuint size = digits != 0
            ? 2 + digits
            : 2 + (nuint)(2.0 / System.Math.Log2(System.Math.Abs(@base)) * Mpir.mpf_get_prec(_f.Value));

        if (size > int.MaxValue)
            throw new OverflowException();

        Span<byte> span = size > 512 ? new byte[size] : stackalloc byte[(int)size];
        string str = Mpir.mpf_get_str((Utf8StringPtr)Ptr.FromRef(ref span[0]), out nint exp, @base, digits,
            _f.Value).ToString();

        if (string.IsNullOrEmpty(str))
            return "0";

        if (str[0] == '-')
            str = string.Concat("-0.", str.AsSpan(1));
        else
            str = "0." + str;

        if (exp != 0)
            str += "E" + exp.ToString(CultureInfo.InvariantCulture);

        return str;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ToUInt16() => (ushort)Mpir.mpf_get_ui(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ToInt16() => (short)Mpir.mpf_get_si(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ToUInt32() => (uint)Mpir.mpf_get_ui(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ToInt32() => (int)Mpir.mpf_get_si(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint ToNativeUInt() => Mpir.mpf_get_ui(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ToNativeInt() => Mpir.mpf_get_si(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ToUInt64() => IntPtr.Size == 8 ? Mpir.mpf_get_ui(F) : ToInteger().ToUInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ToInt64() => IntPtr.Size == 8 ? Mpir.mpf_get_si(F) : ToInteger().ToInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble() => Mpir.mpf_get_d(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble(out int exponent)
    {
        double result = Mpir.mpf_get_d_2exp(out nint exp, F);
        exponent = (int)exp;
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble(out nint exponent) => Mpir.mpf_get_d_2exp(out exponent, F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger ToInteger() => new(this);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational ToRational() => new(this);
}
