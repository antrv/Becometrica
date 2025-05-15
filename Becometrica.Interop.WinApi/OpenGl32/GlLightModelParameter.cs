namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlLightModelParameter: uint
{
    /// <summary>
    /// The params parameter contains four floating-point values that specify the ambient RGBA intensity of
    /// the entire scene. Integer values are mapped linearly such that the most positive representable value
    /// maps to 1.0, and the most negative representable value maps to -1.0. Floating-point values are mapped directly.
    /// Neither integer nor floating-point values are clamped. The default ambient scene intensity is
    /// (0.2, 0.2, 0.2, 1.0).
    /// </summary>
    Ambient = Constants.GL_LIGHT_MODEL_AMBIENT,

    /// <summary>
    /// The param parameter is a single floating-point value that specifies how specular reflection angles are computed.
    /// If param is 0 (or 0.0), specular reflection angles take the view direction to be parallel to and in
    /// the direction of the -z axis, regardless of the location of the vertex in eye coordinates. Otherwise,
    /// specular reflections are computed from the origin of the eye coordinate system. The default is 0.
    /// </summary>
    LocalViewer = Constants.GL_LIGHT_MODEL_LOCAL_VIEWER,

    /// <summary>
    /// The param parameter is a single floating-point value that specifies whether one-sided or two-sided lighting
    /// calculations are done for polygons. It has no effect on the lighting calculations for points, lines, or bitmaps.
    /// If param is 0 (or 0.0), one-sided lighting is specified, and only the front material parameters are used in
    /// the lighting equation. Otherwise, two-sided lighting is specified.
    /// In this case, vertices of back-facing polygons are lighted using the back material parameters,
    /// and have their normals reversed before the lighting equation is evaluated. Vertices of front-facing polygons
    /// are always lighted using the front material parameters, with no change to their normals. The default is 0.
    /// </summary>
    TwoSide = Constants.GL_LIGHT_MODEL_TWO_SIDE,
}