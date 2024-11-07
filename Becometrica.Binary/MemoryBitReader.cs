using System.Runtime.CompilerServices;

namespace Becometrica.Binary;

public struct MemoryBitReader<TConverter>(ReadOnlyMemory<byte> source): IBitReader
    where TConverter: struct, IBitConverter
{
    private ReadOnlyMemory<byte> _source = source;
    private int _position;

    public int Position => _position;
    public int Length => _source.Length;

    public byte ReadByte()
    {
        byte result = _source.Span[0];
        _source = _source[1..];
        _position++;
        return result;
    }

    public bool ReadBoolean() => ReadByte() != 0;

    public T ReadValue<T>()
        where T: unmanaged
    {
        T result = TConverter.ToValue<T>(_source.Span);
        _source = _source[Unsafe.SizeOf<T>()..];
        _position += Unsafe.SizeOf<T>();
        return result;
    }

    public TEnum ReadEnum<TEnum>()
        where TEnum: unmanaged, Enum => ReadValue<TEnum>();

    public ushort ReadUInt16() => ReadValue<ushort>();
    public short ReadInt16() => ReadValue<short>();
    public int ReadInt32() => ReadValue<int>();
    public uint ReadUInt32() => ReadValue<uint>();
    public long ReadInt64() => ReadValue<long>();
    public ulong ReadUInt64() => ReadValue<ulong>();
    public Int128 ReadInt128() => ReadValue<Int128>();
    public UInt128 ReadUInt128() => ReadValue<UInt128>();

    public void ReadBytes(Span<byte> buffer)
    {
        _source.Span[..buffer.Length].CopyTo(buffer);
        _source = _source[buffer.Length..];
        _position += buffer.Length;
    }

    public void Skip(int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        _source = _source[length..];
        _position += length;
    }
}