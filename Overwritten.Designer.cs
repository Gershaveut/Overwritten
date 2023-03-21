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
            this.replace = new System.Windows.Forms.Button();
            this.replacementFile = new System.Windows.Forms.OpenFileDialog();
            this.searchFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.search = new System.Windows.Forms.ComboBox();
            this.replacementSelection = new System.Windows.Forms.Button();
            this.searchDirectorySelection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.replacement = new System.Windows.Forms.ComboBox();
            this.searchDirectory = new System.Windows.Forms.ComboBox();
            this.fullName = new System.Windows.Forms.CheckBox();
            this.nameChange = new System.Windows.Forms.CheckBox();
            this.requireAdministrator = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancel = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.currentFile = new System.Windows.Forms.Label();
            this.undo = new System.Windows.Forms.Button();
            this.undoCheck = new System.Windows.Forms.CheckBox();
            this.requireAdministrator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 282);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(280, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            // 
            // replace
            // 
            this.replace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replace.Location = new System.Drawing.Point(12, 311);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(194, 23);
            this.replace.TabIndex = 1;
            this.replace.Text = "Заменить";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.Click += new System.EventHandler(this.replace_Click);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.search.FormattingEnabled = true;
            this.search.Location = new System.Drawing.Point(12, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(280, 21);
            this.search.TabIndex = 8;
            this.search.Tag = "Поиск";
            this.search.Text = "Поиск";
            this.search.TextChanged += new System.EventHandler(this.ComboBoxs_TextChanged);
            this.search.Enter += new System.EventHandler(this.ComboBoxs_Enter);
            this.search.Leave += new System.EventHandler(this.ComboBoxs_Leave);
            // 
            // replacementSelection
            // 
            this.replacementSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replacementSelection.Location = new System.Drawing.Point(267, 38);
            this.replacementSelection.Name = "replacementSelection";
            this.replacementSelection.Size = new System.Drawing.Size(25, 21);
            this.replacementSelection.TabIndex = 1;
            this.replacementSelection.Text = "...";
            this.replacementSelection.UseVisualStyleBackColor = true;
            this.replacementSelection.Click += new System.EventHandler(this.replacementSelection_Click);
            // 
            // searchDirectorySelection
            // 
            this.searchDirectorySelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectorySelection.Location = new System.Drawing.Point(267, 110);
            this.searchDirectorySelection.Name = "searchDirectorySelection";
            this.searchDirectorySelection.Size = new System.Drawing.Size(25, 21);
            this.searchDirectorySelection.TabIndex = 5;
            this.searchDirectorySelection.Text = "...";
            this.searchDirectorySelection.UseVisualStyleBackColor = true;
            this.searchDirectorySelection.Click += new System.EventHandler(this.searchDirectorySelection_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Область поиска";
            // 
            // replacement
            // 
            this.replacement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replacement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.replacement.ForeColor = System.Drawing.SystemColors.GrayText;
            this.replacement.FormattingEnabled = true;
            this.replacement.Location = new System.Drawing.Point(12, 38);
            this.replacement.Name = "replacement";
            this.replacement.Size = new System.Drawing.Size(250, 21);
            this.replacement.TabIndex = 9;
            this.replacement.Tag = "Заменить";
            this.replacement.Text = "Заменить";
            this.replacement.TextChanged += new System.EventHandler(this.ComboBoxs_TextChanged);
            this.replacement.Enter += new System.EventHandler(this.ComboBoxs_Enter);
            this.replacement.Leave += new System.EventHandler(this.ComboBoxs_Leave);
            // 
            // searchDirectory
            // 
            this.searchDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.searchDirectory.FormattingEnabled = true;
            this.searchDirectory.Location = new System.Drawing.Point(107, 111);
            this.searchDirectory.Name = "searchDirectory";
            this.searchDirectory.Size = new System.Drawing.Size(155, 21);
            this.searchDirectory.TabIndex = 10;
            // 
            // fullName
            // 
            this.fullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullName.AutoSize = true;
            this.fullName.Location = new System.Drawing.Point(15, 65);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(123, 17);
            this.fullName.TabIndex = 11;
            this.fullName.Text = "Название целиком";
            this.fullName.UseVisualStyleBackColor = true;
            // 
            // nameChange
            // 
            this.nameChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameChange.AutoSize = true;
            this.nameChange.Checked = true;
            this.nameChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nameChange.Location = new System.Drawing.Point(15, 88);
            this.nameChange.Name = "nameChange";
            this.nameChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameChange.Size = new System.Drawing.Size(128, 17);
            this.nameChange.TabIndex = 12;
            this.nameChange.Text = "Изменять название";
            this.nameChange.UseVisualStyleBackColor = true;
            // 
            // requireAdministrator
            // 
            this.requireAdministrator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requireAdministrator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(158)))));
            this.requireAdministrator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.requireAdministrator.Controls.Add(this.label2);
            this.requireAdministrator.Controls.Add(this.pictureBox1);
            this.requireAdministrator.Controls.Add(this.cancel);
            this.requireAdministrator.Controls.Add(this.yes);
            this.requireAdministrator.Location = new System.Drawing.Point(12, 163);
            this.requireAdministrator.Name = "requireAdministrator";
            this.requireAdministrator.Size = new System.Drawing.Size(280, 100);
            this.requireAdministrator.TabIndex = 13;
            this.requireAdministrator.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(59, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выполнение этой задачи требует наличия разрешений более высокого уровня.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(117, 72);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(76, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // yes
            // 
            this.yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yes.Location = new System.Drawing.Point(199, 72);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(76, 23);
            this.yes.TabIndex = 0;
            this.yes.Text = "Перезапуск";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // currentFile
            // 
            this.currentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentFile.BackColor = System.Drawing.Color.Transparent;
            this.currentFile.Location = new System.Drawing.Point(19, 266);
            this.currentFile.Name = "currentFile";
            this.currentFile.Size = new System.Drawing.Size(273, 13);
            this.currentFile.TabIndex = 14;
            this.currentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // undo
            // 
            this.undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.undo.Enabled = false;
            this.undo.Location = new System.Drawing.Point(212, 311);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(80, 23);
            this.undo.TabIndex = 15;
            this.undo.Text = "Отменить";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // undoCheck
            // 
            this.undoCheck.AutoSize = true;
            this.undoCheck.Checked = true;
            this.undoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.undoCheck.Location = new System.Drawing.Point(169, 65);
            this.undoCheck.Name = "undoCheck";
            this.undoCheck.Size = new System.Drawing.Size(124, 17);
            this.undoCheck.TabIndex = 16;
            this.undoCheck.Text = "Отмена изменений";
            this.undoCheck.UseVisualStyleBackColor = true;
            // 
            // Overwritten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 346);
            this.Controls.Add(this.undoCheck);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.currentFile);
            this.Controls.Add(this.requireAdministrator);
            this.Controls.Add(this.nameChange);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.replace);
            this.Controls.Add(this.searchDirectory);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.replacement);
            this.Controls.Add(this.search);
            this.Controls.Add(this.replacementSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchDirectorySelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Overwritten";
            this.Text = "Overwritten";
            this.requireAdministrator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button replace;
        private System.Windows.Forms.OpenFileDialog replacementFile;
        private System.Windows.Forms.FolderBrowserDialog searchFolder;
        private System.Windows.Forms.Button replacementSelection;
        private System.Windows.Forms.Button searchDirectorySelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox search;
        private System.Windows.Forms.ComboBox replacement;
        private System.Windows.Forms.ComboBox searchDirectory;
        private System.Windows.Forms.CheckBox fullName;
        private System.Windows.Forms.CheckBox nameChange;
        private System.Windows.Forms.Panel requireAdministrator;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentFile;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.CheckBox undoCheck;
    }
}

