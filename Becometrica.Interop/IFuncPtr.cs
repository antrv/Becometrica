namespace Becometrica.Interop;

public interface IFuncPtr<TSelf, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TResult>
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TResult> ptr);
    static abstract unsafe explicit operator delegate*<TResult>(TSelf ptr);

    unsafe delegate*<TResult> Pointer { get; }

    TResult Invoke();
}

public interface IFuncPtr<TSelf, in TArg, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg, TResult>
    where TArg: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg, TResult>(TSelf ptr);

    unsafe delegate*<TArg, TResult> Pointer { get; }

    TResult Invoke(TArg arg);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7,
    out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TResult: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult
        >(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8,
    out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
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
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult
        >(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8,
    in TArg9, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>
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
    static abstract unsafe TSelf Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8,
        TArg9 arg9);
}

public interface IFuncPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8,
    in TArg9, in TArg10, out TResult>: IPtr<TSelf>
    where TSelf: unmanaged, IFuncPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
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
    static abstract unsafe TSelf Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TArg10, TResult>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Pointer { get; }

    TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8,
        TArg9 arg9, TArg10 arg10);
}