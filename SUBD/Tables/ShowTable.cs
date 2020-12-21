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
    public partial class ShowTable : Form
    {
        public static Table curTab;
        public static List<List<string>> data;
        public ShowTable(Table curTab)
        {
            InitializeComponent();
            ShowTable.curTab = curTab;
            fillDataGridColumns(curTab);
            recordInDataGrid(curTab);
        }

        private void UpdateDataButton_Click(object sender, EventArgs e)
        {
            if (tableData.Rows.Count > 0)
            {
                editRecordsForm form = new editRecordsForm(curTab, ShowTable.data[tableData.SelectedRows[0].Index],
                    tableData.SelectedRows[0].Cells[GetIndexOfPrimaryKey()].Value.ToString());
                form.ShowDialog();
            }
        }
        private void ViewTable_Activated(object sender, EventArgs e)
        {
            tableData.Rows.Clear();
            recordInDataGrid(ShowTable.curTab);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveLineButton_Click(object sender, EventArgs e)
        {
            if (tableData.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in tableData.SelectedRows)
                {
                    string value = row.Cells[GetIndexOfPrimaryKey()].Value.ToString();
                    curTab.PrimaryField.Value = value;
                    tableData.Rows.Remove(row);
                    Program.CurrentDb.Delete(curTab);
                }
            }
        }
        private void AddDataButton_Click(object sender, EventArgs e)
        {
            editRecordsForm form = new editRecordsForm(curTab);
            form.ShowDialog();
        }
        public void AddRow()
        {
            tableData.Rows.Add();
        }
        public void fillDataGridColumns(Table table)
        {
            tableData.ColumnCount = table.Fields.Count;
            for (int i = 0; i < table.Fields.Count; i++)
            {
                if (table.Fields[i].PrimaryKey) 
                    tableData.Columns[i].Name = "$ ";
                tableData.Columns[i].Name += table.Fields[i].Name + " (" + table.Fields[i].Type + ")";           
            }
        }

        public void recordInDataGrid(Table table)
        {
            List<List<String>> data = Program.CurrentDb.Select(table);
            ShowTable.data = data;
            for (int i = 0; i < data.Count; i++)
            {
                AddRow();
                for (int j = 0; j < tableData.Columns.Count; j++)
                {
                    tableData.Rows[i].Cells[j].Value = data[i][j].ToString();
                }
            }
        }

        private int GetIndexOfPrimaryKey()
        {
            Field primKey = curTab.PrimaryField;
            int index = curTab.Fields.FindIndex(e => e.Name == primKey.Name);
            return index;
        }
       
    }
}
