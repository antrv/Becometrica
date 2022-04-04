namespace rec Becometrica.Math.Symbolic

open System
open System.Collections.Generic
open System.Globalization
open System.Numerics
open System.Text
open Becometrica.Math

type Variable =
    { Name: string; Indices: Expr list }
    member x.HasIndices = x.Indices |> List.isEmpty |> not

    override x.ToString() =
        if x.HasIndices then
            let sb = StringBuilder()
            x.ToString sb
            string sb
        else
            x.Name

    member x.ToString sb =
        sb.Append x.Name |> ignore
        match x.Indices with
        | head::tail -> sb.Append "[" |> ignore
                        head.ToString sb
                        for item in tail do
                            sb.Append ", " |> ignore
                            item.ToString sb
                        sb.Append "]" |> ignore
        | _ -> ()

    static member Create name = { Name = name; Indices = List.empty }
    static member Create(name, indices) = { Name = name; Indices = indices }

type Expr =
    /// Positive zero represents something that is larger than zero and smaller than any positive real number.
    | ZeroPlus
    /// Negative zero represents something that is smaller than zero and larger than any negative real number.
    | ZeroMinus

    /// Infinity represents something that is boundless or endless or else something that is larger than any real or natural number.
    | Infinity
    /// Negative infinity represents something that is boundless or endless or else something that is smaller than any real number.
    | NegativeInfinity
    /// Complex infinity is an infinite number in the complex plane whose complex argument is unknown or undefined.
    | ComplexInfinity

    /// An expression which is not assigned an interpretation or a value.
    | Undefined
    /// The number π is a mathematical constant, defined as the ratio of a circle's circumference to its diameter.
    | Pi
    /// The number e is a mathematical constant that is the base of the natural logarithm. It is approximately equal to 2.71828
    | E
    /// The imaginary unit or unit imaginary number (i) is a solution to the quadratic equation x^2 + 1 = 0.
    | I

    | IntegerExpr of MpInteger
    | RationalExpr of MpRational
    | ConstantExpr of constant: Constant
    | ComplexExpr of real: Expr * imaginary: Expr

    | NegateExpr of arg: Expr
    | AddExpr of addends: Expr list
    | SubtractExpr of left: Expr * right: Expr
    | MultiplyExpr of factors: Expr list
    | DivideExpr of dividend: Expr * divisor: Expr
    | PowerExpr of ``base``: Expr * exponent: Expr
    | ModuloExpr of dividend: Expr * divisor: Expr
    | FactorialExpr of arg: Expr

    | VariableExpr of variable: Variable

    | FunctionExpr of fn: Function * args: Expr list

    static member Zero = IntegerExpr 0Z
    static member One = IntegerExpr 1Z
    static member MinusOne = IntegerExpr -1Z

    static member (~+) (value: Expr) = value
    static member (~-) value = NegateExpr value
    static member (+) (left, right) = AddExpr [left; right]
    static member (-) (left, right) = SubtractExpr(left, right)
    static member (*) (left, right) = MultiplyExpr [left; right]
    static member (/) (left, right) = DivideExpr(left, right)
    static member (%) (left, right) = ModuloExpr(left, right)

    static member Pow(``base``, exponent) = PowerExpr(``base``, exponent)
    static member Factorial value = FactorialExpr value

    static member OfInteger(integer: int) = new MpInteger(integer) |> IntegerExpr
    static member OfInteger(integer: uint) = new MpInteger(integer) |> IntegerExpr
    static member OfInteger(integer: int64) = new MpInteger(integer) |> IntegerExpr
    static member OfInteger(integer: uint64) = new MpInteger(integer) |> IntegerExpr
    static member OfInteger(integer: MpInteger) = IntegerExpr integer
    static member OfRational(numerator: MpInteger, denominator) = RationalExpr(new MpRational(numerator, denominator))
    static member OfComplex(real, imaginary) = ComplexExpr(real, imaginary)
    static member OfConstant constant = ConstantExpr constant
    static member OfDouble double =
        if Double.IsNaN double then
            Undefined
        elif Double.IsInfinity double then
            if Double.IsPositiveInfinity double then
                Infinity
            else
                NegativeInfinity
        elif double = 0.0 then
            Expr.Zero
        else
            let isNegative = Double.IsNegative double
            let struct(mantissa, scale) = Conversion.Grizu2.grizu2 (if isNegative then -double else double)
            let result =
                let r = Expr.OfInteger mantissa
                if isNegative then -r else r
            if scale = 0 then
                result
            else
                result * ((Expr.OfInteger 10Z) ** (Expr.OfInteger scale))

    static member OfFloat(float: single) = float |> double |> Expr.OfDouble
    static member OfDecimal decimal =
        let struct (mantissa, scale) = Conversion.decimalToMantissaAndScale decimal
        let result = Expr.OfInteger mantissa
        if scale = 0 then
            result
        else
            result / ((Expr.OfInteger 10Z) ** (Expr.OfInteger scale))

    static member OfComplex(complex: Complex) =
        ComplexExpr(complex.Real |> Expr.OfDouble, complex.Imaginary |> Expr.OfDouble)

    static member OfVariable variable = VariableExpr variable
    static member OfFunction(func: Function, arguments) =
        func.TestArgumentCount arguments
        FunctionExpr(func, arguments)

    static member op_Implicit(integer: int) = Expr.OfInteger integer
    static member op_Implicit(integer: uint) = Expr.OfInteger integer
    static member op_Implicit(integer: int64) = Expr.OfInteger integer
    static member op_Implicit(integer: uint64) = Expr.OfInteger integer
    static member op_Implicit(integer: MpInteger) = Expr.OfInteger integer
    static member op_Implicit constant = Expr.OfConstant constant
    static member op_Implicit float = Expr.OfFloat float
    static member op_Implicit double = Expr.OfDouble double
    static member op_Implicit decimal = Expr.OfDecimal decimal
    static member op_Implicit variable = Expr.OfVariable variable

    member x.ToDebugString() = $"%A{x}"

    override x.ToString() =
        let sb = StringBuilder()
        x.ToString sb
        string sb

    member x.ToString sb = Expr.ConvertToString sb x 0 false

    static member private ConvertToString sb expr priority associative =
        match expr with
        | ZeroPlus -> sb.Append "#pzero" |> ignore
        | ZeroMinus -> sb.Append "#nzero" |> ignore
        | Infinity -> sb.Append "#inf" |> ignore
        | NegativeInfinity -> sb.Append "#ninf" |> ignore
        | ComplexInfinity -> sb.Append "#cinf" |> ignore
        | Undefined -> sb.Append "#undef" |> ignore
        | Pi -> sb.Append "#pi" |> ignore
        | E -> sb.Append "#e" |> ignore
        | I -> sb.Append "#i" |> ignore
        | IntegerExpr integer ->
            if integer < 0Z then
                Expr.ConvertToString sb -(Expr.OfInteger -integer) priority associative
            else
                sb.Append (integer.ToString CultureInfo.InvariantCulture) |> ignore

        | RationalExpr(numerator, denominator) ->
            Expr.ConvertToString sb (Expr.OfInteger numerator / Expr.OfInteger denominator) priority associative

        | ConstantExpr constant -> sb.Append "@" |> ignore
                                   sb.Append constant.Name |> ignore

        | ComplexExpr(real, imaginary) -> Expr.ConvertToString sb (real + I * imaginary) priority associative

        | NegateExpr arg -> Expr.ConvertOpToString sb [arg] Operators.Negation priority associative
        | AddExpr addends -> Expr.ConvertOpToString sb addends Operators.Addition priority associative
        | SubtractExpr(left, right) -> Expr.ConvertOpToString sb [left; right] Operators.Subtraction priority associative
        | MultiplyExpr factors -> Expr.ConvertOpToString sb factors Operators.Multiplication priority associative
        | DivideExpr(left, right) -> Expr.ConvertOpToString sb [left; right] Operators.Division priority associative
        | ModuloExpr(left, right) -> Expr.ConvertOpToString sb [left; right] Operators.Modulo priority associative
        | PowerExpr(``base``, exponent) -> Expr.ConvertOpToString sb [``base``; exponent] Operators.Exponentiation priority associative
        | FactorialExpr arg ->  Expr.ConvertOpToString sb [arg] Operators.Factorial priority associative

        | VariableExpr variable -> variable.ToString sb

        | FunctionExpr(fn, args) ->
            sb.Append fn.Name |> ignore
            sb.Append "(" |> ignore
            match args with
            | head::tail ->
                Expr.ConvertToString sb head 0 false
                tail |> List.iter (fun arg -> sb.Append ", " |> ignore
                                              Expr.ConvertToString sb arg 0 false)
            | _ -> ()
            sb.Append ")" |> ignore

    static member private ConvertOpToString sb args op priority associative =
        let brackets = priority > op.Priority || (not associative && priority = op.Priority)
        if brackets then
            sb.Append "(" |> ignore

        match op.Kind with
        | PrefixOperator associative -> sb.Append op.Symbol |> ignore
                                        Expr.ConvertToString sb args.Head op.Priority associative
        | PostfixOperator associative -> Expr.ConvertToString sb args.Head op.Priority associative
                                         sb.Append op.Symbol |> ignore
        | InfixOperator associativity ->
            let associativeLeft = (associativity &&& OperatorAssociativity.Left) = OperatorAssociativity.Left
            let associativeRight = (associativity &&& OperatorAssociativity.Right) = OperatorAssociativity.Right
            match args with
            | head::tail ->
                Expr.ConvertToString sb head op.Priority associativeLeft
                tail |> List.iter (fun arg -> sb.Append " " |> ignore
                                              sb.Append op.Symbol |> ignore
                                              sb.Append " " |> ignore
                                              Expr.ConvertToString sb arg op.Priority associativeRight)
            | _ -> invalidOp "Invalid expression"

        if brackets then
            sb.Append ")" |> ignore

    member x.ContainsVariable variable =
        let rec contains expr =
            match expr with
            | VariableExpr var -> var = variable
            | NegateExpr arg -> contains arg
            | AddExpr addends -> addends |> List.exists contains
            | SubtractExpr(left, right) -> contains left || contains right
            | MultiplyExpr factors -> factors |> List.exists contains
            | DivideExpr(left, right) -> contains left || contains right
            | ModuloExpr(left, right) -> contains left || contains right
            | PowerExpr(left, right) -> contains left || contains right
            | FactorialExpr arg -> contains arg
            | FunctionExpr(_, args) -> args |> List.exists contains
            | _ -> false
        contains x

    member x.SubstituteVariable (variable: Variable) (substitution: Expr) =
        let rec substitute expr =
            match expr with
            | VariableExpr var when var = variable -> substitution
            | NegateExpr arg -> arg |> substitute |> NegateExpr
            | AddExpr addends -> AddExpr(addends |> List.map substitute)
            | SubtractExpr(left, right) -> SubtractExpr(substitute left, substitute right)
            | MultiplyExpr factors -> MultiplyExpr(factors |> List.map substitute)
            | DivideExpr(left, right) -> DivideExpr(substitute left, substitute right)
            | ModuloExpr(left, right) -> ModuloExpr(substitute left, substitute right)
            | PowerExpr(left, right) -> PowerExpr(substitute left, substitute right)
            | FactorialExpr arg -> arg |> substitute |> FactorialExpr
            | FunctionExpr(fn, args) -> FunctionExpr(fn, args |> List.map substitute)
            | _ -> expr
        substitute x

    member x.SubstituteVariables (variables: #IDictionary<_, _>) =
        let rec substitute expr =
            match expr with
            | VariableExpr var ->
                match variables.TryGetValue var with
                | true, substitution -> substitution
                | _ -> expr
            | NegateExpr arg -> arg |> substitute |> NegateExpr
            | AddExpr addends -> AddExpr(addends |> List.map substitute)
            | SubtractExpr(left, right) -> SubtractExpr(substitute left, substitute right)
            | MultiplyExpr factors -> MultiplyExpr(factors |> List.map substitute)
            | DivideExpr(left, right) -> DivideExpr(substitute left, substitute right)
            | ModuloExpr(left, right) -> ModuloExpr(substitute left, substitute right)
            | PowerExpr(left, right) -> PowerExpr(substitute left, substitute right)
            | FactorialExpr arg -> arg |> substitute |> FactorialExpr
            | FunctionExpr(fn, args) -> FunctionExpr(fn, args |> List.map substitute)
            | _ -> expr
        substitute x
