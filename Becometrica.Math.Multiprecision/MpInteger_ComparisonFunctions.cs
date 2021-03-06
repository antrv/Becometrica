using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpInteger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, MpInteger b) => Mpir.mpz_cmp(a.Z, b.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, double b) => Mpir.mpz_cmp_d(a.Z, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, int b) => Compare(a, (nint)b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, nint b) => Mpir.mpz_cmp_si(a.Z, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, long b)
    {
        if (IntPtr.Size == 8)
            return Compare(a, (nint)b);

        using MpInteger temp = b;
        return Compare(a, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, uint b) => Compare(a, (nuint)b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, nuint b) => Mpir.mpz_cmp_ui(a.Z, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(MpInteger a, ulong b)
    {
        if (IntPtr.Size == 8)
            return Compare(a, (nuint)b);

        using MpInteger temp = b;
        return Compare(a, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, MpInteger b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, int b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, uint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, nint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, nuint b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, long b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, ulong b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(MpInteger a, double b) => Compare(a, b) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(int a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(uint a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nint a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(nuint a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(long a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ulong a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(double a, MpInteger b) => Compare(b, a) == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, MpInteger b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, int b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, uint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, nint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, nuint b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, long b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, ulong b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(MpInteger a, double b) => Compare(a, b) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(int a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(uint a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nint a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(nuint a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(long a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ulong a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(double a, MpInteger b) => Compare(b, a) != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, MpInteger b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, int b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, uint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, nint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, nuint b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, long b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, ulong b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(MpInteger a, double b) => Compare(a, b) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(int a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(uint a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nint a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(nuint a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(long a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ulong a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(double a, MpInteger b) => Compare(b, a) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, MpInteger b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, int b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, uint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, nint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, nuint b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, long b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, ulong b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(MpInteger a, double b) => Compare(a, b) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(int a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(uint a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nint a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(nuint a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(long a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ulong a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(double a, MpInteger b) => Compare(b, a) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, MpInteger b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, int b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, uint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, nint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, nuint b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, long b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, ulong b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(MpInteger a, double b) => Compare(a, b) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(int a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(uint a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nint a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(nuint a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(long a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ulong a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(double a, MpInteger b) => Compare(b, a) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, MpInteger b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, int b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, uint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, nint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, nuint b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, long b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, ulong b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(MpInteger a, double b) => Compare(a, b) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(int a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(uint a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nint a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(nuint a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(long a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ulong a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(double a, MpInteger b) => Compare(b, a) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareAbs(MpInteger a, MpInteger b) => Mpir.mpz_cmpabs(a.Z, b.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareAbs(MpInteger a, double b) => Mpir.mpz_cmpabs_d(a.Z, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareAbs(MpInteger a, uint b) => CompareAbs(a, (nuint)b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareAbs(MpInteger a, nuint b) => Mpir.mpz_cmpabs_ui(a.Z, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareAbs(MpInteger a, ulong b)
    {
        if (IntPtr.Size == 8)
            return CompareAbs(a, (nuint)b);

        using MpInteger temp = b;
        return CompareAbs(a, temp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Sign() => Mpir.mpz_sgn(Z);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is MpInteger integer && integer == this;

    /// <inheritdoc />
    public int CompareTo(object? obj)
    {
        if (obj is MpInteger i)
            return CompareTo(i);

        throw new ArgumentException("Argument must be " + nameof(MpInteger), nameof(obj));
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(MpInteger other) => other == this;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(MpInteger other) => Compare(this, other);
}
