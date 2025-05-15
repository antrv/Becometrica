namespace Becometrica.Unsafe;

internal static class Utils
{
    internal static string ToHexString(nint ptr) => "0x" + ptr.ToString(nint.Size == 4 ? "x8" : "x16");
}