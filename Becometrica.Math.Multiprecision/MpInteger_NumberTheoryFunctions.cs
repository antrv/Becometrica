using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreatestCommonDivisor(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_gcd(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger GreatestCommonDivisor(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        GreatestCommonDivisor(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint GreatestCommonDivisor(MpInteger operand1, uint operand2) =>
        (uint)GreatestCommonDivisor(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nuint GreatestCommonDivisor(MpInteger operand1, nuint operand2)
    {
        ref Mpz nullPtr = ref default(Ptr<Mpz>).Ref;
        return Mpir.mpz_gcd_ui(ref nullPtr, operand1.Z, operand2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GreatestCommonDivisorExtended(ref MpInteger result, ref MpInteger operand1Factor,
        ref MpInteger operand2Factor, MpInteger operand1, MpInteger operand2) => Mpir.mpz_gcdext(
        ref (result._z ??= new()).Value, ref (operand1Factor._z ??= new()).Value,
        ref (operand2Factor._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Gcd, MpInteger Op1Factor, MpInteger Op2Factor) GreatestCommonDivisorExtended(
        MpInteger operand1, MpInteger operand2)
    {
        MpInteger gcd = default;
        MpInteger op1Factor = default;
        MpInteger op2Factor = default;
        GreatestCommonDivisorExtended(ref gcd, ref op1Factor, ref op2Factor, operand1, operand2);
        return (gcd, op1Factor, op2Factor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LeastCommonFactor(ref MpInteger result, MpInteger operand1, MpInteger operand2) =>
        Mpir.mpz_lcm(ref (result._z ??= new()).Value, operand1.Z, operand2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger LeastCommonFactor(MpInteger operand1, MpInteger operand2)
    {
        MpInteger result = default;
        LeastCommonFactor(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LeastCommonFactor(ref MpInteger result, MpInteger operand1, uint operand2) =>
        LeastCommonFactor(ref result, operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger LeastCommonFactor(MpInteger operand1, uint operand2) =>
        LeastCommonFactor(operand1, (nuint)operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LeastCommonFactor(ref MpInteger result, MpInteger operand1, nuint operand2) =>
        Mpir.mpz_lcm_ui(ref (result._z ??= new()).Value, operand1.Z, operand2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger LeastCommonFactor(MpInteger operand1, nuint operand2)
    {
        MpInteger result = default;
        LeastCommonFactor(ref result, operand1, operand2);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(ref MpInteger result, MpInteger value, MpInteger modulo) =>
        Mpir.mpz_invert(ref (result._z ??= new()).Value, value.Z, modulo.Z) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Invert(MpInteger value, MpInteger modulo)
    {
        MpInteger result = default;
        Invert(ref result, value, modulo);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Jacobi(MpInteger value1, MpInteger value2) => Mpir.mpz_jacobi(value1.Z, value2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Legendre(MpInteger value, MpInteger prime) => Mpir.mpz_legendre(value.Z, prime.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, MpInteger value2) => Mpir.mpz_kronecker(value1.Z, value2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, int value2) => Kronecker(value1, (nint)value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, nint value2) => Mpir.mpz_kronecker_si(value1.Z, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, long value2) =>
        IntPtr.Size == 8 ? Kronecker(value1, (nint)value2) : Kronecker(value1, (MpInteger)value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, uint value2) => Kronecker(value1, (nuint)value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, nuint value2) => Mpir.mpz_kronecker_ui(value1.Z, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(MpInteger value1, ulong value2) =>
        IntPtr.Size == 8 ? Kronecker(value1, (nuint)value2) : Kronecker(value1, (MpInteger)value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(int value1, MpInteger value2) => Kronecker((nint)value1, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(nint value1, MpInteger value2) => Mpir.mpz_si_kronecker(value1, value2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(long value1, MpInteger value2) =>
        IntPtr.Size == 8 ? Kronecker((nint)value1, value2) : Kronecker((MpInteger)value1, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(uint value1, MpInteger value2) => Kronecker((nuint)value1, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(nuint value1, MpInteger value2) => Mpir.mpz_ui_kronecker(value1, value2.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Kronecker(ulong value1, MpInteger value2) =>
        IntPtr.Size == 8 ? Kronecker((nuint)value1, value2) : Kronecker((MpInteger)value1, value2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint RemoveFactor(ref MpInteger result, MpInteger operand, MpInteger factor) =>
        (uint)Mpir.mpz_remove(ref (result._z ??= new()).Value, operand.Z, factor.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Factorial(ref MpInteger result, uint n) => Factorial(ref result, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Factorial(ref MpInteger result, nuint n) => Mpir.mpz_fac_ui(ref (result._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Factorial(uint n) => Factorial((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Factorial(nuint n)
    {
        MpInteger result = default;
        Factorial(ref result, n);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DoubleFactorial(ref MpInteger result, uint n) => DoubleFactorial(ref result, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DoubleFactorial(ref MpInteger result, nuint n) =>
        Mpir.mpz_2fac_ui(ref (result._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DoubleFactorial(uint n) => DoubleFactorial((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger DoubleFactorial(nuint n)
    {
        MpInteger result = default;
        DoubleFactorial(ref result, n);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MultiFactorial(ref MpInteger result, uint n, uint m) => MultiFactorial(ref result, (nuint)n, m);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MultiFactorial(ref MpInteger result, nuint n, nuint m) =>
        Mpir.mpz_mfac_uiui(ref (result._z ??= new()).Value, n, m);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger MultiFactorial(uint n, uint m) => MultiFactorial((nuint)n, m);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger MultiFactorial(nuint n, nuint m)
    {
        MpInteger result = default;
        MultiFactorial(ref result, n, m);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Primorial(ref MpInteger result, uint n) => Primorial(ref result, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Primorial(ref MpInteger result, nuint n) =>
        Mpir.mpz_primorial_ui(ref (result._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Primorial(uint n) => Primorial((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Primorial(nuint n)
    {
        MpInteger result = default;
        Primorial(ref result, n);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Binomial(ref MpInteger result, MpInteger n, uint k) => Binomial(ref result, n, (nuint)k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Binomial(ref MpInteger result, MpInteger n, nuint k) =>
        Mpir.mpz_bin_ui(ref (result._z ??= new()).Value, n.Z, k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Binomial(MpInteger n, uint k) => Binomial(n, (nuint)k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Binomial(MpInteger n, nuint k)
    {
        MpInteger result = default;
        Binomial(ref result, n, k);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Binomial(ref MpInteger result, uint n, uint k) => Binomial(ref result, n, (nuint)k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Binomial(ref MpInteger result, nuint n, nuint k) =>
        Mpir.mpz_bin_uiui(ref (result._z ??= new()).Value, n, k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Binomial(uint n, uint k) => Binomial(n, (nuint)k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Binomial(nuint n, nuint k)
    {
        MpInteger result = default;
        Binomial(ref result, n, k);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fibonacci(ref MpInteger fn, uint n) => Fibonacci(ref fn, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fibonacci(ref MpInteger fn, nuint n) => Mpir.mpz_fib_ui(ref (fn._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Fibonacci(uint n) => Fibonacci((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Fibonacci(nuint n)
    {
        MpInteger result = default;
        Fibonacci(ref result, n);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fibonacci2(ref MpInteger fn, ref MpInteger fnsub1, uint n) =>
        Fibonacci2(ref fn, ref fnsub1, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fibonacci2(ref MpInteger fn, ref MpInteger fnsub1, nuint n) =>
        Mpir.mpz_fib2_ui(ref (fn._z ??= new()).Value, ref (fnsub1._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Fn, MpInteger FnSub1) Fibonacci2(uint n) => Fibonacci2((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Fn, MpInteger FnSub1) Fibonacci2(nuint n)
    {
        MpInteger fn = default;
        MpInteger fnsub1 = default;
        Fibonacci2(ref fn, ref fnsub1, n);
        return (fn, fnsub1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Lucas(ref MpInteger ln, uint n) => Lucas(ref ln, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Lucas(ref MpInteger ln, nuint n) => Mpir.mpz_lucnum_ui(ref (ln._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Lucas(uint n) => Lucas((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger Lucas(nuint n)
    {
        MpInteger ln = default;
        Lucas(ref ln, n);
        return ln;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Lucas2(ref MpInteger ln, ref MpInteger lnsub1, uint n) =>
        Lucas2(ref ln, ref lnsub1, (nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Lucas2(ref MpInteger ln, ref MpInteger lnsub1, nuint n) =>
        Mpir.mpz_lucnum2_ui(ref (ln._z ??= new()).Value, ref (lnsub1._z ??= new()).Value, n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Ln, MpInteger LnSub1) Lucas2(uint n) => Lucas2((nuint)n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (MpInteger Ln, MpInteger LnSub1) Lucas2(nuint n)
    {
        MpInteger ln = default;
        MpInteger lnsub1 = default;
        Lucas2(ref ln, ref lnsub1, n);
        return (ln, lnsub1);
    }
}
