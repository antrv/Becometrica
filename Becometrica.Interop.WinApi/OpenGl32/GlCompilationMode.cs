namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlCompilationMode: uint
{
    /// <summary>
    /// Commands are merely compiled.
    /// </summary>
    Compile = Constants.GL_COMPILE,

    /// <summary>
    /// Commands are executed as they are compiled into the display list.
    /// </summary>
    CompileAndExecute = Constants.GL_COMPILE_AND_EXECUTE,
}