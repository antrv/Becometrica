using System.Numerics;
using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    public string ToString(int @base)
    {
        if ((@base < -36 || @base > -2) && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (_z is null)
            return "0";

        nuint size = 2 + Mpir.mpz_sizeinbase(_z.Value, System.Math.Abs(@base));
        if (size > int.MaxValue)
            throw new OverflowException();

        Span<byte> span = size > 512 ? new byte[size] : stackalloc byte[(int)size];
        return Mpir.mpz_get_str((Utf8StringPtr)Ptr.FromRef(ref span[0]), @base, _z.Value).ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ToUInt16() => (ushort)Mpir.mpz_get_ui(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ToInt16() => (short)Mpir.mpz_get_si(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ToUInt32() => (uint)Mpir.mpz_get_ui(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ToInt32() => (int)Mpir.mpz_get_si(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint ToNativeUInt() => Mpir.mpz_get_ui(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ToNativeInt() => Mpir.mpz_get_si(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ToUInt64() => Mpir.mpz_get_ux(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ToInt64() => Mpir.mpz_get_sx(Z);

    public BigInteger ToBigInteger()
    {
        if (_z is null)
            return BigInteger.Zero;

        nuint byteCount = 2 + Mpir.mpz_sizeinbase(_z.Value, 16) / 2;
        if (byteCount > int.MaxValue)
            throw new OverflowException();

        Span<byte> buffer = byteCount > 512 ? new byte[byteCount] : stackalloc byte[(int)byteCount];
        Ptr<byte> ptr = Ptr.FromRef(ref buffer[0]);
        Mpir.mpz_export(ptr, out nuint count, -1, 1, -1, 0, _z.Value);
        BigInteger value = new(buffer[..(int)count], true);
        return Sign() >= 0 ? value : -value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble() => Mpir.mpz_get_d(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble(out int exponent)
    {
        double result = Mpir.mpz_get_d_2exp(out nint exp, Z);
        exponent = (int)exp;
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble(out nint exponent) => Mpir.mpz_get_d_2exp(out exponent, Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational ToRational() => new(this);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat ToFloat() => new(this);
}
