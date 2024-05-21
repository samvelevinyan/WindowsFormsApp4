using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class AddStudent : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        private string connectionString;
        int studentid;

        public string gName;
        public AddStudent(string receivedData)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
          //  label7.Text = $"Добавить студента к группе: {receivedData}";
            DeleteM = new DeleteM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            gName = receivedData;

            dataGridView1.DataSource = SelectM.GetStudentsByGroup(gName);

        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string combobox;
            if (studentid < 1)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (guna2ComboBox2.SelectedIndex == -1)
            {
                combobox = "";
            }
            else
            {
                combobox = guna2ComboBox2.SelectedItem.ToString();
            }
            UpdateMcs.UpdateStudentInfos(studentid, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2DateTimePicker1.Value, combobox, guna2TextBox7.Text, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text);

            studentid = 0;
            dataGridView1.DataSource = SelectM.GetStudentsByGroup(gName);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                studentid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                MessageBox.Show("Вы выбрали студента под номером: " + studentid);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string combobox;
            if (guna2ComboBox2.SelectedIndex == -1)
            {
                combobox = "male";
            }
            else
            {
                combobox = guna2ComboBox2.SelectedItem.ToString();
            }

            try
            {
                int gID = SelectM.GetGroupIdByName(gName);
                InsertM.AddStudent(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2DateTimePicker1.Value, combobox, guna2TextBox7.Text, guna2TextBox6.Text, guna2TextBox4.Text, guna2TextBox5.Text, gID);
                MessageBox.Show("Студент добавлен", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка добавления студента: {ex.Message}");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (studentid < 1)
            {
                MessageBox.Show("Cтудент не выбран");
                return;
            }


            AddParent f2 = new AddParent(studentid);
            f2.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Вы точно хотите удалить студента под номером {studentid}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем, какая кнопка была нажата
            if (result == DialogResult.Yes)
            {

                DeleteM.RemoveStudent(studentid);
                dataGridView1.DataSource = SelectM.GetStudentsByGroup(gName);
            }
            else
            {
                // Ваш код для обработки нажатия "Нет", если необходимо
                // Например, можно ничего не делать или вывести сообщение
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
