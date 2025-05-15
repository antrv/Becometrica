namespace Becometrica.Interop.WinApi.Types;

public readonly struct WParam(nuint value)
{
    public nuint Value => value;
}