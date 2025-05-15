namespace Becometrica.Interop.WinApi.Types;

public readonly struct LResult(nint value)
{
    public nint Value => value;

    public static implicit operator LResult(nint value) => new(value);
}