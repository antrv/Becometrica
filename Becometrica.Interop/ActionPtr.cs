using System.Diagnostics;

namespace Becometrica.Unsafe;

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr: IActionPtr<ActionPtr>
{
    private readonly unsafe delegate*<void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<void>)ptr;
    public unsafe ActionPtr(delegate*<void> ptr) => _ptr = ptr;

    public static ActionPtr Create(nint ptr) => new(ptr);
    public static ActionPtr Create(nuint ptr) => new(ptr);
    public static unsafe ActionPtr Create(delegate*<void> ptr) => new(ptr);

    public static explicit operator ActionPtr(nint ptr) => new(ptr);
    public static explicit operator ActionPtr(nuint ptr) => new(ptr);
    public static unsafe explicit operator ActionPtr(delegate*<void> ptr) => new(ptr);
    public static implicit operator ActionPtr(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(ActionPtr ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator delegate*<void>(ActionPtr ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr Null => default;

    public unsafe delegate*<void> Pointer => _ptr;

    public unsafe void Invoke() => _ptr();

    public static unsafe bool operator ==(ActionPtr left, ActionPtr right) => (nint)left._ptr == (nint)right._ptr;
    public static unsafe bool operator !=(ActionPtr left, ActionPtr right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr other) => (nint)_ptr == (nint)other._ptr;
    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}

/// <summary>
/// The structure represents an unmanaged pointer to an unmanaged function.
/// </summary>
/// <typeparam name="TArg">The function argument type.</typeparam>
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg>: IActionPtr<ActionPtr<TArg>, TArg>
    where TArg: unmanaged
{
    private readonly unsafe delegate*<TArg, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg> Create(nuint ptr) => new(ptr);
    public static unsafe ActionPtr<TArg> Create(delegate*<TArg, void> ptr) => new(ptr);

    public static explicit operator ActionPtr<TArg>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg>(nuint ptr) => new(ptr);
    public static unsafe explicit operator ActionPtr<TArg>(delegate*<TArg, void> ptr) => new(ptr);
    public static implicit operator ActionPtr<TArg>(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(ActionPtr<TArg> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr<TArg> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator delegate*<TArg, void>(ActionPtr<TArg> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg> Null => default;
    public unsafe delegate*<TArg, void> Pointer => _ptr;
    public unsafe void Invoke(TArg arg) => _ptr(arg);

    public static unsafe bool operator ==(ActionPtr<TArg> left, ActionPtr<TArg> right) => (nint)left._ptr == (nint)right._ptr;
    public static unsafe bool operator !=(ActionPtr<TArg> left, ActionPtr<TArg> right) => (nint)left._ptr != (nint)right._ptr;
    public static unsafe bool operator !(ActionPtr<TArg> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr<TArg> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr<TArg> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2>: IActionPtr<ActionPtr<TArg1, TArg2>, TArg1, TArg2>
    where TArg1: unmanaged
    where TArg2: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2> Create(nuint ptr) => new(ptr);
    public static unsafe ActionPtr<TArg1, TArg2> Create(delegate*<TArg1, TArg2, void> ptr) => new(ptr);

    public static explicit operator ActionPtr<TArg1, TArg2>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2>(nuint ptr) => new(ptr);
    public static unsafe explicit operator ActionPtr<TArg1, TArg2>(delegate*<TArg1, TArg2, void> ptr) => new(ptr);
    public static implicit operator ActionPtr<TArg1, TArg2>(NullPtr ptr) => new(default(nint));
    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator delegate*<TArg1, TArg2, void>(ActionPtr<TArg1, TArg2> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2> Null => default;
    public unsafe delegate*<TArg1, TArg2, void> Pointer => _ptr;
    public unsafe void Invoke(TArg1 arg1, TArg2 arg2) => _ptr(arg1, arg2);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2> left, ActionPtr<TArg1, TArg2> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2> left, ActionPtr<TArg1, TArg2> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr<TArg1, TArg2> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr<TArg1, TArg2> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3>: IActionPtr<ActionPtr<TArg1, TArg2, TArg3>, TArg1, TArg2, TArg3>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3> Create(nuint ptr) => new(ptr);
    public static unsafe ActionPtr<TArg1, TArg2, TArg3> Create(delegate*<TArg1, TArg2, TArg3, void> ptr) => new(ptr);

    public static explicit operator ActionPtr<TArg1, TArg2, TArg3>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2, TArg3>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3>(
        delegate*<TArg1, TArg2, TArg3, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2, TArg3> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2, TArg3> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, void>(ActionPtr<TArg1, TArg2, TArg3> ptr) =>
        ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, void> Pointer => _ptr;
    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3) => _ptr(arg1, arg2, arg3);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3> left,
        ActionPtr<TArg1, TArg2, TArg3> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3> left,
        ActionPtr<TArg1, TArg2, TArg3> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4>:
    IActionPtr<ActionPtr<TArg1, TArg2, TArg3, TArg4>, TArg1, TArg2, TArg3, TArg4>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3, TArg4> Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, void> ptr) => new(ptr);

    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4>(
        delegate*<TArg1, TArg2, TArg3, TArg4, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, void
        >(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, void> Pointer => _ptr;
    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) => _ptr(arg1, arg2, arg3, arg4);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3, TArg4> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>: IActionPtr<
    ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>, TArg1, TArg2, TArg3, TArg4, TArg5>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> ptr) => new(ptr);

    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5>(NullPtr ptr) => new(default(nint));

    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => (nint)ptr._ptr;
    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void>(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> Pointer => _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
        _ptr(arg1, arg2, arg3, arg4, arg5);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => ptr._ptr is null;
    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => ptr._ptr is null;
    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>: IActionPtr<
    ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(NullPtr ptr) =>
        new(default(nint));

    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> ptr) => new(ptr);

    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) =>
        (nint)ptr._ptr;

    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) =>
        (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> Pointer => _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
        _ptr(arg1, arg2, arg3, arg4, arg5, arg6);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>: IActionPtr<
    ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)ptr;
    public unsafe ActionPtr(nuint ptr) => _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)ptr;
    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(NullPtr ptr) =>
        new(default(nint));

    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> ptr) => new(ptr);

    public static unsafe explicit operator nint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) =>
        (nint)ptr._ptr;

    public static unsafe explicit operator nuint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) =>
        (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> Pointer => _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
        _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> other) => (nint)_ptr == (nint)other._ptr;
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>: IActionPtr<
    ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
    TArg7, TArg8>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> _ptr;

    public unsafe ActionPtr(nint ptr) => _ptr =
        (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)ptr;

    public unsafe ActionPtr(nuint ptr) => _ptr =
        (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)ptr;

    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> ptr) => _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Create(nint ptr) => new(ptr);
    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> ptr) => new(ptr);

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(nint ptr) => new(ptr);

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> ptr) => new(ptr);

    public static implicit operator ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(NullPtr ptr) =>
        new(default(nint));

    public static unsafe explicit operator
        nint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator
        nuint(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;

    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> Pointer => _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8) => _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> right) => (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> right) => (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator false(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) =>
        ptr._ptr is null;

    public static unsafe bool operator true(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> ptr) =>
        ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> other) =>
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>: IActionPtr<
    ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>, TArg1, TArg2, TArg3, TArg4, TArg5,
    TArg6, TArg7, TArg8, TArg9>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
    where TArg9: unmanaged
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> _ptr;

    public unsafe ActionPtr(nint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)ptr;

    public unsafe ActionPtr(nuint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)ptr;

    public unsafe ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> ptr) =>
        _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Create(nint ptr) => new(ptr);

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Create(nuint ptr) =>
        new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> ptr) => new(ptr);

    public static implicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(NullPtr ptr) =>
        new(default(nint));

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(nint ptr) => new(ptr);

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(nuint ptr) => new(ptr);

    public static unsafe explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(
            delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> ptr) => new(ptr);

    public static unsafe explicit operator nint(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator nuint(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void
        >(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Null => default;
    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> Pointer => _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8, TArg9 arg9) =>
        _ptr(arg1, arg2, arg3,
            arg4, arg5, arg6, arg7, arg8, arg9);

    public static unsafe bool operator ==(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator
        !(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => ptr._ptr is null;

    public static unsafe bool operator true(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> other) =>
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
[DebuggerDisplay("{DebuggerString}")]
public readonly struct ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>: IActionPtr
<ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>, TArg1, TArg2, TArg3, TArg4
    , TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
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
{
    private readonly unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> _ptr;

    public unsafe ActionPtr(nint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)ptr;

    public unsafe ActionPtr(nuint ptr) =>
        _ptr = (delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)ptr;

    public unsafe
        ActionPtr(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> ptr) =>
        _ptr = ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
        Create(nint ptr) => new(ptr);

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
        Create(nuint ptr) => new(ptr);

    public static unsafe ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> ptr) => new(ptr);

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(nint ptr) => new(ptr);

    public static explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(nuint ptr) => new(ptr);

    public static unsafe explicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(
            delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> ptr) => new(ptr);

    public static implicit operator
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(NullPtr ptr) =>
        new(default(nint));

    public static unsafe explicit operator nint(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => (nint)ptr._ptr;

    public static unsafe explicit operator nuint(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TArg10, void>(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => ptr._ptr;

    public unsafe bool IsNull => _ptr is null;
    public unsafe nint ToNativeInt() => (nint)_ptr;
    public unsafe nuint ToNativeUInt() => (nuint)_ptr;

    public static ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Null => default;

    public unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> Pointer =>
        _ptr;

    public unsafe void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7,
        TArg8 arg8, TArg9 arg9, TArg10 arg10) => _ptr(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

    public static unsafe bool operator ==(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> right) =>
        (nint)left._ptr == (nint)right._ptr;

    public static unsafe bool operator !=(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> left,
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> right) =>
        (nint)left._ptr != (nint)right._ptr;

    public static unsafe bool operator !(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => ptr._ptr is null;

    public static unsafe bool operator false(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => ptr._ptr is null;

    public static unsafe bool operator true(
        ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> ptr) => ptr._ptr is not null;

    public override unsafe int GetHashCode() => (int)_ptr;

    public override unsafe bool Equals(object? obj) => obj switch
    {
        null => _ptr is null,
        nint ptr => (nint)_ptr == ptr,
        nuint ptr => (nuint)_ptr == ptr,
        IPtr ptr => (nint)_ptr == ptr.ToNativeInt(),
        _ => false,
    };

    public unsafe bool Equals(ActionPtr<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> other) =>
        (nint)_ptr == (nint)other._ptr;

    public unsafe bool Equals(nint other) => (nint)_ptr == other;
    public unsafe bool Equals(nuint other) => (nuint)_ptr == other;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private unsafe string DebuggerString => Utils.ToHexString((nint)_ptr);
}