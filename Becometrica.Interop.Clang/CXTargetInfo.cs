namespace Becometrica.Interop.Clang;

/**
 * An opaque type representing target information for a given translation
 * unit.
 */
public readonly struct CXTargetInfo(nint value)
{
    private readonly nint _value = value;
}