namespace Becometrica.Interop.Clang;

/**
 * A particular source file that is part of a translation unit.
 */
public readonly struct CXFile(nint value)
{
    private readonly nint _value = value;
}