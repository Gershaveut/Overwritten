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
        private List<string> files;
        private Logs logsForm = new Logs();
        private History historyForm = new History();

        private bool fullNameCheckChecked;
        private string searchComboText;
        private bool nameChangeCheckChecked;
        private bool undoCheckChecked;
        private string replacementComboText;

        public Overwritten()
        {
            InitializeComponent();
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
                    MessageBox.Show("Замена уже выполняеться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (fullNameCheckChecked ? searchComboText == Path.GetFileName(file) : searchComboText.Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries).Intersect(Path.GetFileName(file).Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries)).Any())
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
                {
                    requireAdministrator.Visible = true;
                }
                else if (ex is DirectoryNotFoundException)
                {
                    MessageBox.Show(ex.Message, "Ошибка области поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is FileNotFoundException)
                {
                    MessageBox.Show(ex.Message, "Ошибка заменителя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is IOException)
                {
                    MessageBox.Show(ex.Message, "Ошибка изменения названия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LogsWrite(ex.ToString());
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
                    MessageBox.Show("Замена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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

                    LogsWrite("Запись замены в историю");
                }
                else
                {
                    if (MessageBox.Show("Ничего не найдено", "Предупреждение", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    {
                        ReplaceButton_Click(replaceButton, e);
                    }
                }

                if (!requireAdministrator.Visible)
                {
                    replaceButton.Enabled = !cancelWorker.IsBusy;
                    СheckUndo();
                }
            }
            else
            {
                replaceButton.Enabled = !cancelWorker.IsBusy;
                СheckUndo();
            }
        }

        private void WorkersProgressChanged(string currentFileName)
        {
            currentFile.Text = currentFileName;
            LogsWrite(currentFileName);

            progressBar.PerformStep();
            СheckUndo();
        }

        private void WorkersRunWorkerCompleted()
        {
            LogsUpdate();
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

        private void СancelButton_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Ошибка удаления истории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LogsWrite(ex.ToString());
                }

                LogsWrite("Удаление последней замены в истории");
            }

            replaceButton.Enabled = false;
            cancelButton.Enabled = false;
            progressBar.Value = 0;
            progressBar.Maximum = undoFiles.Count + createFiles.Count;
            progressBar.Visible = true;

            if (!cancelWorker.IsBusy)
                cancelWorker.RunWorkerAsync();
            else
                MessageBox.Show("Отмена уже выполняеться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void СheckUndo()
        {
            if (!cancelWorker.IsBusy)
                cancelButton.Enabled = undoFiles.Count > 0 || replaceWorker.IsBusy;
        }

        private void СancelWorker_DoWork(object sender, DoWorkEventArgs e)
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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogsWrite(ex.ToString());
            }
        }

        private void СancelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkersProgressChanged((string)e.UserState);
        }

        private void СancelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkersRunWorkerCompleted();

            progressBar.Value = 0;
            progressBar.Visible = false;

            MessageBox.Show("Отмена была выполнена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
                LogsWrite(ex.ToString());
            }
        }

        private void ReplacementSelectionButton_Click(object sender, EventArgs e)
        {
            replacementSearch.ShowDialog();

            if (replacementSearch.FileName != "")
                replacementCombo.Text = replacementSearch.FileName;
            else
                ComboBoxs_Leave(replacementCombo, e);
        }

        private void SearchDirectorySelectionButton_Click(object sender, EventArgs e)
        {
            searchDirectorySearch.ShowDialog();
            searchDirectoryCombo.Text = searchDirectorySearch.SelectedPath;
        }

        private void ComboBoxs_Enter(object sender, EventArgs e)
        {
            ComboBox comboBoxSender = sender as ComboBox;

            if (comboBoxSender.Text == (string)comboBoxSender.Tag)
                comboBoxSender.Text = "";

            comboBoxSender.ForeColor = Color.Black;
        }

        private void ComboBoxs_Leave(object sender, EventArgs e)
        {
            ComboBox comboBoxSender = sender as ComboBox;

            if (string.IsNullOrWhiteSpace(comboBoxSender.Text))
            {
                comboBoxSender.Text = (string)comboBoxSender.Tag;
                comboBoxSender.ForeColor = SystemColors.GrayText;
            }
        }

        private void ComboBoxs_TextChanged(object sender, EventArgs e)
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
            СheckUndo();
        }

        private void LogsStripMenuItem_Click(object sender, EventArgs e)
        {
            logsForm.ShowDialog();
        }

        private void LogsWrite(string text)
        {
            Console.WriteLine(text);

            if (logsForm.logs != "")
                logsForm.logs = logsForm.logs + "\n" + text;
            else
                logsForm.logs = text;
        }

        private void LogsUpdate()
        {
            logsForm.logsTextBox.Text = logsForm.logs;
        }

        private void HistoryStripMenuItem_Click(object sender, EventArgs e)
        {
            historyForm.ShowDialog();
        }
    }
}
