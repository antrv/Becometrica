namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlTextureLevelParameter: uint
{
    /// <summary>
    /// The params parameter returns a single value containing the width of the texture image.
    /// This value includes the border of the texture image.
    /// </summary>
    Width = Constants.GL_TEXTURE_WIDTH,

    /// <summary>
    /// The params parameter returns a single value containing the height of the texture image.
    /// This value includes the border of the texture image.
    /// </summary>
    Height = Constants.GL_TEXTURE_HEIGHT,

    /// <summary>
    /// The params parameter returns a single value which describes the texel format of the texture.
    /// </summary>
    InternalFormat = Constants.GL_TEXTURE_INTERNAL_FORMAT,

    /// <summary>
    /// The params parameter returns a single value: the width in pixels of the border of the texture image.
    /// </summary>
    Border = Constants.GL_TEXTURE_BORDER,

    /// <summary>
    /// The internal storage resolution of the red component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    RedSize = Constants.GL_TEXTURE_RED_SIZE,

    /// <summary>
    /// The internal storage resolution of the green component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    GreenSize = Constants.GL_TEXTURE_GREEN_SIZE,

    /// <summary>
    /// The internal storage resolution of the blue component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    BlueSize = Constants.GL_TEXTURE_BLUE_SIZE,

    /// <summary>
    /// The internal storage resolution of the alpha component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    AlphaSize = Constants.GL_TEXTURE_ALPHA_SIZE,

    /// <summary>
    /// The internal storage resolution of the luminance component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    LuminanceSize = Constants.GL_TEXTURE_LUMINANCE_SIZE,

    /// <summary>
    /// The internal storage resolution of the intensity component of a texel. The resolution chosen by the OpenGL
    /// will be a close match for the resolution requested by the user with the component argument of
    /// glTexImage1D or glTexImage2D.
    /// </summary>
    IntensitySize = Constants.GL_TEXTURE_INTENSITY_SIZE,

    /// <summary>
    /// The params parameter returns a single value: the number of components in the texture image.
    /// </summary>
    Components = Constants.GL_TEXTURE_COMPONENTS,
}