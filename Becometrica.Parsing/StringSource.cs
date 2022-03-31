namespace Becometrica.Parsing;

public sealed class StringSource: IInputSource<char>
{
    private readonly string _input;

    public StringSource(string input)
    {
        _input = input;
    }

    public bool EndOfInput(int position) => position >= _input.Length;

    public bool TryGet(int position, out char item, out int next)
    {
        if (position < _input.Length)
        {
            item = _input[position];
            next = position + 1;
            return true;
        }

        item = default;
        next = position;
        return false;
    }

    public bool TryGetMany(int position, int count, out ReadOnlySpan<char> items, out int next)
    {
        if (position + count <= _input.Length)
        {
            items = _input.AsSpan(position, count);
            next = position + count;
            return true;
        }

        items = default;
        next = position;
        return false;
    }
}
