using Becometrica.Binary;

namespace Becometrica.FileFormats;

public interface IReadableObject
{
    void ReadFrom<TReader>(ref TReader reader)
        where TReader: struct, IBitReader;
}