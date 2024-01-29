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
        public readonly List<UndoFile> undoFiles = new List<UndoFile>();
        private readonly List<string> createFiles = new List<string>();
        private readonly Log logForm = new Log();
        private readonly History historyForm = new History();
        private List<string> files;
        
        private bool fullNameCheckChecked;
        private string searchComboText;
        private bool nameChangeCheckChecked;
        private bool undoCheckChecked;
        private string replacementComboText;

        public Overwritten()
        {
            InitializeComponent();

            LogsWrite("Инициализация программы", LogLevel.Info);

            if (Program.args.Length > 0)
            {
                string args = "";

                foreach (string arg in Program.args)
                {
                    args += " " + arg;

                    switch (Util.ArgTextName(arg))
                    {
                        case "search":
                            searchCombo.Text = Util.ArgTextValue(arg);
                            break;
                        case "replacement":
                            replacementCombo.Text = Util.ArgTextValue(arg);
                            break;
                        case "fullName":
                            fullNameCheck.Checked = Util.ArgTextValueBool(arg);
                            break;
                        case "nameChange":
                            nameChangeCheck.Checked = Util.ArgTextValueBool(arg);
                            break;
                        case "undo":
                            undoCheck.Checked = Util.ArgTextValueBool(arg);
                            break;
                        case "searchSubdirectories":
                            searchSubdirectoriesCheck.Checked = Util.ArgTextValueBool(arg);
                            break;
                        case "searchDirectory":
                            searchDirectoryCombo.Text = Util.ArgTextValue(arg);
                            break;
                    }
                }

                LogsWrite("Аргументы:" + args, LogLevel.Info);
            }
        }
        
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            replaceButton.Enabled = false;

            if (searchCombo.Text != (string)searchCombo.Tag && replacementCombo.Text != (string)replacementCombo.Tag && searchDirectoryCombo.Text != "")
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
                    ShowMessageBoxWithLog("Замена уже выполняется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
            }
            else
            {
                ShowMessageBoxWithLog("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
                replaceButton.Enabled = true;
            }
        }

        private void ReplaceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            foreach (UndoFile undoFile in undoFiles)
            {
                undoFile.Delete();
            }
            undoFiles.Clear();

            try
            {
                foreach (string file in files)
                {
                    if (fullNameCheckChecked ? searchComboText == Path.GetFileName(file) || searchComboText == "*" : searchComboText.Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries).Intersect(Path.GetFileName(file).Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries)).Any())
                    {
                        worker.ReportProgress(0, file);

                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }

                        if (undoCheckChecked)
                            undoFiles.Add(new UndoFile(file));

                        if (nameChangeCheckChecked)
                        {
                            File.Move(file, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)));
                            File.Copy(replacementComboText, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)), true);

                            if (undoCheckChecked)
                                createFiles.Add(Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacementComboText)));
                            if (Path.GetFileName(file) != Path.GetFileName(replacementComboText))
                                File.Delete(file);
                        }
                        else
                            File.Copy(replacementComboText, file, true);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                    requireAdministrator.Visible = true;
                else if (ex is DirectoryNotFoundException)
                    ShowMessageBoxWithLog(ex.Message, "Ошибка области поиска", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
                else if (ex is FileNotFoundException)
                    ShowMessageBoxWithLog(ex.Message, "Ошибка заменителя", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
                else if (ex is IOException)
                    ShowMessageBoxWithLog(ex.Message, "Ошибка изменения названия", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
                else
                    ShowMessageBoxWithLog(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);

                LogsWrite(ex.ToString(), LogLevel.Debug);
            }
        }

        private void ReplaceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkersProgressChanged("Замена: " + (string)e.UserState);
        }

        private void ReplaceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkersRunWorkerCompleted();

            if (!e.Cancelled)
            {
                if (progressBar.Value > 0)
                {
                    progressBar.Value = 0;
                    progressBar.Visible = false;

                    ShowMessageBoxWithLog("Замена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LogLevel.Info);

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
                    DataGridViewButtonCell cancelButtonCell = new DataGridViewButtonCell
                    {
                        Value = "Отмена"
                    };

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.AddRange(searchCell, replacementCell, searchDirectoryCell, fullNameCell, nameChangeCell, undoCell, searchSubdirectoriesCell, cancelButtonCell);
                    historyForm.historyDataGridView.Rows.Add(row);

                    LogsWrite("Запись замены в историю", LogLevel.Info);
                }
                else
                {
                    if (ShowMessageBoxWithLog("Ничего не найдено", "Предупреждение", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, LogLevel.Warn) == DialogResult.Retry)
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

        private void WorkersProgressChanged(string currentFileName)
        {
            currentFile.Text = currentFileName;
            LogsWrite(currentFileName, LogLevel.Info);

            progressBar.PerformStep();
            CheckUndo();
        }

        private void WorkersRunWorkerCompleted()
        {
            currentFile.Text = "";
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
            if (replaceWorker.IsBusy)
                replaceWorker.CancelAsync();
            else
            {
                try
                {
                    historyForm.historyDataGridView.Rows.RemoveAt(historyForm.historyDataGridView.Rows.Count - 1);
                }
                catch (Exception ex)
                {
                    ShowMessageBoxWithLog("Ошибка удаления истории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);

                    LogsWrite(ex.ToString(), LogLevel.Debug);
                }

                LogsWrite("Удаление последней замены в истории", LogLevel.Info);
            }

            replaceButton.Enabled = false;
            cancelButton.Enabled = false;
            progressBar.Value = 0;
            progressBar.Maximum = undoFiles.Count + createFiles.Count;
            progressBar.Visible = true;

            if (!cancelWorker.IsBusy)
                cancelWorker.RunWorkerAsync();
            else
                ShowMessageBoxWithLog("Отмена уже выполняется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);
        }

        private void CheckUndo()
        {
            if (!cancelWorker.IsBusy)
                cancelButton.Enabled = undoFiles.Count > 0 || replaceWorker.IsBusy;
        }

        private void CancelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (replaceWorker.IsBusy)
                worker.ReportProgress(0, "Ожидание завершения замены");

            while (replaceWorker.IsBusy)
            {
                Application.DoEvents();
            }

            try
            {
                foreach (string file in createFiles)
                {
                    worker.ReportProgress(0, "Удаление: " + file);

                    File.Delete(file);
                }

                foreach (UndoFile file in undoFiles)
                {
                    worker.ReportProgress(0, "Возвращение: " + file.undoPath);

                    file.Undo();
                }
            }
            catch (Exception ex)
            {
                ShowMessageBoxWithLog(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LogLevel.Error);

                LogsWrite(ex.ToString(), LogLevel.Debug);
            }
        }

        private void CancelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkersProgressChanged((string)e.UserState);
        }

        private void CancelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkersRunWorkerCompleted();

            progressBar.Value = 0;
            progressBar.Visible = false;

            ShowMessageBoxWithLog("Отмена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, LogLevel.Info);

            undoFiles.Clear();

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
                LogsWrite(ex.ToString(), LogLevel.Debug);
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

        private void LogsWrite(string text, LogLevel logLevel)
        {
            text = $"[{DateTime.Now.ToLongTimeString()}] [{logLevel.ToString().ToUpperInvariant()}] {text}";
            
            Console.WriteLine(text);

            if ((logLevel == LogLevel.Debug && Program.debug) || logLevel != LogLevel.Debug)
            {
                if (logForm.logTextBox.Text != "")
                    logForm.logTextBox.AppendText("\n" + text);
                else
                    logForm.logTextBox.AppendText(text);

                logForm.logTextBox.Select(logForm.logTextBox.TextLength - text.Length, logForm.logTextBox.TextLength);
                
                Color logLevelColor;

                switch (logLevel)
                {
                    default:
                        logLevelColor = logForm.logTextBox.ForeColor;
                        break;
                    case LogLevel.Info:
                        logLevelColor = logForm.logTextBox.ForeColor;
                        break;
                    case LogLevel.Warn:
                        logLevelColor = Color.FromArgb(164, 255, 164, 1); //Gold
                        break;
                    case LogLevel.Error:
                        logLevelColor = Color.Red;
                        break;
                    case LogLevel.Debug:
                        logLevelColor = Color.Gray;
                        break;
                }

                logForm.logTextBox.SelectionColor = logLevelColor;

                logForm.logTextBox.DeselectAll();
            }
        }

        private DialogResult ShowMessageBoxWithLog(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, LogLevel logLevel)
        {
            LogsWrite(text, logLevel);
            return MessageBox.Show(text, caption, buttons, icon);
        }

        private void HistoryStripMenuItem_Click(object sender, EventArgs e)
        {
            historyForm.Show();
        }     
    }
}
