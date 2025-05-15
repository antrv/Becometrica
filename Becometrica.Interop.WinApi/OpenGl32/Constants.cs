namespace Becometrica.Interop.WinApi.Opengl32;

internal static class Constants
{
    /* Version */
    internal const uint GL_VERSION_1_1 = 1;

    /* AccumOp */
    internal const uint GL_ACCUM = 0x0100;
    internal const uint GL_LOAD = 0x0101;
    internal const uint GL_RETURN = 0x0102;
    internal const uint GL_MULT = 0x0103;
    internal const uint GL_ADD = 0x0104;

    /* AlphaFunction */
    internal const uint GL_NEVER = 0x0200;
    internal const uint GL_LESS = 0x0201;
    internal const uint GL_EQUAL = 0x0202;
    internal const uint GL_LEQUAL = 0x0203;
    internal const uint GL_GREATER = 0x0204;
    internal const uint GL_NOTEQUAL = 0x0205;
    internal const uint GL_GEQUAL = 0x0206;
    internal const uint GL_ALWAYS = 0x0207;

    /* AttribMask */
    internal const uint GL_CURRENT_BIT = 0x00000001;
    internal const uint GL_POINT_BIT = 0x00000002;
    internal const uint GL_LINE_BIT = 0x00000004;
    internal const uint GL_POLYGON_BIT = 0x00000008;
    internal const uint GL_POLYGON_STIPPLE_BIT = 0x00000010;
    internal const uint GL_PIXEL_MODE_BIT = 0x00000020;
    internal const uint GL_LIGHTING_BIT = 0x00000040;
    internal const uint GL_FOG_BIT = 0x00000080;
    internal const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
    internal const uint GL_ACCUM_BUFFER_BIT = 0x00000200;
    internal const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
    internal const uint GL_VIEWPORT_BIT = 0x00000800;
    internal const uint GL_TRANSFORM_BIT = 0x00001000;
    internal const uint GL_ENABLE_BIT = 0x00002000;
    internal const uint GL_COLOR_BUFFER_BIT = 0x00004000;
    internal const uint GL_HINT_BIT = 0x00008000;
    internal const uint GL_EVAL_BIT = 0x00010000;
    internal const uint GL_LIST_BIT = 0x00020000;
    internal const uint GL_TEXTURE_BIT = 0x00040000;
    internal const uint GL_SCISSOR_BIT = 0x00080000;
    internal const uint GL_ALL_ATTRIB_BITS = 0x000fffff;

    /* BeginMode */
    internal const uint GL_POINTS = 0x0000;
    internal const uint GL_LINES = 0x0001;
    internal const uint GL_LINE_LOOP = 0x0002;
    internal const uint GL_LINE_STRIP = 0x0003;
    internal const uint GL_TRIANGLES = 0x0004;
    internal const uint GL_TRIANGLE_STRIP = 0x0005;
    internal const uint GL_TRIANGLE_FAN = 0x0006;
    internal const uint GL_QUADS = 0x0007;
    internal const uint GL_QUAD_STRIP = 0x0008;
    internal const uint GL_POLYGON = 0x0009;

    /* BlendingFactorDest */
    internal const uint GL_ZERO = 0;
    internal const uint GL_ONE = 1;
    internal const uint GL_SRC_COLOR = 0x0300;
    internal const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
    internal const uint GL_SRC_ALPHA = 0x0302;
    internal const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
    internal const uint GL_DST_ALPHA = 0x0304;
    internal const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;

    /* BlendingFactorSrc */
    /*      GL_ZERO */
    /*      GL_ONE */
    internal const uint GL_DST_COLOR = 0x0306;
    internal const uint GL_ONE_MINUS_DST_COLOR = 0x0307;

    internal const uint GL_SRC_ALPHA_SATURATE = 0x0308;
    /*      GL_SRC_ALPHA */
    /*      GL_ONE_MINUS_SRC_ALPHA */
    /*      GL_DST_ALPHA */
    /*      GL_ONE_MINUS_DST_ALPHA */

    /* Boolean */
    internal const uint GL_TRUE = 1;
    internal const uint GL_FALSE = 0;

    /* ClearBufferMask */
    /*      GL_COLOR_BUFFER_BIT */
    /*      GL_ACCUM_BUFFER_BIT */
    /*      GL_STENCIL_BUFFER_BIT */
    /*      GL_DEPTH_BUFFER_BIT */

    /* ClientArrayType */
    /*      GL_VERTEX_ARRAY */
    /*      GL_NORMAL_ARRAY */
    /*      GL_COLOR_ARRAY */
    /*      GL_INDEX_ARRAY */
    /*      GL_TEXTURE_COORD_ARRAY */
    /*      GL_EDGE_FLAG_ARRAY */

    /* ClipPlaneName */
    internal const uint GL_CLIP_PLANE0 = 0x3000;
    internal const uint GL_CLIP_PLANE1 = 0x3001;
    internal const uint GL_CLIP_PLANE2 = 0x3002;
    internal const uint GL_CLIP_PLANE3 = 0x3003;
    internal const uint GL_CLIP_PLANE4 = 0x3004;
    internal const uint GL_CLIP_PLANE5 = 0x3005;

    /* ColorMaterialFace */
    /*      GL_FRONT */
    /*      GL_BACK */
    /*      GL_FRONT_AND_BACK */

    /* ColorMaterialParameter */
    /*      GL_AMBIENT */
    /*      GL_DIFFUSE */
    /*      GL_SPECULAR */
    /*      GL_EMISSION */
    /*      GL_AMBIENT_AND_DIFFUSE */

    /* ColorPointerType */
    /*      GL_BYTE */
    /*      GL_UNSIGNED_BYTE */
    /*      GL_SHORT */
    /*      GL_UNSIGNED_SHORT */
    /*      GL_INT */
    /*      GL_UNSIGNED_INT */
    /*      GL_FLOAT */
    /*      GL_DOUBLE */

    /* CullFaceMode */
    /*      GL_FRONT */
    /*      GL_BACK */
    /*      GL_FRONT_AND_BACK */

    /* DataType */
    internal const uint GL_BYTE = 0x1400;
    internal const uint GL_UNSIGNED_BYTE = 0x1401;
    internal const uint GL_SHORT = 0x1402;
    internal const uint GL_UNSIGNED_SHORT = 0x1403;
    internal const uint GL_INT = 0x1404;
    internal const uint GL_UNSIGNED_INT = 0x1405;
    internal const uint GL_FLOAT = 0x1406;
    internal const uint GL_2_BYTES = 0x1407;
    internal const uint GL_3_BYTES = 0x1408;
    internal const uint GL_4_BYTES = 0x1409;
    internal const uint GL_DOUBLE = 0x140A;

    /* DepthFunction */
    /*      GL_NEVER */
    /*      GL_LESS */
    /*      GL_EQUAL */
    /*      GL_LEQUAL */
    /*      GL_GREATER */
    /*      GL_NOTEQUAL */
    /*      GL_GEQUAL */
    /*      GL_ALWAYS */

