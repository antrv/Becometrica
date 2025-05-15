namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlStencilOp: uint
{
    /// <summary>
    /// Keeps the current value.
    /// </summary>
    Keep = Constants.GL_KEEP,

    /// <summary>
    /// Sets the stencil buffer value to zero.
    /// </summary>
    Zero = Constants.GL_ZERO,

    /// <summary>
    /// Sets the stencil buffer value to ref, as specified by glStencilFunc.
    /// </summary>
    Replace = Constants.GL_REPLACE,

    /// <summary>
    /// Increments the current stencil buffer value. Clamps to the maximum representable unsigned value.
    /// </summary>
    Increment = Constants.GL_INCR,

    /// <summary>
    /// Decrements the current stencil buffer value. Clamps to zero.
    /// </summary>
    Decrement = Constants.GL_DECR,

    /// <summary>
    /// Bitwise inverts the current stencil buffer value.
    /// </summary>
    Invert = Constants.GL_INVERT,
}