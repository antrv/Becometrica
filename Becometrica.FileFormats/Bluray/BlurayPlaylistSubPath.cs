using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistSubPath: IReadableObject
{
    public SubPathType SubPathType { get; set; }
    public bool IsRepeatSubPath { get; set; }
    public List<BlurayPlaylistSubPlayItem> SubPlayItems { get; set; } = [];

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        int length = reader.ReadInt32();
        reader.Skip(1); // reserved
        SubPathType = (SubPathType)reader.ReadByte();
        IsRepeatSubPath = (reader.ReadUInt16() & 1) != 0;
        reader.Skip(1); // reserved
        int subPlayItemCount = reader.ReadByte();
        SubPlayItems = reader.ReadList(new List<BlurayPlaylistSubPlayItem>(), subPlayItemCount);
    }
}