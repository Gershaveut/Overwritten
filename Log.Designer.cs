namespace Overwritten
{
    partial class Log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            logTextBox = new System.Windows.Forms.RichTextBox();
            BackButton = new System.Windows.Forms.Button();
            CopyButton = new System.Windows.Forms.Button();
            ClearButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // logTextBox
            // 
            logTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            logTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            logTextBox.Location = new System.Drawing.Point(14, 14);
            logTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.Size = new System.Drawing.Size(536, 412);
            logTextBox.TabIndex = 0;
            logTextBox.Text = "";
            logTextBox.VisibleChanged += LogTextBox_VisibleChanged;
            // 
            // BackButton
            // 
            BackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BackButton.Location = new System.Drawing.Point(463, 434);
            BackButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(88, 27);
            BackButton.TabIndex = 1;
            BackButton.Text = "Назад";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            CopyButton.Location = new System.Drawing.Point(369, 434);
            CopyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new System.Drawing.Size(88, 27);
            CopyButton.TabIndex = 2;
            CopyButton.Text = "Копировать";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ClearButton.Location = new System.Drawing.Point(14, 434);
            ClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new System.Drawing.Size(88, 27);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "Очистить";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // Log
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(565, 474);
            Controls.Add(ClearButton);
            Controls.Add(CopyButton);
            Controls.Add(BackButton);
            Controls.Add(logTextBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Log";
            Text = "Журнал";
            FormClosing += Log_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button ClearButton;
    }
}