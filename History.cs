using OFGmCoreCS.LoggerSimple;
using System;
using System.Windows.Forms;

namespace Overwritten
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();

            DataGridViewTextBoxColumn searchColumn = new DataGridViewTextBoxColumn
            {
                Name = "Поиск"
            };

            DataGridViewTextBoxColumn replacementColumn = new DataGridViewTextBoxColumn
            {
                Name = "Заменить"
            };

            DataGridViewTextBoxColumn searchDirectoryColumn = new DataGridViewTextBoxColumn
            {
                Name = "Область поиска"
            };

            DataGridViewCheckBoxColumn fullNameColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Название целиком"
            };

            DataGridViewCheckBoxColumn nameChangeColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Изменять название"
            };

            DataGridViewCheckBoxColumn undoColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Отмена изменений"
            };

            DataGridViewCheckBoxColumn searchSubdirectoriesColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Поиск в поддиректориях"
            };

            DataGridViewTextBoxColumn IdColumn = new DataGridViewTextBoxColumn
            {
                Name = "ID"
            };

            DataGridViewButtonColumn cancelButtonColum = new DataGridViewButtonColumn
            {
                Name = "Отмена замены",
            };
            
            historyDataGridView.Columns.AddRange(searchColumn, replacementColumn, searchDirectoryColumn, fullNameColumn, nameChangeColumn, undoColumn, searchSubdirectoriesColumn, IdColumn, cancelButtonColum);
        }

 

        private void History_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }

        private void HistoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    if (!Program.overwritten.replaceWorker.IsBusy && !Program.overwritten.cancelWorker.IsBusy)
                        Program.overwritten.Cancel(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value), e.RowIndex);
                    else
                        Program.overwritten.ShowMessageBoxWithLog("Программа уже работает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);
                }
                catch (Exception ex)
                {
                    Program.overwritten.ShowMessageBoxWithLog(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, LoggerLevel.Error);

                    Program.overwritten.logger.Write(ex.ToString(), LoggerLevel.Debug);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            historyDataGridView.Rows.Clear();
            Program.overwritten.ClearUndoFiles();
        }
    }
}
