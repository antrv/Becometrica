using System.Buffers;
using System.Runtime.CompilerServices;

namespace Becometrica.Binary;

public struct StreamBitReader<TConverter>(Stream stream): IBitReader
    where TConverter: struct, IBitConverter
{
    private int _position;

    public int Position => _position;

    public byte ReadByte()
    {
        Span<byte> buffer = stackalloc byte[1];
        stream.ReadExactly(buffer);
        _position++;
        return buffer[0];
    }

    public bool ReadBoolean() => ReadByte() != 0;

    public T ReadValue<T>()
        where T: unmanaged
    {
        Span<byte> buffer = stackalloc byte[Unsafe.SizeOf<T>()];
        ReadBytes(buffer);
        return TConverter.ToValue<T>(buffer);
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
        stream.ReadExactly(buffer);
        _position += buffer.Length;
    }

    public void Skip(int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        if (stream.CanSeek)
            stream.Seek(length, SeekOrigin.Current);
        else
        {
            const int bufferSize = 16384;
            byte[] buffer = ArrayPool<byte>.Shared.Rent(Math.Min(length, bufferSize));
            try
            {
                int count = length;
                while (count > 0)
                {
                    int bytesToRead = Math.Min(count, bufferSize);
                    stream.ReadExactly(buffer, 0, bytesToRead);
                    count -= bytesToRead;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        _position += length;
    }
}