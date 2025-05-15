namespace Becometrica.Interop.Clang;

/**
 * An "index" that consists of a set of translation units that would
 * typically be linked together into an executable or library.
 */
public readonly struct CXIndex(nint value)
{
    private readonly nint _value = value;
}