using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.User32;

public delegate LResult WndProc(HWnd hWnd, Message msg, WParam wParam, LParam lParam);