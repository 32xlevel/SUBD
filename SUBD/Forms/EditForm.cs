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
    public partial class editForm : Form
    {
        Table curerntTable;
        Field currentField;
        bool isNewField;

        public editForm(Table table)
        {
            InitializeComponent();
            this.InitializeDataGrid();
            this.AddRow();
            this.isNewField = true;
            this.curerntTable = table;
            editDataGridView.Rows[0].Cells[1].Value = "INTEGER";
        }

        public editForm(Field field, Table table)
        {
            InitializeComponent();
            this.curerntTable = table;
            this.currentField = field;
            this.InitializeDataGrid();
            this.ReadOnlyGrid();
            this.AddRow();
            this.FillRow(editDataGridView.Rows[0], field);
        }

        private void ReadOnlyGrid()
        {
            for (int i = 1; i <= 5; i++)
            {
                editDataGridView.Columns[i].ReadOnly = true;
            }
            
        }

        private void Replace()
        {
            int index = curerntTable.Fields.FindIndex(e => e.Name == currentField.Name);
            currentField.Name = editDataGridView.Rows[0].Cells[0].Value.ToString();
            curerntTable.Fields[index] = currentField;
        }

        private bool CheckFieldsNames()
        {
            return editDataGridView.Rows[0].Cells[0].Value != null 
                && editDataGridView.Rows[0].Cells[0].Value.ToString().Length > 0;
        }

        private bool CheckFieldsUniqueName()
        {
            if (!isNewField && currentField.Name == editDataGridView.Rows[0].Cells[0].Value.ToString()) this.Close(); 
            for (int i = 0; i < curerntTable.Fields.Count; i++)
            {
                Field item = curerntTable.Fields[i];
                
                Console.WriteLine(editDataGridView.Rows[0].Cells[0].Value.ToString());
                
                if (item.Name == editDataGridView.Rows[0].Cells[0].Value.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidField()
        {

            foreach (Char symbol in editDataGridView.Rows[0].Cells[0].Value.ToString())
            {
                if (!Char.IsLetterOrDigit(symbol) && symbol != '_') return false;
            }
             
            return true;
        }

        public bool IsRowPrimaryKey()
        {
            DataGridViewRow row = editDataGridView.Rows[0];
            if (row.Cells[3].Value == null
                || (bool)row.Cells[3].Value == false)
            {
                return false;
            }
            return true;
        }

        public void InitializeDataGrid()
        {
            editDataGridView.ColumnCount = 1;
            editDataGridView.Columns[0].Name = "Имя";
            DataGridViewComboBoxColumn grid = new DataGridViewComboBoxColumn();
            grid.Items.Add("TEXT");
            grid.Items.Add("INTEGER");
            grid.Items.Add("REAL");
            grid.Name = "Тип";
            editDataGridView.Columns.Add(grid);
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[2].Name = "Не пустое";
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[3].Name = "Ключ";
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[4].Name = "Счетчик";
            grid = new DataGridViewComboBoxColumn();
            //todo добавить связи
            grid.Name = "Связи";
            grid.Items.Add("");
            grid.Items.Add("table.field"); //can be null
            editDataGridView.Columns.Add(grid);
        }

        private void AddRow()
        {
            editDataGridView.Rows.Add();
        }

        public void ShowError(string text)
        {
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        public void FillRow(DataGridViewRow row, Field field)
        {
            row.Cells[0].Value = field.Name;
            row.Cells[1].Value = field.Type;
            row.Cells[2].Value = field.NotNull;
            row.Cells[3].Value = field.PrimaryKey;
            row.Cells[4].Value = field.AutoInc;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (CheckFieldsNames() && CheckFieldsUniqueName() && IsValidField() && !IsRowPrimaryKey())
            {
                if (!isNewField)
                {
                    Program.CurrentDb.RenameColumn(curerntTable.Name, currentField.Name,
                        editDataGridView.Rows[0].Cells[0].Value.ToString());
                    Replace();
                    EditTable.Table = curerntTable;
                    this.Close();
                }
                else
                {
                    Field field;
                    DataGridViewRow item = editDataGridView.Rows[0];
                    if (item.Cells[3].Value == null)
                    {
                        field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                            item.Cells[2].Value != null, item.Cells[3].Value != null,
                            item.Cells[4].Value != null, item.Cells[3].Value != null);
                    }
                    else
                    {
                        field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                            item.Cells[2].Value != null, (bool)item.Cells[3].Value == true,
                            item.Cells[4].Value != null, item.Cells[3].Value != null);
                    }

                    curerntTable.Fields.Add(field);
                    Program.CurrentDb.AddColumn(curerntTable.Name, field);
                    EditTable.Table = curerntTable;
                    this.Close();
                }
            }
            else if (!CheckFieldsNames()) ShowError("У поля должно быть название");
            else if (!IsValidField()) ShowError("Название поля может содержать только буквы, цифры или нижнее подчеркивание");
            else if (!CheckFieldsUniqueName()) ShowError("Название поля совпадает с названием существующого поля");
            else if (IsRowPrimaryKey()) ShowError("Невозможно добавить еще одно ключевое поле");
        }
    }
}
