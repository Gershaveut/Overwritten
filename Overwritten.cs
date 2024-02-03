using OFGmCoreCS.LoggerSimple;
using OFGmCoreCS.ProgramArgument;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Overwritten : Form
    {
        private readonly Dictionary<int, List<UndoFile>> undoFiles = new Dictionary<int, List<UndoFile>>();
        private readonly Dictionary<int, List<string>> createFiles = new Dictionary<int, List<string>>();
        private readonly Log logForm = new Log();
        private readonly History historyForm = new History();
        private List<string> files;
        private Logger logger = new Logger(new Logger.Properties().Debug());

        private bool fullNameCheckChecked;
        private string searchComboText;
        private bool nameChangeCheckChecked;
        private bool undoCheckChecked;
        private string replacementComboText;

        public Overwritten()
        {
            InitializeComponent();

            Logger.Properties loggerProperties = new Logger.Properties();
            if (Program.debug)
                loggerProperties.Debug();
            logger = new Logger(loggerProperties);

            logger.LogWritten += LogWritten;

            logger.Write("Инициализация программы", LoggerLevel.Info);

            ArgumentHandler argumentHandler = new ArgumentHandler(new HashSet<IArgument>
            {
                new Argument<string>("search", (arg) => searchCombo.Text = arg),
                new Argument<string>("replacement", (arg) => replacementCombo.Text = arg),
                new Argument<string>("searchDirectory", (arg) => searchDirectoryCombo.Text = arg),
                new Argument<bool>("fullName", (arg) => fullNameCheck.Checked = arg),
                new Argument<bool>("nameChange", (arg) => nameChangeCheck.Checked = arg),
                new Argument<bool>("undo", (arg) => undoCheck.Checked = arg),
                new Argument<bool>("searchSubdirectories", (arg) => searchSubdirectoriesCheck.Checked = arg)
            });

            argumentHandler.ArgumentsInvoke(Program.args);

            if (ArgumentHandler.ArgumentsList(Program.args) != "")
                logger.Write("Аргументы: " + ArgumentHandler.ArgumentsList(Program.args), LoggerLevel.Info);
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            replaceButton.Enabled = false;

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
                catch 
                {
                    ShowMessageBoxWithLog("Поля заполнены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
                }
            }
            else
            {
                ShowMessageBoxWithLog("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
                replaceButton.Enabled = true;
            }
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

        private void ReplaceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

            if (!requireAdministrator.Visible)
            {
                replaceButton.Enabled = !cancelWorker.IsBusy;
                CheckUndo();
            }
        }

        private void WorkersProgressChanged(string currentFileName, LoggerLevel loggerLevel)
        {
            currentFile.Text = currentFileName;
            logger.Write(currentFileName, loggerLevel);

            progressBar.PerformStep();
            CheckUndo();
        }

        private void WorkersProgressChanged(ErrorReport report)
        {
            WorkersProgressChanged(report.message + ": " + report.exception.Message, LoggerLevel.Error);

            logger.Write(report.exception.ToString(), LoggerLevel.Debug);
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

        private void WorkersRunWorkerCompleted(RunWorkerCompletedEventArgs e, string name)
        {
            currentFile.Text = "";

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancel(undoFiles.Keys.Count - 1, historyForm.historyDataGridView.Rows.Count - 1);
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

        private void CheckUndo()
        {
            if (!cancelWorker.IsBusy)
                cancelButton.Enabled = undoFiles.Count > 0 || replaceWorker.IsBusy;
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
            WorkersRunWorkerCompleted(e, "отмены");

            progressBar.Value = 0;
            progressBar.Visible = false;

            if (e.Error == null)
                ShowMessageBoxWithLog("Отмена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LoggerLevel.Info);
            else
                ShowMessageBoxWithLog("Отмена была провалена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
            
            replaceButton.Enabled = !replaceWorker.IsBusy;
        }

        private void RequireAdministratorConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(Application.ExecutablePath)
                {
                    Verb = "runas"
                });
                Application.Exit();
            }
            catch (Exception ex)
            {
                logger.Write(ex.ToString(), LoggerLevel.Debug);
            }
        }

        private void ReplacementSelectionButton_Click(object sender, EventArgs e)
        {
            replacementSearch.ShowDialog();

            if (replacementSearch.FileName != "")
                replacementCombo.Text = replacementSearch.FileName;
            else
                ComboBoxes_Leave(replacementCombo, e);
        }

        private void SearchDirectorySelectionButton_Click(object sender, EventArgs e)
        {
            searchDirectorySearch.ShowDialog();
            searchDirectoryCombo.Text = searchDirectorySearch.SelectedPath;
        }

        private void ComboBoxes_Enter(object sender, EventArgs e)
        {
            ComboBox comboBoxSender = sender as ComboBox;

            if (comboBoxSender.Text == (string)comboBoxSender.Tag)
                comboBoxSender.Text = "";

            comboBoxSender.ForeColor = Color.Black;
        }

        private void ComboBoxes_Leave(object sender, EventArgs e)
        {
            ComboBox comboBoxSender = sender as ComboBox;

            if (string.IsNullOrWhiteSpace(comboBoxSender.Text))
            {
                comboBoxSender.Text = (string)comboBoxSender.Tag;
                comboBoxSender.ForeColor = SystemColors.GrayText;
            }
        }

        private void ComboBoxes_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxSender = sender as ComboBox;

            if (comboBoxSender.Text != (string)comboBoxSender.Tag)
                comboBoxSender.ForeColor = Color.Black;
        }

        private void RequireAdministratorCancelButton_Click(object sender, EventArgs e)
        {
            requireAdministrator.Visible = false;
            progressBar.Value = 0;
            progressBar.Visible = false;
            replaceButton.Enabled = true;
            CheckUndo();
        }

        private void LogsStripMenuItem_Click(object sender, EventArgs e)
        {
            logForm.Show();
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

        private void HistoryStripMenuItem_Click(object sender, EventArgs e)
        {
            historyForm.Show();
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
    }
}
