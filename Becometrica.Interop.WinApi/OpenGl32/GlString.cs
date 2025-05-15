namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlString: uint
{
    /// <summary>
    /// Returns the company responsible for this OpenGL implementation.
    /// This name does not change from release to release.
    /// </summary>
    Vendor = Constants.GL_VENDOR,

    /// <summary>
    /// Returns the name of the renderer. This name is typically specific to a particular configuration of
    /// a hardware platform. It does not change from release to release.
    /// </summary>
    Renderer = Constants.GL_RENDERER,

    /// <summary>
    /// Returns a version or release number.
    /// </summary>
    Version = Constants.GL_VERSION,

    /// <summary>
    /// Returns a space-separated list of supported extensions to OpenGL.
    /// </summary>
    Extensions = Constants.GL_EXTENSIONS,
}