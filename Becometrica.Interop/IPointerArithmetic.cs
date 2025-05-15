using System.Numerics;

namespace Becometrica.Interop;

public interface IPointerArithmetic<TSelf>
    where TSelf: IPointerArithmetic<TSelf>, IAdditionOperators<TSelf, int, TSelf>,
    IAdditionOperators<TSelf, nint, TSelf>, IAdditionOperators<TSelf, long, TSelf>,
    ISubtractionOperators<TSelf, int, TSelf>, ISubtractionOperators<TSelf, nint, TSelf>,
    ISubtractionOperators<TSelf, long, TSelf>, IComparisonOperators<TSelf, TSelf, bool>, IDecrementOperators<TSelf>,
    IIncrementOperators<TSelf>
{
    TSelf Add(int offset);
    TSelf Add(nint offset);
    TSelf Add(long offset);
    TSelf Subtract(int offset);
    TSelf Subtract(nint offset);
    TSelf Subtract(long offset);
    long Offset(TSelf other);
}