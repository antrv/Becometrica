namespace Becometrica.Interop.WinApi.Types;

public readonly struct HGdiObj(nint value)
{
    public nint Value => value;

    public static implicit operator HGdiObj(HBrush brush) => new(brush.Value);
}