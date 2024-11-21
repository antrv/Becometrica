using Becometrica.Unsafe;

namespace Becometrica.Interop.Clang;

public struct CXString
{
    public ConstPtr<byte> Data;
    public uint PrivateFlags;
}