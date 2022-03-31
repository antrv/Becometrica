using System.Runtime.CompilerServices;

namespace Becometrica.Math.Interop;

internal sealed class MpzGuard: IDisposable
{
    internal Mpz Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard() => Mpir.mpz_init(ref Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(int value) => Mpir.mpz_init_set_si(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(uint value) => Mpir.mpz_init_set_ui(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(nint value) => Mpir.mpz_init_set_si(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(nuint value) => Mpir.mpz_init_set_ui(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(long value) => Mpir.mpz_init_set_sx(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(ulong value) => Mpir.mpz_init_set_ux(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(double value) => Mpir.mpz_init_set_d(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpzGuard(in Mpz value) => Mpir.mpz_init_set(ref Value, value);

    ~MpzGuard() => Mpir.mpz_clear(ref Value);

    public void Dispose()
    {
        Mpir.mpz_clear(ref Value);
        GC.SuppressFinalize(this);
    }
}
