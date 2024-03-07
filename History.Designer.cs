namespace Overwritten
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            historyDataGridView = new System.Windows.Forms.DataGridView();
            BackButton = new System.Windows.Forms.Button();
            ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)historyDataGridView).BeginInit();
            SuspendLayout();
            // 
            // historyDataGridView
            // 
            historyDataGridView.AllowUserToAddRows = false;
            historyDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            historyDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyDataGridView.Location = new System.Drawing.Point(14, 14);
            historyDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            historyDataGridView.Name = "historyDataGridView";
            historyDataGridView.ReadOnly = true;
            historyDataGridView.Size = new System.Drawing.Size(1100, 471);
            historyDataGridView.TabIndex = 0;
            historyDataGridView.CellContentClick += HistoryDataGridView_CellContentClick;
            // 
            // BackButton
            // 
            BackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BackButton.Location = new System.Drawing.Point(1027, 492);
            BackButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(88, 27);
            BackButton.TabIndex = 1;
            BackButton.Text = "Назад";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ClearButton.Location = new System.Drawing.Point(14, 492);
            ClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new System.Drawing.Size(88, 27);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "Очистить";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // History
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1128, 532);
            Controls.Add(ClearButton);
            Controls.Add(BackButton);
            Controls.Add(historyDataGridView);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "History";
            Text = "История";
            FormClosing += History_FormClosing;
            ((System.ComponentModel.ISupportInitialize)historyDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.DataGridView historyDataGridView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ClearButton;
    }
}