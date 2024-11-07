namespace Becometrica.FileFormats.Bluray;

public enum CharacterCode
{
    Utf8 = 0x01, // UTF-8
    Utf16Be = 0x02, // UTF-16BE
    ShiftJis = 0x03, // Shift-JIS
    Ksc5601_1987 = 0x04, // KSC 5601-1987 including KSC 5653 (also called EUC KR)
    Gb18030_2000 = 0x05, // GB18030-2000
    Gb2312 = 0x06, // GB2312
    Big5 = 0x07, // BIG5
}