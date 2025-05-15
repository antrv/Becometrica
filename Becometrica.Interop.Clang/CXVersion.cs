namespace Becometrica.Interop.Clang;

/**
 * Describes a version number of the form major.minor.subminor.
 */
public struct CXVersion
{
    /**
     * The major version number, e.g., the '10' in '10.7.3'. A negative
     * value indicates that there is no version number at all.
     */
    public int Major;

    /**
     * The minor version number, e.g., the '7' in '10.7.3'. This value
     * will be negative if no minor version number was provided, e.g., for
     * version '10'.
     */
    public int Minor;

    /**
     * The subminor version number, e.g., the '3' in '10.7.3'. This value
     * will be negative if no minor or subminor version number was provided,
     * e.g., in version '10' or '10.7'.
     */
    public int Subminor;
}