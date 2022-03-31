using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpRational
{
    public string ToString(int @base)
    {
        if ((@base < -36 || @base > -2) && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (_q is null)
            return "0";

        nuint size = 3 + Mpir.mpz_sizeinbase(_q.Value.MpNum, System.Math.Abs(@base))
            + Mpir.mpz_sizeinbase(_q.Value.MpDen, System.Math.Abs(@base));

        if (size > int.MaxValue)
            throw new OverflowException();

        Span<byte> span = size > 512 ? new byte[size] : stackalloc byte[(int)size];
        return Mpir.mpq_get_str((Utf8StringPtr)Ptr.FromRef(ref span[0]), @base, _q.Value).ToString();
    }

    public uint ToUInt32()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return (uint)Mpir.mpz_get_ui(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    public int ToInt32()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return (int)Mpir.mpz_get_si(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    public nuint ToNativeUInt()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return Mpir.mpz_get_ui(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    public nint ToNativeInt()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return Mpir.mpz_get_si(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    public ulong ToUInt64()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return Mpir.mpz_get_ux(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    public long ToInt64()
    {
        Mpz z = default;
        Mpir.mpz_init(ref z);
        try
        {
            Mpir.mpz_set_q(ref z, Q);
            return Mpir.mpz_get_sx(z);
        }
        finally
        {
            Mpir.mpz_clear(ref z);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ToDouble() => Mpir.mpq_get_d(Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger ToInteger() => new(this);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat ToFloat() => new(this);
}
