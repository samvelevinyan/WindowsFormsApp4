using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddStudent : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private DB db;
        private string connectionString;

        public string gName;
        public AddStudent(string receivedData)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            label7.Text = $"Добавить студента к группе: {receivedData}";
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            gName = receivedData;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int gID = SelectM.GetGroupIdByName(gName);
                InsertM.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, comboBox1.SelectedItem.ToString(), textBox5.Text, maskedTextBox1.Text, textBox4.Text, gID);
                MessageBox.Show("Студент добавлен", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка добавления студента: {ex.Message}");
            }
            
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
