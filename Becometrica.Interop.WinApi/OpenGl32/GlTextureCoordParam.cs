namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlTextureCoordParam: uint
{
    /// <summary>
    /// The params parameter returns the single-valued texture generation function, a symbolic constant.
    /// </summary>
    GenMode = Constants.GL_TEXTURE_GEN_MODE,

    /// <summary>
    /// The params parameter returns the four plane equation coefficients that specify object linear-coordinate
    /// generation. Integer values, when requested, are mapped directly from the internal floating-point representation.
    /// </summary>
    ObjectPlane = Constants.GL_OBJECT_PLANE,

    /// <summary>
    /// The params parameter returns the four plane equation coefficients that specify eye linear-coordinate generation.
    /// Integer values, when requested, are mapped directly from the internal floating-point representation.
    /// The returned values are those maintained in eye coordinates. They are not equal to the values specified using
    /// glTexGen, unless the modelview matrix was identified at the time glTexGen was called.
    /// </summary>
    EyePlane = Constants.GL_EYE_PLANE,
}