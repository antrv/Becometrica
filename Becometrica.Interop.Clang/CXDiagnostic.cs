namespace Becometrica.Interop.Clang;

/**
 * A single diagnostic, containing the diagnostic's severity,
 * location, text, source ranges, and fix-it hints.
 */
public readonly struct CXDiagnostic(nint value)
{
    private readonly nint _value = value;
}