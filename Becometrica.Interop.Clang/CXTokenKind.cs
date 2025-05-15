namespace Becometrica.Interop.Clang;

/**
 * Describes a kind of token.
 */
public enum CXTokenKind
{
    /**
     * A token that contains some kind of punctuation.
     */
    CXToken_Punctuation,

    /**
     * A language keyword.
     */
    CXToken_Keyword,

    /**
     * An identifier (that is not a keyword).
     */
    CXToken_Identifier,

    /**
     * A numeric, string, or character literal.
     */
    CXToken_Literal,

    /**
     * A comment.
     */
    CXToken_Comment
}