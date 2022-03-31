namespace Becometrica.Math;

public struct Precision
{
    public Precision(uint precision) => Value = precision;
    public uint Value { get; }
    public static Precision Create(uint precision) => new(precision);
}
