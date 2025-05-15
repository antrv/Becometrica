namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlHintMode: uint
{
    /// <summary>
    /// The most efficient option should be chosen.
    /// </summary>
    Fastest = Constants.GL_FASTEST,

    /// <summary>
    /// The most correct, or highest quality, option should be chosen.
    /// </summary>
    Nicest = Constants.GL_NICEST,

    /// <summary>
    /// The client doesn't have a preference.
    /// </summary>
    DontCare = Constants.GL_DONT_CARE,
}