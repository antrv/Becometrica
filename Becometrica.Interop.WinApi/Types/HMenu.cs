namespace Becometrica.Interop.WinApi.Types;

public readonly struct HMenu(nint value)
{
    public nint Value => value;
}