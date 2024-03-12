using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OFGmCoreCS.Util;

namespace Overwritten
{
    internal static class Program
    {
        public static bool debug;
        public static string[] args;
        public static string logPath = Path.Combine(Directory.GetCurrentDirectory(), "log");

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
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                overwritten = new Overwritten();
                Application.Run(overwritten);
            #if !DEBUG
            }
            catch (Exception ex)
            {
                new CrashReport(CrashReporter.CreateReport(ex, new FileLogger("CrashReport", logPath), overwritten.GetReport())).ShowDialog();
            }
            #endif

            overwritten.logger.fileLogger.SaveFile();
            overwritten.ClearUndoFiles();
        }
    }
}
