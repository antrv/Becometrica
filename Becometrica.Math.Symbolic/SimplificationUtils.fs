module private Becometrica.Math.Symbolic.SimplificationUtils

let simplifyRational x y =
    if y = 0I then
        if x > 0I then
            Infinity
        elif x.Sign < 0 then
            NegativeInfinity
        else
            Undefined
    elif x.IsZero then
        Expr.Zero
    elif y.IsOne then
        IntegerExpr x
    elif y = -1I then
        IntegerExpr -x
    else
        let gcd = bigint.GreatestCommonDivisor(x, y)
        let struct (a, b) = if y.Sign < 0 then struct (-x / gcd, -y / gcd) else struct (x / gcd, y / gcd)
        if b.IsOne then
            IntegerExpr a
        elif b = -1I then
            IntegerExpr -a
        else
            RationalExpr(a, b)

let simplifyIntegerPower (a: bigint) (b: bigint) =
    if a.IsZero then
        if b.IsZero then
            Undefined
        elif b.Sign > 0 then
            Expr.Zero
        else
            ComplexInfinity
    elif a.IsOne then
        Expr.One
    elif b.IsZero then
        Expr.One
    elif b.IsOne then
        Expr.OfInteger a
    elif b = -1I then
        if a.Sign > 0 then
            RationalExpr(1I, a)
        else
            RationalExpr(-1I, a)
    else
        let exp = bigint.Abs b
        // limit to 10 MB
        let maxExp = 25252226.3 / (a |> bigint.Abs |> bigint.Log10)
        if exp <= bigint maxExp then
            let pow = bigint.Pow(a, int exp)
            if b.Sign > 0 then
                Expr.OfInteger pow
            elif pow.Sign > 0 then
                RationalExpr(1I, pow)
            else
                RationalExpr(-1I, -pow)
        else
            let pow = Expr.Pow(Expr.OfInteger (bigint.Abs a), Expr.OfInteger exp)
            let pow1 = if b.Sign > 0 then pow else Expr.One / pow
            if a.Sign > 0 || exp.IsEven then
                pow1
            else
                -pow1

let simplifyIntegerFactorial (a: bigint) =
    if a.IsZero || a.IsOne then
        Expr.One
    elif a.Sign < 0 then
        ComplexInfinity
    elif a <= 4000000I then
        seq { 2I..a }
        |> Seq.reduce (*)
        |> Expr.OfInteger
    else
        Expr.Factorial(Expr.OfInteger a)

let tryGetNthRoot value n =
    bigint.
