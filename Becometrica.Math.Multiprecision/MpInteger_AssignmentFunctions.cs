using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpInteger value) => Mpir.mpz_set(ref (_z ??= new()).Value, value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int value) => Mpir.mpz_set_si(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(uint value) => Mpir.mpz_set_ui(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nint value) => Mpir.mpz_set_si(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nuint value) => Mpir.mpz_set_ui(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(long value) => Mpir.mpz_set_sx(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(ulong value) => Mpir.mpz_set_ux(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(double value) => Mpir.mpz_set_d(ref (_z ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpRational value) => Mpir.mpz_set_q(ref (_z ??= new()).Value, value.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpFloat value) => Mpir.mpz_set_f(ref (_z ??= new()).Value, value.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(string value, int @base = 0)
    {
        if (@base != 0 && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (Mpir.mpz_set_str(ref (_z ??= new()).Value, value, @base) != 0)
            throw new FormatException();
    }
}
