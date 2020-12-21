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
    public partial class ShowQuery : Form
    {
        private List<List<string>> _currentData;
        private List<Field> _fields;
        public ShowQuery(Table table, List<Field> fields, bool reference, string condition = "")
        {
            InitializeComponent();
            FillDataGridColumns(fields);
            FillDataInDataGrid(table, fields, reference, condition);
        }

        private void FillDataGridColumns(IReadOnlyList<Field> fields)
        {
            showQueryDataGrid.ColumnCount = fields.Count;
            
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].PrimaryKey)
                {
                    showQueryDataGrid.Columns[i].Name = "$ ";
                }
                showQueryDataGrid.Columns[i].Name += $"{fields[i].Name} ({fields[i].Type})";
            }
        }

        private void FillDataInDataGrid(Table table, List<Field> fields, bool reference, string condition = "")
        {
            showQueryDataGrid.Rows.Clear();
            List<List<string>> data;

            if (table.Fields.Count == fields.Count && string.IsNullOrEmpty(condition))
            {
                data = Program.CurrentDb.Select(table, reference);
            }

            if (table.Fields.Count == fields.Count && !string.IsNullOrEmpty(condition))
            {
                data = Program.CurrentDb.Select(table, condition, reference);
            }
            else if (string.IsNullOrEmpty(condition))
            {
                data = Program.CurrentDb.Select(table, fields, reference);
            }
            else
            {
                data = Program.CurrentDb.Select(table, fields, condition, reference);
            }

            if (reference)
            {
                showQueryDataGrid.Columns.Add("Связанная таблица", "Связанная таблица");
            }
            showQueryDataGrid.ColumnCount = data.Count > 0 ? data[0].Count : 0;

            for (int i = 0; i < data.Count; i++)
            {
                AddRow();
                for (int j = 0; j < data[i].Count; j++)
                {
                    showQueryDataGrid.Rows[i].Cells[j].Value = data[i][j];
                }
            }

            _fields = fields; 
            _currentData = data;
            _currentData.Insert(0, FieldHeaders(_fields));
        }

        private static List<string> FieldHeaders(List<Field> fields)
        {
            return fields.Select(item => item.Name).ToList();
        }

        private void ExportToWord()
        {
            saveFileDialog1.Filter = "MS Word(*.doc)|*.docx";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            
            string filename = saveFileDialog1.FileName;
            
            Reports.WriteWord(filename, _currentData);
        }

        private void ExportToExcel()
        {
            saveFileDialog1.Filter = "MS Excel(*.xls)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            
            Reports.WriteExcel(filename, _currentData);
        }

        private void AddRow()
        {
            showQueryDataGrid.Rows.Add();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToWordButton_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
