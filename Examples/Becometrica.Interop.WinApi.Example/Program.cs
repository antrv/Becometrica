using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Gdi32;
using Becometrica.Interop.WinApi.Kernel32;
using Becometrica.Interop.WinApi.Opengl32;
using Becometrica.Interop.WinApi.Types;
using Becometrica.Interop.WinApi.User32;

const string className = "Becometrica Example Window Class";
HInstance instance = Kernel32Lib.GetModuleHandleW(null);
WndClassEx wc = new()
{
    Size = (uint)Unsafe.SizeOf<WndClassEx>(),
    WndProc = WndProc,
    Instance = instance,
    ClassName = className,
};

User32Lib.RegisterClassExW(wc);

HWnd hWnd = User32Lib.CreateWindowExW(ExtendedWindowStyles.None, className, "Window Title",
    WindowStyles.WS_OVERLAPPEDWINDOW, int.MinValue, int.MinValue, int.MinValue, int.MinValue, default, default,
    instance, default);

if (hWnd.IsNull)
{
    int errorCode = Marshal.GetLastWin32Error();
    string error = new Win32Exception(errorCode).Message;
    User32Lib.MessageBoxW(hWnd, $"Create window failed: {error} ({errorCode})", "My application", MessageBoxType.Ok);
}

User32Lib.ShowWindow(hWnd, CmdShow.SW_NORMAL);

while (User32Lib.GetMessageW(out Msg msg, default, 0, 0))
{
    User32Lib.TranslateMessage(msg);
    User32Lib.DispatchMessageW(msg);
}

return;

static LResult WndProc(HWnd hWnd, Message msg, WParam wParam, LParam lParam)
{
    switch (msg)
    {
        case Message.WM_CREATE:
        {
            PixelFormatDescriptor pfd = new();
            pfd.Size = (ushort)Unsafe.SizeOf<PixelFormatDescriptor>();
            pfd.Version = 1;
            pfd.Flags = PixelFormatDescriptorFlags.PFD_DRAW_TO_WINDOW | PixelFormatDescriptorFlags.PFD_SUPPORT_OPENGL; // | PixelFormatDescriptorFlags.PFD_DOUBLEBUFFER;

            pfd.PixelType = PixelType.PFD_TYPE_RGBA;
            pfd.ColorBits = 24;
            pfd.DepthBits = 32;
            pfd.LayerType = LayerType.PFD_MAIN_PLANE;
            HDc hdc = User32Lib.GetDC(hWnd);
            int pixelFormat = Gdi32Lib.ChoosePixelFormat(hdc, pfd);
            if (!Gdi32Lib.SetPixelFormat(hdc, pixelFormat, pfd))
            {
                int errorCode = Marshal.GetLastWin32Error();
            }

            HGlRc glRc = Opengl32Lib.wglCreateContext(hdc);
            if (!glRc.IsNull)
            {
                Opengl32Lib.wglMakeCurrent(hdc, glRc);
            }

            return 0;
        }

        case Message.WM_SIZE:
        {
            int width = (int)(lParam.Value & 0xFFFF);
            int height = (int)((lParam.Value >> 16) & 0xFFFF);
            Opengl32Lib.Viewport(0, 0, width, height);
            return 0;
        }

        case Message.WM_PAINT:
        {
            // HDc hdc = User32Lib.BeginPaint(hWnd, out PaintStruct ps);
            // Color orange = new(255, 128, 0);
            // HBrush brush = Gdi32Lib.CreateSolidBrush(orange);
            // //User32Lib.FillRect(hdc, ps.Paint, SystemColor.COLOR_DESKTOP);
            // User32Lib.FillRect(hdc, ps.Paint, brush);
            // Gdi32Lib.DeleteObject(brush);
            // User32Lib.EndPaint(hWnd, ps);

            Opengl32Lib.Clear(GlBufferTypes.ColorBuffer);
            Opengl32Lib.Begin(GlPrimitiveKind.Triangles);

            // Opengl32Lib.Color3(1.0f, 0.0f, 0.0f);
            // Opengl32Lib.Vertex2(0, 1);
            // Opengl32Lib.Color3(0.0f, 1.0f, 0.0f);
            // Opengl32Lib.Vertex2(-1, -1);
            // Opengl32Lib.Color3(0.0f, 0.0f, 1.0f);
            // Opengl32Lib.Vertex2(1, -1);

            Opengl32Lib.Color3(1.0f, 0.0f, 0.0f);
            Opengl32Lib.Vertex2(0, 1);
            Opengl32Lib.Color3(0.0f, 1.0f, 0.0f);
            Opengl32Lib.Vertex2(-1, -1);
            Opengl32Lib.Color3(0.0f, 0.0f, 1.0f);
            Opengl32Lib.Vertex2(1, -1);

            Opengl32Lib.End();
            Opengl32Lib.Flush();

            //HDc hdc = User32Lib.BeginPaint(hWnd, out PaintStruct ps);
            //User32Lib.EndPaint(hWnd, ps);

            return 0;
        }

        case Message.WM_CLOSE:
        {
            // if (User32Lib.MessageBoxW(hWnd, "Really quit?", "My application", MessageBoxType.OkCancel) ==
            //     MessageBoxResult.Ok)
            // {
            //     User32Lib.DestroyWindow(hWnd);
            // }

            HGlRc glRc = Opengl32Lib.wglGetCurrentContext();
            if (!glRc.IsNull)
            {
                HDc hdc = Opengl32Lib.wglGetCurrentDC() ;
                Opengl32Lib.wglMakeCurrent(default, default);
                User32Lib.ReleaseDC(hWnd, hdc);
                Opengl32Lib.wglDeleteContext(glRc);
            }

            User32Lib.DestroyWindow(hWnd);
            return 0;
        }

        case Message.WM_DESTROY:
        {
            User32Lib.PostQuitMessage(0);
            return 0;
        }

        default:
            return User32Lib.DefWindowProcW(hWnd, msg, wParam, lParam);
    }
}