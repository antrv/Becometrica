namespace Becometrica.Interop;

public interface IStringPtr<TSelf, TChar>: IPtr<TSelf>
    where TSelf: unmanaged, IStringPtr<TSelf, TChar>
    where TChar: unmanaged
{
    static abstract unsafe implicit operator TSelf(TChar* value);

    static abstract unsafe TSelf Create(TChar* ptr);
}