using System.Text;
using Becometrica.Binary;

namespace Becometrica.FileFormats.Bluray;

public sealed class BlurayPlaylistItemStream: IReadableObject
{
    public int StreamType { get; set; }
    public int RefToStreamPid { get; set; }
    public int RefToSubPathId { get; set; }
    public int RefToSubClipId { get; set; }
    public StreamCodingType StreamCodingType { get; set; }
    public VideoFormat VideoFormat { get; set; }
    public FrameRate FrameRate { get; set; }
    public DynamicRange DynamicRange { get; set; }
    public ColorSpace ColorSpace { get; set; }
    public bool Cr { get; set; } // ???
    public bool HdrPlus { get; set; }
    public AudioFormat AudioFormat { get; set; }
    public SampleRate SampleRate { get; set; }
    public CharacterCode CharacterCode { get; set; }
    public string Language { get; set; } = string.Empty;

    public void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        int length = reader.ReadByte();
        int position = reader.Position;
        StreamType = reader.ReadByte();
        switch (StreamType)
        {
            case 1:
                RefToStreamPid = reader.ReadUInt16();
                break;
            case 2:
                RefToSubPathId = reader.ReadByte();
                RefToSubClipId = reader.ReadByte();
                RefToStreamPid = reader.ReadUInt16();
                break;
            case 3:
            case 4:
                RefToSubPathId = reader.ReadByte();
                RefToStreamPid = reader.ReadUInt16();
                break;
        }

        int padding = length - (reader.Position - position);
        if (padding > 0)
            reader.Skip(padding);

        // attributes
        length = reader.ReadByte();
        position = reader.Position;
        StreamCodingType = (StreamCodingType)reader.ReadByte();
        switch (StreamCodingType)
        {
            case StreamCodingType.Mpeg1Video:
            case StreamCodingType.Mpeg2Video:
            case StreamCodingType.Mpeg4Avc:
            case StreamCodingType.SmtpeVc1:
            {
                int code = reader.ReadByte();
                VideoFormat = VideoFormat.Create(code >> 4);
                FrameRate = FrameRate.Create(code & 0xF);
                break;
            }

            case StreamCodingType.HevcVideo:
            {
                int code = reader.ReadByte();
                VideoFormat = VideoFormat.Create(code >> 4);
                FrameRate = FrameRate.Create(code & 0xF);
                code = reader.ReadByte();
                DynamicRange = (DynamicRange)(code >> 4);
                ColorSpace = (ColorSpace)(code & 0xF);
                code = reader.ReadByte();
                Cr = (code & 0x80) != 0;
                HdrPlus = (code & 0x40) != 0;
                break;
            }

            case StreamCodingType.Mpeg1Audio:
            case StreamCodingType.Mpeg2Audio:
            case StreamCodingType.LPcmAudio:
            case StreamCodingType.DolbyDigitalAudio:
            case StreamCodingType.DtsAudio:
            case StreamCodingType.DolbyDigitalTrueHdAudio:
            case StreamCodingType.DolbyDigitalPlusPrimaryAudio:
            case StreamCodingType.DtsHdHighResolutionAudio:
            case StreamCodingType.DtsHdMasterAudio:
            case StreamCodingType.DolbyDigitalPlusSecondaryAudio:
            case StreamCodingType.DtsHdAudio:
            {
                int code = reader.ReadByte();
                AudioFormat = (AudioFormat)(code >> 4);
                SampleRate = (SampleRate)(code & 0xF);
                Language = ReadLanguageCode(ref reader);
                break;
            }

            case StreamCodingType.PresentationGraphics:
            case StreamCodingType.InteractiveGraphics:
            {
                Language = ReadLanguageCode(ref reader);
                break;
            }

            case StreamCodingType.TextSubtitle:
            {
                CharacterCode = (CharacterCode)reader.ReadByte();
                Language = ReadLanguageCode(ref reader);
                break;
            }
        }

        padding = length - (reader.Position - position);
        if (padding > 0)
            reader.Skip(padding);
    }

    private static string ReadLanguageCode<TReader>(ref TReader reader)
        where TReader: struct, IBitReader
    {
        Span<byte> buffer = stackalloc byte[3];
        reader.ReadBytes(buffer);
        return Encoding.UTF8.GetString(buffer);
    }
}