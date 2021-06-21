using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Application.ThreadException += ThreadException;
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ThreadException(sender, new ThreadExceptionEventArgs(e.ExceptionObject as Exception));
        }

        private static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"{e.Exception + e.Exception.StackTrace}\nUNHANDLED EXCEPTION. Please report a bug here: https://discord.gg/XW7XhXuZ89 or on github page.");
        }
    }
}
