namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlArray: uint
{
    /// <summary>
    /// If enabled, use color arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glColorPointer.
    /// </summary>
    Color = Constants.GL_COLOR_ARRAY,

    /// <summary>
    /// If enabled, use edge flag arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glEdgeFlagPointer.
    /// </summary>
    EdgeFlag = Constants.GL_EDGE_FLAG_ARRAY,

    /// <summary>
    /// If enabled, use index arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glIndexPointer.
    /// </summary>
    Index = Constants.GL_INDEX_ARRAY,

    /// <summary>
    /// If enabled, use normal arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glNormalPointer.
    /// </summary>
    Normal = Constants.GL_NORMAL_ARRAY,

    /// <summary>
    /// If enabled, use texture coordinate arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glTexCoordPointer.
    /// </summary>
    TextureCoord = Constants.GL_TEXTURE_COORD_ARRAY,

    /// <summary>
    /// If enabled, use vertex arrays with calls to glArrayElement, glDrawElements, or glDrawArrays.
    /// See also glVertexPointer.
    /// </summary>
    Vertex = Constants.GL_VERTEX_ARRAY,
}