using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents an unmanaged pointer to a UTF-16 encoded zero-terminated string.
/// This is extremely useful for interop with the native code.
/// </summary>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct Utf16StringPtr: IStringPtr<Utf16StringPtr, char>, IEquatable<Ptr<char>>,
    IEquatable<ConstPtr<char>>, IEquatable<nint>, IEquatable<nuint>
{
    private readonly nint _ptr;

    public Utf16StringPtr(nint ptr) => _ptr = ptr;
    public Utf16StringPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe Utf16StringPtr(char* ptr) => _ptr = (nint)ptr;
    public Utf16StringPtr(Ptr<char> ptr) => _ptr = (nint)ptr;
    public Utf16StringPtr(ConstPtr<char> ptr) => _ptr = (nint)ptr;

    public static Utf16StringPtr Create(nint ptr) => new(ptr);
    public static Utf16StringPtr Create(nuint ptr) => new(ptr);
    public static unsafe Utf16StringPtr Create(char* ptr) => new(ptr);

    public static explicit operator Utf16StringPtr(nint ptr) => new(ptr);
    public static explicit operator Utf16StringPtr(nuint ptr) => new(ptr);
    public static unsafe implicit operator Utf16StringPtr(char* ptr) => new(ptr);
    public static explicit operator Utf16StringPtr(Ptr<char> ptr) => new(ptr);
    public static explicit operator Utf16StringPtr(ConstPtr<char> ptr) => new(ptr);
    public static implicit operator Utf16StringPtr(NullPtr ptr) => new(default(nint));
    public static explicit operator nint(Utf16StringPtr ptr) => ptr._ptr;
    public static explicit operator nuint(Utf16StringPtr ptr) => (nuint)ptr._ptr;
    public static explicit operator Ptr<char>(Utf16StringPtr ptr) => new(ptr._ptr);
    public static implicit operator ConstPtr<char>(Utf16StringPtr ptr) => new(ptr._ptr);
    public static explicit operator string?(Utf16StringPtr ptr) => Marshal.PtrToStringUni(ptr._ptr);

    public bool IsNull => _ptr == 0;
    public static Utf16StringPtr Null => default;

    public static bool operator ==(Utf16StringPtr left, Utf16StringPtr right) => left._ptr == right._ptr;
    public static bool operator !=(Utf16StringPtr left, Utf16StringPtr right) => left._ptr != right._ptr;

    public static bool operator !(Utf16StringPtr ptr) => ptr._ptr == 0;
    public static bool operator false(Utf16StringPtr ptr) => ptr._ptr == 0;
    public static bool operator true(Utf16StringPtr ptr) => ptr._ptr != 0;

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
    public Ptr<char> ToPtr() => new(_ptr);
    public ConstPtr<char> ToConstPtr() => new(_ptr);

    public bool Equals(Utf16StringPtr other) => _ptr == other._ptr;
    public bool Equals(Ptr<char> other) => _ptr == (nint)other;
    public bool Equals(ConstPtr<char> other) => _ptr == (nint)other;
    public bool Equals(nint other) => _ptr == other;
    public bool Equals(nuint other) => _ptr == (nint)other;

    public override string ToString() => Marshal.PtrToStringUni(_ptr) ?? string.Empty;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerString => Utils.ToHexString(_ptr);
}