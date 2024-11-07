using Becometrica.Binary;

namespace Becometrica.FileFormats;

public static class FileFormatExtensions
{
    public static void ReadFrom<T>(this T fileFormat, ReadOnlyMemory<byte> memory)
        where T: IFileFormat
    {
        switch (T.Endianness)
        {
            case Endianness.LittleEndian:
            {
                MemoryBitReader<LittleEndianBitConverter> reader = new(memory);
                fileFormat.ReadFrom(ref reader);
                break;
            }

            case Endianness.BigEndian:
            {
                MemoryBitReader<BigEndianBitConverter> reader = new(memory);
                fileFormat.ReadFrom(ref reader);
                break;
            }

            case Endianness.NativeEndian:
            default:
            {
                MemoryBitReader<NativeEndianBitConverter> reader = new(memory);
                fileFormat.ReadFrom(ref reader);
                break;
            }
        }
    }

    public static void ReadFrom<T>(this T fileFormat, Stream stream)
        where T: IFileFormat
    {
        switch (T.Endianness)
        {
            case Endianness.LittleEndian:
            {
                StreamBitReader<LittleEndianBitConverter> reader = new(stream);
                fileFormat.ReadFrom(ref reader);
                break;
            }

            case Endianness.BigEndian:
            {
                StreamBitReader<BigEndianBitConverter> reader = new(stream);
                fileFormat.ReadFrom(ref reader);
                break;
            }

            case Endianness.NativeEndian:
            default:
            {
                StreamBitReader<NativeEndianBitConverter> reader = new(stream);
                fileFormat.ReadFrom(ref reader);
                break;
            }
        }
    }

    public static void ReadFrom<T>(this T fileFormat, string filePath)
        where T: IFileFormat
    {
        using FileStream fs = File.OpenRead(filePath);
        fileFormat.ReadFrom(fs);
    }

    public static List<T> ReadList<T, TReader>(this ref TReader reader, List<T> list, int count)
        where T: IReadableObject, new()
        where TReader: struct, IBitReader
    {
        for (int i = 0; i < count; i++)
        {
            T item = new();
            item.ReadFrom(ref reader);
            list.Add(item);
        }

        return list;
    }
}