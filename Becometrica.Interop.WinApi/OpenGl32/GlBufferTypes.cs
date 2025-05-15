namespace Becometrica.Interop.WinApi.Opengl32;

[Flags]
public enum GlBufferTypes: uint
{
    None = 0,

    /// <summary>
    /// The buffers currently enabled for color writing.
    /// </summary>
    ColorBuffer = Constants.GL_COLOR_BUFFER_BIT,

    /// <summary>
    /// The depth buffer.
    /// </summary>
    DepthBuffer = Constants.GL_DEPTH_BUFFER_BIT,

    /// <summary>
    /// The accumulation buffer.
    /// </summary>
    AccumBuffer = Constants.GL_ACCUM_BUFFER_BIT,

    /// <summary>
    /// The stencil buffer.
    /// </summary>
    StencilBuffer = Constants.GL_STENCIL_BUFFER_BIT,
}