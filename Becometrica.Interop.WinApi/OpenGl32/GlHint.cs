namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlHint: uint
{
    /// <summary>
    /// Indicates the accuracy of fog calculation. If per-pixel fog calculation is not efficiently supported
    /// by the OpenGL implementation, hinting GL_DONT_CARE or GL_FASTEST can result in per-vertex calculation
    /// of fog effects.
    /// </summary>
    Fog = Constants.GL_FOG_HINT,

    /// <summary>
    /// Indicates the sampling quality of antialiased lines. Hinting GL_NICEST can result in more pixel fragments
    /// being generated during rasterization, if a larger filter function is applied.
    /// </summary>
    LineSmooth = Constants.GL_LINE_SMOOTH_HINT,

    /// <summary>
    /// Indicates the quality of color and texture coordinate interpolation. If perspective-corrected parameter
    /// interpolation is not efficiently supported by the OpenGL implementation, hinting GL_DONT_CARE or GL_FASTEST
    /// can result in simple linear interpolation of colors and/or texture coordinates.
    /// </summary>
    PerspectiveCorrection = Constants.GL_PERSPECTIVE_CORRECTION_HINT,

    /// <summary>
    /// Indicates the sampling quality of antialiased points. Hinting GL_NICEST can result in more pixel fragments
    /// being generated during rasterization, if a larger filter function is applied.
    /// </summary>
    PointSmooth = Constants.GL_POINT_SMOOTH_HINT,

    /// <summary>
    /// Indicates the sampling quality of antialiased polygons. Hinting GL_NICEST can result in more pixel fragments
    /// being generated during rasterization, if a larger filter function is applied.
    /// </summary>
    PolygonSmooth = Constants.GL_POLYGON_SMOOTH_HINT,
}