    /* DrawBufferMode */
    internal const uint GL_NONE = 0;
    internal const uint GL_FRONT_LEFT = 0x0400;
    internal const uint GL_FRONT_RIGHT = 0x0401;
    internal const uint GL_BACK_LEFT = 0x0402;
    internal const uint GL_BACK_RIGHT = 0x0403;
    internal const uint GL_FRONT = 0x0404;
    internal const uint GL_BACK = 0x0405;
    internal const uint GL_LEFT = 0x0406;
    internal const uint GL_RIGHT = 0x0407;
    internal const uint GL_FRONT_AND_BACK = 0x0408;
    internal const uint GL_AUX0 = 0x0409;
    internal const uint GL_AUX1 = 0x040A;
    internal const uint GL_AUX2 = 0x040B;
    internal const uint GL_AUX3 = 0x040C;

    /* Enable */
    /*      GL_FOG */
    /*      GL_LIGHTING */
    /*      GL_TEXTURE_1D */
    /*      GL_TEXTURE_2D */
    /*      GL_LINE_STIPPLE */
    /*      GL_POLYGON_STIPPLE */
    /*      GL_CULL_FACE */
    /*      GL_ALPHA_TEST */
    /*      GL_BLEND */
    /*      GL_INDEX_LOGIC_OP */
    /*      GL_COLOR_LOGIC_OP */
    /*      GL_DITHER */
    /*      GL_STENCIL_TEST */
    /*      GL_DEPTH_TEST */
    /*      GL_CLIP_PLANE0 */
    /*      GL_CLIP_PLANE1 */
    /*      GL_CLIP_PLANE2 */
    /*      GL_CLIP_PLANE3 */
    /*      GL_CLIP_PLANE4 */
    /*      GL_CLIP_PLANE5 */
    /*      GL_LIGHT0 */
    /*      GL_LIGHT1 */
    /*      GL_LIGHT2 */
    /*      GL_LIGHT3 */
    /*      GL_LIGHT4 */
    /*      GL_LIGHT5 */
    /*      GL_LIGHT6 */
    /*      GL_LIGHT7 */
    /*      GL_TEXTURE_GEN_S */
    /*      GL_TEXTURE_GEN_T */
    /*      GL_TEXTURE_GEN_R */
    /*      GL_TEXTURE_GEN_Q */
    /*      GL_MAP1_VERTEX_3 */
    /*      GL_MAP1_VERTEX_4 */
    /*      GL_MAP1_COLOR_4 */
    /*      GL_MAP1_INDEX */
    /*      GL_MAP1_NORMAL */
    /*      GL_MAP1_TEXTURE_COORD_1 */
    /*      GL_MAP1_TEXTURE_COORD_2 */
    /*      GL_MAP1_TEXTURE_COORD_3 */
    /*      GL_MAP1_TEXTURE_COORD_4 */
    /*      GL_MAP2_VERTEX_3 */
    /*      GL_MAP2_VERTEX_4 */
    /*      GL_MAP2_COLOR_4 */
    /*      GL_MAP2_INDEX */
    /*      GL_MAP2_NORMAL */
    /*      GL_MAP2_TEXTURE_COORD_1 */
    /*      GL_MAP2_TEXTURE_COORD_2 */
    /*      GL_MAP2_TEXTURE_COORD_3 */
    /*      GL_MAP2_TEXTURE_COORD_4 */
    /*      GL_POINT_SMOOTH */
    /*      GL_LINE_SMOOTH */
    /*      GL_POLYGON_SMOOTH */
    /*      GL_SCISSOR_TEST */
    /*      GL_COLOR_MATERIAL */
    /*      GL_NORMALIZE */
    /*      GL_AUTO_NORMAL */
    /*      GL_VERTEX_ARRAY */
    /*      GL_NORMAL_ARRAY */
    /*      GL_COLOR_ARRAY */
    /*      GL_INDEX_ARRAY */
    /*      GL_TEXTURE_COORD_ARRAY */
    /*      GL_EDGE_FLAG_ARRAY */
    /*      GL_POLYGON_OFFSET_POINT */
    /*      GL_POLYGON_OFFSET_LINE */
    /*      GL_POLYGON_OFFSET_FILL */

    /* ErrorCode */
    internal const uint GL_NO_ERROR = 0;
    internal const uint GL_INVALID_ENUM = 0x0500;
    internal const uint GL_INVALID_VALUE = 0x0501;
    internal const uint GL_INVALID_OPERATION = 0x0502;
    internal const uint GL_STACK_OVERFLOW = 0x0503;
    internal const uint GL_STACK_UNDERFLOW = 0x0504;
    internal const uint GL_OUT_OF_MEMORY = 0x0505;

    /* FeedBackMode */
    internal const uint GL_2D = 0x0600;
    internal const uint GL_3D = 0x0601;
    internal const uint GL_3D_COLOR = 0x0602;
    internal const uint GL_3D_COLOR_TEXTURE = 0x0603;
    internal const uint GL_4D_COLOR_TEXTURE = 0x0604;

    /* FeedBackToken */
    internal const uint GL_PASS_THROUGH_TOKEN = 0x0700;
    internal const uint GL_POINT_TOKEN = 0x0701;
    internal const uint GL_LINE_TOKEN = 0x0702;
    internal const uint GL_POLYGON_TOKEN = 0x0703;
    internal const uint GL_BITMAP_TOKEN = 0x0704;
    internal const uint GL_DRAW_PIXEL_TOKEN = 0x0705;
    internal const uint GL_COPY_PIXEL_TOKEN = 0x0706;
    internal const uint GL_LINE_RESET_TOKEN = 0x0707;

    /* FogMode */
    /*      GL_LINEAR */
    internal const uint GL_EXP = 0x0800;
    internal const uint GL_EXP2 = 0x0801;


    /* FogParameter */
    /*      GL_FOG_COLOR */
    /*      GL_FOG_DENSITY */
    /*      GL_FOG_END */
    /*      GL_FOG_INDEX */
    /*      GL_FOG_MODE */
    /*      GL_FOG_START */

    /* FrontFaceDirection */
    internal const uint GL_CW = 0x0900;
    internal const uint GL_CCW = 0x0901;

    /* GetMapTarget */
    internal const uint GL_COEFF = 0x0A00;
    internal const uint GL_ORDER = 0x0A01;
    internal const uint GL_DOMAIN = 0x0A02;

    /* GetPixelMap */
    /*      GL_PIXEL_MAP_I_TO_I */
    /*      GL_PIXEL_MAP_S_TO_S */
    /*      GL_PIXEL_MAP_I_TO_R */
    /*      GL_PIXEL_MAP_I_TO_G */
    /*      GL_PIXEL_MAP_I_TO_B */
    /*      GL_PIXEL_MAP_I_TO_A */
    /*      GL_PIXEL_MAP_R_TO_R */
    /*      GL_PIXEL_MAP_G_TO_G */
    /*      GL_PIXEL_MAP_B_TO_B */
    /*      GL_PIXEL_MAP_A_TO_A */

