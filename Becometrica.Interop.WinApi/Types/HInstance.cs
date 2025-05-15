namespace Becometrica.Interop.WinApi.Types;

public readonly struct HInstance(nint value)
{
    public nint Value => value;
}