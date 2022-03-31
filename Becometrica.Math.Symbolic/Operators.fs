module Becometrica.Math.Symbolic.Operators

let Addition = Operator.Create "+" 1 (InfixOperator OperatorAssociativity.Left) "Addition"
let Subtraction = Operator.Create "-" 1 (InfixOperator OperatorAssociativity.Left) "Subtraction"
let Multiplication = Operator.Create "*" 2 (InfixOperator OperatorAssociativity.Left) "Multiplication"
let Division = Operator.Create "/" 2 (InfixOperator OperatorAssociativity.Left) "Division"
let Modulo = Operator.Create "%" 2 (InfixOperator OperatorAssociativity.Left) "Modulo"
let Negation = Operator.Create "-" 4 (PrefixOperator true) "Negation"
let Exponentiation = Operator.Create "^" 5 (InfixOperator OperatorAssociativity.Left) "Exponentiation"
let Factorial = Operator.Create "!" 6 (PostfixOperator false) "Factorial"

let internal AllOperators =
    [Addition; Subtraction; Multiplication; Division; Modulo; Negation; Exponentiation; Factorial]
