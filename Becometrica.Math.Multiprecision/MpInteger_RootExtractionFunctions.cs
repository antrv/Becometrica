using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Root(ref MpInteger result, MpInteger operand, uint n) => Root(ref result, operand, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Root(ref MpInteger result, MpInteger operand, nuint n) =>
        Mpir.mpz_root(ref (result._z ??= new()).Value, operand.Z, n) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NthRoot(ref MpInteger result, MpInteger operand, uint n) =>
        NthRoot(ref result, operand, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger NthRoot(MpInteger operand, uint n) => NthRoot(operand, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NthRoot(ref MpInteger result, MpInteger operand, nuint n) =>
        Mpir.mpz_nthroot(ref (result._z ??= new()).Value, operand.Z, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger NthRoot(MpInteger operand, nuint n)
    {
        MpInteger result = default;
        NthRoot(ref result, operand, n);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RootRem(ref MpInteger root, ref MpInteger remainder, MpInteger operand, uint n) =>
        RootRem(ref root, ref remainder, operand, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Root, MpInteger Remainder) RootRem(MpInteger operand, uint n) =>
        RootRem(operand, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RootRem(ref MpInteger root, ref MpInteger remainder, MpInteger operand, nuint n) =>
        Mpir.mpz_rootrem(ref (root._z ??= new()).Value, ref (remainder._z ??= new()).Value, operand.Z, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Root, MpInteger Remainder) RootRem(MpInteger operand, nuint n)
    {
        MpInteger root = default;
        MpInteger remainder = default;
        RootRem(ref root, ref remainder, operand, n);
        return (root, remainder);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Sqrt(ref MpInteger result, MpInteger operand) =>
        Mpir.mpz_sqrt(ref (result._z ??= new()).Value, operand.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Sqrt(MpInteger operand)
    {
        MpInteger result = default;
        Sqrt(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SqrtRem(ref MpInteger root, ref MpInteger remainder, MpInteger operand) =>
        Mpir.mpz_sqrtrem(ref (root._z ??= new()).Value, ref (remainder._z ??= new()).Value, operand.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Root, MpInteger Remainder) SqrtRem(MpInteger operand)
    {
        MpInteger root = default;
        MpInteger remainder = default;
        SqrtRem(ref root, ref remainder, operand);
        return (root, remainder);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPerfectPower(MpInteger operand) => Mpir.mpz_perfect_power_p(operand.Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPerfectSquare(MpInteger operand) => Mpir.mpz_perfect_square_p(operand.Z) != 0;
}
