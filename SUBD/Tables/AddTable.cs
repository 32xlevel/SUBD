using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SUBD
{
    public partial class AddTable : Form
    {
        private static Table _table;
        private static List<Field> _fields;
        private static int countRows;
        
        public AddTable()
        {
            InitializeComponent();
            countRows = 0;        
            _table = new Table(tableName.Text, new List<Field>(), null);
            _fields = new List<Field>();
            InitializeDataGrid();
        }

        private void AddRow()
        {
            var name = "field" + countRows;
            AddingTable.Rows.Add(name, "INTEGER");
            countRows++;
        }

        private static List<string> GetAllFitFields(string type)
        {
            return (from item in Program.Tables from field in item.Fields where field.Type == type select item.Name + "." + field.Name).ToList();
        }

        private void FillColumnConnections(List<string> items, int rowIndex)
        {
            var cell = (DataGridViewComboBoxCell)(AddingTable.Rows[rowIndex].Cells["Связи"]);
            cell.DataSource = items ?? new List<string> { " " };
        }

        private static string GetTableName(DataGridViewRow row)
        {
            return row.Cells[5].Value.ToString().Split('.')[0];
        }

        private static string GetFieldName(DataGridViewRow row)
        {
            return row.Cells[5].Value.ToString().Split('.')[1];
        }

        private void InitializeDataGrid()
        {           
            AddingTable.ColumnCount = 1;
            AddingTable.Columns[0].Name = "Имя";
            DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
            temp.Items.Add("STRING");
            temp.Items.Add("INTEGER");
            temp.Items.Add("REAL");
            temp.Name = "Тип";
            AddingTable.Columns.Add(temp);
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[2].Name = "Not null?";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[3].Name = "Ключ?";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[4].Name = "Счетчик?";
            temp = new DataGridViewComboBoxColumn();

            temp.Name = "Связи";
            temp.Items.Add("");
            temp.Items.Add("table.field"); 
            AddingTable.Columns.Add(temp);
        }


        private void ShowError(string text)
        {
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        private bool CheckTableUniqName()
        {
            foreach (var item in Program.Tables)
            {
                if (item.Name.Equals(tableName.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckFieldsUniqName()
        {
            for (int i = 0; i < AddingTable.Rows.Count; i++)
            {
                DataGridViewRow item = AddingTable.Rows[i];
                for (int j = i + 1; j < AddingTable.Rows.Count; j++)
                {
                    if (item.Cells[0].Value.ToString() == AddingTable.Rows[j].Cells[0].Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsFieldsNamesValid()
        {
            for (var i = 0; i < AddingTable.Rows.Count; i++)
            {
                var item = AddingTable.Rows[i];

                if (item.Cells[0].Value.ToString().Any(symbol => !char.IsLetterOrDigit(symbol) && symbol != '_'))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsTableNameValid()
        {
            return char.IsLetter(tableName.Text[0]) && tableName.Text.All(symbol => char.IsLetterOrDigit(symbol) || symbol == '_');
        }

        private bool CheckFieldsNames()
        {
            var hasFieldsNames = true;
            for (var i = 0; i < AddingTable.Rows.Count; i++)
            {
                var item = AddingTable.Rows[i];
                if (item.Cells[0].Value == null)
                {
                    hasFieldsNames = false;
                }
            }
            return hasFieldsNames;
        }

        private bool CheckTableName()
        {
            return !tableName.Text.Equals("");
        }

        private bool CheckPrimaryKey()
        {
            var countPrimaryKeys = 0;
            for (var i = 0; i < AddingTable.Rows.Count; i++)
            {
                var item = AddingTable.Rows[i];
                if (item.Cells[3].Value != null && (bool)item.Cells[3].Value != false) countPrimaryKeys++;
            }
            return countPrimaryKeys == 1;
        }

        private bool CheckRowCount()
        {
           return AddingTable.Rows.Count >= 1;
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (CheckFieldsNames() && CheckPrimaryKey() && CheckRowCount()
                && CheckTableName() && CheckTableUniqName()
                && CheckFieldsUniqName() && IsTableNameValid())
            {
                for (int i = 0; i < AddingTable.Rows.Count; i++)
                {

                    var item = AddingTable.Rows[i];

                    var field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                        item.Cells[2].Value != null, item.Cells[3].Value != null,
                        item.Cells[4].Value != null, item.Cells[3].Value != null);
                    if (item.Cells[3].Value != null) _table.PrimaryField = field;

                    if (item.Cells[5].Value != null)
                    {
                        var tableName = GetTableName(item);
                        var fieldName = GetFieldName(item);
                        var depTable = Program.Tables.Find(p => p.Name == tableName);
                        var tempField = depTable.Fields.Find(p => p.Name == fieldName);

                        field.Foreign = new Foreign(depTable, tempField);
                    }
                    _fields.Add(field);
                }
                _table.Name = tableName.Text;
                _table.Fields = _fields;

                Program.Tables.Add(_table);
                Program.CurrentDb.Create(_table);
                Close();
            }
            else
            {
                if (!CheckTableName()) ShowError("У таблицы должно быть название");
                else if (!CheckTableUniqName()) ShowError("Название таблицы совпадает с названием существующей таблицей");
                else if (!IsTableNameValid()) ShowError("Название таблицы может начинаться только с буквы и содержать только буквы, цифры или нижнее подчеркивание");
                else if (!CheckRowCount()) ShowError("Создайте поля");
                else if (!CheckFieldsNames()) ShowError("У каждого поля должно быть название");
                else if (!IsFieldsNamesValid()) ShowError("Название поля может начинаться только с буквы и содержать только буквы, цифры или нижнее подчеркивание");
                else if (!CheckFieldsUniqName()) ShowError("Названия полей должны быть уникальны");
                else if (!CheckPrimaryKey()) ShowError("В таблице может быть только одно ключевое поле");
            }
        }

        private void AddingTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AddingTable.CurrentCell.ColumnIndex == 1)
            {
                var type = AddingTable.CurrentCell.Value.ToString();
                var fields = GetAllFitFields(type);
                FillColumnConnections(fields, AddingTable.CurrentCell.RowIndex);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddRow();
            const string type = "INT";
            var items = GetAllFitFields(type);
            FillColumnConnections(items, AddingTable.Rows.Count - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AddingTable.Rows.Count >= 1)
                AddingTable.Rows.RemoveAt(AddingTable.Rows.Count - 1);
        }

        private void tableName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
