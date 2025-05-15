namespace Becometrica.Interop.WinApi.Opengl32;

/// <summary>
/// The accumulation buffer operation.
/// </summary>
public enum GlAccumOp: uint
{
    /// <summary>
    /// Obtains R, G, B, and A values from the buffer currently selected for reading (see glReadBuffer).
    /// Each component value is divided by 2^n-1, where n is the number of bits allocated to each color component
    /// in the currently selected buffer. The result is a floating-point value in the range [0,1],
    /// which is multiplied by value and added to the corresponding pixel component in the accumulation buffer,
    /// thereby updating the accumulation buffer.
    /// </summary>
    Accumulate = Constants.GL_ACCUM,

    /// <summary>
    /// Similar to GL_ACCUM, except that the current value in the accumulation buffer is not used in the calculation
    /// of the new value. That is, the R, G, B, and A values from the currently selected buffer are divided by 2^n-1,
    /// multiplied by value, and then stored in the corresponding accumulation buffer cell,
    /// overwriting the current value.
    /// </summary>
    Load = Constants.GL_LOAD,

    /// <summary>
    /// Transfers accumulation buffer values to the color buffer or buffers currently selected for writing.
    /// Each R, G, B, and A component is multiplied by value, then multiplied by 2^n-1, clamped to the range [0, 2^n-1],
    /// and stored in the corresponding display buffer cell. The only fragment operations that are applied
    /// to this transfer are pixel ownership, scissor, dithering, and color writemasks.
    /// </summary>
    Return = Constants.GL_RETURN,

    /// <summary>
    /// Multiplies each R, G, B, and A in the accumulation buffer by value and returns the scaled component
    /// to its corresponding accumulation buffer location.
    /// </summary>
    Multiply = Constants.GL_MULT,

    /// <summary>
    /// Adds value to each R, G, B, and A in the accumulation buffer.
    /// </summary>
    Add = Constants.GL_ADD,
}