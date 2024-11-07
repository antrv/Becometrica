using System.Text;
using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistSubPlayItem: IReadableObject
{
    public string ClipInformationFileName { get; set; } = string.Empty;
    public string ClipCodecIdentifier { get; set; } = string.Empty;
    public int ConnectionCondition { get; set; }
    public bool IsMultiClipEntries { get; set; }
    public int RefToStcId { get; set; }
    public TimeSpan InTime { get; set; }
    public TimeSpan OutTime { get; set; }
    public int SyncPlayItemId { get; set; }
    public int SyncStartPts { get; set; }
    public List<BlurayPlaylistSubPlayItemEntry> MultiClipEntries { get; set; } = [];

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        int length = reader.ReadUInt16();
        Span<byte> buffer = stackalloc byte[5];
        reader.ReadBytes(buffer);
        ClipInformationFileName = Encoding.UTF8.GetString(buffer).TrimEnd();
        Span<byte> buffer1 = buffer[..4];
        reader.ReadBytes(buffer1);
        ClipCodecIdentifier = Encoding.UTF8.GetString(buffer1).TrimEnd();
        reader.Skip(3);
        length = reader.ReadByte();
        ConnectionCondition = (length & 0x1E) >> 1;
        IsMultiClipEntries = (length & 1) != 0;
        RefToStcId = reader.ReadByte();
        InTime = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
        OutTime = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
        SyncPlayItemId = reader.ReadUInt16();
        SyncStartPts = reader.ReadInt32();
        if (IsMultiClipEntries)
        {
            int multiClipEntryCount = reader.ReadByte();
            reader.Skip(1); // reserved
            MultiClipEntries = reader.ReadList(new List<BlurayPlaylistSubPlayItemEntry>(), multiClipEntryCount);
        }
    }
}