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
    public partial class AddIndividualWorkcs : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private InsertM InsertM;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        public AddIndividualWorkcs()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InsertM.Individual(Convert.ToInt32(comboBox3.SelectedValue), dateTimePicker1.Value, textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedYear = comboBox1.SelectedItem.ToString();
                SelectM.LoadGroupsForYear(comboBox2, selectedYear);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
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
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
