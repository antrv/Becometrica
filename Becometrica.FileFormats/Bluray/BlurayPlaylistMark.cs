using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistMark: IReadableObject
{
    public MarkType MarkType { get; set; }
    public int PlayItemId { get; set; }
    public TimeSpan Offset { get; set; }
    public TimeSpan Duration { get; set; }

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        reader.Skip(1); // reserved
        MarkType = (MarkType)reader.ReadByte();
        PlayItemId = reader.ReadUInt16();
        Offset = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
        reader.Skip(2); // Entry ESPID; Exact purpose unknown. This value will usually be set to $FFFF.
        Duration = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
    }
}