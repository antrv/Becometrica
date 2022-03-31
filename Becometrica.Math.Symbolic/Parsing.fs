module Becometrica.Math.Symbolic.Parsing


open System
open System.Globalization
open FParsec

[<Struct>]
type private IdentType =
    | Variable
    | Function

let private parseBigInt (str: ReadOnlySpan<char>) styles = bigint.Parse(str, styles, CultureInfo.InvariantCulture)

let private parser =
    let numberToExpr (nl: NumberLiteral) =
        let mutable span = nl.String.AsSpan()
        let mutable exponent = 0I
        let mutable fractionLength = 0
        let mutable fraction = 0I
        if nl.HasExponent then
            let exponentIndex = nl.String.IndexOf('E', StringComparison.OrdinalIgnoreCase)
            exponent <- parseBigInt (span.Slice(exponentIndex + 1)) NumberStyles.AllowLeadingSign
            span <- span.Slice(0, exponentIndex)
        if nl.HasFraction then
            let pointIndex = span.IndexOf '.'
            fractionLength <- span.Length - pointIndex - 1
            if fractionLength > 0 then
                fraction <- parseBigInt (span.Slice(pointIndex + 1)) NumberStyles.None
            span <- span.Slice(0, pointIndex)
        let integer = parseBigInt span NumberStyles.None
        let mantissa =
            if fractionLength = 0 then
                Expr.OfInteger integer
            else
                let pow10 = 10I ** fractionLength
                Expr.OfRational(integer * pow10 + fraction, pow10)
        if exponent = 0I then
            mantissa
        else
            mantissa * ((Expr.OfInteger 10) ** (Expr.OfInteger exponent))

    let numberParser: Parser<_, EvaluationContext> =
        numberLiteral (NumberLiteralOptions.AllowExponent ||| NumberLiteralOptions.AllowFraction) "number"
        |>> numberToExpr

    let identStart c = isAsciiLetter c || c = '_'
    let identContinue c = isAsciiLetter c || isDigit c || c = '_'
    let identOptions = IdentifierOptions(isAsciiIdStart = identStart, isAsciiIdContinue = identContinue)
    let identParser: Parser<_, EvaluationContext> = identifier identOptions
    let whitespacesParser: Parser<_, EvaluationContext> = spaces

    let failIfNone fn errf (p: Parser<_, _>) =
        fun stream ->
            let reply = p stream
            if reply.Status = Ok then
                match fn reply.Result stream.UserState with
                | Some x -> Reply x
                | _ -> Reply(Error, ErrorMessageList(ErrorMessage.Message(errf reply.Result)))
            else
                Reply(reply.Status, reply.Error)

    let symbolParser =
        skipChar '#'
        >>. identParser
        |> failIfNone (fun ident context -> context.Symbols.[ident]) (sprintf "Unknown symbol '#%s'")

    let constantParser =
        skipChar '@'
        >>. identParser
        |> failIfNone (fun ident context -> context.Constants.[ident]) (sprintf "Unknown symbol '@%s'")
        |>> Expr.OfConstant

    let exprParser, exprParserRef = createParserForwardedToRef<Expr, EvaluationContext>()

    let exprListParser = sepBy1 exprParser (pchar ',')

    let variableIndicesParser =
        exprListParser
        |> between (pchar '[') (pchar ']')
        |>> fun args -> (IdentType.Variable, args)

    let functionArgumentsParser =
        exprListParser
        |> between (pchar '(') (pchar ')')
        |>> fun args -> (IdentType.Function, args)

    let variableOrFunctionParser =
        identParser
        .>>. choice [functionArgumentsParser; variableIndicesParser; preturn (IdentType.Variable, [])]
        |>> fun (ident, (identType, args)) -> identType, ident, args
        |> failIfNone
               (fun (identType, ident, args) context ->
                   match identType with
                   | Variable -> Some (Expr.OfVariable (Variable.Create(ident, args)))
                   | Function -> context.Functions.[ident]
                                 |> Option.map (fun f -> Expr.OfFunction(f, args)))
               (fun (_, ident, _) -> $"Unknown function '%s{ident}'")

    let subExprParser =
        exprParser
        |> between (pchar '(') (pchar ')')

    let simpleExprParser =
        choice [numberParser; symbolParser; constantParser; subExprParser; variableOrFunctionParser]
        |> between whitespacesParser whitespacesParser

    let opp = OperatorPrecedenceParser<Expr, unit, EvaluationContext>()
    opp.TermParser <- simpleExprParser

    // Operators
    [ InfixOperator("+", spaces, 1, Associativity.Left, fun left right -> AddExpr [left; right]) :> Operator<Expr, unit, EvaluationContext>
      upcast InfixOperator("-", spaces, 1, Associativity.Left, fun left right -> SubtractExpr(left, right))
      upcast InfixOperator("*", spaces, 2, Associativity.Left, fun left right -> MultiplyExpr [left; right])
      upcast InfixOperator("/", spaces, 2, Associativity.Left, fun left right -> DivideExpr(left, right))
      upcast InfixOperator("%", spaces, 2, Associativity.Left, fun left right -> ModuloExpr(left, right))
      upcast PrefixOperator("-", spaces, 4, true, NegateExpr)
      upcast InfixOperator("^", spaces, 5, Associativity.None, fun left right -> PowerExpr(left, right))
      upcast PostfixOperator("!", spaces, 6, false, FactorialExpr)
    ]
    |> List.iter opp.AddOperator

    exprParserRef.Value <- opp.ExpressionParser
    exprParser .>> eof

let parse text context =
    let result = runParserOnString parser context "expr" text
    match result with
    | Success(expr, _, _) -> expr
    | Failure(_, error, _) -> invalidArg (nameof text) $"Invalid input expression: %O{error.Messages}"
