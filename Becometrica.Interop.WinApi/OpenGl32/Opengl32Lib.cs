using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.Opengl32;

public static partial class Opengl32Lib
{
    /// <summary>
    /// Operates on the accumulation buffer.
    /// </summary>
    /// <param name="op">The accumulation buffer operation.</param>
    /// <param name="value">A floating-point value used in the accumulation buffer operation.
    /// The op parameter determines how value is used.</param>
    public static void Accum(GlAccumOp op, float value) => Interop.glAccum(op, value);

    /// <summary>
    /// Enables your application to set the alpha test function.
    /// </summary>
    /// <param name="func">The alpha comparison function.</param>
    /// <param name="referenceValue">The reference value to which incoming alpha values are compared.
    /// This value is clamped to the range 0 through 1, where 0 represents the lowest possible alpha value
    /// and 1 the highest possible value. The default reference is 0.</param>
    public static void AlphaFunc(GlTestFunction func, float referenceValue)
        => Interop.glAlphaFunc(func, referenceValue);

    /// <summary>
    /// Determines whether specified texture objects are resident in texture memory.
    /// </summary>
    /// <param name="textures">An array containing the names of the textures to be queried.</param>
    /// <param name="residences">An array in which the texture residence status is returned.
    /// The residence status of a texture named by an element of textures is returned in
    /// the corresponding element of residences.</param>
    /// <returns></returns>
    public static unsafe bool AreTexturesResident(ReadOnlySpan<uint> textures, Span<bool> residences)
    {
        int length = Math.Min(textures.Length, residences.Length);
        fixed (uint* texturesPtr = textures)
        fixed (bool* residencesPtr = residences)
            return Interop.glAreTexturesResident(length, texturesPtr, residencesPtr);
    }

    /// <summary>
    /// Specifies the array elements used to render a vertex.
    /// </summary>
    /// <param name="index">An index in the enabled arrays.</param>
    public static void ArrayElement(int index) => Interop.glArrayElement(index);

    /// <summary>
    /// The <see cref="Begin"/> and <see cref="End"/> functions delimit the vertices of a primitive
    /// or a group of like primitives.
    /// </summary>
    /// <param name="mode">The primitive or primitives that will be created from vertices presented between
    /// glBegin and the subsequent <see cref="End"/>.</param>
    public static void Begin(GlPrimitiveKind mode) => Interop.glBegin(mode);

    /// <summary>
    /// Enables the creation of a named texture that is bound to a texture target.
    /// </summary>
    /// <param name="target">The target to which the texture is bound.</param>
    /// <param name="texture">The name of a texture; the texture name cannot currently be in use.</param>
    public static void BindTexture(GlTextureTarget target, uint texture) => Interop.glBindTexture(target, texture);

    /// <summary>
    /// Draws a bitmap.
    /// </summary>
    /// <param name="width">The pixel width of the bitmap image.</param>
    /// <param name="height">The pixel height of the bitmap image.</param>
    /// <param name="xOrig">The x location of the origin in the bitmap image. The origin is measured from
    /// the lower-left corner of the bitmap, with right and up directions being the positive axes.</param>
    /// <param name="yOrig">The y location of the origin in the bitmap image. The origin is measured from
    /// the lower-left corner of the bitmap, with right and up directions being the positive axes.</param>
    /// <param name="xMove">The x offset to be added to the current raster position after the bitmap is drawn.</param>
    /// <param name="yMove">The y offset to be added to the current raster position after the bitmap is drawn.</param>
    /// <param name="bitmap">The bitmap image.</param>
    public static unsafe void Bitmap(int width, int height, float xOrig, float yOrig, float xMove, float yMove,
        ReadOnlySpan<byte> bitmap)
    {
        fixed (byte* bitmapPtr = bitmap)
            Interop.glBitmap(width, height, xOrig, yOrig, xMove, yMove, bitmapPtr);
    }

    /// <summary>
    /// Specifies pixel arithmetic.
    /// </summary>
    /// <param name="sourceFactor">Specifies how the red, green, blue, and alpha source-blending
    /// factors are computed.</param>
    /// <param name="destinationFactor">Specifies how the red, green, blue, and
    /// alpha destination-blending factors are computed.</param>
    public static void BlendFunc(GlBlendingFactor sourceFactor, GlBlendingFactor destinationFactor)
        => Interop.glBlendFunc(sourceFactor, destinationFactor);

