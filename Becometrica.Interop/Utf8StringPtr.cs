using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents an unmanaged pointer to a UTF-8 encoded zero-terminated string.
/// This is extremely useful for interop with the native code.
/// </summary>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct Utf8StringPtr: IStringPtr<Utf8StringPtr, byte>, IEquatable<Ptr<byte>>,
    IEquatable<ConstPtr<byte>>, IEquatable<nint>, IEquatable<nuint>
{
    private readonly nint _ptr;

    public Utf8StringPtr(nint ptr) => _ptr = ptr;
    public Utf8StringPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe Utf8StringPtr(byte* ptr) => _ptr = (nint)ptr;
    public Utf8StringPtr(Ptr<byte> ptr) => _ptr = (nint)ptr;
    public Utf8StringPtr(ConstPtr<byte> ptr) => _ptr = (nint)ptr;

    public static Utf8StringPtr Create(nint ptr) => new(ptr);
    public static Utf8StringPtr Create(nuint ptr) => new(ptr);
    public static unsafe Utf8StringPtr Create(byte* ptr) => new(ptr);

    public static explicit operator Utf8StringPtr(nint ptr) => new(ptr);
    public static explicit operator Utf8StringPtr(nuint ptr) => new(ptr);
    public static unsafe implicit operator Utf8StringPtr(byte* ptr) => new(ptr);
    public static explicit operator Utf8StringPtr(Ptr<byte> ptr) => new(ptr);
    public static explicit operator Utf8StringPtr(ConstPtr<byte> ptr) => new(ptr);
    public static implicit operator Utf8StringPtr(NullPtr ptr) => new(default(nint));
    public static explicit operator nint(Utf8StringPtr ptr) => ptr._ptr;
    public static explicit operator nuint(Utf8StringPtr ptr) => (nuint)ptr._ptr;
    public static explicit operator Ptr<byte>(Utf8StringPtr ptr) => new(ptr._ptr);
    public static implicit operator ConstPtr<byte>(Utf8StringPtr ptr) => new(ptr._ptr);
    public static explicit operator string?(Utf8StringPtr ptr) => Marshal.PtrToStringUTF8(ptr._ptr);

    public bool IsNull => _ptr == default;
    public static Utf8StringPtr Null => default;

    public static bool operator ==(Utf8StringPtr left, Utf8StringPtr right) => left._ptr == right._ptr;
    public static bool operator !=(Utf8StringPtr left, Utf8StringPtr right) => left._ptr != right._ptr;

    public static bool operator !(Utf8StringPtr ptr) => ptr._ptr == default;
    public static bool operator false(Utf8StringPtr ptr) => ptr._ptr == default;
    public static bool operator true(Utf8StringPtr ptr) => ptr._ptr != default;

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

    public bool Equals(Utf8StringPtr other) => _ptr == other._ptr;
    public bool Equals(Ptr<byte> other) => _ptr == (nint)other;
    public bool Equals(ConstPtr<byte> other) => _ptr == (nint)other;
    public bool Equals(nint other) => _ptr == other;
    public bool Equals(nuint other) => _ptr == (nint)other;

    public override string ToString() => Marshal.PtrToStringUTF8(_ptr) ?? string.Empty;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerString => Utils.ToHexString(_ptr);
}