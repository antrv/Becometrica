namespace Becometrica.Math.Symbolic

open System

[<Flags>]
type OperatorAssociativity =
    | None = 0
    | Left = 1
    | Right = 2

type OperatorKind =
    | PrefixOperator of isAssociative: bool
    | PostfixOperator of isAssociative: bool
    | InfixOperator of associativity: OperatorAssociativity

[<ReferenceEquality>]
type Operator =
    { Symbol: string; Priority: int; Kind: OperatorKind; Description: string }
    override x.ToString() = x.Symbol
    static member Create symbol priority kind description =
        { Symbol = symbol; Priority = priority; Kind = kind; Description = description }
