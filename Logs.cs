using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class Logs : Form
    {
        public string logs;

        public Logs()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (logsTextBox.Text != "")
                Clipboard.SetText(logsTextBox.Text);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            logs = "";
            logsTextBox.Text = logs;
        }
    }
}
