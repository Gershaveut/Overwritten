using System.Drawing;

namespace Overwritten
{
    partial class Overwritten
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overwritten));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replacementSearch = new System.Windows.Forms.OpenFileDialog();
            this.searchDirectorySearch = new System.Windows.Forms.FolderBrowserDialog();
            this.searchCombo = new System.Windows.Forms.ComboBox();
            this.replacementSelectionButton = new System.Windows.Forms.Button();
            this.searchDirectorySelectionButton = new System.Windows.Forms.Button();
            this.searchDirectoryLabel = new System.Windows.Forms.Label();
            this.replacementCombo = new System.Windows.Forms.ComboBox();
            this.searchDirectoryCombo = new System.Windows.Forms.ComboBox();
            this.fullNameCheck = new System.Windows.Forms.CheckBox();
            this.nameChangeCheck = new System.Windows.Forms.CheckBox();
            this.requireAdministrator = new System.Windows.Forms.Panel();
            this.requireAdministratorLabel = new System.Windows.Forms.Label();
            this.requireAdministratorPicture = new System.Windows.Forms.PictureBox();
            this.requireAdministratorCancelButton = new System.Windows.Forms.Button();
            this.requireAdministratorConfirmButton = new System.Windows.Forms.Button();
            this.currentFile = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.undoCheck = new System.Windows.Forms.CheckBox();
            this.replaceWorker = new System.ComponentModel.BackgroundWorker();
            this.cancelWorker = new System.ComponentModel.BackgroundWorker();
            this.searchSubdirectoriesCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requireAdministrator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requireAdministratorPicture)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 302);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(295, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // replaceButton
            // 
            this.replaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceButton.Location = new System.Drawing.Point(12, 331);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(209, 23);
            this.replaceButton.TabIndex = 1;
            this.replaceButton.Text = "Заменить";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // searchCombo
            // 
            this.searchCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.searchCombo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchCombo.FormattingEnabled = true;
            this.searchCombo.Location = new System.Drawing.Point(12, 32);
            this.searchCombo.Name = "searchCombo";
            this.searchCombo.Size = new System.Drawing.Size(295, 21);
            this.searchCombo.TabIndex = 8;
            this.searchCombo.Tag = "Поиск";
            this.searchCombo.Text = "Поиск";
            this.searchCombo.TextChanged += new System.EventHandler(this.ComboBoxes_TextChanged);
            this.searchCombo.Enter += new System.EventHandler(this.ComboBoxes_Enter);
            this.searchCombo.Leave += new System.EventHandler(this.ComboBoxes_Leave);
            // 
            // replacementSelectionButton
            // 
            this.replacementSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.replacementSelectionButton.Location = new System.Drawing.Point(282, 58);
            this.replacementSelectionButton.Name = "replacementSelectionButton";
            this.replacementSelectionButton.Size = new System.Drawing.Size(25, 21);
            this.replacementSelectionButton.TabIndex = 1;
            this.replacementSelectionButton.Text = "...";
            this.replacementSelectionButton.UseVisualStyleBackColor = true;
            this.replacementSelectionButton.Click += new System.EventHandler(this.ReplacementSelectionButton_Click);
            // 
            // searchDirectorySelectionButton
            // 
            this.searchDirectorySelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectorySelectionButton.Location = new System.Drawing.Point(282, 130);
            this.searchDirectorySelectionButton.Name = "searchDirectorySelectionButton";
            this.searchDirectorySelectionButton.Size = new System.Drawing.Size(25, 21);
            this.searchDirectorySelectionButton.TabIndex = 5;
            this.searchDirectorySelectionButton.Text = "...";
            this.searchDirectorySelectionButton.UseVisualStyleBackColor = true;
            this.searchDirectorySelectionButton.Click += new System.EventHandler(this.SearchDirectorySelectionButton_Click);
            // 
            // searchDirectoryLabel
            // 
            this.searchDirectoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectoryLabel.AutoSize = true;
            this.searchDirectoryLabel.Location = new System.Drawing.Point(11, 133);
            this.searchDirectoryLabel.Name = "searchDirectoryLabel";
            this.searchDirectoryLabel.Size = new System.Drawing.Size(89, 13);
            this.searchDirectoryLabel.TabIndex = 7;
            this.searchDirectoryLabel.Text = "Область поиска";
            // 
            // replacementCombo
            // 
            this.replacementCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replacementCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.replacementCombo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.replacementCombo.FormattingEnabled = true;
            this.replacementCombo.Location = new System.Drawing.Point(12, 58);
            this.replacementCombo.Name = "replacementCombo";
            this.replacementCombo.Size = new System.Drawing.Size(265, 21);
            this.replacementCombo.TabIndex = 9;
            this.replacementCombo.Tag = "Заменить";
            this.replacementCombo.Text = "Заменить";
            this.replacementCombo.TextChanged += new System.EventHandler(this.ComboBoxes_TextChanged);
            this.replacementCombo.Enter += new System.EventHandler(this.ComboBoxes_Enter);
            this.replacementCombo.Leave += new System.EventHandler(this.ComboBoxes_Leave);
            // 
            // searchDirectoryCombo
            // 
            this.searchDirectoryCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectoryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.searchDirectoryCombo.FormattingEnabled = true;
            this.searchDirectoryCombo.Location = new System.Drawing.Point(107, 131);
            this.searchDirectoryCombo.Name = "searchDirectoryCombo";
            this.searchDirectoryCombo.Size = new System.Drawing.Size(170, 21);
            this.searchDirectoryCombo.TabIndex = 10;
            // 
            // fullNameCheck
            // 
            this.fullNameCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullNameCheck.AutoSize = true;
            this.fullNameCheck.Location = new System.Drawing.Point(15, 85);
            this.fullNameCheck.Name = "fullNameCheck";
            this.fullNameCheck.Size = new System.Drawing.Size(123, 17);
            this.fullNameCheck.TabIndex = 11;
            this.fullNameCheck.Text = "Название целиком";
            this.fullNameCheck.UseVisualStyleBackColor = true;
            // 
            // nameChangeCheck
            // 
            this.nameChangeCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameChangeCheck.AutoSize = true;
            this.nameChangeCheck.Location = new System.Drawing.Point(15, 108);
            this.nameChangeCheck.Name = "nameChangeCheck";
            this.nameChangeCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameChangeCheck.Size = new System.Drawing.Size(128, 17);
            this.nameChangeCheck.TabIndex = 12;
            this.nameChangeCheck.Text = "Изменять название";
            this.nameChangeCheck.UseVisualStyleBackColor = true;
            // 
            // requireAdministrator
            // 
            this.requireAdministrator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requireAdministrator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(158)))));
            this.requireAdministrator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.requireAdministrator.Controls.Add(this.requireAdministratorLabel);
            this.requireAdministrator.Controls.Add(this.requireAdministratorPicture);
            this.requireAdministrator.Controls.Add(this.requireAdministratorCancelButton);
            this.requireAdministrator.Controls.Add(this.requireAdministratorConfirmButton);
            this.requireAdministrator.Location = new System.Drawing.Point(12, 158);
            this.requireAdministrator.Name = "requireAdministrator";
            this.requireAdministrator.Size = new System.Drawing.Size(295, 100);
            this.requireAdministrator.TabIndex = 13;
            this.requireAdministrator.Visible = false;
            // 
            // requireAdministratorLabel
            // 
            this.requireAdministratorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requireAdministratorLabel.Location = new System.Drawing.Point(59, 3);
            this.requireAdministratorLabel.Name = "requireAdministratorLabel";
            this.requireAdministratorLabel.Size = new System.Drawing.Size(231, 50);
            this.requireAdministratorLabel.TabIndex = 3;
            this.requireAdministratorLabel.Text = "Выполнение этой задачи требует наличия разрешений более высокого уровня.";
            // 
            // requireAdministratorPicture
            // 
            this.requireAdministratorPicture.Image = ((System.Drawing.Image)(resources.GetObject("requireAdministratorPicture.Image")));
            this.requireAdministratorPicture.Location = new System.Drawing.Point(3, 3);
            this.requireAdministratorPicture.Name = "requireAdministratorPicture";
            this.requireAdministratorPicture.Size = new System.Drawing.Size(50, 50);
            this.requireAdministratorPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.requireAdministratorPicture.TabIndex = 2;
            this.requireAdministratorPicture.TabStop = false;
            // 
            // requireAdministratorCancelButton
            // 
            this.requireAdministratorCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.requireAdministratorCancelButton.Location = new System.Drawing.Point(132, 72);
            this.requireAdministratorCancelButton.Name = "requireAdministratorCancelButton";
            this.requireAdministratorCancelButton.Size = new System.Drawing.Size(76, 23);
            this.requireAdministratorCancelButton.TabIndex = 1;
            this.requireAdministratorCancelButton.Text = "Отмена";
            this.requireAdministratorCancelButton.UseVisualStyleBackColor = true;
            this.requireAdministratorCancelButton.Click += new System.EventHandler(this.RequireAdministratorCancelButton_Click);
            // 
            // requireAdministratorConfirmButton
            // 
            this.requireAdministratorConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.requireAdministratorConfirmButton.Location = new System.Drawing.Point(214, 72);
            this.requireAdministratorConfirmButton.Name = "requireAdministratorConfirmButton";
            this.requireAdministratorConfirmButton.Size = new System.Drawing.Size(76, 23);
            this.requireAdministratorConfirmButton.TabIndex = 0;
            this.requireAdministratorConfirmButton.Text = "Перезапуск";
            this.requireAdministratorConfirmButton.UseVisualStyleBackColor = true;
            this.requireAdministratorConfirmButton.Click += new System.EventHandler(this.RequireAdministratorConfirmButton_Click);
            // 
            // currentFile
            // 
            this.currentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentFile.BackColor = System.Drawing.Color.Transparent;
            this.currentFile.Location = new System.Drawing.Point(12, 261);
            this.currentFile.Name = "currentFile";
            this.currentFile.Size = new System.Drawing.Size(295, 38);
            this.currentFile.TabIndex = 14;
            this.currentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(227, 331);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // undoCheck
            // 
            this.undoCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.undoCheck.AutoSize = true;
            this.undoCheck.Checked = true;
            this.undoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.undoCheck.Location = new System.Drawing.Point(169, 85);
            this.undoCheck.Name = "undoCheck";
            this.undoCheck.Size = new System.Drawing.Size(124, 17);
            this.undoCheck.TabIndex = 16;
            this.undoCheck.Text = "Отмена изменений";
            this.undoCheck.UseVisualStyleBackColor = true;
            // 
            // replaceWorker
            // 
            this.replaceWorker.WorkerReportsProgress = true;
            this.replaceWorker.WorkerSupportsCancellation = true;
            this.replaceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReplaceWorker_DoWork);
            this.replaceWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ReplaceWorker_ProgressChanged);
            this.replaceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReplaceWorker_RunWorkerCompleted);
            // 
            // cancelWorker
            // 
            this.cancelWorker.WorkerReportsProgress = true;
            this.cancelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CancelWorker_DoWork);
            this.cancelWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CancelWorker_ProgressChanged);
            this.cancelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CancelWorker_RunWorkerCompleted);
            // 
            // searchSubdirectoriesCheck
            // 
            this.searchSubdirectoriesCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchSubdirectoriesCheck.AutoSize = true;
            this.searchSubdirectoriesCheck.Checked = true;
            this.searchSubdirectoriesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchSubdirectoriesCheck.Location = new System.Drawing.Point(169, 108);
            this.searchSubdirectoriesCheck.Name = "searchSubdirectoriesCheck";
            this.searchSubdirectoriesCheck.Size = new System.Drawing.Size(152, 17);
            this.searchSubdirectoriesCheck.TabIndex = 17;
            this.searchSubdirectoriesCheck.Text = "Поиск в поддиректориях";
            this.searchSubdirectoriesCheck.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(319, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsStripMenuItem,
            this.historyStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // logsStripMenuItem
            // 
            this.logsStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logsStripMenuItem.Name = "logsStripMenuItem";
            this.logsStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.logsStripMenuItem.Text = "Журнал";
            this.logsStripMenuItem.Click += new System.EventHandler(this.LogsStripMenuItem_Click);
            // 
            // historyStripMenuItem
            // 
            this.historyStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.historyStripMenuItem.Name = "historyStripMenuItem";
            this.historyStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.historyStripMenuItem.Text = "История";
            this.historyStripMenuItem.Click += new System.EventHandler(this.HistoryStripMenuItem_Click);
            // 
            // Overwritten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(319, 366);
            this.Controls.Add(this.searchSubdirectoriesCheck);
            this.Controls.Add(this.undoCheck);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.currentFile);
            this.Controls.Add(this.requireAdministrator);
            this.Controls.Add(this.nameChangeCheck);
            this.Controls.Add(this.fullNameCheck);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.searchDirectoryCombo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.replacementCombo);
            this.Controls.Add(this.searchCombo);
            this.Controls.Add(this.replacementSelectionButton);
            this.Controls.Add(this.searchDirectoryLabel);
            this.Controls.Add(this.searchDirectorySelectionButton);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Overwritten";
            this.Text = "Overwritten";
            this.requireAdministrator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requireAdministratorPicture)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.OpenFileDialog replacementSearch;
        private System.Windows.Forms.FolderBrowserDialog searchDirectorySearch;
        private System.Windows.Forms.Button replacementSelectionButton;
        private System.Windows.Forms.Button searchDirectorySelectionButton;
        private System.Windows.Forms.Label searchDirectoryLabel;
        private System.Windows.Forms.Panel requireAdministrator;
        private System.Windows.Forms.PictureBox requireAdministratorPicture;
        private System.Windows.Forms.Button requireAdministratorCancelButton;
        private System.Windows.Forms.Button requireAdministratorConfirmButton;
        private System.Windows.Forms.Label requireAdministratorLabel;
        private System.Windows.Forms.Label currentFile;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyStripMenuItem;
        public System.Windows.Forms.ComboBox searchCombo;
        public System.Windows.Forms.ComboBox replacementCombo;
        public System.Windows.Forms.ComboBox searchDirectoryCombo;
        public System.Windows.Forms.CheckBox fullNameCheck;
        public System.Windows.Forms.CheckBox nameChangeCheck;
        public System.Windows.Forms.CheckBox undoCheck;
        public System.Windows.Forms.CheckBox searchSubdirectoriesCheck;
        public System.ComponentModel.BackgroundWorker replaceWorker;
        public System.ComponentModel.BackgroundWorker cancelWorker;
    }
}
