using System.Runtime.InteropServices;
using Becometrica.Interop.WinApi.Types;

namespace Becometrica.Interop.WinApi.Opengl32;

public static partial class Opengl32Lib
{
    private static class Interop
    {
        private const string DllName = "Opengl32";

        [DllImport(DllName)]
        public static extern void glAccum(GlAccumOp op, float value);

        [DllImport(DllName)]
        public static extern void glAlphaFunc(GlTestFunction func, float referenceValue);

        [DllImport(DllName)]
        public static extern bool glAreTexturesResident(int n, ConstPtr<uint> textures, Ptr<bool> residences);

        [DllImport(DllName)]
        public static extern void glArrayElement(int index);

        [DllImport(DllName)]
        public static extern void glBegin(GlPrimitiveKind mode);

        [DllImport(DllName)]
        public static extern void glBindTexture(GlTextureTarget target, uint texture);

        [DllImport(DllName)]
        public static extern void glBitmap(int width, int height, float xOrig, float yOrig, float xMove, float yMove,
            ConstPtr<byte> bitmap);

        [DllImport(DllName)]
        public static extern void glBlendFunc(GlBlendingFactor sourceFactor, GlBlendingFactor destinationFactor);

        [DllImport(DllName)]
        public static extern void glCallList(uint list);

        [DllImport(DllName)]
        public static extern void glCallLists(int n, GlDataType type, ConstPtr<byte> lists);

        public static unsafe void CallLists<T>(ReadOnlySpan<T> lists, GlDataType type)
            where T: unmanaged
        {
            fixed (T* listsPtr = lists)
                glCallLists(lists.Length, type, new ConstPtr<T>(listsPtr).Cast<byte>());
        }

        [DllImport(DllName)]
        public static extern void glClear(GlBufferTypes mask);

        [DllImport(DllName)]
        public static extern void glClearAccum(float red, float green, float blue, float alpha);

        [DllImport(DllName)]
        public static extern void glClearColor(float red, float green, float blue, float alpha);

        [DllImport(DllName)]
        public static extern void glClearDepth(double depth);

        [DllImport(DllName)]
        public static extern void glClearIndex(float c);

        [DllImport(DllName)]
        public static extern void glClearStencil(int s);

        [DllImport(DllName)]
        public static extern void glClipPlane(GlClipPlane plane, ConstPtr<double> equation);

        [DllImport(DllName)]
        public static extern void glColor3b(sbyte red, sbyte green, sbyte blue);

        [DllImport(DllName)]
        public static extern void glColor3bv(ConstPtr<sbyte> v);

        [DllImport(DllName)]
        public static extern void glColor3d(double red, double green, double blue);

        [DllImport(DllName)]
        public static extern void glColor3dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glColor3f(float red, float green, float blue);

        [DllImport(DllName)]
        public static extern void glColor3fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glColor3i(int red, int green, int blue);

        [DllImport(DllName)]
        public static extern void glColor3iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glColor3s(short red, short green, short blue);

        [DllImport(DllName)]
        public static extern void glColor3sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glColor3ub(byte red, byte green, byte blue);

        [DllImport(DllName)]
        public static extern void glColor3ubv(ConstPtr<byte> v);

        [DllImport(DllName)]
        public static extern void glColor3ui(uint red, uint green, uint blue);

        [DllImport(DllName)]
        public static extern void glColor3uiv(ConstPtr<uint> v);

        [DllImport(DllName)]
        public static extern void glColor3us(ushort red, ushort green, ushort blue);

        [DllImport(DllName)]
        public static extern void glColor3usv(ConstPtr<ushort> v);

        [DllImport(DllName)]
        public static extern void glColor4b(sbyte red, sbyte green, sbyte blue, sbyte alpha);

        [DllImport(DllName)]
        public static extern void glColor4bv(ConstPtr<sbyte> v);

        [DllImport(DllName)]
        public static extern void glColor4d(double red, double green, double blue, double alpha);

        [DllImport(DllName)]
        public static extern void glColor4dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glColor4f(float red, float green, float blue, float alpha);

        [DllImport(DllName)]
        public static extern void glColor4fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glColor4i(int red, int green, int blue, int alpha);

        [DllImport(DllName)]
        public static extern void glColor4iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glColor4s(short red, short green, short blue, short alpha);

        [DllImport(DllName)]
        public static extern void glColor4sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);

        [DllImport(DllName)]
        public static extern void glColor4ubv(ConstPtr<byte> v);

