namespace Becometrica.Interop.Clang;

/**
 * Contains the results of a search in the compilation database
 *
 * When searching for the compile command for a file, the compilation db can
 * return several commands, as the file may have been compiled with
 * different options in different places of the project. This choice of compile
 * commands is wrapped in this opaque data structure. It must be freed by
 * \c clang_CompileCommands_dispose.
 */
public readonly struct CXCompileCommands(nint value)
{
    private readonly nint _value = value;
}