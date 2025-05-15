using System.Runtime.CompilerServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.User32;

public struct PaintStruct
{
    public HDc HDc;
    public Bool Erase;
    public Rect Paint;
    public Bool Restore;
    public Bool IncUpdate;
    public Array32<byte> RgbReserved;
}

[InlineArray(32)]
public struct Array32<T>
where T: unmanaged
{
    public T Value;
}