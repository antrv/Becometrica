namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlLogicOp: uint
{
    /// <summary>
    /// 0
    /// </summary>
    Clear = Constants.GL_CLEAR,
    /// <summary>
    /// 1
    /// </summary>
    Set = Constants.GL_SET,
    /// <summary>
    /// s
    /// </summary>
    Copy = Constants.GL_COPY,
    /// <summary>
    /// !s
    /// </summary>
    CopyInverted = Constants.GL_COPY_INVERTED,

    /// <summary>
    /// d
    /// </summary>
    Noop = Constants.GL_NOOP,

    /// <summary>
    /// !d
    /// </summary>
    Invert = Constants.GL_INVERT,

    /// <summary>
    /// s & d
    /// </summary>
    And = Constants.GL_AND,
    /// <summary>
    /// !(s & d)
    /// </summary>
    NAnd = Constants.GL_NAND,

    /// <summary>
    /// s | d
    /// </summary>
    Or = Constants.GL_OR,

    /// <summary>
    /// !(s | d)
    /// </summary>
    NOr = Constants.GL_NOR,

    /// <summary>
    /// s ^ d
    /// </summary>
    Xor = Constants.GL_XOR,

    /// <summary>
    /// !(s ^ d)
    /// </summary>
    Equiv = Constants.GL_EQUIV,

    /// <summary>
    /// s & !d
    /// </summary>
    AndReverse = Constants.GL_AND_REVERSE,

    /// <summary>
    /// !s & d
    /// </summary>
    AndInverted = Constants.GL_AND_INVERTED,

    /// <summary>
    /// s | !d
    /// </summary>
    OrReverse = Constants.GL_OR_REVERSE,

    /// <summary>
    /// !s | d
    /// </summary>
    OrInverted = Constants.GL_OR_INVERTED,
}