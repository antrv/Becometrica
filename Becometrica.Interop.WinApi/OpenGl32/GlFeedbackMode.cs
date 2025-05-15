namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlFeedbackMode: uint
{
    P2D = Constants.GL_2D,
    P3D = Constants.GL_3D,
    P3DColor = Constants.GL_3D_COLOR,
    P3DColorTexture = Constants.GL_3D_COLOR_TEXTURE,
    P4DColorTexture = Constants.GL_4D_COLOR_TEXTURE,
}