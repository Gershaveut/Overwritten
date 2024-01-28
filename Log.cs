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
    }
}
