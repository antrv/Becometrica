namespace Becometrica.Interop.Clang;

public struct CXStringSet
{
    public Ptr<CXString> Strings;
    public uint Count;
}