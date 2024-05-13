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
    public partial class AddPlanCalendarcs : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private DB db;
        private string connectionString;
        public AddPlanCalendarcs()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString; 
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            SelectM.LoadYears(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertM.PlanCalendar(SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString()), dateTimePicker1.Value, dateTimePicker2.Value, comboBox3.SelectedItem.ToString(), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.LoadGroupsForYear(comboBox2, comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.FillComboBoxWithStudentsName(comboBox3, comboBox2.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