    /* GetPointerTarget */
    /*      GL_VERTEX_ARRAY_POINTER */
    /*      GL_NORMAL_ARRAY_POINTER */
    /*      GL_COLOR_ARRAY_POINTER */
    /*      GL_INDEX_ARRAY_POINTER */
    /*      GL_TEXTURE_COORD_ARRAY_POINTER */
    /*      GL_EDGE_FLAG_ARRAY_POINTER */

    /* GetTarget */
    internal const uint GL_CURRENT_COLOR = 0x0B00;
    internal const uint GL_CURRENT_INDEX = 0x0B01;
    internal const uint GL_CURRENT_NORMAL = 0x0B02;
    internal const uint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
    internal const uint GL_CURRENT_RASTER_COLOR = 0x0B04;
    internal const uint GL_CURRENT_RASTER_INDEX = 0x0B05;
    internal const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
    internal const uint GL_CURRENT_RASTER_POSITION = 0x0B07;
    internal const uint GL_CURRENT_RASTER_POSITION_VALID = 0x0B08;
    internal const uint GL_CURRENT_RASTER_DISTANCE = 0x0B09;
    internal const uint GL_POINT_SMOOTH = 0x0B10;
    internal const uint GL_POINT_SIZE = 0x0B11;
    internal const uint GL_POINT_SIZE_RANGE = 0x0B12;
    internal const uint GL_POINT_SIZE_GRANULARITY = 0x0B13;
    internal const uint GL_LINE_SMOOTH = 0x0B20;
    internal const uint GL_LINE_WIDTH = 0x0B21;
    internal const uint GL_LINE_WIDTH_RANGE = 0x0B22;
    internal const uint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
    internal const uint GL_LINE_STIPPLE = 0x0B24;
    internal const uint GL_LINE_STIPPLE_PATTERN = 0x0B25;
    internal const uint GL_LINE_STIPPLE_REPEAT = 0x0B26;
    internal const uint GL_LIST_MODE = 0x0B30;
    internal const uint GL_MAX_LIST_NESTING = 0x0B31;
    internal const uint GL_LIST_BASE = 0x0B32;
    internal const uint GL_LIST_INDEX = 0x0B33;
    internal const uint GL_POLYGON_MODE = 0x0B40;
    internal const uint GL_POLYGON_SMOOTH = 0x0B41;
    internal const uint GL_POLYGON_STIPPLE = 0x0B42;
    internal const uint GL_EDGE_FLAG = 0x0B43;
    internal const uint GL_CULL_FACE = 0x0B44;
    internal const uint GL_CULL_FACE_MODE = 0x0B45;
    internal const uint GL_FRONT_FACE = 0x0B46;
    internal const uint GL_LIGHTING = 0x0B50;
    internal const uint GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
    internal const uint GL_LIGHT_MODEL_TWO_SIDE = 0x0B52;
    internal const uint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
    internal const uint GL_SHADE_MODEL = 0x0B54;
    internal const uint GL_COLOR_MATERIAL_FACE = 0x0B55;
    internal const uint GL_COLOR_MATERIAL_PARAMETER = 0x0B56;
    internal const uint GL_COLOR_MATERIAL = 0x0B57;
    internal const uint GL_FOG = 0x0B60;
    internal const uint GL_FOG_INDEX = 0x0B61;
    internal const uint GL_FOG_DENSITY = 0x0B62;
    internal const uint GL_FOG_START = 0x0B63;
    internal const uint GL_FOG_END = 0x0B64;
    internal const uint GL_FOG_MODE = 0x0B65;
    internal const uint GL_FOG_COLOR = 0x0B66;
    internal const uint GL_DEPTH_RANGE = 0x0B70;
    internal const uint GL_DEPTH_TEST = 0x0B71;
    internal const uint GL_DEPTH_WRITEMASK = 0x0B72;
    internal const uint GL_DEPTH_CLEAR_VALUE = 0x0B73;
    internal const uint GL_DEPTH_FUNC = 0x0B74;
    internal const uint GL_ACCUM_CLEAR_VALUE = 0x0B80;
    internal const uint GL_STENCIL_TEST = 0x0B90;
    internal const uint GL_STENCIL_CLEAR_VALUE = 0x0B91;
    internal const uint GL_STENCIL_FUNC = 0x0B92;
    internal const uint GL_STENCIL_VALUE_MASK = 0x0B93;
    internal const uint GL_STENCIL_FAIL = 0x0B94;
    internal const uint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
    internal const uint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
    internal const uint GL_STENCIL_REF = 0x0B97;
    internal const uint GL_STENCIL_WRITEMASK = 0x0B98;
    internal const uint GL_MATRIX_MODE = 0x0BA0;
    internal const uint GL_NORMALIZE = 0x0BA1;
    internal const uint GL_VIEWPORT = 0x0BA2;
    internal const uint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
    internal const uint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
    internal const uint GL_TEXTURE_STACK_DEPTH = 0x0BA5;
    internal const uint GL_MODELVIEW_MATRIX = 0x0BA6;
    internal const uint GL_PROJECTION_MATRIX = 0x0BA7;
    internal const uint GL_TEXTURE_MATRIX = 0x0BA8;
    internal const uint GL_ATTRIB_STACK_DEPTH = 0x0BB0;
    internal const uint GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
    internal const uint GL_ALPHA_TEST = 0x0BC0;
    internal const uint GL_ALPHA_TEST_FUNC = 0x0BC1;
    internal const uint GL_ALPHA_TEST_REF = 0x0BC2;
    internal const uint GL_DITHER = 0x0BD0;
    internal const uint GL_BLEND_DST = 0x0BE0;
    internal const uint GL_BLEND_SRC = 0x0BE1;
    internal const uint GL_BLEND = 0x0BE2;
    internal const uint GL_LOGIC_OP_MODE = 0x0BF0;
    internal const uint GL_INDEX_LOGIC_OP = 0x0BF1;
    internal const uint GL_COLOR_LOGIC_OP = 0x0BF2;
    internal const uint GL_AUX_BUFFERS = 0x0C00;
    internal const uint GL_DRAW_BUFFER = 0x0C01;
    internal const uint GL_READ_BUFFER = 0x0C02;
    internal const uint GL_SCISSOR_BOX = 0x0C10;
    internal const uint GL_SCISSOR_TEST = 0x0C11;
    internal const uint GL_INDEX_CLEAR_VALUE = 0x0C20;
    internal const uint GL_INDEX_WRITEMASK = 0x0C21;
    internal const uint GL_COLOR_CLEAR_VALUE = 0x0C22;
    internal const uint GL_COLOR_WRITEMASK = 0x0C23;
    internal const uint GL_INDEX_MODE = 0x0C30;
    internal const uint GL_RGBA_MODE = 0x0C31;
    internal const uint GL_DOUBLEBUFFER = 0x0C32;
    internal const uint GL_STEREO = 0x0C33;
    internal const uint GL_RENDER_MODE = 0x0C40;
    internal const uint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
    internal const uint GL_POINT_SMOOTH_HINT = 0x0C51;
    internal const uint GL_LINE_SMOOTH_HINT = 0x0C52;
    internal const uint GL_POLYGON_SMOOTH_HINT = 0x0C53;
    internal const uint GL_FOG_HINT = 0x0C54;
    internal const uint GL_TEXTURE_GEN_S = 0x0C60;
    internal const uint GL_TEXTURE_GEN_T = 0x0C61;
    internal const uint GL_TEXTURE_GEN_R = 0x0C62;
    internal const uint GL_TEXTURE_GEN_Q = 0x0C63;
    internal const uint GL_PIXEL_MAP_I_TO_I = 0x0C70;
    internal const uint GL_PIXEL_MAP_S_TO_S = 0x0C71;
    internal const uint GL_PIXEL_MAP_I_TO_R = 0x0C72;
    internal const uint GL_PIXEL_MAP_I_TO_G = 0x0C73;
    internal const uint GL_PIXEL_MAP_I_TO_B = 0x0C74;
    internal const uint GL_PIXEL_MAP_I_TO_A = 0x0C75;
    internal const uint GL_PIXEL_MAP_R_TO_R = 0x0C76;
    internal const uint GL_PIXEL_MAP_G_TO_G = 0x0C77;
    internal const uint GL_PIXEL_MAP_B_TO_B = 0x0C78;
    internal const uint GL_PIXEL_MAP_A_TO_A = 0x0C79;
    internal const uint GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
    internal const uint GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
    internal const uint GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
    internal const uint GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
    internal const uint GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
    internal const uint GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
    internal const uint GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
    internal const uint GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
    internal const uint GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
    internal const uint GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
    internal const uint GL_UNPACK_SWAP_BYTES = 0x0CF0;
    internal const uint GL_UNPACK_LSB_FIRST = 0x0CF1;
    internal const uint GL_UNPACK_ROW_LENGTH = 0x0CF2;
    internal const uint GL_UNPACK_SKIP_ROWS = 0x0CF3;
    internal const uint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
    internal const uint GL_UNPACK_ALIGNMENT = 0x0CF5;
    internal const uint GL_PACK_SWAP_BYTES = 0x0D00;
    internal const uint GL_PACK_LSB_FIRST = 0x0D01;
    internal const uint GL_PACK_ROW_LENGTH = 0x0D02;
    internal const uint GL_PACK_SKIP_ROWS = 0x0D03;
    internal const uint GL_PACK_SKIP_PIXELS = 0x0D04;
    internal const uint GL_PACK_ALIGNMENT = 0x0D05;
    internal const uint GL_MAP_COLOR = 0x0D10;
    internal const uint GL_MAP_STENCIL = 0x0D11;
    internal const uint GL_INDEX_SHIFT = 0x0D12;
    internal const uint GL_INDEX_OFFSET = 0x0D13;
    internal const uint GL_RED_SCALE = 0x0D14;
    internal const uint GL_RED_BIAS = 0x0D15;
    internal const uint GL_ZOOM_X = 0x0D16;
    internal const uint GL_ZOOM_Y = 0x0D17;
    internal const uint GL_GREEN_SCALE = 0x0D18;
    internal const uint GL_GREEN_BIAS = 0x0D19;
    internal const uint GL_BLUE_SCALE = 0x0D1A;
    internal const uint GL_BLUE_BIAS = 0x0D1B;
    internal const uint GL_ALPHA_SCALE = 0x0D1C;
    internal const uint GL_ALPHA_BIAS = 0x0D1D;
    internal const uint GL_DEPTH_SCALE = 0x0D1E;
    internal const uint GL_DEPTH_BIAS = 0x0D1F;
    internal const uint GL_MAX_EVAL_ORDER = 0x0D30;
    internal const uint GL_MAX_LIGHTS = 0x0D31;
    internal const uint GL_MAX_CLIP_PLANES = 0x0D32;
    internal const uint GL_MAX_TEXTURE_SIZE = 0x0D33;
    internal const uint GL_MAX_PIXEL_MAP_TABLE = 0x0D34;
    internal const uint GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35;
    internal const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
    internal const uint GL_MAX_NAME_STACK_DEPTH = 0x0D37;
    internal const uint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
    internal const uint GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39;
    internal const uint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
    internal const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
    internal const uint GL_SUBPIXEL_BITS = 0x0D50;
    internal const uint GL_INDEX_BITS = 0x0D51;
    internal const uint GL_RED_BITS = 0x0D52;
    internal const uint GL_GREEN_BITS = 0x0D53;
    internal const uint GL_BLUE_BITS = 0x0D54;
    internal const uint GL_ALPHA_BITS = 0x0D55;
    internal const uint GL_DEPTH_BITS = 0x0D56;
    internal const uint GL_STENCIL_BITS = 0x0D57;
    internal const uint GL_ACCUM_RED_BITS = 0x0D58;
    internal const uint GL_ACCUM_GREEN_BITS = 0x0D59;
    internal const uint GL_ACCUM_BLUE_BITS = 0x0D5A;
    internal const uint GL_ACCUM_ALPHA_BITS = 0x0D5B;
    internal const uint GL_NAME_STACK_DEPTH = 0x0D70;
    internal const uint GL_AUTO_NORMAL = 0x0D80;
    internal const uint GL_MAP1_COLOR_4 = 0x0D90;
    internal const uint GL_MAP1_INDEX = 0x0D91;
    internal const uint GL_MAP1_NORMAL = 0x0D92;
    internal const uint GL_MAP1_TEXTURE_COORD_1 = 0x0D93;
    internal const uint GL_MAP1_TEXTURE_COORD_2 = 0x0D94;
    internal const uint GL_MAP1_TEXTURE_COORD_3 = 0x0D95;
    internal const uint GL_MAP1_TEXTURE_COORD_4 = 0x0D96;
    internal const uint GL_MAP1_VERTEX_3 = 0x0D97;
    internal const uint GL_MAP1_VERTEX_4 = 0x0D98;
    internal const uint GL_MAP2_COLOR_4 = 0x0DB0;
    internal const uint GL_MAP2_INDEX = 0x0DB1;
    internal const uint GL_MAP2_NORMAL = 0x0DB2;
    internal const uint GL_MAP2_TEXTURE_COORD_1 = 0x0DB3;
    internal const uint GL_MAP2_TEXTURE_COORD_2 = 0x0DB4;
    internal const uint GL_MAP2_TEXTURE_COORD_3 = 0x0DB5;
    internal const uint GL_MAP2_TEXTURE_COORD_4 = 0x0DB6;
    internal const uint GL_MAP2_VERTEX_3 = 0x0DB7;
    internal const uint GL_MAP2_VERTEX_4 = 0x0DB8;
    internal const uint GL_MAP1_GRID_DOMAIN = 0x0DD0;
    internal const uint GL_MAP1_GRID_SEGMENTS = 0x0DD1;
    internal const uint GL_MAP2_GRID_DOMAIN = 0x0DD2;
    internal const uint GL_MAP2_GRID_SEGMENTS = 0x0DD3;
    internal const uint GL_TEXTURE_1D = 0x0DE0;
    internal const uint GL_TEXTURE_2D = 0x0DE1;
    internal const uint GL_FEEDBACK_BUFFER_POINTER = 0x0DF0;
    internal const uint GL_FEEDBACK_BUFFER_SIZE = 0x0DF1;
    internal const uint GL_FEEDBACK_BUFFER_TYPE = 0x0DF2;
    internal const uint GL_SELECTION_BUFFER_POINTER = 0x0DF3;

