namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlPixelStoreType: uint
{
    /// <summary>
    /// If true, byte ordering for multibyte color components, depth components, color indexes, or stencil indexes is
    /// reversed. That is, if a four-byte component is made up of bytes b0 , b1 , b2 , b3 , it is stored in memory as
    /// b3, b2, b1, b0 if GL_PACK_SWAP_BYTES is true. GL_PACK_SWAP_BYTES has no effect on the memory order of components
    /// within a pixel, only on the order of bytes within components or indexes. For example, the three components of
    /// a GL_RGB format pixel are always stored with red first, green second, and blue third, regardless of the value of
    /// GL_PACK_SWAP_BYTES.
    /// </summary>
    PackSwapBytes = Constants.GL_PACK_SWAP_BYTES,

    /// <summary>
    /// If true, bits are ordered within a byte from least significant to most significant; otherwise, the first bit in
    /// each byte is the most significant one. This parameter is significant for bitmap data only.
    /// </summary>
    PackLsbFirst = Constants.GL_PACK_LSB_FIRST,

    /// <summary>
    /// If greater than zero, GL_PACK_ROW_LENGTH defines the number of pixels in a row. If the first pixel of a row is
    /// placed at location p in memory, then the location of the first pixel of the next row is obtained by skipping
    /// [newline] components or indexes, where n is the number of components or indexes in a pixel, l is the number of
    /// pixels in a row (gl-pack-row-length if it is greater than zero, the width argument to the pixel routine
    /// otherwise), a is the value of gl-pack-alignment, and s is the size, in bytes, of a single component (if a &lt;
    /// s, then it is as if a = s). in the case of 1-bit values, the location of the next row is obtained by skipping
    /// components or indexes. The word component in this description refers to the nonindex values red, green, blue,
    /// alpha, and depth. Storage format GL_RGB, for example, has three components per pixel: first red, then green,
    /// and finally blue.
    /// </summary>
    PackRowLength = Constants.GL_PACK_ROW_LENGTH,

    /// <summary>
    /// These values are provided as a convenience to the programmer; they provide no functionality that cannot be
    /// duplicated simply by incrementing the pointer passed to glReadPixels. Setting GL_PACK_SKIP_PIXELS to i is
    /// equivalent to incrementing the pointer by i n components or indexes, where n is the number of components or
    /// indexes in each pixel. Setting GL_PACK_SKIP_ROWS to j is equivalent to incrementing the pointer by j k
    /// components or indexes, where k is the number of components or indexes per row, as computed above in
    /// the GL_PACK_ROW_LENGTH section.
    /// </summary>
    PackSkipPixels = Constants.GL_PACK_SKIP_PIXELS,

    /// <summary>
    /// These values are provided as a convenience to the programmer; they provide no functionality that cannot be
    /// duplicated simply by incrementing the pointer passed to glReadPixels. Setting GL_PACK_SKIP_PIXELS to i is
    /// equivalent to incrementing the pointer by i n components or indexes, where n is the number of components or
    /// indexes in each pixel. Setting GL_PACK_SKIP_ROWS to j is equivalent to incrementing the pointer by j k
    /// components or indexes, where k is the number of components or indexes per row, as computed above in
    /// the GL_PACK_ROW_LENGTH section.
    /// </summary>
    PackSkipRows = Constants.GL_PACK_SKIP_ROWS,

    /// <summary>
    /// Specifies the alignment requirements for the start of each pixel row in memory. The allowable values are 1
    /// (byte-alignment), 2 (rows aligned to even-numbered bytes), 4 (word alignment), and 8 (rows start on
    /// double-word boundaries).
    /// </summary>
    PackAlignment = Constants.GL_PACK_ALIGNMENT,

    /// <summary>
    /// If true, byte ordering for multibyte color components, depth components, color indexes, or stencil indexes is
    /// reversed. That is, if a four-byte component is made up of bytes b0 , b1 , b2 , b3 , it is stored in memory as
    /// b3 , b2 , b1 , b0 if GL_UNPACK_SWAP_BYTES is true. GL_UNPACK_SWAP_BYTES has no effect on the memory order of
    /// components within a pixel, only on the order of bytes within components or indexes. For example, the three
    /// components of a GL_RGB format pixel are always stored with red first, green second, and blue third, regardless
    /// of the value of GL_UNPACK_SWAP_BYTES.
    /// </summary>
    UnpackSwapBytes = Constants.GL_UNPACK_SWAP_BYTES,

    /// <summary>
    /// If true, bits are ordered within a byte from least significant to most significant; otherwise, the first bit in
    /// each byte is the most significant one. This is significant for bitmap data only.
    /// </summary>
    UnpackLsbFirst = Constants.GL_UNPACK_LSB_FIRST,

    /// <summary>
    /// If greater than zero, GL_UNPACK_ROW_LENGTH defines the number of pixels in a row. If the first pixel of a row
    /// is placed at location p in memory, then the location of the first pixel of the next row is obtained by skipping
    /// [newline] components or indexes, where n is the number of components or indexes in a pixel, l is the number
    /// of pixels in a row (gl-pack-row-length if it is greater than zero, the width argument to the pixel routine
    /// otherwise), a is the value of gl-pack-alignment, and s is the size, in bytes, of a single component
    /// (if a &lt; s, then it is as if a = s). in the case of 1-bit values, the location of the next row is obtained
    /// by skipping components or indexes. The word component in this description refers to the nonindex values red,
    /// green, blue, alpha, and depth. Storage format GL_RGB, for example, has three components per pixel: first red,
    /// then green, and finally blue.
    /// </summary>
    UnpackRowLength = Constants.GL_UNPACK_ROW_LENGTH,

    /// <summary>
    /// These values are provided as a convenience to the programmer; they provide no functionality that cannot be
    /// duplicated simply by incrementing the pointer passed to glDrawPixels, glTexImage1D, glTexImage2D, glBitmap,
    /// or glPolygonStipple. Setting GL_UNPACK_SKIP_PIXELS to i is equivalent to incrementing the pointer by i n
    /// components or indexes, where n is the number of components or indexes in each pixel. Setting
    /// GL_UNPACK_SKIP_ROWS to j is equivalent to incrementing the pointer by j k components or indexes, where k is
    /// the number of components or indexes per row, as computed above in the GL_UNPACK_ROW_LENGTH section.
    /// </summary>
    UnpackSkipPixels = Constants.GL_UNPACK_SKIP_PIXELS,

    /// <summary>
    /// These values are provided as a convenience to the programmer; they provide no functionality that cannot be
    /// duplicated simply by incrementing the pointer passed to glDrawPixels, glTexImage1D, glTexImage2D, glBitmap,
    /// or glPolygonStipple. Setting GL_UNPACK_SKIP_PIXELS to i is equivalent to incrementing the pointer by i n
    /// components or indexes, where n is the number of components or indexes in each pixel. Setting
    /// GL_UNPACK_SKIP_ROWS to j is equivalent to incrementing the pointer by j k components or indexes, where k is
    /// the number of components or indexes per row, as computed above in the GL_UNPACK_ROW_LENGTH section.
    /// </summary>
    UnpackSkipRows = Constants.GL_UNPACK_SKIP_ROWS,

    /// <summary>
    /// 	Specifies the alignment requirements for the start of each pixel row in memory. The allowable values are 1
    /// (byte-alignment), 2 (rows aligned to even-numbered bytes), 4 (word alignment), and 8
    /// (rows start on double-word boundaries).
    /// </summary>
    UnpackAlignment = Constants.GL_UNPACK_ALIGNMENT,
}