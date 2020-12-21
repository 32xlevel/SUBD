
namespace SUBD
{
    partial class ShowQuery
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
            this.showQueryDataGrid = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.exportToWordButton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showQueryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showQueryDataGrid
            // 
            this.showQueryDataGrid.AllowUserToAddRows = false;
            this.showQueryDataGrid.AllowUserToDeleteRows = false;
            this.showQueryDataGrid.AllowUserToResizeColumns = false;
            this.showQueryDataGrid.AllowUserToResizeRows = false;
            this.showQueryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showQueryDataGrid.Location = new System.Drawing.Point(162, 36);
            this.showQueryDataGrid.Name = "showQueryDataGrid";
            this.showQueryDataGrid.ReadOnly = true;
            this.showQueryDataGrid.Size = new System.Drawing.Size(576, 351);
            this.showQueryDataGrid.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 360);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(92, 27);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // exportToWordButton
            // 
            this.exportToWordButton.Location = new System.Drawing.Point(15, 62);
            this.exportToWordButton.Name = "exportToWordButton";
            this.exportToWordButton.Size = new System.Drawing.Size(141, 27);
            this.exportToWordButton.TabIndex = 2;
            this.exportToWordButton.Text = "Выгрузить в MS Word";
            this.exportToWordButton.UseVisualStyleBackColor = true;
            this.exportToWordButton.Click += new System.EventHandler(this.exportToWordButton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Location = new System.Drawing.Point(12, 108);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(144, 27);
            this.exportToExcelButton.TabIndex = 3;
            this.exportToExcelButton.Text = "Выгрузить в MS Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(368, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Результат запроса:";
            // 
            // ShowQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(756, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.exportToWordButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.showQueryDataGrid);
            this.Name = "ShowQuery";
            this.Text = "Результат запроса";
            ((System.ComponentModel.ISupportInitialize)(this.showQueryDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView showQueryDataGrid;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button exportToWordButton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
    }
}