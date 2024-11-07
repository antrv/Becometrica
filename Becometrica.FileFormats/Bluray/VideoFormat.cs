namespace Becometrica.FileFormats.Bluray;

public record struct VideoFormat(int Resolution, bool Interlaced)
{
    internal static VideoFormat Create(int code) => code switch
    {
        1 => new VideoFormat(480, true),
        2 => new VideoFormat(576, true),
        3 => new VideoFormat(480, false),
        4 => new VideoFormat(1080, true),
        5 => new VideoFormat(720, false),
        6 => new VideoFormat(1080, false),
        7 => new VideoFormat(576, false),
        8 => new VideoFormat(2160, false),
        _ => default,
    };
}