using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.User32;

/// <summary>
/// Contains the window class attributes that are registered by the RegisterClass function.
/// </summary>
public struct WndClass
{
    /// <summary>
    /// The class style(s). This member can be any combination of the Class Styles.
    /// </summary>
    public WindowClassStyles Style;

    /// <summary>
    /// A pointer to the window procedure.
    /// </summary>
    public WndProc WndProc;

    /// <summary>
    /// The number of extra bytes to allocate following the window-class structure.
    /// The system initializes the bytes to zero.
    /// </summary>
    public int ClsExtra;

    /// <summary>
    /// The number of extra bytes to allocate following the window instance.
    /// The system initializes the bytes to zero. If an application uses WNDCLASS to register a dialog box
    /// created by using the CLASS directive in the resource file, it must set this member to DLGWINDOWEXTRA.
    /// </summary>
    public int WndExtra;

    /// <summary>
    /// A handle to the instance that contains the window procedure for the class.
    /// </summary>
    public HInstance Instance;

    /// <summary>
    /// A handle to the class icon. This member must be a handle to an icon resource.
    /// If this member is NULL, the system provides a default icon.
    /// </summary>
    public HIcon Icon;

    /// <summary>
    /// A handle to the class cursor. This member must be a handle to a cursor resource.
    /// If this member is NULL, an application must explicitly set the cursor shape whenever
    /// the mouse moves into the application's window.
    /// </summary>
    public HCursor Cursor;

    /// <summary>
    /// A handle to the class background brush. This member can be a handle to the physical brush
    /// to be used for painting the background, or it can be a color value.
    /// A color value must be one of the following standard system colors
    /// (the value 1 must be added to the chosen color).
    /// </summary>
    public HBrush Background;

    /// <summary>
    /// The resource name of the class menu, as the name appears in the resource file.
    /// If this member is NULL, windows belonging to this class have no default menu.
    /// </summary>
    public string? MenuName;

    /// <summary>
    /// A pointer to a null-terminated string or is an atom. If this parameter is an atom,
    /// it must be a class atom created by a previous call to the RegisterClass or RegisterClassEx function.
    /// The atom must be in the low-order word of ClassName; the high-order word must be zero.
    /// If lpszClassName is a string, it specifies the window class name. The class name can
    /// be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
    /// The maximum length for ClassName is 256. If ClassName is greater than the maximum length,
    /// the RegisterClass function will fail.
    /// </summary>
    public string? ClassName;
}