    internal const uint GL_SELECTION_BUFFER_SIZE = 0x0DF4;
    /*      GL_TEXTURE_BINDING_1D */
    /*      GL_TEXTURE_BINDING_2D */
    /*      GL_VERTEX_ARRAY */
    /*      GL_NORMAL_ARRAY */
    /*      GL_COLOR_ARRAY */
    /*      GL_INDEX_ARRAY */
    /*      GL_TEXTURE_COORD_ARRAY */
    /*      GL_EDGE_FLAG_ARRAY */
    /*      GL_VERTEX_ARRAY_SIZE */
    /*      GL_VERTEX_ARRAY_TYPE */
    /*      GL_VERTEX_ARRAY_STRIDE */
    /*      GL_NORMAL_ARRAY_TYPE */
    /*      GL_NORMAL_ARRAY_STRIDE */
    /*      GL_COLOR_ARRAY_SIZE */
    /*      GL_COLOR_ARRAY_TYPE */
    /*      GL_COLOR_ARRAY_STRIDE */
    /*      GL_INDEX_ARRAY_TYPE */
    /*      GL_INDEX_ARRAY_STRIDE */
    /*      GL_TEXTURE_COORD_ARRAY_SIZE */
    /*      GL_TEXTURE_COORD_ARRAY_TYPE */
    /*      GL_TEXTURE_COORD_ARRAY_STRIDE */
    /*      GL_EDGE_FLAG_ARRAY_STRIDE */
    /*      GL_POLYGON_OFFSET_FACTOR */
    /*      GL_POLYGON_OFFSET_UNITS */

