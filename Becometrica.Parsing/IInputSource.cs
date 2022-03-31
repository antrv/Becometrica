namespace Becometrica.Parsing;

public interface IInputSource<T>
{
    bool EndOfInput(int position);
    bool TryGet(int position, out T item, out int nextPosition);
    bool TryGetMany(int position, int count, out ReadOnlySpan<T> items, out int nextPosition);
}
