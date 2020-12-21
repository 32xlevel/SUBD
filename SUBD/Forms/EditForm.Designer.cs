
namespace SUBD
{
    partial class editForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.editDataGridView = new System.Windows.Forms.DataGridView();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.editDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(564, 83);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(69, 21);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // editDataGridView
            // 
            this.editDataGridView.AllowUserToAddRows = false;
            this.editDataGridView.AllowUserToDeleteRows = false;
            this.editDataGridView.AllowUserToOrderColumns = true;
            this.editDataGridView.AllowUserToResizeColumns = false;
            this.editDataGridView.AllowUserToResizeRows = false;
            this.editDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editDataGridView.Location = new System.Drawing.Point(12, 12);
            this.editDataGridView.Name = "editDataGridView";
            this.editDataGridView.RowHeadersVisible = false;
            this.editDataGridView.Size = new System.Drawing.Size(621, 63);
            this.editDataGridView.TabIndex = 1;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 87);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(28, 13);
            this.errorLabel.TabIndex = 2;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(645, 116);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.editDataGridView);
            this.Controls.Add(this.okButton);
            this.Name = "editForm";
            this.Text = "editForm";
            ((System.ComponentModel.ISupportInitialize) (this.editDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.DataGridView editDataGridView;
        private System.Windows.Forms.Label errorLabel;
    }
}