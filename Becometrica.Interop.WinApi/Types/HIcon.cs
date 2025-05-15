namespace Becometrica.Interop.WinApi.Types;

public readonly struct HIcon(nint value)
{
    public nint Value => value;
}