using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void And(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_and(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger And(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        And(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Or(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_ior(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Or(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Or(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Xor(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_xor(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Xor(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Xor(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Not(ref MpInteger result, MpInteger operand) =>
        Mpir.mpz_com(ref (result._z ??= new()).Value, operand.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Not(MpInteger operand)
    {
        MpInteger result = default;
        Not(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint PopCount() => (uint)Mpir.mpz_popcount(Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint HammingDistance(MpInteger operand1, MpInteger operand2) =>
        (uint)Mpir.mpz_hamdist(operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint Scan0(uint startingBit) => (uint)Scan0((nuint)startingBit);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint Scan0(nuint startingBit) => Mpir.mpz_scan0(Z, startingBit);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint Scan1(uint startingBit) => (uint)Scan1((nuint)startingBit);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nuint Scan1(nuint startingBit) => Mpir.mpz_scan1(Z, startingBit);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetBit(uint bitIndex) => SetBit((nuint)bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetBit(nuint bitIndex) => Mpir.mpz_setbit(ref (_z ??= new()).Value, bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ClearBit(uint bitIndex) => ClearBit((nuint)bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ClearBit(nuint bitIndex) => Mpir.mpz_clrbit(ref (_z ??= new()).Value, bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void InvertBit(uint bitIndex) => InvertBit((nuint)bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void InvertBit(nuint bitIndex) => Mpir.mpz_combit(ref (_z ??= new()).Value, bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool GetBit(uint bitIndex) => GetBit((nuint)bitIndex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool GetBit(nuint bitIndex) => Mpir.mpz_tstbit(Z, bitIndex) != 0;
}
