namespace Becometrica.Math.Symbolic

open System
open System.Collections.Generic
open Funcs

[<AbstractClass>]
type ItemListBase<'T> internal () =
    let list = List()
    member _.Count = list.Count
    member _.Item with get index = list.[index]
    abstract Register: 'T -> unit
    default _.Register item = list.Add item

    member _.Contains item = list.Contains item

    interface System.Collections.IEnumerable with
        member _.GetEnumerator() = upcast list.GetEnumerator()

    interface IEnumerable<'T> with
        member _.GetEnumerator() = upcast list.GetEnumerator()

    interface IReadOnlyCollection<'T> with
        member _.Count = list.Count

    interface IReadOnlyList<'T> with
        member _.Item with get index = list.[index]

[<AbstractClass>]
type NamedItemListBase<'T> internal () =
    inherit ItemListBase<'T>()
    let dictionary = Dictionary(StringComparer.InvariantCultureIgnoreCase)
    member _.Item with get name =
        match dictionary.TryGetValue name with
        | true, fn -> Some fn
        | _ -> None
    member _.Contains name = dictionary.ContainsKey name
    abstract GetNames: 'T -> string seq
    override x.Register item =
        item
        |> x.GetNames
        |> Seq.iter (fun n -> dictionary.Add(n, item))
        base.Register item

type OperatorList() =
    inherit ItemListBase<Operator>()
    override x.Register(operator: Operator) =
        if x.Contains operator then
            invalidOp $"Operator %O{operator} already registered"
        base.Register operator

type ConstantList() =
    inherit NamedItemListBase<Constant>()
    override x.GetNames constant = seq { constant.Name }

type SymbolList() as self =
    inherit NamedItemListBase<Expr>()
    do
        self.Register ZeroPlus
        self.Register ZeroMinus
        self.Register Infinity
        self.Register NegativeInfinity
        self.Register ComplexInfinity
        self.Register Undefined
        self.Register Pi
        self.Register E
        self.Register I
    override x.GetNames symbol =
        let name =
            match symbol with
            | ZeroPlus -> "pzero"
            | ZeroMinus -> "nzero"
            | Infinity -> "inf"
            | NegativeInfinity -> "ninf"
            | ComplexInfinity -> "cinf"
            | Undefined -> "undef"
            | Pi -> "pi"
            | E -> "e"
            | I -> "i"
            | _ -> invalidOp "Invalid symbol"
        seq { name }

type FunctionList() =
    inherit NamedItemListBase<Function>()
    override x.GetNames fn = fn.GetNameAndAliases()
    override x.Register fn =
        fn.GetNameAndAliases()
        |> Seq.tryFind x.Contains
        |> Option.iter (fun n -> invalidOp $"Function '%s{n}' already registered")
        base.Register fn

