namespace Becometrica.Interop.WinApi.Types;

public readonly struct LParam(nint value)
{
    public nint Value => value;
}