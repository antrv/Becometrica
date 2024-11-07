using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayMovieObject: IReadableObject
{
    // https://github.com/lw/BluRay/wiki/MovieObjects
    public bool ResumeIntention { get; set; }
    public bool MenuCallMask { get; set; }
    public bool TitleSearchMask { get; set; }
    public List<BlurayNavigationCommand> NavigationCommands { get; set; } = [];

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        int flags = reader.ReadUInt16();
        ResumeIntention = (flags & 0x8000) != 0;
        MenuCallMask = (flags & 0x4000) != 0;
        TitleSearchMask = (flags & 0x2000) != 0;

        int navigationCommandCount = reader.ReadUInt16();
        NavigationCommands = reader.ReadList(new List<BlurayNavigationCommand>(), navigationCommandCount);
    }
}