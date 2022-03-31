using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Becometrica.Math.Interop;

internal static class Mpir
{
    private const string LibraryName = "mpir";
    private const string Prefix = "__g";

    /// <summary>
    /// Initialize integer, and set its value to 0.
    /// </summary>
    /// <param name="value"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init))]
    internal static extern void mpz_init(ref Mpz value);

    /// <summary>
    /// Initialize a NULL-terminated list of mpz_t variables, and set their values to 0.
    /// </summary>
    /// <param name="values"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_inits))]
    internal static extern void mpz_inits(ref Mpz values);

    /// <summary>
    /// Initialize integer, with space for n bits, and set its value to 0.
    /// n is only the initial space, integer will grow automatically in the normal way, if necessary,
    /// for subsequent values stored. mpz_init2 makes it possible to avoid such reallocations if a
    /// maximum size is known in advance.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init2))]
    internal static extern void mpz_init2(ref Mpz value, nuint n);

    /// <summary>
    /// Free the space occupied by integer. Call this function for all mpz_t variables when you are done with them.
    /// </summary>
    /// <param name="value"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_clear))]
    internal static extern void mpz_clear(ref Mpz value);

    /// <summary>
    /// Free the space occupied by a NULL-terminated list of mpz_t variables.
    /// </summary>
    /// <param name="values"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_clears))]
    internal static extern void mpz_clears(ref Mpz values);

