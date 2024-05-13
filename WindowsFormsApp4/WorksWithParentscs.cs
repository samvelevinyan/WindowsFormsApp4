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
    public partial class WorksWithParentscs : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        public WorksWithParentscs()
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
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboBox2.SelectedItem.ToString();
            int studentId = Convert.ToInt32(comboBox3.SelectedValue);
            //  dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);

            try
            {
                SelectM.FillComboBoxWithStudents(comboBox3, selectedGroup);
                SelectM.FillComboBoxWithStudents(comboBox5, selectedGroup);
                

                // SelectM.FillComboBoxWithStudents(comboBox6, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox4, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox5, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                int studentId = Convert.ToInt32(comboBox3.SelectedValue);
                SelectM.FillComboBoxWithParents(comboBox4, studentId);
                SelectM.FillComboBoxWithParents(comboBox6, studentId);
                SelectM.DisplayWorkWithParentInfo(dataGridView1, Convert.ToInt32(comboBox4.SelectedValue));
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.DisplayWorkWithParentInfo(dataGridView1, Convert.ToInt32(comboBox4.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
           
        }

        private void WorksWithParentscs_Load(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddWorkWithParent f2 = new AddWorkWithParent(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(comboBox5.SelectedValue);
            SelectM.FillComboBoxWithParents(comboBox6, studentId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.WorkWithParentType(comboBox7.SelectedItem.ToString(), Convert.ToInt32(comboBox6.SelectedValue));
                SelectM.DisplayWorkWithParentInfo(dataGridView1, Convert.ToInt32(comboBox4.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.WorkWithParentText(textBox1.Text, Convert.ToInt32(comboBox6.SelectedValue));
                SelectM.DisplayWorkWithParentInfo(dataGridView1, Convert.ToInt32(comboBox4.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
