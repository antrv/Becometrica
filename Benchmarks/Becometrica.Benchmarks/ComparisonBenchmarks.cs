using Becometrica.Math;
using BenchmarkDotNet.Attributes;

namespace Becometrica.Benchmarks;

public class ComparisonBenchmarks
{
    private const int N = 1024 * 1024;
    private readonly long[] _data;
    private readonly long _value;
    private readonly long _value2;

    public ComparisonBenchmarks()
    {
        long[] data = _data = new long[N];
        Random random = new();
        _value = random.NextInt64();
        _value2 = random.NextInt64();
        for (int i = 0; i < data.Length; i++)
            data[i] = random.NextInt64();
    }

    [Benchmark]
    public int CompareTo_RandomData()
    {
        long[] data = _data;
        long value = _value;
        int sum = 0;
        for (int i = 0; i < data.Length; i++)
            sum += value.CompareTo(data[i]);

        return sum;
    }

    [Benchmark]
    public int CompareTo_FixedData()
    {
        return _value.CompareTo(_value2);
    }

    [Benchmark]
    public int BitUtils_Compare_RandomData()
    {
        long[] data = _data;
        long value = _value;
        int sum = 0;
        for (int i = 0; i < data.Length; i++)
            sum += BitUtils.Compare(value, data[i]);

        return sum;
    }

    [Benchmark]
    public int BitUtils_Compare_FixedData()
    {
        return BitUtils.Compare(_value, _value2);
    }
}
