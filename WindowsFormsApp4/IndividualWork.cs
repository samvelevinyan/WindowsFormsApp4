using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class IndividualWork : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        public IndividualWork()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddIndividualWorkcs addNewPenalt = new AddIndividualWorkcs();
            addNewPenalt.ShowDialog();
            this.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string selectedGroup = comboBox1.SelectedItem.ToString();
                SelectM.LoadGroupsForYear(comboBox2, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedGroup = comboBox2.SelectedItem.ToString();

            try
            {
                SelectM.FillComboBoxWithStudents(comboBox3, selectedGroup);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string selectedGroup = comboBox2.SelectedItem.ToString();
                SelectM.FillComboBoxWithStudents(comboBox5, selectedGroup);
                SelectM.DisplayIndividual(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.IndividualDate(dateTimePicker1.Value, Convert.ToInt32(comboBox5.SelectedValue));
                SelectM.DisplayIndividual(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.IndividualDescr(textBox1.Text, Convert.ToInt32(comboBox5.SelectedValue));
                SelectM.DisplayIndividual(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
