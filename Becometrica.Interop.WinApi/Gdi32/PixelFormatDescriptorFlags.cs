﻿namespace Becometrica.Interop.WinApi.Gdi32;

[Flags]
public enum PixelFormatDescriptorFlags: uint
{
    /// <summary>
    /// The buffer can draw to a window or device surface.
    /// </summary>
    PFD_DRAW_TO_WINDOW = 0x00000004,

    /// <summary>
    /// The buffer can draw to a memory bitmap.
    /// </summary>
    PFD_DRAW_TO_BITMAP = 0x00000008,

    /// <summary>
    /// The buffer supports GDI drawing. This flag and PFD_DOUBLEBUFFER are mutually exclusive in the current generic implementation.
    /// </summary>
    PFD_SUPPORT_GDI = 0x00000010,

    /// <summary>
    /// The buffer supports OpenGL drawing.
    /// </summary>
    PFD_SUPPORT_OPENGL = 0x00000020,

    /// <summary>
    /// The pixel format is supported by a device driver that accelerates the generic implementation. If this flag is clear and the PFD_GENERIC_FORMAT flag is set, the pixel format is supported by the generic implementation only.
    /// </summary>
    PFD_GENERIC_ACCELERATED = 0x00001000,

    /// <summary>
    /// The pixel format is supported by the GDI software implementation, which is also known as the generic implementation. If this bit is clear, the pixel format is supported by a device driver or hardware.
    /// </summary>
    PFD_GENERIC_FORMAT = 0x00000040,

    /// <summary>
    /// The buffer uses RGBA pixels on a palette-managed device. A logical palette is required to achieve the best results for this pixel type. Colors in the palette should be specified according to the values of the cRedBits, cRedShift, cGreenBits, cGreenShift, cBluebits, and cBlueShift members. The palette should be created and realized in the device context before calling wglMakeCurrent.
    /// </summary>
    PFD_NEED_PALETTE = 0x00000080,

    /// <summary>
    /// Defined in the pixel format descriptors of hardware that supports one hardware palette in 256-color mode only. For such systems to use hardware acceleration, the hardware palette must be in a fixed order (for example, 3-3-2) when in RGBA mode or must match the logical palette when in color-index mode.When this flag is set, you must call SetSystemPaletteUse in your program to force a one-to-one mapping of the logical palette and the system palette. If your OpenGL hardware supports multiple hardware palettes and the device driver can allocate spare hardware palettes for OpenGL, this flag is typically clear.
    /// This flag is not set in the generic pixel formats.
    /// </summary>
    PFD_NEED_SYSTEM_PALETTE = 0x00000100,

    /// <summary>
    /// The buffer is double-buffered. This flag and PFD_SUPPORT_GDI are mutually exclusive in the current generic implementation.
    /// </summary>
    PFD_DOUBLEBUFFER = 0x00000001,

    /// <summary>
    /// The buffer is stereoscopic. This flag is not supported in the current generic implementation.
    /// </summary>
    PFD_STEREO = 0x00000002,

    /// <summary>
    /// Indicates whether a device can swap individual layer planes with pixel formats that include double-buffered overlay or underlay planes. Otherwise all layer planes are swapped together as a group. When this flag is set, wglSwapLayerBuffers is supported.
    /// </summary>
    PFD_SWAP_LAYER_BUFFERS = 0x00000800,

    /// <summary>
    /// The requested pixel format can either have or not have a depth buffer. To select a pixel format without a depth buffer, you must specify this flag. The requested pixel format can be with or without a depth buffer. Otherwise, only pixel formats with a depth buffer are considered.
    /// </summary>
    PFD_DEPTH_DONTCARE = 0x20000000,

    /// <summary>
    /// The requested pixel format can be either single- or double-buffered.
    /// </summary>
    PFD_DOUBLEBUFFER_DONTCARE = 0x40000000,

    /// <summary>
    /// The requested pixel format can be either monoscopic or stereoscopic.
    /// </summary>
    PFD_STEREO_DONTCARE = 0x80000000,

    /// <summary>
    /// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color buffers causes the content of the back buffer to be copied to the front buffer. The content of the back buffer is not affected by the swap. PFD_SWAP_COPY is a hint only and might not be provided by a driver.
    /// </summary>
    PFD_SWAP_COPY = 0x00000400,

    /// <summary>
    /// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color buffers causes the exchange of the back buffer's content with the front buffer's content. Following the swap, the back buffer's content contains the front buffer's content before the swap. PFD_SWAP_EXCHANGE is a hint only and might not be provided by a driver.
    /// </summary>
    PFD_SWAP_EXCHANGE = 0x00000200,
}