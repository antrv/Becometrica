namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents a constant unmanaged pointer to an unmanaged structure.
/// The difference between <see cref="Ptr{T}"/> and <see cref="ConstPtr{T}"/> types is just a semantic,
/// corresponding to a non-const pointer or a const pointer in C++.
/// </summary>
/// <typeparam name="T">The unmanaged type.</typeparam>
public readonly struct ConstPtr<T>: IConstPtr<ConstPtr<T>, T>, IEquatable<nint>, IEquatable<nuint>
    where T: unmanaged
{
    private readonly unsafe T* _ptr;

    public unsafe ConstPtr(nint ptr) => _ptr = (T*)ptr;
    public unsafe ConstPtr(nuint ptr) => _ptr = (T*)ptr;
    public unsafe ConstPtr(T* ptr) => _ptr = ptr;

    public unsafe ConstPtr(ref readonly T ptr) => _ptr =
        (T*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AsRef(in ptr));

    public unsafe ConstPtr(Ptr<T> ptr) => _ptr = ptr.Pointer;

    public static ConstPtr<T> Create(nint ptr) => new(ptr);
    public static ConstPtr<T> Create(nuint ptr) => new(ptr);
    public static unsafe ConstPtr<T> Create(T* ptr) => new(ptr);
    public static ConstPtr<T> Create(in T @ref) => new(in @ref);

    public static explicit operator ConstPtr<T>(nint ptr) => new(ptr);
    public static explicit operator ConstPtr<T>(nuint ptr) => new(ptr);
    public static unsafe explicit operator ConstPtr<T>(T* ptr) => new(ptr);
    public static implicit operator ConstPtr<T>(Ptr<T> ptr) => new(ptr);
    public static implicit operator ConstPtr<T>(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(ConstPtr<T> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ConstPtr<T> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator T*(ConstPtr<T> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ConstPtr<T> Null => default;

    public unsafe T Value => System.Runtime.CompilerServices.Unsafe.AsRef<T>(_ptr);
    public unsafe ref readonly T Ref => ref System.Runtime.CompilerServices.Unsafe.AsRef<T>(_ptr);

    public unsafe T* Pointer => _ptr;

    public unsafe ConstPtr<TResult> Cast<TResult>()
        where TResult: unmanaged => new((TResult*)_ptr);

    public unsafe ReadOnlySpan<T> AsReadOnlySpan(int length) => new(_ptr, length);

    public unsafe ConstPtr<T> Add(int offset) => new(_ptr + offset);
    public unsafe ConstPtr<T> Add(nint offset) => new(_ptr + offset);
    public unsafe ConstPtr<T> Add(long offset) => new(_ptr + offset);
    public unsafe ConstPtr<T> Subtract(int offset) => new(_ptr - offset);
    public unsafe ConstPtr<T> Subtract(nint offset) => new(_ptr - offset);
    public unsafe ConstPtr<T> Subtract(long offset) => new(_ptr - offset);

    public unsafe long Offset(ConstPtr<T> ptr) => _ptr - ptr._ptr;

    public static unsafe bool operator ==(ConstPtr<T> left, ConstPtr<T> right) => left._ptr == right._ptr;
    public static unsafe bool operator !=(ConstPtr<T> left, ConstPtr<T> right) => left._ptr != right._ptr;
    public static unsafe bool operator >(ConstPtr<T> left, ConstPtr<T> right) => left._ptr > right._ptr;
    public static unsafe bool operator >=(ConstPtr<T> left, ConstPtr<T> right) => left._ptr >= right._ptr;
    public static unsafe bool operator <(ConstPtr<T> left, ConstPtr<T> right) => left._ptr < right._ptr;
    public static unsafe bool operator <=(ConstPtr<T> left, ConstPtr<T> right) => left._ptr <= right._ptr;

    public static unsafe bool operator !(ConstPtr<T> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ConstPtr<T> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ConstPtr<T> ptr) => ptr._ptr is not null;

    public static ConstPtr<T> operator ++(ConstPtr<T> ptr) => ptr.Add(1);
    public static ConstPtr<T> operator --(ConstPtr<T> ptr) => ptr.Subtract(1);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, int offset) => ptr.Add(offset);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, nint offset) => ptr.Add(offset);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, long offset) => ptr.Add(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, int offset) => ptr.Subtract(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, nint offset) => ptr.Subtract(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, long offset) => ptr.Subtract(offset);

    public ref readonly T this[int index] => ref (this + index).Ref;

    public override unsafe string ToString() => Utils.ToHexString((nint)_ptr);

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => _ptr == (T*)ptr,
        nuint ptr => _ptr == (T*)ptr,
        IGenericPtr genericPtr => _ptr == (T*)genericPtr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ConstPtr<T> other) => _ptr == other._ptr;
    public unsafe bool Equals(Ptr<T> other) => _ptr == other.Pointer;
    public unsafe bool Equals(nint other) => _ptr == (T*)other;
    public unsafe bool Equals(nuint other) => _ptr == (T*)other;
}

public static class ConstPtr
{
    /// <summary>
    /// Constructs <see cref="ConstPtr{T}"/> from the reference.
    /// </summary>
    /// <param name="ref">The reference.</param>
    /// <typeparam name="T">The unmanaged type</typeparam>
    /// <returns>The constant pointer of type <see cref="ConstPtr{T}"/></returns>
    public static ConstPtr<T> Create<T>(ref readonly T @ref)
        where T: unmanaged => new(in @ref);
}