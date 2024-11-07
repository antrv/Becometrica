using System.Text;
using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistItem: IReadableObject
{
    public string ClipInformationFileName { get; set; } = string.Empty;
    public string ClipCodecIdentifier { get; set; } = string.Empty;
    public bool IsMultiAngle { get; set; }
    public int ConnectionCondition { get; set; }
    public int RefToStcId { get; set; }
    public TimeSpan InTime { get; set; }
    public TimeSpan OutTime { get; set; }
    public PlaylistUserOperationMask UserOperationMask { get; set; }
    public bool PlayItemRandomAccess { get; set; }
    public int StillMode { get; set; }
    public int StillTime { get; set; }

    // Multi-angle
    public bool IsDifferentAudios { get; set; }
    public bool IsSeamlessAngleChange { get; set; }
    public List<BlurayPlaylistItemAngle> Angles { get; set; } = [];

    // Stream table
    public List<BlurayPlaylistItemStream> PrimaryVideoStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> PrimaryAudioStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> PrimaryPgStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> PrimaryIgStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> SecondaryVideoStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> SecondaryAudioStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> SecondaryPgStreams { get; set; } = [];
    public List<BlurayPlaylistItemStream> DvStreams { get; set; } = [];

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
        reader.Skip(1);
        int flags = reader.ReadByte();
        IsMultiAngle = (flags & 0x10) != 0;
        ConnectionCondition = flags & 0xF;
        RefToStcId = reader.ReadByte();
        InTime = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
        OutTime = TimeSpan.FromTicks(reader.ReadUInt32() * TimeSpan.TicksPerSecond / 45000);
        UserOperationMask = reader.ReadEnum<PlaylistUserOperationMask>();
        PlayItemRandomAccess = (reader.ReadByte() & 0x80) != 0;
        StillMode = reader.ReadByte();
        StillTime = reader.ReadUInt16(); // only if StillMode == 1
        if (IsMultiAngle)
        {
            int angleCount = reader.ReadByte();
            flags = reader.ReadByte();
            IsDifferentAudios = (flags & 0x2) != 0;
            IsSeamlessAngleChange = (flags & 0x1) != 0;
            Angles = reader.ReadList(new List<BlurayPlaylistItemAngle>(), angleCount - 1);
        }

        int streamTableLength = reader.ReadUInt16();
        reader.Skip(2); // reserved
        int primaryVideoStreamCount = reader.ReadByte();
        int primaryAudioStreamCount = reader.ReadByte();
        int primaryPgStreamCount = reader.ReadByte();
        int primaryIgStreamCount = reader.ReadByte();
        int secondaryAudioStreamCount = reader.ReadByte();
        int secondaryVideoStreamCount = reader.ReadByte();
        int secondaryPgStreamCount = reader.ReadByte();
        int dvStreamCount = reader.ReadByte();
        reader.Skip(4); // reserved
        PrimaryVideoStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), primaryVideoStreamCount);
        PrimaryAudioStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), primaryAudioStreamCount);
        PrimaryPgStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), primaryPgStreamCount);
        SecondaryPgStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), secondaryPgStreamCount);
        PrimaryIgStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), primaryIgStreamCount);
        SecondaryAudioStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), secondaryAudioStreamCount);
        SecondaryVideoStreams= reader.ReadList(new List<BlurayPlaylistItemStream>(), secondaryVideoStreamCount);
        DvStreams = reader.ReadList(new List<BlurayPlaylistItemStream>(), dvStreamCount);
    }
}