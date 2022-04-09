using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

public partial struct MpRational: IEquatable<MpRational>, IComparable, IComparable<MpRational>, IDisposable
{
    private static readonly MpqGuard _zero = new();
    private MpqGuard? _q;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(int numerator, uint denominator) =>
        Mpir.mpq_set_si(ref (_q = new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(nint numerator, nuint denominator) =>
        Mpir.mpq_set_si(ref (_q = new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(uint numerator, uint denominator) =>
        Mpir.mpq_set_ui(ref (_q = new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(nuint numerator, nuint denominator) =>
        Mpir.mpq_set_ui(ref (_q = new()).Value, numerator, denominator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(long numerator, ulong denominator)
    {
        if (IntPtr.Size == 8)
            Mpir.mpq_set_si(ref (_q = new()).Value, (nint)numerator, (nuint)denominator);
        else
        {
            Mpir.mpz_set_sx(ref (_q = new()).Value.MpNum, numerator);
            Mpir.mpz_set_ux(ref _q.Value.MpDen, denominator);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(ulong numerator, ulong denominator)
    {
        if (IntPtr.Size == 8)
            Mpir.mpq_set_ui(ref (_q = new()).Value, (nuint)numerator, (nuint)denominator);
        else
        {
            Mpir.mpz_set_ux(ref (_q = new()).Value.MpNum, numerator);
            Mpir.mpz_set_ux(ref _q.Value.MpDen, denominator);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(double value) => Mpir.mpq_set_d(ref (_q = new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(MpInteger value) => Mpir.mpq_set_z(ref (_q = new()).Value, value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(MpInteger numerator, MpInteger denominator)
    {
        Mpir.mpz_set(ref (_q = new()).Value.MpNum, numerator.Z);
        Mpir.mpz_set(ref _q.Value.MpDen, denominator.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(MpRational value) => Mpir.mpq_set(ref (_q = new()).Value, value.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational(MpFloat value) => Mpir.mpq_set_f(ref (_q = new()).Value, value.F);

    internal ref readonly Mpq Q => ref (_q ?? _zero).Value;

    public static MpRational Parse(string str, int @base = 0)
    {
        if (@base != 0 && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        MpRational result = default;
        if (Mpir.mpq_set_str(ref (result._q = new()).Value, str, @base) != 0)
            throw new FormatException();

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(int a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(uint a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(nint a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(nuint a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(long a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(ulong a) => new(a, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(double a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpRational(MpInteger a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator MpRational(MpFloat a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(MpRational a) => a.ToInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(MpRational a) => a.ToUInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(MpRational a) => a.ToNativeInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(MpRational a) => a.ToNativeUInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(MpRational a) => a.ToInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ulong(MpRational a) => a.ToUInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator double(MpRational a) => a.ToDouble();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator +(MpRational a) => a;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator -(MpRational a) => Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator +(MpRational a, MpRational b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator -(MpRational a, MpRational b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator *(MpRational a, MpRational b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpRational operator /(MpRational a, MpRational b) => Divide(a, b);

    /// <inheritdoc />
    public override int GetHashCode() => ToInt32();

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => ToString(10);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpRational Copy() => new(this);

    /// <inheritdoc />
    public void Dispose()
    {
        MpqGuard? guard = _q;
        _q = null;
        guard?.Dispose();
    }
}
