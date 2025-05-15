namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlMaterialParameter: uint
{
    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the ambient reflectance of
    /// the material. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Ambient = Constants.GL_AMBIENT,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the diffuse reflectance of
    /// the material. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Diffuse = Constants.GL_DIFFUSE,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the specular reflectance of
    /// the material. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Specular = Constants.GL_SPECULAR,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the emitted light intensity of
    /// the material. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Emission = Constants.GL_EMISSION,

    /// <summary>
    /// The params parameter returns one integer or floating-point value representing the specular exponent of
    /// the material. Integer values, when requested, are computed by rounding the internal floating-point value
    /// to the nearest integer value.
    /// </summary>
    Shininess = Constants.GL_SHININESS,

    /// <summary>
    /// Equivalent to calling glMaterial twice with the same parameter values,
    /// once with GL_AMBIENT and once with GL_DIFFUSE.
    /// </summary>
    AmbientAndDiffuse = Constants.GL_AMBIENT_AND_DIFFUSE,

    /// <summary>
    /// The params parameter returns three integer or floating-point values representing the ambient, diffuse,
    /// and specular indexes of the material. Use these indexes only for color-index lighting.
    /// (The other parameters are all used only for RGBA lighting.) Integer values, when requested, are computed
    /// by rounding the internal floating-point values to the nearest integer values.
    /// </summary>
    ColorIndexes = Constants.GL_COLOR_INDEXES,
}