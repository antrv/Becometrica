using System.Numerics;

namespace Becometrica.Interop;

public interface INullPtr<TSelf>: IEquatable<TSelf>, IPtr,
    IEqualityOperators<TSelf, TSelf, bool>
    where TSelf: unmanaged, INullPtr<TSelf>
{
    static abstract TSelf Create();
}