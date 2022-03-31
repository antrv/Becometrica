using System.Runtime.CompilerServices;

namespace Becometrica.Math.Interop;

internal sealed class MpqGuard: IDisposable
{
    internal Mpq Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MpqGuard() => Mpir.mpq_init(ref Value);

    ~MpqGuard() => Mpir.mpq_clear(ref Value);

    public void Dispose()
    {
        Mpir.mpq_clear(ref Value);
        GC.SuppressFinalize(this);
    }
}
