using OFGmCoreCS.LoggerSimple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Overwritten
    {
        private void Replace()
        {
            replaceButton.Enabled = false;
            cancelButton.Enabled = true;

            if (searchCombo.Text != (string)searchCombo.Tag && replacementCombo.Text != (string)replacementCombo.Tag && searchDirectoryCombo.Text != "")
            {
                try
                {
                    files = GetAllFiles(searchDirectoryCombo.Text);
                    progressBar.Maximum = files.Count;
                    progressBar.Visible = true;

                    fullNameCheckChecked = fullNameCheck.Checked;
                    searchComboText = searchCombo.Text;

                    nameChangeCheckChecked = nameChangeCheck.Checked;
                    undoCheckChecked = undoCheck.Checked;
                    replacementComboText = replacementCombo.Text;

                    if (!replaceWorker.IsBusy)
                        replaceWorker.RunWorkerAsync();
                    else
                        ShowMessageBoxWithLog("Замена уже выполняется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException)
                        requireAdministrator.Visible = true;
                    else
                        ShowMessageBoxWithLog("Поля заполнены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

                    replaceButton.Enabled = true;
                    cancelButton.Enabled = false;
                }
            }
            else
            {
                ShowMessageBoxWithLog("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
                replaceButton.Enabled = true;
                cancelButton.Enabled = false;
            }
        }

        private List<string> GetAllFiles(string directoryPath)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                files.Add(file);
            }

            if (searchSubdirectoriesCheck.Checked)
            {
                foreach (string subDirectory in Directory.GetDirectories(directoryPath))
                {
                    files.AddRange(GetAllFiles(subDirectory));
                }
            }

            return files;
        }

        public void Cancel(int id, int historyIndex)
        {
            if (!cancelWorker.IsBusy)
            {
                if (replaceWorker.IsBusy)
                    replaceWorker.CancelAsync();
                else
                {
                    historyForm.historyDataGridView.Rows.RemoveAt(historyIndex);

                    logger.Write($"Удаление {historyIndex} записи в истории", LoggerLevel.Info);
                }

                replaceButton.Enabled = false;
                cancelButton.Enabled = false;
                progressBar.Value = 0;

                progressBar.Maximum = undoFiles[id].Count + createFiles[id].Count;
                progressBar.Visible = true;

                cancelWorker.RunWorkerAsync(id);
            }
            else
                ShowMessageBoxWithLog("Отмена уже выполняется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
        }

        private void LogWritten(string message, LoggerLevel loggerLevel)
        {
            logForm.logTextBox.AppendText(message);

            logForm.logTextBox.Select(logForm.logTextBox.TextLength - message.Length, logForm.logTextBox.TextLength);
            logForm.logTextBox.SelectionColor = LoggerLevelColor.GetColor(loggerLevel);
            logForm.logTextBox.DeselectAll();
        }

        private DialogResult ShowMessageBoxWithLog(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, LoggerLevel logLevel)
        {
            logger.Write(text, logLevel);
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public void ClearUndoFiles()
        {
            foreach (var undoFile in undoFiles)
            {
                foreach (UndoFile file in undoFiles[undoFile.Key])
                {
                    file.Delete();
                }
            }
        }

        public class UndoFile
        {
            private readonly string file;

            public readonly string undoPath;

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
}
