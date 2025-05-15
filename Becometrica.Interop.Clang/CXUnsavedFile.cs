namespace Becometrica.Interop.Clang;

/**
 * Provides the contents of a file that has not yet been saved to disk.
 *
 * Each CXUnsavedFile instance provides the name of a file on the
 * system along with the current contents of that file that have not
 * yet been saved to disk.
 */
public struct CXUnsavedFile
{
   /**
      * The file whose contents have not yet been saved.
      *
      * This file must already exist in the file system.
      */
   public ConstPtr<byte> Filename;

   /**
      * A buffer containing the unsaved contents of this file.
      */
   public ConstPtr<byte> Contents;

   /**
      * The length of the unsaved contents of this buffer.
      */
   public uint Length; // unsigned long
}