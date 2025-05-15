namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlTextureParameter: uint
{
    /// <summary>
    /// Returns the single-valued texture magnification filter, a symbolic constant.
    /// </summary>
    MagFilter = Constants.GL_TEXTURE_MAG_FILTER,

    /// <summary>
    /// Returns the single-valued texture minification filter, a symbolic constant.
    /// </summary>
    MinFilter = Constants.GL_TEXTURE_MIN_FILTER,

    /// <summary>
    /// Returns the single-valued wrapping function for texture coordinate s, a symbolic constant.
    /// </summary>
    WrapS = Constants.GL_TEXTURE_WRAP_S,

    /// <summary>
    /// Returns the single-valued wrapping function for texture coordinate t, a symbolic constant.
    /// </summary>
    WrapT = Constants.GL_TEXTURE_WRAP_T,

    /// <summary>
    /// Returns four integer or floating-point numbers that comprise the RGBA color of the texture border.
    /// Floating-point values are returned in the range [0,1]. Integer values are returned as a linear mapping
    /// of the internal floating-point representation such that 1.0 maps to the most positive representable integer
    /// and -1.0 maps to the most negative representable integer.
    /// </summary>
    BorderColor = Constants.GL_TEXTURE_BORDER_COLOR,

    /// <summary>
    /// Returns the residence priority of the target texture (or the named texture bound to it).
    /// The initial value is 1. See glPrioritizeTextures.
    /// </summary>
    Priority = Constants.GL_TEXTURE_PRIORITY,

    /// <summary>
    /// Returns the residence status of the target texture. If the value returned in params is GL_TRUE,
    /// the texture is resident in texture memory. See glAreTexturesResident.
    /// </summary>
    Resident = Constants.GL_TEXTURE_RESIDENT,
}