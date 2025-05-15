namespace Becometrica.Interop.Clang;

/**
 * Identifies a specific source location within a translation
 * unit.
 *
 * Use clang_getExpansionLocation() or clang_getSpellingLocation()
 * to map a source location to a particular file, line, and column.
 */
public struct CXSourceLocation
{
    public ConstPtr<byte> PtrData0;
    public ConstPtr<byte> PtrData1;
    public uint IntData;
}