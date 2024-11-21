using System.Runtime.InteropServices;
using Becometrica.Unsafe;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /// <summary>
        /// Retrieve the character data associated with the given string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [DllImport(LibraryName)]
        public static extern Utf8StringPtr clang_getCString(CXString str);

        /// <summary>
        /// Free the given string.
        /// </summary>
        /// <param name="str"></param>
        [DllImport(LibraryName)]
        public static extern void clang_disposeString(CXString str);

        /// <summary>
        /// Free the given string set.
        /// </summary>
        /// <param name="str"></param>
        [DllImport(LibraryName)]
        public static extern void clang_disposeStringSet(Ptr<CXStringSet> str);
    }
}