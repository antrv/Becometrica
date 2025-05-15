using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.User32;

public static class User32Lib
{
    private const string DllName = "user32";

    /// <summary>
    /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
    /// </summary>
    /// <param name="wndClass"></param>
    /// <returns>If the function succeeds, the return value is a class atom that uniquely
    /// identifies the class being registered. This atom can only be used by
    /// the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow, FindWindowEx,
    /// and UnregisterClass functions and the IActiveIMMap::FilterClientWindows method.
    /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
    [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern Atom RegisterClassW(in WndClass wndClass);

    [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern Atom RegisterClassExW(in WndClassEx wndClass);

    [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern HWnd CreateWindowExW(ExtendedWindowStyles exStyle, string? className, string? windowName,
        WindowStyles style, int x, int y, int width, int height, HWnd parent, HMenu menu, HInstance instance,
        nint param);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern LResult DefWindowProcW(HWnd hWnd, Message msg, WParam wParam, LParam lParam);

    /// <summary>
    /// Sets the specified window's show state.
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="cmdShow"></param>
    /// <returns>If the window was previously visible, the return value is nonzero.
    /// If the window was previously hidden, the return value is zero.</returns>
    [DllImport(DllName)]
    public static extern Bool ShowWindow(HWnd hWnd, CmdShow cmdShow);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern Bool GetMessageW(out Msg msg, HWnd hWnd, Message filterMin, Message filterMax);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern Bool TranslateMessage(in Msg msg);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern Bool DispatchMessageW(in Msg msg);

    [DllImport(DllName)]
    public static extern Bool DestroyWindow(HWnd hWnd);

    [DllImport(DllName)]
    public static extern void PostQuitMessage(int exitCode);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern MessageBoxResult MessageBoxW(HWnd hWnd, string? text, string? caption, MessageBoxType type);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern HDc BeginPaint(HWnd hWnd, out PaintStruct paint);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern Bool EndPaint(HWnd hWnd, in PaintStruct paint);

    [DllImport(DllName, CharSet = CharSet.Unicode)]
    public static extern int FillRect(HDc hdc, in Rect rc, HBrush hbr);

    [DllImport(DllName)]
    public static extern HDc GetDC(HWnd hWnd);

    [DllImport(DllName)]
    public static extern int ReleaseDC(HWnd hWnd, HDc hdc);
}