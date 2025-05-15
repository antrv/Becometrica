using System.Numerics;

namespace Becometrica.Unsafe;

public interface IPtr
{
    bool IsNull { get; }

    nint ToNativeInt();
    nuint ToNativeUInt();
}

public interface IPtr<TSelf>: IEquatable<TSelf>, IPtr, IEqualityOperators<TSelf, TSelf, bool>
    where TSelf: unmanaged, IPtr<TSelf>
{
    static abstract TSelf Null { get; }
    static abstract TSelf Create(nint ptr);
    static abstract TSelf Create(nuint ptr);

    static abstract explicit operator TSelf(nint ptr);
    static abstract explicit operator TSelf(nuint ptr);
    static abstract implicit operator TSelf(NullPtr ptr);
    static abstract explicit operator nint(TSelf ptr);
    static abstract explicit operator nuint(TSelf ptr);

    static abstract bool operator !(TSelf ptr);
    static abstract bool operator false(TSelf ptr);
    static abstract bool operator true(TSelf ptr);
}

public interface IPtr<TSelf, T>: IPtr<TSelf>, IPointerArithmetic<TSelf>,
    IAdditionOperators<TSelf, int, TSelf>, IAdditionOperators<TSelf, nint, TSelf>,
    IAdditionOperators<TSelf, long, TSelf>, ISubtractionOperators<TSelf, int, TSelf>,
    ISubtractionOperators<TSelf, nint, TSelf>, ISubtractionOperators<TSelf, long, TSelf>,
    IComparisonOperators<TSelf, TSelf, bool>, IDecrementOperators<TSelf>, IIncrementOperators<TSelf>
    where TSelf: unmanaged, IPtr<TSelf, T>
    where T: unmanaged
{
    static abstract unsafe TSelf Create(T* ptr);

    static abstract unsafe implicit operator TSelf(T* ptr);
    static abstract unsafe explicit operator T*(TSelf ptr);

    unsafe T* Pointer { get; }

    T Value { get; }
    ReadOnlySpan<T> AsReadOnlySpan(int length);
}