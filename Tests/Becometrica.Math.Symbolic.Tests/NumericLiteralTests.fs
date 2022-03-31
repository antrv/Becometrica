module Becometrica.Math.Symbolic.Tests.NumericLiteralTests

open Becometrica.Math
open Xunit

[<Fact>]
let ``MpInteger Literal``() =
    Assert.Equal(42Z, MpInteger 42)
