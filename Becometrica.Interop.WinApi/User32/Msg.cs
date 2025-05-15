using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.User32;

public struct Msg
{
    public HWnd Wnd;
    public Message Message;
    public WParam WParam;
    public LParam LParam;
    public uint Time;
    public Point Pt;
    public uint Private;
}