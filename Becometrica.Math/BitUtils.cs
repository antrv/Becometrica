using System.Runtime.CompilerServices;

namespace Becometrica.Math;

public static class BitUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Conditional(bool condition, int whenTrue, int whenFalse)
    {
        int c = -Conversion.UnsafeBooleanToInt32(condition); // all bits set if true
        return (c & whenTrue) | (~c & whenFalse);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(long a, long b) =>
        Conversion.UnsafeBooleanToInt32(a > b) - Conversion.UnsafeBooleanToInt32(a < b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(ulong a, ulong b) =>
        Conversion.UnsafeBooleanToInt32(a > b) - Conversion.UnsafeBooleanToInt32(a < b);
}
