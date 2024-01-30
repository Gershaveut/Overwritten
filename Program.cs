using OFGmCoreCS.Argument;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Overwritten
{
    internal static class Program
    {
        public static bool debug;
        public static string[] args;
        public static ArgumentHandler argumentHandler;

        public static Overwritten overwritten;

        [STAThread]
        static void Main(string[] args)
        {
            #if DEBUG
            debug = true;
            #endif

            Program.args = args;

            try
            {
                argumentHandler = new ArgumentHandler(new HashSet<AbstractArgument>
                {
                new Argument("debug", () => debug = true)
                });

                argumentHandler.ArgumentsInvoke(args);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                overwritten = new Overwritten();
                Application.Run(overwritten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (UndoFile file in overwritten.undoFiles)
            {
                file.Delete();
            }
        }
    }
}
