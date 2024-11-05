namespace Becometrica.Unsafe;

public interface IStringPtr<TSelf, T>: IGenericPtr<TSelf>
    where TSelf: unmanaged, IStringPtr<TSelf, T>
    where T: unmanaged
{
    static abstract unsafe TSelf Create(T* ptr);
}