type FunctionPropertiesList() =
    let dict = Dictionary()
    member _.Item with get fn =
        match dict.TryGetValue fn with
        | true, p -> p
        | _ -> let p = FunctionProperties.create fn
               dict.Add(fn, p)
               p

    member internal x.Fill() =
        let one = Expr.One
        let two = Expr.OfInteger 2

        let setEvaluator fn evaluator = x.[fn].Evaluator <- Some evaluator
        let setUnaryEvaluator (fn: Function) evaluator =
            let eval args =
                fn.TestArgumentCount args
                evaluator args.Head
            setEvaluator fn eval

        let setCalculator fn calculator = x.[fn].Calculator <- Some calculator
        let setUnaryCalculator (fn: Function) calculator =
            let eval args =
                fn.TestArgumentCount args
                calculator args.Head
            setCalculator fn eval

        let setParity fn index parity = x.[fn].Arguments.[index].Parity <- parity
        let setDerivative fn index derivative = x.[fn].Arguments.[index].Derivative <- Some derivative
        let setUnaryDerivative (fn: Function) derivative =
            let drv args =
                fn.TestArgumentCount args
                derivative args.Head
            setDerivative fn 0 drv

        // Commonly used functions
        setUnaryDerivative Functions.Sqrt (fun x -> one / (two * sqrt(x)))
        setUnaryCalculator Functions.Sqrt Math.Sqrt
        setUnaryDerivative Functions.Exp exp
        setUnaryCalculator Functions.Exp Math.Exp
        setUnaryDerivative Functions.Ln (fun x -> one / x)
        setUnaryCalculator Functions.Ln Math.Log
        setEvaluator Functions.Log (fun args -> Functions.Log.TestArgumentCount args; (ln args.[0]) / (ln args.[1]))
        setUnaryDerivative Functions.Abs (fun x -> abs(x) / x)
        setUnaryCalculator Functions.Abs Math.Abs
        setUnaryDerivative Functions.Sign (fun x -> two * delta(x))
        setUnaryCalculator Functions.Sign (fun x -> Math.Sign(x) |> float)
        // TODO: gamma, delta

        // Trigonometric functions
        setParity Functions.Sin 0 FunctionParity.Odd
        setUnaryDerivative Functions.Sin cos
        setUnaryCalculator Functions.Sin Math.Sin
        setParity Functions.Cos 0 FunctionParity.Even
        setUnaryDerivative Functions.Cos (fun x -> -sin(x))
        setUnaryCalculator Functions.Cos Math.Cos
        setUnaryCalculator Functions.Tan Math.Tan

        setUnaryEvaluator Functions.Sec (fun x -> one / cos(x))
        setUnaryEvaluator Functions.Csc (fun x -> one / sin(x))
        setUnaryEvaluator Functions.Cot (fun x -> cos(x) / sin(x))

        // Inverse trigonometric functions
        setUnaryCalculator Functions.ArcSin Math.Asin
        setUnaryCalculator Functions.ArcCos Math.Acos
        setUnaryCalculator Functions.ArcTan Math.Atan

        // Hyperbolic functions
        setUnaryCalculator Functions.Sinh Math.Sinh
        setUnaryCalculator Functions.Cosh Math.Cosh
        setUnaryCalculator Functions.Tanh Math.Tanh

        // Inverse hyperbolic functions
        setUnaryCalculator Functions.ArSinh Math.Asinh
        setUnaryCalculator Functions.ArCosh Math.Acosh
        setUnaryCalculator Functions.ArTanh Math.Atanh

        // Exsecant and excosecant trigonometric functions
        setUnaryEvaluator Functions.ExSec (fun x -> one / cos(x) - one)
        setUnaryEvaluator Functions.ExCsc (fun x -> one / sin(x) - one)
        setUnaryEvaluator Functions.ArcExSec (fun x -> arccos(one / (x + one)))
        setUnaryEvaluator Functions.ArcExCsc (fun x -> arcsin(one / (x + one)))

        // Historical functions
        setUnaryEvaluator Functions.Crd (fun x -> two * sin(x / two))
        setUnaryEvaluator Functions.Acrd (fun x -> two * arcsin(x / two))
        setUnaryEvaluator Functions.VerSin (fun x -> one - cos(x))
        setUnaryEvaluator Functions.VerCos (fun x -> one + cos(x))
        setUnaryEvaluator Functions.CoverSin (fun x -> one - sin(x))
        setUnaryEvaluator Functions.CoverCos (fun x -> one + sin(x))
        setUnaryEvaluator Functions.HaverSin (fun x -> (one - cos(x)) / two)
        setUnaryEvaluator Functions.HaverCos (fun x -> (one + cos(x)) / two)
        setUnaryEvaluator Functions.HacoverSin (fun x -> (one - sin(x)) / two)
        setUnaryEvaluator Functions.HacoverCos (fun x -> (one - cos(x)) / two)
        setUnaryEvaluator Functions.ArcVerSin (fun x -> arccos(one - x))
        setUnaryEvaluator Functions.ArcVerCos (fun x -> arccos(x - one))
        setUnaryEvaluator Functions.ArcCoverSin (fun x -> arcsin(one - x))
        setUnaryEvaluator Functions.ArcCoverCos (fun x -> arcsin(x - one))
        setUnaryEvaluator Functions.ArcHaverSin (fun x -> arccos(one - two * x))
        setUnaryEvaluator Functions.ArcHaverCos (fun x -> arccos(two * x - one))
        setUnaryEvaluator Functions.ArcHacoverSin (fun x -> arcsin(one - two * x))
        setUnaryEvaluator Functions.ArcHacoverCos (fun x -> arcsin(two * x - one))

type EvaluationContext() =
    static let globalContext = EvaluationContext()
    let symbols = SymbolList()
    let constants = ConstantList()
    let operators = OperatorList()
    let functions = FunctionList()
    let properties = FunctionPropertiesList()

    do
        Operators.AllOperators |> Seq.iter operators.Register
        Functions.AllFunctions |> Seq.iter functions.Register
        properties.Fill()

    static member Global = globalContext

    member _.Symbols = symbols
    member _.Constants = constants
    member _.Operators = operators
    member _.Functions = functions
    member _.Properties = properties
