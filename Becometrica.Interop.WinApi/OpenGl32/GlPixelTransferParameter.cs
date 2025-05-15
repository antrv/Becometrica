namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlPixelTransferParameter: uint
{
    MapColor = Constants.GL_MAP_COLOR,
    MapStencil = Constants.GL_MAP_STENCIL,
    IndexShift = Constants.GL_INDEX_SHIFT,
    IndexOffset = Constants.GL_INDEX_OFFSET,
    RedScale = Constants.GL_RED_SCALE,
    GreenScale = Constants.GL_GREEN_SCALE,
    BlueScale = Constants.GL_BLUE_SCALE,
    AlphaScale = Constants.GL_ALPHA_SCALE,
    DepthScale = Constants.GL_DEPTH_SCALE,
    RedBias = Constants.GL_RED_BIAS,
    GreenBias = Constants.GL_GREEN_BIAS,
    BlueBias = Constants.GL_BLUE_BIAS,
    AlphaBias = Constants.GL_ALPHA_BIAS,
    DepthBias = Constants.GL_DEPTH_BIAS,
}