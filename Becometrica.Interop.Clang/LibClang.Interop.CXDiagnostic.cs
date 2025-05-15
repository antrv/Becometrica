﻿using System.Runtime.InteropServices;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /// <summary>
        /// Determine the number of diagnostics in a CXDiagnosticSet.
        /// </summary>
        /// <param name="diags"></param>
        /// <returns></returns>
        [DllImport(LibraryName)]
        public static extern uint clang_getNumDiagnosticsInSet(CXDiagnosticSet diags);

        /**
         * Retrieve a diagnostic associated with the given CXDiagnosticSet.
         *
         * \param Diags the CXDiagnosticSet to query.
         * \param Index the zero-based diagnostic number to retrieve.
         *
         * \returns the requested diagnostic. This diagnostic must be freed
         * via a call to \c clang_disposeDiagnostic().
         */
        [DllImport(LibraryName)]
        public static extern CXDiagnostic clang_getDiagnosticInSet(CXDiagnosticSet diags, uint index);

        /**
         * Deserialize a set of diagnostics from a Clang diagnostics bitcode
         * file.
         *
         * \param file The name of the file to deserialize.
         * \param error A pointer to a enum value recording if there was a problem
         *        deserializing the diagnostics.
         * \param errorString A pointer to a CXString for recording the error string
         *        if the file was not successfully loaded.
         *
         * \returns A loaded CXDiagnosticSet if successful, and NULL otherwise.  These
         * diagnostics should be released using clang_disposeDiagnosticSet().
         */
        [DllImport(LibraryName)]
        public static extern CXDiagnosticSet clang_loadDiagnostics([MarshalAs(UnmanagedType.LPUTF8Str)] string file,
            out CXLoadDiag_Error error, out CXString errorString);

        /**
         * Release a CXDiagnosticSet and all of its contained diagnostics.
         */
        [DllImport(LibraryName)]
        public static extern void clang_disposeDiagnosticSet(CXDiagnosticSet diags);

        /**
         * Retrieve the child diagnostics of a CXDiagnostic.
         *
         * This CXDiagnosticSet does not need to be released by
         * clang_disposeDiagnosticSet.
         */
        [DllImport(LibraryName)]
        public static extern CXDiagnosticSet clang_getChildDiagnostics(CXDiagnostic d);

        /**
         * Destroy a diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern void clang_disposeDiagnostic(CXDiagnostic diagnostic);
        
        /**
         * Format the given diagnostic in a manner that is suitable for display.
         *
         * This routine will format the given diagnostic to a string, rendering
         * the diagnostic according to the various options given. The
         * \c clang_defaultDiagnosticDisplayOptions() function returns the set of
         * options that most closely mimics the behavior of the clang compiler.
         *
         * \param Diagnostic The diagnostic to print.
         *
         * \param Options A set of options that control the diagnostic display,
         * created by combining \c CXDiagnosticDisplayOptions values.
         *
         * \returns A new string containing for formatted diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_formatDiagnostic(CXDiagnostic diagnostic, uint options);

        /**
         * Retrieve the set of display options most similar to the
         * default behavior of the clang compiler.
         *
         * \returns A set of display options suitable for use with \c
         * clang_formatDiagnostic().
         */
        [DllImport(LibraryName)]
        public static extern uint clang_defaultDiagnosticDisplayOptions();

        /**
         * Determine the severity of the given diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern CXDiagnosticSeverity clang_getDiagnosticSeverity(CXDiagnostic diagnostic);

        /**
         * Retrieve the source location of the given diagnostic.
         *
         * This location is where Clang would print the caret ('^') when
         * displaying the diagnostic on the command line.
         */
        [DllImport(LibraryName)]
        public static extern CXSourceLocation clang_getDiagnosticLocation(CXDiagnostic diagnostic);

        /**
         * Retrieve the text of the given diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getDiagnosticSpelling(CXDiagnostic diagnostic);

        /**
         * Retrieve the name of the command-line option that enabled this
         * diagnostic.
         *
         * \param Diag The diagnostic to be queried.
         *
         * \param Disable If non-NULL, will be set to the option that disables this
         * diagnostic (if any).
         *
         * \returns A string that contains the command-line option used to enable this
         * warning, such as "-Wconversion" or "-pedantic".
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getDiagnosticOption(CXDiagnostic diag, Ptr<CXString> disable);

        /**
         * Retrieve the category number for this diagnostic.
         *
         * Diagnostics can be categorized into groups along with other, related
         * diagnostics (e.g., diagnostics under the same warning flag). This routine
         * retrieves the category number for the given diagnostic.
         *
         * \returns The number of the category that contains this diagnostic, or zero
         * if this diagnostic is uncategorized.
         */
        [DllImport(LibraryName)]
        public static extern uint clang_getDiagnosticCategory(CXDiagnostic diagnostic);

        /**
         * Retrieve the name of a particular diagnostic category.  This
         *  is now deprecated.  Use clang_getDiagnosticCategoryText()
         *  instead.
         *
         * \param Category A diagnostic category number, as returned by
         * \c clang_getDiagnosticCategory().
         *
         * \returns The name of the given diagnostic category.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getDiagnosticCategoryName(uint category);

        /**
         * Retrieve the diagnostic category text for a given diagnostic.
         *
         * \returns The text of the given diagnostic category.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getDiagnosticCategoryText(CXDiagnostic diagnostic);

        /**
         * Determine the number of source ranges associated with the given
         * diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern uint clang_getDiagnosticNumRanges(CXDiagnostic diagnostic);

        /**
         * Retrieve a source range associated with the diagnostic.
         *
         * A diagnostic's source ranges highlight important elements in the source
         * code. On the command line, Clang displays source ranges by
         * underlining them with '~' characters.
         *
         * \param Diagnostic the diagnostic whose range is being extracted.
         *
         * \param Range the zero-based index specifying which range to
         *
         * \returns the requested source range.
         */
        [DllImport(LibraryName)]
        public static extern CXSourceRange clang_getDiagnosticRange(CXDiagnostic Diagnostic, uint Range);

        /**
         * Determine the number of fix-it hints associated with the
         * given diagnostic.
         */
        [DllImport(LibraryName)]
        public static extern uint clang_getDiagnosticNumFixIts(CXDiagnostic Diagnostic);

        /**
         * Retrieve the replacement information for a given fix-it.
         *
         * Fix-its are described in terms of a source range whose contents
         * should be replaced by a string. This approach generalizes over
         * three kinds of operations: removal of source code (the range covers
         * the code to be removed and the replacement string is empty),
         * replacement of source code (the range covers the code to be
         * replaced and the replacement string provides the new code), and
         * insertion (both the start and end of the range point at the
         * insertion location, and the replacement string provides the text to
         * insert).
         *
         * \param Diagnostic The diagnostic whose fix-its are being queried.
         *
         * \param FixIt The zero-based index of the fix-it.
         *
         * \param ReplacementRange The source range whose contents will be
         * replaced with the returned replacement string. Note that source
         * ranges are half-open ranges [a, b), so the source code should be
         * replaced from a and up to (but not including) b.
         *
         * \returns A string containing text that should be replace the source
         * code indicated by the \c ReplacementRange.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getDiagnosticFixIt(
            CXDiagnostic Diagnostic, uint FixIt, Ptr<CXSourceRange> ReplacementRange);

    }
}