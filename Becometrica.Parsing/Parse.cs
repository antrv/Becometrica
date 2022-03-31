using System.Globalization;
using System.Numerics;
using System.Text;

namespace Becometrica.Parsing;

public static class Parse
{
    // Predefined parsers
    private static readonly Parser<char, string> _ident =
        Char(c => char.IsLetter(c) || c == '_', "Identifier expected")
            .Then(Char(c => char.IsLetterOrDigit(c) || c == '_', string.Empty).Many())
            .Select(t => t.Item1 + t.Item2);

    private static readonly Parser<char, string> _stringLiteral =
        Char('"').Then(Char(c => c != '"', "End of string expected").Many()).Select(t => t.Item2)
            .Then(Char('"')).Select(t => t.Item1).AtLeastOnce().Select(c => string.Join("\"", c));

    private static readonly Parser<char, string> _whitespaces =
        Char(char.IsWhiteSpace, "Whitespace expected").AtLeastOnce();

    private static readonly Parser<char, string> _digits =
        Char(c => c is >= '0' and <= '9', "Digit expected").AtLeastOnce();

    private static readonly Parser<char, string> _plusOrMinusSign =
        Char('-').Or(Char('+')).Select(c => c.ToString()).Optional(string.Empty);

    private static readonly Parser<char, string> _integer =
        _plusOrMinusSign.Then(Char(c => c is >= '0' and <= '9', "Digit expected").AtLeastOnce())
            .Select(t => t.Item1 + t.Item2);

    private static readonly Parser<char, string> _fixedPointNumber =
        _integer.Then(Char('.').Then(_digits).Select(t => t.Item1 + t.Item2).Optional(string.Empty))
            .Select(t => t.Item1 + t.Item2);

    private static readonly Parser<char, string> _floatingPointNumber =
        _fixedPointNumber.Then(Char('e', true).Then(_integer).Select(t => t.Item1 + t.Item2).Optional(string.Empty))
            .Select(t => t.Item1 + t.Item2);

    private static readonly Parser<char, float> _float = _floatingPointNumber
        .Select(f => float.Parse(f, CultureInfo.InvariantCulture)).Catch("Floating point number overflow");

    private static readonly Parser<char, double> _double = _floatingPointNumber
        .Select(f => double.Parse(f, CultureInfo.InvariantCulture)).Catch("Floating point number overflow");

    private static readonly Parser<char, int> _int32 =
        _integer.Select(integer => int.Parse(integer, CultureInfo.InvariantCulture))
            .ErrorMessage("Integer expected").Catch("Integer overflow");

    private static readonly Parser<char, long> _int64 =
        _integer.Select(integer => long.Parse(integer, CultureInfo.InvariantCulture))
            .ErrorMessage("Integer expected").Catch("Integer overflow");

    private static readonly Parser<char, BigInteger> _bigint =
        _integer.Select(integer => BigInteger.Parse(integer, CultureInfo.InvariantCulture))
            .ErrorMessage("Integer expected").Catch("Integer overflow");

    private static readonly Parser<char, string> _newLine = String("\x000D\x000A").Or(String("\x000D"),
        String("\x000A"), String("\x0085"), String("\x2028"), String("\x2029"));

    public static Parser<char, string> Ident => _ident;
    public static Parser<char, string> StringLiteral => _stringLiteral;
    public static Parser<char, string> Whitespaces => _whitespaces;
    public static Parser<char, float> Float => _float;
    public static Parser<char, double> Double => _double;
    public static Parser<char, int> Int32 => _int32;
    public static Parser<char, long> Int64 => _int64;
    public static Parser<char, BigInteger> BigInt => _bigint;
    public static Parser<char, string> NewLine => _newLine;

    public static Parser<char, char> Char(char c) => input =>
    {
        if (input.TryGet(out char ic, out ParserInput<char> next) && ic == c)
            return Success(c, next);

        return Error(input, new ParsingError
        {
            Position = input.Position,
            Message = $"'{c}' expected",
            RuleName = "Parse.Char(char)",
            ResultType = typeof(char),
        });
    };

