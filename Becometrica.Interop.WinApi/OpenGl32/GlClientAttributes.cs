namespace Becometrica.Interop.WinApi.Opengl32;

[Flags]
public enum GlClientAttributes: uint
{
    None = 0,

    /// <summary>
    /// Pixel storage mode attributes.
    /// </summary>
    PixelStore = Constants.GL_CLIENT_PIXEL_STORE_BIT,

    /// <summary>
    /// Vertex array attributes.
    /// </summary>
    VertexArray = Constants.GL_CLIENT_VERTEX_ARRAY_BIT,

    /// <summary>
    /// All stackable client-state attributes.
    /// </summary>
    All = Constants.GL_CLIENT_ALL_ATTRIB_BITS,
}