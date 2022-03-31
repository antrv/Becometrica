using System.Runtime.InteropServices;

namespace Becometrica.Math.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct Mpf
{
    internal int MpPrec;
    internal int MpSize;
    internal int MpExt;
    internal Ptr<nuint> MpD;
}
