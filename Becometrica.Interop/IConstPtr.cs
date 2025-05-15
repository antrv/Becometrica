namespace Becometrica.Unsafe;

public interface IConstPtr<TSelf, T>: IPtr<TSelf, T>
    where TSelf: unmanaged, IConstPtr<TSelf, T>
    where T: unmanaged
{
    static abstract TSelf Create(in T @ref);

    ref readonly T Ref { get; }
    ref readonly T this[int index] { get; }
}