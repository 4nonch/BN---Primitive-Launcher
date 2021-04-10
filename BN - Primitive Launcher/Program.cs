using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BN_Primitive_Launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.LanguageState == "EN" && InitdeDEDll()) // Create dll if it's missing.
            {
                // Restart the application if the language-package was added
                Application.Restart();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static bool InitdeDEDll()
        {
            try
            {
                // Language of my package. This will be the name of the subfolder.
                string language = "en";
                return TryCreateFileFromRessource(language, @"BN - Primitive Launcher.resources.dll", Properties.Resources.BN___Primitive_Launcher_resources);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool TryCreateFileFromRessource(string subfolder, string fileName, byte[] buffer)
        {
            try
            {
                // path of the subfolder
                string subfolderPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + (subfolder != "" ? @"\" : "") + subfolder;

                // Create subfolder if it doesn't exist
                if (!System.IO.Directory.Exists(subfolder))
                    System.IO.Directory.CreateDirectory(subfolderPath);


                fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + subfolder + (subfolder != "" ? @"\" : "") + fileName;
                if (!System.IO.File.Exists(fileName)) // if the dll doesn't already exist, it has to be created
                {
                    // Write dll
                    System.IO.Stream stream = System.IO.File.Create(fileName);
                    stream.Write(buffer, 0, buffer.GetLength(0));
                    stream.Close();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
