namespace Becometrica.Interop.Clang;

/**
 * Represents the command line invocation to compile a specific file.
 */
public readonly struct CXCompileCommand(nint value)
{
    private readonly nint _value = value;
}