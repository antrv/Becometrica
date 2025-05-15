using System.Runtime.InteropServices;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /**
         * Return the timestamp for use with Clang's
         * \c -fbuild-session-timestamp= option.
         */
        [DllImport(LibraryName)]
        public static extern ulong clang_getBuildSessionTimestamp();

        /**
         * Create a \c CXVirtualFileOverlay object.
         * Must be disposed with \c clang_VirtualFileOverlay_dispose().
         *
         * \param options is reserved, always pass 0.
         */
        [DllImport(LibraryName)]
        public static extern CXVirtualFileOverlay clang_VirtualFileOverlay_create(uint options);

        /**
         * Map an absolute virtual file path to an absolute real one.
         * The virtual path must be canonicalized (not contain "."/"..").
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_VirtualFileOverlay_addFileMapping(CXVirtualFileOverlay fileOverlay,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string virtualPath,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string realPath);

        /**
         * Set the case sensitivity for the \c CXVirtualFileOverlay object.
         * The \c CXVirtualFileOverlay object is case-sensitive by default, this
         * option can be used to override the default.
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_VirtualFileOverlay_setCaseSensitivity(CXVirtualFileOverlay fileOverlay,
            int caseSensitive);

        /**
         * Write out the \c CXVirtualFileOverlay object to a char buffer.
         *
         * \param options is reserved, always pass 0.
         * \param out_buffer_ptr pointer to receive the buffer pointer, which should be
         * disposed using \c clang_free().
         * \param out_buffer_size pointer to receive the buffer size.
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_VirtualFileOverlay_writeToBuffer(CXVirtualFileOverlay fileOverlay,
            uint options, Ptr<Ptr<byte>> out_buffer_ptr, Ptr<uint> out_buffer_size);

        /**
         * free memory allocated by libclang, such as the buffer returned by
         * \c CXVirtualFileOverlay() or \c clang_ModuleMapDescriptor_writeToBuffer().
         *
         * \param buffer memory pointer to free.
         */
        [DllImport(LibraryName)]
        public static extern void clang_free(Ptr<byte> buffer);

        /**
         * Dispose a \c CXVirtualFileOverlay object.
         */
        [DllImport(LibraryName)]
        public static extern void clang_VirtualFileOverlay_dispose(CXVirtualFileOverlay fileOverlay);

        /**
         * Create a \c CXModuleMapDescriptor object.
         * Must be disposed with \c clang_ModuleMapDescriptor_dispose().
         *
         * \param options is reserved, always pass 0.
         */
        [DllImport(LibraryName)]
        public static extern CXModuleMapDescriptor clang_ModuleMapDescriptor_create(uint options);

        /**
         * Sets the framework module name that the module.modulemap describes.
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_ModuleMapDescriptor_setFrameworkModuleName(
            CXModuleMapDescriptor descriptor, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        /**
         * Sets the umbrella header name that the module.modulemap describes.
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_ModuleMapDescriptor_setUmbrellaHeader(CXModuleMapDescriptor descriptor,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string namename);

        /**
         * Write out the \c CXModuleMapDescriptor object to a char buffer.
         *
         * \param options is reserved, always pass 0.
         * \param out_buffer_ptr pointer to receive the buffer pointer, which should be
         * disposed using \c clang_free().
         * \param out_buffer_size pointer to receive the buffer size.
         * \returns 0 for success, non-zero to indicate an error.
         */
        [DllImport(LibraryName)]
        public static extern CXErrorCode clang_ModuleMapDescriptor_writeToBuffer(CXModuleMapDescriptor descriptor,
            uint options, Ptr<Ptr<byte>> out_buffer_ptr, Ptr<uint> out_buffer_size);

        /**
         * Dispose a \c CXModuleMapDescriptor object.
         */
        [DllImport(LibraryName)]
        public static extern void clang_ModuleMapDescriptor_dispose(CXModuleMapDescriptor descriptor);
    }
}