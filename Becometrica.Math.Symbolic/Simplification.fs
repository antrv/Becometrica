module rec Becometrica.Math.Symbolic.Simplification

open Becometrica.Math.Symbolic
open SimplificationUtils

let private simplifyComplex evaluationContext r i =
    match r, i with
    | Undefined, _
    | _, Undefined -> Undefined
    | _, (Infinity | NegativeInfinity | ComplexInfinity) -> ComplexInfinity
    | _, IntegerExpr x when x.IsZero -> r
    | I, I -> ComplexExpr(Expr.MinusOne, Expr.One)
    | I, _ -> simplify evaluationContext (ComplexExpr(Expr.Zero, r + Expr.One))
    | _, I -> simplify evaluationContext (r - Expr.One)
    | ComplexExpr(a, b), ComplexExpr(c, d) -> simplify evaluationContext (ComplexExpr(a - d, b + c))
    | ComplexExpr(a, b), _ -> simplify evaluationContext (ComplexExpr(a, b + i))
    | _, ComplexExpr(a, b) -> simplify evaluationContext (ComplexExpr(r - b, a))
    | _ -> ComplexExpr(r, i)

let private simplifyNegate x =
    match x with
    | ZeroPlus -> ZeroMinus
    | ZeroMinus -> ZeroPlus
    | Undefined -> Undefined
    | ComplexInfinity -> ComplexInfinity
    | Infinity -> NegativeInfinity
    | NegativeInfinity -> Infinity
    | I -> ComplexExpr(Expr.Zero, Expr.MinusOne)
    | IntegerExpr x -> IntegerExpr -x
    | RationalExpr(x, y) -> RationalExpr(-x, y)
    | ComplexExpr(r, i) -> ComplexExpr(-r, -i)
    | NegateExpr arg -> arg
    | AddExpr addends -> AddExpr(addends |> List.map (~-))
    | SubtractExpr(left, right) -> SubtractExpr(right, left)
    | _ -> -x

let private simplifyAdd2 evaluationContext x y =
    match x, y with
    | Undefined, _
    | _, Undefined
    | Infinity, NegativeInfinity
    | NegativeInfinity, Infinity -> Undefined
    | Infinity, Infinity -> Infinity
    | NegativeInfinity, NegativeInfinity -> NegativeInfinity
    | (Infinity | NegativeInfinity), ComplexInfinity
    | ComplexInfinity, (Infinity | NegativeInfinity)
    | ComplexInfinity, ComplexInfinity -> ComplexInfinity
    | ZeroPlus, ZeroPlus -> ZeroPlus
    | ZeroMinus, ZeroMinus -> ZeroMinus
    | ZeroPlus, ZeroMinus
    | ZeroMinus, ZeroPlus -> Expr.Zero
    | IntegerExpr a, _ when a.IsZero -> y
    | _, IntegerExpr a when a.IsZero -> x
    | ComplexExpr(r, i), ComplexExpr(r1, i1) -> simplifyComplex evaluationContext (r + r1) (i + i1)
    | ComplexExpr(r, i), _ -> simplifyComplex evaluationContext (r + y) i
    | _, ComplexExpr(r, i) -> simplifyComplex evaluationContext (x + r) i
    | IntegerExpr a, IntegerExpr b -> IntegerExpr(a + b)
    | IntegerExpr a, RationalExpr(b, c) -> simplifyRational (a * c + b) c
    | RationalExpr(a, b), IntegerExpr c -> simplifyRational (a + c * b) b
    | RationalExpr(a, b), RationalExpr(c, d) -> simplifyRational (a * d + c * b) (b * d)
    | _ -> x + y

let private simplifyAdd evaluationContext addends =
    match addends with
    | head::tail -> List.fold (simplifyAdd2 evaluationContext) head tail
    | _ -> invalidOp "Invalid expression"

let private simplifySubtract evaluationContext x y =
    match x, y with
    | Undefined, _
    | _, Undefined
    | Infinity, Infinity
    | NegativeInfinity, NegativeInfinity
    | ComplexInfinity, ComplexInfinity -> Undefined
    | Infinity, NegativeInfinity -> Infinity
    | NegativeInfinity, Infinity -> NegativeInfinity
    | ZeroPlus, ZeroMinus -> ZeroPlus
    | ZeroMinus, ZeroPlus -> ZeroMinus
    | ZeroPlus, ZeroPlus
    | ZeroMinus, ZeroMinus -> Expr.Zero
    | IntegerExpr a, _ when a.IsZero -> simplifyNegate -y
    | _, IntegerExpr a when a.IsZero -> x
    | ComplexExpr(r, i), ComplexExpr(r1, i1) -> simplifyComplex evaluationContext (r - r1) (i - i1)
    | ComplexExpr(r, i), _ -> simplifyComplex evaluationContext (r - y) i
    | _, ComplexExpr(r, i) -> simplifyComplex evaluationContext (x - r) -i
    | IntegerExpr a, IntegerExpr b -> IntegerExpr(a - b)
    | IntegerExpr a, RationalExpr(b, c) -> simplifyRational (a * c - b) c
    | RationalExpr(a, b), IntegerExpr c -> simplifyRational (a - c * b) b
    | RationalExpr(a, b), RationalExpr(c, d) -> simplifyRational (a * d - c * b) (b * d)
    | _ -> x - y

