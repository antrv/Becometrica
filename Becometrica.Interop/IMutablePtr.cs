namespace Becometrica.Unsafe;

public interface IMutablePtr<TSelf, T>: IPtr<TSelf, T>
    where TSelf: unmanaged, IMutablePtr<TSelf, T>
    where T: unmanaged
{
    static abstract TSelf Create(ref T @ref);

    ref T Ref { get; }
    Span<T> AsSpan(int length);
    ref T this[int index] { get; }
}