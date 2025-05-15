namespace Becometrica.Interop.WinApi.Opengl32;

[Flags]
public enum GlAttributes: uint
{
    None = 0,
    Current = Constants.GL_CURRENT_BIT,
    Point = Constants.GL_POINT_BIT,
    Line = Constants.GL_LINE_BIT,
    Polygon = Constants.GL_POLYGON_BIT,
    PolygonStipple = Constants.GL_POLYGON_STIPPLE_BIT,
    PixelMode = Constants.GL_PIXEL_MODE_BIT,
    Lighting = Constants.GL_LIGHTING_BIT,
    Fog = Constants.GL_FOG_BIT,
    DepthBuffer = Constants.GL_DEPTH_BUFFER_BIT,
    AccumBuffer = Constants.GL_ACCUM_BUFFER_BIT,
    StencilBuffer = Constants.GL_STENCIL_BUFFER_BIT,
    Viewport = Constants.GL_VIEWPORT_BIT,
    Transform = Constants.GL_TRANSFORM_BIT,
    Enable = Constants.GL_ENABLE_BIT,
    ColorBuffer = Constants.GL_COLOR_BUFFER_BIT,
    Hint = Constants.GL_HINT_BIT,
    Eval = Constants.GL_EVAL_BIT,
    List = Constants.GL_LIST_BIT,
    Texture = Constants.GL_TEXTURE_BIT,
    Scissor = Constants.GL_SCISSOR_BIT,
    All = Constants.GL_ALL_ATTRIB_BITS,
}