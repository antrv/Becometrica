namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlDataType: uint
{
    /// <summary>
    /// The lists parameter is treated as an array of signed bytes, each in the range -128 through 127.
    /// </summary>
    Byte = Constants.GL_BYTE,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned bytes, each in the range 0 through 255.
    /// </summary>
    UnsignedByte = Constants.GL_UNSIGNED_BYTE,

    /// <summary>
    /// The lists parameter is treated as an array of signed 2-byte integers, each in the range -32768 through 32767.
    /// </summary>
    Short = Constants.GL_SHORT,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned 2-byte integers, each in the range 0 through 65535.
    /// </summary>
    UnsignedShort = Constants.GL_UNSIGNED_SHORT,

    /// <summary>
    /// The lists parameter is treated as an array of signed 4-byte integers.
    /// </summary>
    Int = Constants.GL_INT,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned 4-byte integers.
    /// </summary>
    UnsignedInt = Constants.GL_UNSIGNED_INT,

    /// <summary>
    /// The lists parameter is treated as an array of 4-byte, floating-point values.
    /// </summary>
    Float = Constants.GL_FLOAT,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned bytes. Each pair of bytes specifies
    /// a single display-list name. The value of the pair is computed as 256 times the unsigned value
    /// of the first byte plus the unsigned value of the second byte.
    /// </summary>
    TwoBytes = Constants.GL_2_BYTES,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned bytes. Each triplet of bytes specifies
    /// a single display list name. The value of the triplet is computed as 65536 times the unsigned value
    /// of the first byte, plus 256 times the unsigned value of the second byte, plus the unsigned value
    /// of the third byte.
    /// </summary>
    ThreeBytes = Constants.GL_3_BYTES,

    /// <summary>
    /// The lists parameter is treated as an array of unsigned bytes. Each quadruplet of bytes specifies
    /// a single display list name. The value of the quadruplet is computed as 16777216 times
    /// the unsigned value of the first byte, plus 65536 times the unsigned value of the second byte,
    /// plus 256 times the unsigned value of the third byte, plus the unsigned value of the fourth byte.
    /// </summary>
    FourBytes = Constants.GL_4_BYTES,

    /// <summary>
    /// The lists parameter is treated as an array of 8-byte, floating-point values.
    /// </summary>
    Double = Constants.GL_DOUBLE,
}