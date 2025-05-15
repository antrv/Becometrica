namespace Becometrica.Interop.Clang;

/**
 * Object encapsulating information about overlaying virtual
 * file/directories over the real file system.
 */
public readonly struct CXVirtualFileOverlay(nint value)
{
    private readonly nint _value = value;
}