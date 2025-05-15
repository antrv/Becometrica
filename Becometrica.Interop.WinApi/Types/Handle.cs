namespace Becometrica.Interop.WinApi.Types;

public readonly struct Handle(nint value)
{
    public nint Value => value;
}