let private simplifyMul2 evaluationContext x y =
    match x, y with
    | Undefined, _
    | _, Undefined
    | Infinity, NegativeInfinity
    | NegativeInfinity, Infinity -> NegativeInfinity
    | Infinity, Infinity
    | NegativeInfinity, NegativeInfinity -> Infinity
    | (Infinity | NegativeInfinity), ComplexInfinity
    | ComplexInfinity, (Infinity | NegativeInfinity)
    | ComplexInfinity, ComplexInfinity -> ComplexInfinity
    | ZeroPlus, ZeroPlus
    | ZeroMinus, ZeroMinus -> ZeroPlus
    | ZeroPlus, ZeroMinus
    | ZeroMinus, ZeroPlus -> ZeroMinus
    | IntegerExpr a, (Infinity | NegativeInfinity | ComplexInfinity) when a.IsZero -> Undefined
    | (Infinity | NegativeInfinity | ComplexInfinity), IntegerExpr a when a.IsZero -> Undefined
    | IntegerExpr a, _ when a.IsZero -> Expr.Zero
    | _, IntegerExpr a when a.IsZero -> Expr.Zero
    | ComplexExpr(r, i), ComplexExpr(r1, i1) -> simplifyComplex evaluationContext (r * r1 - i * i1) (r * i1 + r1 * i)
    | ComplexExpr(r, i), _ -> simplifyComplex evaluationContext (r * y) (i * y)
    | _, ComplexExpr(r, i) -> simplifyComplex evaluationContext (x * r) (x * i)
    | IntegerExpr a, IntegerExpr b -> IntegerExpr(a * b)
    | IntegerExpr a, RationalExpr(b, c) -> simplifyRational (a * b) c
    | RationalExpr(a, b), IntegerExpr c -> simplifyRational (a * c) b
    | RationalExpr(a, b), RationalExpr(c, d) -> simplifyRational (a * c) (b * d)
    | _ -> x * y

let private simplifyDivide evaluationContext x y =
    match x, y with
    | Undefined, _
    | _, Undefined -> Undefined
    | (Infinity | NegativeInfinity | ComplexInfinity), (Infinity | NegativeInfinity | ComplexInfinity) -> Undefined
    | (ZeroPlus | ZeroMinus), (ZeroPlus | ZeroMinus) -> Undefined
    | ComplexExpr(r, i), ComplexExpr(r1, i1) -> simplifyComplex evaluationContext (r * r1 - i * i1) (r * i1 + r1 * i)
    | ComplexExpr(r, i), _ -> simplifyComplex evaluationContext (r * y) (i * y)
    | _, ComplexExpr(r, i) -> simplifyComplex evaluationContext (x * r) (x * i)
    | IntegerExpr a, IntegerExpr b -> simplifyRational a b
    | IntegerExpr a, RationalExpr(b, c) -> simplifyRational (a * c) b
    | RationalExpr(a, b), IntegerExpr c -> simplifyRational a (b * c)
    | RationalExpr(a, b), RationalExpr(c, d) -> simplifyRational (a * d) (b * c)
    | _ -> x / y

let private simplifyMul evaluationContext factors =
    match factors with
    | head::tail -> List.fold (simplifyMul2 evaluationContext) head tail
    | _ -> invalidOp "Invalid expression"

let private simplifyPower evaluationContext x y =
    match x, y with
    | Undefined, _
    | _, Undefined -> Undefined
    | Infinity, Infinity -> Infinity
    | (Infinity | NegativeInfinity), NegativeInfinity -> Expr.Zero
    | NegativeInfinity, (Infinity | NegativeInfinity) -> Undefined
    | (ZeroPlus | ZeroMinus), (ZeroPlus | ZeroMinus) -> Undefined
    | IntegerExpr a, IntegerExpr b -> simplifyIntegerPower a b
    | IntegerExpr a, RationalExpr(b, c) ->
    | RationalExpr(a, b), _ -> simplifyDivide evaluationContext (Expr.Pow(a, y)) (Expr.Pow(b, y))
    | _ -> Expr.Pow(x, y)

let private simplifyFactorial evaluationContext x =
    match x with
    | Undefined -> Undefined
    | NegativeInfinity -> Undefined
    | Infinity -> Infinity
    | ComplexInfinity -> ComplexInfinity
    | IntegerExpr a -> simplifyIntegerFactorial a
    | _ -> Expr.Factorial x

let simplify (evaluationContext: EvaluationContext) expr =
    match expr with
    | RationalExpr(x, y) -> simplifyRational x y
    | ComplexExpr(r, i) ->
        simplifyComplex evaluationContext (simplify evaluationContext r) (simplify evaluationContext i)

    | NegateExpr arg -> simplifyNegate (simplify evaluationContext arg)
    | AddExpr addends -> simplifyAdd evaluationContext (addends |> List.map (simplify evaluationContext))
    | SubtractExpr(left, right) ->
        simplifySubtract evaluationContext (simplify evaluationContext left) (simplify evaluationContext right)

    | MultiplyExpr factors -> simplifyMul evaluationContext (factors |> List.map (simplify evaluationContext))

    | DivideExpr(left, right) ->
        simplifyDivide evaluationContext (simplify evaluationContext left) (simplify evaluationContext right)

    | PowerExpr(``base``, exponent) ->
        simplifyPower evaluationContext (simplify evaluationContext ``base``) (simplify evaluationContext exponent)

    | FactorialExpr expr -> simplifyFactorial evaluationContext (simplify evaluationContext expr)

    | FunctionExpr(fn, args) ->
        evaluationContext.Properties.[fn].Evaluator
        |> Option.map (fun evaluator -> simplify evaluationContext (evaluator args))
        |> Option.defaultValue expr

    | _ -> expr
