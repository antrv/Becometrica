module Becometrica.Math.Symbolic.Functions

module Categories =

    [<Literal>]
    let Common = "Commonly used functions"

    [<Literal>]
    let Trigonometry = "Trigonometric functions"

    [<Literal>]
    let InverseTrigonometry = "Inverse trigonometric functions"

    [<Literal>]
    let ExTrigonometry = "Exsecant and excosecant trigonometric functions"

    [<Literal>]
    let Hyperbolic = "Hyperbolic functions"

    [<Literal>]
    let InverseHyperbolic = "Inverse hyperbolic functions"

    [<Literal>]
    let HistoricTrigonometry = "Historical functions"

// Commonly used functions
let Sqrt = Function.Create Categories.Common "sqrt" [] 1 "Square root function"
let Exp = Function.Create Categories.Common "exp" [] 1 "Exponential function"
let Ln = Function.Create Categories.Common "ln" [] 1 "Natural logarithm function"
let Log = Function.Create Categories.Common "log" [] 2 "Logarithm function with custom base"
let Abs = Function.Create Categories.Common "abs" [] 1 "The absolute value or modulus is the non-negative value without regard to its sign."
let Sign = Function.Create Categories.Common "sign" ["sgn"] 1 "The sign of the value: -1, 0 or 1."
let Gamma = Function.Create Categories.Common "gamma" ["Γ"] 1 "The gamma function is one commonly used extension of the factorial function to complex numbers"
let Delta = Function.Create Categories.Common "delta" ["δ"] 1 "The Dirac delta function (δ function) is a function to model the density of an idealized point mass or point charge as a function equal to zero everywhere except for zero and whose integral over the entire real line is equal to one."

// Trigonometric functions
let Sin = Function.Create Categories.Trigonometry "sin" [] 1 "Trigonometric sine function"
let Cos = Function.Create Categories.Trigonometry "cos" [] 1 "Trigonometric cosine function"
let Tan = Function.Create Categories.Trigonometry "tan" ["tg"] 1 "Trigonometric tangent function"
let Cot = Function.Create Categories.Trigonometry "cot" ["cotan"; "cotg"; "ctg"; "ctn"] 1 "Trigonometric cotangent function"
let Sec = Function.Create Categories.Trigonometry "sec" [] 1 "Trigonometric secant function"
let Csc = Function.Create Categories.Trigonometry "csc" ["cosec"] 1 "Trigonometric cosecant function"

// Inverse trigonometric functions
let ArcSin = Function.Create Categories.InverseTrigonometry "arcsin" [] 1 "Inverse trigonometric sine function"
let ArcCos = Function.Create Categories.InverseTrigonometry "arccos" [] 1 "Inverse trigonometric cosine function"
let ArcTan = Function.Create Categories.InverseTrigonometry "arctan" ["arctg"] 1 "Inverse trigonometric tangent function"
let ArcCot = Function.Create Categories.InverseTrigonometry "arccot" ["arccotan"; "arccotg"; "arcctg"; "arcctn"] 1 "Inverse trigonometric cotangent function"
let ArcSec = Function.Create Categories.InverseTrigonometry "arcsec" [] 1 "Inverse trigonometric secant function"
let ArcCsc = Function.Create Categories.InverseTrigonometry "arccsc" ["arccosec"] 1 "Inverse trigonometric cosecant function"

// Exsecant and excosecant trigonometric functions
let ExSec = Function.Create Categories.ExTrigonometry "exsec" ["exs"] 1 "Trigonometric exsecant (outer secant) function"
let ExCsc = Function.Create Categories.ExTrigonometry "excsc" ["excosec"; "coexsec"; "exc"] 1 "Trigonometric excosecant (outer cosecant) function"
let ArcExSec = Function.Create Categories.ExTrigonometry "arcexsec" ["aexsec"; "aexs"] 1 "Inverse trigonometric exsecant (outer secant) function"
let ArcExCsc = Function.Create Categories.ExTrigonometry "arcexcsc" ["arcexcosec"; "aexcsc"; "aexc"; "arccoexsecant"; "arccoexsec"] 1 "Inverse trigonometric excosecant (outer cosecant) function"

// Hyperbolic functions
let Sinh = Function.Create Categories.Hyperbolic "sinh" ["sh"] 1 "Hyperbolic sine function"
let Cosh = Function.Create Categories.Hyperbolic "cosh" ["ch"] 1 "Hyperbolic cosine function"
let Tanh = Function.Create Categories.Hyperbolic "tanh" ["th"] 1 "Hyperbolic tangent function"
let Coth = Function.Create Categories.Hyperbolic "coth" ["cth"] 1 "Hyperbolic cotangent function"
let Sech = Function.Create Categories.Hyperbolic "sech" ["sch"] 1 "Hyperbolic secant function"
let Csch = Function.Create Categories.Hyperbolic "csch" ["cosech"] 1 "Hyperbolic cosecant function"

// Inverse hyperbolic functions
let ArSinh = Function.Create Categories.InverseHyperbolic "arsinh" ["arsh"] 1 "Inverse hyperbolic sine function"
let ArCosh = Function.Create Categories.InverseHyperbolic "arcosh" ["arch"] 1 "Inverse hyperbolic cosine function"
let ArTanh = Function.Create Categories.InverseHyperbolic "artanh" ["arth"] 1 "Inverse hyperbolic tangent function"
let ArCoth = Function.Create Categories.InverseHyperbolic "arcoth" ["arcth"] 1 "Inverse hyperbolic cotangent function"
let ArSech = Function.Create Categories.InverseHyperbolic "arsech" ["arsch"] 1 "Inverse hyperbolic secant function"
let ArCsch = Function.Create Categories.InverseHyperbolic "arcsch" ["arcosech"] 1 "Inverse hyperbolic cosecant function"