    /// <summary>
    /// Executes a display list.
    /// </summary>
    /// <param name="list">The integer name of the display list to be executed.</param>
    public static void CallList(uint list) => Interop.glCallList(list);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<sbyte> lists) => Interop.CallLists(lists, GlDataType.Byte);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<byte> lists) => Interop.CallLists(lists, GlDataType.UnsignedByte);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<short> lists) => Interop.CallLists(lists, GlDataType.Short);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<ushort> lists) => Interop.CallLists(lists, GlDataType.UnsignedShort);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<int> lists) => Interop.CallLists(lists, GlDataType.Int);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<uint> lists) => Interop.CallLists(lists, GlDataType.UnsignedInt);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    public static void CallLists(ReadOnlySpan<float> lists) => Interop.CallLists(lists, GlDataType.Float);

    /// <summary>
    /// Executes a list of display lists.
    /// </summary>
    /// <param name="lists">The array of name offsets in the display list.</param>
    /// <param name="dataType">The type of values in lists.</param>
    public static void CallLists(ReadOnlySpan<byte> lists, GlDataType dataType) => Interop.CallLists(lists, dataType);

    /// <summary>
    /// Clears buffers to preset values.
    /// </summary>
    /// <param name="mask">Bitwise OR operators of masks that indicate the buffers to be cleared.</param>
    public static void Clear(GlBufferTypes mask) => Interop.glClear(mask);

    /// <summary>
    /// Specifies the clear values for the accumulation buffer.
    /// </summary>
    /// <param name="red">The red value used when the accumulation buffer is cleared. The default value is zero.</param>
    /// <param name="green">The green value used when the accumulation buffer is cleared. The default value is zero.</param>
    /// <param name="blue">The blue value used when the accumulation buffer is cleared. The default value is zero.</param>
    /// <param name="alpha">The alpha value used when the accumulation buffer is cleared. The default value is zero.</param>
    public static void ClearAccum(float red, float green, float blue, float alpha)
        => Interop.glClearAccum(red, green, blue, alpha);

    /// <summary>
    /// Specifies clear values for the color buffers.
    /// </summary>
    /// <param name="red">The red value used when the color buffer is cleared. The default value is zero.</param>
    /// <param name="green">The green value used when the color buffer is cleared. The default value is zero.</param>
    /// <param name="blue">The blue value used when the color buffer is cleared. The default value is zero.</param>
    /// <param name="alpha">The alpha value used when the color buffer is cleared. The default value is zero.</param>
    public static void ClearColor(float red, float green, float blue, float alpha)
        => Interop.glClearColor(red, green, blue, alpha);

    /// <summary>
    /// Specifies the clear value for the depth buffer.
    /// </summary>
    /// <param name="depth">The depth value used when the depth buffer is cleared.</param>
    public static void ClearDepth(double depth) => Interop.glClearDepth(depth);

    /// <summary>
    /// Specifies the clear value for the color-index buffers.
    /// </summary>
    /// <param name="c">The index used when the color-index buffers are cleared. The default value is zero.</param>
    public static void ClearIndex(float c) => Interop.glClearIndex(c);

    /// <summary>
    /// Specifies the clear value for the stencil buffer.
    /// </summary>
    /// <param name="s">The index used when the stencil buffer is cleared. The default value is zero.</param>
    public static void ClearStencil(int s) => Interop.glClearStencil(s);

    /// <summary>
    /// Specifies a plane against which all geometry is clipped.
    /// </summary>
    /// <param name="plane">The clipping plane that is being positioned.</param>
    /// <param name="equation">An array of four double-precision floating-point values.
    /// These values are interpreted as a plane equation.</param>
    public static unsafe void ClipPlane(GlClipPlane plane, ReadOnlySpan<double> equation)
    {
        fixed (double* equationPtr = equation)
            Interop.glClipPlane(plane, equationPtr);
    }

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(sbyte red, sbyte green, sbyte blue) => Interop.glColor3b(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(byte red, byte green, byte blue) => Interop.glColor3ub(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(short red, short green, short blue) => Interop.glColor3s(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(ushort red, ushort green, ushort blue) => Interop.glColor3us(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(int red, int green, int blue) => Interop.glColor3i(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(uint red, uint green, uint blue) => Interop.glColor3ui(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(float red, float green, float blue) => Interop.glColor3f(red, green, blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    public static void Color3(double red, double green, double blue) => Interop.glColor3d(red, green, blue);

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<sbyte> v)
    {
        fixed (sbyte* vPtr = v)
            Interop.glColor3bv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<byte> v)
    {
        fixed (byte* vPtr = v)
            Interop.glColor3ubv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<short> v)
    {
        fixed (short* vPtr = v)
            Interop.glColor3sv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<ushort> v)
    {
        fixed (ushort* vPtr = v)
            Interop.glColor3usv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<int> v)
    {
        fixed (int* vPtr = v)
            Interop.glColor3iv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<uint> v)
    {
        fixed (uint* vPtr = v)
            Interop.glColor3uiv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<float> v)
    {
        fixed (float* vPtr = v)
            Interop.glColor3fv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, and blue values.</param>
    public static unsafe void Color3(ReadOnlySpan<double> v)
    {
        fixed (double* vPtr = v)
            Interop.glColor3dv(vPtr);
    }

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(sbyte red, sbyte green, sbyte blue, sbyte alpha)
        => Interop.glColor4b(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(byte red, byte green, byte blue, byte alpha)
        => Interop.glColor4ub(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(short red, short green, short blue, short alpha)
        => Interop.glColor4s(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(ushort red, ushort green, ushort blue, ushort alpha)
        => Interop.glColor4us(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(int red, int green, int blue, int alpha) => Interop.glColor4i(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(uint red, uint green, uint blue, uint alpha)
        => Interop.glColor4ui(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(float red, float green, float blue, float alpha)
        => Interop.glColor4f(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color.</param>
    /// <param name="green">The new green value for the current color.</param>
    /// <param name="blue">The new blue value for the current color.</param>
    /// <param name="alpha">The new alpha value for the current color.</param>
    public static void Color4(double red, double green, double blue, double alpha)
        => Interop.glColor4d(red, green, blue, alpha);

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<sbyte> v)
    {
        fixed (sbyte* vPtr = v)
            Interop.glColor4bv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<byte> v)
    {
        fixed (byte* vPtr = v)
            Interop.glColor4ubv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<short> v)
    {
        fixed (short* vPtr = v)
            Interop.glColor4sv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<ushort> v)
    {
        fixed (ushort* vPtr = v)
            Interop.glColor4usv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<int> v)
    {
        fixed (int* vPtr = v)
            Interop.glColor4iv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<uint> v)
    {
        fixed (uint* vPtr = v)
            Interop.glColor4uiv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<float> v)
    {
        fixed (float* vPtr = v)
            Interop.glColor4fv(vPtr);
    }

    /// <summary>
    /// Sets the current color from an already existing array of color values.
    /// </summary>
    /// <param name="v">An array that contains red, green, blue, and alpha values.</param>
    public static unsafe void Color4(ReadOnlySpan<double> v)
    {
        fixed (double* vPtr = v)
            Interop.glColor4dv(vPtr);
    }

    /// <summary>
    /// Enables and disables writing of frame-buffer color components.
    /// </summary>
    /// <param name="red">Specify whether red can or cannot be written into the framebuffer.
    /// The default values is true, indicating that the color component can be written.</param>
    /// <param name="green">Specify whether green can or cannot be written into the framebuffer.
    /// The default value is true, indicating that the color component can be written.</param>
    /// <param name="blue">Specify whether blue can or cannot be written into the framebuffer.
    /// The default value is true, indicating that the color component can be written.</param>
    /// <param name="alpha">Specify whether alpha can or cannot be written into the framebuffer.
    /// The default value is true, indicating that the color component can be written.</param>
    public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        => Interop.glColorMask(red, green, blue, alpha);

    /// <summary>
    /// Causes a material color to track the current color.
    /// </summary>
    /// <param name="face">Specifies whether front, back, or both front and back material
    /// parameters should track the current color.</param>
    /// <param name="mode">Specifies which of several material parameters track the current color.</param>
    public static void ColorMaterial(GlFace face, GlMaterialMode mode) => Interop.glColorMaterial(face, mode);

    /// <summary>
    /// Defines an array of colors.
    /// </summary>
    /// <param name="size">The number of components per color. The value must be either 3 or 4.</param>
    /// <param name="type">The data type of each color component in a color array.</param>
    /// <param name="stride">The byte offset between consecutive colors. When stride is zero,
    /// the colors are tightly packed in the array.</param>
    /// <param name="pointer">A pointer to the first component of the first color element in a color array.</param>
    public static unsafe void ColorPointer(int size, GlDataType type, int stride, ReadOnlySpan<byte> pointer)
    {
        fixed (byte* p = pointer)
            Interop.glColorPointer(size, type, stride, p);
    }

    /// <summary>
    /// Copies pixels in the framebuffer.
    /// </summary>
    /// <param name="x">The window x-plane coordinate of the lower-left corner of the rectangular region of pixels to be copied.</param>
    /// <param name="y">The window y-plane coordinate of the lower-left corner of the rectangular region of pixels to be copied.</param>
    /// <param name="width">The width dimension of the rectangular region of pixels to be copied. Must be nonnegative.</param>
    /// <param name="height">The height dimension of the rectangular region of pixels to be copied. Must be nonnegative.</param>
    /// <param name="type">Specifies whether glCopyPixels is to copy color values, depth values, or stencil values.</param>
    public static void CopyPixels(int x, int y, int width, int height, GlPixelCopyType type)
        => Interop.glCopyPixels(x, y, width, height, type);

    /// <summary>
    /// Copies pixels from the framebuffer into a one-dimensional texture image.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image. Level n is the nth mipmap reduction image.</param>
    /// <param name="internalFormat">The internal format and resolution of the texture data.</param>
    /// <param name="x">The window x-plane coordinate of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="y">The window y-plane coordinate of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="width">The width of the texture image. Must be zero or 2n + 2(border) for some integer n.
    /// The height of the texture image is 1.</param>
    /// <param name="border">The width of the border. Must be either zero or 1.</param>
    public static void CopyTextureImage1D(int level, GlTexturePixelFormat internalFormat, int x, int y, int width,
        int border) => Interop.glCopyTexImage1D(GlTextureTarget.Texture1D, level, internalFormat, x, y, width, border);

    /// <summary>
    /// Copies pixels from the framebuffer into a two-dimensional texture image.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image. Level n is the nth mipmap reduction image.</param>
    /// <param name="internalFormat">The internal format and resolution of the texture data.</param>
    /// <param name="x">The window x-plane coordinate of the lower-left corner of the rectangular region of pixels to be copied.</param>
    /// <param name="y">The window y-plane coordinate of the lower-left corner of the rectangular region of pixels to be copied.</param>
    /// <param name="width">The width of the texture image. Must be 2n + 2 * border for some integer n.</param>
    /// <param name="height">The height of the texture image. Must be 2n + 2 * border for some integer n.</param>
    /// <param name="border">The width of the border. Must be either zero or 1.</param>
    public static void CopyTextureImage2D(int level, GlTexturePixelFormat internalFormat, int x, int y, int width,
        int height, int border) => Interop.glCopyTexImage2D(GlTextureTarget.Texture2D, level, internalFormat, x, y,
        width, height, border);

    /// <summary>
    /// Copies a sub-image of a one-dimensional texture image from the framebuffer.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image. Level n is the nth mipmap reduction image.</param>
    /// <param name="xOffset">The texel offset within the texture array.</param>
    /// <param name="x">The window x-plane coordinate of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="y">The window y-plane coordinate of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="width">The width of the sub-image of the texture image. Specifying a texture sub-image with zero width has no effect.</param>
    public static void CopyTextureSubImage1D(int level, int xOffset, int x, int y, int width)
        => Interop.glCopyTexSubImage1D(GlTextureTarget.Texture1D, level, xOffset, x, y, width);

    /// <summary>
    /// Copies a sub-image of a two-dimensional texture image from the framebuffer.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image. Level n is the nth mipmap reduction image.</param>
    /// <param name="xOffset">The texel offset in the x direction within the texture array.</param>
    /// <param name="yOffset">The texel offset in the y direction within the texture array.</param>
    /// <param name="x">The window x-plane coordinates of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="y">The window y-plane coordinates of the lower-left corner of the row of pixels to be copied.</param>
    /// <param name="width">The width of the sub-image of the texture image. Specifying a texture sub-image with zero width has no effect.</param>
    /// <param name="height">The height of the sub-image of the texture image. Specifying a texture sub-image with zero width has no effect.</param>
    public static void CopyTextureSubImage2D(int level, int xOffset, int yOffset, int x, int y, int width, int height)
        => Interop.glCopyTexSubImage2D(GlTextureTarget.Texture2D, level, xOffset, yOffset, x, y, width, height);

    /// <summary>
    /// Specifies whether front-facing or back-facing facets can be culled.
    /// </summary>
    /// <param name="mode">Specifies whether front-facing or back-facing facets are candidates for culling.</param>
    public static void CullFace(GlFace mode) => Interop.glCullFace(mode);

    /// <summary>
    /// Deletes a contiguous group of display lists.
    /// </summary>
    /// <param name="list">The integer name of the first display list to delete.</param>
    /// <param name="range">The number of display lists to delete.</param>
    public static void DeleteLists(uint list, int range) => Interop.glDeleteLists(list, range);

    /// <summary>
    /// Deletes named textures.
    /// </summary>
    /// <param name="textures">An array of textures to be deleted.</param>
    public static unsafe void DeleteTextures(ReadOnlySpan<uint> textures)
    {
        fixed (uint* p = textures)
            Interop.glDeleteTextures(textures.Length, p);
    }

    /// <summary>
    /// Specifies the value used for depth-buffer comparisons.
    /// </summary>
    /// <param name="func">Specifies the depth-comparison function.</param>
    public static void DepthFunc(GlTestFunction func) => Interop.glDepthFunc(func);

    /// <summary>
    /// Enables or disables writing into the depth buffer.
    /// </summary>
    /// <param name="enabled">Specifies whether the depth buffer is enabled for writing.
    /// Initially, depth-buffer writing is enabled.</param>
    public static void DepthMask(bool enabled) => Interop.glDepthMask(enabled);

    /// <summary>
    /// Specifies the mapping of z values from normalized device coordinates to window coordinates.
    /// </summary>
    /// <param name="zNear">The mapping of the near clipping plane to window coordinates. The default value is zero.</param>
    /// <param name="zFar">The mapping of the far clipping plane to window coordinates. The default value is 1.</param>
    public static void DepthRange(double zNear, double zFar) => Interop.glDepthRange(zNear, zFar);

    /// <summary>
    /// Disables an OpenGL capability.
    /// </summary>
    /// <param name="capability">An OpenGL capability to disable.</param>
    public static void Disable(GlCapability capability) => Interop.glDisable(capability);

    /// <summary>
    /// Disables arrays.
    /// </summary>
    /// <param name="array">The array you want to disable.</param>
    public static void DisableClientState(GlArray array) => Interop.glDisableClientState(array);

    /// <summary>
    /// Specifies multiple primitives to render.
    /// </summary>
    /// <param name="mode">The kind of primitives to render.</param>
    /// <param name="first">The starting index in the enabled arrays.</param>
    /// <param name="count">The number of indexes to render.</param>
    public static void DrawArrays(GlPrimitiveKind mode, int first, int count)
        => Interop.glDrawArrays(mode, first, count);

    /// <summary>
    /// Specifies which color buffers are to be drawn into.
    /// </summary>
    /// <param name="mode">Specifies up to four color buffers to be drawn into.</param>
    public static void DrawBuffer(GlColorBuffer mode) => Interop.glDrawBuffer(mode);

    /// <summary>
    /// Renders primitives from array data.
    /// </summary>
    /// <param name="mode">The kind of primitives to render.</param>
    /// <param name="indices">The location where the indices are stored.</param>
    public static unsafe void DrawElements(GlPrimitiveKind mode, ReadOnlySpan<byte> indices)
    {
        fixed (byte* p = indices)
            Interop.glDrawElements(mode, indices.Length, GlDataType.UnsignedByte, p);
    }

    /// <summary>
    /// Renders primitives from array data.
    /// </summary>
    /// <param name="mode">The kind of primitives to render.</param>
    /// <param name="indices">The location where the indices are stored.</param>
    public static unsafe void DrawElements(GlPrimitiveKind mode, ReadOnlySpan<ushort> indices)
    {
        ReadOnlySpan<byte> bytes = MemoryMarshal.Cast<ushort, byte>(indices);
        fixed (byte* p = bytes)
            Interop.glDrawElements(mode, indices.Length, GlDataType.UnsignedShort, p);
    }

    /// <summary>
    /// Renders primitives from array data.
    /// </summary>
    /// <param name="mode">The kind of primitives to render.</param>
    /// <param name="indices">The location where the indices are stored.</param>
    public static unsafe void DrawElements(GlPrimitiveKind mode, ReadOnlySpan<uint> indices)
    {
        ReadOnlySpan<byte> bytes = MemoryMarshal.Cast<uint, byte>(indices);
        fixed (byte* p = bytes)
            Interop.glDrawElements(mode, indices.Length, GlDataType.UnsignedInt, p);
    }

    /// <summary>
    /// Writes a block of pixels to the framebuffer.
    /// </summary>
    /// <param name="width">The width dimension of the pixel rectangle that will be written into the framebuffer.</param>
    /// <param name="height">The height dimension of the pixel rectangle that will be written into the framebuffer.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type for pixels.</param>
    /// <param name="pixels">The pixel data.</param>
    public static unsafe void DrawPixels(int width, int height, GlDrawPixelFormat format, GlDataType type,
        ReadOnlySpan<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glDrawPixels(width, height, format, type, p);
    }

    /// <summary>
    /// Flags edges as either boundary or non-boundary.
    /// </summary>
    /// <param name="flag">Specifies the current edge flag value.</param>
    public static void EdgeFlag(bool flag) => Interop.glEdgeFlag(flag);

    /// <summary>
    /// Defines an array of edge flags.
    /// </summary>
    /// <param name="stride">The byte offset between consecutive edge flags. When stride is zero,
    /// the edge flags are tightly packed in the array.</param>
    /// <param name="flags">An array of edge flags.</param>
    public static unsafe void EdgeFlagPointer(int stride, ReadOnlySpan<bool> flags)
    {
        fixed (bool* p = flags)
            Interop.glEdgeFlagPointer(stride, p);
    }

    /// <summary>
    /// Flags edges as either boundary or non-boundary.
    /// </summary>
    /// <param name="flag">Specifies an array that contains a single element,
    /// which replaces the current edge flag value.</param>
    public static unsafe void EdgeFlag(ReadOnlySpan<bool> flag)
    {
        fixed (bool* p = flag)
            Interop.glEdgeFlagv(p);
    }

    /// <summary>
    /// Enables OpenGL capabilities.
    /// </summary>
    /// <param name="capability">An OpenGL capability to enable.</param>
    public static void Enable(GlCapability capability) => Interop.glEnable(capability);

    /// <summary>
    /// Enables arrays.
    /// </summary>
    /// <param name="array">An array to enable.</param>
    public static void EnableClientState(GlArray array) => Interop.glEnableClientState(array);

    /// <summary>
    /// The <see cref="Begin"/> and <see cref="End"/> functions delimit the vertices of a primitive or
    /// a group of like primitives.
    /// </summary>
    public static void End() => Interop.glEnd();

    /// <summary>
    /// The <see cref="NewList"/> and <see cref="EndList"/> functions create or replace a display list.
    /// </summary>
    public static void EndList() => Interop.glEndList();

    /// <summary>
    /// Evaluates enabled one-dimensional maps.
    /// </summary>
    /// <param name="u">A value that is the domain coordinate u to the basis function
    /// defined in a previous glMap1 function.</param>
    public static void EvalCoord1D(double u) => Interop.glEvalCoord1d(u);

    /// <summary>
    /// Evaluates enabled one-dimensional maps.
    /// </summary>
    /// <param name="u">A value that is the domain coordinate u to the basis function
    /// defined in a previous glMap1 function.</param>
    public static void EvalCoord1D(float u) => Interop.glEvalCoord1f(u);

    /// <summary>
    /// Evaluates enabled one-dimensional maps.
    /// </summary>
    /// <param name="u">A pointer to an array containing the domain coordinate u.</param>
    public static unsafe void EvalCoord1D(ReadOnlySpan<double> u)
    {
        fixed (double* p = u)
            Interop.glEvalCoord1dv(p);
    }

    /// <summary>
    /// Evaluates enabled one-dimensional maps.
    /// </summary>
    /// <param name="u">A pointer to an array containing the domain coordinate u.</param>
    public static unsafe void EvalCoord1D(ReadOnlySpan<float> u)
    {
        fixed (float* p = u)
            Interop.glEvalCoord1fv(p);
    }

    /// <summary>
    /// Evaluates enabled two-dimensional maps.
    /// </summary>
    /// <param name="u">A value that is the domain coordinate u to the basis function defined
    /// in a previous glMap2 function.</param>
    /// <param name="v">A value that is the domain coordinate v to the basis function defined
    /// in a previous glMap2 function.</param>
    public static void EvalCoord2D(double u, double v) => Interop.glEvalCoord2d(u, v);

    /// <summary>
    /// Evaluates enabled two-dimensional maps.
    /// </summary>
    /// <param name="u">A value that is the domain coordinate u to the basis function defined
    /// in a previous glMap2 function.</param>
    /// <param name="v">A value that is the domain coordinate v to the basis function defined
    /// in a previous glMap2 function.</param>
    public static void EvalCoord2D(float u, float v) => Interop.glEvalCoord2f(u, v);

    /// <summary>
    /// Evaluates enabled two-dimensional maps.
    /// </summary>
    /// <param name="u">An array containing the domain coordinates u and v.</param>
    public static unsafe void EvalCoord2D(ReadOnlySpan<double> u)
    {
        fixed (double* p = u)
            Interop.glEvalCoord2dv(p);
    }

    /// <summary>
    /// Evaluates enabled two-dimensional maps.
    /// </summary>
    /// <param name="u">An array containing the domain coordinates u and v.</param>
    public static unsafe void EvalCoord2D(ReadOnlySpan<float> u)
    {
        fixed (float* p = u)
            Interop.glEvalCoord2fv(p);
    }

    /// <summary>
    /// Computes a one-dimensional grid of points or lines.
    /// </summary>
    /// <param name="mode">A value that specifies whether to compute a one-dimensional mesh of points or lines.</param>
    /// <param name="i1">The first integer value for grid domain variable i.</param>
    /// <param name="i2">The last integer value for grid domain variable i.</param>
    public static void EvalMesh1D(GlEvalMeshMode mode, int i1, int i2) => Interop.glEvalMesh1(mode, i1, i2);

    /// <summary>
    /// Computes a two-dimensional grid of points or lines.
    /// </summary>
    /// <param name="mode">A value that specifies whether to compute a two-dimensional mesh of points, lines,
    /// or polygons.</param>
    /// <param name="i1">The first integer value for grid domain variable i.</param>
    /// <param name="i2">The last integer value for grid domain variable i.</param>
    /// <param name="j1">The first integer value for grid domain variable j.</param>
    /// <param name="j2">The last integer value for grid domain variable j.</param>
    public static void EvalMesh2D(GlEvalMeshMode mode, int i1, int i2, int j1, int j2)
        => Interop.glEvalMesh2(mode, i1, i2, j1, j2);

    /// <summary>
    /// Generates and evaluates a single point in a mesh.
    /// </summary>
    /// <param name="i">The integer value for grid domain variable i.</param>
    public static void EvalPoint1D(int i) => Interop.glEvalPoint1(i);

    /// <summary>
    /// Generates and evaluates a single point in a mesh.
    /// </summary>
    /// <param name="i">The integer value for grid domain variable i.</param>
    /// <param name="j">The integer value for grid domain variable j.</param>
    public static void EvalPoint2D(int i, int j) => Interop.glEvalPoint2(i, j);

    /// <summary>
    /// Controls feedback mode.
    /// </summary>
    /// <param name="type">A symbolic constant that describes the information that will be returned for each vertex.</param>
    /// <param name="buffer">Returns the feedback data.</param>
    public static unsafe void FeedbackBuffer(GlFeedbackMode type, Span<float> buffer)
    {
        fixed (float* p = buffer)
            Interop.glFeedbackBuffer(buffer.Length, type, p);
    }

    /// <summary>
    /// Blocks until all OpenGL execution is complete.
    /// </summary>
    public static void Finish() => Interop.glFinish();

    /// <summary>
    /// Forces execution of OpenGL functions in finite time.
    /// </summary>
    public static void Flush() => Interop.glFlush();

    /// <summary>
    /// Specifies fog parameters.
    /// </summary>
    /// <param name="param">A fog parameter.</param>
    /// <param name="value">The parameter value.</param>
    public static void Fog(GlFogParam param, float value) => Interop.glFogf(param, value);

    /// <summary>
    /// Specifies fog parameters.
    /// </summary>
    /// <param name="param">A fog parameter.</param>
    /// <param name="value">The parameter value.</param>
    public static unsafe void Fog(GlFogParam param, ReadOnlySpan<float> value)
    {
        fixed (float* p = value)
            Interop.glFogfv(param, p);
    }

    /// <summary>
    /// Specifies fog parameters.
    /// </summary>
    /// <param name="param">A fog parameter.</param>
    /// <param name="value">The parameter value.</param>
    public static void Fog(GlFogParam param, int value) => Interop.glFogi(param, value);

    /// <summary>
    /// Specifies fog parameters.
    /// </summary>
    /// <param name="param">A fog parameter.</param>
    /// <param name="value">The parameter value.</param>
    public static unsafe void Fog(GlFogParam param, ReadOnlySpan<int> value)
    {
        fixed (int* p = value)
            Interop.glFogiv(param, p);
    }

    /// <summary>
    /// Defines front-facing and back-facing polygons.
    /// </summary>
    /// <param name="mode">The orientation of front-facing polygons.</param>
    public static void FrontFace(GlPolygonOrientation mode) => Interop.glFrontFace(mode);

    /// <summary>
    /// Multiplies the current matrix by a perspective matrix.
    /// </summary>
    /// <param name="left">The coordinate for the left-vertical clipping plane.</param>
    /// <param name="right">The coordinate for the right-vertical clipping plane.</param>
    /// <param name="bottom">The coordinate for the bottom-horizontal clipping plane.</param>
    /// <param name="top">The coordinate for the bottom-horizontal clipping plane.</param>
    /// <param name="zNear">The distances to the near-depth clipping plane. Must be positive.</param>
    /// <param name="zFar">The distances to the far-depth clipping planes. Must be positive.</param>
    public static void Frustum(double left, double right, double bottom, double top, double zNear, double zFar)
        => Interop.glFrustum(left, right, bottom, top, zNear, zFar);

    /// <summary>
    /// Generates a contiguous set of empty display lists.
    /// </summary>
    /// <param name="range">The number of contiguous empty display lists to be generated.</param>
    /// <returns></returns>
    public static uint GenLists(int range) => Interop.glGenLists(range);

    /// <summary>
    /// Generates texture names.
    /// </summary>
    /// <param name="textures">An array in which the generated texture names are stored.</param>
    public static unsafe void GenTextures(Span<uint> textures)
    {
        fixed (uint* p = textures)
            Interop.glGenTextures(textures.Length, p);
    }

    /// <summary>
    /// Returns the value or values of a selected parameter.
    /// </summary>
    /// <param name="param">The parameter value to be returned.</param>
    /// <param name="values">Returns the value or values of the specified parameter.</param>
    public static unsafe void GetBoolean(GlParameter param, Span<bool> values)
    {
        fixed (bool* p = values)
            Interop.glGetBooleanv(param, p);
    }

    /// <summary>
    /// Returns the coefficients of the specified clipping plane.
    /// </summary>
    /// <param name="plane">A clipping plane. The number of clipping planes depends on the implementation,
    /// but at least six clipping planes are supported.</param>
    /// <param name="equation">Returns four double-precision values that are the coefficients of
    /// the plane equation of plane in eye coordinates.</param>
    public static unsafe void GetClipPlane(GlClipPlane plane, Span<double> equation)
    {
        fixed (double* p = equation)
            Interop.glGetClipPlane(plane, p);
    }

    /// <summary>
    /// Returns the value or values of a selected parameter.
    /// </summary>
    /// <param name="param">The parameter value to be returned.</param>
    /// <param name="values">Returns the value or values of the specified parameter.</param>
    public static unsafe void GetDouble(GlParameter param, Span<double> values)
    {
        fixed (double* p = values)
            Interop.glGetDoublev(param, p);
    }

    /// <summary>
    /// Returns error information.
    /// </summary>
    /// <returns>One of the error codes.</returns>
    public static GlError GetError() => Interop.glGetError();

    /// <summary>
    /// Returns the value or values of a selected parameter.
    /// </summary>
    /// <param name="param">The parameter value to be returned.</param>
    /// <param name="values">Returns the value or values of the specified parameter.</param>
    public static unsafe void GetFloat(GlParameter param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetFloatv(param, p);
    }

    /// <summary>
    /// Returns the value or values of a selected parameter.
    /// </summary>
    /// <param name="param">The parameter value to be returned.</param>
    /// <param name="values">Returns the value or values of the specified parameter.</param>
    public static unsafe void GetInteger(GlParameter param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetIntegerv(param, p);
    }

    /// <summary>
    /// Returns light source parameter values.
    /// </summary>
    /// <param name="lightIndex">A light source. The number of possible lights depends on the implementation,
    /// but at least eight lights are supported.</param>
    /// <param name="param">A light source parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetLight(int lightIndex, GlLightParameter param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetLightfv(Constants.GL_LIGHT0 + (uint)lightIndex, param, p);
    }

    /// <summary>
    /// Returns light source parameter values.
    /// </summary>
    /// <param name="lightIndex">A light source. The number of possible lights depends on the implementation,
    /// but at least eight lights are supported.</param>
    /// <param name="param">A light source parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetLight(int lightIndex, GlLightParameter param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetLightiv(Constants.GL_LIGHT0 + (uint)lightIndex, param, p);
    }

    /// <summary>
    /// Return evaluator parameters.
    /// </summary>
    /// <param name="target">The symbolic name of a map.</param>
    /// <param name="query">Specifies which parameter to return.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetMap(GlMapName target, GlMapParameter query, Span<double> values)
    {
        fixed (double* p = values)
            Interop.glGetMapdv(target, query, p);
    }

    /// <summary>
    /// Return evaluator parameters.
    /// </summary>
    /// <param name="target">The symbolic name of a map.</param>
    /// <param name="query">Specifies which parameter to return.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetMap(GlMapName target, GlMapParameter query, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetMapfv(target, query, p);
    }

    /// <summary>
    /// Return evaluator parameters.
    /// </summary>
    /// <param name="target">The symbolic name of a map.</param>
    /// <param name="query">Specifies which parameter to return.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetMap(GlMapName target, GlMapParameter query, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetMapiv(target, query, p);
    }

    /// <summary>
    /// Return material parameters.
    /// </summary>
    /// <param name="face">Specifies which of the two materials is being queried.</param>
    /// <param name="param">The material parameter to return.</param>
    /// <param name="values"></param>
    public static unsafe void GetMaterial(GlFace face, GlMaterialParameter param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetMaterialfv(face, param, p);
    }

    /// <summary>
    /// Return material parameters.
    /// </summary>
    /// <param name="face">Specifies which of the two materials is being queried.</param>
    /// <param name="param">The material parameter to return.</param>
    /// <param name="values"></param>
    public static unsafe void GetMaterial(GlFace face, GlMaterialParameter param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetMaterialiv(face, param, p);
    }

    /// <summary>
    /// Returns the specified pixel map.
    /// </summary>
    /// <param name="map">The name of the pixel map to return.</param>
    /// <param name="values">Returns the pixel map contents.</param>
    public static unsafe void GetPixelMap(GlPixelMap map, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetPixelMapfv(map, p);
    }

    /// <summary>
    /// Returns the specified pixel map.
    /// </summary>
    /// <param name="map">The name of the pixel map to return.</param>
    /// <param name="values">Returns the pixel map contents.</param>
    public static unsafe void GetPixelMap(GlPixelMap map, Span<uint> values)
    {
        fixed (uint* p = values)
            Interop.glGetPixelMapuiv(map, p);
    }

    /// <summary>
    /// Returns the specified pixel map.
    /// </summary>
    /// <param name="map">The name of the pixel map to return.</param>
    /// <param name="values">Returns the pixel map contents.</param>
    public static unsafe void GetPixelMap(GlPixelMap map, Span<ushort> values)
    {
        fixed (ushort* p = values)
            Interop.glGetPixelMapusv(map, p);
    }

    /// <summary>
    /// Returns the address of a vertex data array.
    /// </summary>
    /// <param name="param">The type of array pointer to return.</param>
    /// <param name="pointer">Returns the value of the array pointer specified by parameter.</param>
    public static void GetPointer(GlPointerType param, out nint pointer) => Interop.glGetPointerv(param, out pointer);

    /// <summary>
    /// Returns the polygon stipple pattern.
    /// </summary>
    /// <param name="mask">Returns the stipple pattern.</param>
    public static unsafe void GetPolygonStipple(Span<byte> mask)
    {
        fixed (byte* maskPtr = mask)
            Interop.glGetPolygonStipple(maskPtr);
    }

    /// <summary>
    /// Returns a string describing the current OpenGL connection.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetString(GlString name) => Interop.glGetString(name).ToString();

    /// <summary>
    /// Returns texture environment parameters.
    /// </summary>
    /// <param name="param">A texture environment parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexEnv(GlTextureEnvParameter param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetTexEnvfv(Constants.GL_TEXTURE_ENV, param, p);
    }

    /// <summary>
    /// Returns texture environment parameters.
    /// </summary>
    /// <param name="param">A texture environment parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexEnv(GlTextureEnvParameter param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetTexEnviv(Constants.GL_TEXTURE_ENV, param, p);
    }

    /// <summary>
    /// Returns texture coordinate generation parameters.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">A value(s) to be returned.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexGen(GlTextureCoord coord, GlTextureCoordParam param, Span<double> values)
    {
        fixed (double* p = values)
            Interop.glGetTexGendv(coord, param, p);
    }

    /// <summary>
    /// Returns texture coordinate generation parameters.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">A value(s) to be returned.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexGen(GlTextureCoord coord, GlTextureCoordParam param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetTexGenfv(coord, param, p);
    }

    /// <summary>
    /// Returns texture coordinate generation parameters.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">A value(s) to be returned.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexGen(GlTextureCoord coord, GlTextureCoordParam param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetTexGeniv(coord, param, p);
    }

    /// <summary>
    /// Returns a texture image.
    /// </summary>
    /// <param name="target">Specifies which texture is to be obtained.</param>
    /// <param name="level">The level-of-detail number of the desired image. Level 0 is the base image level.
    /// Level n is the nth mipmap reduction image.</param>
    /// <param name="format">A pixel format for the returned data.</param>
    /// <param name="type">A pixel type for the returned data.</param>
    /// <param name="pixels">Returns the texture image.</param>
    public static unsafe void GetTexImage(GlTextureTarget target, int level, GlGetTexturePixelFormat format,
        GlDataType type, Span<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glGetTexImage(target, level, format, type, p);
    }

    /// <summary>
    /// Returns texture parameter values for a specific level of detail.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="level">The level-of-detail number of the desired image. Level 0 is the base image level.
    /// Level n is the nth mipmap reduction image.</param>
    /// <param name="param">A texture parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexLevelParameter(GlTextureTarget2 target, int level, GlTextureLevelParameter param,
        Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetTexLevelParameterfv(target, level, param, p);
    }

    /// <summary>
    /// Returns texture parameter values for a specific level of detail.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="level">The level-of-detail number of the desired image. Level 0 is the base image level.
    /// Level n is the nth mipmap reduction image.</param>
    /// <param name="param">A texture parameter.</param>
    /// <param name="values">Returns the requested data.</param>
    public static unsafe void GetTexLevelParameter(GlTextureTarget2 target, int level, GlTextureLevelParameter param,
        Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetTexLevelParameteriv(target, level, param, p);
    }

    /// <summary>
    /// Returns texture parameter values.
    /// </summary>
    /// <param name="target">A target texture.</param>
    /// <param name="param">A texture parameter.</param>
    /// <param name="values">Returns the texture parameters.</param>
    public static unsafe void GetTexParameter(GlTextureTarget target, GlTextureParameter param, Span<float> values)
    {
        fixed (float* p = values)
            Interop.glGetTexParameterfv(target, param, p);
    }

    /// <summary>
    /// Returns texture parameter values.
    /// </summary>
    /// <param name="target">A target texture.</param>
    /// <param name="param">A texture parameter.</param>
    /// <param name="values">Returns the texture parameters.</param>
    public static unsafe void GetTexParameter(GlTextureTarget target, GlTextureParameter param, Span<int> values)
    {
        fixed (int* p = values)
            Interop.glGetTexParameteriv(target, param, p);
    }

    /// <summary>
    /// Specifies implementation-specific hints.
    /// </summary>
    /// <param name="target">A symbolic constant indicating the behavior to be controlled.</param>
    /// <param name="mode">A symbolic constant indicating the desired behavior.</param>
    public static void Hint(GlHint target, GlHintMode mode) => Interop.glHint(target, mode);

    /// <summary>
    /// Controls the writing of individual bits in the color-index buffers.
    /// </summary>
    /// <param name="mask">A bit mask to enable and disable the writing of individual bits in the color-index buffers.
    /// Initially, the mask is all ones.</param>
    public static void IndexMask(uint mask) => Interop.glIndexMask(mask);

    /// <summary>
    /// Defines an array of color indexes.
    /// </summary>
    /// <param name="type">The data type of each color index in the array.</param>
    /// <param name="stride">The byte offset between consecutive color indexes. When stride is zero,
    /// the color indexes are tightly packed in the array.</param>
    /// <param name="indexes">An array of the color indexes.</param>
    public static unsafe void IndexPointer(GlDataType type, int stride, ReadOnlySpan<byte> indexes)
    {
        fixed (byte* p = indexes)
            Interop.glIndexPointer(type, stride, p);
    }

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">The new value for the current color index.</param>
    public static void Index(double c) => Interop.glIndexd(c);

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">A one-element array that contains the new value for the current color index.</param>
    public static unsafe void Index(ReadOnlySpan<double> c)
    {
        fixed (double* p = c)
            Interop.glIndexdv(p);
    }

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">The new value for the current color index.</param>
    public static void Index(float c) => Interop.glIndexf(c);

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">A one-element array that contains the new value for the current color index.</param>
    public static unsafe void Index(ReadOnlySpan<float> c)
    {
        fixed (float* p = c)
            Interop.glIndexfv(p);
    }

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">The new value for the current color index.</param>
    public static void Index(int c) => Interop.glIndexi(c);

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">A one-element array that contains the new value for the current color index.</param>
    public static unsafe void Index(ReadOnlySpan<int> c)
    {
        fixed (int* p = c)
            Interop.glIndexiv(p);
    }

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">The new value for the current color index.</param>
    public static void Index(short c) => Interop.glIndexs(c);

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">A one-element array that contains the new value for the current color index.</param>
    public static unsafe void Index(ReadOnlySpan<short> c)
    {
        fixed (short* p = c)
            Interop.glIndexsv(p);
    }

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">The new value for the current color index.</param>
    public static void Index(byte c) => Interop.glIndexub(c);

    /// <summary>
    /// Sets the current color index.
    /// </summary>
    /// <param name="c">A one-element array that contains the new value for the current color index.</param>
    public static unsafe void Index(ReadOnlySpan<byte> c)
    {
        fixed (byte* p = c)
            Interop.glIndexubv(p);
    }

    /// <summary>
    /// Initializes the name stack.
    /// </summary>
    public static void InitNames() => Interop.glInitNames();

    /// <summary>
    /// Simultaneously specifies and enables several interleaved arrays in a larger aggregate array.
    /// </summary>
    /// <param name="format">The type of array to enable.</param>
    /// <param name="stride">The offset in bytes between each aggregate array element.</param>
    /// <param name="array">An aggregate array.</param>
    public static unsafe void InterleavedArrays(GlInterleavedArray format, int stride, ReadOnlySpan<byte> array)
    {
        fixed (byte* p = array)
            Interop.glInterleavedArrays(format, stride, p);
    }

    /// <summary>
    /// Tests whether a capability is enabled.
    /// </summary>
    /// <param name="capability">A symbolic constant indicating an OpenGL capability.</param>
    /// <returns></returns>
    public static bool IsEnabled(GlCapability capability) => Interop.glIsEnabled(capability);

    /// <summary>
    /// Tests for display list existence.
    /// </summary>
    /// <param name="list">A potential display list name.</param>
    /// <returns></returns>
    public static bool IsList(uint list) => Interop.glIsList(list);

    /// <summary>
    /// Determines if a name corresponds to a texture.
    /// </summary>
    /// <param name="texture">A value that is the name of a texture.</param>
    /// <returns></returns>
    public static bool IsTexture(uint texture) => Interop.glIsTexture(texture);

    /// <summary>
    /// Sets lighting model parameters.
    /// </summary>
    /// <param name="param">A single-valued lighting model parameter.</param>
    /// <param name="value">The value to which param will be set.</param>
    public static void LightModel(GlLightModelParameter param, float value) => Interop.glLightModelf(param, value);

    /// <summary>
    /// Sets lighting model parameters.
    /// </summary>
    /// <param name="param">A lighting model parameter.</param>
    /// <param name="values">The value or values to which param will be set.</param>
    public static unsafe void LightModel(GlLightModelParameter param, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glLightModelfv(param, p);
    }

    /// <summary>
    /// Sets lighting model parameters.
    /// </summary>
    /// <param name="param">A single-valued lighting model parameter.</param>
    /// <param name="value">The value to which param will be set.</param>
    public static void LightModel(GlLightModelParameter param, int value) => Interop.glLightModeli(param, value);

    /// <summary>
    /// Sets lighting model parameters.
    /// </summary>
    /// <param name="param">A lighting model parameter.</param>
    /// <param name="values">The value or values to which param will be set.</param>
    public static unsafe void LightModel(GlLightModelParameter param, ReadOnlySpan<int> values)
    {
        fixed (int* p = values)
            Interop.glLightModeliv(param, p);
    }

    /// <summary>
    /// Sets light source parameter values.
    /// </summary>
    /// <param name="lightIndex">The identifier of a light.</param>
    /// <param name="param">A single-valued light source parameter for light.</param>
    /// <param name="value">Specifies the parameter value to set.</param>
    public static void Light(int lightIndex, GlLightParameter param, float value)
        => Interop.glLightf(Constants.GL_LIGHT0 + (uint)lightIndex, param, value);

    /// <summary>
    /// Sets light source parameter values.
    /// </summary>
    /// <param name="lightIndex">The identifier of a light.</param>
    /// <param name="param">A light source parameter for light.</param>
    /// <param name="values">Specifies the parameter value or values to set.</param>
    public static unsafe void Light(int lightIndex, GlLightParameter param, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glLightfv(Constants.GL_LIGHT0 + (uint)lightIndex, param, p);
    }

    /// <summary>
    /// Sets light source parameter values.
    /// </summary>
    /// <param name="lightIndex">The identifier of a light.</param>
    /// <param name="param">A single-valued light source parameter for light.</param>
    /// <param name="value">Specifies the parameter value to set.</param>
    public static void Light(int lightIndex, GlLightParameter param, int value)
        => Interop.glLighti(Constants.GL_LIGHT0 + (uint)lightIndex, param, value);

    /// <summary>
    /// Sets light source parameter values.
    /// </summary>
    /// <param name="lightIndex">The identifier of a light.</param>
    /// <param name="param">A light source parameter for light.</param>
    /// <param name="values">Specifies the parameter value or values to set.</param>
    public static unsafe void Light(int lightIndex, GlLightParameter param, ReadOnlySpan<int> values)
    {
        fixed (int* p = values)
            Interop.glLightiv(Constants.GL_LIGHT0 + (uint)lightIndex, param, p);
    }

    /// <summary>
    /// Specifies the line stipple pattern.
    /// </summary>
    /// <param name="factor">A multiplier for each bit in the line stipple pattern. If factor is 3, for example,
    /// each bit in the pattern will be used three times before the next bit in the pattern is used.
    /// The factor parameter is clamped to the range [1, 256] and defaults to one.</param>
    /// <param name="pattern">A 16-bit integer whose bit pattern determines which fragments of
    /// a line will be drawn when the line is rasterized. Bit zero is used first,
    /// and the default pattern is all ones.</param>
    public static void LineStipple(int factor, ushort pattern) => Interop.glLineStipple(factor, pattern);

    /// <summary>
    /// Specifies the width of rasterized lines.
    /// </summary>
    /// <param name="width">The width of rasterized lines. The default is 1.0.</param>
    public static void LineWidth(float width) => Interop.glLineWidth(width);

    /// <summary>
    /// Sets the display list base for glCallLists.
    /// </summary>
    /// <param name="base">An integer offset that will be added to glCallLists offsets to generate display list names.
    /// Initial value is zero.</param>
    public static void ListBase(uint @base) => Interop.glListBase(@base);

    /// <summary>
    /// Replaces the current matrix with the identity matrix.
    /// </summary>
    public static void LoadIdentity() => Interop.glLoadIdentity();

    /// <summary>
    /// Replaces the current matrix with an arbitrary matrix.
    /// </summary>
    /// <param name="m">A 4x4 matrix stored in column-major order as 16 consecutive values.</param>
    public static unsafe void LoadMatrix(ReadOnlySpan<double> m)
    {
        fixed (double* p = m)
            Interop.glLoadMatrixd(p);
    }

    /// <summary>
    /// Replaces the current matrix with an arbitrary matrix.
    /// </summary>
    /// <param name="m">A 4x4 matrix stored in column-major order as 16 consecutive values.</param>
    public static unsafe void LoadMatrix(ReadOnlySpan<float> m)
    {
        fixed (float* p = m)
            Interop.glLoadMatrixf(p);
    }

    /// <summary>
    /// Loads a name onto the name stack.
    /// </summary>
    /// <param name="name">A name that will replace the top value on the name stack.</param>
    public static void LoadName(uint name) => Interop.glLoadName(name);

    /// <summary>
    /// Specifies a logical pixel operation for color index rendering.
    /// </summary>
    /// <param name="opcode">A symbolic constant that selects a logical operation.</param>
    public static void LogicOp(GlLogicOp opcode) => Interop.glLogicOp(opcode);

    /// <summary>
    /// Defines a one-dimensional evaluator.
    /// </summary>
    /// <param name="target">The kind of values that are generated by the evaluator.</param>
    /// <param name="u1">A linear mapping of u, as presented to glEvalCoord1, to u^, the variable
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="u2">A linear mapping of u, as presented to glEvalCoord1, to u^, the variable
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="stride">The number of floats or doubles between the beginning of one control point and
    /// the beginning of the next one in the data structure referenced in points. This allows control points
    /// to be embedded in arbitrary data structures. The only constraint is that the values for a particular
    /// control point must occupy contiguous memory locations.</param>
    /// <param name="order">The number of control points. Must be positive.</param>
    /// <param name="points">An array of control points.</param>
    public static unsafe void Map1D(GlMap1DValue target, double u1, double u2, int stride, int order,
        ReadOnlySpan<double> points)
    {
        fixed (double* p = points)
            Interop.glMap1d(target, u1, u2, stride, order, p);
    }

    /// <summary>
    /// Defines a one-dimensional evaluator.
    /// </summary>
    /// <param name="target">The kind of values that are generated by the evaluator.</param>
    /// <param name="u1">A linear mapping of u, as presented to glEvalCoord1, to u^, the variable
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="u2">A linear mapping of u, as presented to glEvalCoord1, to u^, the variable
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="stride">The number of floats or doubles between the beginning of one control point and
    /// the beginning of the next one in the data structure referenced in points. This allows control points
    /// to be embedded in arbitrary data structures. The only constraint is that the values for a particular
    /// control point must occupy contiguous memory locations.</param>
    /// <param name="order">The number of control points. Must be positive.</param>
    /// <param name="points">An array of control points.</param>
    public static unsafe void Map1D(GlMap1DValue target, float u1, float u2, int stride, int order,
        ReadOnlySpan<float> points)
    {
        fixed (float* p = points)
            Interop.glMap1f(target, u1, u2, stride, order, p);
    }

    /// <summary>
    /// Defines a two-dimensional evaluator.
    /// </summary>
    /// <param name="target">The kind of values that are generated by the evaluator.</param>
    /// <param name="u1">A linear mapping of u, as presented to glEvalCoord2, to u^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="u2">A linear mapping of u, as presented to glEvalCoord2, to u^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="uStride">The number of floats or doubles between the beginning of control point R ij and
    /// the beginning of control point R (i\ +1\ )\ j, where i and j are the u and v control point indexes,
    /// respectively. This allows control points to be embedded in arbitrary data structures.
    /// The only constraint is that the values for a particular control point must occupy contiguous memory locations.
    /// </param>
    /// <param name="uOrder">The dimension of the control point array in the u-axis. Must be positive.</param>
    /// <param name="v1">A linear mapping of v, as presented to glEvalCoord2, to v^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="v2">A linear mapping of v, as presented to glEvalCoord2, to v^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="vStride">The number of floats or doubles between the beginning of control point R ij and
    /// the beginning of control point R i(j\ +1\ ), where i and j are the u and v control point indexes, respectively.
    /// This allows control points to be embedded in arbitrary data structures. The only constraint is that the values
    /// for a particular control point must occupy contiguous memory locations.</param>
    /// <param name="vOrder">The dimension of the control point array in the v-axis. Must be positive.</param>
    /// <param name="points">An array of control points.</param>
    public static unsafe void Map2D(GlMap2DValue target, double u1, double u2, int uStride, int uOrder, double v1,
        double v2, int vStride, int vOrder, ReadOnlySpan<double> points)
    {
        fixed (double* p = points)
            Interop.glMap2d(target, u1, u2, uStride, uOrder, v1, v2, vStride, vOrder, p);
    }

    /// <summary>
    /// Defines a two-dimensional evaluator.
    /// </summary>
    /// <param name="target">The kind of values that are generated by the evaluator.</param>
    /// <param name="u1">A linear mapping of u, as presented to glEvalCoord2, to u^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="u2">A linear mapping of u, as presented to glEvalCoord2, to u^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="uStride">The number of floats or doubles between the beginning of control point R ij and
    /// the beginning of control point R (i\ +1\ )\ j, where i and j are the u and v control point indexes,
    /// respectively. This allows control points to be embedded in arbitrary data structures.
    /// The only constraint is that the values for a particular control point must occupy contiguous memory locations.
    /// </param>
    /// <param name="uOrder">The dimension of the control point array in the u-axis. Must be positive.</param>
    /// <param name="v1">A linear mapping of v, as presented to glEvalCoord2, to v^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="v2">A linear mapping of v, as presented to glEvalCoord2, to v^, one of the two variables
    /// that is evaluated by the equations specified by this command.</param>
    /// <param name="vStride">The number of floats or doubles between the beginning of control point R ij and
    /// the beginning of control point R i(j\ +1\ ), where i and j are the u and v control point indexes, respectively.
    /// This allows control points to be embedded in arbitrary data structures. The only constraint is that the values
    /// for a particular control point must occupy contiguous memory locations.</param>
    /// <param name="vOrder">The dimension of the control point array in the v-axis. Must be positive.</param>
    /// <param name="points">An array of control points.</param>
    public static unsafe void Map2D(GlMap2DValue target, float u1, float u2, int uStride, int uOrder, float v1,
        float v2, int vStride, int vOrder, ReadOnlySpan<float> points)
    {
        fixed (float* p = points)
            Interop.glMap2f(target, u1, u2, uStride, uOrder, v1, v2, vStride, vOrder, p);
    }

    /// <summary>
    /// Defines a one-dimensional mesh.
    /// </summary>
    /// <param name="un">The number of partitions in the grid range interval [u1, u2].
    /// This value must be positive.</param>
    /// <param name="u1">A value used as the mapping for integer grid domain value i = 0.</param>
    /// <param name="u2">A value used as the mapping for integer grid domain value i = un.</param>
    public static void MapGrid1D(int un, double u1, double u2) => Interop.glMapGrid1d(un, u1, u2);

    /// <summary>
    /// Defines a one-dimensional mesh.
    /// </summary>
    /// <param name="un">The number of partitions in the grid range interval [u1, u2].
    /// This value must be positive.</param>
    /// <param name="u1">A value used as the mapping for integer grid domain value i = 0.</param>
    /// <param name="u2">A value used as the mapping for integer grid domain value i = un.</param>
    public static void MapGrid1D(int un, float u1, float u2) => Interop.glMapGrid1f(un, u1, u2);

    /// <summary>
    /// Defines a two-dimensional mesh.
    /// </summary>
    /// <param name="un">The number of partitions in the grid range interval [u1, u2].
    /// This value must be positive.</param>
    /// <param name="u1">A value used as the mapping for integer grid domain value i = 0.</param>
    /// <param name="u2">A value used as the mapping for integer grid domain value i = un.</param>
    /// <param name="vn">The number of partitions in the grid range interval [v1, v2].</param>
    /// <param name="v1">A value used as the mapping for integer grid domain value j = 0.</param>
    /// <param name="v2">A value used as the mapping for integer grid domain value j = vn.</param>
    public static void MapGrid2D(int un, double u1, double u2, int vn, double v1, double v2)
        => Interop.glMapGrid2d(un, u1, u2, vn, v1, v2);

    /// <summary>
    /// Defines a two-dimensional mesh.
    /// </summary>
    /// <param name="un">The number of partitions in the grid range interval [u1, u2].
    /// This value must be positive.</param>
    /// <param name="u1">A value used as the mapping for integer grid domain value i = 0.</param>
    /// <param name="u2">A value used as the mapping for integer grid domain value i = un.</param>
    /// <param name="vn">The number of partitions in the grid range interval [v1, v2].</param>
    /// <param name="v1">A value used as the mapping for integer grid domain value j = 0.</param>
    /// <param name="v2">A value used as the mapping for integer grid domain value j = vn.</param>
    public static void MapGrid2D(int un, float u1, float u2, int vn, float v1, float v2)
        => Interop.glMapGrid2f(un, u1, u2, vn, v1, v2);

    /// <summary>
    /// Specifies material parameters for the lighting model.
    /// </summary>
    /// <param name="face">The face or faces that are being updated.</param>
    /// <param name="param">The single-valued material parameter of the face or faces being updated. Must be Shininess.</param>
    /// <param name="value">The value to which parameter will be set.</param>
    public static void Material(GlFace face, GlMaterialParameter param, float value)
        => Interop.glMaterialf(face, param, value);

    /// <summary>
    /// Specifies material parameters for the lighting model.
    /// </summary>
    /// <param name="face">The face or faces that are being updated.</param>
    /// <param name="param">The single-valued material parameter of the face or faces being updated. Must be Shininess.</param>
    /// <param name="values">The value to which parameter will be set.</param>
    public static unsafe void Material(GlFace face, GlMaterialParameter param, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glMaterialfv(face, param, p);
    }

    /// <summary>
    /// Specifies material parameters for the lighting model.
    /// </summary>
    /// <param name="face">The face or faces that are being updated.</param>
    /// <param name="param">The single-valued material parameter of the face or faces being updated. Must be Shininess.</param>
    /// <param name="value">The value to which parameter will be set.</param>
    public static void Material(GlFace face, GlMaterialParameter param, int value)
        => Interop.glMateriali(face, param, value);

    /// <summary>
    /// Specifies material parameters for the lighting model.
    /// </summary>
    /// <param name="face">The face or faces that are being updated.</param>
    /// <param name="param">The single-valued material parameter of the face or faces being updated. Must be Shininess.</param>
    /// <param name="values">The value to which parameter will be set.</param>
    public static unsafe void Material(GlFace face, GlMaterialParameter param, ReadOnlySpan<int> values)
    {
        fixed (int* p = values)
            Interop.glMaterialiv(face, param, p);
    }

    /// <summary>
    /// Specifies which matrix is the current matrix.
    /// </summary>
    /// <param name="mode">The matrix stack that is the target for subsequent matrix operations.</param>
    public static void MatrixMode(GlMatrix mode) => Interop.glMatrixMode(mode);

    /// <summary>
    /// Multiplies the current matrix by an arbitrary matrix.
    /// </summary>
    /// <param name="m">A 4x4 matrix stored in column-major order as 16 consecutive values.</param>
    public static unsafe void MultMatrix(ReadOnlySpan<double> m)
    {
        fixed (double* p = m)
            Interop.glMultMatrixd(p);
    }

    /// <summary>
    /// Multiplies the current matrix by an arbitrary matrix.
    /// </summary>
    /// <param name="m">A 4x4 matrix stored in column-major order as 16 consecutive values.</param>
    public static unsafe void MultMatrix(ReadOnlySpan<float> m)
    {
        fixed (float* p = m)
            Interop.glMultMatrixf(p);
    }

    /// <summary>
    /// The NewList and EndList functions create or replace a display list.
    /// </summary>
    /// <param name="list">The display list name.</param>
    /// <param name="mode">The compilation mode.</param>
    public static void NewList(uint list, GlCompilationMode mode) => Interop.glNewList(list, mode);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    public static void Normal(sbyte nx, sbyte ny, sbyte nz) => Interop.glNormal3b(nx, ny, nz);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="v">An array of three elements: the x, y, and z coordinates of the new current normal.</param>
    public static unsafe void Normal(ReadOnlySpan<sbyte> v)
    {
        fixed (sbyte* p = v)
            Interop.glNormal3bv(p);
    }

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    public static void Normal(double nx, double ny, double nz) => Interop.glNormal3d(nx, ny, nz);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="v">An array of three elements: the x, y, and z coordinates of the new current normal.</param>
    public static unsafe void Normal(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glNormal3dv(p);
    }

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    public static void Normal(float nx, float ny, float nz) => Interop.glNormal3f(nx, ny, nz);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="v">An array of three elements: the x, y, and z coordinates of the new current normal.</param>
    public static unsafe void Normal(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glNormal3fv(p);
    }

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    public static void Normal(int nx, int ny, int nz) => Interop.glNormal3i(nx, ny, nz);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="v">An array of three elements: the x, y, and z coordinates of the new current normal.</param>
    public static unsafe void Normal(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glNormal3iv(p);
    }

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    public static void Normal(short nx, short ny, short nz) => Interop.glNormal3s(nx, ny, nz);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="v">An array of three elements: the x, y, and z coordinates of the new current normal.</param>
    public static unsafe void Normal(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glNormal3sv(p);
    }

    /// <summary>
    /// Defines an array of normals.
    /// </summary>
    /// <param name="type">The data type of each coordinate in the array.</param>
    /// <param name="stride">The byte offset between consecutive normals. When stride is zero,
    /// the normals are tightly packed in the array.</param>
    /// <param name="array">An array of the normals.</param>
    public static unsafe void NormalPointer(GlDataType type, int stride, ReadOnlySpan<byte> array)
    {
        fixed (byte* p = array)
            Interop.glNormalPointer(type, stride, p);
    }

    /// <summary>
    /// Multiplies the current matrix by an orthographic matrix.
    /// </summary>
    /// <param name="left">The coordinates for the left vertical clipping plane.</param>
    /// <param name="right">The coordinates for the right vertical clipping plane.</param>
    /// <param name="bottom">The coordinates for the bottom horizontal clipping plane.</param>
    /// <param name="top">The coordinates for the top horizontal clipping plans.</param>
    /// <param name="zNear">The distances to the nearer depth clipping plane.
    /// This distance is negative if the plane is to be behind the viewer.</param>
    /// <param name="zFar">The distances to the farther depth clipping plane.
    /// This distance is negative if the plane is to be behind the viewer.</param>
    public static void Ortho(double left, double right, double bottom, double top, double zNear, double zFar)
        => Interop.glOrtho(left, right, bottom, top, zNear, zFar);

    /// <summary>
    /// Places a marker in the feedback buffer.
    /// </summary>
    public static void PassThrough() => Interop.glPassThrough(Constants.GL_PASS_THROUGH_TOKEN);

    /// <summary>
    /// Sets up pixel transfer maps.
    /// </summary>
    /// <param name="map">A symbolic map name.</param>
    /// <param name="values">An array of values.</param>
    public static unsafe void PixelMap(GlPixelMap map, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glPixelMapfv(map, values.Length, p);
    }

    /// <summary>
    /// Sets up pixel transfer maps.
    /// </summary>
    /// <param name="map">A symbolic map name.</param>
    /// <param name="values">An array of values.</param>
    public static unsafe void PixelMap(GlPixelMap map, ReadOnlySpan<uint> values)
    {
        fixed (uint* p = values)
            Interop.glPixelMapuiv(map, values.Length, p);
    }

    /// <summary>
    /// Sets up pixel transfer maps.
    /// </summary>
    /// <param name="map">A symbolic map name.</param>
    /// <param name="values">An array of values.</param>
    public static unsafe void PixelMap(GlPixelMap map, ReadOnlySpan<ushort> values)
    {
        fixed (ushort* p = values)
            Interop.glPixelMapusv(map, values.Length, p);
    }

    /// <summary>
    /// Sets pixel storage modes.
    /// </summary>
    /// <param name="param">The symbolic name of the parameter to be set.</param>
    /// <param name="value">The value that parameter is set to.</param>
    public static void PixelStore(GlPixelStoreType param, float value) => Interop.glPixelStoref(param, value);

    /// <summary>
    /// Sets pixel storage modes.
    /// </summary>
    /// <param name="param">The symbolic name of the parameter to be set.</param>
    /// <param name="value">The value that parameter is set to.</param>
    public static void PixelStore(GlPixelStoreType param, int value) => Interop.glPixelStorei(param, value);

    /// <summary>
    /// Sets pixel transfer modes.
    /// </summary>
    /// <param name="param">The symbolic name of the pixel transfer parameter to be set.</param>
    /// <param name="value">The value that the parameter is set to.</param>
    public static void PixelTransfer(GlPixelTransferParameter param, float value)
        => Interop.glPixelTransferf(param, value);

    /// <summary>
    /// Sets pixel transfer modes.
    /// </summary>
    /// <param name="param">The symbolic name of the pixel transfer parameter to be set.</param>
    /// <param name="value">The value that the parameter is set to.</param>
    public static void PixelTransfer(GlPixelTransferParameter param, int value)
        => Interop.glPixelTransferi(param, value);

    /// <summary>
    /// Specifies the pixel zoom factors.
    /// </summary>
    /// <param name="xFactor">The x zoom factor for pixel write operations.</param>
    /// <param name="yFactor">The y zoom factor for pixel write operations.</param>
    public static void PixelZoom(float xFactor, float yFactor) => Interop.glPixelZoom(xFactor, yFactor);

    /// <summary>
    /// Specifies the diameter of rasterized points.
    /// </summary>
    /// <param name="size">The diameter of rasterized points. The default is 1.0.</param>
    public static void PointSize(float size) => Interop.glPointSize(size);

    /// <summary>
    /// Selects a polygon rasterization mode.
    /// </summary>
    /// <param name="face">The polygons that mode applies to.</param>
    /// <param name="mode">The way polygons will be rasterized.</param>
    public static void PolygonMode(GlFace face, GlPolygonMode mode) => Interop.glPolygonMode(face, mode);

    /// <summary>
    /// Sets the scale and units OpenGL uses to calculate depth values.
    /// </summary>
    /// <param name="factor">Specifies a scale factor that is used to create a variable depth offset for each polygon.
    /// The initial value is zero.</param>
    /// <param name="units">Specifies a value that is multiplied by an implementation-specific value to create
    /// a constant depth offset. The initial value is 0.</param>
    public static void PolygonOffset(float factor, float units) => Interop.glPolygonOffset(factor, units);

    /// <summary>
    /// Sets the polygon stippling pattern.
    /// </summary>
    /// <param name="mask">A 32x32 stipple pattern that will be unpacked from memory in the same way that
    /// glDrawPixels unpacks pixels.</param>
    public static unsafe void PolygonStipple(ReadOnlySpan<byte> mask)
    {
        fixed (byte* p = mask)
            Interop.glPolygonStipple(p);
    }

    /// <summary>
    /// Pops the attribute stack.
    /// </summary>
    public static void PopAttrib() => Interop.glPopAttrib();

    /// <summary>
    /// Restore groups of client-state variables on the client-attribute stack.
    /// </summary>
    public static void PopClientAttrib() => Interop.glPopClientAttrib();

    /// <summary>
    /// Pops the current matrix from the stack.
    /// </summary>
    public static void PopMatrix() => Interop.glPopMatrix();

    /// <summary>
    /// Pops the name from the stack.
    /// </summary>
    public static void PopName() => Interop.glPopName();

    /// <summary>
    /// Sets the residence priority of textures.
    /// </summary>
    /// <param name="textures">An array containing the names of the textures to be prioritized.</param>
    /// <param name="priorities">An array containing the texture priorities.
    /// A priority given in an element of the priorities parameter applies to the texture named by the corresponding
    /// element of the texture parameter.</param>
    public static unsafe void PrioritizeTextures(ReadOnlySpan<uint> textures, ReadOnlySpan<float> priorities)
    {
        fixed (uint* p1 = textures)
        fixed (float* p2 = priorities)
            Interop.glPrioritizeTextures(textures.Length, p1, p2);
    }

    /// <summary>
    /// Pushes the attribute stack.
    /// </summary>
    /// <param name="mask">A mask that indicates which attributes to save.</param>
    public static void PushAttrib(GlAttributes mask) => Interop.glPushAttrib(mask);

    /// <summary>
    /// Saves groups of client-state variables on the client-attribute stack.
    /// </summary>
    /// <param name="mask">A mask that indicates which attributes to save.</param>
    public static void PushClientAttrib(GlClientAttributes mask) => Interop.glPushClientAttrib(mask);

    /// <summary>
    /// Pushes the current matrix stack.
    /// </summary>
    public static void PushMatrix() => Interop.glPushMatrix();

    /// <summary>
    /// Pushes the name stack.
    /// </summary>
    /// <param name="name"></param>
    public static void PushName(uint name) => Interop.glPushName(name);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    public static void RasterPos2(double x, double y) => Interop.glRasterPos2d(x, y);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of two elements, specifying x and y coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos2(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glRasterPos2dv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    public static void RasterPos2(float x, float y) => Interop.glRasterPos2f(x, y);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of two elements, specifying x and y coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos2(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glRasterPos2fv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    public static void RasterPos2(int x, int y) => Interop.glRasterPos2i(x, y);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of two elements, specifying x and y coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos2(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glRasterPos2iv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    public static void RasterPos2(short x, short y) => Interop.glRasterPos2s(x, y);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of two elements, specifying x and y coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos2(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glRasterPos2sv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    public static void RasterPos3(double x, double y, double z) => Interop.glRasterPos3d(x, y, z);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of three elements, specifying x, y, and z coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos3(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glRasterPos3dv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    public static void RasterPos3(float x, float y, float z) => Interop.glRasterPos3f(x, y, z);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of three elements, specifying x, y, and z coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos3(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glRasterPos3fv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    public static void RasterPos3(int x, int y, int z) => Interop.glRasterPos3i(x, y, z);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of three elements, specifying x, y, and z coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos3(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glRasterPos3iv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    public static void RasterPos3(short x, short y, short z) => Interop.glRasterPos3s(x, y, z);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of three elements, specifying x, y, and z coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos3(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glRasterPos3sv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    /// <param name="w">Specifies the w-coordinate for the current raster position.</param>
    public static void RasterPos4(double x, double y, double z, double w) => Interop.glRasterPos4d(x, y, z, w);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of four elements, specifying x, y, z, and w coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos4(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glRasterPos4dv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    /// <param name="w">Specifies the w-coordinate for the current raster position.</param>
    public static void RasterPos4(float x, float y, float z, float w) => Interop.glRasterPos4f(x, y, z, w);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of four elements, specifying x, y, z, and w coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos4(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glRasterPos4fv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    /// <param name="w">Specifies the w-coordinate for the current raster position.</param>
    public static void RasterPos4(int x, int y, int z, int w) => Interop.glRasterPos4i(x, y, z, w);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of four elements, specifying x, y, z, and w coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos4(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glRasterPos4iv(p);
    }

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate for the current raster position.</param>
    /// <param name="y">Specifies the y-coordinate for the current raster position.</param>
    /// <param name="z">Specifies the z-coordinate for the current raster position.</param>
    /// <param name="w">Specifies the w-coordinate for the current raster position.</param>
    public static void RasterPos4(short x, short y, short z, short w) => Interop.glRasterPos4s(x, y, z, w);

    /// <summary>
    /// Specifies the raster position for pixel operations.
    /// </summary>
    /// <param name="v">An array of four elements, specifying x, y, z, and w coordinates for
    /// the current raster position.</param>
    public static unsafe void RasterPos4(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glRasterPos4sv(p);
    }

    /// <summary>
    /// Selects a color buffer source for pixels.
    /// </summary>
    /// <param name="mode">A color buffer.</param>
    public static void ReadBuffer(GlColorBuffer mode) => Interop.glReadBuffer(mode);

    /// <summary>
    /// Reads a block of pixels from the framebuffer.
    /// </summary>
    /// <param name="x">The window x coordinate of the first pixel that is read from the framebuffer.
    /// Together with the y coordinate, specifies the location of the lower-left corner of a rectangular block
    /// of pixels.</param>
    /// <param name="y">The window y coordinates of the first pixel that is read from the framebuffer.
    /// Together with the x coordinate, specifies the location of the lower-left corner of a rectangular block
    /// of pixels.</param>
    /// <param name="width">The width of the pixel rectangle.</param>
    /// <param name="height">The height of the pixel rectangle. Width and height parameters of value "1"
    /// correspond to a single pixel.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">Returns the pixel data.</param>
    public static unsafe void ReadPixels(int x, int y, int width, int height, GlDrawPixelFormat format, GlDataType type,
        Span<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glReadPixels(x, y, width, height, format, type, p);
    }

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="x1">The x coordinate of the vertex of a rectangle.</param>
    /// <param name="y1">The y coordinate of the vertex of a rectangle.</param>
    /// <param name="x2">The x coordinate of the opposite vertex of the rectangle.</param>
    /// <param name="y2">The y coordinate of the opposite vertex of the rectangle.</param>
    public static void Rect(double x1, double y1, double x2, double y2) => Interop.glRectd(x1, y1, x2, y2);

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="v1">One vertex of a rectangle.</param>
    /// <param name="v2">The opposite vertex of the rectangle.</param>
    public static unsafe void Rect(ReadOnlySpan<double> v1, ReadOnlySpan<double> v2)
    {
        fixed (double* p1 = v1)
        fixed (double* p2 = v2)
            Interop.glRectdv(p1, p2);
    }

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="x1">The x coordinate of the vertex of a rectangle.</param>
    /// <param name="y1">The y coordinate of the vertex of a rectangle.</param>
    /// <param name="x2">The x coordinate of the opposite vertex of the rectangle.</param>
    /// <param name="y2">The y coordinate of the opposite vertex of the rectangle.</param>
    public static void Rect(float x1, float y1, float x2, float y2) => Interop.glRectf(x1, y1, x2, y2);

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="v1">One vertex of a rectangle.</param>
    /// <param name="v2">The opposite vertex of the rectangle.</param>
    public static unsafe void Rect(ReadOnlySpan<float> v1, ReadOnlySpan<float> v2)
    {
        fixed (float* p1 = v1)
        fixed (float* p2 = v2)
            Interop.glRectfv(p1, p2);
    }

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="x1">The x coordinate of the vertex of a rectangle.</param>
    /// <param name="y1">The y coordinate of the vertex of a rectangle.</param>
    /// <param name="x2">The x coordinate of the opposite vertex of the rectangle.</param>
    /// <param name="y2">The y coordinate of the opposite vertex of the rectangle.</param>
    public static void Rect(int x1, int y1, int x2, int y2) => Interop.glRecti(x1, y1, x2, y2);

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="v1">One vertex of a rectangle.</param>
    /// <param name="v2">The opposite vertex of the rectangle.</param>
    public static unsafe void Rect(ReadOnlySpan<int> v1, ReadOnlySpan<int> v2)
    {
        fixed (int* p1 = v1)
        fixed (int* p2 = v2)
            Interop.glRectiv(p1, p2);
    }

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="x1">The x coordinate of the vertex of a rectangle.</param>
    /// <param name="y1">The y coordinate of the vertex of a rectangle.</param>
    /// <param name="x2">The x coordinate of the opposite vertex of the rectangle.</param>
    /// <param name="y2">The y coordinate of the opposite vertex of the rectangle.</param>
    public static void Rect(short x1, short y1, short x2, short y2) => Interop.glRects(x1, y1, x2, y2);

    /// <summary>
    /// Draws a rectangle.
    /// </summary>
    /// <param name="v1">One vertex of a rectangle.</param>
    /// <param name="v2">The opposite vertex of the rectangle.</param>
    public static unsafe void Rect(ReadOnlySpan<short> v1, ReadOnlySpan<short> v2)
    {
        fixed (short* p1 = v1)
        fixed (short* p2 = v2)
            Interop.glRectsv(p1, p2);
    }

    /// <summary>
    /// Sets the rasterization mode.
    /// </summary>
    /// <param name="mode">The rasterization mode.</param>
    /// <returns>The return value of the glRenderMode function is determined by the render mode at the time
    /// glRenderMode is called, rather than by mode. The values returned for the three render modes are
    /// as follows.
    /// GL_RENDER	Zero.
    /// GL_SELECT	The number of hit records transferred to the select buffer.
    /// GL_FEEDBACK	The number of values (not vertices) transferred to the feedback buffer.
    /// </returns>
    public static int RenderMode(GlRenderMode mode) => Interop.glRenderMode(mode);

    /// <summary>
    /// Multiplies the current matrix by a rotation matrix.
    /// </summary>
    /// <param name="angle">The angle of rotation, in degrees.</param>
    /// <param name="x">The x coordinate of a vector.</param>
    /// <param name="y">The y coordinate of a vector.</param>
    /// <param name="z">The z coordinate of a vector.</param>
    public static void Rotate(double angle, double x, double y, double z) => Interop.glRotated(angle, x, y, z);

    /// <summary>
    /// Multiplies the current matrix by a rotation matrix.
    /// </summary>
    /// <param name="angle">The angle of rotation, in degrees.</param>
    /// <param name="x">The x coordinate of a vector.</param>
    /// <param name="y">The y coordinate of a vector.</param>
    /// <param name="z">The z coordinate of a vector.</param>
    public static void Rotate(float angle, float x, float y, float z) => Interop.glRotatef(angle, x, y, z);

    /// <summary>
    /// Multiply the current matrix by a general scaling matrix.
    /// </summary>
    /// <param name="x">Scale factors along the x-axis.</param>
    /// <param name="y">Scale factors along the y-axis.</param>
    /// <param name="z">Scale factors along the z-axis.</param>
    public static void Scale(double x, double y, double z) => Interop.glScaled(x, y, z);

    /// <summary>
    /// Multiply the current matrix by a general scaling matrix.
    /// </summary>
    /// <param name="x">Scale factors along the x-axis.</param>
    /// <param name="y">Scale factors along the y-axis.</param>
    /// <param name="z">Scale factors along the z-axis.</param>
    public static void Scale(float x, float y, float z) => Interop.glScalef(x, y, z);

    /// <summary>
    /// Defines the scissor box.
    /// </summary>
    /// <param name="x">The x (vertical axis) coordinate for the lower-left corner of the scissor box.</param>
    /// <param name="y">The y (horizontal axis) coordinate for the lower-left corner of the scissor box.
    /// Together, x and y specify the lower-left corner of the scissor box. Initially (0,0).</param>
    /// <param name="width">The width of the scissor box.</param>
    /// <param name="height">The height of the scissor box. When an OpenGL context is first attached to a window,
    /// width and height are set to the dimensions of that window.</param>
    public static void Scissor(int x, int y, int width, int height) => Interop.glScissor(x, y, width, height);

    /// <summary>
    /// Establishes a buffer for selection mode values.
    /// </summary>
    /// <param name="buffer">Returns the selection data.</param>
    public static unsafe void SelectBuffer(Span<uint> buffer)
    {
        fixed (uint* p = buffer)
            Interop.glSelectBuffer(buffer.Length, p);
    }

    /// <summary>
    /// Selects flat or smooth shading.
    /// </summary>
    /// <param name="mode"></param>
    public static void ShadeModel(GlShadingMode mode) => Interop.glShadeModel(mode);

    /// <summary>
    /// Sets the function and reference value for stencil testing.
    /// </summary>
    /// <param name="func">The test function.</param>
    /// <param name="ref">The reference value for the stencil test. The ref parameter is clamped to the range [0, 2n 1],
    /// where n is the number of bitplanes in the stencil buffer.</param>
    /// <param name="mask">A mask that is ANDed with both the reference value and the stored stencil value when
    /// the test is done.</param>
    public static void StencilFunc(GlTestFunction func, int @ref, uint mask) => Interop.glStencilFunc(func, @ref, mask);

    /// <summary>
    /// Controls the writing of individual bits in the stencil planes.
    /// </summary>
    /// <param name="mask">A bit mask to enable and disable writing of individual bits in the stencil planes.
    /// Initially, the mask is all ones.</param>
    public static void StencilMask(uint mask) => Interop.glStencilMask(mask);

    /// <summary>
    /// Sets the stencil test actions.
    /// </summary>
    /// <param name="fail">The action to take when the stencil test fails.</param>
    /// <param name="zFail">Stencil action when the stencil test passes, but the depth test fails.</param>
    /// <param name="zPass">Stencil action when both the stencil test and the depth test pass, or when the stencil
    /// test passes and either there is no depth buffer or depth testing is not enabled.</param>
    public static void StencilOp(GlStencilOp fail, GlStencilOp zFail, GlStencilOp zPass)
        => Interop.glStencilOp(fail, zFail, zPass);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    public static void TexCoord1(double s) => Interop.glTexCoord1d(s);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord1(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glTexCoord1dv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    public static void TexCoord1(float s) => Interop.glTexCoord1f(s);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord1(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glTexCoord1fv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    public static void TexCoord1(int s) => Interop.glTexCoord1i(s);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord1(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glTexCoord1iv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    public static void TexCoord1(short s) => Interop.glTexCoord1s(s);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord1(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glTexCoord1sv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    public static void TexCoord2(double s, double t) => Interop.glTexCoord2d(s, t);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord2(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glTexCoord2dv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    public static void TexCoord2(float s, float t) => Interop.glTexCoord2f(s, t);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord2(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glTexCoord2fv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    public static void TexCoord2(int s, int t) => Interop.glTexCoord2i(s, t);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord2(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glTexCoord2iv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    public static void TexCoord2(short s, short t) => Interop.glTexCoord2s(s, t);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord2(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glTexCoord2sv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    public static void TexCoord3(double s, double t, double r) => Interop.glTexCoord3d(s, t, r);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord3(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glTexCoord3dv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    public static void TexCoord3(float s, float t, float r) => Interop.glTexCoord3f(s, t, r);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord3(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glTexCoord3fv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    public static void TexCoord3(int s, int t, int r) => Interop.glTexCoord3i(s, t, r);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord3(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glTexCoord3iv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    public static void TexCoord3(short s, short t, short r) => Interop.glTexCoord3s(s, t, r);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord3(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glTexCoord3sv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    /// <param name="q">The q texture coordinate.</param>
    public static void TexCoord4(double s, double t, double r, double q) => Interop.glTexCoord4d(s, t, r, q);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord4(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glTexCoord4dv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    /// <param name="q">The q texture coordinate.</param>
    public static void TexCoord4(float s, float t, float r, float q) => Interop.glTexCoord4f(s, t, r, q);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord4(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glTexCoord4fv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    /// <param name="q">The q texture coordinate.</param>
    public static void TexCoord4(int s, int t, int r, int q) => Interop.glTexCoord4i(s, t, r, q);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord4(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glTexCoord4iv(p);
    }

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="s">The s texture coordinate.</param>
    /// <param name="t">The t texture coordinate.</param>
    /// <param name="r">The r texture coordinate.</param>
    /// <param name="q">The q texture coordinate.</param>
    public static void TexCoord4(short s, short t, short r, short q) => Interop.glTexCoord4s(s, t, r, q);

    /// <summary>
    /// Sets the current texture coordinates.
    /// </summary>
    /// <param name="v">An array of texture coordinates.</param>
    public static unsafe void TexCoord4(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glTexCoord4sv(p);
    }

    /// <summary>
    /// Defines an array of texture coordinates.
    /// </summary>
    /// <param name="size">The number of coordinates per array element. The value of size must be 1, 2, 3, or 4.</param>
    /// <param name="type">The data type of each texture coordinate in the array.</param>
    /// <param name="stride">The byte offset between consecutive array elements. When stride is zero,
    /// the array elements are tightly packed in the array.</param>
    /// <param name="array">An array of texture coordinates.</param>
    public static unsafe void TexCoordPointer(int size, GlDataType type, int stride, ReadOnlySpan<byte> array)
    {
        fixed (byte* p = array)
            Interop.glTexCoordPointer(size, type, stride, p);
    }

    /// <summary>
    /// Sets a texture environment mode.
    /// </summary>
    /// <param name="mode">A single symbolic constant.</param>
    public static void TexEnvMode(GlTexEnvMode mode)
        => Interop.glTexEnvi(Constants.GL_TEXTURE_ENV, Constants.GL_TEXTURE_ENV_MODE, mode);

    /// <summary>
    /// Sets a texture environment RGBA color.
    /// </summary>
    /// <param name="color">An array of 4 values of RGBA color.</param>
    public static unsafe void TexEnvColor(ReadOnlySpan<float> color)
    {
        fixed (float* p = color)
            Interop.glTexEnvfv(Constants.GL_TEXTURE_ENV, Constants.GL_TEXTURE_ENV_COLOR, p);
    }

    /// <summary>
    /// Sets a texture environment RGBA color.
    /// </summary>
    /// <param name="color">An array of 4 values of RGBA color.</param>
    public static unsafe void TexEnvColor(ReadOnlySpan<int> color)
    {
        fixed (int* p = color)
            Interop.glTexEnviv(Constants.GL_TEXTURE_ENV, Constants.GL_TEXTURE_ENV_COLOR, p);
    }

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="value">A single valued texture generation parameter.</param>
    public static void TexGen(GlTextureCoord coord, GlTextureCoordParam param, double value)
        => Interop.glTexGend(coord, param, value);

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="values">An array that contains the coefficients for the corresponding texture generation
    /// function.</param>
    public static unsafe void TexGen(GlTextureCoord coord, GlTextureCoordParam param, ReadOnlySpan<double> values)
    {
        fixed (double* p = values)
            Interop.glTexGendv(coord, param, p);
    }

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="value">A single valued texture generation parameter.</param>
    public static void TexGen(GlTextureCoord coord, GlTextureCoordParam param, float value)
        => Interop.glTexGenf(coord, param, value);

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="values">An array that contains the coefficients for the corresponding texture generation
    /// function.</param>
    public static unsafe void TexGen(GlTextureCoord coord, GlTextureCoordParam param, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glTexGenfv(coord, param, p);
    }

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="value">A single valued texture generation parameter.</param>
    public static void TexGen(GlTextureCoord coord, GlTextureCoordParam param, int value)
        => Interop.glTexGeni(coord, param, value);

    /// <summary>
    /// Controls the generation of texture coordinates.
    /// </summary>
    /// <param name="coord">A texture coordinate.</param>
    /// <param name="param">The symbolic name of the texture coordinate generation function.</param>
    /// <param name="values">An array that contains the coefficients for the corresponding texture generation
    /// function.</param>
    public static unsafe void TexGen(GlTextureCoord coord, GlTextureCoordParam param, ReadOnlySpan<int> values)
    {
        fixed (int* p = values)
            Interop.glTexGeniv(coord, param, p);
    }

    /// <summary>
    /// Specifies a one-dimensional texture image.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image level.
    /// Level n is the nTh mipmap reduction image.</param>
    /// <param name="internalformat">Specifies the number of color components in the texture. Must be 1, 2, 3, or 4,
    /// or one of the following symbolic constants.</param>
    /// <param name="width">The width of the texture image. Must be 2n + 2( border ) for some integer n.
    /// The height of the texture image is 1.</param>
    /// <param name="border">The width of the border. Must be either 0 or 1.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">The image data in memory.</param>
    public static unsafe void TexImage1D(int level, GlTexturePixelFormat internalformat, int width, int border,
        GlDrawPixelFormat format, GlDataType type, ReadOnlySpan<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glTexImage1D(Constants.GL_TEXTURE_1D, level, internalformat, width, border, format, type, p);
    }

    /// <summary>
    /// Specifies a two-dimensional texture image.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image level.
    /// Level n is the n th mipmap reduction image.</param>
    /// <param name="internalformat">The number of color components in the texture. Must be 1, 2, 3, or 4,
    /// or one of the following symbolic constants.</param>
    /// <param name="width">The width of the texture image. Must be 2n + 2(border) for some integer n.</param>
    /// <param name="height">The height of the texture image. Must be 2*m* + 2(border) for some integer m.</param>
    /// <param name="border">The width of the border. Must be either 0 or 1.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">The image data in memory.</param>
    public static unsafe void TexImage2D(int level, GlTexturePixelFormat internalformat, int width, int height,
        int border, GlDrawPixelFormat format, GlDataType type, ReadOnlySpan<byte> pixels)
    {
        fixed (byte* p = pixels)
        {
            Interop.glTexImage2D(Constants.GL_TEXTURE_2D, level, internalformat, width, height, border, format, type,
                p);
        }
    }

    /// <summary>
    /// Sets texture parameters.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="param">The symbolic name of a single valued texture parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    public static void TexParameter(GlTextureTarget target, GlTextureParameter param, float value)
        => Interop.glTexParameterf(target, param, value);

    /// <summary>
    /// Sets texture parameters.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="param">The symbolic name of a single valued texture parameter.</param>
    /// <param name="values">The value of the parameter.</param>
    public static unsafe void TexParameter(GlTextureTarget target, GlTextureParameter param, ReadOnlySpan<float> values)
    {
        fixed (float* p = values)
            Interop.glTexParameterfv(target, param, p);
    }

    /// <summary>
    /// Sets texture parameters.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="param">The symbolic name of a single valued texture parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    public static void TexParameter(GlTextureTarget target, GlTextureParameter param, int value)
        => Interop.glTexParameteri(target, param, value);

    /// <summary>
    /// Sets texture parameters.
    /// </summary>
    /// <param name="target">The target texture.</param>
    /// <param name="param">The symbolic name of a single valued texture parameter.</param>
    /// <param name="values">The value of the parameter.</param>
    public static unsafe void TexParameter(GlTextureTarget target, GlTextureParameter param, ReadOnlySpan<int> values)
    {
        fixed (int* p = values)
            Interop.glTexParameteriv(target, param, p);
    }

    /// <summary>
    /// Specifies a portion of an existing one-dimensional texture image.
    /// You cannot define a new texture with TexSubImage1D.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image.
    /// Level n is the nth mipmap reduction image.</param>
    /// <param name="xOffset">A texel offset in the x direction within the texture array.</param>
    /// <param name="width">The width of the texture sub-image.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">The image data in memory.</param>
    public static unsafe void TexSubImage1D(int level, int xOffset, int width, GlDrawPixelFormat format,
        GlDataType type, ReadOnlySpan<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glTexSubImage1D(Constants.GL_TEXTURE_1D, level, xOffset, width, format, type, p);
    }

    /// <summary>
    /// Specifies a portion of an existing one-dimensional texture image.
    /// You cannot define a new texture with glTexSubImage2D.
    /// </summary>
    /// <param name="level">The level-of-detail number. Level 0 is the base image.
    /// Level n is the nth mipmap reduction image.</param>
    /// <param name="xOffset">A texel offset in the x direction within the texture array.</param>
    /// <param name="yOffset">A texel offset in the y direction within the texture array.</param>
    /// <param name="width">The width of the texture sub-image.</param>
    /// <param name="height">The height of the texture sub-image.</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">The image data in memory.</param>
    public static unsafe void TexSubImage2D(int level, int xOffset, int yOffset, int width, int height,
        GlDrawPixelFormat format, GlDataType type, ReadOnlySpan<byte> pixels)
    {
        fixed (byte* p = pixels)
            Interop.glTexSubImage2D(Constants.GL_TEXTURE_2D, level, xOffset, yOffset, width, height, format, type, p);
    }

    /// <summary>
    /// Multiplies the current matrix by a translation matrix.
    /// </summary>
    /// <param name="x">The x coordinate of a translation vector.</param>
    /// <param name="y">The y coordinate of a translation vector.</param>
    /// <param name="z">The z coordinate of a translation vector.</param>
    public static void Translate(double x, double y, double z) => Interop.glTranslated(x, y, z);

    /// <summary>
    /// Multiplies the current matrix by a translation matrix.
    /// </summary>
    /// <param name="x">The x coordinate of a translation vector.</param>
    /// <param name="y">The y coordinate of a translation vector.</param>
    /// <param name="z">The z coordinate of a translation vector.</param>
    public static void Translate(float x, float y, float z) => Interop.glTranslatef(x, y, z);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    public static void Vertex2(double x, double y) => Interop.glVertex2d(x, y);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of two elements. The elements are the x and y coordinates of a vertex.
    /// </param>
    public static unsafe void Vertex2(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glVertex2dv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    public static void Vertex2(float x, float y) => Interop.glVertex2f(x, y);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of two elements. The elements are the x and y coordinates of a vertex.
    /// </param>
    public static unsafe void Vertex2(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glVertex2fv(p);
    }
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    public static void Vertex2(int x, int y) => Interop.glVertex2i(x, y);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of two elements. The elements are the x and y coordinates of a vertex.
    /// </param>
    public static unsafe void Vertex2(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glVertex2iv(p);
    }
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    public static void Vertex2(short x, short y) => Interop.glVertex2s(x, y);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of two elements. The elements are the x and y coordinates of a vertex.
    /// </param>
    public static unsafe void Vertex2(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glVertex2sv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    public static void Vertex3(double x, double y, double z) => Interop.glVertex3d(x, y, z);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of three elements. The elements are the x, y, and z coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex3(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glVertex3dv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    public static void Vertex3(float x, float y, float z) => Interop.glVertex3f(x, y, z);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of three elements. The elements are the x, y, and z coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex3(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glVertex3fv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    public static void Vertex3(int x, int y, int z) => Interop.glVertex3i(x, y, z);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of three elements. The elements are the x, y, and z coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex3(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glVertex3iv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    public static void Vertex3(short x, short y, short z) => Interop.glVertex3s(x, y, z);
    
    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of three elements. The elements are the x, y, and z coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex3(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glVertex3sv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    /// <param name="w">Specifies the w-coordinate of a vertex.</param>
    public static void Vertex4(double x, double y, double z, double w) => Interop.glVertex4d(x, y, z, w);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of four elements. The elements are the x, y, z, and w coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex4(ReadOnlySpan<double> v)
    {
        fixed (double* p = v)
            Interop.glVertex4dv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    /// <param name="w">Specifies the w-coordinate of a vertex.</param>
    public static void Vertex4(float x, float y, float z, float w) => Interop.glVertex4f(x, y, z, w);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of four elements. The elements are the x, y, z, and w coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex4(ReadOnlySpan<float> v)
    {
        fixed (float* p = v)
            Interop.glVertex4fv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    /// <param name="w">Specifies the w-coordinate of a vertex.</param>
    public static void Vertex4(int x, int y, int z, int w) => Interop.glVertex4i(x, y, z, w);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of four elements. The elements are the x, y, z, and w coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex4(ReadOnlySpan<int> v)
    {
        fixed (int* p = v)
            Interop.glVertex4iv(p);
    }

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    /// <param name="w">Specifies the w-coordinate of a vertex.</param>
    public static void Vertex4(short x, short y, short z, short w) => Interop.glVertex4s(x, y, z, w);

    /// <summary>
    /// Specifies a vertex.
    /// </summary>
    /// <param name="v">A pointer to an array of four elements. The elements are the x, y, z, and w coordinates of
    /// a vertex.</param>
    public static unsafe void Vertex4(ReadOnlySpan<short> v)
    {
        fixed (short* p = v)
            Interop.glVertex4sv(p);
    }

    /// <summary>
    /// Defines an array of vertex data.
    /// </summary>
    /// <param name="size">The number of coordinates per vertex. The value of size must be 2, 3, or 4.</param>
    /// <param name="type">The data type of each coordinate in the array.</param>
    /// <param name="stride">The byte offset between consecutive vertices. When stride is zero,
    /// the vertices are tightly packed in the array.</param>
    /// <param name="pointer">An array of the vertices.</param>
    public static unsafe void VertexPointer(int size, GlDataType type, int stride, ReadOnlySpan<byte> pointer)
    {
        fixed (byte* p = pointer)
            Interop.glVertexPointer(size, type, stride, p);
    }

    /// <summary>
    /// Sets the viewport.
    /// </summary>
    /// <param name="x">The lower-left corner of the viewport rectangle, in pixels. The default is (0,0).</param>
    /// <param name="y">The lower-left corner of the viewport rectangle, in pixels. The default is (0,0).</param>
    /// <param name="width">The width of the viewport. When an OpenGL context is first attached to a window,
    /// width and height are set to the dimensions of that window.</param>
    /// <param name="height">The height of the viewport. When an OpenGL context is first attached to a window,
    /// width and height are set to the dimensions of that window.</param>
    public static void Viewport(int x, int y, int width, int height) => Interop.glViewport(x, y, width, height);

    public static HGlRc wglCreateContext(HDc hdc) => Interop.wglCreateContext(hdc);

    public static bool wglMakeCurrent(HDc hdc, HGlRc glRc) => Interop.wglMakeCurrent(hdc, glRc);

    public static HGlRc wglGetCurrentContext() => Interop.wglGetCurrentContext();

    public static HDc wglGetCurrentDC() => Interop.wglGetCurrentDC();

    public static bool wglDeleteContext(HGlRc glRc) => Interop.wglDeleteContext(glRc);
}