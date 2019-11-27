using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Helpers.Files
{
    class FilesManager
    {
        public static string GetNameWithTime(string name)
        {
            return name + " " + DateTime.Now.ToString().Replace('/', '_').Replace(':', '-');
        }

        public static void CopyDirectoryTree(string source, string target)
        {
            //We create a folder specially for the save
            Directory.CreateDirectory(target);
            foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(source, target));
        }

        public static long GetFilesSize(string[] files)
        {
            return files.Sum(f => new FileInfo(f).Length);
        }
    }
}
