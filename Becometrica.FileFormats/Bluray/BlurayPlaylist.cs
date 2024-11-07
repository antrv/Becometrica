using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylist: IFileFormat
{
    // https://github.com/lw/BluRay/wiki/MPLS
    // https://en.wikibooks.org/wiki/User:Bdinfo/mpls
    public PlaylistPlaybackType PlaybackType { get; set; }
    public int PlaybackCount { get; set; }
    public PlaylistUserOperationMask UserOperationMask { get; set; }
    public bool RandomAccess { get; set; }
    public bool AudioMix { get; set; }
    public bool LosslessBypass { get; set; }
    public bool MvcBaseViewR { get; set; }
    public bool SdrConversionNotification { get; set; }
    public List<BlurayPlaylistItem> Items { get; set; } = [];
    public List<BlurayPlaylistSubPath> SubPaths { get; set; } = [];
    public List<BlurayPlaylistMark> Marks { get; set; } = [];

    public static string Name => "Bluray Playlist";
    public static string Extensions => ".mpls";
    public static Endianness Endianness => Endianness.BigEndian;

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        Span<byte> buffer = stackalloc byte[4];

        // signature
        reader.ReadBytes(buffer);

        if (!buffer.SequenceEqual("MPLS"u8))
            throw new InvalidDataException("Invalid Bluray Playlist format.");

        // version: 0200
        reader.ReadBytes(buffer);

        int playListStartAddress = reader.ReadInt32();
        int playListMarkStartAddress = reader.ReadInt32();
        int extensionDataStartAddress = reader.ReadInt32();
        reader.Skip(20); // reserved

        // AppInfoPlayList
        int appInfoPlayListLength = reader.ReadInt32();
        reader.ReadByte(); // reserved
        PlaybackType = (PlaylistPlaybackType)reader.ReadByte();
        if (PlaybackType is PlaylistPlaybackType.Random or PlaylistPlaybackType.Shuffle)
            PlaybackCount = reader.ReadUInt16();
        else
            reader.Skip(2); // reserved

        UserOperationMask = reader.ReadEnum<PlaylistUserOperationMask>();

        int flags = reader.ReadByte();
        RandomAccess = (flags & 0x80) != 0;
        AudioMix = (flags & 0x40) != 0;
        LosslessBypass = (flags & 0x20) != 0;
        MvcBaseViewR = (flags & 0x10) != 0;
        SdrConversionNotification = (flags & 0x08) != 0;
        reader.Skip(1);

        if (reader.Position < playListStartAddress)
            reader.Skip(playListStartAddress - reader.Position);

        // Playlist
        int length = reader.ReadInt32();
        reader.Skip(2); // reserved
        int playItemCount = reader.ReadUInt16();
        int subPathCount = reader.ReadUInt16();
        Items = reader.ReadList(new List<BlurayPlaylistItem>(), playItemCount);
        SubPaths = reader.ReadList(new List<BlurayPlaylistSubPath>(), subPathCount);

        length = reader.ReadInt32();
        int playlistMarkCount = reader.ReadUInt16();
        Marks = reader.ReadList(new List<BlurayPlaylistMark>(), playlistMarkCount);
    }
}