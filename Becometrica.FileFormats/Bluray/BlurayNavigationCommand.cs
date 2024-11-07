using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayNavigationCommand: IReadableObject
{
    // https://github.com/lw/BluRay/wiki/NavigationCommand
    public int OperandCount { get; set; }
    public int CommandGroup { get; set; }
    public int CommandSubGroup { get; set; }
    public bool ImmediateValueDestination  { get; set; }
    public bool ImmediateValueSource  { get; set; }
    public int BranchOption { get; set; }
    public int CompareOption { get; set; }
    public int SetOption { get; set; }
    public int Destination { get; set; }
    public int Source { get; set; }

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        int flags = reader.ReadByte();
        OperandCount = flags >> 5;
        CommandGroup = (flags >> 3) & 0x3;
        CommandSubGroup = flags & 0x7;

        flags = reader.ReadByte();
        ImmediateValueDestination = (flags & 0x80) != 0;
        ImmediateValueSource = (flags & 0x40) != 0;
        BranchOption = flags & 0xF;

        flags = reader.ReadByte();
        CompareOption = flags & 0xF;

        flags = reader.ReadByte();
        SetOption = flags & 0x1F;

        Destination = reader.ReadInt32();
        Source = reader.ReadInt32();
    }
}