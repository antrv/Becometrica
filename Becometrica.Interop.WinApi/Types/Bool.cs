namespace Becometrica.Interop.WinApi.Types;

public readonly struct Bool(uint value)
{
    public uint Value => value;

    public static implicit operator bool(Bool value) => value.Value != 0;
    public static implicit operator Bool(bool value) => new(value ? 1u : 0u);
    public static bool operator !(Bool value) => value.Value == 0;
    public static bool operator true(Bool value) => value.Value != 0;
    public static bool operator false(Bool value) => value.Value == 0;
}