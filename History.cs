using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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

            DataGridViewButtonColumn cancelButtonColum = new DataGridViewButtonColumn
            {
                Name = "Отмена замены",
            };

            historyDataGridView.Columns.AddRange(searchColumn, replacementColumn, searchDirectoryColumn, fullNameColumn, nameChangeColumn, undoColumn, searchSubdirectoriesColumn, cancelButtonColum);
        }
    }
}
