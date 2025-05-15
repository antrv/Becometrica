using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.Gdi32;

public static class Gdi32Lib
{
    private const string DllName = "gdi32";

    [DllImport(DllName)]
    public static extern HBrush CreateSolidBrush(Color color);

    [DllImport(DllName)]
    public static extern Bool DeleteObject(HGdiObj obj);

    [DllImport(DllName)]
    public static extern int ChoosePixelFormat(HDc hdc, in PixelFormatDescriptor pfd);

    [DllImport(DllName)]
    public static extern Bool SetPixelFormat(HDc hdc, int format, in PixelFormatDescriptor pfd);
}