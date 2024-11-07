using Becometrica.Binary;

namespace Becometrica.FileFormats;

public interface IFileFormat: IReadableObject
{
    static abstract string Name { get; }
    static abstract string Extensions { get; }
    static abstract Endianness Endianness { get; }
}