namespace Becometrica.Interop.Clang;

/**
 * A single translation unit, which resides in an index.
 */
public readonly struct CXTranslationUnit(nint value)
{
    private readonly nint _value = value;
}