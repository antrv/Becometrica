namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlPolygonMode: uint
{
    /// <summary>
    /// Polygon vertices that are marked as the start of a boundary edge are drawn as points.
    /// Point attributes such as GL_POINT_SIZE and GL_POINT_SMOOTH control the rasterization of the points.
    /// Polygon rasterization attributes other than GL_POLYGON_MODE have no effect.
    /// </summary>
    Point = Constants.GL_POINT,

    /// <summary>
    /// Boundary edges of the polygon are drawn as line segments. They are treated as connected line segments for
    /// line stippling; the line stipple counter and pattern are not reset between segments (see glLineStipple).
    /// Line attributes such as GL_LINE_WIDTH and GL_LINE_SMOOTH control the rasterization of the lines.
    /// Polygon rasterization attributes other than GL_POLYGON_MODE have no effect.
    /// </summary>
    Line = Constants.GL_LINE,

    /// <summary>
    /// The interior of the polygon is filled. Polygon attributes such as GL_POLYGON_STIPPLE and GL_POLYGON_SMOOTH
    /// control the rasterization of the polygon.
    /// </summary>
    Fill = Constants.GL_FILL,
}