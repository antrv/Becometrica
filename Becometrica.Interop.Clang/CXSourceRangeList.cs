using Becometrica.Unsafe;

namespace Becometrica.Interop.Clang;

/**
 * Identifies an array of ranges.
 */
public struct CXSourceRangeList
{
    /** The number of ranges in the \c ranges array. */
    public uint Count;

    /**
     * An array of \c CXSourceRanges.
     */
    public Ptr<CXSourceRange> Ranges;
}