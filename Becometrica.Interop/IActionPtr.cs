namespace Becometrica.Unsafe;

public interface IActionPtr<TSelf>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf>
{
    static abstract unsafe TSelf Create(delegate*<void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<void> ptr);
    static abstract unsafe explicit operator delegate*<void>(TSelf ptr);

    unsafe delegate*<void> Pointer { get; }

    void Invoke();
}

public interface IActionPtr<TSelf, in TArg>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg>
    where TArg: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg, void>(TSelf ptr);

    unsafe delegate*<TArg, void> Pointer { get; }

    void Invoke(TArg arg);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2>
    where TArg1: unmanaged
    where TArg2: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> ptr);
    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> ptr);
    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void
        >(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    where TArg1: unmanaged
    where TArg2: unmanaged
    where TArg3: unmanaged
    where TArg4: unmanaged
    where TArg5: unmanaged
    where TArg6: unmanaged
    where TArg7: unmanaged
    where TArg8: unmanaged
{
    static abstract unsafe TSelf Create(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> ptr);

    static abstract unsafe explicit operator TSelf(delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8,
    in TArg9>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
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
    static abstract unsafe TSelf Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8,
        TArg9 arg9);
}

public interface IActionPtr<TSelf, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7, in TArg8,
    in TArg9, in TArg10>: IPtr<TSelf>
    where TSelf: unmanaged, IActionPtr<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
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
    static abstract unsafe TSelf Create(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> ptr);

    static abstract unsafe explicit operator TSelf(
        delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> ptr);

    static abstract unsafe explicit operator delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
        TArg10, void>(TSelf ptr);

    unsafe delegate*<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void> Pointer { get; }

    void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8,
        TArg9 arg9, TArg10 arg10);
}