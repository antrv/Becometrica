using System.Runtime.InteropServices;

namespace Becometrica.Interop.Clang;

public static partial class LibClang
{
    private static partial class Interop
    {
        /**
         * Creates a compilation database from the database found in directory
         * buildDir. For example, CMake can output a compile_commands.json which can
         * be used to build the database.
         *
         * It must be freed by \c clang_CompilationDatabase_dispose.
         */
        [DllImport(LibraryName)]
        public static extern CXCompilationDatabase clang_CompilationDatabase_fromDirectory(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string BuildDir,
            out CXCompilationDatabase_Error ErrorCode);

        /**
         * Free the given compilation database
         */
        [DllImport(LibraryName)]
        public static extern void clang_CompilationDatabase_dispose(CXCompilationDatabase database);

        /**
         * Find the compile commands used for a file. The compile commands
         * must be freed by \c clang_CompileCommands_dispose.
         */
        [DllImport(LibraryName)]
        public static extern CXCompileCommands clang_CompilationDatabase_getCompileCommands(
            CXCompilationDatabase database,  [MarshalAs(UnmanagedType.LPUTF8Str)] string CompleteFileName);

        /**
         * Get all the compile commands in the given compilation database.
         */
        [DllImport(LibraryName)]
        public static extern CXCompileCommands clang_CompilationDatabase_getAllCompileCommands(
            CXCompilationDatabase database);

        /**
         * Free the given CompileCommands
         */
        [DllImport(LibraryName)]
        public static extern void clang_CompileCommands_dispose(CXCompileCommands commands);

        /**
         * Get the number of CompileCommand we have for a file
         */
        [DllImport(LibraryName)]
        public static extern uint clang_CompileCommands_getSize(CXCompileCommands commands);

        /**
         * Get the I'th CompileCommand for a file
         *
         * Note : 0 <= i < clang_CompileCommands_getSize(CXCompileCommands)
         */
        [DllImport(LibraryName)]
        public static extern CXCompileCommand clang_CompileCommands_getCommand(CXCompileCommands commands, uint I);

        /**
         * Get the working directory where the CompileCommand was executed from
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_CompileCommand_getDirectory(CXCompileCommand command);

        /**
         * Get the filename associated with the CompileCommand.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_CompileCommand_getFilename(CXCompileCommand command);

        /**
         * Get the number of arguments in the compiler invocation.
         *
         */
        [DllImport(LibraryName)]
        public static extern uint clang_CompileCommand_getNumArgs(CXCompileCommand command);

        /**
         * Get the I'th argument value in the compiler invocations
         *
         * Invariant :
         *  - argument 0 is the compiler executable
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_CompileCommand_getArg(CXCompileCommand command, uint I);

        /**
         * Get the number of source mappings for the compiler invocation.
         */
        [DllImport(LibraryName)]
        public static extern uint
            clang_CompileCommand_getNumMappedSources(CXCompileCommand command);

        /**
         * Get the I'th mapped source path for the compiler invocation.
         */
        [DllImport(LibraryName)]
        public static extern CXString
            clang_CompileCommand_getMappedSourcePath(CXCompileCommand command, uint I);

        /**
         * Get the I'th mapped source content for the compiler invocation.
         */
        [DllImport(LibraryName)]
        public static extern CXString clang_CompileCommand_getMappedSourceContent(CXCompileCommand command, uint I);
    }
}