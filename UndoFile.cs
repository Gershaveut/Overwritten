using System.IO;

namespace Overwritten
{
    public class UndoFile
    {
        private string file;
        public string undoPath;

        public UndoFile(string file)
        {
            this.file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            File.Copy(file, this.file, true);
            undoPath = file;
        }

        public void Undo()
        {
            File.Copy(file, undoPath, true);
            File.Delete(file);
        }

        public void Delete()
        {
            File.Delete(file);
        }
    }
}