    public static Parser<char, char> Char(char c, bool ignoreCase, CultureInfo? cultureInfo = null)
    {
        if (!ignoreCase)
            return Char(c);

        CultureInfo culture = cultureInfo ?? CultureInfo.CurrentCulture;

        char lowChar = char.ToLower(c, culture);
        char highChar = char.ToUpper(c, culture);
        if (c == lowChar && c == highChar)
            return Char(c);

        return input =>
        {
            if (input.TryGet(out char ic, out ParserInput<char> next)
                && (ic == c || ic == lowChar || ic == highChar))
            {
                return Success(ic, next);
            }

            return Error(input, new ParsingError
            {
                Position = input.Position,
                Message = $"'{c}' expected",
                RuleName = "Parse.Char(char, bool, CultureInfo)",
                ResultType = typeof(char),
            });
        };
    }

    public static Parser<char, string> String(string str)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException("Argument cannot be empty", nameof(str));

        return input =>
        {
            if (input.TryGetMany(str.Length, out ReadOnlySpan<char> items, out ParserInput<char> next)
                && items.SequenceEqual(str))
            {
                return Success(str, next);
            }

            return Error(input, new ParsingError
            {
                Position = input.Position,
                Message = $"'{str}' expected",
                RuleName = "Parse.String(string)",
                ResultType = typeof(string),
            });
        };
    }

    public static Parser<char, string> String(string str, bool ignoreCase, CultureInfo? cultureInfo = null)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException("Argument cannot be empty", nameof(str));

        if (!ignoreCase)
            return String(str);

        CultureInfo culture = cultureInfo ?? CultureInfo.CurrentCulture;
        return input =>
        {
            if (input.TryGetMany(str.Length, out ReadOnlySpan<char> items, out ParserInput<char> next))
            {
                string s = new(items);
                if (string.Compare(str, s, ignoreCase, culture) == 0)
                    return Success(str, next);
            }

            return Error(input, new ParsingError
            {
                Position = input.Position,
                Message = $"'{str}' expected",
                RuleName = "Parse.String(string, bool, CultureInfo)",
                ResultType = typeof(string),
            });
        };
    }

    public static Parser<T, T> Item<T>(Func<T, bool> predicate, string errorMessage) => input =>
    {
        if (input.TryGet(out T ic, out ParserInput<T> next) && predicate(ic))
            return Success(ic, next);

        return Error(input, new ParsingError
        {
            Position = input.Position,
            Message = errorMessage,
            RuleName = "Parse.Item(Predicate, string)",
            ResultType = typeof(T),
        });
    };

    public static Parser<char, char> Char(Func<char, bool> predicate, string errorMessage) =>
        Item(predicate, errorMessage);

    public static Parser<TInput, TInput> Error<TInput>(string errorMessage) => input => Error(input,
        new ParsingError
        {
            Position = input.Position,
            Message = errorMessage,
            RuleName = "Parse.Error(string)",
            ResultType = typeof(TInput),
        });

    public static Parser<TInput, TResult> ErrorMessage<TInput, TResult>(
        this Parser<TInput, TResult> parser, string errorMessage) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (result.Error != null)
            result.Error.Message = errorMessage;

        return result;
    };

    public static Parser<TInput, TResult> Value<TInput, TResult>(TResult value) =>
        input => Success(value, input);

    public static Parser<TInput, TResult> Catch<TInput, TResult>(this Parser<TInput, TResult> parser,
        string? errorMessage = null) => input =>
    {
        try
        {
            return parser(input);
        }
        catch (Exception exception)
        {
            return Error(input, new ParsingError
            {
                Position = input.Position,
                Message = errorMessage ?? exception.Message,
                Exception = exception,
                RuleName = "Parser.Catch(Parser, string)",
                ResultType = typeof(TResult),
            });
        }
    };

    public static Parser<TInput, TResult> Select<TInput, T, TResult>(this Parser<TInput, T> parser,
        Func<T, TResult> selector) => input =>
    {
        ParsingResult<TInput, T> result = parser(input);
        return result.Success
            ? Success(selector(result.Value), result.Input, result.Error)
            : Error(input, result.Error!);
    };

    public static Parser<TInput, (T1, T2)> Then<TInput, T1, T2>(this Parser<TInput, T1> parser,
        Parser<TInput, T2> otherParser)
    {
        return input =>
        {
            ParsingResult<TInput, T1> result = parser(input);
            if (!result.Success)
                return Error(input, result.Error!);

            ParsingResult<TInput, T2> otherResult = otherParser(result.Input);
            if (!otherResult.Success)
                return Error(input, otherResult.Error!);

            return Success((result.Value, otherResult.Value), otherResult.Input, otherResult.Error ?? result.Error);
        };
    }

    public static Parser<TInput, TResult> SelectMany<TInput, T, TOther, TResult>(
        this Parser<TInput, T> parser, Func<T, Parser<TInput, TOther>> selectFunc,
        Func<T, TOther, TResult> resultFunc) => input =>
    {
        ParsingResult<TInput, T> result = parser(input);
        if (!result.Success)
            return Error(input, result.Error!);

        ParsingResult<TInput, TOther> otherResult = selectFunc(result.Value)(result.Input);
        if (!otherResult.Success)
            return Error(input, otherResult.Error!);

        return Success(resultFunc(result.Value, otherResult.Value), otherResult.Input,
            otherResult.Error ?? result.Error);
    };

    public static Parser<TInput, TResult> Or<TInput, TResult>(this Parser<TInput, TResult> parser,
        Parser<TInput, TResult> other) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (result.Success)
            return result;

        // loop for other parsers
        ParsingResult<TInput, TResult> result1 = other(input);
        if (result1.Success)
            return result1;

        if (result1.Error!.Position > result.Error!.Position)
            result.Error = result1.Error;

        // end of loop

        return result;
    };

    public static Parser<TInput, TResult> Or<TInput, TResult>(this Parser<TInput, TResult> parser,
        Parser<TInput, TResult> other1, Parser<TInput, TResult> other2) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (result.Success)
            return result;

        // loop for other parsers
        ParsingResult<TInput, TResult> result1 = other1(input);
        if (result1.Success)
            return result1;

        if (result1.Error!.Position > result.Error!.Position)
            result.Error = result1.Error;

        result1 = other2(input);
        if (result1.Success)
            return result1;

        if (result1.Error!.Position > result.Error.Position)
            result.Error = result1.Error;

        // end of loop
        return result;
    };

    public static Parser<TInput, TResult> Or<TInput, TResult>(this Parser<TInput, TResult> parser,
        params Parser<TInput, TResult>[] others) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (result.Success)
            return result;

        // loop for other parsers
        foreach (Parser<TInput, TResult> other in others)
        {
            ParsingResult<TInput, TResult> result1 = other(input);
            if (result1.Success)
                return result1;

            if (result1.Error!.Position > result.Error!.Position)
                result = result1;
        }

        // end of loop
        return result;
    };

    public static Parser<TInput, IEnumerable<TResult>> Many<TInput, TResult>(
        this Parser<TInput, TResult> parser) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return Success(Enumerable.Empty<TResult>(), input, result.Error);

        List<TResult> list = new();
        list.Add(result.Value);

        result = parser(result.Input);
        while (result.Success)
        {
            list.Add(result.Value);
            result = parser(result.Input);
        }

        return Success(list.AsEnumerable(), result.Input, result.Error);
    };

    public static Parser<TInput, string> Many<TInput>(this Parser<TInput, char> parser) => input =>
    {
        ParsingResult<TInput, char> result = parser(input);
        if (!result.Success)
            return Success(string.Empty, input, result.Error);

        StringBuilder sb = new();
        sb.Append(result.Value);

        result = parser(result.Input);
        while (result.Success)
        {
            sb.Append(result.Value);
            result = parser(result.Input);
        }

        return Success(sb.ToString(), result.Input, result.Error);
    };

    public static Parser<TInput, string> Many<TInput>(this Parser<TInput, string> parser) => input =>
    {
        ParsingResult<TInput, string> result = parser(input);
        if (!result.Success)
            return Success(string.Empty, input, result.Error);

        StringBuilder sb = new();
        sb.Append(result.Value);

        result = parser(result.Input);
        while (result.Success)
        {
            sb.Append(result.Value);
            result = parser(result.Input);
        }

        return Success(sb.ToString(), result.Input, result.Error);
    };

    public static Parser<TInput, IEnumerable<TResult>> Many<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return Success(Enumerable.Empty<TResult>(), input, result.Error);

        List<TResult> list = new();
        list.Add(result.Value);

        ParsingResult<TInput, TSeparator> separatorResult = separatorParser(result.Input);
        while (separatorResult.Success)
        {
            result = parser(separatorResult.Input);
            if (!result.Success)
                return Success(list.AsEnumerable(), result.Input, result.Error);

            list.Add(result.Value);
            separatorResult = separatorParser(result.Input);
        }

        return Success(list.AsEnumerable(), result.Input, separatorResult.Error);
    };

    public static Parser<TInput, IEnumerable<TResult>> ManyWhen<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return Success(Enumerable.Empty<TResult>(), input, result.Error);

        List<TResult> list = new();
        list.Add(result.Value);

        ParsingResult<TInput, TSeparator> separatorResult = separatorParser(result.Input);
        while (separatorResult.Success)
        {
            result = parser(separatorResult.Input);
            if (!result.Success)
                return Error(input, result.Error!);

            list.Add(result.Value);
            separatorResult = separatorParser(result.Input);
        }

        return Success(list.AsEnumerable(), result.Input, separatorResult.Error);
    };

    public static Parser<TInput, TResult> AtLeastOnce<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser,
        Func<TResult, TSeparator, TResult, TResult> aggregationFunction) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return result;

        TResult value = result.Value;
        ParsingResult<TInput, TSeparator> separatorResult = separatorParser(result.Input);
        while (separatorResult.Success)
        {
            result = parser(separatorResult.Input);
            if (!result.Success)
                return Success(value, result.Input, result.Error);

            value = aggregationFunction(value, separatorResult.Value, result.Value);
            separatorResult = separatorParser(result.Input);
        }

        return Success(value, result.Input, separatorResult.Error);
    };

    public static Parser<TInput, TResult> AtLeastOnceWhen<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser,
        Func<TResult, TSeparator, TResult, TResult> aggregationFunction) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return result;

        TResult value = result.Value;
        ParsingResult<TInput, TSeparator> separatorResult = separatorParser(result.Input);
        while (separatorResult.Success)
        {
            result = parser(separatorResult.Input);
            if (!result.Success)
                return result;

            value = aggregationFunction(value, separatorResult.Value, result.Value);
            separatorResult = separatorParser(result.Input);
        }

        return Success(value, result.Input, separatorResult.Error);
    };

    public static Parser<TInput, IEnumerable<TResult>> AtLeastOnce<TInput, TResult>(
        this Parser<TInput, TResult> parser) =>
        parser.Then(parser.Many()).Select(t => t.Item2.Prepend(t.Item1));

    public static Parser<TInput, string> AtLeastOnce<TInput>(this Parser<TInput, char> parser) =>
        parser.Then(parser.Many()).Select(t => t.Item1 + t.Item2);

    public static Parser<TInput, IEnumerable<TResult>> AtLeastOnce<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser) =>
        parser.Then(separatorParser.Then(parser).Select(t => t.Item2).Many())
            .Select(t => t.Item2.Prepend(t.Item1));

    public static Parser<TInput, IEnumerable<TResult>> AtLeastOnceWhen<TInput, TResult, TSeparator>(
        this Parser<TInput, TResult> parser, Parser<TInput, TSeparator> separatorParser) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (!result.Success)
            return Error(input, result.Error!);

        List<TResult> list = new List<TResult>();
        list.Add(result.Value);

        ParsingResult<TInput, TSeparator> separatorResult = separatorParser(result.Input);
        while (separatorResult.Success)
        {
            result = parser(separatorResult.Input);
            if (!result.Success)
                return Error(input, result.Error!);

            list.Add(result.Value);
            separatorResult = separatorParser(result.Input);
        }

        return Success(list.AsEnumerable(), result.Input, separatorResult.Error);
    };

    public static Parser<TInput, string> AsText<TInput>(this Parser<TInput, IEnumerable<char>> parser) =>
        parser.Select(CollectChars);

    public static Parser<TInput, TResult?> Optional<TInput, TResult>(this Parser<TInput, TResult> parser) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        return Success(result.Success ? (TResult?)result.Value : default, result.Input, result.Error);
    };

    public static Parser<TInput, TResult> Optional<TInput, TResult>(this Parser<TInput, TResult> parser,
        TResult defaultValue) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        return result.Success ? result : Success(defaultValue, input, result.Error);
    };

    public static Parser<TInput, T> Ref<TInput, T>(Func<Parser<TInput, T>> parserRef) => input => parserRef()(input);

    public static Parser<TInput, TResult> EndOfInput<TInput, TResult>(this Parser<TInput, TResult> parser,
        string? errorMessage = null) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        input = result.Input;
        if (result.Success && !input.EndOfInput)
        {
            return Error(input,
                new ParsingError
                {
                    Position = input.Position,
                    Message = errorMessage ?? "End of input expected",
                    RuleName = "Eof(Parser, string)",
                    ResultType = typeof(TResult),
                });
        }

        return result;
    };

    public static Parser<TInput, TResult> Where<TInput, TResult>(this Parser<TInput, TResult> parser,
        Func<TResult, bool> predicate, string? errorMessage = null) => input =>
    {
        ParsingResult<TInput, TResult> result = parser(input);
        if (result.Success && !predicate(result.Value))
        {
            return Error(input,
                new ParsingError
                {
                    Position = input.Position,
                    Message = errorMessage ?? "Condition fails",
                    RuleName = "Where(Parser, Predicate, string)",
                    ResultType = typeof(TResult),
                });
        }

        return result;
    };

    public static Parser<TInput, T> Enclose<TInput, T, TLeft, TRight>(this Parser<TInput, T> parser,
        Parser<TInput, TLeft> leftParser, Parser<TInput, TRight> rightParser) =>
        leftParser.Then(parser).Select(t => t.Item2).Then(rightParser).Select(t => t.Item1);

    public static Parser<TInput, T> Enclose<TInput, T, TEnclosing>(this Parser<TInput, T> parser,
        Parser<TInput, TEnclosing> enclosingParser) => parser.Enclose(enclosingParser, enclosingParser);

    public static Parser<char, TResult> Trim<TResult>(this Parser<char, TResult> parser) =>
        _whitespaces.Optional().Then(parser).Select(t => t.Item2).Then(_whitespaces.Optional())
            .Select(t => t.Item1);

    private static ParsingResult<TInput, TResult> Success<TInput, TResult>(TResult result, ParserInput<TInput> input,
        ParsingError? error = null) => new() { Success = true, Input = input, Value = result, Error = error };

    private static ParsingResultError<TInput> Error<TInput>(ParserInput<TInput> input, ParsingError? error = null) =>
        new() { Input = input, Error = error };

    private static string CollectChars(IEnumerable<char> chars)
    {
        StringBuilder sb = new();
        foreach (char c in chars)
            sb.Append(c);

        return sb.ToString();
    }
}
