namespace Becometrica.FileFormats.Bluray;

public enum StreamCodingType
{
    Mpeg1Video = 0x01, // MPEG-1 video stream
    Mpeg2Video = 0x02, // MPEG-2 video stream
    Mpeg4Avc = 0x1B, // MPEG-4 AVC video stream
    Mpeg4Mvc = 0x20, // MPEG-4 MVC video stream
    SmtpeVc1 = 0xEA, // SMTPE VC-1 video stream
    HevcVideo = 0x24, // HEVC video stream (including DV stream),
    Mpeg1Audio = 0x03, // MPEG-1 audio stream
    Mpeg2Audio = 0x04, // MPEG-2 audio stream
    LPcmAudio = 0x80, // LPCM audio stream (primary audio)
    DolbyDigitalAudio = 0x81, // Dolby Digital audio stream (primary audio)
    DtsAudio = 0x82, // DTS audio stream (primary audio)
    DolbyDigitalTrueHdAudio = 0x83, // Dolby Digital TrueHD audio stream (primary audio)
    DolbyDigitalPlusPrimaryAudio = 0x84, // Dolby Digital Plus audio stream (primary audio)
    DtsHdHighResolutionAudio = 0x85, // DTS-HD High Resolution audio stream (primary audio)
    DtsHdMasterAudio = 0x86, // DTS-HD Master audio stream (primary audio)
    DolbyDigitalPlusSecondaryAudio = 0xA1, // Dolby Digital Plus audio stream (secondary audio)
    DtsHdAudio = 0xA2, // DTS-HD audio stream (secondary audio)
    PresentationGraphics = 0x90, // Presentation Graphics stream
    InteractiveGraphics = 0x91, // Interactive Graphics stream
    TextSubtitle = 0x92, // Text Subtitle stream
}