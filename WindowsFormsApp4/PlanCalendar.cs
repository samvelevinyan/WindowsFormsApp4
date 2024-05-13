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
    public partial class PlanCalendar : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private InsertM InsertM;
        private DB db;
        string connectionString;
        public PlanCalendar()
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
            AddPlanCalendarcs addNewPenalt = new AddPlanCalendarcs();
            addNewPenalt.ShowDialog();
            this.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectM.LoadGroupsForYear(comboBox2, comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.DisplayPlanCalendar(dataGridView1, SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString()));
                SelectM.FillComboBoxWithStudentsName(comboBox3, comboBox2.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlatDateStart(dateTimePicker1.Value, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlatDateEnd(dateTimePicker2.Value, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlanIspolnitel(comboBox3.SelectedItem.ToString(), groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PenaltDescr(textBox1.Text, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlanResult(textBox2.Text, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlanProtokol(textBox3.Text, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int groupID = SelectM.GetGroupIdByName(comboBox2.SelectedItem.ToString());
            UpdateMcs.PlanComment(textBox4.Text, groupID);
            SelectM.DisplayPlanCalendar(dataGridView1, groupID);
        }
    }
}
