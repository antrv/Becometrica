namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlMapParameter: uint
{
    /// <summary>
    /// The v parameter returns the control points for the evaluator function. One-dimensional evaluators return
    /// order control points, and two-dimensional evaluators return uorder x vorder control points.
    /// Each control point consists of one, two, three, or four integer, single-precision floating-point,
    /// or double-precision floating-point values, depending on the type of the evaluator.
    /// Two-dimensional control points are returned in row-major order, incrementing the uorder index quickly,
    /// and the vorder index after each row. Integer values, when requested, are computed by rounding the internal
    /// floating-point values to the nearest integer values.
    /// </summary>
    Coeff = Constants.GL_COEFF,

    /// <summary>
    /// The v parameter returns the order of the evaluator function. One-dimensional evaluators return a single value,
    /// order. Two-dimensional evaluators return two values, uorder and vorder.
    /// </summary>
    Order = Constants.GL_ORDER,

    /// <summary>
    /// The v parameter returns the linear u and v mapping parameters. One-dimensional evaluators return two values,
    /// u 1 and u 2, as specified by glMap1. Two-dimensional evaluators return four values (u1, u2, v1, and v2)
    /// as specified by glMap2. Integer values, when requested, are computed by rounding the internal floating-point
    /// values to the nearest integer values.
    /// </summary>
    Domain = Constants.GL_DOMAIN,
}