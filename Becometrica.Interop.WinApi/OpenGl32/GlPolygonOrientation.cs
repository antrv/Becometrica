namespace Becometrica.Interop.WinApi.Opengl32;

/// <summary>
/// The orientation of front-facing polygons.
/// </summary>
public enum GlPolygonOrientation: uint
{
    ClockWise = Constants.GL_CW,
    CounterClockWise = Constants.GL_CCW,
}