module Becometrica.Math.Symbolic.Funcs

// Commonly used functions

let sqrt x = Expr.OfFunction(Functions.Sqrt, [x])
let exp x = Expr.OfFunction(Functions.Exp, [x])
let ln x = Expr.OfFunction(Functions.Ln, [x])
let log x y = Expr.OfFunction(Functions.Log, [x; y])
let abs x = Expr.OfFunction(Functions.Abs, [x])
let sign x = Expr.OfFunction(Functions.Sign, [x])
let gamma x = Expr.OfFunction(Functions.Gamma, [x])
let delta x = Expr.OfFunction(Functions.Delta, [x])

// Trigonometric functions

let sin x = Expr.OfFunction(Functions.Sin, [x])
let cos x = Expr.OfFunction(Functions.Cos, [x])
let tan x = Expr.OfFunction(Functions.Tan, [x])
let cot x = Expr.OfFunction(Functions.Cot, [x])
let sec x = Expr.OfFunction(Functions.Sec, [x])
let csc x = Expr.OfFunction(Functions.Csc, [x])

// Inverse trigonometric functions

let arcsin x = Expr.OfFunction(Functions.ArcSin, [x])
let arccos x = Expr.OfFunction(Functions.ArcCos, [x])
let arctan x = Expr.OfFunction(Functions.ArcTan, [x])
let arccot x = Expr.OfFunction(Functions.ArcCot, [x])
let arcsec x = Expr.OfFunction(Functions.ArcSec, [x])
let arccsc x = Expr.OfFunction(Functions.ArcCsc, [x])

// Exsecant and excosecant trigonometric functions

let exsec x = Expr.OfFunction(Functions.ExSec, [x])
let excsc x = Expr.OfFunction(Functions.ExCsc, [x])
let arcexsec x = Expr.OfFunction(Functions.ArcExSec, [x])
let arcexcsc x = Expr.OfFunction(Functions.ArcExCsc, [x])

// Hyperbolic functions

let sinh x = Expr.OfFunction(Functions.Sinh, [x])
let cosh x = Expr.OfFunction(Functions.Cosh, [x])
let tanh x = Expr.OfFunction(Functions.Tanh, [x])
let coth x = Expr.OfFunction(Functions.Coth, [x])
let sech x = Expr.OfFunction(Functions.Sech, [x])
let csch x = Expr.OfFunction(Functions.Csch, [x])

// Inverse hyperbolic functions

let arsinh x = Expr.OfFunction(Functions.ArSinh, [x])
let arcosh x = Expr.OfFunction(Functions.ArCosh, [x])
let artanh x = Expr.OfFunction(Functions.ArTanh, [x])
let arcoth x = Expr.OfFunction(Functions.ArCoth, [x])
let arsech x = Expr.OfFunction(Functions.ArSech, [x])
let arcsch x = Expr.OfFunction(Functions.ArCsch, [x])

// Historical functions
// https://en.wikipedia.org/wiki/Versine

let crd x = Expr.OfFunction(Functions.Crd, [x])
let acrd x = Expr.OfFunction(Functions.Acrd, [x])
let versin x = Expr.OfFunction(Functions.VerSin, [x])
let vercos x = Expr.OfFunction(Functions.VerCos, [x])
let coversin x = Expr.OfFunction(Functions.CoverSin, [x])
let covercos x = Expr.OfFunction(Functions.CoverCos, [x])
let haversin x = Expr.OfFunction(Functions.HaverSin, [x])
let havercos x = Expr.OfFunction(Functions.HaverCos, [x])
let hacoversin x = Expr.OfFunction(Functions.HacoverSin, [x])
let hacovercos x = Expr.OfFunction(Functions.HacoverCos, [x])
let arcversin x = Expr.OfFunction(Functions.ArcVerSin, [x])
let arcvercos x = Expr.OfFunction(Functions.ArcVerCos, [x])
let arccoversin x = Expr.OfFunction(Functions.ArcCoverSin, [x])
let arccovercos x = Expr.OfFunction(Functions.ArcCoverCos, [x])
let archaversin x = Expr.OfFunction(Functions.ArcHaverSin, [x])
let archavercos x = Expr.OfFunction(Functions.ArcHaverCos, [x])
let archacoversin x = Expr.OfFunction(Functions.ArcHacoverSin, [x])
let archacovercos x = Expr.OfFunction(Functions.ArcHacoverCos, [x])
