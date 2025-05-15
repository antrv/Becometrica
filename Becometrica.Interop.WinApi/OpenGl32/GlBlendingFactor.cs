namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlBlendingFactor: uint
{
    Zero = Constants.GL_ZERO,
    One = Constants.GL_ONE,
    SrcColor = Constants.GL_SRC_COLOR,
    OneMinusSrcColor = Constants.GL_ONE_MINUS_SRC_COLOR,
    SrcAlpha = Constants.GL_SRC_ALPHA,
    OneMinusSrcAlpha = Constants.GL_ONE_MINUS_SRC_ALPHA,
    DstAlpha = Constants.GL_DST_ALPHA,
    OneMinusDstAlpha = Constants.GL_ONE_MINUS_DST_ALPHA,
    DstColor = Constants.GL_DST_COLOR,
    OneMinusDstColor = Constants.GL_ONE_MINUS_DST_COLOR,
    SrcAlphaSaturate = Constants.GL_SRC_ALPHA_SATURATE,
}