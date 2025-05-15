using System.Runtime.InteropServices;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /**
         * Retrieve a NULL (invalid) source location.
         */
        [DllImport(LibraryName)]
        public static extern CXSourceLocation clang_getNullLocation();

        /**
         * Determine whether two source locations, which must refer into
         * the same translation unit, refer to exactly the same point in the source
         * code.
         *
         * \returns non-zero if the source locations refer to the same location, zero
         * if they refer to different locations.
         */
        [DllImport(LibraryName)]
        public static extern uint clang_equalLocations(CXSourceLocation loc1, CXSourceLocation loc2);

        /**
         * Returns non-zero if the given source location is in a system header.
         */
        [DllImport(LibraryName)]
        public static extern int clang_Location_isInSystemHeader(CXSourceLocation location);

        /**
         * Returns non-zero if the given source location is in the main file of
         * the corresponding translation unit.
         */
        [DllImport(LibraryName)]
        public static extern int clang_Location_isFromMainFile(CXSourceLocation location);

        /**
         * Retrieve a NULL (invalid) source range.
         */
        [DllImport(LibraryName)]
        public static extern CXSourceRange clang_getNullRange();

        /**
         * Retrieve a source range given the beginning and ending source
         * locations.
         */
        [DllImport(LibraryName)]
        public static extern CXSourceRange clang_getRange(CXSourceLocation begin, CXSourceLocation end);

        /**
         * Determine whether two ranges are equivalent.
         *
         * \returns non-zero if the ranges are the same, zero if they differ.
         */
        [DllImport(LibraryName)]
        public static extern uint clang_equalRanges(CXSourceRange range1, CXSourceRange range2);

        /**
         * Returns non-zero if \p range is null.
         */
        [DllImport(LibraryName)]
        public static extern int clang_Range_isNull(CXSourceRange range);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro expansion, retrieves the
         * location of the macro expansion.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        [DllImport(LibraryName)]
        public static extern void clang_getExpansionLocation(CXSourceLocation location,
                                                             Ptr<CXFile> file, Ptr<uint> line,
                                                             Ptr<uint> column,
                                                             Ptr<uint> offset);

        /**
         * Retrieve the file, line and column represented by the given source
         * location, as specified in a # line directive.
         *
         * Example: given the following source code in a file somefile.c
         *
         * \code
         * #123 "dummy.c" 1
         *
         * static int func(void)
         * {
         *     return 0;
         * }
         * \endcode
         *
         * the location information returned by this function would be
         *
         * File: dummy.c Line: 124 Column: 12
         *
         * whereas clang_getExpansionLocation would have returned
         *
         * File: somefile.c Line: 3 Column: 12
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param filename [out] if non-NULL, will be set to the filename of the
         * source location. Note that filenames returned will be for "virtual" files,
         * which don't necessarily exist on the machine running clang - e.g. when
         * parsing preprocessed output obtained from a different environment. If
         * a non-NULL value is passed in, remember to dispose of the returned value
         * using \c clang_disposeString() once you've finished with it. For an invalid
         * source location, an empty string is returned.
         *
         * \param line [out] if non-NULL, will be set to the line number of the
         * source location. For an invalid source location, zero is returned.
         *
         * \param column [out] if non-NULL, will be set to the column number of the
         * source location. For an invalid source location, zero is returned.
         */
        public static extern void clang_getPresumedLocation(CXSourceLocation location,
                                                            Ptr<CXString> filename,
                                                            Ptr<uint> line, Ptr<uint> column);

        /**
         * Legacy API to retrieve the file, line, column, and offset represented
         * by the given source location.
         *
         * This interface has been replaced by the newer interface
         * #clang_getExpansionLocation(). See that interface's documentation for
         * details.
         */
        public static extern void clang_getInstantiationLocation(CXSourceLocation location,
                                                                 Ptr<CXFile> file, Ptr<uint> line,
                                                                 Ptr<uint> column,
                                                                 Ptr<uint> offset);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro instantiation, return where the
         * location was originally spelled in the source file.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        public static extern void clang_getSpellingLocation(CXSourceLocation location,
                                                            Ptr<CXFile> file, Ptr<uint> line,
                                                            Ptr<uint> column,
                                                            Ptr<uint> offset);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro expansion, return where the macro was
         * expanded or where the macro argument was written, if the location points at
         * a macro argument.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        public static extern void clang_getFileLocation(CXSourceLocation location,
                                                        Ptr<CXFile> file, Ptr<uint> line,
                                                        Ptr<uint> column, Ptr<uint> offset);

        /**
         * Retrieve a source location representing the first character within a
         * source range.
         */
        public static extern CXSourceLocation clang_getRangeStart(CXSourceRange range);

        /**
         * Retrieve a source location representing the last character within a
         * source range.
         */
        public static extern CXSourceLocation clang_getRangeEnd(CXSourceRange range);

        /**
         * Destroy the given \c CXSourceRangeList.
         */
        public static extern void clang_disposeSourceRangeList(Ptr<CXSourceRangeList> ranges);
    }
}