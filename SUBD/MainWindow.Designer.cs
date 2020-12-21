
namespace SUBD
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.tableTable = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTableButton = new System.Windows.Forms.Button();
            this.createQueryButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.tableTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableTable
            // 
            this.tableTable.AllowUserToAddRows = false;
            this.tableTable.AllowUserToDeleteRows = false;
            this.tableTable.AllowUserToResizeColumns = false;
            this.tableTable.AllowUserToResizeRows = false;
            this.tableTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTable.Location = new System.Drawing.Point(13, 49);
            this.tableTable.Margin = new System.Windows.Forms.Padding(4);
            this.tableTable.Name = "tableTable";
            this.tableTable.ReadOnly = true;
            this.tableTable.RowHeadersVisible = false;
            this.tableTable.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.tableTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableTable.Size = new System.Drawing.Size(619, 300);
            this.tableTable.TabIndex = 1;
            this.tableTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableTable_CellDoubleClick);
            this.tableTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableTable_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.открытьТаблицуToolStripMenuItem, this.changeTableMenuItem, this.удалитьТаблицуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 76);
            // 
            // открытьТаблицуToolStripMenuItem
            // 
            this.открытьТаблицуToolStripMenuItem.Name = "открытьТаблицуToolStripMenuItem";
            this.открытьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(240, 24);
            this.открытьТаблицуToolStripMenuItem.Text = "Открыть таблицу";
            this.открытьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.открытьТаблицуToolStripMenuItem_Click);
            // 
            // changeTableMenuItem
            // 
            this.changeTableMenuItem.Name = "changeTableMenuItem";
            this.changeTableMenuItem.Size = new System.Drawing.Size(240, 24);
            this.changeTableMenuItem.Text = "Редактировать таблицу";
            this.changeTableMenuItem.Click += new System.EventHandler(this.changeTableMenuItem_Click);
            // 
            // удалитьТаблицуToolStripMenuItem
            // 
            this.удалитьТаблицуToolStripMenuItem.Name = "удалитьТаблицуToolStripMenuItem";
            this.удалитьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(240, 24);
            this.удалитьТаблицуToolStripMenuItem.Text = "Удалить таблицу";
            this.удалитьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.удалитьТаблицуToolStripMenuItem_Click);
            // 
            // addTableButton
            // 
            this.addTableButton.BackColor = System.Drawing.Color.Azure;
            this.addTableButton.Location = new System.Drawing.Point(16, 357);
            this.addTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.addTableButton.Name = "addTableButton";
            this.addTableButton.Size = new System.Drawing.Size(165, 28);
            this.addTableButton.TabIndex = 2;
            this.addTableButton.Text = "Создать таблицу";
            this.addTableButton.UseVisualStyleBackColor = false;
            this.addTableButton.Click += new System.EventHandler(this.addTableButton_Click);
            // 
            // createQueryButton
            // 
            this.createQueryButton.BackColor = System.Drawing.Color.Azure;
            this.createQueryButton.Location = new System.Drawing.Point(189, 357);
            this.createQueryButton.Margin = new System.Windows.Forms.Padding(4);
            this.createQueryButton.Name = "createQueryButton";
            this.createQueryButton.Size = new System.Drawing.Size(167, 28);
            this.createQueryButton.TabIndex = 3;
            this.createQueryButton.Text = "Создать запрос";
            this.createQueryButton.UseVisualStyleBackColor = false;
            this.createQueryButton.Click += new System.EventHandler(this.createQueryButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 462);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать БД";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Открыть БД";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(645, 520);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createQueryButton);
            this.Controls.Add(this.addTableButton);
            this.Controls.Add(this.tableTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            ((System.ComponentModel.ISupportInitialize) (this.tableTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        #endregion

        private System.Windows.Forms.Button addTableButton;
        private System.Windows.Forms.Button createQueryButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTableMenuItem;
        public System.Windows.Forms.DataGridView tableTable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem удалитьТаблицуToolStripMenuItem;
    }
}