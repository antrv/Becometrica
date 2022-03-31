namespace Becometrica.Parsing;

public delegate ParsingResult<TInput, TResult> Parser<TInput, TResult>(ParserInput<TInput> input);
