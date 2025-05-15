namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlTextureEnvParameter: uint
{
    /// <summary>
    /// The params parameter returns the single-valued texture environment mode, a symbolic constant.
    /// </summary>
    Mode = Constants.GL_TEXTURE_ENV_MODE,

    /// <summary>
    /// The params parameter returns four integer or floating-point values that are the texture environment color.
    /// Integer values, when requested, are linearly mapped from the internal floating-point representation such
    /// that 1.0 maps to the most positive representable integer, and -1.0 maps to
    /// the most negative representable integer.
    /// </summary>
    Color = Constants.GL_TEXTURE_ENV_COLOR,
}