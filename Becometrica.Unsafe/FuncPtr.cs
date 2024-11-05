using System.Diagnostics;

namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TResult>: IFuncPtr<FuncPtr<TResult>, TResult>
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TResult>)ptr;
    public unsafe FuncPtr(delegate*<TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TResult> Create(nuint ptr) => new(ptr);
    public static unsafe FuncPtr<TResult> Create(delegate*<TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TResult>(nuint ptr) => new(ptr);
    public static unsafe explicit operator FuncPtr<TResult>(delegate*<TResult> ptr) => new(ptr);
    public static implicit operator FuncPtr<TResult>(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(FuncPtr<TResult> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(FuncPtr<TResult> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator delegate*<TResult>(FuncPtr<TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TResult> Null => default;

    public unsafe delegate*<TResult> Pointer => _ptr;

    public unsafe TResult Invoke() => _ptr();

    public static unsafe bool operator ==(FuncPtr<TResult> left, FuncPtr<TResult> right)
        => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TResult> left, FuncPtr<TResult> right)
        => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(FuncPtr<TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(FuncPtr<TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TResult> other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg, TResult>: IFuncPtr<FuncPtr<TArg, TResult>, TArg, TResult>
    where TArg: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg, TResult> Create(nuint ptr) => new(ptr);
    public static unsafe FuncPtr<TArg, TResult> Create(delegate*<TArg, TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TArg, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg, TResult>(nuint ptr) => new(ptr);
    public static unsafe explicit operator FuncPtr<TArg, TResult>(delegate*<TArg, TResult> ptr) => new(ptr);
    public static implicit operator FuncPtr<TArg, TResult>(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(FuncPtr<TArg, TResult> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(FuncPtr<TArg, TResult> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator delegate*<TArg, TResult>(FuncPtr<TArg, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg, TResult> Null => default;

    public unsafe delegate*<TArg, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg arg) => _ptr(arg);

    public static unsafe bool operator ==(FuncPtr<TArg, TResult> left, FuncPtr<TArg, TResult> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg, TResult> left, FuncPtr<TArg, TResult> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(FuncPtr<TArg, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(FuncPtr<TArg, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg, TResult> other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TResult>: IFuncPtr<FuncPtr<TArg1, TArg2, TResult>, TArg1, TArg2, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TResult> Create(nuint ptr) => new(ptr);
    public static unsafe FuncPtr<TArg1, TArg2, TResult> Create(delegate*<TArg1, TArg2, TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg1, TArg2, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TResult>(delegate*<TArg1, TArg2, TResult> ptr) =>
        new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TResult>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(FuncPtr<TArg1, TArg2, TResult> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(FuncPtr<TArg1, TArg2, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TResult>(FuncPtr<TArg1, TArg2, TResult> ptr) =>
        ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2) => _ptr(arg1, arg2);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TResult> left, FuncPtr<TArg1, TArg2, TResult> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TResult> left, FuncPtr<TArg1, TArg2, TResult> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TResult> other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct
    FuncPtr<TArg1, TArg2, TArg3, TResult>: IFuncPtr<FuncPtr<TArg1, TArg2, TArg3, TResult>, TArg1, TArg2, TArg3, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TArg3, TResult> Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TResult> Create(delegate*<TArg1, TArg2, TArg3, TResult> ptr) =>
        new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TResult>(
        delegate*<TArg1, TArg2, TArg3, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TResult>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TResult>(
        FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3) => _ptr(arg1, arg2, arg3);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TResult> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TResult> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TArg3, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TResult> other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>:
    IFuncPtr<FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>, TArg1, TArg2, TArg3, TArg4, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TResult
        >(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) => _ptr(arg1, arg2, arg3, arg4);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (uint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TResult> other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>:
    IFuncPtr<FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(NullPtr ptr)
        => new(default(nint));

    public static unsafe explicit operator nint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) =>
        (nint)ptr._ptr;

    public static unsafe explicit operator nuint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) =>
        (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult
        >(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
        _ptr(arg1, arg2, arg3, arg4, arg5);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> other)
        => (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TArg6">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>: IFuncPtr<
    FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) => new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(NullPtr ptr)
        => new(default(nint));

    public static unsafe explicit operator nint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) =>
        (nint)ptr._ptr;

    public static unsafe explicit operator nuint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) =>
        (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
        _ptr(arg1, arg2, arg3, arg4, arg5, arg6);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> other)
        => (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TArg6">The function argument type.</typeparam>
/// <typeparam name="TArg7">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>: IFuncPtr<
    FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7,
    TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>)ptr;
    public unsafe FuncPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>)ptr;
    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) => _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create(nint ptr) => new(ptr);
    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(NullPtr ptr)
        => new(default(nint));

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(nint ptr) =>
        new(ptr);

    public static explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(nuint ptr) =>
        new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) => new(ptr);

    public static unsafe explicit operator
        nint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) =>
        (nint)ptr._ptr;

    public static unsafe explicit operator
        nuint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) =>
        (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
        _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator false(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> other) =>
        (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TArg6">The function argument type.</typeparam>
/// <typeparam name="TArg7">The function argument type.</typeparam>
/// <typeparam name="TArg8">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>: IFuncPtr<
    FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
    TArg7, TArg8, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) => _ptr =
        (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>)ptr;

    public unsafe FuncPtr(nuint ptr) => _ptr =
        (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>)ptr;

    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) =>
        _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create(nint ptr) => new(ptr);

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create(nuint ptr) =>
        new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => new(ptr);

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(nint ptr) => new(ptr);

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
        NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator
        nint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator
        nuint(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8) => _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static unsafe bool operator ==(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> right)
        => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> right)
        => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator
        !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => ptr._ptr is null;

    public static unsafe bool operator true(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> other) =>
        (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TArg6">The function argument type.</typeparam>
/// <typeparam name="TArg7">The function argument type.</typeparam>
/// <typeparam name="TArg8">The function argument type.</typeparam>
/// <typeparam name="TArg9">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>: IFuncPtr<
    FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>, TArg1, TArg2, TArg3, TArg4, TArg5,
    TArg6, TArg7, TArg8, TArg9, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
    where TArg9: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> _ptr;

    public unsafe FuncPtr(nint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>)ptr;

    public unsafe FuncPtr(nuint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>)ptr;

    public unsafe FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) =>
        _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create(nint ptr) =>
        new(ptr);

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create(nuint ptr) =>
        new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => new(ptr);

    public static implicit operator FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(
        NullPtr ptr) => new(default(nint));

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(nint ptr) => new(ptr);

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(
            delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => new(ptr);

    public static unsafe explicit operator nint(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator nuint(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TResult>(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Pointer => _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8, TArg9 arg9) => _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

    public static unsafe bool operator ==(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator
        !(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => ptr._ptr is null;

    public static unsafe bool operator true(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> other) =>
        (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg1">The function argument type.</typeparam>
/// <typeparam name="TArg2">The function argument type.</typeparam>
/// <typeparam name="TArg3">The function argument type.</typeparam>
/// <typeparam name="TArg4">The function argument type.</typeparam>
/// <typeparam name="TArg5">The function argument type.</typeparam>
/// <typeparam name="TArg6">The function argument type.</typeparam>
/// <typeparam name="TArg7">The function argument type.</typeparam>
/// <typeparam name="TArg8">The function argument type.</typeparam>
/// <typeparam name="TArg9">The function argument type.</typeparam>
/// <typeparam name="TArg10">The function argument type.</typeparam>
/// <typeparam name="TResult">The function result type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>: IFuncPtr
<FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>, TArg1, TArg2, TArg3, TArg4
    , TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
    where TArg9: unmanaged
    where TArg10: unmanaged
    where TResult: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
        _ptr;

    public unsafe FuncPtr(nint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>)ptr;

    public unsafe FuncPtr(nuint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>)ptr;

    public unsafe
        FuncPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) =>
        _ptr = ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
        Create(nint ptr) => new(ptr);

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
        Create(nuint ptr) => new(ptr);

    public static unsafe FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) => new(ptr);

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(nint ptr) => new(ptr);

    public static explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(
            delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) => new(ptr);

    public static implicit operator
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(NullPtr ptr)
        => new(default(nint));

    public static unsafe explicit operator nint(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator nuint(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TArg10, TResult>(FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) =>
        ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Null =>
        default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Pointer =>
        _ptr;

    public unsafe TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8, TArg9 arg9, TArg10 arg10) => _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

    public static unsafe bool operator ==(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> left,
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator false(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IGenericPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(
        FuncPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> other) =>
        (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}