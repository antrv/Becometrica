using Becometrica.Unsafe;

namespace Becometrica.Interop.Clang;

/**
 * Opaque pointer representing client data that will be passed through
 * to various callbacks and visitors.
 */
public readonly struct CXClientData(nint value)
{
    private readonly nint _value = value;
}

/**
 * Index initialization options.
 *
 * 0 is the default value of each member of this struct except for Size.
 * Initialize the struct in one of the following three ways to avoid adapting
 * code each time a new member is added to it:
 * \code
 * CXIndexOptions Opts;
 * memset(&Opts, 0, sizeof(Opts));
 * Opts.Size = sizeof(CXIndexOptions);
 * \endcode
 * or explicitly initialize the first data member and zero-initialize the rest:
 * \code
 * CXIndexOptions Opts = { sizeof(CXIndexOptions) };
 * \endcode
 * or to prevent the -Wmissing-field-initializers warning for the above version:
 * \code
 * CXIndexOptions Opts{};
 * Opts.Size = sizeof(CXIndexOptions);
 * \endcode
 */
public struct CXIndexOptions
{
    /**
     * The size of struct CXIndexOptions used for option versioning.
     *
     * Always initialize this member to sizeof(CXIndexOptions), or assign
     * sizeof(CXIndexOptions) to it right after creating a CXIndexOptions object.
     */
    public uint Size;

    /**
     * A CXChoice enumerator that specifies the indexing priority policy.
     * \sa CXGlobalOpt_ThreadBackgroundPriorityForIndexing
     */
    public byte ThreadBackgroundPriorityForIndexing;

    /**
     * A CXChoice enumerator that specifies the editing priority policy.
     * \sa CXGlobalOpt_ThreadBackgroundPriorityForEditing
     */
    public byte ThreadBackgroundPriorityForEditing;

    public ushort Flags; // see below
    /**
     * \see clang_createIndex()
     */
    //public unsigned ExcludeDeclarationsFromPCH : 1;

    /**
     * \see clang_createIndex()
     */
    //public unsigned DisplayDiagnostics : 1;

    /**
     * Store PCH in memory. If zero, PCH are stored in temporary files.
     */
    //public unsigned StorePreamblesInMemory : 1;
    //public unsigned /*Reserved*/ : 13;

    /**
     * The path to a directory, in which to store temporary PCH files. If null or
     * empty, the default system temporary directory is used. These PCH files are
     * deleted on clean exit but stay on disk if the program crashes or is killed.
     *
     * This option is ignored if \a StorePreamblesInMemory is non-zero.
     *
     * Libclang does not create the directory at the specified path in the file
     * system. Therefore it must exist, or storing PCH files will fail.
     */
    public Utf8StringPtr PreambleStoragePath;

    /**
     * Specifies a path which will contain log files for certain libclang
     * invocations. A null value implies that libclang invocations are not logged.
     */
    public Utf8StringPtr InvocationEmissionPath;
}