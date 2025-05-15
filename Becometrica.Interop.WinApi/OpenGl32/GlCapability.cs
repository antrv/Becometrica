namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlCapability: uint
{
    /// <summary>
    /// If enabled, do alpha testing. See <see cref="Opengl32Lib.glAlphaFunc"/>.
    /// </summary>
    AlphaTest = Constants.GL_ALPHA_TEST,

    /// <summary>
    /// If enabled, compute surface normal vectors analytically when either GL_MAP2_VERTEX_3 or
    /// GL_MAP2_VERTEX_4 has generated vertices. See glMap2.
    /// </summary>
    AutoNormal = Constants.GL_AUTO_NORMAL,

    /// <summary>
    /// If enabled, blend the incoming RGBA color values with the values in the color buffers. See glBlendFunc.
    /// </summary>
    Blend = Constants.GL_BLEND,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 0. See glClipPlane.
    /// </summary>
    ClipPlane0 = Constants.GL_CLIP_PLANE0,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 1. See glClipPlane.
    /// </summary>
    ClipPlane1 = Constants.GL_CLIP_PLANE1,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 2. See glClipPlane.
    /// </summary>
    ClipPlane2 = Constants.GL_CLIP_PLANE2,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 3. See glClipPlane.
    /// </summary>
    ClipPlane3 = Constants.GL_CLIP_PLANE3,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 4. See glClipPlane.
    /// </summary>
    ClipPlane4 = Constants.GL_CLIP_PLANE4,

    /// <summary>
    /// If enabled, clip geometry against user-defined clipping plane 5. See glClipPlane.
    /// </summary>
    ClipPlane5 = Constants.GL_CLIP_PLANE5,

    /// <summary>
    /// If enabled, apply the current logical operation to the incoming RGBA color and color buffer values. See glLogicOp.
    /// </summary>
    ColorLogicOp = Constants.GL_COLOR_LOGIC_OP,

    /// <summary>
    /// If enabled, have one or more material parameters track the current color. See glColorMaterial.
    /// </summary>
    ColorMaterial = Constants.GL_COLOR_MATERIAL,

    /// <summary>
    /// If enabled, cull polygons based on their winding in window coordinates. See glCullFace.
    /// </summary>
    CullFace = Constants.GL_CULL_FACE,

    /// <summary>
    /// If enabled, do depth comparisons and update the depth buffer. See glDepthFunc and glDepthRange.
    /// </summary>
    DepthTest = Constants.GL_DEPTH_TEST,

    /// <summary>
    /// If enabled, dither color components or indexes before they are written to the color buffer.
    /// </summary>
    Dither = Constants.GL_DITHER,

    /// <summary>
    /// If enabled, blend a fog color into the post-texturing color. See glFog.
    /// </summary>
    Fog = Constants.GL_FOG,

    /// <summary>
    /// If enabled, apply the current logical operation to the incoming index and color buffer indices. See glLogicOp.
    /// </summary>
    IndexLogicOp = Constants.GL_INDEX_LOGIC_OP,

    /// <summary>
    /// If enabled, include light 0 in the evaluation of the lighting equation. See glLightModel and glLight.
    /// </summary>
    Light0 = Constants.GL_LIGHT0,

    /// <summary>
    /// If enabled, use the current lighting parameters to compute the vertex color or index. If disabled,
    /// associate the current color or index with each vertex. See glMaterial, glLightModel, and glLight.
    /// </summary>
    Lighting = Constants.GL_LIGHTING,

    /// <summary>
    /// If enabled, draw lines with correct filtering. If disabled, draw aliased lines. See glLineWidth.
    /// </summary>
    LineSmooth = Constants.GL_LINE_SMOOTH,

    /// <summary>
    /// If enabled, use the current line stipple pattern when drawing lines. See glLineStipple.
    /// </summary>
    LineStipple = Constants.GL_LINE_STIPPLE,

    /// <summary>
    /// If enabled, apply the currently selected logical operation to the incoming and color-buffer indexes. See glLogicOp.
    /// </summary>
    LogicOp = Constants.GL_LOGIC_OP,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate RGBA values. See also glMap1.
    /// </summary>
    Map1Color4 = Constants.GL_MAP1_COLOR_4,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate color indexes. See also glMap1.
    /// </summary>
    Map1Index = Constants.GL_MAP1_INDEX,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate normals. See also glMap1.
    /// </summary>
    Map1Normal = Constants.GL_MAP1_NORMAL,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s texture coordinates. See also glMap1.
    /// </summary>
    Map1TextureCoord1 = Constants.GL_MAP1_TEXTURE_COORD_1,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s and t texture coordinates. See also glMap1.
    /// </summary>
    Map1TextureCoord2 = Constants.GL_MAP1_TEXTURE_COORD_2,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s, t, and r texture coordinates. See also glMap1.
    /// </summary>
    Map1TextureCoord3 = Constants.GL_MAP1_TEXTURE_COORD_3,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s, t, r, and q texture coordinates. See also glMap1.
    /// </summary>
    Map1TextureCoord4 = Constants.GL_MAP1_TEXTURE_COORD_4,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate x, y, and z vertex coordinates. See also glMap1.
    /// </summary>
    Map1Vertex3 = Constants.GL_MAP1_VERTEX_3,

    /// <summary>
    /// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate homogeneous x, y, z, and w vertex
    /// coordinates. See also glMap1.
    /// </summary>
    Map1Vertex4 = Constants.GL_MAP1_VERTEX_4,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate RGBA values. See also glMap2.
    /// </summary>
    Map2Color4 = Constants.GL_MAP2_COLOR_4,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate color indexes. See also glMap2.
    /// </summary>
    Map2Index = Constants.GL_MAP2_INDEX,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate normals. See also glMap2.
    /// </summary>
    Map2Normal = Constants.GL_MAP2_NORMAL,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s texture coordinates. See also glMap2.
    /// </summary>
    Map2TextureCoord1 = Constants.GL_MAP2_TEXTURE_COORD_1,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s and t texture coordinates. See also glMap2.
    /// </summary>
    Map2TextureCoord2 = Constants.GL_MAP2_TEXTURE_COORD_2,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s, t, and r texture coordinates. See also glMap2.
    /// </summary>
    Map2TextureCoord3 = Constants.GL_MAP2_TEXTURE_COORD_3,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s, t, r, and q texture coordinates. See also glMap2.
    /// </summary>
    Map2TextureCoord4 = Constants.GL_MAP2_TEXTURE_COORD_4,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate x, y, and z vertex coordinates. See also glMap2.
    /// </summary>
    Map2Vertex3 = Constants.GL_MAP2_VERTEX_3,

    /// <summary>
    /// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate homogeneous x, y, z, and w vertex coordinates. See also glMap2.
    /// </summary>
    Map2Vertex4 = Constants.GL_MAP2_VERTEX_4,

    /// <summary>
    /// If enabled, normal vectors specified with glNormal are scaled to unit length after transformation. See glNormal.
    /// </summary>
    Normalize = Constants.GL_NORMALIZE,

    /// <summary>
    /// If enabled, draw points with proper filtering. If disabled, draw aliased points. See glPointSize.
    /// </summary>
    PointSmooth = Constants.GL_POINT_SMOOTH,

    /// <summary>
    /// If enabled, and if the polygon is rendered in GL_FILL mode, an offset is added to depth values of
    /// a polygon's fragments before the depth comparison is performed. See glPolygonOffset.
    /// </summary>
    PolygonOffsetFill = Constants.GL_POLYGON_OFFSET_FILL,

    /// <summary>
    /// If enabled, and if the polygon is rendered in GL_LINE mode, an offset is added to depth values of
    /// a polygon's fragments before the depth comparison is performed. See glPolygonOffset.
    /// </summary>
    PolygonOffsetLine = Constants.GL_POLYGON_OFFSET_LINE,

    /// <summary>
    /// If enabled, an offset is added to depth values of a polygon's fragments before the depth comparison
    /// is performed, if the polygon is rendered in GL_POINT mode. See glPolygonOffset.
    /// </summary>
    PolygonOffsetPoint = Constants.GL_POLYGON_OFFSET_POINT,

    /// <summary>
    /// If enabled, draw polygons with proper filtering. If disabled, draw aliased polygons. See glPolygonMode.
    /// </summary>
    PolygonSmooth = Constants.GL_POLYGON_SMOOTH,

    /// <summary>
    /// If enabled, use the current polygon stipple pattern when rendering polygons. See glPolygonStipple.
    /// </summary>
    PolygonStipple = Constants.GL_POLYGON_STIPPLE,

    /// <summary>
    /// If enabled, discard fragments that are outside the scissor rectangle. See glScissor.
    /// </summary>
    ScissorTest = Constants.GL_SCISSOR_TEST,

    /// <summary>
    /// If enabled, do stencil testing and update the stencil buffer. See glStencilFunc and glStencilOp.
    /// </summary>
    StencilTest = Constants.GL_STENCIL_TEST,

    /// <summary>
    /// If enabled, one-dimensional texturing is performed (unless two-dimensional texturing is also enabled). See glTexImage1D.
    /// </summary>
    Texture1D = Constants.GL_TEXTURE_1D,

    /// <summary>
    /// If enabled, two-dimensional texturing is performed. See glTexImage2D.
    /// </summary>
    Texture2D = Constants.GL_TEXTURE_2D,

    /// <summary>
    /// If enabled, the q texture coordinate is computed using the texture-generation function defined with glTexGen. Otherwise, the current q texture coordinate is used.
    /// </summary>
    TextureGenQ = Constants.GL_TEXTURE_GEN_Q,

    /// <summary>
    /// If enabled, the r texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current r texture coordinate is used.
    /// </summary>
    TextureGenR = Constants.GL_TEXTURE_GEN_R,

    /// <summary>
    /// If enabled, the s texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current s texture coordinate is used.
    /// </summary>
    TextureGenS = Constants.GL_TEXTURE_GEN_S,

    /// <summary>
    /// If enabled, the t texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current t texture coordinate is used.}
    /// </summary>
    TextureGenT = Constants.GL_TEXTURE_GEN_T,
}