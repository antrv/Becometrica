namespace Becometrica.Interop.WinApi.Opengl32;

/// <summary>
/// The target to which the texture is bound.
/// </summary>
public enum GlTextureTarget: uint
{
    Texture1D = Constants.GL_TEXTURE_1D,
    Texture2D = Constants.GL_TEXTURE_2D,
}