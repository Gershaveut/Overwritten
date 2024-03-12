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
            progressBar = new System.Windows.Forms.ProgressBar();
            replaceButton = new System.Windows.Forms.Button();
            replacementSearch = new System.Windows.Forms.OpenFileDialog();
            searchDirectorySearch = new System.Windows.Forms.FolderBrowserDialog();
            searchCombo = new System.Windows.Forms.ComboBox();
            replacementSelectionButton = new System.Windows.Forms.Button();
            searchDirectorySelectionButton = new System.Windows.Forms.Button();
            searchDirectoryLabel = new System.Windows.Forms.Label();
            replacementCombo = new System.Windows.Forms.ComboBox();
            searchDirectoryCombo = new System.Windows.Forms.ComboBox();
            fullNameCheck = new System.Windows.Forms.CheckBox();
            nameChangeCheck = new System.Windows.Forms.CheckBox();
            requireAdministrator = new System.Windows.Forms.Panel();
            requireAdministratorLabel = new System.Windows.Forms.Label();
            requireAdministratorPicture = new System.Windows.Forms.PictureBox();
            requireAdministratorCancelButton = new System.Windows.Forms.Button();
            requireAdministratorConfirmButton = new System.Windows.Forms.Button();
            fileCountLabel = new System.Windows.Forms.Label();
            currentFileLabel = new System.Windows.Forms.Label();
            cancelButton = new System.Windows.Forms.Button();
            undoCheck = new System.Windows.Forms.CheckBox();
            replaceWorker = new System.ComponentModel.BackgroundWorker();
            cancelWorker = new System.ComponentModel.BackgroundWorker();
            searchSubdirectoriesCheck = new System.Windows.Forms.CheckBox();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            historyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            requireAdministrator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)requireAdministratorPicture).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new Point(14, 349);
            progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Minimum = 1;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(344, 27);
            progressBar.Step = 1;
            progressBar.TabIndex = 0;
            progressBar.Value = 1;
            progressBar.Visible = false;
            // 
            // replaceButton
            // 
            replaceButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            replaceButton.Location = new Point(14, 382);
            replaceButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            replaceButton.Name = "replaceButton";
            replaceButton.Size = new Size(244, 27);
            replaceButton.TabIndex = 1;
            replaceButton.Text = "Заменить";
            replaceButton.UseVisualStyleBackColor = true;
            replaceButton.Click += ReplaceButton_Click;
            // 
            // searchCombo
            // 
            searchCombo.AllowDrop = true;
            searchCombo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchCombo.ForeColor = SystemColors.GrayText;
            searchCombo.FormattingEnabled = true;
            searchCombo.Location = new Point(14, 37);
            searchCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchCombo.Name = "searchCombo";
            searchCombo.Size = new Size(344, 23);
            searchCombo.TabIndex = 8;
            searchCombo.Tag = "Поиск";
            searchCombo.Text = "Поиск";
            searchCombo.TextChanged += ComboBoxes_TextChanged;
            searchCombo.DragDrop += SearchCombo_DragDrop;
            searchCombo.DragEnter += SearchCombo_DragEnter;
            searchCombo.Enter += ComboBoxes_Enter;
            searchCombo.Leave += ComboBoxes_Leave;
            // 
            // replacementSelectionButton
            // 
            replacementSelectionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            replacementSelectionButton.Location = new Point(329, 67);
            replacementSelectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            replacementSelectionButton.Name = "replacementSelectionButton";
            replacementSelectionButton.Size = new Size(29, 24);
            replacementSelectionButton.TabIndex = 1;
            replacementSelectionButton.Text = "...";
            replacementSelectionButton.UseVisualStyleBackColor = true;
            replacementSelectionButton.Click += ReplacementSelectionButton_Click;
            // 
            // searchDirectorySelectionButton
            // 
            searchDirectorySelectionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            searchDirectorySelectionButton.Location = new Point(329, 150);
            searchDirectorySelectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchDirectorySelectionButton.Name = "searchDirectorySelectionButton";
            searchDirectorySelectionButton.Size = new Size(29, 24);
            searchDirectorySelectionButton.TabIndex = 5;
            searchDirectorySelectionButton.Text = "...";
            searchDirectorySelectionButton.UseVisualStyleBackColor = true;
            searchDirectorySelectionButton.Click += SearchDirectorySelectionButton_Click;
            // 
            // searchDirectoryLabel
            // 
            searchDirectoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchDirectoryLabel.AutoSize = true;
            searchDirectoryLabel.Location = new Point(13, 153);
            searchDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            searchDirectoryLabel.Name = "searchDirectoryLabel";
            searchDirectoryLabel.Size = new Size(95, 15);
            searchDirectoryLabel.TabIndex = 7;
            searchDirectoryLabel.Text = "Область поиска";
            // 
            // replacementCombo
            // 
            replacementCombo.AllowDrop = true;
            replacementCombo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            replacementCombo.ForeColor = SystemColors.GrayText;
            replacementCombo.FormattingEnabled = true;
            replacementCombo.Location = new Point(14, 67);
            replacementCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            replacementCombo.Name = "replacementCombo";
            replacementCombo.Size = new Size(308, 23);
            replacementCombo.TabIndex = 9;
            replacementCombo.Tag = "Заменить";
            replacementCombo.Text = "Заменить";
            replacementCombo.TextChanged += ComboBoxes_TextChanged;
            replacementCombo.DragDrop += ReplacementCombo_DragDrop;
            replacementCombo.DragEnter += ReplacementCombo_DragEnter;
            replacementCombo.Enter += ComboBoxes_Enter;
            replacementCombo.Leave += ComboBoxes_Leave;
            // 
            // searchDirectoryCombo
            // 
            searchDirectoryCombo.AllowDrop = true;
            searchDirectoryCombo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchDirectoryCombo.FormattingEnabled = true;
            searchDirectoryCombo.Location = new Point(125, 151);
            searchDirectoryCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchDirectoryCombo.Name = "searchDirectoryCombo";
            searchDirectoryCombo.Size = new Size(198, 23);
            searchDirectoryCombo.TabIndex = 10;
            searchDirectoryCombo.DragDrop += SearchDirectoryCombo_DragDrop;
            searchDirectoryCombo.DragEnter += SearchDirectoryCombo_DragEnter;
            // 
            // fullNameCheck
            // 
            fullNameCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fullNameCheck.AutoSize = true;
            fullNameCheck.Location = new Point(18, 99);
            fullNameCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fullNameCheck.Name = "fullNameCheck";
            fullNameCheck.Size = new Size(130, 19);
            fullNameCheck.TabIndex = 11;
            fullNameCheck.Text = "Название целиком";
            fullNameCheck.UseVisualStyleBackColor = true;
            // 
            // nameChangeCheck
            // 
            nameChangeCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nameChangeCheck.AutoSize = true;
            nameChangeCheck.Location = new Point(18, 126);
            nameChangeCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nameChangeCheck.Name = "nameChangeCheck";
            nameChangeCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            nameChangeCheck.Size = new Size(132, 19);
            nameChangeCheck.TabIndex = 12;
            nameChangeCheck.Text = "Изменять название";
            nameChangeCheck.UseVisualStyleBackColor = true;
            // 
            // requireAdministrator
            // 
            requireAdministrator.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            requireAdministrator.BackColor = Color.FromArgb(255, 255, 158);
            requireAdministrator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            requireAdministrator.Controls.Add(requireAdministratorLabel);
            requireAdministrator.Controls.Add(requireAdministratorPicture);
            requireAdministrator.Controls.Add(requireAdministratorCancelButton);
            requireAdministrator.Controls.Add(requireAdministratorConfirmButton);
            requireAdministrator.Location = new Point(14, 182);
            requireAdministrator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            requireAdministrator.Name = "requireAdministrator";
            requireAdministrator.Size = new Size(344, 115);
            requireAdministrator.TabIndex = 13;
            requireAdministrator.Visible = false;
            // 
            // requireAdministratorLabel
            // 
            requireAdministratorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            requireAdministratorLabel.Location = new Point(69, 3);
            requireAdministratorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            requireAdministratorLabel.Name = "requireAdministratorLabel";
            requireAdministratorLabel.Size = new Size(270, 58);
            requireAdministratorLabel.TabIndex = 3;
            requireAdministratorLabel.Text = "Выполнение этой задачи требует наличия разрешений более высокого уровня.";
            // 
            // requireAdministratorPicture
            // 
            requireAdministratorPicture.Image = (Image)resources.GetObject("requireAdministratorPicture.Image");
            requireAdministratorPicture.Location = new Point(4, 3);
            requireAdministratorPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            requireAdministratorPicture.Name = "requireAdministratorPicture";
            requireAdministratorPicture.Size = new Size(58, 58);
            requireAdministratorPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            requireAdministratorPicture.TabIndex = 2;
            requireAdministratorPicture.TabStop = false;
            // 
            // requireAdministratorCancelButton
            // 
            requireAdministratorCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            requireAdministratorCancelButton.Location = new Point(154, 83);
            requireAdministratorCancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            requireAdministratorCancelButton.Name = "requireAdministratorCancelButton";
            requireAdministratorCancelButton.Size = new Size(89, 27);
            requireAdministratorCancelButton.TabIndex = 1;
            requireAdministratorCancelButton.Text = "Отмена";
            requireAdministratorCancelButton.UseVisualStyleBackColor = true;
            requireAdministratorCancelButton.Click += RequireAdministratorCancelButton_Click;
            // 
            // requireAdministratorConfirmButton
            // 
            requireAdministratorConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            requireAdministratorConfirmButton.Location = new Point(250, 83);
            requireAdministratorConfirmButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            requireAdministratorConfirmButton.Name = "requireAdministratorConfirmButton";
            requireAdministratorConfirmButton.Size = new Size(89, 27);
            requireAdministratorConfirmButton.TabIndex = 0;
            requireAdministratorConfirmButton.Text = "Перезапуск";
            requireAdministratorConfirmButton.UseVisualStyleBackColor = true;
            requireAdministratorConfirmButton.Click += RequireAdministratorConfirmButton_Click;
            // 
            // fileCountLabel
            // 
            fileCountLabel.BackColor = Color.Transparent;
            fileCountLabel.ForeColor = SystemColors.ControlText;
            fileCountLabel.Location = new Point(14, 318);
            fileCountLabel.Name = "fileCountLabel";
            fileCountLabel.Size = new Size(344, 28);
            fileCountLabel.TabIndex = 18;
            fileCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentFileLabel
            // 
            currentFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            currentFileLabel.BackColor = Color.Transparent;
            currentFileLabel.Location = new Point(14, 242);
            currentFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            currentFileLabel.Name = "currentFileLabel";
            currentFileLabel.Size = new Size(344, 76);
            currentFileLabel.TabIndex = 14;
            currentFileLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(265, 382);
            cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(93, 27);
            cancelButton.TabIndex = 15;
            cancelButton.Text = "Отменить";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // undoCheck
            // 
            undoCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            undoCheck.AutoSize = true;
            undoCheck.Checked = true;
            undoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            undoCheck.Location = new Point(197, 99);
            undoCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            undoCheck.Name = "undoCheck";
            undoCheck.Size = new Size(132, 19);
            undoCheck.TabIndex = 16;
            undoCheck.Text = "Отмена изменений";
            undoCheck.UseVisualStyleBackColor = true;
            // 
            // replaceWorker
            // 
            replaceWorker.WorkerReportsProgress = true;
            replaceWorker.WorkerSupportsCancellation = true;
            replaceWorker.DoWork += ReplaceWorker_DoWork;
            replaceWorker.ProgressChanged += ReplaceWorker_ProgressChanged;
            replaceWorker.RunWorkerCompleted += ReplaceWorker_RunWorkerCompleted;
            // 
            // cancelWorker
            // 
            cancelWorker.WorkerReportsProgress = true;
            cancelWorker.DoWork += CancelWorker_DoWork;
            cancelWorker.ProgressChanged += CancelWorker_ProgressChanged;
            cancelWorker.RunWorkerCompleted += CancelWorker_RunWorkerCompleted;
            // 
            // searchSubdirectoriesCheck
            // 
            searchSubdirectoriesCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            searchSubdirectoriesCheck.AutoSize = true;
            searchSubdirectoriesCheck.Checked = true;
            searchSubdirectoriesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            searchSubdirectoriesCheck.Location = new Point(197, 126);
            searchSubdirectoriesCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchSubdirectoriesCheck.Name = "searchSubdirectoriesCheck";
            searchSubdirectoriesCheck.Size = new Size(163, 19);
            searchSubdirectoriesCheck.TabIndex = 17;
            searchSubdirectoriesCheck.Text = "Поиск в поддиректориях";
            searchSubdirectoriesCheck.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = SystemColors.ControlLightLight;
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(372, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { logsStripMenuItem, historyStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // logsStripMenuItem
            // 
            logsStripMenuItem.BackColor = SystemColors.ControlLightLight;
            logsStripMenuItem.Name = "logsStripMenuItem";
            logsStripMenuItem.Size = new Size(121, 22);
            logsStripMenuItem.Text = "Журнал";
            logsStripMenuItem.Click += LogsStripMenuItem_Click;
            // 
            // historyStripMenuItem
            // 
            historyStripMenuItem.BackColor = SystemColors.ControlLightLight;
            historyStripMenuItem.Name = "historyStripMenuItem";
            historyStripMenuItem.Size = new Size(121, 22);
            historyStripMenuItem.Text = "История";
            historyStripMenuItem.Click += HistoryStripMenuItem_Click;
            // 
            // Overwritten
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(372, 422);
            Controls.Add(requireAdministrator);
            Controls.Add(searchSubdirectoriesCheck);
            Controls.Add(undoCheck);
            Controls.Add(cancelButton);
            Controls.Add(fileCountLabel);
            Controls.Add(currentFileLabel);
            Controls.Add(nameChangeCheck);
            Controls.Add(fullNameCheck);
            Controls.Add(replaceButton);
            Controls.Add(searchDirectoryCombo);
            Controls.Add(replacementCombo);
            Controls.Add(searchCombo);
            Controls.Add(replacementSelectionButton);
            Controls.Add(searchDirectoryLabel);
            Controls.Add(searchDirectorySelectionButton);
            Controls.Add(menuStrip);
            Controls.Add(progressBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 461);
            MinimumSize = new Size(388, 461);
            Name = "Overwritten";
            Text = "Overwritten";
            Shown += Overwritten_Shown;
            requireAdministrator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)requireAdministratorPicture).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.OpenFileDialog replacementSearch;
        private System.Windows.Forms.FolderBrowserDialog searchDirectorySearch;
        private System.Windows.Forms.Button replacementSelectionButton;
        private System.Windows.Forms.Button searchDirectorySelectionButton;
        private System.Windows.Forms.Label searchDirectoryLabel;
        private System.Windows.Forms.ComboBox searchCombo;
        private System.Windows.Forms.ComboBox replacementCombo;
        private System.Windows.Forms.ComboBox searchDirectoryCombo;
        private System.Windows.Forms.CheckBox fullNameCheck;
        private System.Windows.Forms.CheckBox nameChangeCheck;
        private System.Windows.Forms.Panel requireAdministrator;
        private System.Windows.Forms.PictureBox requireAdministratorPicture;
        private System.Windows.Forms.Button requireAdministratorCancelButton;
        private System.Windows.Forms.Button requireAdministratorConfirmButton;
        private System.Windows.Forms.Label requireAdministratorLabel;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox undoCheck;
        private System.Windows.Forms.CheckBox searchSubdirectoriesCheck;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyStripMenuItem;
        private System.Windows.Forms.Label fileCountLabel;
        internal System.ComponentModel.BackgroundWorker replaceWorker;
        internal System.ComponentModel.BackgroundWorker cancelWorker;
    }
}
