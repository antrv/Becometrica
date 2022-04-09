using System.Numerics;
using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

public partial struct MpInteger: IEquatable<MpInteger>, IComparable, IComparable<MpInteger>, IDisposable
{
    private static readonly MpzGuard _zero = new();
    private MpzGuard? _z;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(int value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(uint value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(nint value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(nuint value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(long value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(ulong value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(BigInteger value)
    {
        _z = default;
        Set(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(double value) => _z = new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(MpInteger value) => _z = new(value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(MpRational value) => Mpir.mpz_set_q(ref (_z = new()).Value, value.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger(MpFloat value) => Mpir.mpz_set_f(ref (_z = new()).Value, value.F);

    internal ref readonly Mpz Z => ref (_z ?? _zero).Value;

    public static MpInteger Parse(string str, int @base = 0)
    {
        if (@base != 0 && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        MpInteger result = default;
        result._z = new();
        if (Mpir.mpz_set_str(ref result._z.Value, str, @base) != 0)
            throw new FormatException();

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(short a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(ushort a) => new((nuint)a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(int a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(uint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(nint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(nuint a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(long a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(ulong a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MpInteger(BigInteger a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator MpInteger(double a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator MpInteger(MpRational a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator MpInteger(MpFloat a) => new(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(MpInteger a) => a.ToInt16();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(MpInteger a) => a.ToUInt16();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(MpInteger a) => a.ToInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(MpInteger a) => a.ToUInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(MpInteger a) => a.ToNativeInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(MpInteger a) => a.ToNativeUInt();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(MpInteger a) => a.ToInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ulong(MpInteger a) => a.ToUInt64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator double(MpInteger a) => a.ToDouble();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a) => a;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a) => Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, MpInteger b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, int b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(int a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, uint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(uint a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, nint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(nint a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, nuint b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(nuint a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, long b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(long a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(MpInteger a, ulong b) => Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator +(ulong a, MpInteger b) => Add(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, int b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(int a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, uint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(uint a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, nint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(nint a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, nuint b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(nuint a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, long b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(long a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(MpInteger a, ulong b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator -(ulong a, MpInteger b) => Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, MpInteger b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, int b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(int a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, uint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(uint a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, nint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(nint a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, nuint b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(nuint a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, long b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(long a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(MpInteger a, ulong b) => Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator *(ulong a, MpInteger b) => Multiply(b, a);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, MpInteger b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, int b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, uint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, nint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, nuint b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, long b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator /(MpInteger a, ulong b) => Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, MpInteger b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, int b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, uint b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, nint b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, nuint b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, long b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator %(MpInteger a, ulong b) => Remainder(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator <<(MpInteger a, int b) => ShiftLeft(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator >>(MpInteger a, int b) => ShiftRight(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator &(MpInteger a, MpInteger b) => And(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator |(MpInteger a, MpInteger b) => Or(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator ^(MpInteger a, MpInteger b) => Xor(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MpInteger operator ~(MpInteger a) => Not(a);

    /// <inheritdoc />
    public override int GetHashCode() => ToInt32();

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => ToString(10);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MpInteger Copy() => new(this);

    /// <inheritdoc />
    public void Dispose()
    {
        MpzGuard? guard = _z;
        _z = null;
        guard?.Dispose();
    }
}
