using System;
using System.Windows.Forms;
using OFGmCoreCS.Util;

namespace Overwritten
{
    internal static class Program
    {
        public static bool debug;
        public static string[] args;

        public static Overwritten overwritten;

        [STAThread]
        static void Main(string[] args)
        {
            #if DEBUG
            debug = true;
            #endif

            Program.args = args;

            #if !DEBUG
            try
            {
            #endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                overwritten = new Overwritten();
                Application.Run(overwritten);
            #if !DEBUG
            }
            catch (Exception ex)
            {
                MessageBox.Show(CrashReporter.CreateReport(ex), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endif
            
            overwritten.ClearUndoFiles();
        }
    }
}
