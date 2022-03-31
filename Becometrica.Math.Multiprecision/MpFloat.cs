using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

public partial struct MpFloat: IEquatable<MpFloat>, IComparable<MpFloat>, IDisposable
{
    private static readonly MpfGuard _zero = new();
    private MpfGuard? _f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(Precision precision) => _f = new(precision.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(MpFloat value) => _f = new(value.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(int value) => _f = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(uint value) => _f = new((nuint)value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(nint value) => _f = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(nuint value) => _f = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(long value)
    {
        if (IntPtr.Size == 8)
            _f = new((nint)value);
        else
        {
            Mpz z = default;
            Mpir.mpz_init_set_sx(ref z, value);
            try
            {
                Mpir.mpf_set_z(ref (_f = new()).Value, z);
            }
            finally
            {
                Mpir.mpz_clear(ref z);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(ulong value)
    {
        if (IntPtr.Size == 8)
            _f = new((nint)value);
        else
        {
            Mpz z = default;
            Mpir.mpz_init_set_ux(ref z, value);
            try
            {
                Mpir.mpf_set_z(ref (_f = new()).Value, z);
            }
            finally
            {
                Mpir.mpz_clear(ref z);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(double value) => _f = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(MpInteger value) => Mpir.mpf_set_z(ref (_f = new()).Value, value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat(MpRational value) => Mpir.mpf_set_q(ref (_f = new()).Value, value.Q);

    internal ref readonly Mpf F => ref (_f ?? _zero).Value;

    public static MpFloat Parse(string str, int @base = 0)
    {
        if (@base != 0 && (@base < -62 || @base > -2) && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        MpFloat result = default;
        result._f = new();
        if (Mpir.mpf_set_str(ref result._f.Value, str, @base) != 0)
            throw new FormatException();

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetDefaultPrecision(uint precision) => Mpir.mpf_set_default_prec(precision);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint GetDefaultPrecision(uint precision) => (uint)Mpir.mpf_get_default_prec();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint GetPrecision() => (uint)Mpir.mpf_get_prec(F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetPrecision(uint precision) => Mpir.mpf_set_prec(ref (_f ??= new()).Value, precision);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(int a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(uint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(nint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(nuint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(long a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(ulong a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(double a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpFloat(MpInteger a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator MpFloat(MpRational a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(MpFloat a) => a.ToInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(MpFloat a) => a.ToUInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(MpFloat a) => a.ToNativeInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(MpFloat a) => a.ToNativeUInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(MpFloat a) => a.ToInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ulong(MpFloat a) => a.ToUInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator double(MpFloat a) => a.ToDouble();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a) => a;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a) => Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, MpFloat b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, int b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(int a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, uint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(uint a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, nint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(nint a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, nuint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(nuint a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, long b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(long a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(MpFloat a, ulong b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator +(ulong a, MpFloat b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, int b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(int a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, uint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(uint a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, nint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(nint a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, nuint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(nuint a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, long b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(long a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(MpFloat a, ulong b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator -(ulong a, MpFloat b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, MpFloat b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, int b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(int a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, uint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(uint a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, nint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(nint a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, nuint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(nuint a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, long b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(long a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(MpFloat a, ulong b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator *(ulong a, MpFloat b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, MpFloat b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, int b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, uint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, nint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, nuint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, long b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpFloat operator /(MpFloat a, ulong b) => Divide(a, b);

    /// <inheritdoc />
    public override int GetHashCode() => ToInt32();

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => ToString(10);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpFloat Copy() => new(this);

    /// <inheritdoc />
    public void Dispose()
    {
        MpfGuard? guard = _f;
        _f = null;
        guard?.Dispose();
    }
}
