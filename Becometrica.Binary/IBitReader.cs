namespace Becometrica.Binary;

public interface IBitReader
{
    int Position { get; }

    byte ReadByte();

    bool ReadBoolean();

    T ReadValue<T>()
        where T: unmanaged;

    TEnum ReadEnum<TEnum>()
        where TEnum: unmanaged, Enum;

    ushort ReadUInt16();
    short ReadInt16();
    int ReadInt32();
    uint ReadUInt32();
    long ReadInt64();
    ulong ReadUInt64();
    Int128 ReadInt128();
    UInt128 ReadUInt128();

    void ReadBytes(Span<byte> buffer);

    void Skip(int length);
}