using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt16() => Mpir.mpz_fits_ushort_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt16() => Mpir.mpz_fits_sshort_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt32() => Mpir.mpz_fits_uint_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt32() => Mpir.mpz_fits_sint_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt64() => Mpir.mpz_fits_ulong_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt64() => Mpir.mpz_fits_slong_p(Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsOdd() => Mpir.mpz_odd_p(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsEven() => Mpir.mpz_even_p(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint GetLimbCount() => Mpir.mpz_size(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint GetLimb(nuint limbIndex) => Mpir.mpz_getlimbn(Z, limbIndex);
}
