module Becometrica.Math.Symbolic.Calculation

open System
open System.Collections.Generic

let calculate (evaluationContext: EvaluationContext) (variables: #IDictionary<_, _>) expr =
    let rec calc expr =
        match expr with
        | Undefined -> Double.NaN
        | Infinity -> Double.PositiveInfinity
        | NegativeInfinity -> Double.NegativeInfinity
        | ComplexInfinity -> Double.NaN
        | I -> Double.NaN
        | E -> Math.E
        | Pi -> Math.PI
        | ZeroPlus -> 0.0
        | ZeroMinus -> 0.0
        | IntegerExpr integer -> float integer
        | RationalExpr(n, d) -> float n / float d
        | ComplexExpr(r, i) ->
            if (calc i) <> 0.0 then
                Double.NaN
            else
                calc r
        | ConstantExpr constant ->
            constant.ApproximateValue
            |> Option.defaultWith (fun () -> constant.Name |> sprintf "Constant '%s' has no value" |> invalidOp)
        | VariableExpr var ->
            match variables.TryGetValue var with
            | true, expr -> calc expr
            | _ -> var |> sprintf "Variable '%O' not substituted" |> invalidOp
        | NegateExpr arg -> -(calc arg)
        | AddExpr addends -> List.fold (fun x y -> x + calc y) 0.0 addends
        | SubtractExpr(left, right) -> calc left - calc right
        | MultiplyExpr factors -> List.fold (fun x y -> x * calc y) 1.0 factors
        | DivideExpr(left, right) -> calc left / calc right
        | ModuloExpr(left, right) -> calc left % calc right
        | PowerExpr(left, right) -> calc left ** calc right
        | FactorialExpr _ -> invalidOp "Not implemented"
        | FunctionExpr(fn, args) ->
            evaluationContext.Properties.[fn].Calculator
            |> Option.map (fun c -> args |> List.map calc |> c)
            |> Option.defaultWith (fun () -> evaluationContext.Properties.[fn].Evaluator
                                             |> Option.map (fun e -> args |> e |> calc)
                                             |> Option.defaultWith (fun () -> fn.Name |> sprintf "Function '%s' calculation is not defined" |> invalidOp))

    calc expr
