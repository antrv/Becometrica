namespace Becometrica.Parsing;

public struct ParsingResultError<TInput>
{
    public ParserInput<TInput> Input;
    public ParsingError? Error;
}
