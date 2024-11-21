namespace Becometrica.Interop.Clang;

/**
 * Uniquely identifies a CXFile, that refers to the same underlying file,
 * across an indexing session.
 */
public struct CXFileUniqueID
{
    public ulong Data0;
    public ulong Data1;
    public ulong Data2;
}