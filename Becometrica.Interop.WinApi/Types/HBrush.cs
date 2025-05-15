using Becometrica.Interop.WinApi.User32;

namespace Becometrica.Interop.WinApi.Types;

public readonly struct HBrush(nint value)
{
    public nint Value => value;

    public static implicit operator HBrush(SystemColor systemColor) => new((nint)systemColor);
}