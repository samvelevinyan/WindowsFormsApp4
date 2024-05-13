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

namespace WindowsFormsApp4
{
    public partial class AddParent : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private DB db;


        string connectionString;

        private int sID;
        public AddParent(int studentID)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            sID = studentID;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InsertM.AddParentToStudent(sID, textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text, textBox4.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox6.Text);
                MessageBox.Show("Действие успешно выполнено!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Родитель не был добавлен по причине: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
