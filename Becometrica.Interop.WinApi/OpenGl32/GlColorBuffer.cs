namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlColorBuffer: uint
{
    /// <summary>
    /// No color buffers are written.
    /// </summary>
    None = Constants.GL_NONE,

    /// <summary>
    /// Only the front-left color buffer is written.
    /// </summary>
    FrontLeft = Constants.GL_FRONT_LEFT,

    /// <summary>
    /// Only the front-right color buffer is written.
    /// </summary>
    FrontRight = Constants.GL_FRONT_RIGHT,

    /// <summary>
    /// Only the back-left color buffer is written.
    /// </summary>
    BackLeft = Constants.GL_BACK_LEFT,

    /// <summary>
    /// Only the back-right color buffer is written.
    /// </summary>
    BackRight = Constants.GL_BACK_RIGHT,

    /// <summary>
    /// Only the front-left and front-right color buffers are written. If there is no front-right color buffer, only the front left-color buffer is written.
    /// </summary>
    Front = Constants.GL_FRONT,

    /// <summary>
    /// Only the back-left and back-right color buffers are written. If there is no back-right color buffer, only the back-left color buffer is written.
    /// </summary>
    Back = Constants.GL_BACK,

    /// <summary>
    /// Only the front-left and back-left color buffers are written. If there is no back-left color buffer, only the front-left color buffer is written.
    /// </summary>
    Left = Constants.GL_LEFT,

    /// <summary>
    /// Only the front-right and back-right color buffers are written. If there is no back-right color buffer, only the front-right color buffer is written.
    /// </summary>
    Right = Constants.GL_RIGHT,

    /// <summary>
    /// All the front and back color buffers (front-left, front-right, back-left, back-right) are written. If there are no back color buffers, only the front-left and front-right color buffers are written. If there are no right color buffers, only the front-left and back-left color buffers are written. If there are no right or back color buffers, only the front-left color buffer is written.
    /// </summary>
    FrontAndBack = Constants.GL_FRONT_AND_BACK,

    /// <summary>
    /// Only the auxiliary color buffer 0 is written.
    /// </summary>
    Aux0 = Constants.GL_AUX0,

    /// <summary>
    /// Only the auxiliary color buffer 1 is written.
    /// </summary>
    Aux1 = Constants.GL_AUX1,

    /// <summary>
    /// Only the auxiliary color buffer 2 is written.
    /// </summary>
    Aux2 = Constants.GL_AUX2,

    /// <summary>
    /// Only the auxiliary color buffer 3 is written.
    /// </summary>
    Aux3 = Constants.GL_AUX3,
}