    /// <summary>
    /// Change the space allocated for integer to n bits. The value in integer is preserved if it fits,
    /// or is set to 0 if not.
    /// This function can be used to increase the space for a variable in order to avoid repeated
    /// automatic reallocations, or to decrease it to give memory back to the heap.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_realloc2))]
    internal static extern void mpz_realloc2(ref Mpz value, nuint n);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set))]
    internal static extern void mpz_set(ref Mpz value, in Mpz op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_ui))]
    internal static extern void mpz_set_ui(ref Mpz value, nuint op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_si))]
    internal static extern void mpz_set_si(ref Mpz value, nint op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_ux))]
    internal static extern void mpz_set_ux(ref Mpz value, ulong op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_sx))]
    internal static extern void mpz_set_sx(ref Mpz value, long op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_d))]
    internal static extern void mpz_set_d(ref Mpz value, double op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_q))]
    internal static extern void mpz_set_q(ref Mpz value, in Mpq op);

    /// <summary>
    /// Set the value from op.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_f))]
    internal static extern void mpz_set_f(ref Mpz value, in Mpf op);

    /// <summary>
    /// Set the value of rop from str, a null-terminated C string in base base. White space is allowed
    /// in the string, and is simply ignored.
    /// The base may vary from 2 to 62, or if base is 0, then the leading characters are used: 0x and
    /// 0X for hexadecimal, 0b and 0B for binary, 0 for octal, or decimal otherwise.
    ///
    /// For bases up to 36, case is ignored; upper-case and lower-case letters have the same value. For
    /// bases 37 to 62, upper-case letter represent the usual 10..35 while lower-case letter represent
    /// 36..61.
    /// This function returns 0 if the entire string is a valid number in base base. Otherwise it returns −1.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="str"></param>
    /// <param name="base"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_set_str))]
    internal static extern int mpz_set_str(ref Mpz value, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, int @base);

    /// <summary>
    /// Swap the values rop1 and rop2 efficiently.
    /// </summary>
    /// <param name="rop1"></param>
    /// <param name="rop2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_swap))]
    internal static extern void mpz_swap(ref Mpz rop1, ref Mpz rop2);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set))]
    internal static extern void mpz_init_set(ref Mpz rop, in Mpz op);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_ui))]
    internal static extern void mpz_init_set_ui(ref Mpz rop, nuint op);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_si))]
    internal static extern void mpz_init_set_si(ref Mpz rop, nint op);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_ux))]
    internal static extern void mpz_init_set_ux(ref Mpz rop, ulong op);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_ux))]
    internal static extern void mpz_init_set_sx(ref Mpz rop, long op);

    /// <summary>
    /// Initialize rop with limb space and set the initial numeric value from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_d))]
    internal static extern void mpz_init_set_d(ref Mpz rop, double op);

    /// <summary>
    /// Initialize rop and set its value like mpz_set_str (see its documentation above for details).
    ///
    /// If the string is a correct base base number, the function returns 0; if an error occurs it returns
    /// −1. rop is initialized even if an error occurs. (I.e., you have to call mpz_clear for it.)
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="str"></param>
    /// <param name="base"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_init_set_str))]
    internal static extern int mpz_init_set_str(ref Mpz rop, [MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        int @base);

    /// <summary>
    /// Return the value of op as an mpir_ui.
    ///
    /// If op is too big to fit an mpir_ui then just the least significant bits that do fit are returned.
    /// The sign of op is ignored, only the absolute value is used.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_ui))]
    internal static extern nuint mpz_get_ui(in Mpz op);

    /// <summary>
    /// If op fits into a mpir_si return the value of op. Otherwise return the least significant part
    /// of op, with the same sign as op.
    ///
    /// If op is too big to fit in a mpir_si, the returned result is probably not very useful. To find
    /// out if the value will fit, use the function mpz_fits_slong_p.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_si))]
    internal static extern nint mpz_get_si(in Mpz op);

    /// <summary>
    /// Return the value of op as an uintmax_t.
    ///
    /// If op is too big to fit an uintmax_t then just the least significant bits that do fit are returned.
    /// The sign of op is ignored, only the absolute value is used.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_ux))]
    internal static extern ulong mpz_get_ux(in Mpz op);

    /// <summary>
    /// If op fits into a intmax_t return the value of op. Otherwise return the least significant part
    /// of op, with the same sign as op.
    ///
    /// If op is too big to fit in a intmax_t, the returned result is probably not very useful.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_sx))]
    internal static extern long mpz_get_sx(in Mpz op);

    /// <summary>
    /// Convert op to a double, truncating if necessary (ie. rounding towards zero).
    ///
    /// If the exponent from the conversion is too big, the result is system dependent. An infinity is
    /// returned where available. A hardware overflow trap may or may not occur.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_d))]
    internal static extern double mpz_get_d(in Mpz op);

    /// <summary>
    /// Convert op to a double, truncating if necessary (ie. rounding towards zero), and returning
    /// the exponent separately.
    ///
    /// The return value is in the range 0:5 ≤ |d| &lt; 1 and the exponent is stored to *exp. d ∗ 2exp is
    /// the (truncated) op value. If op is zero, the return is 0:0 and 0 is stored to *exp.
    /// </summary>
    /// <param name="exp"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_d_2exp))]
    internal static extern double mpz_get_d_2exp(out nint exp, in Mpz op);

    /// <summary>
    /// Convert op to a string of digits in base base. The base may vary from 2 to 36 or from −2 to −36.
    /// For base in the range 2..36, digits and lower-case letters are used; for −2..−36, digits and
    /// upper-case letters are used; for 37..62, digits, upper-case letters, and lower-case letters (in
    /// that significance order) are used.
    /// If str is NULL, the result string is allocated using the current allocation function (see
    /// Chapter 14 [Custom Allocation], page 106). The block will be strlen(str)+1 bytes, that
    /// being exactly enough for the string and null-terminator.
    /// If str is not NULL, it should point to a block of storage large enough for the result, that being
    /// mpz_sizeinbase (op, base) + 2. The two extra bytes are for a possible minus sign, and the
    /// null-terminator.
    /// A pointer to the result string is returned, being either the allocated block, or the given str.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="base"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_get_str))]
    internal static extern Utf8StringPtr mpz_get_str(Utf8StringPtr str, int @base, in Mpz op);

    /// <summary>
    /// Set rop to op1 + op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_add))]
    internal static extern void mpz_add(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 + op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_add_ui))]
    internal static extern void mpz_add_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to op1 − op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_sub))]
    internal static extern void mpz_sub(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 − op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_sub_ui))]
    internal static extern void mpz_sub_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to op1 − op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_ui_sub))]
    internal static extern void mpz_ui_sub(ref Mpz rop, nuint op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 * op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mul))]
    internal static extern void mpz_mul(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 * op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mul_ui))]
    internal static extern void mpz_mul_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to op1 * op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mul_si))]
    internal static extern void mpz_mul_si(ref Mpz rop, in Mpz op1, nint op2);

    /// <summary>
    /// Set rop to rop + op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_addmul))]
    internal static extern void mpz_addmul(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to rop + op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_addmul_ui))]
    internal static extern void mpz_addmul_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to rop - op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_submul))]
    internal static extern void mpz_submul(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to rop - op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_submul_ui))]
    internal static extern void mpz_submul_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to op1 × 2^op2. This operation can also be defined as a left shift by op2 bits.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mul_2exp))]
    internal static extern void mpz_mul_2exp(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set rop to −op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_neg))]
    internal static extern void mpz_neg(ref Mpz rop, in Mpz op);

    /// <summary>
    /// Set rop to the absolute value of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_abs))]
    internal static extern void mpz_abs(ref Mpz rop, in Mpz op);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_q))]
    internal static extern void mpz_cdiv_q(ref Mpz q, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_r))]
    internal static extern void mpz_cdiv_r(ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_qr))]
    internal static extern void mpz_cdiv_qr(ref Mpz q, ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_q_ui))]
    internal static extern nuint mpz_cdiv_q_ui(ref Mpz q, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_r_ui))]
    internal static extern nuint mpz_cdiv_r_ui(ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_qr_ui))]
    internal static extern nuint mpz_cdiv_qr_ui(ref Mpz q, ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_ui))]
    internal static extern nuint mpz_cdiv_ui(in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_q_2exp))]
    internal static extern void mpz_cdiv_q_2exp(ref Mpz q, in Mpz n, nuint b);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cdiv_r_2exp))]
    internal static extern void mpz_cdiv_r_2exp(ref Mpz r, in Mpz n, nuint b);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_q))]
    internal static extern void mpz_fdiv_q(ref Mpz q, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_r))]
    internal static extern void mpz_fdiv_r(ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_qr))]
    internal static extern void mpz_fdiv_qr(ref Mpz q, ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_q_ui))]
    internal static extern nuint mpz_fdiv_q_ui(ref Mpz q, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_r_ui))]
    internal static extern nuint mpz_fdiv_r_ui(ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_qr_ui))]
    internal static extern nuint mpz_fdiv_qr_ui(ref Mpz q, ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_ui))]
    internal static extern nuint mpz_fdiv_ui(in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_q_2exp))]
    internal static extern void mpz_fdiv_q_2exp(ref Mpz q, in Mpz n, nuint b);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fdiv_r_2exp))]
    internal static extern void mpz_fdiv_r_2exp(ref Mpz r, in Mpz n, nuint b);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_q))]
    internal static extern void mpz_tdiv_q(ref Mpz q, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_r))]
    internal static extern void mpz_tdiv_r(ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_qr))]
    internal static extern void mpz_tdiv_qr(ref Mpz q, ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_q_ui))]
    internal static extern nuint mpz_tdiv_q_ui(ref Mpz q, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_r_ui))]
    internal static extern nuint mpz_tdiv_r_ui(ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_qr_ui))]
    internal static extern nuint mpz_tdiv_qr_ui(ref Mpz q, ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_ui))]
    internal static extern nuint mpz_tdiv_ui(in Mpz n, nuint d);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_q_2exp))]
    internal static extern void mpz_tdiv_q_2exp(ref Mpz q, in Mpz n, nuint b);

    /// <summary>
    /// Divide n by d, forming a quotient q and/or remainder r. For the 2exp functions, d = 2^b. The
    /// rounding is in three styles, each suiting different applications.
    /// - cdiv rounds q up towards +1, and r will have the opposite sign to d. The c stands for “ceil”.
    /// - fdiv rounds q down towards −1, and r will have the same sign as d. The f stands for “floor”.
    /// - tdiv rounds q towards zero, and r will have the same sign as n. The t stands for “truncate”.
    /// In all cases q and r will satisfy n = qd + r, and r will satisfy 0 ≤ |r| &lt; |d|.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tdiv_r_2exp))]
    internal static extern void mpz_tdiv_r_2exp(ref Mpz r, in Mpz n, nuint b);

    /// <summary>
    /// Set r to n mod d. The sign of the divisor is ignored; the result is always non-negative.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mod))]
    internal static extern void mpz_mod(ref Mpz r, in Mpz n, in Mpz d);

    /// <summary>
    /// Set r to n mod d. The sign of the divisor is ignored; the result is always non-negative.
    /// mpz_mod_ui is identical to mpz_fdiv_r_ui above, returning the remainder as well as setting
    /// r. See mpz_fdiv_ui above if only the return value is wanted.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mod_ui))]
    internal static extern nuint mpz_mod_ui(ref Mpz r, in Mpz n, nuint d);

    /// <summary>
    /// Set q to n/d. These functions produce correct results only when it is known in advance that d divides n.
    ///
    /// These routines are much faster than the other division functions, and are the best choice
    /// when exact division is known to occur, for example reducing a rational to lowest terms.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_divexact))]
    internal static extern void mpz_divexact(ref Mpz q, in Mpz n, in Mpz d);

    /// <summary>
    /// Set q to n/d. These functions produce correct results only when it is known in advance that d divides n.
    ///
    /// These routines are much faster than the other division functions, and are the best choice
    /// when exact division is known to occur, for example reducing a rational to lowest terms.
    /// </summary>
    /// <param name="q"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_divexact_ui))]
    internal static extern void mpz_divexact_ui(ref Mpz q, in Mpz n, nuint d);

    /// <summary>
    /// Return non-zero if n is exactly divisible by d.
    ///
    /// n is divisible by d if there exists an integer q satisfying n = qd. Unlike the other division
    /// functions, d = 0 is accepted and following the rule it can be seen that only 0 is considered divisible by 0.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_divisible_p))]
    internal static extern int mpz_divisible_p(in Mpz n, in Mpz d);

    /// <summary>
    /// Return non-zero if n is exactly divisible by d.
    ///
    /// n is divisible by d if there exists an integer q satisfying n = qd. Unlike the other division
    /// functions, d = 0 is accepted and following the rule it can be seen that only 0 is considered divisible by 0.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_divisible_ui_p))]
    internal static extern int mpz_divisible_ui_p(in Mpz n, nuint d);

    /// <summary>
    /// Return non-zero if n is exactly divisible by 2^b.
    ///
    /// n is divisible by d if there exists an integer q satisfying n = qd. Unlike the other division
    /// functions, d = 0 is accepted and following the rule it can be seen that only 0 is considered divisible by 0.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_divisible_2exp_p))]
    internal static extern int mpz_divisible_2exp_p(in Mpz n, nuint b);

    /// <summary>
    /// Return non-zero if n is congruent to c modulo d.
    ///
    /// n is congruent to c mod d if there exists an integer q satisfying n = c + qd. Unlike the other
    /// division functions, d = 0 is accepted and following the rule it can be seen that n and c are
    /// considered congruent mod 0 only when exactly equal.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_congruent_p))]
    internal static extern int mpz_congruent_p(in Mpz n, in Mpz c, in Mpz d);

    /// <summary>
    /// Return non-zero if n is congruent to c modulo d.
    ///
    /// n is congruent to c mod d if there exists an integer q satisfying n = c + qd. Unlike the other
    /// division functions, d = 0 is accepted and following the rule it can be seen that n and c are
    /// considered congruent mod 0 only when exactly equal.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_congruent_ui_p))]
    internal static extern int mpz_congruent_ui_p(in Mpz n, nuint c, nuint d);

    /// <summary>
    /// Return non-zero if n is congruent to c modulo 2^b.
    ///
    /// n is congruent to c mod d if there exists an integer q satisfying n = c + qd. Unlike the other
    /// division functions, d = 0 is accepted and following the rule it can be seen that n and c are
    /// considered congruent mod 0 only when exactly equal.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_congruent_2exp_p))]
    internal static extern int mpz_congruent_2exp_p(in Mpz n, in Mpz c, nuint b);

    /// <summary>
    /// Set rop to base^exp mod mod.
    /// A negative exp is supported in mpz_powm if an inverse base^−1 mod mod exists (see
    /// mpz_invert. If an inverse doesn’t exist then a divide by zero is raised.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="base"></param>
    /// <param name="exp"></param>
    /// <param name="mod"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_powm))]
    internal static extern void mpz_powm(ref Mpz rop, in Mpz @base, in Mpz exp, in Mpz mod);

    /// <summary>
    /// Set rop to base^exp mod mod.
    /// A negative exp is supported in mpz_powm if an inverse base^−1 mod mod exists (see
    /// mpz_invert. If an inverse doesn’t exist then a divide by zero is raised.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="base"></param>
    /// <param name="exp"></param>
    /// <param name="mod"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_powm_ui))]
    internal static extern void mpz_powm_ui(ref Mpz rop, in Mpz @base, nuint exp, in Mpz mod);

    /// <summary>
    /// Set rop to base^exp. The case 0^0 yields 1.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="base"></param>
    /// <param name="exp"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_pow_ui))]
    internal static extern void mpz_pow_ui(ref Mpz rop, in Mpz @base, nuint exp);

    /// <summary>
    /// Set rop to base^exp. The case 0^0 yields 1.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="base"></param>
    /// <param name="exp"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_ui_pow_ui))]
    internal static extern void mpz_ui_pow_ui(ref Mpz rop, nuint @base, nuint exp);

    /// <summary>
    /// Set rop to the truncated integer part of the nth root of op. Return non-zero if the
    /// computation was exact, i.e., if op is rop to the nth power.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_root))]
    internal static extern int mpz_root(ref Mpz rop, in Mpz op, nuint n);

    /// <summary>
    /// Set rop to the truncated integer part of the nth root of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_nthroot))]
    internal static extern void mpz_nthroot(ref Mpz rop, in Mpz op, nuint n);

    /// <summary>
    /// Set root to the truncated integer part of the nth root of u.
    /// Set rem to the remainder, (u − root^n).
    /// </summary>
    /// <param name="root"></param>
    /// <param name="rem"></param>
    /// <param name="u"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_rootrem))]
    internal static extern void mpz_rootrem(ref Mpz root, ref Mpz rem, in Mpz u, nuint n);

    /// <summary>
    /// Set rop to the truncated integer part of the square root of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_sqrt))]
    internal static extern void mpz_sqrt(ref Mpz rop, in Mpz op);

    /// <summary>
    /// Set root to the truncated integer part of the square root of u.
    /// Set rem to the remainder, (u − root^2).
    /// </summary>
    /// <param name="root"></param>
    /// <param name="rem"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_sqrtrem))]
    internal static extern void mpz_sqrtrem(ref Mpz root, ref Mpz rem, in Mpz u);

    /// <summary>
    /// Return non-zero if op is a perfect power, i.e., if there exist integers a and b, with b > 1, such
    /// that op = a^b.
    /// Under this definition both 0 and 1 are considered to be perfect powers. Negative values of
    /// op are accepted, but of course can only be odd perfect powers.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_perfect_power_p))]
    internal static extern int mpz_perfect_power_p(in Mpz op);

    /// <summary>
    /// Return non-zero if op is a perfect square, i.e., if the square root of op is an integer. Under
    /// this definition both 0 and 1 are considered to be perfect squares.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_perfect_square_p))]
    internal static extern int mpz_perfect_square_p(in Mpz op);

    /// <summary>
    /// Set rop to the greatest common divisor of op1 and op2. The result is always positive even if
    /// one or both input operands are negative.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_gcd))]
    internal static extern void mpz_gcd(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Compute the greatest common divisor of op1 and op2. If rop is not NULL, store the result there.
    ///
    /// If the result is small enough to fit in an mpir_ui, it is returned. If the result does not fit, 0
    /// is returned, and the result is equal to the argument op1. Note that the result will always fit
    /// if op2 is non-zero.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_gcd_ui))]
    internal static extern nuint mpz_gcd_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Set g to the greatest common divisor of a and b, and in addition set s and t to coefficients
    /// satisfying as + bt = g. The value in g is always positive, even if one or both of a and b
    /// are negative (or zero if both inputs are zero).
    /// </summary>
    /// <param name="g"></param>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_gcdext))]
    internal static extern void mpz_gcdext(ref Mpz g, ref Mpz s, ref Mpz t, in Mpz a, in Mpz b);

    /// <summary>
    /// Set rop to the least common multiple of op1 and op2. rop is always positive, irrespective of
    /// the signs of op1 and op2. rop will be zero if either op1 or op2 is zero.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_lcm))]
    internal static extern void mpz_lcm(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to the least common multiple of op1 and op2. rop is always positive, irrespective of
    /// the signs of op1 and op2. rop will be zero if either op1 or op2 is zero.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_lcm_ui))]
    internal static extern nuint mpz_lcm_ui(ref Mpz rop, in Mpz op1, nuint op2);

    /// <summary>
    /// Compute the inverse of op1 modulo op2 and put the result in rop. If the inverse exists, the
    /// return value is non-zero and rop will satisfy 0 ≤ rop &lt; op2. If an inverse doesn’t exist the
    /// return value is zero and rop is undefined.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_invert))]
    internal static extern int mpz_invert(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b). This is defined only for b odd.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_jacobi))]
    internal static extern int mpz_jacobi(in Mpz a, in Mpz b);

    /// <summary>
    /// Calculate the Legendre symbol (a/p). This is defined only for p an odd positive prime, and
    /// for such p it’s identical to the Jacobi symbol.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_legendre))]
    internal static extern int mpz_legendre(in Mpz a, in Mpz p);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b) with the Kronecker extension (a/2) = (2/a) when a odd, or
    /// (a/2) = 0 when a even.
    ///
    /// When b is odd the Jacobi symbol and Kronecker symbol are identical, so mpz_kronecker_ui
    /// etc can be used for mixed precision Jacobi symbols too.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_kronecker))]
    internal static extern int mpz_kronecker(in Mpz a, in Mpz b);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b) with the Kronecker extension (a/2) = (2/a) when a odd, or
    /// (a/2) = 0 when a even.
    ///
    /// When b is odd the Jacobi symbol and Kronecker symbol are identical, so mpz_kronecker_ui
    /// etc can be used for mixed precision Jacobi symbols too.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_kronecker_si))]
    internal static extern int mpz_kronecker_si(in Mpz a, nint b);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b) with the Kronecker extension (a/2) = (2/a) when a odd, or
    /// (a/2) = 0 when a even.
    ///
    /// When b is odd the Jacobi symbol and Kronecker symbol are identical, so mpz_kronecker_ui
    /// etc can be used for mixed precision Jacobi symbols too.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_kronecker_ui))]
    internal static extern int mpz_kronecker_ui(in Mpz a, nuint b);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b) with the Kronecker extension (a/2) = (2/a) when a odd, or
    /// (a/2) = 0 when a even.
    ///
    /// When b is odd the Jacobi symbol and Kronecker symbol are identical, so mpz_kronecker_ui
    /// etc can be used for mixed precision Jacobi symbols too.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_si_kronecker))]
    internal static extern int mpz_si_kronecker(nint a, in Mpz b);

    /// <summary>
    /// Calculate the Jacobi symbol (a/b) with the Kronecker extension (a/2) = (2/a) when a odd, or
    /// (a/2) = 0 when a even.
    ///
    /// When b is odd the Jacobi symbol and Kronecker symbol are identical, so mpz_kronecker_ui
    /// etc can be used for mixed precision Jacobi symbols too.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_ui_kronecker))]
    internal static extern int mpz_ui_kronecker(nuint a, in Mpz b);

    /// <summary>
    /// Remove all occurrences of the factor f from op and store the result in rop. The return value
    /// is how many such occurrences were removed.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_remove))]
    internal static extern nuint mpz_remove(ref Mpz rop, in Mpz op, in Mpz f);

    /// <summary>
    /// Set rop to the factorial of n.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fac_ui))]
    internal static extern void mpz_fac_ui(ref Mpz rop, nuint n);

    /// <summary>
    /// Set rop to the double-factorial of n.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_2fac_ui))]
    internal static extern void mpz_2fac_ui(ref Mpz rop, nuint n);

    /// <summary>
    /// Set rop to the m-multi-factorial of n.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    /// <param name="m"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_mfac_uiui))]
    internal static extern void mpz_mfac_uiui(ref Mpz rop, nuint n, nuint m);

    /// <summary>
    /// Set rop to the primorial of n, i.e. the product of all positive prime numbers ≤ n.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_primorial_ui))]
    internal static extern void mpz_primorial_ui(ref Mpz rop, nuint n);

    /// <summary>
    /// Compute the binomial coefficient (n/k) and store the result in rop. Negative values of n are
    /// supported by mpz_bin_ui, using the identity (−n / k) = (−1)^k * (n+k-1 / k).
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_bin_ui))]
    internal static extern void mpz_bin_ui(ref Mpz rop, in Mpz n, nuint k);

    /// <summary>
    /// Compute the binomial coefficient (n/k) and store the result in rop. Negative values of n are
    /// supported by mpz_bin_ui, using the identity (−n / k) = (−1)^k * (n+k-1 / k).
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_bin_uiui))]
    internal static extern void mpz_bin_uiui(ref Mpz rop, nuint n, nuint k);

    /// <summary>
    /// Computes n-th fibonacci number.
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fib_ui))]
    internal static extern void mpz_fib_ui(ref Mpz fn, nuint n);

    /// <summary>
    /// Computes n-th fibonacci number.
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="fnsub1"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fib2_ui))]
    internal static extern void mpz_fib2_ui(ref Mpz fn, ref Mpz fnsub1, nuint n);

    /// <summary>
    /// Computes n-th Lucas number.
    /// </summary>
    /// <param name="ln"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_lucnum_ui))]
    internal static extern void mpz_lucnum_ui(ref Mpz ln, nuint n);

    /// <summary>
    /// Computes n-th Lucas number.
    /// </summary>
    /// <param name="ln"></param>
    /// <param name="lnsub1"></param>
    /// <param name="n"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_lucnum2_ui))]
    internal static extern void mpz_lucnum2_ui(ref Mpz ln, ref Mpz lnsub1, nuint n);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2,
    /// or a negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmp))]
    internal static extern int mpz_cmp(in Mpz op1, in Mpz op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2,
    /// or a negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmp_d))]
    internal static extern int mpz_cmp_d(in Mpz op1, double op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2,
    /// or a negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmp_si))]
    internal static extern int mpz_cmp_si(in Mpz op1, nint op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2,
    /// or a negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmp_ui))]
    internal static extern int mpz_cmp_ui(in Mpz op1, nuint op2);

    /// <summary>
    /// Compare the absolute values of op1 and op2. Return a positive value if |op1| > |op2|, zero if |op1| = |op2|,
    /// or a negative value if |op1| &lt; |op2|.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmpabs))]
    internal static extern int mpz_cmpabs(in Mpz op1, in Mpz op2);

    /// <summary>
    /// Compare the absolute values of op1 and op2. Return a positive value if |op1| > |op2|, zero if |op1| = |op2|,
    /// or a negative value if |op1| &lt; |op2|.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmpabs_d))]
    internal static extern int mpz_cmpabs_d(in Mpz op1, double op2);

    /// <summary>
    /// Compare the absolute values of op1 and op2. Return a positive value if |op1| > |op2|, zero if |op1| = |op2|,
    /// or a negative value if |op1| &lt; |op2|.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_cmpabs_ui))]
    internal static extern int mpz_cmpabs_ui(in Mpz op1, nuint op2);

    /// <summary>
    /// Return +1 if op > 0, 0 if op = 0, and −1 if op &lt; 0.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int mpz_sgn(in Mpz op) => System.Math.Sign(op.MpSize);

    /// <summary>
    /// Set rop to op1 bitwise-and op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_and))]
    internal static extern void mpz_and(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 bitwise inclusive-or op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_ior))]
    internal static extern void mpz_ior(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to op1 bitwise exclusive-or op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_xor))]
    internal static extern void mpz_xor(ref Mpz rop, in Mpz op1, in Mpz op2);

    /// <summary>
    /// Set rop to the one’s complement of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_com))]
    internal static extern void mpz_com(ref Mpz rop, in Mpz op);

    /// <summary>
    /// If op ≥ 0, return the population count of op, which is the number of 1 bits in the binary
    /// representation. If op &lt; 0, the number of 1s is infinite, and the return value is ULONG MAX,
    /// the largest possible mp_bitcnt_t.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_popcount))]
    internal static extern nuint mpz_popcount(in Mpz op);

    /// <summary>
    /// If op1 and op2 are both ≥ 0 or both &lt; 0, return the hamming distance between the two
    /// operands, which is the number of bit positions where op1 and op2 have different bit values.
    /// If one operand is ≥ 0 and the other &lt; 0 then the number of bits different is infinite, and the
    /// return value is the largest possible imp_bitcnt_t.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_hamdist))]
    internal static extern nuint mpz_hamdist(in Mpz op1, in Mpz op2);

    /// <summary>
    /// Scan op, starting from bit starting bit, towards more significant bits, until the first 0 bit
    /// (respectively) is found. Return the index of the found bit.
    ///
    /// If the bit at starting bit is already what’s sought, then starting bit is returned.
    ///
    /// If there’s no bit found, then the largest possible mp_bitcnt_t is returned. This will happen
    /// in mpz_scan0 past the end of a positive number, or mpz_scan1 past the end of a nonnegative
    /// number.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="startingBit"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_scan0))]
    internal static extern nuint mpz_scan0(in Mpz op, nuint startingBit);

    /// <summary>
    /// Scan op, starting from bit starting bit, towards more significant bits, until the first 1 bit
    /// (respectively) is found. Return the index of the found bit.
    ///
    /// If the bit at starting bit is already what’s sought, then starting bit is returned.
    ///
    /// If there’s no bit found, then the largest possible mp_bitcnt_t is returned. This will happen
    /// in mpz_scan0 past the end of a positive number, or mpz_scan1 past the end of a nonnegative
    /// number.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="startingBit"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_scan1))]
    internal static extern nuint mpz_scan1(in Mpz op, nuint startingBit);

    /// <summary>
    /// Set bit bitIndex in rop.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="bitIndex"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_setbit))]
    internal static extern void mpz_setbit(ref Mpz rop, nuint bitIndex);

    /// <summary>
    /// Clear bit bitIndex in rop.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="bitIndex"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_clrbit))]
    internal static extern void mpz_clrbit(ref Mpz rop, nuint bitIndex);

    /// <summary>
    /// Complement bit bitIndex in rop.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="bitIndex"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_combit))]
    internal static extern void mpz_combit(ref Mpz rop, nuint bitIndex);

    /// <summary>
    /// Test bit bitIndex in op and return 0 or 1 accordingly.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="bitIndex"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_tstbit))]
    internal static extern int mpz_tstbit(in Mpz op, nuint bitIndex);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_ulong_p))]
    internal static extern int mpz_fits_ulong_p(in Mpz op);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_slong_p))]
    internal static extern int mpz_fits_slong_p(in Mpz op);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_uint_p))]
    internal static extern int mpz_fits_uint_p(in Mpz op);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_sint_p))]
    internal static extern int mpz_fits_sint_p(in Mpz op);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_ushort_p))]
    internal static extern int mpz_fits_ushort_p(in Mpz op);

    /// <summary>
    /// Return non-zero iff the value of op fits in an unsigned long, long, unsigned int, signed
    /// int, unsigned short int, or signed short int, respectively. Otherwise, return zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_fits_sshort_p))]
    internal static extern int mpz_fits_sshort_p(in Mpz op);

    /// <summary>
    /// Determine whether op is odd.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool mpz_odd_p(in Mpz op) => (op.MpSize != 0) & ((op.MpD[0] & 1) != 0);

    /// <summary>
    /// Determine whether op is even.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool mpz_even_p(in Mpz op) => !mpz_odd_p(op);

    /// <summary>
    /// Return the size of op measured in number of digits in the given base. base can vary from 2
    /// to 36. The sign of op is ignored, just the absolute value is used. The result will be either
    /// exact or 1 too big. If base is a power of 2, the result is always exact. If op is zero the return
    /// value is always 1.
    ///
    /// This function can be used to determine the space required when converting op to a string. The
    /// right amount of allocation is normally two more than the value returned by mpz_sizeinbase,
    /// one extra for a minus sign and one for the null-terminator.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="base"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_sizeinbase))]
    internal static extern nuint mpz_sizeinbase(in Mpz op, int @base);

    /// <summary>
    /// Return limb number n from op. The sign of op is ignored, just the absolute value is used.
    /// The least significant limb is number 0.
    ///
    /// mpz_size can be used to find how many limbs make up op. mpz_getlimbn returns zero if n
    /// is outside the range 0 to mpz_size(op)-1.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_getlimbn))]
    internal static extern nuint mpz_getlimbn(in Mpz op, nuint n);

    /// <summary>
    /// Return the size of op measured in number of limbs. If op is zero, the returned value will be zero.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpz_size))]
    internal static extern nuint mpz_size(in Mpz op);

    /// <summary>
    /// Remove any factors that are common to the numerator and denominator of op, and make
    /// the denominator positive.
    /// </summary>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_canonicalize))]
    internal static extern void mpq_canonicalize(ref Mpq op);

    /// <summary>
    /// Initialize dest rational and set it to 0/1. Each variable should normally only be initialized
    /// once, or at least cleared out (using the function mpq_clear) between each initialization.
    /// </summary>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_init))]
    internal static extern void mpq_init(ref Mpq op);

    /// <summary>
    /// Free the space occupied by rational number. Make sure to call this function for all mpq_t
    /// variables when you are done with them.
    /// </summary>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_clear))]
    internal static extern void mpq_clear(ref Mpq op);

    /// <summary>
    /// Assign rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set))]
    internal static extern void mpq_set(ref Mpq rop, in Mpq op);

    /// <summary>
    /// Assign rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_z))]
    internal static extern void mpq_set_z(ref Mpq rop, in Mpz op);

    /// <summary>
    /// Set the value of rop to op1/op2. Note that if op1 and op2 have common factors, rop has to
    /// be passed to mpq_canonicalize before any operations are performed on rop.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_ui))]
    internal static extern void mpq_set_ui(ref Mpq rop, nuint op1, nuint op2);

    /// <summary>
    /// Set the value of rop to op1/op2. Note that if op1 and op2 have common factors, rop has to
    /// be passed to mpq_canonicalize before any operations are performed on rop.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_si))]
    internal static extern void mpq_set_si(ref Mpq rop, nint op1, nuint op2);

    /// <summary>
    /// Set rop from a null-terminated string str in the given base.
    ///
    /// The string can be an integer like “41” or a fraction like “41/152”. The fraction must be
    /// in canonical form (see Chapter 6 [Rational Number Functions], page 46), or if not then
    /// mpq_canonicalize must be called.
    ///
    /// The numerator and optional denominator are parsed the same as in mpz_set_str (see
    /// Section 5.2 [Assigning Integers], page 30). White space is allowed in the string, and is simply
    /// ignored. The base can vary from 2 to 62, or if base is 0 then the leading characters are used:
    /// 0x or 0X for hex, 0b or 0B for binary, 0 for octal, or decimal otherwise. Note that this is done
    /// separately for the numerator and denominator, so for instance 0xEF/100 is 239/100, whereas
    /// 0xEF/0x100 is 239/256.
    /// The return value is 0 if the entire string is a valid number, or −1 if not.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="str"></param>
    /// <param name="base"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_str))]
    internal static extern int mpq_set_str(ref Mpq rop, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, int @base);

    /// <summary>
    /// Swap the values rop1 and rop2 efficiently.
    /// </summary>
    /// <param name="rop1"></param>
    /// <param name="rop2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_swap))]
    internal static extern void mpq_swap(ref Mpq rop1, ref Mpq rop2);

    /// <summary>
    /// Convert op to a double, truncating if necessary (ie. rounding towards zero).
    ///
    /// If the exponent from the conversion is too big or too small to fit a double then the result is
    /// system dependent. For too big an infinity is returned when available. For too small 0:0 is
    /// normally returned. Hardware overflow, underflow and denorm traps may or may not occur.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_get_d))]
    internal static extern double mpq_get_d(in Mpq op);

    /// <summary>
    /// Set rop to the value of op. There is no rounding, this conversion is exact.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_d))]
    internal static extern void mpq_set_d(ref Mpq rop, double op);

    /// <summary>
    /// Set rop to the value of op. There is no rounding, this conversion is exact.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_set_f))]
    internal static extern void mpq_set_f(ref Mpq rop, in Mpf op);

    /// <summary>
    /// Convert op to a string of digits in base base. The base may vary from 2 to 36. The string
    /// will be of the form ‘num/den’, or if the denominator is 1 then just ‘num’.
    ///
    /// If str is NULL, the result string is allocated using the current allocation function (see
    /// Chapter 14 [Custom Allocation], page 106). The block will be strlen(str)+1 bytes, that
    /// being exactly enough for the string and null-terminator.
    ///
    /// If str is not NULL, it should point to a block of storage large enough for the result, that being
    /// mpz_sizeinbase (mpq_numref(op), base) + mpz_sizeinbase (mpq_denref(op), base) + 3
    /// The three extra bytes are for a possible minus sign, possible slash, and the null-terminator.
    /// A pointer to the result string is returned, being either the allocated block, or the given str.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="base"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_get_str))]
    internal static extern Utf8StringPtr mpq_get_str(Utf8StringPtr str, int @base, in Mpq op);

    /// <summary>
    /// Set sum to addend1 + addend2.
    /// </summary>
    /// <param name="sum"></param>
    /// <param name="addend1"></param>
    /// <param name="addend2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_add))]
    internal static extern void mpq_add(ref Mpq sum, in Mpq addend1, in Mpq addend2);

    /// <summary>
    /// Set difference to minuend − subtrahend.
    /// </summary>
    /// <param name="difference"></param>
    /// <param name="minuend"></param>
    /// <param name="subtrahend"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_sub))]
    internal static extern void mpq_sub(ref Mpq difference, in Mpq minuend, in Mpq subtrahend);

    /// <summary>
    /// Set product to multiplier × multiplicand.
    /// </summary>
    /// <param name="product"></param>
    /// <param name="multiplier"></param>
    /// <param name="multiplicand"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_mul))]
    internal static extern void mpq_mul(ref Mpq product, in Mpq multiplier, in Mpq multiplicand);

    /// <summary>
    /// Set rop to op1 × 2^op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_mul_2exp))]
    internal static extern void mpq_mul_2exp(ref Mpq rop, in Mpq op1, nuint op2);

    /// <summary>
    /// Set quotient to dividend/divisor.
    /// </summary>
    /// <param name="quotient"></param>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_div))]
    internal static extern void mpq_div(ref Mpq quotient, in Mpq dividend, in Mpq divisor);

    /// <summary>
    /// Set rop to op1=2^op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_div_2exp))]
    internal static extern void mpq_div_2exp(ref Mpq rop, in Mpq op1, nuint op2);

    /// <summary>
    /// Set rop to −op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_neg))]
    internal static extern void mpq_neg(ref Mpq rop, in Mpq op);

    /// <summary>
    /// Set rop to the absolute value of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_abs))]
    internal static extern void mpq_abs(ref Mpq rop, in Mpq op);

    /// <summary>
    /// Set rop to 1/op. If the new denominator is zero, this routine will divide by zero.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_inv))]
    internal static extern void mpq_inv(ref Mpq rop, in Mpq op);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// To determine if two rationals are equal, mpq_equal is faster than mpq_cmp.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_cmp))]
    internal static extern int mpq_cmp(in Mpq op1, in Mpq op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// To determine if two rationals are equal, mpq_equal is faster than mpq_cmp.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_cmp_z))]
    internal static extern int mpq_cmp_z(in Mpq op1, in Mpz op2);

    /// <summary>
    /// Compare op1 and num2/den2. Return a positive value if op1 > num2/den2, zero if op1 =
    /// num2/den2, and a negative value if op1 &lt; num2/den2.
    /// num2 and den2 are allowed to have common factors.
    /// These functions are implemented as a macros and evaluate their arguments multiple times.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="num2"></param>
    /// <param name="den2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_cmp_ui))]
    internal static extern int mpq_cmp_ui(in Mpq op1, nuint num2, nuint den2);

    /// <summary>
    /// Compare op1 and num2/den2. Return a positive value if op1 > num2/den2, zero if op1 =
    /// num2/den2, and a negative value if op1 &lt; num2/den2.
    /// num2 and den2 are allowed to have common factors.
    /// These functions are implemented as a macros and evaluate their arguments multiple times.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="num2"></param>
    /// <param name="den2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_cmp_si))]
    internal static extern int mpq_cmp_si(in Mpq op1, nint num2, nuint den2);

    /// <summary>
    /// Return +1 if op > 0, 0 if op = 0, and −1 if op &lt; 0.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int mpq_sgn(in Mpq op) => mpz_sgn(op.MpNum);

    /// <summary>
    /// Return non-zero if op1 and op2 are equal, zero if they are non-equal. Although mpq_cmp can
    /// be used for the same purpose, this function is much faster.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpq_equal))]
    internal static extern int mpq_equal(in Mpq op1, in Mpq op2);

    /// <summary>
    /// Set the default precision to be at least prec bits. All subsequent calls to mpf_init will use
    /// this precision, but previously initialized variables are unaffected.
    /// </summary>
    /// <param name="prec"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_default_prec))]
    internal static extern void mpf_set_default_prec(nuint prec);

    /// <summary>
    /// Return the default precision actually used.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_default_prec))]
    internal static extern nuint mpf_get_default_prec();

    /// <summary>
    /// Initialize x to 0. Normally, a variable should be initialized once only or at least be cleared,
    /// using mpf_clear, between initializations. The precision of x is undefined unless a default
    /// precision has already been established by a call to mpf_set_default_prec.
    /// </summary>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init))]
    internal static extern void mpf_init(ref Mpf op);

    /// <summary>
    /// Initialize x to 0 and set its precision to be at least prec bits. Normally, a variable should be
    /// initialized once only or at least be cleared, using mpf_clear, between initializations.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="prec"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init2))]
    internal static extern void mpf_init2(ref Mpf op, nuint prec);

    /// <summary>
    /// Free the space occupied by x. Make sure to call this function for all mpf_t variables when
    /// you are done with them.
    /// </summary>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_clear))]
    internal static extern void mpf_clear(ref Mpf op);

    /// <summary>
    /// Return the current precision of op, in bits.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_prec))]
    internal static extern nuint mpf_get_prec(in Mpf op);

    /// <summary>
    /// Set the precision of rop to be at least prec bits. The value in rop will be truncated to the new precision.
    /// This function requires a call to realloc, and so should not be used in a tight loop.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="prec"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_prec))]
    internal static extern void mpf_set_prec(ref Mpf op, nuint prec);

    /// <summary>
    /// Set the precision of rop to be at least prec bits, without changing the memory allocated.
    /// prec must be no more than the allocated precision for rop, that being the precision when rop
    /// was initialized, or in the most recent mpf_set_prec.
    /// The value in rop is unchanged, and in particular if it had a higher precision than prec it will
    /// retain that higher precision. New values written to rop will use the new prec.
    /// Before calling mpf_clear or the full mpf_set_prec, another mpf_set_prec_raw call must be
    /// made to restore rop to its original allocated precision. Failing to do so will have unpredictable
    /// results.
    /// mpf_get_prec can be used before mpf_set_prec_raw to get the original allocated precision.
    /// After mpf_set_prec_raw it reflects the prec value set.
    /// mpf_set_prec_raw is an efficient way to use an mpf_t variable at different precisions during
    /// a calculation, perhaps to gradually increase precision in an iteration, or just to use various
    /// different precisions for different purposes during a calculation.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="prec"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_prec_raw))]
    internal static extern void mpf_set_prec_raw(ref Mpf op, nuint prec);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set))]
    internal static extern void mpf_set(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_ui))]
    internal static extern void mpf_set_ui(ref Mpf rop, nuint op);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_si))]
    internal static extern void mpf_set_si(ref Mpf rop, nint op);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_d))]
    internal static extern void mpf_set_d(ref Mpf rop, double op);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_z))]
    internal static extern void mpf_set_z(ref Mpf rop, in Mpz op);

    /// <summary>
    /// Set the value of rop from op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_q))]
    internal static extern void mpf_set_q(ref Mpf rop, in Mpq op);

    /// <summary>
    /// Set the value of rop from the string in str. The string is of the form ‘M@N’ or, if the base is 10
    /// or less, alternatively ‘MeN’. ‘M’ is the mantissa and ‘N’ is the exponent. The mantissa is always
    /// in the specified base. The exponent is either in the specified base or, if base is negative, in
    /// decimal. The decimal point expected is taken from the current locale, on systems providing
    /// localeconv.
    /// The argument base may be in the ranges 2 to 62, or −62 to −2. Negative values are used to
    /// specify that the exponent is in decimal.
    /// For bases up to 36, case is ignored; upper-case and lower-case letters have the same value; for
    /// bases 37 to 62, upper-case letter represent the usual 10..35 while lower-case letter represent
    /// 36..61.
    /// Unlike the corresponding mpz function, the base will not be determined from the leading
    /// characters of the string if base is 0. This is so that numbers like ‘0.23’ are not interpreted
    /// as octal.
    /// White space is allowed in the string, and is simply ignored. [This is not really true; whitespace
    /// is ignored in the beginning of the string and within the mantissa, but not in other
    /// places, such as after a minus sign or in the exponent. We are considering changing the
    /// definition of this function, making it fail when there is any white-space in the input, since
    /// that makes a lot of sense. Please tell us your opinion about this change. Do you really want
    /// it to accept "3 14" as meaning 314 as it does now?]
    /// This function returns 0 if the entire string is a valid number in base base. Otherwise it returns
    /// −1.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="str"></param>
    /// <param name="base"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_set_str))]
    internal static extern int mpf_set_str(ref Mpf rop, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, int @base);

    /// <summary>
    /// Swap rop1 and rop2 efficiently. Both the values and the precisions of the two variables are swapped.
    /// </summary>
    /// <param name="rop1"></param>
    /// <param name="rop2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_swap))]
    internal static extern void mpf_swap(ref Mpf rop1, ref Mpf rop2);

    /// <summary>
    /// Initialize rop and set its value from op.
    /// The precision of rop will be taken from the active default precision, as set by mpf_set_
    /// default_prec.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init_set))]
    internal static extern void mpf_init_set(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Initialize rop and set its value from op.
    /// The precision of rop will be taken from the active default precision, as set by mpf_set_
    /// default_prec.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init_set_ui))]
    internal static extern void mpf_init_set_ui(ref Mpf rop, nuint op);

    /// <summary>
    /// Initialize rop and set its value from op.
    /// The precision of rop will be taken from the active default precision, as set by mpf_set_
    /// default_prec.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init_set_si))]
    internal static extern void mpf_init_set_si(ref Mpf rop, nint op);

    /// <summary>
    /// Initialize rop and set its value from op.
    /// The precision of rop will be taken from the active default precision, as set by mpf_set_
    /// default_prec.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init_set_d))]
    internal static extern void mpf_init_set_d(ref Mpf rop, double op);

    /// <summary>
    /// Initialize rop and set its value from the string in str. See mpf_set_str above for details on
    /// the assignment operation.
    ///
    /// Note that rop is initialized even if an error occurs. (I.e., you have to call mpf_clear for it.)
    /// The precision of rop will be taken from the active default precision, as set by mpf_set_default_prec.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="str"></param>
    /// <param name="base"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_init_set_str))]
    internal static extern int
        mpf_init_set_str(ref Mpf rop, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, int @base);

    /// <summary>
    /// Convert op to a double, truncating if necessary (ie. rounding towards zero).
    /// If the exponent in op is too big or too small to fit a double then the result is system dependent.
    /// For too big an infinity is returned when available. For too small 0:0 is normally returned.
    /// Hardware overflow, underflow and denorm traps may or may not occur.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_d))]
    internal static extern double mpf_get_d(in Mpf op);

    /// <summary>
    /// Convert op to a double, truncating if necessary (ie. rounding towards zero), and with an
    /// exponent returned separately.
    /// The return value is in the range 0:5 ≤ jdj &lt; 1 and the exponent is stored to *exp. d ∗ 2exp is
    /// the (truncated) op value. If op is zero, the return is 0:0 and 0 is stored to *exp.
    /// This is similar to the standard C frexp function (see Section “Normalization Functions” in
    /// The GNU C Library Reference Manual).
    /// </summary>
    /// <param name="exp"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_d_2exp))]
    internal static extern double mpf_get_d_2exp(out nint exp, in Mpf op);

    /// <summary>
    /// Convert op to a mpir_si or mpir_ui, truncating any fraction part. If op is too big for the
    /// return type, the result is undefined.
    /// See also mpf_fits_slong_p and mpf_fits_ulong_p (see Section 7.8 [Miscellaneous Float
    /// Functions], page 56).
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_si))]
    internal static extern nint mpf_get_si(in Mpf op);

    /// <summary>
    /// Convert op to a mpir_si or mpir_ui, truncating any fraction part. If op is too big for the
    /// return type, the result is undefined.
    /// See also mpf_fits_slong_p and mpf_fits_ulong_p (see Section 7.8 [Miscellaneous Float
    /// Functions], page 56).
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_ui))]
    internal static extern nuint mpf_get_ui(in Mpf op);

    /// <summary>
    /// Convert op to a string of digits in base base. base can vary from 2 to 36 or from −2 to −36.
    /// Up to n digits digits will be generated. Trailing zeros are not returned. No more digits than
    /// can be accurately represented by op are ever generated. If n digits is 0 then that accurate
    /// maximum number of digits are generated.
    /// For base in the range 2..36, digits and lower-case letters are used; for −2..−36, digits and
    /// upper-case letters are used; for 37..62, digits, upper-case letters, and lower-case letters (in
    /// that significance order) are used.
    /// If str is NULL, the result string is allocated using the current allocation function (see
    /// Chapter 14 [Custom Allocation], page 106). The block will be strlen(str)+1 bytes, that
    /// being exactly enough for the string and null-terminator.
    /// If str is not NULL, it should point to a block of n digits + 2 bytes, that being enough for
    /// the mantissa, a possible minus sign, and a null-terminator. When n digits is 0 to get all
    /// significant digits, an application won’t be able to know the space required, and str should be
    /// NULL in that case.
    /// The generated string is a fraction, with an implicit radix point immediately to the left of the
    /// first digit. The applicable exponent is written through the expptr pointer. For example, the
    /// number 3.1416 would be returned as string "31416" and exponent 1.
    /// When op is zero, an empty string is produced and the exponent returned is 0.
    /// A pointer to the result string is returned, being either the allocated block or the given str.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="exp"></param>
    /// <param name="base"></param>
    /// <param name="nDigits"></param>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_get_str))]
    internal static extern Utf8StringPtr mpf_get_str(Utf8StringPtr str, out nint exp, int @base, nuint nDigits, in Mpf op);

    /// <summary>
    /// Set rop to op1 + op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_add))]
    internal static extern void mpf_add(ref Mpf rop, in Mpf op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1 + op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_add_ui))]
    internal static extern void mpf_add_ui(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to op1 - op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_sub))]
    internal static extern void mpf_sub(ref Mpf rop, in Mpf op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1 - op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_ui_sub))]
    internal static extern void mpf_ui_sub(ref Mpf rop, nuint op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1 - op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_sub_ui))]
    internal static extern void mpf_sub_ui(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_mul))]
    internal static extern void mpf_mul(ref Mpf rop, in Mpf op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1 × op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_mul_ui))]
    internal static extern void mpf_mul_ui(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to op1/op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_div))]
    internal static extern void mpf_div(ref Mpf rop, in Mpf op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1/op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_ui_div))]
    internal static extern void mpf_ui_div(ref Mpf rop, nuint op1, in Mpf op2);

    /// <summary>
    /// Set rop to op1/op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_div_ui))]
    internal static extern void mpf_div_ui(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to square root of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_sqrt))]
    internal static extern void mpf_sqrt(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set rop to square root of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_sqrt_ui))]
    internal static extern void mpf_sqrt_ui(ref Mpf rop, nuint op);

    /// <summary>
    /// Set rop to op1^op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_pow_ui))]
    internal static extern void mpf_pow_ui(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to −op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_neg))]
    internal static extern void mpf_neg(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set rop to the absolute value of op.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_abs))]
    internal static extern void mpf_abs(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set rop to op1 × 2^op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_mul_2exp))]
    internal static extern void mpf_mul_2exp(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Set rop to op1/2^op2.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_div_2exp))]
    internal static extern void mpf_div_2exp(ref Mpf rop, in Mpf op1, nuint op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_cmp))]
    internal static extern int mpf_cmp(in Mpf op1, in Mpf op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// mpf_cmp_d can be called with an infinity, but results are undefined for a NaN.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_cmp_d))]
    internal static extern int mpf_cmp_d(in Mpf op1, double op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_cmp_ui))]
    internal static extern int mpf_cmp_ui(in Mpf op1, nuint op2);

    /// <summary>
    /// Compare op1 and op2. Return a positive value if op1 > op2, zero if op1 = op2, and a
    /// negative value if op1 &lt; op2.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_cmp_si))]
    internal static extern int mpf_cmp_si(in Mpf op1, nint op2);

    /// <summary>
    /// Return non-zero if the first op3 bits of op1 and op2 are equal, zero otherwise. I.e., test if
    /// op1 and op2 are approximately equal.
    /// In the future values like 1000 and 0111 may be considered the same to 3 bits (on the basis
    /// that their difference is that small).
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <param name="op3"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_eq))]
    internal static extern int mpf_eq(in Mpf op1, in Mpf op2, nuint op3);

    /// <summary>
    /// Compute the relative difference between op1 and op2 and store the result in rop. This is
    /// |op1 − op2|/op1.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_reldiff))]
    internal static extern void mpf_reldiff(ref Mpf rop, in Mpf op1, in Mpf op2);

    /// <summary>
    /// Return +1 if op > 0, 0 if op = 0, and −1 if op &lt; 0.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int mpf_sgn(in Mpf op) => System.Math.Sign(op.MpSize);

    /// <summary>
    /// Set rop to op rounded to the next higher integer.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_ceil))]
    internal static extern void mpf_ceil(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set rop to op rounded to the next lower integer.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_floor))]
    internal static extern void mpf_floor(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Set rop to op rounded to the integer towards zero.
    /// </summary>
    /// <param name="rop"></param>
    /// <param name="op"></param>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_trunc))]
    internal static extern void mpf_trunc(ref Mpf rop, in Mpf op);

    /// <summary>
    /// Return non-zero if op is an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_integer_p))]
    internal static extern int mpf_integer_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_ulong_p))]
    internal static extern int mpf_fits_ulong_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_slong_p))]
    internal static extern int mpf_fits_slong_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_uint_p))]
    internal static extern int mpf_fits_uint_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_sint_p))]
    internal static extern int mpf_fits_sint_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_ushort_p))]
    internal static extern int mpf_fits_ushort_p(in Mpf op);

    /// <summary>
    /// Return non-zero if op would fit in the respective data type, when truncated to an integer.
    /// </summary>
    /// <param name="op"></param>
    /// <returns></returns>
    [DllImport(LibraryName, EntryPoint = Prefix + nameof(mpf_fits_sshort_p))]
    internal static extern int mpf_fits_sshort_p(in Mpf op);
}
