using Microsoft.WindowsAPICodePack.Taskbar;
using OFGmCoreCS.LoggerSimple;
using OFGmCoreCS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Overwritten
    {
        private void Replace()
        {
            AddItemNotCopy(searchCombo.Items, searchCombo.Text);
            AddItemNotCopy(replacementCombo.Items, replacementCombo.Text);
            AddItemNotCopy(searchDirectoryCombo.Items, searchDirectoryCombo.Text);

            replaceButton.Enabled = false;
            cancelButton.Enabled = true;

            if (searchCombo.Text != (string)searchCombo.Tag && replacementCombo.Text != (string)replacementCombo.Tag && searchDirectoryCombo.Text != "")
            {
                try
                {
                    files = GetAllFiles(searchDirectoryCombo.Text);
                    progressBar.Maximum = files.Count;
                    progressBar.Visible = true;
                    
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                    if (!replaceWorker.IsBusy)
                        replaceWorker.RunWorkerAsync((searchCombo.Text, replacementCombo.Text, fullNameCheck.Checked, nameChangeCheck.Checked, undoCheck.Checked, progressBar, logger));
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

        private void AddItemNotCopy(IList list, string item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        private List<string> GetAllFiles(string directoryPath)
        {
            List<string> files = Directory.EnumerateFiles(directoryPath).ToList();

            if (searchSubdirectoriesCheck.Checked)
            {
                Directory.EnumerateDirectories(directoryPath)
                         .SelectMany(subDirectory => GetAllFiles(subDirectory))
                         .ToList()
                         .ForEach(file => files.Add(file));
            }

            return files;
        }

        public void Cancel(long id, int historyIndex)
        {
            Cancel(id);

            removeHistoryIndex = historyIndex;
        }

        public void Cancel(long id) //TODO: Неправильный progressBar при отмене во время замены
        {
            if (!cancelWorker.IsBusy)
            {
                if (replaceWorker.IsBusy)
                    replaceWorker.CancelAsync();

                replaceButton.Enabled = false;
                cancelButton.Enabled = false;
                progressBar.Value = progressBar.Minimum;

                progressBar.Maximum = undoFiles[id].Count + createFiles[id].Count;
                progressBar.Visible = true;

                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                cancelWorker.RunWorkerAsync((id, progressBar, logger));
            }
            else
                ShowMessageBoxWithLog("Отмена уже выполняется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
        }

        private void LogWritten(string message, LoggerLevel loggerLevel)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    LogWritten(message, loggerLevel);
                });
                return;
            }

            int startSelect = logForm.logTextBox.TextLength;

            logForm.logTextBox.AppendText(message);

            logForm.logTextBox.Select(startSelect, logForm.logTextBox.TextLength);
            logForm.logTextBox.SelectionColor = LoggerLevelColor.GetColor(loggerLevel);
            logForm.logTextBox.DeselectAll();
        }

        public DialogResult ShowMessageBoxWithLog(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, LoggerLevel logLevel)
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

        private void FileLinkEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && File.Exists(((string[])e.Data.GetData(DataFormats.FileDrop))[0]))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        public string GetReport() //TODO: У ComboBox нет текста
        {
            StringBuilder report = new StringBuilder();

            report.Append("Search: " + searchCombo.Text);
            report.AppendLine("Replacement: " + replacementCombo.Text);
            report.AppendLine("Search Directory: " + searchDirectoryCombo.Text + Environment.NewLine);

            report.AppendLine("Full Name: " + fullNameCheck.Checked);
            report.AppendLine("Name Change: " + nameChangeCheck.Checked);
            report.AppendLine("Undo: " + undoCheck.Checked);
            report.AppendLine("Search Subdirectories: " + searchSubdirectoriesCheck.Checked + Utils.LineSeparator);

            return report.ToString();
        }

        private static void LoggerWrite(ProgressBar progressBar, Logger logger, string file)
        {
            logger.Write($"[{progressBar.Value}/{progressBar.Maximum}] " + file, LoggerLevel.Info);
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
