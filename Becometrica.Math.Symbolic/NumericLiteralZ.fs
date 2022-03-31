module NumericLiteralZ

open Becometrica.Math

let FromZero() = new MpInteger()
let FromOne() = new MpInteger(1)
let FromInt32(n: int) = new MpInteger(n)
let FromInt64(n: int64) = new MpInteger(n)
let FromString(n: string) = MpInteger.Parse n
