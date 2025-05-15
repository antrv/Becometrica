namespace Becometrica.Interop.WinApi.Types;

public readonly struct HDc(nint value)
{
    public nint Value => value;

    public bool IsNull => value == 0;

    public static bool operator ==(HDc left, HDc right) => left.Value == right.Value;
    public static bool operator !=(HDc left, HDc right) => left.Value == right.Value;
}