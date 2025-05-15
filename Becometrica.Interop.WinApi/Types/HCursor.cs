namespace Becometrica.Interop.WinApi.Types;

public readonly struct HCursor(nint value)
{
    public nint Value => value;
}