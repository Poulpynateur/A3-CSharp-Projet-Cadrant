using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Helpers.Files
{
    /// <summary>
    /// Functions to interact with files and folders.
    /// </summary>
    static class FilesHelper
    {
        /// <summary>
        /// Generate a name from the actual date.
        /// </summary>
        /// <param name="name">Name to extend</param>
        /// <returns>Extended name with actual date.</returns>
        public static string GenerateName(string name)
        {
            return name + " " + DateTime.Now.ToString().Replace('/', '_').Replace(':', '-');
        }

        /// <summary>
        /// Copy a directory tree from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder to copy from</param>
        /// <param name="target">Target folder to copy to</param>
        public static void CopyDirectoryTree(string source, string target)
        {
            Directory.CreateDirectory(target);
            foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(source, target));
        }

        /// <summary>
        /// Get the size of an array of files path.
        /// </summary>
        /// <param name="files">Array of files path</param>
        /// <returns>Syze in byte</returns>
        public static long GetFilesSize(string[] files)
        {
            return files.Sum(f => new FileInfo(f).Length);
        }

        public static string GetFileExtension(string path)
        {
            string[] separators = { "." };
            string[] splits = path.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return splits[splits.Length - 1];
        }
    }
}
