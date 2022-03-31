module Becometrica.Math.Symbolic.Tests.SimplificationTests

open Becometrica.Math.Symbolic
open Xunit

let private parseExpr expr =
    let context = EvaluationContext.Global
    let expr = Parsing.parse expr context
    Simplification.simplify context expr

[<Fact>]
let ``Does operations on numbers like a calculator``() =
    let expected = Expr.OfInteger 15I
    Assert.Equal(expected, parseExpr "5 * (9 - 3) / 2")

[<Fact>]
let ``Uses exact rational arithmetic``() =
    let expected = Expr.OfRational(2I, 3I)
    Assert.Equal(expected, parseExpr "1/2 + 1/6")

[<Fact>]
let ``Uses as many digits as necessary for exact arithmetic``() =
    let expected = Expr.OfInteger 1577721810442023610823457130565572459346412870218046009540557861328125I
    Assert.Equal(expected, parseExpr "5^99")

    let expected2 = Expr.OfInteger 230843697339241380472092742683027581083278564571807941132288000000000000I
    Assert.Equal(expected2, parseExpr "54!")

[<Fact>]
let ``Simplifies fractional powers``() =
    let expected = Expr.Pow(Expr.OfInteger 2I, Expr.OfRational(2I, 3I)) / Expr.OfInteger 9I
    Assert.Equal(expected, parseExpr "(2/27)^(2/3)")