    /* GetTextureParameter */
    /*      GL_TEXTURE_MAG_FILTER */
    /*      GL_TEXTURE_MIN_FILTER */
    /*      GL_TEXTURE_WRAP_S */
    /*      GL_TEXTURE_WRAP_T */
    internal const uint GL_TEXTURE_WIDTH = 0x1000;
    internal const uint GL_TEXTURE_HEIGHT = 0x1001;
    internal const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
    internal const uint GL_TEXTURE_BORDER_COLOR = 0x1004;

    internal const uint GL_TEXTURE_BORDER = 0x1005;
    /*      GL_TEXTURE_RED_SIZE */
    /*      GL_TEXTURE_GREEN_SIZE */
    /*      GL_TEXTURE_BLUE_SIZE */
    /*      GL_TEXTURE_ALPHA_SIZE */
    /*      GL_TEXTURE_LUMINANCE_SIZE */
    /*      GL_TEXTURE_INTENSITY_SIZE */
    /*      GL_TEXTURE_PRIORITY */
    /*      GL_TEXTURE_RESIDENT */

    /* HintMode */
    internal const uint GL_DONT_CARE = 0x1100;
    internal const uint GL_FASTEST = 0x1101;
    internal const uint GL_NICEST = 0x1102;

    /* HintTarget */
    /*      GL_PERSPECTIVE_CORRECTION_HINT */
    /*      GL_POINT_SMOOTH_HINT */
    /*      GL_LINE_SMOOTH_HINT */
    /*      GL_POLYGON_SMOOTH_HINT */
    /*      GL_FOG_HINT */
    /*      GL_PHONG_HINT */

    /* IndexPointerType */
    /*      GL_SHORT */
    /*      GL_INT */
    /*      GL_FLOAT */
    /*      GL_DOUBLE */

    /* LightModelParameter */
    /*      GL_LIGHT_MODEL_AMBIENT */
    /*      GL_LIGHT_MODEL_LOCAL_VIEWER */
    /*      GL_LIGHT_MODEL_TWO_SIDE */

    /* LightName */
    internal const uint GL_LIGHT0 = 0x4000;
    internal const uint GL_LIGHT1 = 0x4001;
    internal const uint GL_LIGHT2 = 0x4002;
    internal const uint GL_LIGHT3 = 0x4003;
    internal const uint GL_LIGHT4 = 0x4004;
    internal const uint GL_LIGHT5 = 0x4005;
    internal const uint GL_LIGHT6 = 0x4006;
    internal const uint GL_LIGHT7 = 0x4007;

    /* LightParameter */
    internal const uint GL_AMBIENT = 0x1200;
    internal const uint GL_DIFFUSE = 0x1201;
    internal const uint GL_SPECULAR = 0x1202;
    internal const uint GL_POSITION = 0x1203;
    internal const uint GL_SPOT_DIRECTION = 0x1204;
    internal const uint GL_SPOT_EXPONENT = 0x1205;
    internal const uint GL_SPOT_CUTOFF = 0x1206;
    internal const uint GL_CONSTANT_ATTENUATION = 0x1207;
    internal const uint GL_LINEAR_ATTENUATION = 0x1208;
    internal const uint GL_QUADRATIC_ATTENUATION = 0x1209;

    /* InterleavedArrays */
    /*      GL_V2F */
    /*      GL_V3F */
    /*      GL_C4UB_V2F */
    /*      GL_C4UB_V3F */
    /*      GL_C3F_V3F */
    /*      GL_N3F_V3F */
    /*      GL_C4F_N3F_V3F */
    /*      GL_T2F_V3F */
    /*      GL_T4F_V4F */
    /*      GL_T2F_C4UB_V3F */
    /*      GL_T2F_C3F_V3F */
    /*      GL_T2F_N3F_V3F */
    /*      GL_T2F_C4F_N3F_V3F */
    /*      GL_T4F_C4F_N3F_V4F */

    /* ListMode */
    internal const uint GL_COMPILE = 0x1300;
    internal const uint GL_COMPILE_AND_EXECUTE = 0x1301;

    /* ListNameType */
    /*      GL_BYTE */
    /*      GL_UNSIGNED_BYTE */
    /*      GL_SHORT */
    /*      GL_UNSIGNED_SHORT */
    /*      GL_INT */
    /*      GL_UNSIGNED_INT */
    /*      GL_FLOAT */
    /*      GL_2_BYTES */
    /*      GL_3_BYTES */
    /*      GL_4_BYTES */

