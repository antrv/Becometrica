namespace Becometrica.Unsafe;

public interface IPtr<TSelf, T>: IGenericPtr<TSelf, T>
    where TSelf: unmanaged, IPtr<TSelf, T>
    where T: unmanaged
{
    static abstract TSelf Create(ref T @ref);

    ref T Ref { get; }
    Span<T> AsSpan(int length);
    ref T this[int index] { get; }
}