namespace Becometrica.Interop.WinApi.Opengl32;

/// <summary>
/// The comparison function.
/// </summary>
public enum GlTestFunction: uint
{
    /// <summary>
    /// Never passes.
    /// </summary>
    Never = Constants.GL_NEVER,

    /// <summary>
    /// Passes if the incoming value is less than the reference value.
    /// </summary>
    Less = Constants.GL_LESS,

    /// <summary>
    /// Passes if the incoming value is equal to the reference value.
    /// </summary>
    Equal = Constants.GL_EQUAL,

    /// <summary>
    /// Passes if the incoming value is less than or equal to the reference value.
    /// </summary>
    LessOrEqual = Constants.GL_LEQUAL,

    /// <summary>
    /// Passes if the incoming value is greater than the reference value.
    /// </summary>
    Greater = Constants.GL_GREATER,

    /// <summary>
    /// Passes if the incoming value is not equal to the reference value.
    /// </summary>
    NotEqual = Constants.GL_NOTEQUAL,

    /// <summary>
    /// Passes if the incoming value is greater than or equal to the reference value.
    /// </summary>
    GreaterOrEqual = Constants.GL_GEQUAL,

    /// <summary>
    /// Always passes. This is the default.
    /// </summary>
    Always = Constants.GL_ALWAYS,
}