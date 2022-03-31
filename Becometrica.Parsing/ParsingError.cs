namespace Becometrica.Parsing;

[Serializable]
public sealed class ParsingError
{
    public int Position;
    public string? Message;
    public Exception? Exception;
    public string? RuleName;
    public Type? ResultType;
}
