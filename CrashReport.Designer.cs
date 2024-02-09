namespace Overwritten
{
    partial class CrashReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrashReport));
            ExitButton = new System.Windows.Forms.Button();
            CopyButton = new System.Windows.Forms.Button();
            crashReportTextBox = new System.Windows.Forms.RichTextBox();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ExitButton.Location = new System.Drawing.Point(885, 466);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new System.Drawing.Size(88, 23);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            CopyButton.Location = new System.Drawing.Point(791, 466);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new System.Drawing.Size(88, 23);
            CopyButton.TabIndex = 2;
            CopyButton.Text = "Копировать";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // crashReportTextBox
            // 
            crashReportTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            crashReportTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            crashReportTextBox.Location = new System.Drawing.Point(12, 12);
            crashReportTextBox.Name = "crashReportTextBox";
            crashReportTextBox.ReadOnly = true;
            crashReportTextBox.Size = new System.Drawing.Size(961, 448);
            crashReportTextBox.TabIndex = 3;
            crashReportTextBox.Text = "";
            // 
            // CrashReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(985, 501);
            Controls.Add(crashReportTextBox);
            Controls.Add(CopyButton);
            Controls.Add(ExitButton);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "CrashReport";
            Text = "Критическая ошибка";
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.RichTextBox crashReportTextBox;
    }
}