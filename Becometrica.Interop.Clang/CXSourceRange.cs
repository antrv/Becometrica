namespace Becometrica.Interop.Clang;

/**
 * Identifies a half-open character range in the source code.
 *
 * Use clang_getRangeStart() and clang_getRangeEnd() to retrieve the
 * starting and end locations from a source range, respectively.
 */
public struct CXSourceRange
{
    public ConstPtr<byte> PtrData0;
    public ConstPtr<byte> PtrData1;
    public uint BeginIntData;
    public uint EndIntData;
}