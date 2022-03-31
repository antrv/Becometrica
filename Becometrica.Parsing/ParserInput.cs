namespace Becometrica.Parsing;

public static class ParserInput
{
    public static ParserInput<char> FromString(string s) => new(new StringSource(s), 0);
}

public readonly struct ParserInput<T>
{
    private readonly IInputSource<T> _source;
    private readonly int _position;

    public ParserInput(IInputSource<T> source, int position)
    {
        _source = source;
        _position = position;
    }

    public IInputSource<T> Source => _source;
    public int Position => _position;
    public bool EndOfInput => _source.EndOfInput(_position);

    public bool TryGet(out T item, out ParserInput<T> next)
    {
        bool result = _source.TryGet(_position, out item, out int position);
        next = new(_source, position);
        return result;
    }

    public bool TryGetMany(int count, out ReadOnlySpan<T> items, out ParserInput<T> next)
    {
        bool result = _source.TryGetMany(_position, count, out items, out int position);
        next = new(_source, position);
        return result;
    }
}