    /* LogicOp */
    internal const uint GL_CLEAR = 0x1500;
    internal const uint GL_AND = 0x1501;
    internal const uint GL_AND_REVERSE = 0x1502;
    internal const uint GL_COPY = 0x1503;
    internal const uint GL_AND_INVERTED = 0x1504;
    internal const uint GL_NOOP = 0x1505;
    internal const uint GL_XOR = 0x1506;
    internal const uint GL_OR = 0x1507;
    internal const uint GL_NOR = 0x1508;
    internal const uint GL_EQUIV = 0x1509;
    internal const uint GL_INVERT = 0x150A;
    internal const uint GL_OR_REVERSE = 0x150B;
    internal const uint GL_COPY_INVERTED = 0x150C;
    internal const uint GL_OR_INVERTED = 0x150D;
    internal const uint GL_NAND = 0x150E;
    internal const uint GL_SET = 0x150F;

    /* MapTarget */
    /*      GL_MAP1_COLOR_4 */
    /*      GL_MAP1_INDEX */
    /*      GL_MAP1_NORMAL */
    /*      GL_MAP1_TEXTURE_COORD_1 */
    /*      GL_MAP1_TEXTURE_COORD_2 */
    /*      GL_MAP1_TEXTURE_COORD_3 */
    /*      GL_MAP1_TEXTURE_COORD_4 */
    /*      GL_MAP1_VERTEX_3 */
    /*      GL_MAP1_VERTEX_4 */
    /*      GL_MAP2_COLOR_4 */
    /*      GL_MAP2_INDEX */
    /*      GL_MAP2_NORMAL */
    /*      GL_MAP2_TEXTURE_COORD_1 */
    /*      GL_MAP2_TEXTURE_COORD_2 */
    /*      GL_MAP2_TEXTURE_COORD_3 */
    /*      GL_MAP2_TEXTURE_COORD_4 */
    /*      GL_MAP2_VERTEX_3 */
    /*      GL_MAP2_VERTEX_4 */

    /* MaterialFace */
    /*      GL_FRONT */
    /*      GL_BACK */
    /*      GL_FRONT_AND_BACK */

    /* MaterialParameter */
    internal const uint GL_EMISSION = 0x1600;
    internal const uint GL_SHININESS = 0x1601;
    internal const uint GL_AMBIENT_AND_DIFFUSE = 0x1602;

    internal const uint GL_COLOR_INDEXES = 0x1603;
    /*      GL_AMBIENT */
    /*      GL_DIFFUSE */
    /*      GL_SPECULAR */

    /* MatrixMode */
    internal const uint GL_MODELVIEW = 0x1700;
    internal const uint GL_PROJECTION = 0x1701;
    internal const uint GL_TEXTURE = 0x1702;

    /* MeshMode1 */
    /*      GL_POINT */
    /*      GL_LINE */

    /* MeshMode2 */
    /*      GL_POINT */
    /*      GL_LINE */
    /*      GL_FILL */

    /* NormalPointerType */
    /*      GL_BYTE */
    /*      GL_SHORT */
    /*      GL_INT */
    /*      GL_FLOAT */
    /*      GL_DOUBLE */

    /* PixelCopyType */
    internal const uint GL_COLOR = 0x1800;
    internal const uint GL_DEPTH = 0x1801;
    internal const uint GL_STENCIL = 0x1802;

    /* PixelFormat */
    internal const uint GL_COLOR_INDEX = 0x1900;
    internal const uint GL_STENCIL_INDEX = 0x1901;
    internal const uint GL_DEPTH_COMPONENT = 0x1902;
    internal const uint GL_RED = 0x1903;
    internal const uint GL_GREEN = 0x1904;
    internal const uint GL_BLUE = 0x1905;
    internal const uint GL_ALPHA = 0x1906;
    internal const uint GL_RGB = 0x1907;
    internal const uint GL_RGBA = 0x1908;
    internal const uint GL_LUMINANCE = 0x1909;
    internal const uint GL_LUMINANCE_ALPHA = 0x190A;

    /* PixelMap */
    /*      GL_PIXEL_MAP_I_TO_I */
    /*      GL_PIXEL_MAP_S_TO_S */
    /*      GL_PIXEL_MAP_I_TO_R */
    /*      GL_PIXEL_MAP_I_TO_G */
    /*      GL_PIXEL_MAP_I_TO_B */
    /*      GL_PIXEL_MAP_I_TO_A */
    /*      GL_PIXEL_MAP_R_TO_R */
    /*      GL_PIXEL_MAP_G_TO_G */
    /*      GL_PIXEL_MAP_B_TO_B */
    /*      GL_PIXEL_MAP_A_TO_A */

    /* PixelStore */
    /*      GL_UNPACK_SWAP_BYTES */
    /*      GL_UNPACK_LSB_FIRST */
    /*      GL_UNPACK_ROW_LENGTH */
    /*      GL_UNPACK_SKIP_ROWS */
    /*      GL_UNPACK_SKIP_PIXELS */
    /*      GL_UNPACK_ALIGNMENT */
    /*      GL_PACK_SWAP_BYTES */
    /*      GL_PACK_LSB_FIRST */
    /*      GL_PACK_ROW_LENGTH */
    /*      GL_PACK_SKIP_ROWS */
    /*      GL_PACK_SKIP_PIXELS */
    /*      GL_PACK_ALIGNMENT */

    /* PixelTransfer */
    /*      GL_MAP_COLOR */
    /*      GL_MAP_STENCIL */
    /*      GL_INDEX_SHIFT */
    /*      GL_INDEX_OFFSET */
    /*      GL_RED_SCALE */
    /*      GL_RED_BIAS */
    /*      GL_GREEN_SCALE */
    /*      GL_GREEN_BIAS */
    /*      GL_BLUE_SCALE */
    /*      GL_BLUE_BIAS */
    /*      GL_ALPHA_SCALE */
    /*      GL_ALPHA_BIAS */
    /*      GL_DEPTH_SCALE */
    /*      GL_DEPTH_BIAS */

    /* PixelType */
    internal const uint GL_BITMAP = 0x1A00;
    /*      GL_BYTE */
    /*      GL_UNSIGNED_BYTE */
    /*      GL_SHORT */
    /*      GL_UNSIGNED_SHORT */
    /*      GL_INT */
    /*      GL_UNSIGNED_INT */
    /*      GL_FLOAT */

    /* PolygonMode */
    internal const uint GL_POINT = 0x1B00;
    internal const uint GL_LINE = 0x1B01;
    internal const uint GL_FILL = 0x1B02;

    /* ReadBufferMode */
    /*      GL_FRONT_LEFT */
    /*      GL_FRONT_RIGHT */
    /*      GL_BACK_LEFT */
    /*      GL_BACK_RIGHT */
    /*      GL_FRONT */
    /*      GL_BACK */
    /*      GL_LEFT */
    /*      GL_RIGHT */
    /*      GL_AUX0 */
    /*      GL_AUX1 */
    /*      GL_AUX2 */
    /*      GL_AUX3 */

