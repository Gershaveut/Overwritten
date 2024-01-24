using System;
using System.Windows.Forms;

namespace Overwritten
{
    internal static class Program
    {
        public static Overwritten overwritten;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            overwritten = new Overwritten();
            Application.Run(overwritten);

            foreach (UndoFile file in overwritten.undoFiles)
            {
                file.Delete();
            }
        }
    }
}
