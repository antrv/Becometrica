namespace Becometrica.Binary;

public readonly struct NativeEndianBitConverter: IBitConverter
{
    public static T ToValue<T>(ReadOnlySpan<byte> value) where T: unmanaged =>
        BitConverterHelper.ToValueNativeEndian<T>(value);

    public static short ToInt16(ReadOnlySpan<byte> value) => ToValue<short>(value);
    public static int ToInt32(ReadOnlySpan<byte> value) => ToValue<int>(value);
    public static long ToInt64(ReadOnlySpan<byte> value) => ToValue<long>(value);
    public static Int128 ToInt128(ReadOnlySpan<byte> value) => ToValue<Int128>(value);
    public static ushort ToUInt16(ReadOnlySpan<byte> value) => ToValue<ushort>(value);
    public static uint ToUInt32(ReadOnlySpan<byte> value) => ToValue<uint>(value);
    public static ulong ToUInt64(ReadOnlySpan<byte> value) => ToValue<ulong>(value);
    public static UInt128 ToUInt128(ReadOnlySpan<byte> value) => ToValue<UInt128>(value);

    public static void WriteValue<T>(Span<byte> destination, T value)
        where T: unmanaged =>
        BitConverterHelper.WriteValueNativeEndian(destination, value);

    public static void WriteInt16(Span<byte> destination, short value) => WriteValue(destination, value);
    public static void WriteInt32(Span<byte> destination, int value) => WriteValue(destination, value);
    public static void WriteInt64(Span<byte> destination, long value) => WriteValue(destination, value);
    public static void WriteInt128(Span<byte> destination, Int128 value) => WriteValue(destination, value);
    public static void WriteUInt16(Span<byte> destination, ushort value) => WriteValue(destination, value);
    public static void WriteUInt32(Span<byte> destination, uint value) => WriteValue(destination, value);
    public static void WriteUInt64(Span<byte> destination, ulong value) => WriteValue(destination, value);
    public static void WriteUInt128(Span<byte> destination, UInt128 value) => WriteValue(destination, value);

    public static bool TryWriteValue<T>(Span<byte> destination, T value)
        where T: unmanaged =>
        BitConverterHelper.TryWriteValueNativeEndian(destination, value);

    public static bool TryWriteInt16(Span<byte> destination, short value) => TryWriteValue(destination, value);
    public static bool TryWriteInt32(Span<byte> destination, int value) => TryWriteValue(destination, value);
    public static bool TryWriteInt64(Span<byte> destination, long value) => TryWriteValue(destination, value);
    public static bool TryWriteInt128(Span<byte> destination, Int128 value) => TryWriteValue(destination, value);
    public static bool TryWriteUInt16(Span<byte> destination, ushort value) => TryWriteValue(destination, value);
    public static bool TryWriteUInt32(Span<byte> destination, uint value) => TryWriteValue(destination, value);
    public static bool TryWriteUInt64(Span<byte> destination, ulong value) => TryWriteValue(destination, value);
    public static bool TryWriteUInt128(Span<byte> destination, UInt128 value) => TryWriteValue(destination, value);
}