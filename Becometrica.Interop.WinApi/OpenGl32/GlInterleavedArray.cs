namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlInterleavedArray: uint
{
    V2F = Constants.GL_V2F,
    V3F = Constants.GL_V3F,
    C4UB_V2F = Constants.GL_C4UB_V2F,
    C4UB_V3F = Constants.GL_C4UB_V3F,
    C3F_V3F = Constants.GL_C3F_V3F,
    N3F_V3F = Constants.GL_N3F_V3F,
    C4F_N3F_V3F = Constants.GL_C4F_N3F_V3F,
    T2F_V3F = Constants.GL_T2F_V3F,
    T4F_V4F = Constants.GL_T4F_V4F,
    T2F_C4UB_V3F = Constants.GL_T2F_C4UB_V3F,
    T2F_C3F_V3F = Constants.GL_T2F_C3F_V3F,
    T2F_N3F_V3F = Constants.GL_T2F_N3F_V3F,
    T2F_C4F_N3F_V3F = Constants.GL_T2F_C4F_N3F_V3F,
    T4F_C4F_N3F_V4F = Constants.GL_T4F_C4F_N3F_V4F,
}