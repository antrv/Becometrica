namespace Becometrica.Parsing;

[Serializable]
public struct ParsingResult<TInput, TResult>
{
    public bool Success;
    public ParserInput<TInput> Input;
    public TResult Value;
    public ParsingError? Error;

    public static implicit operator ParsingResult<TInput, TResult>(ParsingResultError<TInput> error) =>
        new() { Input = error.Input, Error = error.Error };
}
