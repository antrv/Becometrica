using System.Numerics;

namespace Becometrica.Unsafe;

public interface INullPtr<TSelf>: IEquatable<TSelf>, IGenericPtr,
    IEqualityOperators<TSelf, TSelf, bool>
    where TSelf: unmanaged, INullPtr<TSelf>
{
    static abstract TSelf Create();
}