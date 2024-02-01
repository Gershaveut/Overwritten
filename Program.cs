using System;
using System.Windows.Forms;

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

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                overwritten = new Overwritten();
                Application.Run(overwritten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (var undoFiles in overwritten.undoFiles)
            {
                foreach (UndoFile file in overwritten.undoFiles[undoFiles.Key])
                {
                    file.Delete();
                }
            }
        }
    }
}
