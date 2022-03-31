using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PowMod(ref MpInteger result, MpInteger @base, MpInteger exponent, MpInteger modulo) =>
        Mpir.mpz_powm(ref (result._z ??= new()).Value, @base.Z, exponent.Z, modulo.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger PowMod(MpInteger @base, MpInteger exponent, MpInteger modulo)
    {
        MpInteger result = default;
        PowMod(ref result, @base, exponent, modulo);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PowMod(ref MpInteger result, MpInteger @base, uint exponent, MpInteger modulo) =>
        PowMod(ref result, @base, (nuint)exponent, modulo);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger PowMod(MpInteger @base, uint exponent, MpInteger modulo) =>
        PowMod(@base, (nuint)exponent, modulo);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PowMod(ref MpInteger result, MpInteger @base, nuint exponent, MpInteger modulo) =>
        Mpir.mpz_powm_ui(ref (result._z ??= new()).Value, @base.Z, exponent, modulo.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger PowMod(MpInteger @base, nuint exponent, MpInteger modulo)
    {
        MpInteger result = default;
        PowMod(ref result, @base, exponent, modulo);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpInteger result, MpInteger @base, uint exponent) =>
        Pow(ref result, @base, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Pow(MpInteger @base, uint exponent) => Pow(@base, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger Pow(uint exponent) => Pow(this, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpInteger result, MpInteger @base, nuint exponent) =>
        Mpir.mpz_pow_ui(ref (result._z ??= new()).Value, @base.Z, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Pow(MpInteger @base, nuint exponent)
    {
        MpInteger result = default;
        Pow(ref result, @base, exponent);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger Pow(nuint exponent) => Pow(this, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpInteger result, uint @base, uint exponent) =>
        Pow(ref result, @base, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Pow(uint @base, uint exponent) => Pow(@base, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpInteger result, nuint @base, nuint exponent) =>
        Mpir.mpz_ui_pow_ui(ref (result._z ??= new()).Value, @base, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Pow(nuint @base, nuint exponent)
    {
        MpInteger result = default;
        Pow(ref result, @base, exponent);
        return result;
    }
}
