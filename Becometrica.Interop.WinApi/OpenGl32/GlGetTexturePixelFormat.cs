namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlGetTexturePixelFormat: uint
{
    Red = Constants.GL_RED,
    Green = Constants.GL_GREEN,
    Blue = Constants.GL_BLUE,
    Alpha = Constants.GL_ALPHA,
    Rgb = Constants.GL_RGB,
    Rgba = Constants.GL_RGBA,
    Luminance = Constants.GL_LUMINANCE,
    BgrExt = Constants.GL_BGR_EXT,
    BgraExt = Constants.GL_BGRA_EXT,
    LuminanceAlpha = Constants.GL_LUMINANCE_ALPHA,
}