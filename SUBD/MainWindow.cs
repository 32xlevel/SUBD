using System;
using System.Drawing;
using System.Windows.Forms;

namespace SUBD
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
            SetupDataGrid();
        }

        private void SetupDataGrid()
        {
            tableTable.ColumnCount = 1;
            tableTable.Columns[0].Name = "Имя";
        }

        private void CreateDb()
        {
            saveFileDialog1.Filter = "Database files(*.db)|*.db";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            
            var filename = saveFileDialog1.FileName;
            Program.CurrentDb = new Database(filename);
        }

        private void OpenDb()
        {
            openFileDialog1.Filter = "Database files(*.db)|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;                
            }
            
            var filename = openFileDialog1.FileName;
            Program.CurrentDb = new Database(filename);
            Program.Tables = Program.CurrentDb.Tables;
            PrintTables();
        }

        private void PrintTables()
        {
            tableTable.Rows.Clear();
            foreach (var item in Program.Tables)
            {
                tableTable.Rows.Add(item.Name);
            }
        }

        private void ProvideInfo(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.White;
            label1.Text = text;
        }

        private void ProvideError(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            label1.Text = text;
        }

        private void DeleteTable(Table table)
        {
            Program.CurrentDb.DropTable(table.Name);
            Program.Tables.Remove(table);
            PrintTables();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            PrintTables();
        }

        private void createQueryButton_Click(object sender, EventArgs e)
        {
            if (Program.CurrentDb != null)
            {
                CreateQuery form = new CreateQuery();
                form.ShowDialog();
            }
        }
        private void addTableButton_Click(object sender, EventArgs e)
        {
            if (Program.CurrentDb != null)
            {
                label1.Visible = false;
                var form = new AddTable();
                form.ShowDialog();
            }
        }

        private void tableTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var form = new ShowTable(Program.Tables[tableTable.SelectedRows[0].Index]);
            form.ShowDialog();
            label1.Visible = false;
        }

        private void changeTableMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EditTable(Program.Tables[tableTable.SelectedRows[0].Index]);
            label1.Text = tableTable.CurrentRow.Index.ToString();
            form.ShowDialog();
            label1.Visible = false;
        }

        private void открытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ShowTable form = new ShowTable(Program.Tables[tableTable.SelectedRows[0].Index]);
            form.ShowDialog();
            label1.Visible = false;
        }

        private void удалитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTable(Program.Tables[tableTable.SelectedRows[0].Index]);
        }

        private void tableTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = tableTable.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    tableTable.ClearSelection();
                    tableTable.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenDb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDb();
        }
    }
}
