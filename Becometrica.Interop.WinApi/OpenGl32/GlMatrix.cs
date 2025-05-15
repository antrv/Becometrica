namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlMatrix: uint
{
    /// <summary>
    /// Applies subsequent matrix operations to the modelview matrix stack.
    /// </summary>
    ModelView = Constants.GL_MODELVIEW,

    /// <summary>
    /// Applies subsequent matrix operations to the projection matrix stack.
    /// </summary>
    Projection = Constants.GL_PROJECTION,

    /// <summary>
    /// Applies subsequent matrix operations to the texture matrix stack.
    /// </summary>
    Texture = Constants.GL_TEXTURE,
}