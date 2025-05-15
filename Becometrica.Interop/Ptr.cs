namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged structure.
/// </summary>
/// <typeparam name="T">The unmanaged type.</typeparam>
public readonly struct Ptr<T>: IMutablePtr<Ptr<T>, T>, IEquatable<ConstPtr<T>>, IEquatable<nint>, IEquatable<nuint>
    where T: unmanaged
{
    private readonly unsafe T* _ptr;

    public unsafe Ptr(nint ptr) => _ptr = (T*)ptr;
    public unsafe Ptr(nuint ptr) => _ptr = (T*)ptr;
    public unsafe Ptr(T* ptr) => _ptr = ptr;
    public unsafe Ptr(ref T ptr) => _ptr = (T*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref ptr);

    public static Ptr<T> Create(nint ptr) => new(ptr);
    public static Ptr<T> Create(nuint ptr) => new(ptr);
    public static Ptr<T> Create(ref T @ref) => new(ref @ref);
    public static unsafe Ptr<T> Create(T* ptr) => new(ptr);

    public static explicit operator Ptr<T>(nint ptr) => new(ptr);
    public static explicit operator Ptr<T>(nuint ptr) => new(ptr);
    public static unsafe implicit operator Ptr<T>(T* ptr) => new(ptr);
    public static implicit operator Ptr<T>(NullPtr ptr) => new(0);
    public static unsafe explicit operator nint(Ptr<T> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(Ptr<T> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator T*(Ptr<T> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static Ptr<T> Null => default;

    public unsafe T Value => System.Runtime.CompilerServices.Unsafe.AsRef<T>(_ptr);
    public unsafe ref T Ref => ref System.Runtime.CompilerServices.Unsafe.AsRef<T>(_ptr);

    public unsafe T* Pointer => _ptr;

    public unsafe Ptr<TResult> Cast<TResult>()
        where TResult: unmanaged => new((TResult*)_ptr);

    public unsafe Span<T> AsSpan(int length) => new(_ptr, length);
    public unsafe ReadOnlySpan<T> AsReadOnlySpan(int length) => new(_ptr, length);

    public unsafe Ptr<T> Add(int offset) => new(_ptr + offset);
    public unsafe Ptr<T> Add(nint offset) => new(_ptr + offset);
    public unsafe Ptr<T> Add(long offset) => new(_ptr + offset);
    public unsafe Ptr<T> Subtract(int offset) => new(_ptr - offset);
    public unsafe Ptr<T> Subtract(nint offset) => new(_ptr - offset);
    public unsafe Ptr<T> Subtract(long offset) => new(_ptr - offset);

    public unsafe long Offset(Ptr<T> ptr) => _ptr - ptr._ptr;

    public static unsafe bool operator ==(Ptr<T> left, Ptr<T> right) => left._ptr == right._ptr;
    public static unsafe bool operator !=(Ptr<T> left, Ptr<T> right) => left._ptr != right._ptr;
    public static unsafe bool operator >(Ptr<T> left, Ptr<T> right) => left._ptr > right._ptr;
    public static unsafe bool operator >=(Ptr<T> left, Ptr<T> right) => left._ptr >= right._ptr;
    public static unsafe bool operator <(Ptr<T> left, Ptr<T> right) => left._ptr < right._ptr;
    public static unsafe bool operator <=(Ptr<T> left, Ptr<T> right) => left._ptr <= right._ptr;

    public static unsafe bool operator !(Ptr<T> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(Ptr<T> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(Ptr<T> ptr) => ptr._ptr is not null;

    public static Ptr<T> operator ++(Ptr<T> ptr) => ptr.Add(1);
    public static Ptr<T> operator --(Ptr<T> ptr) => ptr.Subtract(1);
    public static Ptr<T> operator +(Ptr<T> ptr, int offset) => ptr.Add(offset);
    public static Ptr<T> operator +(Ptr<T> ptr, nint offset) => ptr.Add(offset);
    public static Ptr<T> operator +(Ptr<T> ptr, long offset) => ptr.Add(offset);
    public static Ptr<T> operator -(Ptr<T> ptr, int offset) => ptr.Subtract(offset);
    public static Ptr<T> operator -(Ptr<T> ptr, nint offset) => ptr.Subtract(offset);
    public static Ptr<T> operator -(Ptr<T> ptr, long offset) => ptr.Subtract(offset);

    public ref T this[int index] => ref (this + index).Ref;

    public override unsafe string ToString() => Utils.ToHexString((nint)_ptr);

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => _ptr == (T*)ptr,
        nuint ptr => _ptr == (T*)ptr,
        IPtr genericPtr => _ptr == (T*)genericPtr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(Ptr<T> other) => _ptr == other._ptr;
    public unsafe bool Equals(ConstPtr<T> other) => _ptr == other.Pointer;
    public unsafe bool Equals(nint other) => _ptr == (T*)other;
    public unsafe bool Equals(nuint other) => _ptr == (T*)other;
}

public static class Ptr
{
    public static Ptr<T> Create<T>(ref T @ref)
        where T: unmanaged => new(ref @ref);
}