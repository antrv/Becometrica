using System.Runtime.InteropServices;
using Becometrica.Unsafe;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /**
         * Retrieve the complete file and path name of the given file.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_getFileName(CXFile SFile);

        /**
         * Retrieve the last modification time of the given file.
         */
        [DllImport(LibraryName)]
        public static extern long clang_getFileTime(CXFile SFile);

        /**
         * Retrieve the unique ID for the given \c file.
         *
         * \param file the file to get the ID for.
         * \param outID stores the returned CXFileUniqueID.
         * \returns If there was a failure getting the unique ID, returns non-zero,
         * otherwise returns 0.
         */
        [DllImport(LibraryName)]
        public static extern int clang_getFileUniqueID(CXFile file, out CXFileUniqueID outID);

        /**
         * Returns non-zero if the \c file1 and \c file2 point to the same file,
         * or they are both NULL.
         */
        [DllImport(LibraryName)]
        public static extern int clang_File_isEqual(CXFile file1, CXFile file2);

        /**
         * Returns the real path name of \c file.
         *
         * An empty string may be returned. Use \c clang_getFileName() in that case.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_File_tryGetRealPathName(CXFile file);
    }
}