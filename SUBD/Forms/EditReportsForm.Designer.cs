
namespace SUBD
{
    partial class editRecordsForm
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.tableData = new System.Windows.Forms.DataGridView();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.tableData)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 154);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(35, 13);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "label1";
            this.errorLabel.Visible = false;
            // 
            // tableData
            // 
            this.tableData.AllowUserToAddRows = false;
            this.tableData.AllowUserToDeleteRows = false;
            this.tableData.AllowUserToResizeColumns = false;
            this.tableData.AllowUserToResizeRows = false;
            this.tableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableData.Location = new System.Drawing.Point(12, 29);
            this.tableData.Name = "tableData";
            this.tableData.RowHeadersVisible = false;
            this.tableData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tableData.Size = new System.Drawing.Size(690, 111);
            this.tableData.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(627, 154);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // editRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(724, 185);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.tableData);
            this.Controls.Add(this.errorLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "editRecordsForm";
            this.Text = "editRecordsForm";
            ((System.ComponentModel.ISupportInitialize) (this.tableData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DataGridView tableData;
        private System.Windows.Forms.Button OKButton;
    }
}