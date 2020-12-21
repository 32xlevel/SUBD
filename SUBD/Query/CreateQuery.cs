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
    public partial class CreateQuery : Form
    {
        private Table _currentTable;
        private static List<Field> _chosenFields = new List<Field>();
        private static string _conditions;

        public CreateQuery()
        {
            InitializeComponent();
            FillTableCombobox();
            FillOperators();
            ANDradioButton.Checked = true;
        }

        private Field SearchFieldWithName(string name)
        {
            return _chosenFields.Find(field => field.Name == name);
        }

        private void FillChosenFields()
        {
            chosenFieldComboBox.Items.Clear();

            if (_chosenFields.Count > 0)
            {
                chosenFieldComboBox.Text = _chosenFields[0].Name;
            }

            _chosenFields.ForEach(field => { chosenFieldComboBox.Items.Add(field.Name); });
        }

        private void FillOperators()
        {
            object[] boolOperators = {"=", "!=", "<", ">", "<=", ">="};
            operatorsComboBox.Items.AddRange(boolOperators);
            operatorsComboBox.Text = @"=";
        }

        private void FillTableCombobox()
        {
            Program.Tables.ForEach(table => { tablesComboBox.Items.Add(table.Name); });
        }

        private void FillAllFields()
        {
            fieldsListBox.Items.Clear();

            _currentTable.Fields.ForEach(field => { fieldsListBox.Items.Add(field.Name); });
        }

        private string CreateCompleteQuery()
        {
            string query = "";

            foreach (var item in conditionsListBox.Items)
            {
                query += $" {item}";
            }

            return query;
        }

        private void PaintNewCondition()
        {
            Field currentField = SearchFieldWithName(chosenFieldComboBox.Text);
            string item = "";
            string condition = string.IsNullOrEmpty(conditionTextBox.Text) ? "NULL" : conditionTextBox.Text;

            if (conditionsListBox.Items.Count > 0)
            {
                item = ANDradioButton.Checked ? " AND " : " OR ";
            }

            item += $"{_currentTable.Name}.{currentField.Name}{operatorsComboBox.Text}";
            item += currentField.Type == "TEXT" ? $" '{condition}' " : condition;

            conditionsListBox.Items.Add(item);
        }

        private void EnableIfTableChoice()
        {
            chooseFilledButton.Enabled = true;
            removeChosenFieldButton.Enabled = true;
            referenceFieldCheckBox.Enabled = true;
            fieldsListBox.Enabled = true;
            chosenFieldsListBox.Enabled = true;
        }

        private void EnableIfFieldSelected()
        {
            chosenFieldComboBox.Enabled = true;
            operatorsComboBox.Enabled = true;
            conditionsListBox.Enabled = true;
            conditionTextBox.Enabled = true;
            addButton.Enabled = true;
            removeChosenFieldButton.Enabled = true;
            ANDradioButton.Enabled = true;
            ORradioButton.Enabled = true;
            delteConditionButton.Enabled = true;
            showQueryButton.Enabled = true;
        }

        private void DisableIfFieldsNotSelected()
        {
            chosenFieldComboBox.Enabled = false;
            operatorsComboBox.Enabled = false;
            conditionsListBox.Enabled = false;
            conditionTextBox.Enabled = false;
            addButton.Enabled = false;
            removeChosenFieldButton.Enabled = false;
            ANDradioButton.Enabled = false;
            ORradioButton.Enabled = false;
            delteConditionButton.Enabled = false;
            showQueryButton.Enabled = false;
        }

        private void ClearAll()
        {
            _chosenFields = new List<Field>();
            _conditions = "";
            fieldsListBox.Items.Clear();
            chosenFieldsListBox.Items.Clear();
            conditionsListBox.Items.Clear();
            chosenFieldComboBox.Items.Clear();
        }

        private void AddSelectedField(string name)
        {
            _chosenFields.Add(_currentTable.Fields.Find(p => p.Name == name));
        }

        private void DeleteSelectedField(string name)
        {
            _chosenFields.Remove(_currentTable.Fields.Find(p => p.Name == name));
        }

        private void ReplaceField()
        {
            if (fieldsListBox.SelectedItem == null)
            {
                return;
            }
            
            chosenFieldsListBox.Items.Add(fieldsListBox.SelectedItem);
            AddSelectedField(fieldsListBox.SelectedItem.ToString());
            fieldsListBox.Items.Remove(fieldsListBox.SelectedItem);
            
            if (fieldsListBox.Items.Count > 0)
            {
                fieldsListBox.SelectedItem = fieldsListBox.Items[0];
            }
        }

        private void RemoveChosenField()
        {
            if (chosenFieldsListBox.SelectedItem == null)
            {
                return;
            }
            
            fieldsListBox.Items.Add(chosenFieldsListBox.SelectedItem);
            DeleteSelectedField(chosenFieldsListBox.SelectedItem.ToString());
            chosenFieldsListBox.Items.Remove(chosenFieldsListBox.SelectedItem);
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            DisableIfFieldsNotSelected();
            EnableIfTableChoice();
            _currentTable = Program.Tables.Find(table => table.Name == tablesComboBox.Text);
            FillAllFields();
        }

        private void chooseFilledButton_Click(object sender, EventArgs e)
        {
            ReplaceField();
            
            if (chosenFieldsListBox.Items.Count > 0)
            {
                EnableIfFieldSelected();
            }

            FillChosenFields();
        }

        private void goNext_Click(object sender, EventArgs e)
        {
            if (conditionsListBox.Items.Count > 0)
            {
                _conditions = CreateCompleteQuery();
            }

            ShowQuery form = new ShowQuery(_currentTable, _chosenFields, referenceFieldCheckBox.Checked, _conditions);
            form.ShowDialog();
        }

        private void deleteFilledButton_Click(object sender, EventArgs e)
        {
            RemoveChosenField();

            if (chosenFieldsListBox.Items.Count > 0)
            {
                EnableIfFieldSelected();
            }
            else
            {
                DisableIfFieldsNotSelected();
            }

            FillChosenFields();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (chosenFieldComboBox.Text != null && operatorsComboBox.Text != null)
            {
                PaintNewCondition();
            }
        }

        private void deleteConditionButton_Click(object sender, EventArgs e)
        {
            if (chosenFieldComboBox.Text != null && operatorsComboBox.Text != null && conditionsListBox.Items.Count > 0)
            {
                conditionsListBox.Items.RemoveAt(conditionsListBox.Items.Count - 1);
            }
        }
    }
}