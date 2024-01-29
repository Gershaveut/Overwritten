using System;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (logTextBox.Text != "")
                Clipboard.SetText(logTextBox.Text);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
        }

        private void LogTextBox_VisibleChanged(object sender, EventArgs e)
        {
            if (logTextBox.Visible)
            {
                logTextBox.SelectionStart = logTextBox.TextLength;
                logTextBox.ScrollToCaret();
            }
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
    }
}
