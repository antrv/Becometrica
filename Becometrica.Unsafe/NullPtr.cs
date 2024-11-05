namespace Becometrica.Unsafe;

/// <summary>
/// The pointer type representing null pointer. Implicitly convertible to any other pointer type.
/// </summary>
public readonly struct NullPtr: INullPtr<NullPtr>, IEquatable<nint>, IEquatable<nuint>
{
    public static NullPtr Create() => default;
    public static explicit operator nint(NullPtr ptr) => default;
    public static explicit operator nuint(NullPtr ptr) => default;

    public bool IsNull => true;

    public nint ToNativeInt() => default;
    public nuint ToNativeUInt() => default;

    public static NullPtr Null => default;

    public static bool operator ==(NullPtr left, NullPtr right) => true;
    public static bool operator !=(NullPtr left, NullPtr right) => false;

    public static bool operator !(NullPtr ptr) => true;
    public static bool operator false(NullPtr ptr) => true;
    public static bool operator true(NullPtr ptr) => false;

    public override string ToString() => "null";

    public override int GetHashCode() => 0;

    public override bool Equals(object? obj) => obj switch
    {
        null => true,
        nint ptr => ptr == default,
        nuint ptr => ptr == default,
        IGenericPtr genericPtr => genericPtr.IsNull,
        _ => false,
    };

    public bool Equals(NullPtr other) => true;
    public bool Equals(nint other) => other == default;
    public bool Equals(nuint other) => other == default;
}