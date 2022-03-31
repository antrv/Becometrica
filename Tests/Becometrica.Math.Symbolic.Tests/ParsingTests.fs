module Becometrica.Math.Symbolic.Tests.ParsingTests

open System
open Becometrica.Math.Symbolic
open Becometrica.Math.Symbolic.Funcs
open Xunit

let private parseExpr expr = Parsing.parse expr EvaluationContext.Global

[<Fact>]
let ``Parse integer``() =
    Assert.Equal(parseExpr "1", Expr.OfInteger 1I)

[<Fact>]
let ``Parse variable``() =
    Assert.Equal(parseExpr "a", Expr.OfVariable(Variable.Create "a"))

[<Fact>]
let ``Parse power expression``() =
    Assert.Equal(parseExpr "5^99", PowerExpr(Expr.OfInteger 5I, Expr.OfInteger 99I))

[<Fact>]
let ``Parse factorial expression``() =
    Assert.Equal(parseExpr "54!", Expr.Factorial(Expr.OfInteger 54I))

[<Fact>]
let ``Parse function expression``() =
    Assert.Equal(parseExpr "sqrt(9)", sqrt(Expr.OfInteger 9I))

[<Fact>]
let ``Parse symbols``() =
    Assert.Equal(parseExpr "#i", Expr.I)
    Assert.Equal(parseExpr "#e", Expr.E)
    Assert.Equal(parseExpr "#pi", Expr.Pi)
    Assert.Equal(parseExpr "#undef", Expr.Undefined)
    Assert.Equal(parseExpr "#inf", Expr.Infinity)
    Assert.Equal(parseExpr "#ninf", Expr.NegativeInfinity)
    Assert.Equal(parseExpr "#cinf", Expr.ComplexInfinity)
    Assert.Equal(parseExpr "#pzero", Expr.ZeroPlus)
    Assert.Equal(parseExpr "#nzero", Expr.ZeroMinus)
