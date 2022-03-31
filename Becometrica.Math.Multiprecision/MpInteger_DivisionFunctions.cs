using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    public static void Divide(ref MpInteger quotient, MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        quotient._z ??= new();
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_q(ref quotient._z.Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_q(ref quotient._z.Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_q(ref quotient._z.Value, dividend.Z, divisor.Z);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, int divisor, DivisionRounding rounding) =>
        Divide(ref quotient, dividend, (nint)divisor, rounding);

    public static void Divide(ref MpInteger quotient, MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        Divide(ref quotient, dividend, (nuint)divisor, rounding);

    public static void Divide(ref MpInteger quotient, MpInteger dividend, nint divisor, DivisionRounding rounding)
    {
        if (divisor >= 0)
            Divide(ref quotient, dividend, (nuint)divisor, rounding);
        else
            Divide(ref quotient, dividend, (MpInteger)divisor, rounding);
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        quotient._z ??= new();
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_q_ui(ref quotient._z.Value, dividend.Z, divisor);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_q_ui(ref quotient._z.Value, dividend.Z, divisor);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_q_ui(ref quotient._z.Value, dividend.Z, divisor);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, long divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            Divide(ref quotient, dividend, (nint)divisor, rounding);
        else
            Divide(ref quotient, dividend, (MpInteger)divisor, rounding);
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            Divide(ref quotient, dividend, (nuint)divisor, rounding);
        else
            Divide(ref quotient, dividend, (MpInteger)divisor, rounding);
    }

    public static MpInteger Divide(MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        MpInteger quotient = default;
        Divide(ref quotient, dividend, divisor, rounding);
        return quotient;
    }

    public static MpInteger Divide(MpInteger dividend, int divisor, DivisionRounding rounding) =>
        Divide(dividend, (nint)divisor, rounding);

    public static MpInteger Divide(MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        Divide(dividend, (nuint)divisor, rounding);

    public static MpInteger Divide(MpInteger dividend, nint divisor, DivisionRounding rounding) => divisor >= 0
        ? Divide(dividend, (nuint)divisor, rounding)
        : Divide(dividend, (MpInteger)divisor, rounding);

    public static MpInteger Divide(MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        MpInteger quotient = default;
        Divide(ref quotient, dividend, divisor, rounding);
        return quotient;
    }

    public static MpInteger Divide(MpInteger dividend, long divisor, DivisionRounding rounding) => IntPtr.Size == 8
        ? Divide(dividend, (nint)divisor, rounding)
        : Divide(dividend, (MpInteger)divisor, rounding);

    public static MpInteger Divide(MpInteger dividend, ulong divisor, DivisionRounding rounding) => IntPtr.Size == 8
        ? Divide(dividend, (nuint)divisor, rounding)
        : Divide(dividend, (MpInteger)divisor, rounding);

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        remainder._z ??= new();
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_r(ref remainder._z.Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_r(ref remainder._z.Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_r(ref remainder._z.Value, dividend.Z, divisor.Z);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static int Remainder(ref MpInteger remainder, MpInteger dividend, int divisor, DivisionRounding rounding) =>
        (int)Remainder(ref remainder, dividend, (nint)divisor, rounding);

    public static uint Remainder(ref MpInteger remainder, MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        (uint)Remainder(ref remainder, dividend, (nuint)divisor, rounding);

    public static nint Remainder(ref MpInteger remainder, MpInteger dividend, nint divisor, DivisionRounding rounding)
    {
        if (divisor >= 0)
            return (nint)Remainder(ref remainder, dividend, (nuint)divisor, rounding);

        Remainder(ref remainder, dividend, (MpInteger)divisor, rounding);
        return (nint)remainder;
    }

    public static nuint Remainder(ref MpInteger remainder, MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        remainder._z ??= new();
        return rounding switch
        {
            DivisionRounding.ToZero => Mpir.mpz_tdiv_r_ui(ref remainder._z.Value, dividend.Z, divisor),
            DivisionRounding.ToPositiveInfinity => Mpir.mpz_cdiv_r_ui(ref remainder._z.Value, dividend.Z, divisor),
            DivisionRounding.ToNegativeInfinity => Mpir.mpz_fdiv_r_ui(ref remainder._z.Value, dividend.Z, divisor),
            _ => throw new ArgumentOutOfRangeException(nameof(rounding))
        };
    }

    public static long Remainder(ref MpInteger remainder, MpInteger dividend, long divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Remainder(ref remainder, dividend, (nint)divisor, rounding);

        Remainder(ref remainder, dividend, (MpInteger)divisor, rounding);
        return (long)remainder;
    }

    public static ulong Remainder(ref MpInteger remainder, MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Remainder(ref remainder, dividend, (nuint)divisor, rounding);

        Remainder(ref remainder, dividend, (MpInteger)divisor, rounding);
        return (ulong)remainder;
    }

    public static MpInteger Remainder(MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        MpInteger quotient = default;
        Remainder(ref quotient, dividend, divisor, rounding);
        return quotient;
    }

    public static int Remainder(MpInteger dividend, int divisor, DivisionRounding rounding) =>
        (int)Remainder(dividend, (nint)divisor, rounding);

    public static uint Remainder(MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        (uint)Remainder(dividend, (nuint)divisor, rounding);

    public static nint Remainder(MpInteger dividend, nint divisor, DivisionRounding rounding) => divisor >= 0
        ? (nint)Remainder(dividend, (nuint)divisor, rounding)
        : (nint)Remainder(dividend, (MpInteger)divisor, rounding);

    public static nuint Remainder(MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        ref Mpz nullRef = ref Unsafe.NullRef<Mpz>();
        return rounding switch
        {
            DivisionRounding.ToZero => Mpir.mpz_tdiv_r_ui(ref nullRef, dividend.Z, divisor),
            DivisionRounding.ToPositiveInfinity => Mpir.mpz_cdiv_r_ui(ref nullRef, dividend.Z, divisor),
            DivisionRounding.ToNegativeInfinity => Mpir.mpz_fdiv_r_ui(ref nullRef, dividend.Z, divisor),
            _ => throw new ArgumentOutOfRangeException(nameof(rounding))
        };
    }

    public static long Remainder(MpInteger dividend, long divisor, DivisionRounding rounding) => IntPtr.Size == 8
        ? Remainder(dividend, (nint)divisor, rounding)
        : (long)Remainder(dividend, (MpInteger)divisor, rounding);

    public static ulong Remainder(MpInteger dividend, ulong divisor, DivisionRounding rounding) => IntPtr.Size == 8
        ? Remainder(dividend, (nuint)divisor, rounding)
        : (ulong)Remainder(dividend, (MpInteger)divisor, rounding);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, MpInteger operand2)
    {
        result._z ??= new();
        Mpir.mpz_tdiv_q(ref result._z.Value, operand1.Z, operand2.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, uint operand2) =>
        Divide(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, uint operand2) => Divide(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, int operand2) =>
        Divide(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, int operand2) => Divide(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, nuint operand2)
    {
        result._z ??= new();
        Mpir.mpz_tdiv_q_ui(ref result._z.Value, operand1.Z, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        Divide(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            Divide(ref result, operand1, (nuint)operand2);
        else
            Divide(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, nint operand2) =>
        operand2 >= 0 ? Divide(operand1, (nuint)operand2) : Divide(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, operand1, (nuint)operand2);
        else
            Divide(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Divide(operand1, (nuint)operand2) : Divide(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, operand1, (nint)operand2);
        else
            Divide(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger operand1, long operand2) =>
        IntPtr.Size == 8 ? Divide(operand1, (nint)operand2) : Divide(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, MpInteger operand2)
    {
        result._z ??= new();
        Mpir.mpz_tdiv_r(ref result._z.Value, operand1.Z, operand2.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Remainder(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, uint operand2) =>
        Remainder(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, uint operand2) => Remainder(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, int operand2) =>
        Remainder(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, int operand2) => Remainder(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, nuint operand2)
    {
        result._z ??= new();
        Mpir.mpz_tdiv_r_ui(ref result._z.Value, operand1.Z, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        Remainder(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            Remainder(ref result, operand1, (nuint)operand2);
        else
            Remainder(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, nint operand2) =>
        operand2 >= 0 ? Remainder(operand1, (nuint)operand2) : Remainder(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Remainder(ref result, operand1, (nuint)operand2);
        else
            Remainder(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, ulong operand2) =>
        IntPtr.Size == 8 ? Remainder(operand1, (nuint)operand2) : Remainder(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Remainder(ref result, operand1, (nint)operand2);
        else
            Remainder(ref result, operand1, (MpInteger)operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger operand1, long operand2) =>
        IntPtr.Size == 8 ? Remainder(operand1, (nint)operand2) : Remainder(operand1, (MpInteger)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, MpInteger divisor)
    {
        quotient._z ??= new();
        remainder._z ??= new();
        Mpir.mpz_tdiv_qr(ref quotient._z.Value, ref remainder._z.Value, dividend.Z, divisor.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, MpInteger divisor)
    {
        MpInteger q = default;
        MpInteger r = default;
        DivRem(ref q, ref r, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint DivRem(ref MpInteger quotient, MpInteger dividend, uint divisor)
    {
        quotient._z ??= new();
        ref Mpz nullRef = ref default(Ptr<Mpz>).Ref;
        return (uint)Mpir.mpz_tdiv_qr_ui(ref quotient._z.Value, ref nullRef, dividend.Z, divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, uint Remainder) DivRem(MpInteger dividend, uint divisor)
    {
        MpInteger q = default;
        uint r = DivRem(ref q, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nuint DivRem(ref MpInteger quotient, MpInteger dividend, nuint divisor)
    {
        quotient._z ??= new();
        ref Mpz nullRef = ref default(Ptr<Mpz>).Ref;
        return Mpir.mpz_tdiv_qr_ui(ref quotient._z.Value, ref nullRef, dividend.Z, divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, nuint Remainder) DivRem(MpInteger dividend, nuint divisor)
    {
        MpInteger q = default;
        nuint r = DivRem(ref q, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong DivRem(ref MpInteger quotient, MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
        {
            quotient._z ??= new();
            ref Mpz nullRef = ref default(Ptr<Mpz>).Ref;
            return Mpir.mpz_tdiv_qr_ui(ref quotient._z.Value, ref nullRef, dividend.Z, (nuint)divisor);
        }
        else
        {
            MpInteger r = default;
            DivRem(ref quotient, ref r, dividend, divisor);
            return (ulong)r;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, ulong Remainder) DivRem(MpInteger dividend, ulong divisor)
    {
        MpInteger q = default;
        ulong r = DivRem(ref q, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, MpInteger divisor)
    {
        quotient._z ??= new();
        Mpir.mpz_divexact(ref quotient._z.Value, dividend.Z, divisor.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DivExact(MpInteger dividend, MpInteger divisor)
    {
        MpInteger result = default;
        DivExact(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, uint divisor) =>
        DivExact(ref quotient, dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DivExact(MpInteger dividend, uint divisor) => DivExact(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, nuint divisor)
    {
        quotient._z ??= new();
        Mpir.mpz_divexact_ui(ref quotient._z.Value, dividend.Z, divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DivExact(MpInteger dividend, nuint divisor)
    {
        MpInteger result = default;
        DivExact(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            DivExact(ref quotient, dividend, (nuint)divisor);
        else
            DivExact(ref quotient, dividend, (MpInteger)divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DivExact(MpInteger dividend, ulong divisor) => IntPtr.Size == 8
        ? DivExact(dividend, (nuint)divisor)
        : DivExact(dividend, (MpInteger)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_divisible_p(dividend.Z, divisor.Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, uint divisor) => IsDivisible(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, nuint divisor) =>
        Mpir.mpz_divisible_ui_p(dividend.Z, divisor) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, ulong divisor) => IntPtr.Size == 8
        ? IsDivisible(dividend, (nuint)divisor)
        : IsDivisible(dividend, (MpInteger)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible2Exp(MpInteger dividend, uint bitCount) => IsDivisible2Exp(dividend, (nuint)bitCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible2Exp(MpInteger dividend, nuint bitCount) =>
        Mpir.mpz_divisible_2exp_p(dividend.Z, bitCount) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent(MpInteger value1, MpInteger value2, MpInteger modulo) =>
        Mpir.mpz_congruent_p(value1.Z, value2.Z, modulo.Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent(MpInteger value1, uint value2, uint modulo) =>
        IsCongruent(value1, value2, (nuint)modulo);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent(MpInteger value1, nuint value2, nuint modulo) =>
        Mpir.mpz_congruent_ui_p(value1.Z, value2, modulo) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent(MpInteger value1, ulong value2, ulong modulo) => IntPtr.Size == 8
        ? IsCongruent(value1, (nuint)value2, (nuint)modulo)
        : IsCongruent(value1, value2, (MpInteger)modulo);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent2Exp(MpInteger value1, MpInteger value2, uint bitCount) =>
        IsCongruent2Exp(value1, value2, (nuint)bitCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent2Exp(MpInteger value1, MpInteger value2, nuint bitCount) =>
        Mpir.mpz_congruent_2exp_p(value1.Z, value2.Z, bitCount) != 0;
}
