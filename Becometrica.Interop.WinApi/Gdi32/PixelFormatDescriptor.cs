﻿namespace Becometrica.Interop.WinApi.Gdi32;

public struct PixelFormatDescriptor
{
    public ushort Size;
    public ushort Version;
    public PixelFormatDescriptorFlags Flags;
    public PixelType PixelType;
    public byte ColorBits;
    public byte RedBits;
    public byte RedShift;
    public byte GreenBits;
    public byte GreenShift;
    public byte BlueBits;
    public byte BlueShift;
    public byte AlphaBits;
    public byte AlphaShift;
    public byte AccumBits;
    public byte AccumRedBits;
    public byte AccumGreenBits;
    public byte AccumBlueBits;
    public byte AccumAlphaBits;
    public byte DepthBits;
    public byte StencilBits;
    public byte AuxBuffers;
    public LayerType LayerType;
    public byte Reserved;
    public uint LayerMask;
    public uint VisibleMask;
    public uint DamageMask;
}