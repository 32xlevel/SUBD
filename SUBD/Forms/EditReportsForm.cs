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
    public partial class editRecordsForm : Form
    {
        Table currentTable;
        bool isNewRecord;
        List<string> data;
        int colIndex;
        string keyValue;
        public editRecordsForm(Table table)
        {
            InitializeComponent();
            this.isNewRecord = true;
            this.currentTable = table;
            this.FillDataGridColumns(table);
            this.AddRow();
        }

        public editRecordsForm(Table table, List<string> data, string value)
        {
            InitializeComponent();
            this.currentTable = table;
            this.FillDataGridColumns(table);
            this.AddRow();
            this.isNewRecord = false;
            this.data = data;
            this.FillDataInDataGrid();
            this.keyValue = value;
        }

        public void FillDataInDataGrid()
        {
            int columnIndex = 0;
            for (int j = 0; j < data.Count; j++)
            {
                if (j == colIndex) continue;
                tableData.Rows[0].Cells[columnIndex].Value = data[j].ToString();
                columnIndex++;
            }
        }
    
        public void FillDataGridColumns(Table table)
        {
            int counter = 0;
            /*tableData.ColumnCount = table.Fields.Count;*/
            for (int i = 0; i < table.Fields.Count; i++)
            {
                if (table.Fields[i].AutoInc)
                {
                    colIndex = i;
                    continue;
                }
                tableData.Columns.Add(i.ToString(), table.Fields[i].Name + " (" + table.Fields[i].Type + ")");       
                counter++;
            }
        }

        public void AddRow()
        {
            tableData.Rows.Add();
        }

        public void ProvideError(string text)
        {
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNewRecord)
                {
                    int ind = 0;
                    DataGridViewRow row = tableData.Rows[0];
                    foreach (Field field in currentTable.Fields)
                    {
                        if (field.AutoInc) continue;

                        if (row.Cells[ind].Value == null) field.Value = "";
                        else field.Value = row.Cells[ind].Value.ToString();
                       
                        ind++;
                    }

                    ShowTable.curTab = this.currentTable;
                    Program.CurrentDb.Insert(currentTable);

                    this.Close();
                }
                else
                {
                    int ind = 0;
                    DataGridViewRow row = tableData.Rows[0];
                    foreach (Field field in currentTable.Fields)
                    {
                        if (field.AutoInc) continue;

                        if (row.Cells[ind].Value == null) field.Value = "";
                        else field.Value = row.Cells[ind].Value.ToString();

                        ind++;
                    }

                    currentTable.PrimaryField.Value = keyValue;
                    ShowTable.curTab = this.currentTable;
                    Program.CurrentDb.Update(currentTable);

                    this.Close();
                }
            }
            catch (Exception)
            {
                ProvideError("Введенные данные не соответствуют типам данных полей");
            }
        }
    }
}
