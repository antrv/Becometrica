using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    public static void Divide(ref MpInteger quotient, MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_q(ref (quotient._z ??= new()).Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_q(ref (quotient._z ??= new()).Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_q(ref (quotient._z ??= new()).Value, dividend.Z, divisor.Z);
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
        {
            using MpInteger temp = divisor;
            Divide(ref quotient, dividend, temp, rounding);
        }
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_q_ui(ref (quotient._z ??= new()).Value, dividend.Z, divisor);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_q_ui(ref (quotient._z ??= new()).Value, dividend.Z, divisor);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_q_ui(ref (quotient._z ??= new()).Value, dividend.Z, divisor);
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
        {
            using MpInteger temp = divisor;
            Divide(ref quotient, dividend, temp, rounding);
        }
    }

    public static void Divide(ref MpInteger quotient, MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            Divide(ref quotient, dividend, (nuint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            Divide(ref quotient, dividend, temp, rounding);
        }
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

    public static MpInteger Divide(MpInteger dividend, nint divisor, DivisionRounding rounding)
    {
        if (divisor >= 0)
            return Divide(dividend, (nuint)divisor, rounding);

        using MpInteger temp = divisor;
        return Divide(dividend, temp, rounding);
    }

    public static MpInteger Divide(MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        MpInteger quotient = default;
        Divide(ref quotient, dividend, divisor, rounding);
        return quotient;
    }

    public static MpInteger Divide(MpInteger dividend, long divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Divide(dividend, (nint)divisor, rounding);

        using MpInteger temp = divisor;
        return Divide(dividend, temp, rounding);
    }

    public static MpInteger Divide(MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Divide(dividend, (nuint)divisor, rounding);

        using MpInteger temp = divisor;
        return Divide(dividend, temp, rounding);
    }

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_r(ref (remainder._z ??= new()).Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_r(ref (remainder._z ??= new()).Value, dividend.Z, divisor.Z);
                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_r(ref (remainder._z ??= new()).Value, dividend.Z, divisor.Z);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, int divisor, DivisionRounding rounding) =>
        Remainder(ref remainder, dividend, (nint)divisor, rounding);

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        Remainder(ref remainder, dividend, (nuint)divisor, rounding);

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, nint divisor, DivisionRounding rounding)
    {
        if (divisor >= 0)
            Remainder(ref remainder, dividend, (nuint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref remainder, dividend, temp, rounding);
        }
    }

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_r_ui(ref (remainder._z ??= new()).Value, dividend.Z, divisor);
                return;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_r_ui(ref (remainder._z ??= new()).Value, dividend.Z, divisor);
                return;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_r_ui(ref (remainder._z ??= new()).Value, dividend.Z, divisor);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, long divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            Remainder(ref remainder, dividend, (nint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref remainder, dividend, temp, rounding);
        }
    }

    public static void Remainder(ref MpInteger remainder, MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            Remainder(ref remainder, dividend, (nuint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref remainder, dividend, temp, rounding);
        }
    }

    public static MpInteger Remainder(MpInteger dividend, MpInteger divisor, DivisionRounding rounding)
    {
        MpInteger remainder = default;
        Remainder(ref remainder, dividend, divisor, rounding);
        return remainder;
    }

    public static MpInteger Remainder(MpInteger dividend, int divisor, DivisionRounding rounding) =>
        Remainder(dividend, (nint)divisor, rounding);

    public static MpInteger Remainder(MpInteger dividend, uint divisor, DivisionRounding rounding) =>
        Remainder(dividend, (nuint)divisor, rounding);

    public static MpInteger Remainder(MpInteger dividend, nint divisor, DivisionRounding rounding)
    {
        if (divisor >= 0)
            return Remainder(dividend, (nuint)divisor, rounding);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp, rounding);
    }

    public static MpInteger Remainder(MpInteger dividend, nuint divisor, DivisionRounding rounding)
    {
        MpInteger remainder = default;
        Remainder(ref remainder, dividend, divisor, rounding);
        return remainder;
    }

    public static MpInteger Remainder(MpInteger dividend, long divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Remainder(dividend, (nint)divisor, rounding);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp, rounding);
    }

    public static MpInteger Remainder(MpInteger dividend, ulong divisor, DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            return Remainder(dividend, (nuint)divisor, rounding);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp, rounding);
    }

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, MpInteger divisor,
        DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_qr(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor.Z);

                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_qr(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor.Z);

                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_qr(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor.Z);

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, MpInteger divisor,
        DivisionRounding rounding)
    {
        MpInteger quotient = default;
        MpInteger remainder = default;
        DivRem(ref quotient, ref remainder, dividend, divisor, rounding);
        return (quotient, remainder);
    }

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, int divisor,
        DivisionRounding rounding) => DivRem(ref quotient, ref remainder, dividend, (nint)divisor, rounding);

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, nint divisor,
        DivisionRounding rounding)
    {
        if (divisor >= 0)
            DivRem(ref quotient, ref remainder, dividend, (nuint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            DivRem(ref quotient, ref remainder, dividend, temp, rounding);
        }
    }

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, long divisor,
        DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            DivRem(ref quotient, ref remainder, dividend, (nint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            DivRem(ref quotient, ref remainder, dividend, temp, rounding);
        }
    }

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, uint divisor,
        DivisionRounding rounding) => DivRem(ref quotient, ref remainder, dividend, (nuint)divisor, rounding);

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, nuint divisor,
        DivisionRounding rounding)
    {
        switch (rounding)
        {
            case DivisionRounding.ToZero:
                Mpir.mpz_tdiv_qr_ui(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor);

                break;
            case DivisionRounding.ToPositiveInfinity:
                Mpir.mpz_cdiv_qr_ui(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor);

                break;
            case DivisionRounding.ToNegativeInfinity:
                Mpir.mpz_fdiv_qr_ui(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z,
                    divisor);

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rounding));
        }
    }

    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, ulong divisor,
        DivisionRounding rounding)
    {
        if (IntPtr.Size == 8)
            DivRem(ref quotient, ref remainder, dividend, (nuint)divisor, rounding);
        else
        {
            using MpInteger temp = divisor;
            DivRem(ref quotient, ref remainder, dividend, temp, rounding);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_tdiv_q(ref (result._z ??= new()).Value, dividend.Z, divisor.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, MpInteger divisor)
    {
        MpInteger result = default;
        Divide(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, uint divisor) =>
        Divide(ref result, dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, uint divisor) => Divide(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, int divisor) =>
        Divide(ref result, dividend, (nint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, int divisor) => Divide(dividend, (nint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, nuint divisor) =>
        Mpir.mpz_tdiv_q_ui(ref (result._z ??= new()).Value, dividend.Z, divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, nuint divisor)
    {
        MpInteger result = default;
        Divide(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, nint divisor)
    {
        if (divisor >= 0)
            Divide(ref result, dividend, (nuint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Divide(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, nint divisor)
    {
        if (divisor >= 0)
            return Divide(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return Divide(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, dividend, (nuint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Divide(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            return Divide(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return Divide(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref MpInteger result, MpInteger dividend, long divisor)
    {
        if (IntPtr.Size == 8)
            Divide(ref result, dividend, (nint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Divide(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Divide(MpInteger dividend, long divisor)
    {
        if (IntPtr.Size == 8)
            return Divide(dividend, (nint)divisor);

        using MpInteger temp = divisor;
        return Divide(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_tdiv_r(ref (result._z ??= new()).Value, dividend.Z, divisor.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, MpInteger divisor)
    {
        MpInteger result = default;
        Remainder(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, uint divisor) =>
        Remainder(ref result, dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, uint divisor) => Remainder(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, int divisor) =>
        Remainder(ref result, dividend, (nint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, int divisor) => Remainder(dividend, (nint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, nuint divisor) =>
        Mpir.mpz_tdiv_r_ui(ref (result._z ??= new()).Value, dividend.Z, divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, nuint divisor)
    {
        MpInteger result = default;
        Remainder(ref result, dividend, divisor);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, nint divisor)
    {
        if (divisor >= 0)
            Remainder(ref result, dividend, (nuint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, nint divisor)
    {
        if (divisor >= 0)
            return Remainder(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            Remainder(ref result, dividend, (nuint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            return Remainder(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Remainder(ref MpInteger result, MpInteger dividend, long divisor)
    {
        if (IntPtr.Size == 8)
            Remainder(ref result, dividend, (nint)divisor);
        else
        {
            using MpInteger temp = divisor;
            Remainder(ref result, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Remainder(MpInteger dividend, long divisor)
    {
        if (IntPtr.Size == 8)
            return Remainder(dividend, (nint)divisor);

        using MpInteger temp = divisor;
        return Remainder(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_tdiv_qr(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z, divisor.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, MpInteger divisor)
    {
        MpInteger q = default;
        MpInteger r = default;
        DivRem(ref q, ref r, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, uint divisor) =>
        DivRem(ref quotient, ref remainder, dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, uint divisor) =>
        DivRem(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, nuint divisor) =>
        Mpir.mpz_tdiv_qr_ui(ref (quotient._z ??= new()).Value, ref (remainder._z ??= new()).Value, dividend.Z, divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, nuint divisor)
    {
        MpInteger q = default;
        MpInteger r = default;
        DivRem(ref q, ref r, dividend, divisor);
        return (q, r);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivRem(ref MpInteger quotient, ref MpInteger remainder, MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            DivRem(ref quotient, ref remainder, dividend, (nuint)divisor);
        else
        {
            using MpInteger temp = divisor;
            DivRem(ref quotient, ref remainder, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Quotient, MpInteger Remainder) DivRem(MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            return DivRem(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return DivRem(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_divexact(ref (quotient._z ??= new()).Value, dividend.Z, divisor.Z);

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
    public static void DivExact(ref MpInteger quotient, MpInteger dividend, nuint divisor) =>
        Mpir.mpz_divexact_ui(ref (quotient._z ??= new()).Value, dividend.Z, divisor);

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
        {
            using MpInteger temp = divisor;
            DivExact(ref quotient, dividend, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DivExact(MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            return DivExact(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return DivExact(dividend, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, MpInteger divisor) =>
        Mpir.mpz_divisible_p(dividend.Z, divisor.Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, uint divisor) => IsDivisible(dividend, (nuint)divisor);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, nuint divisor) =>
        Mpir.mpz_divisible_ui_p(dividend.Z, divisor) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisible(MpInteger dividend, ulong divisor)
    {
        if (IntPtr.Size == 8)
            return IsDivisible(dividend, (nuint)divisor);

        using MpInteger temp = divisor;
        return IsDivisible(dividend, temp);
    }

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
    public static bool IsCongruent(MpInteger value1, ulong value2, ulong modulo)
    {
        if (IntPtr.Size == 8)
            return IsCongruent(value1, (nuint)value2, (nuint)modulo);

        using MpInteger temp2 = value2;
        using MpInteger tempM = modulo;
        return IsCongruent(value1, temp2, tempM);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent2Exp(MpInteger value1, MpInteger value2, uint bitCount) =>
        IsCongruent2Exp(value1, value2, (nuint)bitCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCongruent2Exp(MpInteger value1, MpInteger value2, nuint bitCount) =>
        Mpir.mpz_congruent_2exp_p(value1.Z, value2.Z, bitCount) != 0;
}
