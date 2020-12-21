using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUBD
{
    public partial class EditTable : Form
    {

        public static Table Table;
        private static int countRow;
        
        public EditTable(Table loadedTable)
        {
            InitializeComponent();
            AddingTable.ReadOnly = true;
            countRow = 0;
            Table = loadedTable;
            InitializeDataGrid();
            FillDataGrid(loadedTable);
    
        }
        private void editRowButton_Click(object sender, EventArgs e)
        {
            if (!IsPrimaryKey())
            {
                editForm form = new editForm(Table.Fields[AddingTable.SelectedRows[0].Index], Table);
                form.ShowDialog();
            }
            else ShowError("Невозможно редактировать поле с первичным ключем");
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            editForm form = new editForm(Table);
            form.ShowDialog();
        }
        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            if (!IsPrimaryKey())
            {
                Program.CurrentDb.DropColumn(Table, Table.Fields[AddingTable.SelectedRows[0].Index]);
                AddingTable.Rows.RemoveAt(AddingTable.SelectedRows[0].Index);
                label1.Visible = false;
            }
            else ShowError("Невозможно удалить поле с первичным ключем");

        }
        private void changeTable_Activated(object sender, EventArgs e)
        {
            AddingTable.Rows.Clear();
            FillDataGrid(Table);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsPrimaryKey()
        {
            int row = AddingTable.SelectedRows[0].Index;
            if (AddingTable.Rows[row].Cells[3].Value != null 
                && (bool)AddingTable.Rows[row].Cells[3].Value != false)
            {
                return true;
            }

            return false;
        }

        public void ShowError(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            label1.Text = text;
        }
        public void AddRow(int n)
        {
            for (int i = 0; i < n; i++)
            {
                AddRow();
            }
        }



        public void FillDataGrid(Table table)
        {
            tableName.Text = table.Name;
            AddRow(table.Fields.Count);
            DataGridViewRow currentRow;
            for (int i = 0; i < table.Fields.Count; i++)
            {
                currentRow = AddingTable.Rows[i];
                FillRow(currentRow, table.Fields[i]);
            }
        }

        public void FillRow(DataGridViewRow row, Field field)
        {
            row.Cells[0].Value = field.Name;
            row.Cells[1].Value = field.Type;
            row.Cells[2].Value = field.NotNull;
            row.Cells[3].Value = field.PrimaryKey;
            row.Cells[4].Value = field.AutoInc;
            if (field.Foreign != null)
            {
                row.Cells[5].Value = field.Foreign.ToTable.Name + "." + field.Foreign.ToField.Name;
            }
        }
        private void AddRow()
        {
            string name = "field" + countRow;
            AddingTable.Rows.Add(name, "INTEGER");
            countRow++;
        }
        public void InitializeDataGrid()
        {
            AddingTable.ColumnCount = 1;
            AddingTable.Columns[0].Name = "Имя";
            DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
            temp.Items.Add("TEXT");
            temp.Items.Add("INTEGER");
            temp.Items.Add("REAL");
            temp.Name = "Тип";
            AddingTable.Columns.Add(temp);
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[2].Name = "Не пустое";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[3].Name = "Ключ";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[4].Name = "Счетчик";
            AddingTable.Columns.Add("Связи", "Связи");
            
        }      
       
    }
}
