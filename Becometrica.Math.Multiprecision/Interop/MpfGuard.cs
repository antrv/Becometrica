using System.Runtime.CompilerServices;

namespace Becometrica.Math.Interop;

internal sealed class MpfGuard: IDisposable
{
    internal Mpf Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard() => Mpir.mpf_init(ref Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard(uint precision) => Mpir.mpf_init2(ref Value, precision);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard(in Mpf value) => Mpir.mpf_init_set(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard(double value) => Mpir.mpf_init_set_d(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard(nuint value) => Mpir.mpf_init_set_ui(ref Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpfGuard(nint value) => Mpir.mpf_init_set_si(ref Value, value);

    ~MpfGuard() => Mpir.mpf_clear(ref Value);

    public void Dispose()
    {
        Mpir.mpf_clear(ref Value);
        GC.SuppressFinalize(this);
    }
}
