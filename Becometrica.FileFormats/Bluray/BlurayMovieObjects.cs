using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayMovieObjects: IFileFormat
{
    // https://github.com/lw/BluRay/wiki/MOBJ
    public List<BlurayMovieObject> Objects { get; set; } = [];

    public static string Name => "Bluray Movie Object";
    public static string Extensions => ".bdmv";
    public static Endianness Endianness => Endianness.BigEndian;

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        Span<byte> buffer = stackalloc byte[4];

        // signature
        reader.ReadBytes(buffer);

        if (!buffer.SequenceEqual("MOBJ"u8))
            throw new InvalidDataException("Invalid Bluray Movie Object format.");

        // version: 0200
        reader.ReadBytes(buffer);

        int extensionDataStartAddress = reader.ReadInt32();
        reader.Skip(28); // reserved

        // Movie objects
        int movieObjectsLength = reader.ReadInt32();
        reader.Skip(4); // reserved
        int movieObjectCount = reader.ReadUInt16();
        Objects = reader.ReadList(new List<BlurayMovieObject>(), movieObjectCount);
    }
}