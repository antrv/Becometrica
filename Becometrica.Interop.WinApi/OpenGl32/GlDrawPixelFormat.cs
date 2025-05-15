namespace Becometrica.Interop.WinApi.Opengl32;

/// <summary>
/// The format of the pixel data.
/// </summary>
public enum GlDrawPixelFormat: uint
{
    /// <summary>
    /// Each pixel is a single value, a color index.
    /// </summary>
    ColorIndex = Constants.GL_COLOR_INDEX,

    /// <summary>
    /// Each pixel is a single value, a stencil index.
    /// </summary>
    StencilIndex = Constants.GL_STENCIL_INDEX,

    /// <summary>
    /// Each pixel is a single-depth component.
    /// </summary>
    DepthComponent = Constants.GL_DEPTH_COMPONENT,

    /// <summary>
    /// Each pixel is a four-component group in this order: red, green, blue, alpha.
    /// </summary>
    Rgba = Constants.GL_RGBA,

    /// <summary>
    /// Each pixel is a single red component.
    /// </summary>
    Red = Constants.GL_RED,

    /// <summary>
    /// Each pixel is a single green component.
    /// </summary>
    Green = Constants.GL_GREEN,

    /// <summary>
    /// Each pixel is a single blue component.
    /// </summary>
    Blue = Constants.GL_BLUE,

    /// <summary>
    /// Each pixel is a single alpha component.
    /// </summary>
    Alpha = Constants.GL_ALPHA,

    /// <summary>
    /// Each pixel is a group of three components in this order: red, green, blue.
    /// </summary>
    Rgb = Constants.GL_RGB,

    /// <summary>
    /// Each pixel is a single luminance component.
    /// </summary>
    Luminance = Constants.GL_LUMINANCE,

    /// <summary>
    /// Each pixel is a group of two components in this order: luminance, alpha.
    /// </summary>
    LuminanceAlpha = Constants.GL_LUMINANCE_ALPHA,

    /// <summary>
    /// Each pixel is a group of three components in this order: blue, green, red.
    /// </summary>
    BgrExt = Constants.GL_BGR_EXT,

    /// <summary>
    /// Each pixel is a group of four components in this order: blue, green, red, alpha.
    /// </summary>
    BgraExt = Constants.GL_BGRA_EXT,
}