using System.Runtime.InteropServices;

namespace Becometrica.Math.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct Mpq
{
    internal Mpz MpNum;
    internal Mpz MpDen;
}
