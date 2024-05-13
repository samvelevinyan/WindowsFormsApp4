using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class penalties : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        public penalties()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                string selectedGroup = comboBox2.SelectedItem.ToString();
                SelectM.FillComboBoxWithStudents(comboBox5, selectedGroup);
                SelectM.DisplayPenalties(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewPenalt addNewPenalt = new addNewPenalt();
            addNewPenalt.ShowDialog(); 
            this.Visible = true; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.PenaltDate(dateTimePicker1.Value, Convert.ToInt32(comboBox5.SelectedValue));
                SelectM.DisplayPenalties(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.PenaltDescr(textBox1.Text, Convert.ToInt32(comboBox5.SelectedValue));
                SelectM.DisplayPenalties(dataGridView1, Convert.ToInt32(comboBox3.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
