namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlError: uint
{
    /// <summary>
    /// An unacceptable value is specified for an enumerated argument. The offending function is ignored, having no side effect other than to set the error flag.
    /// </summary>
    InvalidEnum = Constants.GL_INVALID_ENUM,

    /// <summary>
    /// A numeric argument is out of range. The offending function is ignored, having no side effect other than to set the error flag.
    /// </summary>
    InvalidValue = Constants.GL_INVALID_VALUE,

    /// <summary>
    /// The specified operation is not allowed in the current state. The offending function is ignored, having no side effect other than to set the error flag.
    /// </summary>
    InvalidOperation = Constants.GL_INVALID_OPERATION,

    /// <summary>
    /// No error has been recorded. The value of this symbolic constant is guaranteed to be zero.
    /// </summary>
    NoError = Constants.GL_NO_ERROR,

    /// <summary>
    /// This function would cause a stack overflow. The offending function is ignored, having no side effect other than to set the error flag.
    /// </summary>
    StackOverflow = Constants.GL_STACK_OVERFLOW,

    /// <summary>
    /// This function would cause a stack underflow. The offending function is ignored, having no side effect other than to set the error flag.
    /// </summary>
    StackUnderflow = Constants.GL_STACK_UNDERFLOW,

    /// <summary>
    /// There is not enough memory left to execute the function. The state of OpenGL is undefined, except for the state of the error flags, after this error is recorded.
    /// </summary>
    OutOfMemory = Constants.GL_OUT_OF_MEMORY,
}