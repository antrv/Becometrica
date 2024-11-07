namespace Becometrica.FileFormats.Bluray;

public record struct FrameRate(int Numerator, int Denominator)
{
    internal static FrameRate Create(int code) => code switch
    {
        1 => new FrameRate(24000, 1001),
        2 => new FrameRate(24, 1),
        3 => new FrameRate(25, 1),
        4 => new FrameRate(30000, 1001),
        6 => new FrameRate(50, 1),
        7 => new FrameRate(60000, 1001),
        _ => default,
    };
}