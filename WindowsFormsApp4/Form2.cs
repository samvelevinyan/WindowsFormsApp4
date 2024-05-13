using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public string groupName = "none";

        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        public Form2(string login)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(comboBox2);


            PersonalData personalData = new PersonalData(connectionString);
            personalData.LoadUser(login);
           
            if (personalData.IsAdmin == false)
            {
                button19.Enabled = false;
                button10.Enabled = false;
                button20.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                string selectedGroup = comboBox2.SelectedItem.ToString();
                SelectM.LoadGroupsForYear(comboBox1, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }



        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(selectedGroup);
            
            
            try
            {
                SelectM.FillComboBoxWithStudents(comboBox3, selectedGroup);
                SelectM.FillComboBoxWithStudents(comboBox6, selectedGroup);
                SelectM.FillComboBoxWithStudentsName(comboBox4, selectedGroup);
                SelectM.FillComboBoxWithStudentsName(comboBox5, selectedGroup);
                SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
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
                SelectM.DisplayParentInfo(dataGridView3, studentId);
                SelectM.FillComboBoxWithParents(comboBox8, studentId);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Год не выбран", "Выберите год", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddGroup addform = new AddGroup();
            addform.ShowDialog(); // Показать Form2
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectM.LoadYears(comboBox2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.Starosta(comboBox4.SelectedItem.ToString(), SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.Fizorg(comboBox5.SelectedItem.ToString(), SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.note(textBox3.Text, SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.GroupYear(maskedTextBox1.Text, SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.GroupName(textBox4.Text, SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Группа не выбрана");
                return;
            }
            

            AddStudent f2 = new AddStudent(comboBox1.SelectedItem.ToString());
            f2.ShowDialog();
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show($"Вы точно хотите удалить студента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем, какая кнопка была нажата
            if (result == DialogResult.Yes)
            {
                int studentId = Convert.ToInt32(comboBox6.SelectedValue);
                DeleteM.RemoveStudent(studentId);
                string selectedGroup = comboBox1.SelectedItem.ToString();
                dataGridView2.DataSource = SelectM.GetStudentsByGroup(selectedGroup);
                SelectM.FillComboBoxWithStudents(comboBox6, selectedGroup);
            }
            else
            {
                // Ваш код для обработки нажатия "Нет", если необходимо
                // Например, можно ничего не делать или вывести сообщение
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentName(textBox2.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentSurname(textBox5.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentPatronymic(textBox6.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentInfoDOB(dateTimePicker1.Value, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentInfoGender(comboBox7.SelectedItem.ToString(), Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentInfoAddress(textBox7.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentInfoPhone(maskedTextBox2.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.StudentInfoNote(textBox8.Text, Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(comboBox1.SelectedItem.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Студент не выбран", "Выберите студента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddParent fp = new AddParent(Convert.ToInt32(comboBox6.SelectedValue));
            fp.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            UpdateMcs.ParentInfoFIO(textBox9.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string selectedParent = comboBox8.SelectedItem.ToString();
            DialogResult result = MessageBox.Show($"Вы точно хотите удалить родителя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем, какая кнопка была нажата
            if (result == DialogResult.Yes)
            {
                SelectM.FillComboBoxWithParents(comboBox8, Convert.ToInt32(comboBox3.SelectedValue));
                DeleteM.RemoveParentById(Convert.ToInt32(comboBox8.SelectedValue));
                SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
            }
            else
            {
                // Ваш код для обработки нажатия "Нет", если необходимо
                // Например, можно ничего не делать или вывести сообщение
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoRole(comboBox9.SelectedItem.ToString(), Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoAddress(textBox10.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoWorkPlace(textBox11.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoPosition(textBox12.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoWorkNumber(maskedTextBox3.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите родителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMcs.ParentInfoHomeNumber(maskedTextBox4.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

            UpdateMcs.ParentInfoNote(textBox13.Text, Convert.ToInt32(comboBox8.SelectedValue));
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string selectedGroup = comboBox8.SelectedItem.ToString();
            // Показываем MessageBox с кнопками "Да" и "Нет"
            DialogResult result = MessageBox.Show($"Вы точно хотите удалить группу {selectedGroup}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем, какая кнопка была нажата
            if (result == DialogResult.Yes)
            {
                // Ваш код для выполнения действия
                DeleteM.RemoveGroup(SelectM.GetGroupIdByName(comboBox1.SelectedItem.ToString()));
                SelectM.LoadGroupsForYear(comboBox1, selectedGroup);
            }
            else
            {
                // Ваш код для обработки нажатия "Нет", если необходимо
                // Например, можно ничего не делать или вывести сообщение
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Группа не выбрана", "Выберите группу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedGroup = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
            dataGridView2.DataSource = SelectM.GetStudentsByGroup(selectedGroup);
            SelectM.DisplayParentInfo(dataGridView3, Convert.ToInt32(comboBox3.SelectedValue));
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}
