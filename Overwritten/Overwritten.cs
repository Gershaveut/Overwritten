using OFGmCoreCS.LoggerSimple;
using OFGmCoreCS.ProgramArgument;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        private bool runReplace;

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
                new Argument<bool>("searchSubdirectories", (arg) => searchSubdirectoriesCheck.Checked = arg),
                new Argument("runReplace", () => runReplace = true)
            });

            argumentHandler.ArgumentsInvoke(Program.args);

            if (ArgumentHandler.ArgumentsList(Program.args) != "")
                logger.Write("Аргументы: " + ArgumentHandler.ArgumentsList(Program.args), LoggerLevel.Info);

            if (runReplace)
                Replace();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancel(undoFiles.Keys.Count - 1, historyForm.historyDataGridView.Rows.Count - 1);
        }

        private void RequireAdministratorConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(Application.ExecutablePath)
                {
                    Verb = "runas",
                    Arguments = $"--search=\"{searchCombo.Text}\" --replacement=\"{replacementCombo.Text}\" --searchDirectory=\"{searchDirectoryCombo.Text}\" --fullName={fullNameCheck.Checked} --nameChange={nameChangeCheck.Checked} --undo={undoCheck.Checked} --searchSubdirectories={searchSubdirectoriesCheck.Checked}"
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
        }

        private void LogsStripMenuItem_Click(object sender, EventArgs e)
        {
            logForm.Show();
        }

        private void HistoryStripMenuItem_Click(object sender, EventArgs e)
        {
            historyForm.Show();
        }
    }
}
