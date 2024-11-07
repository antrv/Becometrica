using System.Text;
using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistItemAngle: IReadableObject
{
    public string ClipInformationFileName { get; set; } = string.Empty;
    public string ClipCodecIdentifier { get; set; } = string.Empty;
    public int RefToStcId { get; set; }

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        Span<byte> buffer = stackalloc byte[5];
        reader.ReadBytes(buffer);
        ClipInformationFileName = Encoding.UTF8.GetString(buffer).TrimEnd();
        Span<byte> buffer1 = buffer[..4];
        reader.ReadBytes(buffer1);
        ClipCodecIdentifier = Encoding.UTF8.GetString(buffer1).TrimEnd();
        RefToStcId = reader.ReadByte();
    }
}