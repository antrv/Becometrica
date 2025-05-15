namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlMap1DValue: uint
{
    /// <summary>
    /// Each control point is three floating-point values representing x, y, and z. Internal glVertex3 commands are generated when the map is evaluated.
    /// </summary>
    Vertex3 = Constants.GL_MAP1_VERTEX_3,

    /// <summary>
    /// Each control point is four floating-point values representing x, y, z, and w. Internal glVertex4 commands are generated when the map is evaluated.
    /// </summary>
    Vertex4 = Constants.GL_MAP1_VERTEX_4,

    /// <summary>
    /// Each control point is a single floating-point value representing a color index. Internal glIndex commands are generated when the map is evaluated. However, the current index is not updated with the value of these glIndex commands.
    /// </summary>
    Index = Constants.GL_MAP1_INDEX,

    /// <summary>
    /// Each control point is four floating-point values representing red, green, blue, and alpha. Internal glColor4 commands are generated when the map is evaluated. However, the current color is not updated with the value of these glColor4 commands.
    /// </summary>
    Color4 = Constants.GL_MAP1_COLOR_4,

    /// <summary>
    /// Each control point is three floating-point values representing the x, y, and z components of a normal vector. Internal glNormal commands are generated when the map is evaluated. However, the current normal is not updated with the value of these glNormal commands.
    /// </summary>
    Normal = Constants.GL_MAP1_NORMAL,

    /// <summary>
    /// Each control point is a single floating-point value representing the s texture coordinate. Internal glTexCoord1 commands are generated when the map is evaluated. However, the current texture coordinates are not updated with the value of these glTexCoord commands.
    /// </summary>
    TextureCoord1 = Constants.GL_MAP1_TEXTURE_COORD_1,

    /// <summary>
    /// Each control point is two floating-point values representing the s and t texture coordinates. Internal glTexCoord2 commands are generated when the map is evaluated. However, the current texture coordinates are not updated with the value of these glTexCoord commands.
    /// </summary>
    TextureCoord2 = Constants.GL_MAP1_TEXTURE_COORD_2,

    /// <summary>
    /// Each control point is three floating-point values representing the s, t, and r texture coordinates. Internal glTexCoord3 commands are generated when the map is evaluated. However, the current texture coordinates are not updated with the value of these glTexCoord commands.
    /// </summary>
    TextureCoord3 = Constants.GL_MAP1_TEXTURE_COORD_3,

    /// <summary>
    /// Each control point is four floating-point values representing the s, t, r, and q texture coordinates. Internal glTexCoord4 commands are generated when the map is evaluated. However, the current texture coordinates are not updated with the value of these glTexCoord commands.
    /// </summary>
    TextureCoord4 = Constants.GL_MAP1_TEXTURE_COORD_4,
}