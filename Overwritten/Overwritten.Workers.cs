using OFGmCoreCS.LoggerSimple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Overwritten
    {
        private void WorkersProgressChanged(string currentFileName, LoggerLevel loggerLevel)
        {
            currentFile.Text = currentFileName;
            logger.Write(currentFileName, loggerLevel);

            progressBar.PerformStep();
        }

        private void WorkersProgressChanged(ErrorReport report)
        {
            WorkersProgressChanged(report.message + ": " + report.exception.Message, LoggerLevel.Error);

            logger.Write(report.exception.ToString(), LoggerLevel.Debug);
        }

        private void ReplaceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            int key = undoFiles.Keys.Count;

            undoFiles.Add(key, new List<UndoFile>());
            createFiles.Add(key, new List<string>());

            foreach (string file in files)
            {
                if ((fullNameCheckChecked ? searchComboText == Path.GetFileName(file) : searchComboText.Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries).Intersect(Path.GetFileName(file).Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries)).Any()) || searchComboText == "*")
                {
                    worker.ReportProgress(0, file);

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (undoCheckChecked)
                        undoFiles[key].Add(new UndoFile(file));

                    if (nameChangeCheckChecked)
                    {
                        try
                        {
                            File.Move(file, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)));
                            File.Copy(replacementComboText, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)), true);

                            if (undoCheckChecked)
                                createFiles[key].Add(Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)));
                            if (Path.GetFileName(file) != Path.GetFileName(replacementComboText))
                                File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            worker.ReportProgress(0, new ErrorReport("Не удалось изменить название файлу", ex));
                        }
                    }
                    else
                        File.Copy(replacementComboText, file, true);
                }
            }
        }

        private void ReplaceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ErrorReport report)
                WorkersProgressChanged(report);
            else
                WorkersProgressChanged("Замена: " + (string)e.UserState, LoggerLevel.Info);
        }

        private void WorkersRunWorkerCompleted(RunWorkerCompletedEventArgs e, string name)
        {
            currentFile.Text = "";
            cancelButton.Enabled = undoFiles.Count > 0;

            if (e.Error is UnauthorizedAccessException)
            {
                requireAdministrator.Visible = true;
            }
            else if (e.Error != null)
            {
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
                if (progressBar.Value > 0)
                {
                    progressBar.Value = 0;
                    progressBar.Visible = false;

                    if (e.Error == null)
                        ShowMessageBoxWithLog("Замена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LoggerLevel.Info);
                    else
                        ShowMessageBoxWithLog("Замена была провалена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

                    DataGridViewTextBoxCell searchCell = new DataGridViewTextBoxCell
                    {
                        Value = searchCombo.Text
                    };
                    DataGridViewTextBoxCell replacementCell = new DataGridViewTextBoxCell
                    {
                        Value = replacementCombo.Text
                    };
                    DataGridViewTextBoxCell searchDirectoryCell = new DataGridViewTextBoxCell
                    {
                        Value = searchDirectoryCombo.Text
                    };
                    DataGridViewCheckBoxCell fullNameCell = new DataGridViewCheckBoxCell
                    {
                        Value = fullNameCheck.Checked
                    };
                    DataGridViewCheckBoxCell nameChangeCell = new DataGridViewCheckBoxCell
                    {
                        Value = nameChangeCheck.Checked
                    };
                    DataGridViewCheckBoxCell undoCell = new DataGridViewCheckBoxCell
                    {
                        Value = undoCheck.Checked
                    };
                    DataGridViewCheckBoxCell searchSubdirectoriesCell = new DataGridViewCheckBoxCell
                    {
                        Value = searchSubdirectoriesCheck.Checked
                    };
                    DataGridViewTextBoxCell IdCell = new DataGridViewTextBoxCell
                    {
                        Value = (undoFiles.Keys.Count - 1).ToString()
                    };
                    DataGridViewButtonCell cancelButtonCell = new DataGridViewButtonCell
                    {
                        Value = "Отмена"
                    };

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.AddRange(searchCell, replacementCell, searchDirectoryCell, fullNameCell, nameChangeCell, undoCell, searchSubdirectoriesCell, IdCell, cancelButtonCell);
                    historyForm.historyDataGridView.Rows.Add(row);

                    logger.Write("Запись замены в историю", LoggerLevel.Info);
                }
                else
                {
                    if (ShowMessageBoxWithLog("Ничего не найдено", "Предупреждение", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, LoggerLevel.Warn) == DialogResult.Retry)
                    {
                        ReplaceButton_Click(replaceButton, e);
                    }
                }
            }
        }

        private void CancelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            int id = (int)e.Argument;

            if (replaceWorker.IsBusy)
                worker.ReportProgress(0, "Ожидание завершения замены");

            while (replaceWorker.IsBusy)
            {
                Application.DoEvents();
            }

            foreach (string file in createFiles[id])
            {
                worker.ReportProgress(0, "Удаление: " + file);

                File.Delete(file);
            }

            foreach (UndoFile file in undoFiles[id])
            {
                worker.ReportProgress(0, "Возвращение: " + file.undoPath);

                file.Undo();
            }

            undoFiles.Remove(id);
            createFiles.Remove(id);
        }

        private void CancelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ErrorReport report)
                WorkersProgressChanged(report);
            else
                WorkersProgressChanged((string)e.UserState, LoggerLevel.Info);
        }

        private void CancelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            replaceButton.Enabled = !replaceWorker.IsBusy;
            WorkersRunWorkerCompleted(e, "отмены");

            progressBar.Value = 0;
            progressBar.Visible = false;

            if (e.Error == null)
                ShowMessageBoxWithLog("Отмена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LoggerLevel.Info);
            else
                ShowMessageBoxWithLog("Отмена была провалена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
        }

        private class ErrorReport
        {
            public string message;
            public Exception exception;

            public ErrorReport(string message, Exception exception)
            {
                this.message = message;
                this.exception = exception;
            }
        }
    }
}
