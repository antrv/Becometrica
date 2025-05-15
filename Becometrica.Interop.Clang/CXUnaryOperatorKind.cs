namespace Becometrica.Interop.Clang;

/**
  * Describes the kind of unary operators.
  */
public enum CXUnaryOperatorKind
{
    /** This value describes cursors which are not unary operators. */
    CXUnaryOperator_Invalid,

    /** Postfix increment operator. */
    CXUnaryOperator_PostInc,

    /** Postfix decrement operator. */
    CXUnaryOperator_PostDec,

    /** Prefix increment operator. */
    CXUnaryOperator_PreInc,

    /** Prefix decrement operator. */
    CXUnaryOperator_PreDec,

    /** Address of operator. */
    CXUnaryOperator_AddrOf,

    /** Dereference operator. */
    CXUnaryOperator_Deref,

    /** Plus operator. */
    CXUnaryOperator_Plus,

    /** Minus operator. */
    CXUnaryOperator_Minus,

    /** Not operator. */
    CXUnaryOperator_Not,

    /** LNot operator. */
    CXUnaryOperator_LNot,

    /** "__real expr" operator. */
    CXUnaryOperator_Real,

    /** "__imag expr" operator. */
    CXUnaryOperator_Imag,

    /** __extension__ marker operator. */
    CXUnaryOperator_Extension,

    /** C++ co_await operator. */
    CXUnaryOperator_Coawait
}