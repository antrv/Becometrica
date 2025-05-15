namespace Becometrica.Interop.WinApi.Types;

public readonly struct HWnd(nint value)
{
    public nint Value => value;

    public bool IsNull => value == 0;

    public static bool operator ==(HWnd left, HWnd right) => left.Value == right.Value;
    public static bool operator !=(HWnd left, HWnd right) => left.Value == right.Value;
}