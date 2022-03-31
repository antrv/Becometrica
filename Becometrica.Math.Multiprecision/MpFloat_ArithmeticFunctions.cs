using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpFloat
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Negate(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_neg(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Negate(MpFloat operand)
    {
        MpFloat result = default;
        Negate(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Abs(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_abs(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Abs(MpFloat operand)
    {
        MpFloat result = default;
        Abs(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, MpFloat operand2) =>
        Mpir.mpf_add(ref (result._f ??= new()).Value, operand1.F, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Add(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Add(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, uint operand2) => Add(operand1, (nuint)operand2);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, int operand2) =>
        Add(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, int operand2) => Add(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_add_ui(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Add(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, nint operand2)
    {
        if (operand2 >= 0)
            Add(ref result, operand1, (nuint)operand2);
        else
            Subtract(ref result, operand1, (nuint)(-operand2));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, nint operand2) =>
        operand2 >= 0 ? Add(operand1, (nuint)operand2) : Subtract(operand1, (nuint)(-operand2));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Add(ref result, operand1, (nuint)operand2);
        else
            Add(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Add(operand1, (nuint)operand2) : Add(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpFloat result, MpFloat operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Add(ref result, operand1, (nint)operand2);
        else
            Add(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Add(MpFloat operand1, long operand2) =>
        IntPtr.Size == 8 ? Add(operand1, (nint)operand2) : Add(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, MpFloat operand2) =>
        Mpir.mpf_sub(ref (result._f ??= new()).Value, operand1.F, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Subtract(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, uint operand2) => Subtract(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, uint operand1, MpFloat operand2) =>
        Subtract(ref result, (nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(uint operand1, MpFloat operand2) => Subtract((nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, int operand2) =>
        Subtract(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, int operand2) => Subtract(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, int operand1, MpFloat operand2) =>
        Subtract(ref result, (nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(int operand1, MpFloat operand2) => Subtract((nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_sub_ui(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, nuint operand1, MpFloat operand2) =>
        Mpir.mpf_ui_sub(ref (result._f ??= new()).Value, operand1, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(nuint operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, nint operand2)
    {
        if (operand2 >= 0)
            Subtract(ref result, operand1, (nuint)operand2);
        else
            Add(ref result, operand1, (nuint)(-operand2));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, nint operand2) =>
        operand2 >= 0 ? Subtract(operand1, (nuint)operand2) : Add(operand1, (nuint)(-operand2));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, nint operand1, MpFloat operand2)
    {
        if (operand1 >= 0)
            Subtract(ref result, (nuint)operand1, operand2);
        else
            Subtract(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(nint operand1, MpFloat operand2) =>
        operand1 >= 0 ? Subtract((nuint)operand1, operand2) : Subtract((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, operand1, (nuint)operand2);
        else
            Subtract(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Subtract(operand1, (nuint)operand2) : Subtract(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, ulong operand1, MpFloat operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, (nuint)operand1, operand2);
        else
            Subtract(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(ulong operand1, MpFloat operand2) =>
        IntPtr.Size == 8 ? Subtract((nuint)operand1, operand2) : Subtract((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, MpFloat operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, operand1, (nint)operand2);
        else
            Subtract(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(MpFloat operand1, long operand2) =>
        IntPtr.Size == 8 ? Subtract(operand1, (nint)operand2) : Subtract(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpFloat result, long operand1, MpFloat operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, (nint)operand1, operand2);
        else
            Subtract(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Subtract(long operand1, MpFloat operand2) =>
        IntPtr.Size == 8 ? Subtract((nint)operand1, operand2) : Subtract((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, MpFloat operand2) =>
        Mpir.mpf_mul(ref (result._f ??= new()).Value, operand1.F, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Multiply(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, uint operand2) => Multiply(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, int operand2) =>
        Multiply(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, int operand2) => Multiply(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_mul_ui(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, nint operand2)
    {
        if (operand2 >= 0)
            Multiply(ref result, operand1, (nuint)operand2);
        else
            Multiply(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, nint operand2) =>
        operand2 >= 0 ? Multiply(operand1, (nuint)operand2) : Multiply(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Multiply(ref result, operand1, (nuint)operand2);
        else
            Multiply(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Multiply(operand1, (nuint)operand2) : Multiply(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpFloat result, MpFloat operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Multiply(ref result, operand1, (nint)operand2);
        else
            Multiply(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply(MpFloat operand1, long operand2) =>
        IntPtr.Size == 8 ? Multiply(operand1, (nint)operand2) : Multiply(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, MpFloat operand2) =>
        Mpir.mpf_div(ref (result._f ??= new()).Value, operand1.F, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Divide(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, uint operand2) => Divide(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, uint operand1, MpFloat operand2) =>
        Divide(ref result, (nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(uint operand1, MpFloat operand2) => Divide((nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, int operand2) =>
        Divide(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, int operand2) => Divide(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, int operand1, MpFloat operand2) =>
        Divide(ref result, (nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(int operand1, MpFloat operand2) => Divide((nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_div_ui(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, nuint operand1, MpFloat operand2) =>
        Mpir.mpf_ui_div(ref (result._f ??= new()).Value, operand1, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(nuint operand1, MpFloat operand2)
    {
        MpFloat result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, nint operand2)
    {
        if (operand2 >= 0)
            Divide(ref result, operand1, (nuint)operand2);
        else
            Divide(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, nint operand2) =>
        operand2 >= 0 ? Divide(operand1, (nuint)operand2) : Divide(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, nint operand1, MpFloat operand2)
    {
        if (operand1 >= 0)
            Divide(ref result, (nuint)operand1, operand2);
        else
            Divide(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(nint operand1, MpFloat operand2) =>
        operand1 >= 0 ? Divide((nuint)operand1, operand2) : Subtract((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, operand1, (nuint)operand2);
        else
            Divide(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Divide(operand1, (nuint)operand2) : Divide(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, ulong operand1, MpFloat operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, (nuint)operand1, operand2);
        else
            Divide(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(ulong operand1, MpFloat operand2) =>
        IntPtr.Size == 8 ? Divide((nuint)operand1, operand2) : Divide((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, MpFloat operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, operand1, (nint)operand2);
        else
            Divide(ref result, operand1, (MpFloat)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(MpFloat operand1, long operand2) =>
        IntPtr.Size == 8 ? Divide(operand1, (nint)operand2) : Divide(operand1, (MpFloat)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpFloat result, long operand1, MpFloat operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, (nint)operand1, operand2);
        else
            Divide(ref result, (MpFloat)operand1, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide(long operand1, MpFloat operand2) =>
        IntPtr.Size == 8 ? Divide((nint)operand1, operand2) : Divide((MpFloat)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Sqrt(ref MpFloat result, MpFloat operand) =>
        Mpir.mpf_sqrt(ref (result._f ??= new()).Value, operand.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Sqrt(MpFloat operand)
    {
        MpFloat result = default;
        Sqrt(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Sqrt(ref MpFloat result, uint operand) => Sqrt(ref result, (nuint)operand);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Sqrt(ref MpFloat result, nuint operand) =>
        Mpir.mpf_sqrt_ui(ref (result._f ??= new()).Value, operand);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Sqrt(uint operand) => Sqrt((nuint)operand);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Sqrt(nuint operand)
    {
        MpFloat result = default;
        Sqrt(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Pow(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Pow(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_pow_ui(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Pow(MpFloat operand1, uint operand2) => Pow(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Pow(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Pow(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply2Exp(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Multiply2Exp(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply2Exp(MpFloat operand1, uint operand2) => Multiply2Exp(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply2Exp(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_mul_2exp(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Multiply2Exp(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Multiply2Exp(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide2Exp(ref MpFloat result, MpFloat operand1, uint operand2) =>
        Divide2Exp(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide2Exp(MpFloat operand1, uint operand2) => Divide2Exp(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide2Exp(ref MpFloat result, MpFloat operand1, nuint operand2) =>
        Mpir.mpf_div_2exp(ref (result._f ??= new()).Value, operand1.F, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat Divide2Exp(MpFloat operand1, nuint operand2)
    {
        MpFloat result = default;
        Divide2Exp(ref result, operand1, operand2);
        return result;
    }
}