    /* RenderingMode */
    internal const uint GL_RENDER = 0x1C00;
    internal const uint GL_FEEDBACK = 0x1C01;
    internal const uint GL_SELECT = 0x1C02;

    /* ShadingModel */
    internal const uint GL_FLAT = 0x1D00;
    internal const uint GL_SMOOTH = 0x1D01;


    /* StencilFunction */
    /*      GL_NEVER */
    /*      GL_LESS */
    /*      GL_EQUAL */
    /*      GL_LEQUAL */
    /*      GL_GREATER */
    /*      GL_NOTEQUAL */
    /*      GL_GEQUAL */
    /*      GL_ALWAYS */

    /* StencilOp */
    /*      GL_ZERO */
    internal const uint GL_KEEP = 0x1E00;
    internal const uint GL_REPLACE = 0x1E01;
    internal const uint GL_INCR = 0x1E02;
    internal const uint GL_DECR = 0x1E03;
    /*      GL_INVERT */

    /* StringName */
    internal const uint GL_VENDOR = 0x1F00;
    internal const uint GL_RENDERER = 0x1F01;
    internal const uint GL_VERSION = 0x1F02;
    internal const uint GL_EXTENSIONS = 0x1F03;

    /* TextureCoordName */
    internal const uint GL_S = 0x2000;
    internal const uint GL_T = 0x2001;
    internal const uint GL_R = 0x2002;
    internal const uint GL_Q = 0x2003;

    /* TexCoordPointerType */
    /*      GL_SHORT */
    /*      GL_INT */
    /*      GL_FLOAT */
    /*      GL_DOUBLE */

    /* TextureEnvMode */
    internal const uint GL_MODULATE = 0x2100;

    internal const uint GL_DECAL = 0x2101;
    /*      GL_BLEND */
    /*      GL_REPLACE */

    /* TextureEnvParameter */
    internal const uint GL_TEXTURE_ENV_MODE = 0x2200;
    internal const uint GL_TEXTURE_ENV_COLOR = 0x2201;

    /* TextureEnvTarget */
    internal const uint GL_TEXTURE_ENV = 0x2300;

    /* TextureGenMode */
    internal const uint GL_EYE_LINEAR = 0x2400;
    internal const uint GL_OBJECT_LINEAR = 0x2401;
    internal const uint GL_SPHERE_MAP = 0x2402;

    /* TextureGenParameter */
    internal const uint GL_TEXTURE_GEN_MODE = 0x2500;
    internal const uint GL_OBJECT_PLANE = 0x2501;
    internal const uint GL_EYE_PLANE = 0x2502;

    /* TextureMagFilter */
    internal const uint GL_NEAREST = 0x2600;
    internal const uint GL_LINEAR = 0x2601;

    /* TextureMinFilter */
    /*      GL_NEAREST */
    /*      GL_LINEAR */
    internal const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
    internal const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
    internal const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
    internal const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;

    /* TextureParameterName */
    internal const uint GL_TEXTURE_MAG_FILTER = 0x2800;
    internal const uint GL_TEXTURE_MIN_FILTER = 0x2801;
    internal const uint GL_TEXTURE_WRAP_S = 0x2802;

    internal const uint GL_TEXTURE_WRAP_T = 0x2803;
    /*      GL_TEXTURE_BORDER_COLOR */
    /*      GL_TEXTURE_PRIORITY */

    /* TextureTarget */
    /*      GL_TEXTURE_1D */
    /*      GL_TEXTURE_2D */
    /*      GL_PROXY_TEXTURE_1D */
    /*      GL_PROXY_TEXTURE_2D */

    /* TextureWrapMode */
    internal const uint GL_CLAMP = 0x2900;
    internal const uint GL_REPEAT = 0x2901;

    /* VertexPointerType */
    /*      GL_SHORT */
    /*      GL_INT */
    /*      GL_FLOAT */
    /*      GL_DOUBLE */

    /* ClientAttribMask */
    internal const uint GL_CLIENT_PIXEL_STORE_BIT = 0x00000001;
    internal const uint GL_CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
    internal const uint GL_CLIENT_ALL_ATTRIB_BITS = 0xffffffff;

    /* polygon_offset */
    internal const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
    internal const uint GL_POLYGON_OFFSET_UNITS = 0x2A00;
    internal const uint GL_POLYGON_OFFSET_POINT = 0x2A01;
    internal const uint GL_POLYGON_OFFSET_LINE = 0x2A02;
    internal const uint GL_POLYGON_OFFSET_FILL = 0x8037;

    /* texture */
    internal const uint GL_ALPHA4 = 0x803B;
    internal const uint GL_ALPHA8 = 0x803C;
    internal const uint GL_ALPHA12 = 0x803D;
    internal const uint GL_ALPHA16 = 0x803E;
    internal const uint GL_LUMINANCE4 = 0x803F;
    internal const uint GL_LUMINANCE8 = 0x8040;
    internal const uint GL_LUMINANCE12 = 0x8041;
    internal const uint GL_LUMINANCE16 = 0x8042;
    internal const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
    internal const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
    internal const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
    internal const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
    internal const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
    internal const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
    internal const uint GL_INTENSITY = 0x8049;
    internal const uint GL_INTENSITY4 = 0x804A;
    internal const uint GL_INTENSITY8 = 0x804B;
    internal const uint GL_INTENSITY12 = 0x804C;
    internal const uint GL_INTENSITY16 = 0x804D;
    internal const uint GL_R3_G3_B2 = 0x2A10;
    internal const uint GL_RGB4 = 0x804F;
    internal const uint GL_RGB5 = 0x8050;
    internal const uint GL_RGB8 = 0x8051;
    internal const uint GL_RGB10 = 0x8052;
    internal const uint GL_RGB12 = 0x8053;
    internal const uint GL_RGB16 = 0x8054;
    internal const uint GL_RGBA2 = 0x8055;
    internal const uint GL_RGBA4 = 0x8056;
    internal const uint GL_RGB5_A1 = 0x8057;
    internal const uint GL_RGBA8 = 0x8058;
    internal const uint GL_RGB10_A2 = 0x8059;
    internal const uint GL_RGBA12 = 0x805A;
    internal const uint GL_RGBA16 = 0x805B;
    internal const uint GL_TEXTURE_RED_SIZE = 0x805C;
    internal const uint GL_TEXTURE_GREEN_SIZE = 0x805D;
    internal const uint GL_TEXTURE_BLUE_SIZE = 0x805E;
    internal const uint GL_TEXTURE_ALPHA_SIZE = 0x805F;
    internal const uint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
    internal const uint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
    internal const uint GL_PROXY_TEXTURE_1D = 0x8063;
    internal const uint GL_PROXY_TEXTURE_2D = 0x8064;

    /* texture_object */
    internal const uint GL_TEXTURE_PRIORITY = 0x8066;
    internal const uint GL_TEXTURE_RESIDENT = 0x8067;
    internal const uint GL_TEXTURE_BINDING_1D = 0x8068;
    internal const uint GL_TEXTURE_BINDING_2D = 0x8069;

