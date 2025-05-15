using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Becometrica.Interop;

/// <summary>
/// The structure represents an unmanaged pointer to a zero-terminated string.
/// This is extremely useful for interop with the native code.
/// </summary>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct AnsiStringPtr: IStringPtr<AnsiStringPtr, byte>, IEquatable<Ptr<byte>>,
    IEquatable<ConstPtr<byte>>, IEquatable<nint>, IEquatable<nuint>
{
    private readonly nint _ptr;

    public AnsiStringPtr(nint ptr) => _ptr = ptr;
    public AnsiStringPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe AnsiStringPtr(byte* ptr) => _ptr = (nint)ptr;
    public AnsiStringPtr(Ptr<byte> ptr) => _ptr = (nint)ptr;
    public AnsiStringPtr(ConstPtr<byte> ptr) => _ptr = (nint)ptr;

    public static AnsiStringPtr Create(nint ptr) => new(ptr);
    public static AnsiStringPtr Create(nuint ptr) => new(ptr);
    public static unsafe AnsiStringPtr Create(byte* ptr) => new(ptr);

    public static explicit operator AnsiStringPtr(nint ptr) => new(ptr);
    public static explicit operator AnsiStringPtr(nuint ptr) => new(ptr);
    public static unsafe implicit operator AnsiStringPtr(byte* ptr) => new(ptr);
    public static explicit operator AnsiStringPtr(Ptr<byte> ptr) => new(ptr);
    public static explicit operator AnsiStringPtr(ConstPtr<byte> ptr) => new(ptr);
    public static implicit operator AnsiStringPtr(NullPtr ptr) => new(0);
    public static explicit operator nint(AnsiStringPtr ptr) => ptr._ptr;
    public static explicit operator nuint(AnsiStringPtr ptr) => (nuint)ptr._ptr;
    public static explicit operator Ptr<byte>(AnsiStringPtr ptr) => new(ptr._ptr);
    public static implicit operator ConstPtr<byte>(AnsiStringPtr ptr) => new(ptr._ptr);
    public static explicit operator string?(AnsiStringPtr ptr) => Marshal.PtrToStringUTF8(ptr._ptr);

    public bool IsNull => _ptr == default;
    public static AnsiStringPtr Null => default;

    public static bool operator ==(AnsiStringPtr left, AnsiStringPtr right) => left._ptr == right._ptr;
    public static bool operator !=(AnsiStringPtr left, AnsiStringPtr right) => left._ptr != right._ptr;

    public static bool operator !(AnsiStringPtr ptr) => ptr._ptr == 0;
    public static bool operator false(AnsiStringPtr ptr) => ptr._ptr == 0;
    public static bool operator true(AnsiStringPtr ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        IPtr genericPtr => _ptr == genericPtr.ToNativeInt(),
        _ => false,
    };

    public nint ToNativeInt() => _ptr;
    public nuint ToNativeUInt() => (nuint)_ptr;
    public Ptr<byte> ToPtr() => new(_ptr);
    public ConstPtr<byte> ToConstPtr() => new(_ptr);

    public bool Equals(AnsiStringPtr other) => _ptr == other._ptr;
    public bool Equals(Ptr<byte> other) => _ptr == (nint)other;
    public bool Equals(ConstPtr<byte> other) => _ptr == (nint)other;
    public bool Equals(nint other) => _ptr == other;
    public bool Equals(nuint other) => _ptr == (nint)other;

    public override string ToString() => Marshal.PtrToStringAnsi(_ptr) ?? string.Empty;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerString => Utils.ToHexString(_ptr);
}