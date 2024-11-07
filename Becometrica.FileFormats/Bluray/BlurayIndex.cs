using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayIndex: IFileFormat
{
    public InitialOutputModePreference InitialOutputMode { get; set; }
    public VideoFormat VideoFormat { get; set; }
    public FrameRate FrameRate { get; set; }
    public bool StereoscopicContent { get; set; }
    public BlurayIndexTitle? FirstPlaybackTitle { get; set; }
    public BlurayIndexTitle? TopMenuTitle { get; set; }
    public List<BlurayIndexTitle> Titles { get; set; } = [];

    public static string Name => "Bluray Index";
    public static string Extensions => ".bdmv";
    public static Endianness Endianness => Endianness.BigEndian;

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        Span<byte> buffer = stackalloc byte[4];

        // signature
        reader.ReadBytes(buffer);

        if (!buffer.SequenceEqual("INDX"u8))
            throw new InvalidDataException("Invalid Bluray Index format.");

        // version: 0200
        reader.ReadBytes(buffer);

        int indexesStartAddress = reader.ReadInt32();
        int extensionDataStartAddress = reader.ReadInt32();
        reader.Skip(24); // reserved

        // appInfo
        int appInfoLength = reader.ReadInt32();
        byte flags = reader.ReadByte();
        InitialOutputMode = (flags & 64) != 0 ? InitialOutputModePreference._3D : InitialOutputModePreference._2D;
        StereoscopicContent = (flags & 32) != 0;

        byte format = reader.ReadByte();
        VideoFormat = VideoFormat.Create(format >> 4);
        FrameRate = FrameRate.Create(format & 0xF);
        reader.Skip(32); // ContentProviderData

        // indexes table
        if (reader.Position < indexesStartAddress)
            reader.Skip(indexesStartAddress - reader.Position);

        int indexesLength = reader.ReadInt32();
        (FirstPlaybackTitle = new BlurayIndexTitle()).ReadFrom(ref reader);
        (TopMenuTitle = new BlurayIndexTitle()).ReadFrom(ref reader);

        int titleCount = reader.ReadUInt16();
        Titles = reader.ReadList(new List<BlurayIndexTitle>(), titleCount);
    }
}