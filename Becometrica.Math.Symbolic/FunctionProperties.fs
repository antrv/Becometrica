namespace Becometrica.Math.Symbolic

type FunctionParity =
    | Unknown = 0
    | None = 1
    | Even = 2
    | Odd = 3

type FunctionArgumentProperties =
    {
        mutable Parity: FunctionParity
        mutable Derivative: (Expr list -> Expr) option
    }

type FunctionProperties =
    {
        mutable Evaluator: (Expr list -> Expr) option
        mutable Calculator: (float list -> float) option
        Arguments: FunctionArgumentProperties list
    }

module FunctionProperties =
    let create fn =
        { Evaluator = None
          Calculator = None
          Arguments = List.init fn.ArgumentCount (fun _ -> { Parity = FunctionParity.Unknown; Derivative = None }) }
