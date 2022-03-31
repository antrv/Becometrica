using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpRational
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(MpRational a, MpRational b) => Mpir.mpq_equal(a.Q, b.Q) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, MpRational b) => Mpir.mpq_cmp(a.Q, b.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, MpInteger b) => Mpir.mpq_cmp_z(a.Q, b.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, int numerator, uint denominator) =>
        Compare(a, (nint)numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, nint numerator, nuint denominator) =>
        Mpir.mpq_cmp_si(a.Q, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, long numerator, ulong denominator) => IntPtr.Size == 8
        ? Compare(a, (nint)numerator, (nuint)denominator)
        : Compare(a, new MpRational(numerator, denominator));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, uint numerator, uint denominator) =>
        Compare(a, (nuint)numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, nuint numerator, nuint denominator) =>
        Mpir.mpq_cmp_ui(a.Q, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpRational a, ulong numerator, ulong denominator) => IntPtr.Size == 8
        ? Compare(a, (nuint)numerator, (nuint)denominator)
        : Compare(a, new MpRational(numerator, denominator));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, MpRational b) => Equals(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, MpInteger b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, int b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, uint b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, nint b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, nuint b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, long b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpRational a, ulong b) => Compare(a, b, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, MpRational b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(int a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(uint a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nint a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nuint a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(long a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ulong a, MpRational b) => Compare(b, a, 1) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, MpRational b) => !Equals(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, MpInteger b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, int b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, uint b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, nint b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, nuint b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, long b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpRational a, ulong b) => Compare(a, b, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, MpRational b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(int a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(uint a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nint a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nuint a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(long a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ulong a, MpRational b) => Compare(b, a, 1) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, MpRational b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, MpInteger b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, int b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, uint b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, nint b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, nuint b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, long b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpRational a, ulong b) => Compare(a, b, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, MpRational b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(int a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(uint a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nint a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nuint a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(long a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ulong a, MpRational b) => Compare(b, a, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, MpRational b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, MpInteger b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, int b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, uint b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, nint b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, nuint b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, long b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpRational a, ulong b) => Compare(a, b, 1) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, MpRational b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(int a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(uint a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nint a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nuint a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(long a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ulong a, MpRational b) => Compare(b, a, 1) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, MpRational b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, MpInteger b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, int b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, uint b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, nint b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, nuint b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, long b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpRational a, ulong b) => Compare(a, b, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, MpRational b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(int a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(uint a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nint a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nuint a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(long a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ulong a, MpRational b) => Compare(b, a, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, MpRational b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, MpInteger b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, int b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, uint b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, nint b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, nuint b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, long b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpRational a, ulong b) => Compare(a, b, 1) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, MpRational b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(int a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(uint a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nint a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nuint a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(long a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ulong a, MpRational b) => Compare(b, a, 1) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Sign() => Mpir.mpq_sgn(Q);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is MpRational rational && Equals(this, rational);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(MpRational other) => Equals(this, other);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(MpRational other) => Compare(this, other);
}
