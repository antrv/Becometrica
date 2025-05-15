namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlParameter: uint
{
    /// <summary>
    /// The params parameter returns one value: the number of alpha bitplanes in the accumulation buffer.
    /// </summary>
    AccumAlphaBits = Constants.GL_ACCUM_ALPHA_BITS,

    /// <summary>
    /// The params parameter returns one value: the number of blue bitplanes in the accumulation buffer.
    /// </summary>
    AccumBlueBits = Constants.GL_ACCUM_BLUE_BITS,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha values used to clear
    /// the accumulation buffer. Integer values, if requested, are linearly mapped from the internal
    /// floating-point representation such that 1.0 returns the most positive representable integer value,
    /// and -1.0 returns the most negative representable integer value. See glClearAccum.
    /// </summary>
    AccumClearValue = Constants.GL_ACCUM_CLEAR_VALUE,

    /// <summary>
    /// The params parameter returns one value: the number of green bitplanes in the accumulation buffer.
    /// </summary>
    AccumGreenBits = Constants.GL_ACCUM_GREEN_BITS,

    /// <summary>
    /// The params parameter returns one value: the number of red bitplanes in the accumulation buffer.
    /// </summary>
    AccumRedBits = Constants.GL_ACCUM_RED_BITS,

    /// <summary>
    /// The params parameter returns one value: the alpha bias factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    AlphaBias = Constants.GL_ALPHA_BIAS,

    /// <summary>
    /// The params parameter returns one value: the number of alpha bitplanes in each color buffer.
    /// </summary>
    AlphaBits = Constants.GL_ALPHA_BITS,

    /// <summary>
    /// The params parameter returns one value: the alpha scale factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    AlphaScale = Constants.GL_ALPHA_SCALE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether alpha testing of fragments is enabled. See glAlphaFunc.
    /// </summary>
    AlphaTest = Constants.GL_ALPHA_TEST,

    /// <summary>
    /// The params parameter returns one value: the symbolic name of the alpha test function. See glAlphaFunc.
    /// </summary>
    AlphaTestFunc = Constants.GL_ALPHA_TEST_FUNC,

    /// <summary>
    /// The params parameter returns one value: the reference value for the alpha test. See glAlphaFunc.
    /// An integer value, if requested, is linearly mapped from the internal floating-point representation
    /// such that 1.0 returns the most positive representable integer value, and -1.0 returns
    /// the most negative representable integer value.
    /// </summary>
    AlphaTestRef = Constants.GL_ALPHA_TEST_REF,

    /// <summary>
    /// The params parameter returns one value: the depth of the attribute stack. If the stack is empty, zero is returned. See glPushAttrib.
    /// </summary>
    AttribStackDepth = Constants.GL_ATTRIB_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D map evaluation automatically
    /// generates surface normals. See glMap2.
    /// </summary>
    AutoNormal = Constants.GL_AUTO_NORMAL,

    /// <summary>
    /// The params parameter returns one value: the number of auxiliary color buffers.
    /// </summary>
    AuxBuffers = Constants.GL_AUX_BUFFERS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether blending is enabled. See glBlendFunc.
    /// </summary>
    Blend = Constants.GL_BLEND,

    /// <summary>
    /// The params parameter returns one value: the symbolic constant identifying the destination blend function. See glBlendFunc.
    /// </summary>
    BlendDst = Constants.GL_BLEND_DST,

    /// <summary>
    /// The params parameter returns one value: the symbolic constant identifying the source blend function. See glBlendFunc.
    /// </summary>
    BlendSrc = Constants.GL_BLEND_SRC,

    /// <summary>
    /// The params parameter returns one value: the blue bias factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    BlueBias = Constants.GL_BLUE_BIAS,

    /// <summary>
    /// The params parameter returns one value: the number of blue bitplanes in each color buffer.
    /// </summary>
    BlueBits = Constants.GL_BLUE_BITS,

    /// <summary>
    /// The params parameter returns one value: the blue scale factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    BlueScale = Constants.GL_BLUE_SCALE,

    /// <summary>
    /// The params parameter returns one value indicating the depth of the attribute stack. The initial value is zero. See glPushClientAttrib.
    /// </summary>
    ClientAttribStackDepth = Constants.GL_CLIENT_ATTRIB_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the specified clipping plane is enabled. See glClipPlane.
    /// </summary>
    ClipPlane0 = Constants.GL_CLIP_PLANE0,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the specified color array is defined. See glColorPointer.
    /// </summary>
    ColorArray = Constants.GL_COLOR_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the number of components per color in the color array. See glColorPointer.
    /// </summary>
    ColorArraySize = Constants.GL_COLOR_ARRAY_SIZE,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive colors in the color array. See glColorPointer.
    /// </summary>
    ColorArrayStride = Constants.GL_COLOR_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter returns one value, the data type of each component in the color array. See glColorPointer.
    /// </summary>
    ColorArrayType = Constants.GL_COLOR_ARRAY_TYPE,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha values used to clear the color buffers.
    /// Integer values, if requested, are linearly mapped from the internal floating-point representation such that 1.0
    /// returns the most positive representable integer value, and -1.0 returns the most negative representable
    /// integer value. See glClearColor.
    /// </summary>
    ColorClearValue = Constants.GL_COLOR_CLEAR_VALUE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether a fragment's RGBA color values are
    /// merged into the framebuffer using a logical operation. See glLogicOp.
    /// </summary>
    ColorLogicOp = Constants.GL_COLOR_LOGIC_OP,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether one or more material parameters are
    /// tracking the current color. See glColorMaterial.
    /// </summary>
    ColorMaterial = Constants.GL_COLOR_MATERIAL,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which materials have a parameter
    /// that is tracking the current color. See glColorMaterial.
    /// </summary>
    ColorMaterialFace = Constants.GL_COLOR_MATERIAL_FACE,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which material parameters are
    /// tracking the current color. See glColorMaterial.
    /// </summary>
    ColorMaterialParameter = Constants.GL_COLOR_MATERIAL_PARAMETER,

    /// <summary>
    /// The params parameter returns four Boolean values: the red, green, blue, and alpha write enables for
    /// the color buffers. See glColorMask.
    /// </summary>
    ColorWritemask = Constants.GL_COLOR_WRITEMASK,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether polygon culling is enabled. See glCullFace.
    /// </summary>
    CullFace = Constants.GL_CULL_FACE,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which polygon faces are to be culled. See glCullFace.
    /// </summary>
    CullFaceMode = Constants.GL_CULL_FACE_MODE,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha values of the current color.
    /// Integer values, if requested, are linearly mapped from the internal floating-point representation such
    /// that 1.0 returns the most positive representable integer value, and -1.0 returns the most negative
    /// representable integer value. See glColor.
    /// </summary>
    CurrentColor = Constants.GL_CURRENT_COLOR,

    /// <summary>
    /// The params parameter returns one value: the current color index. See glIndex.
    /// </summary>
    CurrentIndex = Constants.GL_CURRENT_INDEX,

    /// <summary>
    /// The params parameter returns three values: the x, y, and z values of the current normal. Integer values,
    /// if requested, are linearly mapped from the internal floating-point representation such that 1.0 returns
    /// the most positive representable integer value, and -1.0 returns the most negative representable
    /// integer value. See glNormal.
    /// </summary>
    CurrentNormal = Constants.GL_CURRENT_NORMAL,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha values of the current raster
    /// position. Integer values, if requested, are linearly mapped from the internal floating-point representation
    /// such that 1.0 returns the most positive representable integer value, and -1.0 returns the most negative
    /// representable integer value. See glRasterPos.
    /// </summary>
    CurrentRasterColor = Constants.GL_CURRENT_RASTER_COLOR,

    /// <summary>
    /// The params parameter returns one value: the distance from the eye to the current raster position. See glRasterPos.
    /// </summary>
    CurrentRasterDistance = Constants.GL_CURRENT_RASTER_DISTANCE,

    /// <summary>
    /// The params parameter returns one value: the color index of the current raster position. See glRasterPos.
    /// </summary>
    CurrentRasterIndex = Constants.GL_CURRENT_RASTER_INDEX,

    /// <summary>
    /// The params parameter returns four values: the x, y, z, and w components of the current raster position.
    /// The x, y, and z components are in window coordinates, and w is in clip coordinates. See glRasterPos.
    /// </summary>
    CurrentRasterPosition = Constants.GL_CURRENT_RASTER_POSITION,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the current raster position is valid. See glRasterPos.
    /// </summary>
    CurrentRasterPositionValid = Constants.GL_CURRENT_RASTER_POSITION_VALID,

    /// <summary>
    /// The params parameter returns four values: the s, t, r, and q current raster texture coordinates.
    /// See glRasterPos and glTexCoord.
    /// </summary>
    CurrentRasterTextureCoords = Constants.GL_CURRENT_RASTER_TEXTURE_COORDS,

    /// <summary>
    /// The params parameter returns four values: the s, t, r, and q current texture coordinates. See glTexCoord.
    /// </summary>
    CurrentTextureCoords = Constants.GL_CURRENT_TEXTURE_COORDS,

    /// <summary>
    /// The params parameter returns one value: the depth bias factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    DepthBias = Constants.GL_DEPTH_BIAS,

    /// <summary>
    /// The params parameter returns one value: the number of bitplanes in the depth buffer.
    /// </summary>
    DepthBits = Constants.GL_DEPTH_BITS,

    /// <summary>
    /// The params parameter returns one value: the value that is used to clear the depth buffer. Integer values,
    /// if requested, are linearly mapped from the internal floating-point representation such that 1.0 returns
    /// the most positive representable integer value, and -1.0 returns the most negative representable integer value.
    /// See glClearDepth.
    /// </summary>
    DepthClearValue = Constants.GL_DEPTH_CLEAR_VALUE,

    /// <summary>
    /// The params parameter returns one value: the symbolic constant that indicates the depth comparison function. See glDepthFunc.
    /// </summary>
    DepthFunc = Constants.GL_DEPTH_FUNC,

    /// <summary>
    /// The params parameter returns two values: the near and far mapping limits for the depth buffer. Integer values,
    /// if requested, are linearly mapped from the internal floating-point representation such that 1.0 returns
    /// the most positive representable integer value, and -1.0 returns the most negative representable integer value.
    /// See glDepthRange.
    /// </summary>
    DepthRange = Constants.GL_DEPTH_RANGE,

    /// <summary>
    /// The params parameter returns one value: the depth scale factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    DepthScale = Constants.GL_DEPTH_SCALE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether depth testing of fragments is enabled.
    /// See glDepthFunc and glDepthRange.
    /// </summary>
    DepthTest = Constants.GL_DEPTH_TEST,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating if the depth buffer is enabled for writing. See glDepthMask.
    /// </summary>
    DepthWritemask = Constants.GL_DEPTH_WRITEMASK,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether dithering of fragment colors and indexes is enabled.
    /// </summary>
    Dither = Constants.GL_DITHER,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether double buffering is supported.
    /// </summary>
    Doublebuffer = Constants.GL_DOUBLEBUFFER,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which buffers are being drawn to. See glDrawBuffer.
    /// </summary>
    DrawBuffer = Constants.GL_DRAW_BUFFER,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the current edge flag is true or false. See glEdgeFlag.
    /// </summary>
    EdgeFlag = Constants.GL_EDGE_FLAG,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the edge flag array is enabled. See glEdgeFlagPointer.
    /// </summary>
    EdgeFlagArray = Constants.GL_EDGE_FLAG_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive edge flags in the edge flag array. See glEdgeFlagPointer.
    /// </summary>
    EdgeFlagArrayStride = Constants.GL_EDGE_FLAG_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether fogging is enabled. See glFog.
    /// </summary>
    Fog = Constants.GL_FOG,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha components of the fog color.
    /// Integer values, if requested, are linearly mapped from the internal floating-point representation such
    /// that 1.0 returns the most positive representable integer value, and -1.0 returns the most negative
    /// representable integer value. See glFog.
    /// </summary>
    FogColor = Constants.GL_FOG_COLOR,

    /// <summary>
    /// The params parameter returns one value: the fog density parameter. See glFog.
    /// </summary>
    FogDensity = Constants.GL_FOG_DENSITY,

    /// <summary>
    /// The params parameter returns one value: the end factor for the linear fog equation. See glFog.
    /// </summary>
    FogEnd = Constants.GL_FOG_END,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the mode of the fog hint. See glHint.
    /// </summary>
    FogHint = Constants.GL_FOG_HINT,

    /// <summary>
    /// The params parameter returns one value: the fog color index. See glFog.
    /// </summary>
    FogIndex = Constants.GL_FOG_INDEX,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which fog equation is selected. See glFog.
    /// </summary>
    FogMode = Constants.GL_FOG_MODE,

    /// <summary>
    /// The params parameter returns one value: the start factor for the linear fog equation. See glFog.
    /// </summary>
    FogStart = Constants.GL_FOG_START,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating whether clockwise or counterclockwise
    /// polygon winding is treated as front-facing. See glFrontFace.
    /// </summary>
    FrontFace = Constants.GL_FRONT_FACE,

    /// <summary>
    /// The params parameter returns one value: the green bias factor used during pixel transfers.
    /// </summary>
    GreenBias = Constants.GL_GREEN_BIAS,

    /// <summary>
    /// The params parameter returns one value: the number of green bitplanes in each color buffer.
    /// </summary>
    GreenBits = Constants.GL_GREEN_BITS,

    /// <summary>
    /// The params parameter returns one value: the green scale factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    GreenScale = Constants.GL_GREEN_SCALE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the color index array is enabled. See glIndexPointer.
    /// </summary>
    IndexArray = Constants.GL_INDEX_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive color indexes in the color index array. See glIndexPointer.
    /// </summary>
    IndexArrayStride = Constants.GL_INDEX_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter returns one value, the data type of indexes in the color index array.
    /// The initial value is GL_FLOAT. See glIndexPointer.
    /// </summary>
    IndexArrayType = Constants.GL_INDEX_ARRAY_TYPE,

    /// <summary>
    /// The params parameter returns one value: the number of bitplanes in each color-index buffer.
    /// </summary>
    IndexBits = Constants.GL_INDEX_BITS,

    /// <summary>
    /// The params parameter returns one value: the color index used to clear the color-index buffers. See glClearIndex.
    /// </summary>
    IndexClearValue = Constants.GL_INDEX_CLEAR_VALUE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether a fragment's index values are
    /// merged into the framebuffer using a logical operation. See glLogicOp.
    /// </summary>
    IndexLogicOp = Constants.GL_INDEX_LOGIC_OP,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether OpenGL is
    /// in color-index mode (TRUE) or RGBA mode (FALSE).
    /// </summary>
    IndexMode = Constants.GL_INDEX_MODE,

    /// <summary>
    /// The params parameter returns one value: the offset added to color and stencil indexes during pixel transfers.
    /// See glPixelTransfer.
    /// </summary>
    IndexOffset = Constants.GL_INDEX_OFFSET,

    /// <summary>
    /// The params parameter returns one value: the amount that color and stencil indexes are shifted during
    /// pixel transfers. See glPixelTransfer.
    /// </summary>
    IndexShift = Constants.GL_INDEX_SHIFT,

    /// <summary>
    /// The params parameter returns one value: a mask indicating which bitplanes of each color-index
    /// buffer can be written. See glIndexMask.
    /// </summary>
    IndexWritemask = Constants.GL_INDEX_WRITEMASK,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the specified light is enabled.
    /// See glLight and glLightModel.
    /// </summary>
    Light0 = Constants.GL_LIGHT0,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether lighting is enabled. See glLightModel.
    /// </summary>
    Lighting = Constants.GL_LIGHTING,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha components of the ambient intensity of
    /// the entire scene. Integer values, if requested, are linearly mapped from the internal floating-point representation
    /// such that 1.0 returns the most positive representable integer value, and -1.0 returns the most negative
    /// representable integer value. See glLightModel.
    /// </summary>
    LightModelAmbient = Constants.GL_LIGHT_MODEL_AMBIENT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether specular reflection calculations treat
    /// the viewer as being local to the scene. See glLightModel.
    /// </summary>
    LightModelLocalViewer = Constants.GL_LIGHT_MODEL_LOCAL_VIEWER,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether separate materials are used
    /// to compute lighting for front-facing and back-facing polygons. See glLightModel.
    /// </summary>
    LightModelTwoSide = Constants.GL_LIGHT_MODEL_TWO_SIDE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether antialiasing of lines is enabled.
    /// See glLineWidth.
    /// </summary>
    LineSmooth = Constants.GL_LINE_SMOOTH,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the mode of the line antialiasing hint.
    /// See glHint.
    /// </summary>
    LineSmoothHint = Constants.GL_LINE_SMOOTH_HINT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether stippling of lines is enabled. See glLineStipple.
    /// </summary>
    LineStipple = Constants.GL_LINE_STIPPLE,

    /// <summary>
    /// The params parameter returns one value: the 16-bit line stipple pattern. See glLineStipple.
    /// </summary>
    LineStipplePattern = Constants.GL_LINE_STIPPLE_PATTERN,

    /// <summary>
    /// The params parameter returns one value: the line stipple repeat factor. See glLineStipple.
    /// </summary>
    LineStippleRepeat = Constants.GL_LINE_STIPPLE_REPEAT,

    /// <summary>
    /// The params parameter returns one value: the line width as specified with glLineWidth.
    /// </summary>
    LineWidth = Constants.GL_LINE_WIDTH,

    /// <summary>
    /// The params parameter returns one value: the width difference between adjacent supported widths for
    /// antialiased lines. See glLineWidth.
    /// </summary>
    LineWidthGranularity = Constants.GL_LINE_WIDTH_GRANULARITY,

    /// <summary>
    /// The params parameter returns two values: the smallest and largest supported widths for antialiased lines.
    /// See glLineWidth.
    /// </summary>
    LineWidthRange = Constants.GL_LINE_WIDTH_RANGE,

    /// <summary>
    /// The params parameter returns one value: the base offset added to all names in arrays presented to glCallLists. See glListBase.
    /// </summary>
    ListBase = Constants.GL_LIST_BASE,

    /// <summary>
    /// The params parameter returns one value: the name of the display list currently under construction.
    /// Zero is returned if no display list is currently under construction. See glNewList.
    /// </summary>
    ListIndex = Constants.GL_LIST_INDEX,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the construction mode of
    /// the display list currently being constructed. See glNewList.
    /// </summary>
    ListMode = Constants.GL_LIST_MODE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether fragment indexes are merged into
    /// the framebuffer using a logical operation. See glLogicOp.
    /// </summary>
    LogicOp = Constants.GL_LOGIC_OP,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the selected logic operational mode. See glLogicOp.
    /// </summary>
    LogicOpMode = Constants.GL_LOGIC_OP_MODE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates colors. See glMap1.
    /// </summary>
    Map1Color4 = Constants.GL_MAP1_COLOR_4,

    /// <summary>
    /// The params parameter returns two values: the endpoints of the 1-D maps grid domain. See glMapGrid.
    /// </summary>
    Map1GridDomain = Constants.GL_MAP1_GRID_DOMAIN,

    /// <summary>
    /// The params parameter returns one value: the number of partitions in the 1-D maps grid domain. See glMapGrid.
    /// </summary>
    Map1GridSegments = Constants.GL_MAP1_GRID_SEGMENTS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates color indexes. See glMap1.
    /// </summary>
    Map1Index = Constants.GL_MAP1_INDEX,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates normals. See glMap1.
    /// </summary>
    Map1Normal = Constants.GL_MAP1_NORMAL,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 1-D texture
    /// coordinates. See glMap1.
    /// </summary>
    Map1TextureCoord1 = Constants.GL_MAP1_TEXTURE_COORD_1,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 2-D texture coordinates. See glMap1.
    /// </summary>
    Map1TextureCoord2 = Constants.GL_MAP1_TEXTURE_COORD_2,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 3-D texture coordinates. See glMap1.
    /// </summary>
    Map1TextureCoord3 = Constants.GL_MAP1_TEXTURE_COORD_3,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 4-D texture coordinates. See glMap1.
    /// </summary>
    Map1TextureCoord4 = Constants.GL_MAP1_TEXTURE_COORD_4,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 3-D vertex coordinates. See glMap1.
    /// </summary>
    Map1Vertex3 = Constants.GL_MAP1_VERTEX_3,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D evaluation generates 4-D vertex coordinates. See glMap1.
    /// </summary>
    Map1Vertex4 = Constants.GL_MAP1_VERTEX_4,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates colors. See glMap2.
    /// </summary>
    Map2Color4 = Constants.GL_MAP2_COLOR_4,

    /// <summary>
    /// The params parameter returns four values: the endpoints of the 2-D maps i and j grid domains. See glMapGrid.
    /// </summary>
    Map2GridDomain = Constants.GL_MAP2_GRID_DOMAIN,

    /// <summary>
    /// The params parameter returns two values: the number of partitions in the 2-D maps i and j grid domains. See glMapGrid.
    /// </summary>
    Map2GridSegments = Constants.GL_MAP2_GRID_SEGMENTS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates color indexes. See glMap2.
    /// </summary>
    Map2Index = Constants.GL_MAP2_INDEX,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates normals. See glMap2.
    /// </summary>
    Map2Normal = Constants.GL_MAP2_NORMAL,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 1-D texture coordinates. See glMap2.
    /// </summary>
    Map2TextureCoord1 = Constants.GL_MAP2_TEXTURE_COORD_1,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 2-D texture coordinates. See glMap2.
    /// </summary>
    Map2TextureCoord2 = Constants.GL_MAP2_TEXTURE_COORD_2,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 3-D texture coordinates. See glMap2.
    /// </summary>
    Map2TextureCoord3 = Constants.GL_MAP2_TEXTURE_COORD_3,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 4-D texture coordinates. See glMap2.
    /// </summary>
    Map2TextureCoord4 = Constants.GL_MAP2_TEXTURE_COORD_4,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 3-D vertex coordinates. See glMap2.
    /// </summary>
    Map2Vertex3 = Constants.GL_MAP2_VERTEX_3,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D evaluation generates 4-D vertex coordinates. See glMap2.
    /// </summary>
    Map2Vertex4 = Constants.GL_MAP2_VERTEX_4,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether colors and color indexes are to be replaced by table lookup during pixel transfers. See glPixelTransfer.
    /// </summary>
    MapColor = Constants.GL_MAP_COLOR,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether stencil indexes are to be replaced by table lookup during pixel transfers. See glPixelTransfer.
    /// </summary>
    MapStencil = Constants.GL_MAP_STENCIL,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which matrix stack is currently the target of all matrix operations. See glMatrixMode.
    /// </summary>
    MatrixMode = Constants.GL_MATRIX_MODE,

    /// <summary>
    /// The params parameter returns one value indicating the maximum supported depth of the client attribute stack. See glPushClientAttrib.
    /// </summary>
    MaxClientAttribStackDepth = Constants.GL_MAX_CLIENT_ATTRIB_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the maximum supported depth of the attribute stack. See glPushAttrib.
    /// </summary>
    MaxAttribStackDepth = Constants.GL_MAX_ATTRIB_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the maximum number of application-defined clipping planes. See glClipPlane.
    /// </summary>
    MaxClipPlanes = Constants.GL_MAX_CLIP_PLANES,

    /// <summary>
    /// The params parameter returns one value: the maximum equation order supported by 1-D and 2-D evaluators. See glMap1 and glMap2.
    /// </summary>
    MaxEvalOrder = Constants.GL_MAX_EVAL_ORDER,

    /// <summary>
    /// The params parameter returns one value: the maximum number of lights. See glLight.
    /// </summary>
    MaxLights = Constants.GL_MAX_LIGHTS,

    /// <summary>
    /// The params parameter returns one value: the maximum recursion depth allowed during display-list traversal. See glCallList.
    /// </summary>
    MaxListNesting = Constants.GL_MAX_LIST_NESTING,

    /// <summary>
    /// The params parameter returns one value: the maximum supported depth of the modelview matrix stack. See glPushMatrix.
    /// </summary>
    MaxModelviewStackDepth = Constants.GL_MAX_MODELVIEW_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the maximum supported depth of the selection name stack. See glPushName.
    /// </summary>
    MaxNameStackDepth = Constants.GL_MAX_NAME_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the maximum supported size of a glPixelMap lookup table.
    /// </summary>
    MaxPixelMapTable = Constants.GL_MAX_PIXEL_MAP_TABLE,

    /// <summary>
    /// The params parameter returns one value: the maximum supported depth of the projection matrix stack. See glPushMatrix.
    /// </summary>
    MaxProjectionStackDepth = Constants.GL_MAX_PROJECTION_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the maximum width or height of any texture image (without borders). See glTexImage1D and glTexImage2D.
    /// </summary>
    MaxTextureSize = Constants.GL_MAX_TEXTURE_SIZE,

    /// <summary>
    /// The params parameter returns one value: the maximum supported depth of the texture matrix stack. See glPushMatrix.
    /// </summary>
    MaxTextureStackDepth = Constants.GL_MAX_TEXTURE_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns two values: the maximum supported width and height of the viewport. See glViewport.
    /// </summary>
    MaxViewportDims = Constants.GL_MAX_VIEWPORT_DIMS,

    /// <summary>
    /// The params parameter returns 16 values: the modelview matrix on the top of the modelview matrix stack. See glPushMatrix.
    /// </summary>
    ModelviewMatrix = Constants.GL_MODELVIEW_MATRIX,

    /// <summary>
    /// The params parameter returns one value: the number of matrices on the modelview matrix stack. See glPushMatrix.
    /// </summary>
    ModelviewStackDepth = Constants.GL_MODELVIEW_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the number of names on the selection name stack. See glPushName.
    /// </summary>
    NameStackDepth = Constants.GL_NAME_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns a single Boolean value, indicating whether the normal array is enabled. See glNormalPointer.
    /// </summary>
    NormalArray = Constants.GL_NORMAL_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive normals in the normal array. See glNormalPointer.
    /// </summary>
    NormalArrayStride = Constants.GL_NORMAL_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter returns one value, the data type of each coordinate in the normal array. See glNormalPointer.
    /// </summary>
    NormalArrayType = Constants.GL_NORMAL_ARRAY_TYPE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether normals are automatically scaled to unit length after they have been transformed to eye coordinates. See glNormal.
    /// </summary>
    Normalize = Constants.GL_NORMALIZE,

    /// <summary>
    /// The params parameter returns one value: the byte alignment used for writing pixel data to memory. See glPixelStore.
    /// </summary>
    PackAlignment = Constants.GL_PACK_ALIGNMENT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether single-bit pixels being written to memory are written first to the least significant bit of each unsigned byte. See glPixelStore.
    /// </summary>
    PackLsbFirst = Constants.GL_PACK_LSB_FIRST,

    /// <summary>
    /// The params parameter returns one value: the row length used for writing pixel data to memory. See glPixelStore.
    /// </summary>
    PackRowLength = Constants.GL_PACK_ROW_LENGTH,

    /// <summary>
    /// The params parameter returns one value: the number of pixel locations skipped before the first pixel is written into memory. See glPixelStore.
    /// </summary>
    PackSkipPixels = Constants.GL_PACK_SKIP_PIXELS,

    /// <summary>
    /// The params parameter returns one value: the number of rows of pixel locations skipped before the first pixel is written into memory. See glPixelStore.
    /// </summary>
    PackSkipRows = Constants.GL_PACK_SKIP_ROWS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the bytes of 2-byte and 4-byte pixel indexes and components are swapped before being written to memory. See glPixelStore.
    /// </summary>
    PackSwapBytes = Constants.GL_PACK_SWAP_BYTES,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the mode of the perspective correction hint. See glHint.
    /// </summary>
    PerspectiveCorrectionHint = Constants.GL_PERSPECTIVE_CORRECTION_HINT,

    /// <summary>
    /// The params parameter returns one value: the size of the alpha-to-alpha pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapAToASize = Constants.GL_PIXEL_MAP_A_TO_A_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the blue-to-blue pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapBToBSize = Constants.GL_PIXEL_MAP_B_TO_B_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the green-to-green pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapGToGSize = Constants.GL_PIXEL_MAP_G_TO_G_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the index-to-alpha pixel translation table. See glPixelMap.
    /// </summary>
    PixelMapIToASize = Constants.GL_PIXEL_MAP_I_TO_A_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the index-to-blue pixel translation table. See glPixelMap.
    /// </summary>
    PixelMapIToBSize = Constants.GL_PIXEL_MAP_I_TO_B_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the index-to-green pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapIToGSize = Constants.GL_PIXEL_MAP_I_TO_G_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the index-to-index pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapIToISize = Constants.GL_PIXEL_MAP_I_TO_I_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the index-to-red pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapIToRSize = Constants.GL_PIXEL_MAP_I_TO_R_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the red-to-red pixel-translation table. See glPixelMap.
    /// </summary>
    PixelMapRToRSize = Constants.GL_PIXEL_MAP_R_TO_R_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size of the stencil-to-stencil pixel translation table. See glPixelMap.
    /// </summary>
    PixelMapSToSSize = Constants.GL_PIXEL_MAP_S_TO_S_SIZE,

    /// <summary>
    /// The params parameter returns one value: the point size as specified by glPointSize.
    /// </summary>
    PointSize = Constants.GL_POINT_SIZE,

    /// <summary>
    /// The params parameter returns one value: the size difference between adjacent supported sizes for antialiased points. See glPointSize.
    /// </summary>
    PointSizeGranularity = Constants.GL_POINT_SIZE_GRANULARITY,

    /// <summary>
    /// The params parameter returns two values: the smallest and largest supported sizes for antialiased points. See glPointSize.
    /// </summary>
    PointSizeRange = Constants.GL_POINT_SIZE_RANGE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether antialiasing of points is enabled. See glPointSize.
    /// </summary>
    PointSmooth = Constants.GL_POINT_SMOOTH,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the mode of the point antialiasing hint. See glHint.
    /// </summary>
    PointSmoothHint = Constants.GL_POINT_SMOOTH_HINT,

    /// <summary>
    /// The params parameter returns two values: symbolic constants indicating whether front-facing and back-facing
    /// polygons are rasterized as points, lines, or filled polygons. See glPolygonMode.
    /// </summary>
    PolygonMode = Constants.GL_POLYGON_MODE,

    /// <summary>
    /// The params parameter returns one value, the scaling factor used to determine the variable offset that is
    /// added to the depth value of each fragment generated when a polygon is rasterized. See glPolygonOffset.
    /// </summary>
    PolygonOffsetFactor = Constants.GL_POLYGON_OFFSET_FACTOR,

    /// <summary>
    /// The params parameter returns one value. This value is multiplied by an implementation-specific value and then
    /// added to the depth value of each fragment generated when a polygon is rasterized. See glPolygonOffset.
    /// </summary>
    PolygonOffsetUnits = Constants.GL_POLYGON_OFFSET_UNITS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether polygon offset is enabled for
    /// polygons in fill mode. See glPolygonOffset.
    /// </summary>
    PolygonOffsetFill = Constants.GL_POLYGON_OFFSET_FILL,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether polygon offset is enabled for
    /// polygons in line mode. See glPolygonOffset.
    /// </summary>
    PolygonOffsetLine = Constants.GL_POLYGON_OFFSET_LINE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether polygon offset is enabled for
    /// polygons in point mode. See glPolygonOffset.
    /// </summary>
    PolygonOffsetPoint = Constants.GL_POLYGON_OFFSET_POINT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether antialiasing of polygons is enabled.
    /// See glPolygonMode.
    /// </summary>
    PolygonSmooth = Constants.GL_POLYGON_SMOOTH,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating the mode of the polygon antialiasing hint.
    /// See glHint.
    /// </summary>
    PolygonSmoothHint = Constants.GL_POLYGON_SMOOTH_HINT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether stippling of polygons is enabled.
    /// See glPolygonStipple.
    /// </summary>
    PolygonStipple = Constants.GL_POLYGON_STIPPLE,

    /// <summary>
    /// The params parameter returns 16 values: the projection matrix on the top of the projection matrix stack. See glPushMatrix.
    /// </summary>
    ProjectionMatrix = Constants.GL_PROJECTION_MATRIX,

    /// <summary>
    /// The params parameter returns one value: the number of matrices on the projection matrix stack. See glPushMatrix.
    /// </summary>
    ProjectionStackDepth = Constants.GL_PROJECTION_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which color buffer is selected for reading. See glReadPixels and glAccum.
    /// </summary>
    ReadBuffer = Constants.GL_READ_BUFFER,

    /// <summary>
    /// The params parameter returns one value: the red bias factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    RedBias = Constants.GL_RED_BIAS,

    /// <summary>
    /// The params parameter returns one value: the number of red bitplanes in each color buffer.
    /// </summary>
    RedBits = Constants.GL_RED_BITS,

    /// <summary>
    /// The params parameter returns one value: the red scale factor used during pixel transfers. See glPixelTransfer.
    /// </summary>
    RedScale = Constants.GL_RED_SCALE,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating whether OpenGL is in render, select, or feedback mode. See glRenderMode.
    /// </summary>
    RenderMode = Constants.GL_RENDER_MODE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether OpenGL is in RGBA mode (TRUE) or color-index mode (FALSE). See glColor.
    /// </summary>
    RgbaMode = Constants.GL_RGBA_MODE,

    /// <summary>
    /// The params parameter returns four values: the x and y window coordinates of the scissor box, followed by its width and height. See glScissor.
    /// </summary>
    ScissorBox = Constants.GL_SCISSOR_BOX,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether scissoring is enabled. See glScissor.
    /// </summary>
    ScissorTest = Constants.GL_SCISSOR_TEST,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating whether the shading mode is flat or smooth. See glShadeModel.
    /// </summary>
    ShadeModel = Constants.GL_SHADE_MODEL,

    /// <summary>
    /// The params parameter returns one value: the number of bitplanes in the stencil buffer.
    /// </summary>
    StencilBits = Constants.GL_STENCIL_BITS,

    /// <summary>
    /// The params parameter returns one value: the index to which the stencil bitplanes are cleared. See glClearStencil.
    /// </summary>
    StencilClearValue = Constants.GL_STENCIL_CLEAR_VALUE,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating what action is taken when the stencil test fails. See glStencilOp.
    /// </summary>
    StencilFail = Constants.GL_STENCIL_FAIL,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating what function is used to compare the stencil reference value with the stencil buffer value. See glStencilFunc.
    /// </summary>
    StencilFunc = Constants.GL_STENCIL_FUNC,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating what action is taken when the stencil test passes, but the depth test fails. See glStencilOp.
    /// </summary>
    StencilPassDepthFail = Constants.GL_STENCIL_PASS_DEPTH_FAIL,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating what action is taken when the stencil test passes and the depth test passes. See glStencilOp.
    /// </summary>
    StencilPassDepthPass = Constants.GL_STENCIL_PASS_DEPTH_PASS,

    /// <summary>
    /// The params parameter returns one value: the reference value that is compared with the contents of the stencil buffer. See glStencilFunc.
    /// </summary>
    StencilRef = Constants.GL_STENCIL_REF,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether stencil testing of fragments is enabled. See glStencilFunc and glStencilOp.
    /// </summary>
    StencilTest = Constants.GL_STENCIL_TEST,

    /// <summary>
    /// The params parameter returns one value: the mask that is used to mask both the stencil reference value and the stencil buffer value before they are compared. See glStencilFunc.
    /// </summary>
    StencilValueMask = Constants.GL_STENCIL_VALUE_MASK,

    /// <summary>
    /// The params parameter returns one value: the mask that controls writing of the stencil bitplanes. See glStencilMask.
    /// </summary>
    StencilWritemask = Constants.GL_STENCIL_WRITEMASK,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether stereo buffers (left and right) are supported.
    /// </summary>
    Stereo = Constants.GL_STEREO,

    /// <summary>
    /// The params parameter returns one value: an estimate of the number of bits of subpixel resolution that are used to position rasterized geometry in window coordinates.
    /// </summary>
    SubpixelBits = Constants.GL_SUBPIXEL_BITS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 1-D texture mapping is enabled. See glTexImage1D.
    /// </summary>
    Texture1D = Constants.GL_TEXTURE_1D,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether 2-D texture mapping is enabled. See glTexImage2D.
    /// </summary>
    Texture2D = Constants.GL_TEXTURE_2D,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the texture coordinate array is enabled. See glTexCoordPointer.
    /// </summary>
    TextureCoordArray = Constants.GL_TEXTURE_COORD_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the number of coordinates per element in the texture coordinate array. See glTexCoordPointer.
    /// </summary>
    TextureCoordArraySize = Constants.GL_TEXTURE_COORD_ARRAY_SIZE,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive elements in the texture coordinate array. See glTexCoordPointer.
    /// </summary>
    TextureCoordArrayStride = Constants.GL_TEXTURE_COORD_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter params returns one value, the data type of the coordinates in the texture coordinate array. See glTexCoordPointer.
    /// </summary>
    TextureCoordArrayType = Constants.GL_TEXTURE_COORD_ARRAY_TYPE,

    /// <summary>
    /// The params parameter returns four values: the red, green, blue, and alpha values of the texture environment color.
    /// Integer values, if requested, are linearly mapped from the internal floating-point representation such
    /// that 1.0 returns the most positive representable integer value, and 1.0 returns the most negative representable
    /// integer value. See glTexEnv.
    /// </summary>
    TextureEnvColor = Constants.GL_TEXTURE_ENV_COLOR,

    /// <summary>
    /// The params parameter returns one value: a symbolic constant indicating which texture environment function is currently selected. See glTexEnv.
    /// </summary>
    TextureEnvMode = Constants.GL_TEXTURE_ENV_MODE,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether automatic generation of the Q texture coordinate is enabled. See glTexGen.
    /// </summary>
    TextureGenQ = Constants.GL_TEXTURE_GEN_Q,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether automatic generation of the R texture coordinate is enabled. See glTexGen.
    /// </summary>
    TextureGenR = Constants.GL_TEXTURE_GEN_R,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether automatic generation of the S texture coordinate is enabled. See glTexGen.
    /// </summary>
    TextureGenS = Constants.GL_TEXTURE_GEN_S,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether automatic generation of the T texture coordinate is enabled. See glTexGen.
    /// </summary>
    TextureGenT = Constants.GL_TEXTURE_GEN_T,

    /// <summary>
    /// The params parameter returns 16 values: the texture matrix on the top of the texture matrix stack. See glPushMatrix.
    /// </summary>
    TextureMatrix = Constants.GL_TEXTURE_MATRIX,

    /// <summary>
    /// The params parameter returns one value: the number of matrices on the texture matrix stack. See glPushMatrix.
    /// </summary>
    TextureStackDepth = Constants.GL_TEXTURE_STACK_DEPTH,

    /// <summary>
    /// The params parameter returns one value: the byte alignment used for reading pixel data from memory. See glPixelStore.
    /// </summary>
    UnpackAlignment = Constants.GL_UNPACK_ALIGNMENT,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether single-bit pixels being read from memory are read first from the least significant bit of each unsigned byte. See glPixelStore.
    /// </summary>
    UnpackLsbFirst = Constants.GL_UNPACK_LSB_FIRST,

    /// <summary>
    /// The params parameter returns one value: the row length used for reading pixel data from memory. See glPixelStore.
    /// </summary>
    UnpackRowLength = Constants.GL_UNPACK_ROW_LENGTH,

    /// <summary>
    /// The params parameter returns one value: the number of pixel locations skipped before the first pixel is read from memory. See glPixelStore.
    /// </summary>
    UnpackSkipPixels = Constants.GL_UNPACK_SKIP_PIXELS,

    /// <summary>
    /// The params parameter returns one value: the number of rows of pixel locations skipped before the first pixel is read from memory. See glPixelStore.
    /// </summary>
    UnpackSkipRows = Constants.GL_UNPACK_SKIP_ROWS,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the bytes of 2-byte and 4-byte pixel indexes and components are swapped after being read from memory. See glPixelStore.
    /// </summary>
    UnpackSwapBytes = Constants.GL_UNPACK_SWAP_BYTES,

    /// <summary>
    /// The params parameter returns a single Boolean value indicating whether the vertex array is enabled. See glVertexPointer.
    /// </summary>
    VertexArray = Constants.GL_VERTEX_ARRAY,

    /// <summary>
    /// The params parameter returns one value, the number of coordinates per vertex in the vertex array. See glVertexPointer.
    /// </summary>
    VertexArraySize = Constants.GL_VERTEX_ARRAY_SIZE,

    /// <summary>
    /// The params parameter returns one value, the byte offset between consecutive vertexes in the vertex array. See glVertexPointer.
    /// </summary>
    VertexArrayStride = Constants.GL_VERTEX_ARRAY_STRIDE,

    /// <summary>
    /// The params parameter returns one value, the data type of each coordinate in the vertex array. See glVertexPointer.
    /// </summary>
    VertexArrayType = Constants.GL_VERTEX_ARRAY_TYPE,

    /// <summary>
    /// The params parameter returns four values: the x and y window coordinates of the viewport, followed by its width and height. See glViewport.
    /// </summary>
    Viewport = Constants.GL_VIEWPORT,

    /// <summary>
    /// The params parameter returns one value: the x pixel zoom factor. See glPixelZoom.
    /// </summary>
    ZoomX = Constants.GL_ZOOM_X,

    /// <summary>
    /// The params parameter returns one value: the y pixel zoom factor. See glPixelZoom.
    /// </summary>
    ZoomY = Constants.GL_ZOOM_Y,
}