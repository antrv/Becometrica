using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpFloat
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Ceil(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_ceil(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Ceil(MpFloat operand)
    {
        MpFloat result = default;
        Ceil(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Floor(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_floor(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Floor(MpFloat operand)
    {
        MpFloat result = default;
        Floor(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Truncate(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_trunc(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Truncate(MpFloat operand)
    {
        MpFloat result = default;
        Truncate(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsInteger() => Mpir.mpf_integer_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt64() => Mpir.mpf_fits_ulong_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt64() => Mpir.mpf_fits_slong_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt32() => Mpir.mpf_fits_uint_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt32() => Mpir.mpf_fits_sint_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsUInt16() => Mpir.mpf_fits_ushort_p(F) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FitsInt16() => Mpir.mpf_fits_sshort_p(F) != 0;
}
