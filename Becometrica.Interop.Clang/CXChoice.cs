namespace Becometrica.Interop.Clang;

public enum CXChoice
{
    /**
     * Use the default value of an option that may depend on the process
     * environment.
     */
    CXChoice_Default = 0,

    /**
     * Enable the option.
     */
    CXChoice_Enabled = 1,

    /**
     * Disable the option.
     */
    CXChoice_Disabled = 2
}