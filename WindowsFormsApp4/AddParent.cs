using MySql.Data.MySqlClient;
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
    public partial class AddParent : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;


        string connectionString;

        private int sID;
        private int parentid;
        public AddParent(int studentID)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            sID = studentID;
            SelectM.DisplayParentInfo(dataGridView1, studentID);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                parentid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                MessageBox.Show("Вы выбрали родителя под номером: " + parentid);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string combo2 = "";
            if (guna2ComboBox2.SelectedIndex != -1)
            {
                combo2 = guna2ComboBox2.SelectedItem.ToString();
            }

            try
            {
                InsertM.AddParentToStudent(sID, guna2TextBox1.Text, combo2, guna2TextBox3.Text, guna2TextBox7.Text, guna2TextBox2.Text, guna2TextBox8.Text, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text);
                SelectM.DisplayParentInfo(dataGridView1, sID);
                MessageBox.Show("Родитель успешно добавлен!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Родитель не был добавлен по причине: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string combo = "";


            if (guna2ComboBox2.SelectedIndex != -1)
            {
                combo = guna2ComboBox2.SelectedItem.ToString();
            }

            if (parentid < 1)
            {
                MessageBox.Show($"Выберите родителя в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateMcs.UpdateParentInfo(parentid, guna2TextBox1.Text, combo, guna2TextBox3.Text, guna2TextBox7.Text, guna2TextBox2.Text, guna2TextBox8.Text, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text);
            SelectM.DisplayParentInfo(dataGridView1, sID);
        }

        
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (parentid < 1)
            {
                MessageBox.Show($"Выберите родителя в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Вы точно хотите удалить родителя под номером {parentid}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем, какая кнопка была нажата
            if (result == DialogResult.Yes)
            {
                DeleteM.RemoveParentById(parentid);
                SelectM.DisplayParentInfo(dataGridView1, sID);
            }
            else
            {
                // Ваш код для обработки нажатия "Нет", если необходимо
                // Например, можно ничего не делать или вывести сообщение
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
