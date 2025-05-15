using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Becometrica.Interop;

/// <summary>
/// The structure represents an unmanaged pointer to a binary (BSTR) string.
/// This is extremely useful for interop with the native code.
/// </summary>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct BStringPtr: IStringPtr<BStringPtr, byte>, IEquatable<Ptr<byte>>, IEquatable<ConstPtr<byte>>,
    IEquatable<nint>, IEquatable<nuint>
{
    private readonly nint _ptr;

    public BStringPtr(nint ptr) => _ptr = ptr;
    public BStringPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe BStringPtr(byte* ptr) => _ptr = (nint)ptr;
    public BStringPtr(Ptr<byte> ptr) => _ptr = (nint)ptr;
    public BStringPtr(ConstPtr<byte> ptr) => _ptr = (nint)ptr;

    public static BStringPtr Create(nint ptr) => new(ptr);
    public static BStringPtr Create(nuint ptr) => new(ptr);
    public static unsafe BStringPtr Create(byte* ptr) => new(ptr);

    public static explicit operator BStringPtr(nint ptr) => new(ptr);
    public static explicit operator BStringPtr(nuint ptr) => new(ptr);
    public static unsafe implicit operator BStringPtr(byte* ptr) => new(ptr);
    public static explicit operator BStringPtr(Ptr<byte> ptr) => new(ptr);
    public static explicit operator BStringPtr(ConstPtr<byte> ptr) => new(ptr);
    public static implicit operator BStringPtr(NullPtr ptr) => new(0);
    public static explicit operator nint(BStringPtr ptr) => ptr._ptr;
    public static explicit operator nuint(BStringPtr ptr) => (nuint)ptr._ptr;
    public static explicit operator Ptr<byte>(BStringPtr ptr) => new(ptr._ptr);
    public static implicit operator ConstPtr<byte>(BStringPtr ptr) => new(ptr._ptr);
    public static explicit operator string?(BStringPtr ptr) => Marshal.PtrToStringUTF8(ptr._ptr);

    public bool IsNull => _ptr == 0;
    public static BStringPtr Null => default;

    public static bool operator ==(BStringPtr left, BStringPtr right) => left._ptr == right._ptr;
    public static bool operator !=(BStringPtr left, BStringPtr right) => left._ptr != right._ptr;

    public static bool operator !(BStringPtr ptr) => ptr._ptr == 0;
    public static bool operator false(BStringPtr ptr) => ptr._ptr == 0;
    public static bool operator true(BStringPtr ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        IPtr ptr => _ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public nint ToNativeInt() => _ptr;
    public nuint ToNativeUInt() => (nuint)_ptr;
    public Ptr<byte> ToPtr() => new(_ptr);
    public ConstPtr<byte> ToConstPtr() => new(_ptr);

    public bool Equals(BStringPtr other) => _ptr == other._ptr;
    public bool Equals(Ptr<byte> other) => _ptr == (nint)other;
    public bool Equals(ConstPtr<byte> other) => _ptr == (nint)other;
    public bool Equals(nint other) => _ptr == other;
    public bool Equals(nuint other) => _ptr == (nint)other;

    public override string ToString() => _ptr == 0 ? string.Empty : Marshal.PtrToStringBSTR(_ptr);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerString => Utils.ToHexString(_ptr);
}