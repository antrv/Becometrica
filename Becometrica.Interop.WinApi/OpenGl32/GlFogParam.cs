namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlFogParam: uint
{
    /// <summary>
    /// The parameter value is a single floating-point value that specifies the equation to be used to compute
    /// the fog blend factor, f. Three symbolic constants are accepted: GL_LINEAR, GL_EXP, and GL_EXP2.
    /// The equations corresponding to these symbolic constants are defined in the following Remarks section.
    /// The default fog mode is GL_EXP.
    /// </summary>
    Mode = Constants.GL_FOG_MODE,

    /// <summary>
    /// The parameter value is a single floating-point value that specifies density, the fog density used
    /// in both exponential fog equations. Only nonnegative densities are accepted. The default fog density is 1.0.
    /// </summary>
    Density = Constants.GL_FOG_DENSITY,

    /// <summary>
    /// The parameter value is a single floating-point value that specifies start, the near distance used
    /// in the linear fog equation. The default near distance is 0.0.
    /// </summary>
    Start = Constants.GL_FOG_START,

    /// <summary>
    /// The parameter value is a single floating-point value that specifies end, the far distance used in
    /// the linear fog equation. The default far distance is 1.0.
    /// </summary>
    End = Constants.GL_FOG_END,

    /// <summary>
    /// The parameter value is a single floating-point value that specifies if, the fog color index.
    /// The default fog index is 0.0.
    /// </summary>
    Index = Constants.GL_FOG_INDEX,

    /// <summary>
    /// The parameter value contains four floating-point values that specify Cf, the fog color.
    /// Integer values are mapped linearly such that the most positive representable value maps to 1.0,
    /// and the most negative representable value maps to -1.0. Floating-point values are mapped directly.
    /// After conversion, all color components are clamped to the range [0,1]. The default fog color is (0,0,0,0).
    /// </summary>
    Color = Constants.GL_FOG_COLOR,
}