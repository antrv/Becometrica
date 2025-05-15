namespace Becometrica.Interop.WinApi.Gdi32;

public enum LayerType: byte
{
    PFD_MAIN_PLANE = 0,
    PFD_OVERLAY_PLANE = 1,
    PFD_UNDERLAY_PLANE = 255,
}