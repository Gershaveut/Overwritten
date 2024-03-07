using Microsoft.WindowsAPICodePack.Taskbar;
using OFGmCoreCS.LoggerSimple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace Overwritten
{
    public partial class Overwritten
    {
        private AutoResetEvent replaceWorkerLoggerWait = new(false);

        private void WorkersProgressChanged(string currentFileName, LoggerLevel loggerLevel)
        {
            progressBar.PerformStep();
            TaskbarManager.Instance.SetProgressValue(progressBar.Value, progressBar.Maximum);

            currentFileLabel.Text = currentFileName;
            fileCountLabel.Text = $"{progressBar.Value}/{progressBar.Maximum}";
        }

        private void WorkersProgressChanged((string message, Exception exception) report)
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);

            logger.Write(report.message + ": " + report.exception.Message, LoggerLevel.Warn);
            logger.Write(report.exception.ToString(), LoggerLevel.Debug);

            replaceWorkerLoggerWait.Set();
        }

        private void ReplaceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var arguments = ((string search, string replacement, bool fullName, bool nameChange, bool undo, ProgressBar progressBar, Logger logger))e.Argument;

            BackgroundWorker worker = sender as BackgroundWorker;

            long key = ++lastId;

            undoFiles.Add(key, new List<UndoFile>());
            createFiles.Add(key, new List<string>());

            foreach (string file in files)
            {
                if ((arguments.fullName ? arguments.search == Path.GetFileName(file) : arguments.search.Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries).Intersect(Path.GetFileName(file).Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries)).Any()) || arguments.search == "*")
                {
                    worker.ReportProgress(0, file);
                    LoggerWrite(arguments.progressBar, arguments.logger, "Замена: " + file);

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (arguments.undo)
                        undoFiles[key].Add(new UndoFile(file));

                    if (arguments.nameChange)
                    {
                        try
                        {
                            File.Move(file, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(arguments.replacement)));
                            File.Copy(arguments.replacement, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(arguments.replacement)), true);

                            if (arguments.undo)
                                createFiles[key].Add(Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(arguments.replacement)));
                            if (Path.GetFileName(file) != Path.GetFileName(arguments.replacement))
                                File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                            worker.ReportProgress(0, ("Не удалось изменить название файлу", ex));
                            replaceWorkerLoggerWait.WaitOne();
                        }
                    }
                    else
                        File.Copy(arguments.replacement, file, true);
                }
            }
        }

        private void ReplaceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is (string, Exception))
                WorkersProgressChanged(((string message, Exception exception))e.UserState);
            else
                WorkersProgressChanged("Замена: " + (string)e.UserState, LoggerLevel.Info);
        }

        private void WorkersRunWorkerCompleted(RunWorkerCompletedEventArgs e, string name)
        {
            currentFileLabel.Text = "";
            fileCountLabel.Text = "";
            if (!cancelWorker.IsBusy)
                cancelButton.Enabled = undoFiles.Count > 0;

            if (e.Error is UnauthorizedAccessException)
            {
                requireAdministrator.Visible = true;
            }
            else if (e.Error != null)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                ShowMessageBoxWithLog(e.Error.Message, "Ошибка в процессе " + name, MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

                logger.Write(e.Error.ToString(), LoggerLevel.Debug);
            }
        }

        private void ReplaceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            replaceButton.Enabled = !requireAdministrator.Visible && !cancelWorker.IsBusy;
            WorkersRunWorkerCompleted(e, "замены");

            if (!e.Cancelled)
            {
                if (e.Error != null)
                    ShowMessageBoxWithLog("Замена была провалена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

                if (progressBar.Value > progressBar.Minimum)
                {
                    progressBar.Value = progressBar.Minimum;

                    if (e.Error == null)
                        ShowMessageBoxWithLog("Замена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LoggerLevel.Info);

                    DataGridViewTextBoxCell searchCell = new DataGridViewTextBoxCell { Value = searchCombo.Text };
                    DataGridViewTextBoxCell replacementCell = new DataGridViewTextBoxCell { Value = replacementCombo.Text };
                    DataGridViewTextBoxCell searchDirectoryCell = new DataGridViewTextBoxCell { Value = searchDirectoryCombo.Text };
                    DataGridViewCheckBoxCell fullNameCell = new DataGridViewCheckBoxCell { Value = fullNameCheck.Checked };
                    DataGridViewCheckBoxCell nameChangeCell = new DataGridViewCheckBoxCell { Value = nameChangeCheck.Checked };
                    DataGridViewCheckBoxCell undoCell = new DataGridViewCheckBoxCell { Value = undoCheck.Checked };
                    DataGridViewCheckBoxCell searchSubdirectoriesCell = new DataGridViewCheckBoxCell { Value = searchSubdirectoriesCheck.Checked };
                    DataGridViewTextBoxCell IdCell = new DataGridViewTextBoxCell { Value = lastId.ToString() };
                    DataGridViewButtonCell cancelButtonCell = new DataGridViewButtonCell { Value = "Отмена" };

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.AddRange(searchCell, replacementCell, searchDirectoryCell, fullNameCell, nameChangeCell, undoCell, searchSubdirectoriesCell, IdCell, cancelButtonCell);
                    historyForm.historyDataGridView.Rows.Add(row);

                    logger.Write("Запись замены в историю", LoggerLevel.Info);
                }
                else if (e.Error == null)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);

                    if (ShowMessageBoxWithLog("Ничего не найдено", "Предупреждение", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, LoggerLevel.Warn) == DialogResult.Retry)
                    {
                        ReplaceButton_Click(replaceButton, e);
                    }
                }

                progressBar.Visible = false;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
        }

        private void CancelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var arguments = ((long id, ProgressBar progressBar, Logger logger))e.Argument;

            if (replaceWorker.IsBusy)
                worker.ReportProgress(0, "Ожидание завершения замены");

            while (replaceWorker.IsBusy)
            {
                Application.DoEvents();
            }

            foreach (string file in createFiles[arguments.id])
            {
                worker.ReportProgress(0, "Удаление: " + file);
                LoggerWrite(arguments.progressBar, arguments.logger, "Удаление: " + file);

                File.Delete(file);
            }

            foreach (UndoFile file in undoFiles[arguments.id])
            {
                worker.ReportProgress(0, "Возвращение: " + file.undoPath);
                LoggerWrite(arguments.progressBar, arguments.logger, "Возвращение: " + file.undoPath);

                file.Undo();
            }

            undoFiles.Remove(arguments.id);
            createFiles.Remove(arguments.id);
        }

        private void CancelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is (string, Exception))
                WorkersProgressChanged(((string message, Exception exception))e.UserState);
            else
                WorkersProgressChanged((string)e.UserState, LoggerLevel.Info);
        }

        private void CancelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            replaceButton.Enabled = !replaceWorker.IsBusy;
            WorkersRunWorkerCompleted(e, "отмены");
            
            if (e.Error == null)
            {
                if (removeHistoryIndex != null)
                {
                    logger.Write($"Удаление {removeHistoryIndex} записи в истории", LoggerLevel.Info);
                    historyForm.historyDataGridView.Rows.RemoveAt((int)removeHistoryIndex);
                    removeHistoryIndex = null;
                }

                ShowMessageBoxWithLog("Отмена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LoggerLevel.Info);
            }
            else
                ShowMessageBoxWithLog("Отмена была провалена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            progressBar.Value = progressBar.Minimum;
            progressBar.Visible = false;
        }
    }
}