    /* vertex_array */
    internal const uint GL_VERTEX_ARRAY = 0x8074;
    internal const uint GL_NORMAL_ARRAY = 0x8075;
    internal const uint GL_COLOR_ARRAY = 0x8076;
    internal const uint GL_INDEX_ARRAY = 0x8077;
    internal const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
    internal const uint GL_EDGE_FLAG_ARRAY = 0x8079;
    internal const uint GL_VERTEX_ARRAY_SIZE = 0x807A;
    internal const uint GL_VERTEX_ARRAY_TYPE = 0x807B;
    internal const uint GL_VERTEX_ARRAY_STRIDE = 0x807C;
    internal const uint GL_NORMAL_ARRAY_TYPE = 0x807E;
    internal const uint GL_NORMAL_ARRAY_STRIDE = 0x807F;
    internal const uint GL_COLOR_ARRAY_SIZE = 0x8081;
    internal const uint GL_COLOR_ARRAY_TYPE = 0x8082;
    internal const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
    internal const uint GL_INDEX_ARRAY_TYPE = 0x8085;
    internal const uint GL_INDEX_ARRAY_STRIDE = 0x8086;
    internal const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
    internal const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
    internal const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
    internal const uint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C;
    internal const uint GL_VERTEX_ARRAY_POINTER = 0x808E;
    internal const uint GL_NORMAL_ARRAY_POINTER = 0x808F;
    internal const uint GL_COLOR_ARRAY_POINTER = 0x8090;
    internal const uint GL_INDEX_ARRAY_POINTER = 0x8091;
    internal const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
    internal const uint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;
    internal const uint GL_V2F = 0x2A20;
    internal const uint GL_V3F = 0x2A21;
    internal const uint GL_C4UB_V2F = 0x2A22;
    internal const uint GL_C4UB_V3F = 0x2A23;
    internal const uint GL_C3F_V3F = 0x2A24;
    internal const uint GL_N3F_V3F = 0x2A25;
    internal const uint GL_C4F_N3F_V3F = 0x2A26;
    internal const uint GL_T2F_V3F = 0x2A27;
    internal const uint GL_T4F_V4F = 0x2A28;
    internal const uint GL_T2F_C4UB_V3F = 0x2A29;
    internal const uint GL_T2F_C3F_V3F = 0x2A2A;
    internal const uint GL_T2F_N3F_V3F = 0x2A2B;
    internal const uint GL_T2F_C4F_N3F_V3F = 0x2A2C;
    internal const uint GL_T4F_C4F_N3F_V4F = 0x2A2D;

    /* Extensions */
    internal const uint GL_EXT_vertex_array = 1;
    internal const uint GL_EXT_bgra = 1;
    internal const uint GL_EXT_paletted_texture = 1;
    internal const uint GL_WIN_swap_hint = 1;

    internal const uint GL_WIN_draw_range_elements = 1;
    // internal const uint GL_WIN_phong_shading = 1;
    // internal const uint GL_WIN_specular_fog = 1;

    /* EXT_vertex_array */
    internal const uint GL_VERTEX_ARRAY_EXT = 0x8074;
    internal const uint GL_NORMAL_ARRAY_EXT = 0x8075;
    internal const uint GL_COLOR_ARRAY_EXT = 0x8076;
    internal const uint GL_INDEX_ARRAY_EXT = 0x8077;
    internal const uint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
    internal const uint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
    internal const uint GL_VERTEX_ARRAY_SIZE_EXT = 0x807A;
    internal const uint GL_VERTEX_ARRAY_TYPE_EXT = 0x807B;
    internal const uint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807C;
    internal const uint GL_VERTEX_ARRAY_COUNT_EXT = 0x807D;
    internal const uint GL_NORMAL_ARRAY_TYPE_EXT = 0x807E;
    internal const uint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807F;
    internal const uint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
    internal const uint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
    internal const uint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
    internal const uint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
    internal const uint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
    internal const uint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
    internal const uint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
    internal const uint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
    internal const uint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
    internal const uint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
    internal const uint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808A;
    internal const uint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B;
    internal const uint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808C;
    internal const uint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D;
    internal const uint GL_VERTEX_ARRAY_POINTER_EXT = 0x808E;
    internal const uint GL_NORMAL_ARRAY_POINTER_EXT = 0x808F;
    internal const uint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
    internal const uint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
    internal const uint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
    internal const uint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;
    internal const uint GL_DOUBLE_EXT = GL_DOUBLE;

    /* EXT_bgra */
    internal const uint GL_BGR_EXT = 0x80E0;
    internal const uint GL_BGRA_EXT = 0x80E1;

    /* EXT_paletted_texture */

    /* These must match the GL_COLOR_TABLE_*_SGI enumerants */
    internal const uint GL_COLOR_TABLE_FORMAT_EXT = 0x80D8;
    internal const uint GL_COLOR_TABLE_WIDTH_EXT = 0x80D9;
    internal const uint GL_COLOR_TABLE_RED_SIZE_EXT = 0x80DA;
    internal const uint GL_COLOR_TABLE_GREEN_SIZE_EXT = 0x80DB;
    internal const uint GL_COLOR_TABLE_BLUE_SIZE_EXT = 0x80DC;
    internal const uint GL_COLOR_TABLE_ALPHA_SIZE_EXT = 0x80DD;
    internal const uint GL_COLOR_TABLE_LUMINANCE_SIZE_EXT = 0x80DE;
    internal const uint GL_COLOR_TABLE_INTENSITY_SIZE_EXT = 0x80DF;

    internal const uint GL_COLOR_INDEX1_EXT = 0x80E2;
    internal const uint GL_COLOR_INDEX2_EXT = 0x80E3;
    internal const uint GL_COLOR_INDEX4_EXT = 0x80E4;
    internal const uint GL_COLOR_INDEX8_EXT = 0x80E5;
    internal const uint GL_COLOR_INDEX12_EXT = 0x80E6;
    internal const uint GL_COLOR_INDEX16_EXT = 0x80E7;

    /* WIN_draw_range_elements */
    internal const uint GL_MAX_ELEMENTS_VERTICES_WIN = 0x80E8;
    internal const uint GL_MAX_ELEMENTS_INDICES_WIN = 0x80E9;

    /* WIN_phong_shading */
    internal const uint GL_PHONG_WIN = 0x80EA;
    internal const uint GL_PHONG_HINT_WIN = 0x80EB;

    /* WIN_specular_fog */
    internal const uint GL_FOG_SPECULAR_TEXTURE_WIN = 0x80EC;

    /* For compatibility with OpenGL v1.0 */
    internal const uint GL_LOGIC_OP = GL_INDEX_LOGIC_OP;
    internal const uint GL_TEXTURE_COMPONENTS = GL_TEXTURE_INTERNAL_FORMAT;
}