namespace Becometrica.Interop.Clang;

/**
 * A compilation database holds all information used to compile files in a
 * project. For each file in the database, it can be queried for the working
 * directory or the command line used for the compiler invocation.
 *
 * Must be freed by \c clang_CompilationDatabase_dispose
 */
public readonly struct CXCompilationDatabase(nint value)
{
    private readonly nint _value = value;
}