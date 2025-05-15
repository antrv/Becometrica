namespace Becometrica.Interop.WinApi.Gdi32;

public readonly struct Color(uint value)
{
    public Color(byte r, byte g, byte b)
        : this(((uint)b << 16) | ((uint)g << 8) | r)
    {
    }

    public uint Value => value;
    public byte R => (byte)(value & 0xFF);
    public byte G => (byte)((value >> 8) & 0xFF);
    public byte B => (byte)((value >> 16) & 0xFF);

    public static Color Red => new(0x000000FF);
    public static Color Green => new(0x0000FF00);
    public static Color Blue => new(0x00FF0000);
    public static Color Black => new(0x00000000);
    public static Color White => new(0x00FFFFFF);
}