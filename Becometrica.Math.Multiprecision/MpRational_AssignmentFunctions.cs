using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpRational
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpInteger value) => Mpir.mpq_set_z(ref (_q ??= new()).Value, value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int numerator, uint denominator) => Set((nint)numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(uint numerator, uint denominator) => Set((nuint)numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nint numerator, nuint denominator) =>
        Mpir.mpq_set_si(ref (_q ??= new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nuint numerator, nuint denominator) =>
        Mpir.mpq_set_ui(ref (_q ??= new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(long numerator, ulong denominator)
    {
        if (IntPtr.Size == 8)
            Set((nint)numerator, (nuint)denominator);
        else
        {
            Mpir.mpz_set_sx(ref (_q ??= new()).Value.MpNum, numerator);
            Mpir.mpz_set_ux(ref _q.Value.MpDen, denominator);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(ulong numerator, ulong denominator)
    {
        if (IntPtr.Size == 8)
            Set((nuint)numerator, (nuint)denominator);
        else
        {
            Mpir.mpz_set_ux(ref (_q ??= new()).Value.MpNum, numerator);
            Mpir.mpz_set_ux(ref _q.Value.MpDen, denominator);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(double value) => Mpir.mpq_set_d(ref (_q ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpRational value) => Mpir.mpq_set(ref (_q ??= new()).Value, value.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpFloat value) => Mpir.mpq_set_f(ref (_q ??= new()).Value, value.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(string value, int @base = 0)
    {
        if (@base != 0 && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (Mpir.mpq_set_str(ref (_q ??= new()).Value, value, @base) != 0)
            throw new FormatException();
    }
}
