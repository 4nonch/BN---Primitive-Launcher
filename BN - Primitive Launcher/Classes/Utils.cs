using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BN_Primitive_Launcher.Classes
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Copy directires with replacement
        /// </summary>
        /// <param name="sourceDirectory">Source directory path</param>
        /// <param name="targetDirectory">Destination directory path</param>
        public static void CopyDirectories(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyDirectories(diSource, diTarget);
        }

        /// <summary>
        /// Copy directires with replacement
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Destination directory</param>
        public static void CopyDirectories(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectories(diSourceSubDir, nextTargetSubDir);
            }
        }

        public static bool CheckRootdir(string rootdir)
        {
            if (!System.IO.Directory.Exists(rootdir))
            {
                try
                {
                    Directory.CreateDirectory(rootdir);
                    return true;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Enter the correct path to the root folder");
                    return false;
                }
            }
            return true;
        }
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}
