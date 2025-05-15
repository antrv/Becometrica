namespace Becometrica.Interop.WinApi.Opengl32;

public enum GlMaterialMode: uint
{
    Ambient = Constants.GL_AMBIENT,
    Diffuse = Constants.GL_DIFFUSE,
    Specular = Constants.GL_SPECULAR,
    Emission = Constants.GL_EMISSION,
    AmbientAndDiffuse = Constants.GL_AMBIENT_AND_DIFFUSE,
}