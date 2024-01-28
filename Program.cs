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

            foreach (UndoFile file in overwritten.undoFiles)
            {
                file.Delete();
            }
        }
    }
}
