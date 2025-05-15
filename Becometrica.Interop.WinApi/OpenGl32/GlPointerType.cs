namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlPointerType: uint
{
    ColorArray = Constants.GL_COLOR_ARRAY_POINTER,
    EdgeFlagArray = Constants.GL_EDGE_FLAG_ARRAY_POINTER,
    FeedbackBuffer = Constants.GL_FEEDBACK_BUFFER_POINTER,
    IndexArray = Constants.GL_INDEX_ARRAY_POINTER,
    NormalArray = Constants.GL_NORMAL_ARRAY_POINTER,
    TextureCoordArray = Constants.GL_TEXTURE_COORD_ARRAY_POINTER,
    SelectionBuffer = Constants.GL_SELECTION_BUFFER_POINTER,
    VertexArray = Constants.GL_VERTEX_ARRAY_POINTER,
}