using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Negate(ref MpInteger result, MpInteger operand) =>
        Mpir.mpz_neg(ref (result._z ??= new()).Value, operand.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Negate(MpInteger operand)
    {
        MpInteger result = default;
        Negate(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Abs(ref MpInteger result, MpInteger operand) =>
        Mpir.mpz_abs(ref (result._z ??= new()).Value, operand.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Abs(MpInteger operand)
    {
        MpInteger result = default;
        Abs(ref result, operand);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_add(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Add(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, uint operand2) =>
        Add(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, uint operand2) => Add(operand1, (nuint)operand2);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, int operand2) =>
        Add(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, int operand2) => Add(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_add_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        Add(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            Add(ref result, operand1, (nuint)operand2);
        else
            Subtract(ref result, operand1, (nuint)(-operand2));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, nint operand2) =>
        operand2 >= 0 ? Add(operand1, (nuint)operand2) : Subtract(operand1, (nuint)(-operand2));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Add(ref result, operand1, (nuint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Add(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            return Add(operand1, (nuint)operand2);

        using MpInteger temp = operand2;
        return Add(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Add(ref result, operand1, (nint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Add(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Add(MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            return Add(operand1, (nint)operand2);

        using MpInteger temp = operand2;
        return Add(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_sub(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, uint operand2) =>
        Subtract(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, uint operand2) => Subtract(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, uint operand1, MpInteger operand2) =>
        Subtract(ref result, (nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(uint operand1, MpInteger operand2) => Subtract((nuint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, int operand2) =>
        Subtract(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, int operand2) => Subtract(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, int operand1, MpInteger operand2) =>
        Subtract(ref result, (nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(int operand1, MpInteger operand2) => Subtract((nint)operand1, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_sub_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, nuint operand1, MpInteger operand2) =>
        Mpir.mpz_ui_sub(ref (result._z ??= new()).Value, operand1, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(nuint operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Subtract(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            Subtract(ref result, operand1, (nuint)operand2);
        else
            Add(ref result, operand1, (nuint)(-operand2));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, nint operand2) =>
        operand2 >= 0 ? Subtract(operand1, (nuint)operand2) : Add(operand1, (nuint)(-operand2));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, nint operand1, MpInteger operand2)
    {
        if (operand1 >= 0)
            Subtract(ref result, (nuint)operand1, operand2);
        else
        {
            using MpInteger temp = operand1;
            Subtract(ref result, temp, operand2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(nint operand1, MpInteger operand2)
    {
        if (operand1 >= 0)
            return Subtract((nuint)operand1, operand2);

        using MpInteger temp = operand1;
        return Subtract(temp, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, operand1, (nuint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Subtract(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            return Subtract(operand1, (nuint)operand2);

        using MpInteger temp = operand2;
        return Subtract(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, ulong operand1, MpInteger operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, (nuint)operand1, operand2);
        else
        {
            using MpInteger temp = operand1;
            Subtract(ref result, temp, operand2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(ulong operand1, MpInteger operand2)
    {
        if (IntPtr.Size == 8)
            return Subtract((nuint)operand1, operand2);

        using MpInteger temp = operand1;
        return Subtract(temp, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, operand1, (nint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Subtract(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            return Subtract(operand1, (nint)operand2);

        using MpInteger temp = operand2;
        return Subtract(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref MpInteger result, long operand1, MpInteger operand2)
    {
        if (IntPtr.Size == 8)
            Subtract(ref result, (nint)operand1, operand2);
        else
        {
            using MpInteger temp = operand1;
            Subtract(ref result, temp, operand2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Subtract(long operand1, MpInteger operand2)
    {
        if (IntPtr.Size == 8)
            return Subtract((nint)operand1, operand2);

        using MpInteger temp = operand1;
        return Subtract(temp, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_mul(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, uint operand2) =>
        Multiply(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, uint operand2) => Multiply(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, int operand2) =>
        Multiply(ref result, operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, int operand2) => Multiply(operand1, (nint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_mul_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, nint operand2) =>
        Mpir.mpz_mul_si(ref (result._z ??= new()).Value, operand1.Z, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, nint operand2)
    {
        MpInteger result = default;
        Multiply(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            Multiply(ref result, operand1, (nuint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Multiply(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            return Multiply(operand1, (nuint)operand2);

        using MpInteger temp = operand2;
        return Multiply(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            Multiply(ref result, operand1, (nint)operand2);
        else
        {
            using MpInteger temp = operand2;
            Multiply(ref result, operand1, temp);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Multiply(MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            return Multiply(operand1, (nint)operand2);

        using MpInteger temp = operand2;
        return Multiply(operand1, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShiftLeft(ref MpInteger result, MpInteger operand, uint bits) =>
        Mpir.mpz_mul_2exp(ref (result._z ??= new()).Value, operand.Z, bits);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger ShiftLeft(MpInteger operand, uint bits)
    {
        MpInteger result = default;
        ShiftLeft(ref result, operand, bits);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShiftRight(ref MpInteger result, MpInteger operand, uint bits) =>
        Mpir.mpz_tdiv_q_2exp(ref (result._z ??= new()).Value, operand.Z, bits);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger ShiftRight(MpInteger operand, uint bits)
    {
        MpInteger result = default;
        ShiftRight(ref result, operand, bits);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShiftLeft(ref MpInteger result, MpInteger operand, int bits)
    {
        if (bits >= 0)
            ShiftLeft(ref result, operand, (uint)bits);
        else
            ShiftRight(ref result, operand, (uint)-bits);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger ShiftLeft(MpInteger operand, int bits) =>
        bits >= 0 ? ShiftLeft(operand, (uint)bits) : ShiftRight(operand, (uint)-bits);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShiftRight(ref MpInteger result, MpInteger operand, int bits)
    {
        if (bits >= 0)
            ShiftRight(ref result, operand, (uint)bits);
        else
            ShiftLeft(ref result, operand, (uint)-bits);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger ShiftRight(MpInteger value, int bits) =>
        bits >= 0 ? ShiftRight(value, (uint)bits) : ShiftLeft(value, (uint)-bits);

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_addmul(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, uint operand2) =>
        AddMultiply(ref result, operand1, (nuint)operand2);

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, int operand2) =>
        AddMultiply(ref result, operand1, (nint)operand2);

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_addmul_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            AddMultiply(ref result, operand1, (nuint)operand2);
        else
            SubtractMultiply(ref result, operand1, (nuint)(-operand2));
    }

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            AddMultiply(ref result, operand1, (nuint)operand2);
        else
        {
            using MpInteger temp = operand2;
            AddMultiply(ref result, operand1, temp);
        }
    }

    /// <summary>
    /// Set result to result + operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddMultiply(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            AddMultiply(ref result, operand1, (nint)operand2);
        else
        {
            using MpInteger temp = operand2;
            AddMultiply(ref result, operand1, temp);
        }
    }

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_submul(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, uint operand2) =>
        SubtractMultiply(ref result, operand1, (nuint)operand2);

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, int operand2) =>
        SubtractMultiply(ref result, operand1, (nint)operand2);

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_submul_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, nint operand2)
    {
        if (operand2 >= 0)
            SubtractMultiply(ref result, operand1, (nuint)operand2);
        else
            AddMultiply(ref result, operand1, (nuint)(-operand2));
    }

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, ulong operand2)
    {
        if (IntPtr.Size == 8)
            SubtractMultiply(ref result, operand1, (nuint)operand2);
        else
        {
            using MpInteger temp = operand2;
            SubtractMultiply(ref result, operand1, temp);
        }
    }

    /// <summary>
    /// Set result to result - operand1 * operand2.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="operand1"></param>
    /// <param name="operand2"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SubtractMultiply(ref MpInteger result, MpInteger operand1, long operand2)
    {
        if (IntPtr.Size == 8)
            SubtractMultiply(ref result, operand1, (nint)operand2);
        else
        {
            using MpInteger temp = operand2;
            SubtractMultiply(ref result, operand1, temp);
        }
    }
}
