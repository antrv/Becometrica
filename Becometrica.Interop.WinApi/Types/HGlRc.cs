namespace Becometrica.Interop.WinApi.Types;

public readonly struct HGlRc(nint value)
{
    public nint Value => value;

    public bool IsNull => value == 0;

    public static bool operator ==(HGlRc left, HGlRc right) => left.Value == right.Value;
    public static bool operator !=(HGlRc left, HGlRc right) => left.Value == right.Value;
}