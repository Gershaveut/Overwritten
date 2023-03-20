using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwritten
{
    internal class UndoFile
    {
        private string file;
        private string undoPath;

        public UndoFile(string file) 
        {
            Directory.CreateDirectory(Path.GetTempPath() + "\\Overwritten");
            File.Copy(Path.GetTempPath() + "\\Overwritten", file);
            this.file = Path.GetTempPath() + "\\Overwritten\\" + Path.GetFileName(file);
            undoPath = file;
        }

        public void Undo()
        {
            File.Copy(undoPath, file);
        }
    }
}
