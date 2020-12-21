
namespace SUBD
{
    partial class AddTable
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
            this.AddingTable = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableName = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AddingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // AddingTable
            // 
            this.AddingTable.AllowUserToAddRows = false;
            this.AddingTable.AllowUserToDeleteRows = false;
            this.AddingTable.AllowUserToResizeColumns = false;
            this.AddingTable.AllowUserToResizeRows = false;
            this.AddingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddingTable.Location = new System.Drawing.Point(183, 41);
            this.AddingTable.MultiSelect = false;
            this.AddingTable.Name = "AddingTable";
            this.AddingTable.RowHeadersVisible = false;
            this.AddingTable.Size = new System.Drawing.Size(438, 340);
            this.AddingTable.TabIndex = 0;
            this.AddingTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddingTable_CellEndEdit);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 354);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(102, 27);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
            // 
            // tableName
            // 
            this.tableName.Location = new System.Drawing.Point(12, 18);
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(165, 20);
            this.tableName.TabIndex = 4;
            this.tableName.Text = "Введите название таблицы";
            this.tableName.TextChanged += new System.EventHandler(this.tableName_TextChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(183, 18);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(442, 20);
            this.errorLabel.TabIndex = 5;
            this.errorLabel.Text = "errorLabel";
            this.errorLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить строку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Удалить строку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddTable
            // 
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(637, 393);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.tableName);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.AddingTable);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "AddTable";
            this.Text = "Добавить таблицу";
            ((System.ComponentModel.ISupportInitialize)(this.AddingTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.DataGridView AddingTable;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox tableName;
        private System.Windows.Forms.Label errorLabel;
    }
}