using System.Runtime.InteropServices;

namespace Becometrica.Math.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct Mpz
{
    /// <summary>
    /// Number of *limbs* allocated and pointed to by the _mp_d field.
    /// </summary>
    internal int MpAlloc;

    /// <summary>
    /// abs(_mp_size) is the number of limbs the last field points to.
    /// If _mp_size is negative this is a negative number.
    /// </summary>
    internal int MpSize;

    /// <summary>
    /// Pointer to the limbs.
    /// </summary>
    internal Ptr<nuint> MpD;
}
