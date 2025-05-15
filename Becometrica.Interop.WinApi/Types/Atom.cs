namespace Becometrica.Interop.WinApi.Types;

public readonly struct Atom(ushort value)
{
    public ushort Value => value;
}