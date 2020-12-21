
namespace SUBD
{
    partial class CreateQuery
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
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.fieldsListBox = new System.Windows.Forms.ListBox();
            this.removeChosenFieldButton = new System.Windows.Forms.Button();
            this.chooseFilledButton = new System.Windows.Forms.Button();
            this.chosenFieldsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showQueryButton = new System.Windows.Forms.Button();
            this.referenceFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.chosenFieldComboBox = new System.Windows.Forms.ComboBox();
            this.conditionTextBox = new System.Windows.Forms.TextBox();
            this.operatorsComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.conditionsListBox = new System.Windows.Forms.ListBox();
            this.delteConditionButton = new System.Windows.Forms.Button();
            this.ANDradioButton = new System.Windows.Forms.RadioButton();
            this.ORradioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(23, 34);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(145, 21);
            this.tablesComboBox.TabIndex = 0;
            this.tablesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Enabled = false;
            this.fieldsListBox.FormattingEnabled = true;
            this.fieldsListBox.Location = new System.Drawing.Point(23, 92);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Size = new System.Drawing.Size(145, 108);
            this.fieldsListBox.TabIndex = 7;
            // 
            // removeChosenFieldButton
            // 
            this.removeChosenFieldButton.Enabled = false;
            this.removeChosenFieldButton.Location = new System.Drawing.Point(180, 151);
            this.removeChosenFieldButton.Name = "removeChosenFieldButton";
            this.removeChosenFieldButton.Size = new System.Drawing.Size(76, 48);
            this.removeChosenFieldButton.TabIndex = 10;
            this.removeChosenFieldButton.Text = "Удалить выбранное поле";
            this.removeChosenFieldButton.UseVisualStyleBackColor = true;
            this.removeChosenFieldButton.Click += new System.EventHandler(this.deleteFilledButton_Click);
            // 
            // chooseFilledButton
            // 
            this.chooseFilledButton.Enabled = false;
            this.chooseFilledButton.Location = new System.Drawing.Point(180, 92);
            this.chooseFilledButton.Name = "chooseFilledButton";
            this.chooseFilledButton.Size = new System.Drawing.Size(76, 48);
            this.chooseFilledButton.TabIndex = 9;
            this.chooseFilledButton.Text = "Выбрать поле";
            this.chooseFilledButton.UseVisualStyleBackColor = true;
            this.chooseFilledButton.Click += new System.EventHandler(this.chooseFilledButton_Click);
            // 
            // chosenFieldsListBox
            // 
            this.chosenFieldsListBox.Enabled = false;
            this.chosenFieldsListBox.FormattingEnabled = true;
            this.chosenFieldsListBox.Location = new System.Drawing.Point(270, 92);
            this.chosenFieldsListBox.Name = "chosenFieldsListBox";
            this.chosenFieldsListBox.Size = new System.Drawing.Size(145, 108);
            this.chosenFieldsListBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите поля:";
            // 
            // showQueryButton
            // 
            this.showQueryButton.Enabled = false;
            this.showQueryButton.Location = new System.Drawing.Point(160, 426);
            this.showQueryButton.Name = "showQueryButton";
            this.showQueryButton.Size = new System.Drawing.Size(127, 23);
            this.showQueryButton.TabIndex = 12;
            this.showQueryButton.Text = "Показать результат";
            this.showQueryButton.UseVisualStyleBackColor = true;
            this.showQueryButton.Click += new System.EventHandler(this.goNext_Click);
            // 
            // referenceFieldCheckBox
            // 
            this.referenceFieldCheckBox.AutoSize = true;
            this.referenceFieldCheckBox.Enabled = false;
            this.referenceFieldCheckBox.ForeColor = System.Drawing.Color.White;
            this.referenceFieldCheckBox.Location = new System.Drawing.Point(236, 211);
            this.referenceFieldCheckBox.Name = "referenceFieldCheckBox";
            this.referenceFieldCheckBox.Size = new System.Drawing.Size(163, 17);
            this.referenceFieldCheckBox.TabIndex = 13;
            this.referenceFieldCheckBox.Text = "Поля из связанных таблиц\r\n";
            this.referenceFieldCheckBox.UseVisualStyleBackColor = true;
            // 
            // chosenFieldComboBox
            // 
            this.chosenFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chosenFieldComboBox.Enabled = false;
            this.chosenFieldComboBox.FormattingEnabled = true;
            this.chosenFieldComboBox.Location = new System.Drawing.Point(24, 239);
            this.chosenFieldComboBox.Name = "chosenFieldComboBox";
            this.chosenFieldComboBox.Size = new System.Drawing.Size(144, 21);
            this.chosenFieldComboBox.TabIndex = 14;
            // 
            // conditionTextBox
            // 
            this.conditionTextBox.Enabled = false;
            this.conditionTextBox.Location = new System.Drawing.Point(244, 239);
            this.conditionTextBox.Name = "conditionTextBox";
            this.conditionTextBox.Size = new System.Drawing.Size(172, 20);
            this.conditionTextBox.TabIndex = 15;
            // 
            // operatorsComboBox
            // 
            this.operatorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorsComboBox.Enabled = false;
            this.operatorsComboBox.FormattingEnabled = true;
            this.operatorsComboBox.Location = new System.Drawing.Point(184, 239);
            this.operatorsComboBox.Name = "operatorsComboBox";
            this.operatorsComboBox.Size = new System.Drawing.Size(46, 21);
            this.operatorsComboBox.TabIndex = 16;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(24, 273);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(114, 23);
            this.addButton.TabIndex = 17;
            this.addButton.Text = "Добавить условие";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Укажите условие:";
            // 
            // conditionsListBox
            // 
            this.conditionsListBox.Enabled = false;
            this.conditionsListBox.FormattingEnabled = true;
            this.conditionsListBox.Location = new System.Drawing.Point(24, 302);
            this.conditionsListBox.Name = "conditionsListBox";
            this.conditionsListBox.Size = new System.Drawing.Size(392, 108);
            this.conditionsListBox.TabIndex = 19;
            // 
            // delteConditionButton
            // 
            this.delteConditionButton.Enabled = false;
            this.delteConditionButton.Location = new System.Drawing.Point(302, 273);
            this.delteConditionButton.Name = "delteConditionButton";
            this.delteConditionButton.Size = new System.Drawing.Size(113, 23);
            this.delteConditionButton.TabIndex = 20;
            this.delteConditionButton.Text = "Очистить условия";
            this.delteConditionButton.UseVisualStyleBackColor = true;
            this.delteConditionButton.Click += new System.EventHandler(this.deleteConditionButton_Click);
            // 
            // ANDradioButton
            // 
            this.ANDradioButton.AutoSize = true;
            this.ANDradioButton.Enabled = false;
            this.ANDradioButton.ForeColor = System.Drawing.Color.White;
            this.ANDradioButton.Location = new System.Drawing.Point(210, 263);
            this.ANDradioButton.Name = "ANDradioButton";
            this.ANDradioButton.Size = new System.Drawing.Size(48, 17);
            this.ANDradioButton.TabIndex = 21;
            this.ANDradioButton.TabStop = true;
            this.ANDradioButton.Text = "AND";
            this.ANDradioButton.UseVisualStyleBackColor = true;
            // 
            // ORradioButton
            // 
            this.ORradioButton.AutoSize = true;
            this.ORradioButton.Enabled = false;
            this.ORradioButton.ForeColor = System.Drawing.Color.White;
            this.ORradioButton.Location = new System.Drawing.Point(160, 263);
            this.ORradioButton.Name = "ORradioButton";
            this.ORradioButton.Size = new System.Drawing.Size(41, 17);
            this.ORradioButton.TabIndex = 22;
            this.ORradioButton.TabStop = true;
            this.ORradioButton.Text = "OR";
            this.ORradioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(315, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Выбранные поля:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Выберите таблицу:";
            // 
            // CreateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(439, 458);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ORradioButton);
            this.Controls.Add(this.ANDradioButton);
            this.Controls.Add(this.delteConditionButton);
            this.Controls.Add(this.conditionsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.operatorsComboBox);
            this.Controls.Add(this.conditionTextBox);
            this.Controls.Add(this.chosenFieldComboBox);
            this.Controls.Add(this.referenceFieldCheckBox);
            this.Controls.Add(this.showQueryButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeChosenFieldButton);
            this.Controls.Add(this.chooseFilledButton);
            this.Controls.Add(this.chosenFieldsListBox);
            this.Controls.Add(this.fieldsListBox);
            this.Controls.Add(this.tablesComboBox);
            this.Name = "CreateQuery";
            this.Text = "Создание запроса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.ListBox fieldsListBox;
        private System.Windows.Forms.Button removeChosenFieldButton;
        private System.Windows.Forms.Button chooseFilledButton;
        private System.Windows.Forms.ListBox chosenFieldsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button showQueryButton;
        private System.Windows.Forms.CheckBox referenceFieldCheckBox;
        private System.Windows.Forms.ComboBox chosenFieldComboBox;
        private System.Windows.Forms.TextBox conditionTextBox;
        private System.Windows.Forms.ComboBox operatorsComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox conditionsListBox;
        private System.Windows.Forms.Button delteConditionButton;
        private System.Windows.Forms.RadioButton ANDradioButton;
        private System.Windows.Forms.RadioButton ORradioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}