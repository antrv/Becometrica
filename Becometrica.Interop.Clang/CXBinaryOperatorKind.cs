namespace Becometrica.Interop.Clang;

/**
 * Describes the kind of binary operators.
 */
public enum CXBinaryOperatorKind
{
    /** This value describes cursors which are not binary operators. */
    CXBinaryOperator_Invalid,

    /** C++ Pointer - to - member operator. */
    CXBinaryOperator_PtrMemD,

    /** C++ Pointer - to - member operator. */
    CXBinaryOperator_PtrMemI,

    /** Multiplication operator. */
    CXBinaryOperator_Mul,

    /** Division operator. */
    CXBinaryOperator_Div,

    /** Remainder operator. */
    CXBinaryOperator_Rem,

    /** Addition operator. */
    CXBinaryOperator_Add,

    /** Subtraction operator. */
    CXBinaryOperator_Sub,

    /** Bitwise shift left operator. */
    CXBinaryOperator_Shl,

    /** Bitwise shift right operator. */
    CXBinaryOperator_Shr,

    /** C++ three-way comparison (spaceship) operator. */
    CXBinaryOperator_Cmp,

    /** Less than operator. */
    CXBinaryOperator_LT,

    /** Greater than operator. */
    CXBinaryOperator_GT,

    /** Less or equal operator. */
    CXBinaryOperator_LE,

    /** Greater or equal operator. */
    CXBinaryOperator_GE,

    /** Equal operator. */
    CXBinaryOperator_EQ,

    /** Not equal operator. */
    CXBinaryOperator_NE,

    /** Bitwise AND operator. */
    CXBinaryOperator_And,

    /** Bitwise XOR operator. */
    CXBinaryOperator_Xor,

    /** Bitwise OR operator. */
    CXBinaryOperator_Or,

    /** Logical AND operator. */
    CXBinaryOperator_LAnd,

    /** Logical OR operator. */
    CXBinaryOperator_LOr,

    /** Assignment operator. */
    CXBinaryOperator_Assign,

    /** Multiplication assignment operator. */
    CXBinaryOperator_MulAssign,

    /** Division assignment operator. */
    CXBinaryOperator_DivAssign,

    /** Remainder assignment operator. */
    CXBinaryOperator_RemAssign,

    /** Addition assignment operator. */
    CXBinaryOperator_AddAssign,

    /** Subtraction assignment operator. */
    CXBinaryOperator_SubAssign,

    /** Bitwise shift left assignment operator. */
    CXBinaryOperator_ShlAssign,

    /** Bitwise shift right assignment operator. */
    CXBinaryOperator_ShrAssign,

    /** Bitwise AND assignment operator. */
    CXBinaryOperator_AndAssign,

    /** Bitwise XOR assignment operator. */
    CXBinaryOperator_XorAssign,

    /** Bitwise OR assignment operator. */
    CXBinaryOperator_OrAssign,

    /** Comma operator. */
    CXBinaryOperator_Comma
}