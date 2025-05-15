using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.Kernel32;

public static class Kernel32Lib
{
    private const string DllName = "kernel32";

    /// <summary>
    /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlew
    /// </summary>
    /// <param name="moduleName">The name of the loaded module (either a .dll or .exe file).</param>
    /// <returns>If the function succeeds, the return value is a handle to the specified module.
    /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
    [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern HInstance GetModuleHandleW(string? moduleName);
}