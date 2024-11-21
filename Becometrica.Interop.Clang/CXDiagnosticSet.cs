namespace Becometrica.Interop.Clang;

/**
 * A group of CXDiagnostics.
 */
public readonly struct CXDiagnosticSet(nint value)
{
    private readonly nint _value = value;
}