namespace Becometrica.Interop.Clang;

/**
 * Object encapsulating information about a module.modulemap file.
 */
public readonly struct CXModuleMapDescriptor(nint value)
{
    private readonly nint _value = value;
}