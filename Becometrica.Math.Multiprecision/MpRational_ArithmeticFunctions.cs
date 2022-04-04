using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpRational
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Negate(ref MpRational result, MpRational operand) =>
        Mpir.mpq_neg(ref (result._q ??= new()).Value, operand.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Negate(MpRational operand)
    {
        MpRational result = default;
        Negate(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Abs(ref MpRational result, MpRational operand) =>
        Mpir.mpq_abs(ref (result._q ??= new()).Value, operand.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Abs(MpRational operand)
    {
        MpRational result = default;
        Abs(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpRational result, MpRational operand1, MpRational operand2) =>
        Mpir.mpq_add(ref (result._q ??= new()).Value, operand1.Q, operand2.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Add(MpRational operand1, MpRational operand2)
    {
        MpRational result = default;
        Add(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpRational result, MpRational operand1, MpRational operand2) =>
        Mpir.mpq_sub(ref (result._q ??= new()).Value, operand1.Q, operand2.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Subtract(MpRational operand1, MpRational operand2)
    {
        MpRational result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpRational result, MpRational operand1, MpRational operand2) =>
        Mpir.mpq_mul(ref (result._q ??= new()).Value, operand1.Q, operand2.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Multiply(MpRational operand1, MpRational operand2)
    {
        MpRational result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply2Exp(ref MpRational result, MpRational operand, uint exponent) =>
        Multiply2Exp(ref result, operand, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply2Exp(ref MpRational result, MpRational operand, nuint exponent) =>
        Mpir.mpq_mul_2exp(ref (result._q ??= new()).Value, operand.Q, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Multiply2Exp(MpRational operand, uint exponent) => Multiply2Exp(operand, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Multiply2Exp(MpRational operand, nuint exponent)
    {
        MpRational result = default;
        Multiply2Exp(ref result, operand, exponent);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpRational result, MpRational operand1, MpRational operand2) =>
        Mpir.mpq_div(ref (result._q ??= new()).Value, operand1.Q, operand2.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Divide(MpRational operand1, MpRational operand2)
    {
        MpRational result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide2Exp(ref MpRational result, MpRational operand, uint exponent) =>
        Divide2Exp(ref result, operand, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide2Exp(ref MpRational result, MpRational operand, nuint exponent) =>
        Mpir.mpq_div_2exp(ref (result._q ??= new()).Value, operand.Q, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Divide2Exp(MpRational operand, uint exponent) => Divide2Exp(operand, (nuint)exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Divide2Exp(MpRational operand, nuint exponent)
    {
        MpRational result = default;
        Divide2Exp(ref result, operand, exponent);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Invert(ref MpRational result, MpRational operand) =>
        Mpir.mpq_inv(ref (result._q ??= new()).Value, operand.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational Invert(MpRational operand)
    {
        MpRational result = default;
        Invert(ref result, operand);
        return result;
    }
}
