namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlRenderMode: uint
{
    /// <summary>
    /// Render mode. Primitives are rasterized, producing pixel fragments, which are written into the framebuffer.
    /// This is the normal mode and also the default mode.
    /// </summary>
    Render = Constants.GL_RENDER,

    /// <summary>
    /// Selection mode. No pixel fragments are produced, and no change to the framebuffer contents is made.
    /// Instead, a record of the names of primitives that would have been drawn if the render mode was GL_RENDER is
    /// returned in a select buffer, which must be created (see glSelectBuffer) before selection mode is entered.
    /// </summary>
    Select = Constants.GL_SELECT,

    /// <summary>
    /// Feedback mode. No pixel fragments are produced, and no change to the framebuffer contents is made.
    /// Instead, the coordinates and attributes of vertices that would have been drawn had the render mode been
    /// GL_RENDER are returned in a feedback buffer, which must be created (see glFeedbackBuffer) before
    /// feedback mode is entered.
    /// </summary>
    Feedback = Constants.GL_FEEDBACK,
}