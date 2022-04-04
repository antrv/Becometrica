using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpFloat
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, MpFloat b) => Mpir.mpf_cmp(a.F, b.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, double b) => Mpir.mpf_cmp_d(a.F, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, int b) => Compare(a, (nint)b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, nint b) => Mpir.mpf_cmp_si(a.F, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, long b)
    {
        if (IntPtr.Size == 8)
            return Compare(a, (nint)b);

        using MpFloat temp = b;
        return Compare(a, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, uint b) => Compare(a, (nuint)b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, nuint b) => Mpir.mpf_cmp_ui(a.F, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpFloat a, ulong b)
    {
        if (IntPtr.Size == 8)
            return Compare(a, (nuint)b);

        using MpFloat temp = b;
        return Compare(a, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, MpFloat b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, int b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, uint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, nint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, nuint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, long b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, ulong b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpFloat a, double b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(int a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(uint a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nint a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nuint a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(long a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ulong a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(double a, MpFloat b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, MpFloat b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, int b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, uint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, nint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, nuint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, long b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, ulong b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpFloat a, double b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(int a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(uint a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nint a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nuint a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(long a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ulong a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(double a, MpFloat b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, MpFloat b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, int b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, uint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, nint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, nuint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, long b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, ulong b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpFloat a, double b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(int a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(uint a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nint a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nuint a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(long a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ulong a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(double a, MpFloat b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, MpFloat b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, int b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, uint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, nint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, nuint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, long b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, ulong b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpFloat a, double b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(int a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(uint a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nint a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nuint a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(long a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ulong a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(double a, MpFloat b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, MpFloat b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, int b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, uint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, nint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, nuint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, long b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, ulong b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpFloat a, double b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(int a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(uint a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nint a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nuint a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(long a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ulong a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(double a, MpFloat b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, MpFloat b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, int b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, uint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, nint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, nuint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, long b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, ulong b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpFloat a, double b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(int a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(uint a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nint a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nuint a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(long a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ulong a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(double a, MpFloat b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Sign() => Mpir.mpf_sgn(F);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is MpFloat value && value == this;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(MpFloat other) => other == this;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(MpFloat other) => Compare(this, other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(MpFloat a, MpFloat b, uint precision) => Mpir.mpf_eq(a.F, b.F, precision) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RelativeDifference(ref MpFloat result, MpFloat operand1, MpFloat operand2) =>
        Mpir.mpf_reldiff(ref (result._f ??= new()).Value, operand1.F, operand2.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat RelativeDifference(MpFloat operand1, MpFloat operand2)
    {
        MpFloat result = default;
        RelativeDifference(ref result, operand1, operand2);
        return result;
    }
}
