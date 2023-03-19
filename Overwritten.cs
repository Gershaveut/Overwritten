using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Overwritten : Form
    {
        public Overwritten()
        {
            InitializeComponent();
        }

        private void replacementSelection_Click(object sender, EventArgs e)
        {
            replacementFile.ShowDialog();
            replacement.Text = replacementFile.FileName;
        }

        private void searchDirectorySelection_Click(object sender, EventArgs e)
        {
            searchFolder.ShowDialog();
            searchDirectory.Text = searchFolder.SelectedPath;
        }

        private void replace_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> files = GetAllFiles(searchDirectory.Text);
                progressBar.Maximum = files.Count;
                replace.Enabled = false;
                foreach (string file in files)
                {
                    if (fullName.Checked ? search.Text == Path.GetFileName(file) : search.Text.Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries).Intersect(Path.GetFileName(file).Split(new[] { " ", ".", "_", "-" }, StringSplitOptions.RemoveEmptyEntries)).Any())
                    {
                        if (nameChange.Checked)
                        {
                            File.Move(file, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacement.Text)));
                            File.Copy(replacement.Text, Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(replacement.Text)), true);
                            if (Path.GetFileName(file) != Path.GetFileName(replacement.Text))
                                File.Delete(file);
                        }
                        else
                            File.Copy(replacement.Text, file, true);

                        progressBar.Value += 1;
                    }
                }

                if (progressBar.Value > 0)
                    MessageBox.Show("Дело сделано", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                {
                    if (MessageBox.Show("Ничего не найдено", "Предупреждение", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    {
                        replace_Click(replace, null);
                    }
                }

                progressBar.Value = 0;
                replace.Enabled = true;
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    requireAdministrator.Visible = true;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex);
                    progressBar.Value = 0;
                    replace.Enabled = true;
                }
            }
        }

        private static List<string> GetAllFiles(string directoryPath)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                files.Add(file);
            }

            foreach (string subDirectory in Directory.GetDirectories(directoryPath))
            {
                files.AddRange(GetAllFiles(subDirectory));
            }

            return files;
        }

        private void ComboBoxs_Enter(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == (string)((ComboBox)sender).Tag)
                ((ComboBox)sender).Text = "";

            ((ComboBox)sender).ForeColor = Color.Black;
        }

        private void ComboBoxs_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((ComboBox)sender).Text))
            {
                ((ComboBox)sender).Text = (string)((ComboBox)sender).Tag;
                ((ComboBox)sender).ForeColor = SystemColors.GrayText;
            }
        }

        private void ComboBoxs_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text != (string)((ComboBox)sender).Tag)
                ((ComboBox)sender).ForeColor = Color.Black;
        }

        private void yes_Click(object sender, EventArgs e)
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
                Console.WriteLine(ex);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            requireAdministrator.Visible = false;
            progressBar.Value = 0;
            replace.Enabled = true;
        }
    }
}
