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

    public partial class AddWorkWithParent : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private InsertM InsertM;
        private DB db;
        string connectionString;
        public AddWorkWithParent()
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
                InsertM.WorkWithParent(Convert.ToInt32(comboBox9.SelectedValue), Convert.ToInt32(comboBox8.SelectedValue), comboBox10.SelectedItem.ToString(), textBox2.Text);
                MessageBox.Show("Действие успешно выполнено!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Запись не добавлена. Причина: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedValue != null)
            {
                int studentId = Convert.ToInt32(comboBox8.SelectedValue);
                SelectM.FillComboBoxWithParents(comboBox9, studentId);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboBox2.SelectedItem.ToString();
            //  dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);

            try
            {
                SelectM.FillComboBoxWithStudents(comboBox8, selectedGroup);
                // SelectM.FillComboBoxWithStudents(comboBox6, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox4, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox5, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
