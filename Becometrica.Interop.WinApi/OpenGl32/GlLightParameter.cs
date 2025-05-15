namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlLightParameter: uint
{
    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the ambient intensity of
    /// the light source. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Ambient = Constants.GL_AMBIENT,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the diffuse intensity of
    /// the light source. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Diffuse = Constants.GL_DIFFUSE,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the specular intensity of
    /// the light source. Integer values, when requested, are linearly mapped from the internal floating-point
    /// representation such that 1.0 maps to the most positive representable integer value, and -1.0 maps to
    /// the most negative representable integer value. If the internal value is outside the range [-1,1],
    /// the corresponding integer return value is undefined.
    /// </summary>
    Specular = Constants.GL_SPECULAR,

    /// <summary>
    /// The params parameter returns four integer or floating-point values representing the position of
    /// the light source. Integer values, when requested, are computed by rounding the internal floating-point
    /// values to the nearest integer value. The returned values are those maintained in eye coordinates.
    /// They will not be equal to the values specified using glLight, unless the modelview matrix was identified
    /// at the time glLight was called.
    /// </summary>
    Position = Constants.GL_POSITION,

    /// <summary>
    /// The params parameter returns three integer or floating-point values representing the direction of
    /// the light source. Integer values, when requested, are computed by rounding the internal floating-point
    /// values to the nearest integer value. The returned values are those maintained in eye coordinates.
    /// They will not be equal to the values specified using glLight, unless the modelview matrix was identified
    /// at the time glLight was called. Although spot direction is normalized before being used in the lighting
    /// equation, the returned values are the transformed versions of the specified values prior to normalization.
    /// </summary>
    SpotDirection = Constants.GL_SPOT_DIRECTION,

    /// <summary>
    /// The params parameter returns a single integer or floating-point value representing the spot exponent of
    /// the light. An integer value, when requested, is computed by rounding the internal floating-point
    /// representation to the nearest integer.
    /// </summary>
    SpotExponent = Constants.GL_SPOT_EXPONENT,

    /// <summary>
    /// The params parameter returns a single integer or floating-point value representing the spot cutoff angle of
    /// the light. An integer value, when requested, is computed by rounding the internal floating-point
    /// representation to the nearest integer.
    /// </summary>
    SpotCutoff = Constants.GL_SPOT_CUTOFF,

    /// <summary>
    /// The params parameter returns a single integer or floating-point value representing the constant
    /// (not distance-related) attenuation of the light. An integer value, when requested, is computed by
    /// rounding the internal floating-point representation to the nearest integer.
    /// </summary>
    ConstantAttenuation = Constants.GL_CONSTANT_ATTENUATION,

    /// <summary>
    /// The params parameter returns a single integer or floating-point value representing the linear attenuation of
    /// the light. An integer value, when requested, is computed by rounding the internal floating-point representation
    /// to the nearest integer.
    /// </summary>
    LinearAttenuation = Constants.GL_LINEAR_ATTENUATION,

    /// <summary>
    /// The params parameter returns a single integer or floating-point value representing the quadratic attenuation of
    /// the light. An integer value, when requested, is computed by rounding the internal floating-point representation
    /// to the nearest integer.
    /// </summary>
    QuadraticAttenuation = Constants.GL_QUADRATIC_ATTENUATION,
}