        [DllImport(DllName)]
        public static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);

        [DllImport(DllName)]
        public static extern void glColor4uiv(ConstPtr<uint> v);

        [DllImport(DllName)]
        public static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

        [DllImport(DllName)]
        public static extern void glColor4usv(ConstPtr<ushort> v);

        [DllImport(DllName)]
        public static extern void glColorMask(bool red, bool green, bool blue, bool alpha);

        [DllImport(DllName)]
        public static extern void glColorMaterial(GlFace face, GlMaterialMode mode);

        [DllImport(DllName)]
        public static extern void glColorPointer(int size, GlDataType type, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern void glCopyPixels(int x, int y, int width, int height, GlPixelCopyType type);

        [DllImport(DllName)]
        public static extern void glCopyTexImage1D(GlTextureTarget target, int level,
            GlTexturePixelFormat internalFormat,
            int x, int y, int width, int border);

        [DllImport(DllName)]
        public static extern void glCopyTexImage2D(GlTextureTarget target, int level,
            GlTexturePixelFormat internalFormat,
            int x, int y, int width, int height, int border);

        [DllImport(DllName)]
        public static extern void glCopyTexSubImage1D(GlTextureTarget target, int level, int xOffset, int x, int y,
            int width);

        [DllImport(DllName)]
        public static extern void glCopyTexSubImage2D(GlTextureTarget target, int level, int xOffset, int yOffset,
            int x,
            int y, int width, int height);

        [DllImport(DllName)]
        public static extern void glCullFace(GlFace mode);

        [DllImport(DllName)]
        public static extern void glDeleteLists(uint list, int range);

        [DllImport(DllName)]
        public static extern void glDeleteTextures(int n, ConstPtr<uint> textures);

        [DllImport(DllName)]
        public static extern void glDepthFunc(GlTestFunction func);

        [DllImport(DllName)]
        public static extern void glDepthMask(bool flag);

        [DllImport(DllName)]
        public static extern void glDepthRange(double zNear, double zFar);

        [DllImport(DllName)]
        public static extern void glDisable(GlCapability cap);

        [DllImport(DllName)]
        public static extern void glDisableClientState(GlArray array);

        [DllImport(DllName)]
        public static extern void glDrawArrays(GlPrimitiveKind mode, int first, int count);

        [DllImport(DllName)]
        public static extern void glDrawBuffer(GlColorBuffer mode);

        [DllImport(DllName)]
        public static extern void glDrawElements(GlPrimitiveKind mode, int count, GlDataType type,
            ConstPtr<byte> indices);

        [DllImport(DllName)]
        public static extern void glDrawPixels(int width, int height, GlDrawPixelFormat format, GlDataType type,
            ConstPtr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glEdgeFlag(bool flag);

        [DllImport(DllName)]
        public static extern void glEdgeFlagPointer(int stride, ConstPtr<bool> pointer);

        [DllImport(DllName)]
        public static extern void glEdgeFlagv(ConstPtr<bool> flag);

        [DllImport(DllName)]
        public static extern void glEnable(GlCapability cap);

        [DllImport(DllName)]
        public static extern void glEnableClientState(GlArray array);

        [DllImport(DllName)]
        public static extern void glEnd();

        [DllImport(DllName)]
        public static extern void glEndList();

        [DllImport(DllName)]
        public static extern void glEvalCoord1d(double u);

        [DllImport(DllName)]
        public static extern void glEvalCoord1dv(ConstPtr<double> u);

        [DllImport(DllName)]
        public static extern void glEvalCoord1f(float u);

        [DllImport(DllName)]
        public static extern void glEvalCoord1fv(ConstPtr<float> u);

        [DllImport(DllName)]
        public static extern void glEvalCoord2d(double u, double v);

        [DllImport(DllName)]
        public static extern void glEvalCoord2dv(ConstPtr<double> u);

        [DllImport(DllName)]
        public static extern void glEvalCoord2f(float u, float v);

        [DllImport(DllName)]
        public static extern void glEvalCoord2fv(ConstPtr<float> u);

        [DllImport(DllName)]
        public static extern void glEvalMesh1(GlEvalMeshMode mode, int i1, int i2);

        [DllImport(DllName)]
        public static extern void glEvalMesh2(GlEvalMeshMode mode, int i1, int i2, int j1, int j2);

        [DllImport(DllName)]
        public static extern void glEvalPoint1(int i);

        [DllImport(DllName)]
        public static extern void glEvalPoint2(int i, int j);

        [DllImport(DllName)]
        public static extern void glFeedbackBuffer(int size, GlFeedbackMode type, Ptr<float> buffer);

        [DllImport(DllName)]
        public static extern void glFinish();

        [DllImport(DllName)]
        public static extern void glFlush();

        [DllImport(DllName)]
        public static extern void glFogf(GlFogParam pname, float param);

        [DllImport(DllName)]
        public static extern void glFogfv(GlFogParam pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glFogi(GlFogParam pname, int param);

        [DllImport(DllName)]
        public static extern void glFogiv(GlFogParam pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glFrontFace(GlPolygonOrientation mode);

        [DllImport(DllName)]
        public static extern void glFrustum(double left, double right, double bottom, double top, double zNear,
            double zFar);

        [DllImport(DllName)]
        public static extern uint glGenLists(int range);

        [DllImport(DllName)]
        public static extern void glGenTextures(int n, Ptr<uint> textures);

        [DllImport(DllName)]
        public static extern void glGetBooleanv(GlParameter pname, Ptr<bool> @params);

        [DllImport(DllName)]
        public static extern void glGetClipPlane(GlClipPlane plane, Ptr<double> equation);

        [DllImport(DllName)]
        public static extern void glGetDoublev(GlParameter pname, Ptr<double> @params);

        [DllImport(DllName)]
        public static extern GlError glGetError();

        [DllImport(DllName)]
        public static extern void glGetFloatv(GlParameter pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetIntegerv(GlParameter pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetLightfv(uint light, GlLightParameter pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetLightiv(uint light, GlLightParameter pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetMapdv(GlMapName target, GlMapParameter query, Ptr<double> v);

        [DllImport(DllName)]
        public static extern void glGetMapfv(GlMapName target, GlMapParameter query, Ptr<float> v);

        [DllImport(DllName)]
        public static extern void glGetMapiv(GlMapName target, GlMapParameter query, Ptr<int> v);

        [DllImport(DllName)]
        public static extern void glGetMaterialfv(GlFace face, GlMaterialParameter pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetMaterialiv(GlFace face, GlMaterialParameter pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetPixelMapfv(GlPixelMap map, Ptr<float> values);

        [DllImport(DllName)]
        public static extern void glGetPixelMapuiv(GlPixelMap map, Ptr<uint> values);

        [DllImport(DllName)]
        public static extern void glGetPixelMapusv(GlPixelMap map, Ptr<ushort> values);

        [DllImport(DllName)]
        public static extern void glGetPointerv(GlPointerType pname, out nint @params);

        [DllImport(DllName)]
        public static extern void glGetPolygonStipple(Ptr<byte> mask);

        [DllImport(DllName)]
        public static extern Utf8StringPtr glGetString(GlString name);

        [DllImport(DllName)]
        public static extern void glGetTexEnvfv(uint target, GlTextureEnvParameter pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetTexEnviv(uint target, GlTextureEnvParameter pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetTexGendv(GlTextureCoord coord, GlTextureCoordParam pname, Ptr<double> @params);

        [DllImport(DllName)]
        public static extern void glGetTexGenfv(GlTextureCoord coord, GlTextureCoordParam pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetTexGeniv(GlTextureCoord coord, GlTextureCoordParam pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetTexImage(GlTextureTarget target, int level, GlGetTexturePixelFormat format,
            GlDataType type, Ptr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glGetTexLevelParameterfv(GlTextureTarget2 target, int level,
            GlTextureLevelParameter pname, Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetTexLevelParameteriv(GlTextureTarget2 target, int level,
            GlTextureLevelParameter pname, Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glGetTexParameterfv(GlTextureTarget target, GlTextureParameter pname,
            Ptr<float> @params);

        [DllImport(DllName)]
        public static extern void glGetTexParameteriv(GlTextureTarget target, GlTextureParameter pname,
            Ptr<int> @params);

        [DllImport(DllName)]
        public static extern void glHint(GlHint target, GlHintMode mode);

        [DllImport(DllName)]
        public static extern void glIndexMask(uint mask);

        [DllImport(DllName)]
        public static extern void glIndexPointer(GlDataType type, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern void glIndexd(double c);

        [DllImport(DllName)]
        public static extern void glIndexdv(ConstPtr<double> c);

        [DllImport(DllName)]
        public static extern void glIndexf(float c);

        [DllImport(DllName)]
        public static extern void glIndexfv(ConstPtr<float> c);

        [DllImport(DllName)]
        public static extern void glIndexi(int c);

        [DllImport(DllName)]
        public static extern void glIndexiv(ConstPtr<int> c);

        [DllImport(DllName)]
        public static extern void glIndexs(short c);

        [DllImport(DllName)]
        public static extern void glIndexsv(ConstPtr<short> c);

        [DllImport(DllName)]
        public static extern void glIndexub(byte c);

        [DllImport(DllName)]
        public static extern void glIndexubv(ConstPtr<byte> c);

        [DllImport(DllName)]
        public static extern void glInitNames();

        [DllImport(DllName)]
        public static extern void glInterleavedArrays(GlInterleavedArray format, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern bool glIsEnabled(GlCapability cap);

        [DllImport(DllName)]
        public static extern bool glIsList(uint list);

        [DllImport(DllName)]
        public static extern bool glIsTexture(uint texture);

        [DllImport(DllName)]
        public static extern void glLightModelf(GlLightModelParameter pname, float param);

        [DllImport(DllName)]
        public static extern void glLightModelfv(GlLightModelParameter pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glLightModeli(GlLightModelParameter pname, int param);

        [DllImport(DllName)]
        public static extern void glLightModeliv(GlLightModelParameter pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glLightf(uint light, GlLightParameter pname, float param);

        [DllImport(DllName)]
        public static extern void glLightfv(uint light, GlLightParameter pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glLighti(uint light, GlLightParameter pname, int param);

        [DllImport(DllName)]
        public static extern void glLightiv(uint light, GlLightParameter pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glLineStipple(int factor, ushort pattern);

        [DllImport(DllName)]
        public static extern void glLineWidth(float width);

        [DllImport(DllName)]
        public static extern void glListBase(uint @base);

        [DllImport(DllName)]
        public static extern void glLoadIdentity();

        [DllImport(DllName)]
        public static extern void glLoadMatrixd(ConstPtr<double> m);

        [DllImport(DllName)]
        public static extern void glLoadMatrixf(ConstPtr<float> m);

        [DllImport(DllName)]
        public static extern void glLoadName(uint name);

        [DllImport(DllName)]
        public static extern void glLogicOp(GlLogicOp opcode);

        [DllImport(DllName)]
        public static extern void glMap1d(GlMap1DValue target, double u1, double u2, int stride, int order,
            ConstPtr<double> points);

        [DllImport(DllName)]
        public static extern void glMap1f(GlMap1DValue target, float u1, float u2, int stride, int order,
            ConstPtr<float> points);

        [DllImport(DllName)]
        public static extern void glMap2d(GlMap2DValue target, double u1, double u2, int uStride, int uOrder, double v1,
            double v2, int vStride, int vOrder, ConstPtr<double> points);

        [DllImport(DllName)]
        public static extern void glMap2f(GlMap2DValue target, float u1, float u2, int uStride, int uOrder, float v1,
            float v2, int vStride, int vOrder, ConstPtr<float> points);

        [DllImport(DllName)]
        public static extern void glMapGrid1d(int un, double u1, double u2);

        [DllImport(DllName)]
        public static extern void glMapGrid1f(int un, float u1, float u2);

        [DllImport(DllName)]
        public static extern void glMapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);

        [DllImport(DllName)]
        public static extern void glMapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);

        [DllImport(DllName)]
        public static extern void glMaterialf(GlFace face, GlMaterialParameter pname, float param);

        [DllImport(DllName)]
        public static extern void glMaterialfv(GlFace face, GlMaterialParameter pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glMateriali(GlFace face, GlMaterialParameter pname, int param);

        [DllImport(DllName)]
        public static extern void glMaterialiv(GlFace face, GlMaterialParameter pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glMatrixMode(GlMatrix mode);

        [DllImport(DllName)]
        public static extern void glMultMatrixd(ConstPtr<double> m);

        [DllImport(DllName)]
        public static extern void glMultMatrixf(ConstPtr<float> m);

        [DllImport(DllName)]
        public static extern void glNewList(uint list, GlCompilationMode mode);

        [DllImport(DllName)]
        public static extern void glNormal3b(sbyte nx, sbyte ny, sbyte nz);

        [DllImport(DllName)]
        public static extern void glNormal3bv(ConstPtr<sbyte> v);

        [DllImport(DllName)]
        public static extern void glNormal3d(double nx, double ny, double nz);

        [DllImport(DllName)]
        public static extern void glNormal3dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glNormal3f(float nx, float ny, float nz);

        [DllImport(DllName)]
        public static extern void glNormal3fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glNormal3i(int nx, int ny, int nz);

        [DllImport(DllName)]
        public static extern void glNormal3iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glNormal3s(short nx, short ny, short nz);

        [DllImport(DllName)]
        public static extern void glNormal3sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glNormalPointer(GlDataType type, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern void glOrtho(double left, double right, double bottom, double top, double zNear,
            double zFar);

        [DllImport(DllName)]
        public static extern void glPassThrough(float token);

        [DllImport(DllName)]
        public static extern void glPixelMapfv(GlPixelMap map, int mapSize, ConstPtr<float> values);

        [DllImport(DllName)]
        public static extern void glPixelMapuiv(GlPixelMap map, int mapSize, ConstPtr<uint> values);

        [DllImport(DllName)]
        public static extern void glPixelMapusv(GlPixelMap map, int mapSize, ConstPtr<ushort> values);

        [DllImport(DllName)]
        public static extern void glPixelStoref(GlPixelStoreType pname, float param);

        [DllImport(DllName)]
        public static extern void glPixelStorei(GlPixelStoreType pname, int param);

        [DllImport(DllName)]
        public static extern void glPixelTransferf(GlPixelTransferParameter pname, float param);

        [DllImport(DllName)]
        public static extern void glPixelTransferi(GlPixelTransferParameter pname, int param);

        [DllImport(DllName)]
        public static extern void glPixelZoom(float xfactor, float yfactor);

        [DllImport(DllName)]
        public static extern void glPointSize(float size);

        [DllImport(DllName)]
        public static extern void glPolygonMode(GlFace face, GlPolygonMode mode);

        [DllImport(DllName)]
        public static extern void glPolygonOffset(float factor, float units);

        [DllImport(DllName)]
        public static extern void glPolygonStipple(ConstPtr<byte> mask);

        [DllImport(DllName)]
        public static extern void glPopAttrib();

        [DllImport(DllName)]
        public static extern void glPopClientAttrib();

        [DllImport(DllName)]
        public static extern void glPopMatrix();

        [DllImport(DllName)]
        public static extern void glPopName();

        [DllImport(DllName)]
        public static extern void glPrioritizeTextures(int n, ConstPtr<uint> textures, ConstPtr<float> priorities);

        [DllImport(DllName)]
        public static extern void glPushAttrib(GlAttributes mask);

        [DllImport(DllName)]
        public static extern void glPushClientAttrib(GlClientAttributes mask);

        [DllImport(DllName)]
        public static extern void glPushMatrix();

        [DllImport(DllName)]
        public static extern void glPushName(uint name);

        [DllImport(DllName)]
        public static extern void glRasterPos2d(double x, double y);

        [DllImport(DllName)]
        public static extern void glRasterPos2dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glRasterPos2f(float x, float y);

        [DllImport(DllName)]
        public static extern void glRasterPos2fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glRasterPos2i(int x, int y);

        [DllImport(DllName)]
        public static extern void glRasterPos2iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glRasterPos2s(short x, short y);

        [DllImport(DllName)]
        public static extern void glRasterPos2sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glRasterPos3d(double x, double y, double z);

        [DllImport(DllName)]
        public static extern void glRasterPos3dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glRasterPos3f(float x, float y, float z);

        [DllImport(DllName)]
        public static extern void glRasterPos3fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glRasterPos3i(int x, int y, int z);

        [DllImport(DllName)]
        public static extern void glRasterPos3iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glRasterPos3s(short x, short y, short z);

        [DllImport(DllName)]
        public static extern void glRasterPos3sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glRasterPos4d(double x, double y, double z, double w);

        [DllImport(DllName)]
        public static extern void glRasterPos4dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glRasterPos4f(float x, float y, float z, float w);

        [DllImport(DllName)]
        public static extern void glRasterPos4fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glRasterPos4i(int x, int y, int z, int w);

        [DllImport(DllName)]
        public static extern void glRasterPos4iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glRasterPos4s(short x, short y, short z, short w);

        [DllImport(DllName)]
        public static extern void glRasterPos4sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glReadBuffer(GlColorBuffer mode);

        [DllImport(DllName)]
        public static extern void glReadPixels(int x, int y, int width, int height, GlDrawPixelFormat format,
            GlDataType type, Ptr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glRectd(double x1, double y1, double x2, double y2);

        [DllImport(DllName)]
        public static extern void glRectdv(ConstPtr<double> v1, ConstPtr<double> v2);

        [DllImport(DllName)]
        public static extern void glRectf(float x1, float y1, float x2, float y2);

        [DllImport(DllName)]
        public static extern void glRectfv(ConstPtr<float> v1, ConstPtr<float> v2);

        [DllImport(DllName)]
        public static extern void glRecti(int x1, int y1, int x2, int y2);

        [DllImport(DllName)]
        public static extern void glRectiv(ConstPtr<int> v1, ConstPtr<int> v2);

        [DllImport(DllName)]
        public static extern void glRects(short x1, short y1, short x2, short y2);

        [DllImport(DllName)]
        public static extern void glRectsv(ConstPtr<short> v1, ConstPtr<short> v2);

        [DllImport(DllName)]
        public static extern int glRenderMode(GlRenderMode mode);

        [DllImport(DllName)]
        public static extern void glRotated(double angle, double x, double y, double z);

        [DllImport(DllName)]
        public static extern void glRotatef(float angle, float x, float y, float z);

        [DllImport(DllName)]
        public static extern void glScaled(double x, double y, double z);

        [DllImport(DllName)]
        public static extern void glScalef(float x, float y, float z);

        [DllImport(DllName)]
        public static extern void glScissor(int x, int y, int width, int height);

        [DllImport(DllName)]
        public static extern void glSelectBuffer(int size, Ptr<uint> buffer);

        [DllImport(DllName)]
        public static extern void glShadeModel(GlShadingMode mode);

        [DllImport(DllName)]
        public static extern void glStencilFunc(GlTestFunction func, int @ref, uint mask);

        [DllImport(DllName)]
        public static extern void glStencilMask(uint mask);

        [DllImport(DllName)]
        public static extern void glStencilOp(GlStencilOp fail, GlStencilOp zfail, GlStencilOp zpass);

        [DllImport(DllName)]
        public static extern void glTexCoord1d(double s);

        [DllImport(DllName)]
        public static extern void glTexCoord1dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glTexCoord1f(float s);

        [DllImport(DllName)]
        public static extern void glTexCoord1fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glTexCoord1i(int s);

        [DllImport(DllName)]
        public static extern void glTexCoord1iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glTexCoord1s(short s);

        [DllImport(DllName)]
        public static extern void glTexCoord1sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glTexCoord2d(double s, double t);

        [DllImport(DllName)]
        public static extern void glTexCoord2dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glTexCoord2f(float s, float t);

        [DllImport(DllName)]
        public static extern void glTexCoord2fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glTexCoord2i(int s, int t);

        [DllImport(DllName)]
        public static extern void glTexCoord2iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glTexCoord2s(short s, short t);

        [DllImport(DllName)]
        public static extern void glTexCoord2sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glTexCoord3d(double s, double t, double r);

        [DllImport(DllName)]
        public static extern void glTexCoord3dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glTexCoord3f(float s, float t, float r);

        [DllImport(DllName)]
        public static extern void glTexCoord3fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glTexCoord3i(int s, int t, int r);

        [DllImport(DllName)]
        public static extern void glTexCoord3iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glTexCoord3s(short s, short t, short r);

        [DllImport(DllName)]
        public static extern void glTexCoord3sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glTexCoord4d(double s, double t, double r, double q);

        [DllImport(DllName)]
        public static extern void glTexCoord4dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glTexCoord4f(float s, float t, float r, float q);

        [DllImport(DllName)]
        public static extern void glTexCoord4fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glTexCoord4i(int s, int t, int r, int q);

        [DllImport(DllName)]
        public static extern void glTexCoord4iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glTexCoord4s(short s, short t, short r, short q);

        [DllImport(DllName)]
        public static extern void glTexCoord4sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glTexCoordPointer(int size, GlDataType type, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern void glTexEnvf(uint target, uint pname, float param);

        [DllImport(DllName)]
        public static extern void glTexEnvfv(uint target, uint pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glTexEnvi(uint target, uint pname, GlTexEnvMode param);

        [DllImport(DllName)]
        public static extern void glTexEnviv(uint target, uint pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glTexGend(GlTextureCoord coord, GlTextureCoordParam pname, double param);

        [DllImport(DllName)]
        public static extern void glTexGendv(GlTextureCoord coord, GlTextureCoordParam pname, ConstPtr<double> @params);

        [DllImport(DllName)]
        public static extern void glTexGenf(GlTextureCoord coord, GlTextureCoordParam pname, float param);

        [DllImport(DllName)]
        public static extern void glTexGenfv(GlTextureCoord coord, GlTextureCoordParam pname, ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glTexGeni(GlTextureCoord coord, GlTextureCoordParam pname, int param);

        [DllImport(DllName)]
        public static extern void glTexGeniv(GlTextureCoord coord, GlTextureCoordParam pname, ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glTexImage1D(uint target, int level, GlTexturePixelFormat internalformat, int width,
            int border, GlDrawPixelFormat format, GlDataType type, ConstPtr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glTexImage2D(uint target, int level, GlTexturePixelFormat internalformat, int width,
            int height, int border, GlDrawPixelFormat format, GlDataType type, ConstPtr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glTexParameterf(GlTextureTarget target, GlTextureParameter pname, float param);

        [DllImport(DllName)]
        public static extern void glTexParameterfv(GlTextureTarget target, GlTextureParameter pname,
            ConstPtr<float> @params);

        [DllImport(DllName)]
        public static extern void glTexParameteri(GlTextureTarget target, GlTextureParameter pname, int param);

        [DllImport(DllName)]
        public static extern void glTexParameteriv(GlTextureTarget target, GlTextureParameter pname,
            ConstPtr<int> @params);

        [DllImport(DllName)]
        public static extern void glTexSubImage1D(uint target, int level, int xOffset, int width,
            GlDrawPixelFormat format, GlDataType type, ConstPtr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glTexSubImage2D(uint target, int level, int xOffset, int yOffset, int width,
            int height, GlDrawPixelFormat format, GlDataType type, ConstPtr<byte> pixels);

        [DllImport(DllName)]
        public static extern void glTranslated(double x, double y, double z);

        [DllImport(DllName)]
        public static extern void glTranslatef(float x, float y, float z);

        [DllImport(DllName)]
        public static extern void glVertex2d(double x, double y);

        [DllImport(DllName)]
        public static extern void glVertex2dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glVertex2f(float x, float y);

        [DllImport(DllName)]
        public static extern void glVertex2fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glVertex2i(int x, int y);

        [DllImport(DllName)]
        public static extern void glVertex2iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glVertex2s(short x, short y);

        [DllImport(DllName)]
        public static extern void glVertex2sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glVertex3d(double x, double y, double z);

        [DllImport(DllName)]
        public static extern void glVertex3dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glVertex3f(float x, float y, float z);

        [DllImport(DllName)]
        public static extern void glVertex3fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glVertex3i(int x, int y, int z);

        [DllImport(DllName)]
        public static extern void glVertex3iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glVertex3s(short x, short y, short z);

        [DllImport(DllName)]
        public static extern void glVertex3sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glVertex4d(double x, double y, double z, double w);

        [DllImport(DllName)]
        public static extern void glVertex4dv(ConstPtr<double> v);

        [DllImport(DllName)]
        public static extern void glVertex4f(float x, float y, float z, float w);

        [DllImport(DllName)]
        public static extern void glVertex4fv(ConstPtr<float> v);

        [DllImport(DllName)]
        public static extern void glVertex4i(int x, int y, int z, int w);

        [DllImport(DllName)]
        public static extern void glVertex4iv(ConstPtr<int> v);

        [DllImport(DllName)]
        public static extern void glVertex4s(short x, short y, short z, short w);

        [DllImport(DllName)]
        public static extern void glVertex4sv(ConstPtr<short> v);

        [DllImport(DllName)]
        public static extern void glVertexPointer(int size, GlDataType type, int stride, ConstPtr<byte> pointer);

        [DllImport(DllName)]
        public static extern void glViewport(int x, int y, int width, int height);

        [DllImport(DllName)]
        public static extern HGlRc wglCreateContext(HDc hdc);

        [DllImport(DllName)]
        public static extern Bool wglMakeCurrent(HDc hdc, HGlRc glRc);

        [DllImport(DllName)]
        public static extern HGlRc wglGetCurrentContext();

        [DllImport(DllName)]
        public static extern HDc wglGetCurrentDC();

        [DllImport(DllName)]
        public static extern Bool wglDeleteContext(HGlRc glRc);
    }
}