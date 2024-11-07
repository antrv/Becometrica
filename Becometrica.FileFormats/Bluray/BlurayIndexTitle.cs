using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayIndexTitle: IReadableObject
{
    public ObjectType ObjectType { get; set; }
    public int AccessType { get; set; } // meaning is unknown
    public PlaybackType PlaybackType { get; set; }
    public int RefToMovieObjectId { get; set; }
    public long RefToBdJObjectId { get; set; }

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        uint type = reader.ReadUInt32();
        ObjectType = (ObjectType)(type >> 30);
        AccessType = (int)(type >> 28) & 0x3;

        ushort playbackType = reader.ReadUInt16();
        PlaybackType = (PlaybackType)(playbackType >> 14);

        if (ObjectType == ObjectType.Hdmv)
        {
            RefToMovieObjectId = reader.ReadUInt16();
            reader.Skip(4); // reserved
        }
        else if (ObjectType == ObjectType.BdJ)
        {
            RefToBdJObjectId = (long)reader.ReadUInt32() << 8;
            RefToBdJObjectId |= reader.ReadByte();
            reader.Skip(1); // reserved
        }
    }
}