// Historical functions
let Crd = Function.Create Categories.HistoricTrigonometry "crd" [] 1 "Historical trigonometric chord. crd(x) = 2 * sin(x / 2)"
let Acrd = Function.Create Categories.HistoricTrigonometry "acrd" [] 1 "Historical inverse trigonometric chord. acrd(x) = 2 * arcsin(x / 2)"
let VerSin = Function.Create Categories.HistoricTrigonometry "versin" ["sinver"; "vers"; "ver"; "siv"] 1 "Historical trigonometric versed sine. versin(x) = 1 - cos(x)"
let VerCos = Function.Create Categories.HistoricTrigonometry "vercos" ["vercosin"; "vcs"] 1 "Historical trigonometric versed cosine. vercos(x) = 1 + cos(x)"
let CoverSin = Function.Create Categories.HistoricTrigonometry "coversin" ["covers"; "cosiv"; "cvs"] 1 "Historical trigonometric coversed sine. coversin(x) = 1 - sin(x)"
let CoverCos = Function.Create Categories.HistoricTrigonometry "covercos" ["covercosin"; "cvc"] 1 "Historical trigonometric coversed cosine. covercos(x) = 1 + sin(x)"
let HaverSin = Function.Create Categories.HistoricTrigonometry "haversin" ["semiversin"; "semiversinus"; "havers"; "hav"; "hvs"; "sem"; "hv"] 1 "Historical trigonometric half-value versed sine. haversin(x) = (1 - cos(x)) / 2"
let HaverCos = Function.Create Categories.HistoricTrigonometry "havercos" ["havercosin"; "hac"; "hvc"] 1 "Historical trigonometric half-value versed cosine. havercos(x) = (1 + cos(x)) / 2"
let HacoverSin = Function.Create Categories.HistoricTrigonometry "hacoversin" ["semicoversin"; "hacovers"; "hacov"; "hcv"] 1 "Historical trigonometric half-value coversed sine. hacoversin(x) = (1 - sin(x)) / 2"
let HacoverCos = Function.Create Categories.HistoricTrigonometry "hacovercos" ["hacovercosin"; "hcc"] 1 "Historical trigonometric half-value coversed cosine. hacovercos(x) = (1 + sin(x)) / 2"
let ArcVerSin = Function.Create Categories.HistoricTrigonometry "arcversin" ["arcvers"; "avers"; "aver"] 1 "Historical inverse trigonometric versed sine. arcversin(x) = arccos(1 - x)"
let ArcVerCos = Function.Create Categories.HistoricTrigonometry "arcvercos" ["arcvercosin"; "avercos"; "avcs"] 1 "Historical inverse trigonometric versed cosine. arcvercos(x) = arccos(x - 1)"
let ArcCoverSin = Function.Create Categories.HistoricTrigonometry "arccoversin" ["arccovers"; "acovers"; "acvs"] 1 "Historical inverse trigonometric coversed sine. arccoversin(x) = arcsin(1 - x)"
let ArcCoverCos = Function.Create Categories.HistoricTrigonometry "arccovercos" ["arccovercosin"; "acovercos"; "acvc"] 1 "Historical inverse trigonometric coversed cosine. arccovercos(x) = arcsin(x - 1)"
let ArcHaverSin = Function.Create Categories.HistoricTrigonometry "archaversin" ["archav"; "invhav"; "ahav"; "ahvs"; "ahv"] 1 "Historical inverse trigonometric half-value versed sine. archaversin(x) = arccos(1 - 2 * x)"
let ArcHaverCos = Function.Create Categories.HistoricTrigonometry "archavercos" ["archavercosin"; "ahvc"] 1 "Historical inverse trigonometric half-value versed cosine. archavercos(x) = arccos(2 * x - 1)"
let ArcHacoverSin = Function.Create Categories.HistoricTrigonometry "archacoversin" ["ahcv"] 1 "Historical inverse trigonometric half-value coversed sine. archacoversin(x) = arcsin(1 - 2 * x)"
let ArcHacoverCos = Function.Create Categories.HistoricTrigonometry "archacovercos" ["archacovercosin"; "ahcc"] 1 "Historical inverse trigonometric half-value coversed cosine. archacovercos(x) = arcsin(2 * x - 1)"


let AllFunctions = [
    // Commonly used functions
    Sqrt
    Exp
    Ln
    Log
    Abs
    Sign
    Gamma
    Delta

    // Trigonometric functions
    Sin
    Cos
    Tan
    Cot
    Sec
    Csc

    // Inverse trigonometric functions
    ArcSin
    ArcCos
    ArcTan
    ArcCot
    ArcSec
    ArcCsc

    // Exsecant and excosecant trigonometric functions
    ExSec
    ExCsc
    ArcExSec
    ArcExCsc

    // Hyperbolic functions
    Sinh
    Cosh
    Tanh
    Coth
    Sech
    Csch

    // Inverse hyperbolic functions
    ArSinh
    ArCosh
    ArTanh
    ArCoth
    ArSech
    ArCsch

    // Historical functions
    Crd
    Acrd
    VerSin
    VerCos
    CoverSin
    CoverCos
    HaverSin
    HaverCos
    HacoverSin
    HacoverCos
    ArcVerSin
    ArcVerCos
    ArcCoverSin
    ArcCoverCos
    ArcHaverSin
    ArcHaverCos
    ArcHacoverSin
    ArcHacoverCos ]
