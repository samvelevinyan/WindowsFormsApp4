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
    public partial class Form1 : Form
    {
        private DB db;
        string connectionString;
        public Form1()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var login = textBox1.Text;
           var pass = textBox2.Text;
            
            DB db = new DB();

            PersonalData personalData = new PersonalData(connectionString);
            personalData.LoadUser(login);

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
           
            string query = $"SELECT username, password FROM teachers WHERE username = '{login}' AND password = '{pass}'";
            
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
               
                Form3 f3 = new Form3(login); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
                this.Hide(); //второй вариант скрытия текущей формы
                f3.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
                this.Visible = true; //показать форму
            }
            else
                MessageBox.Show("Логин или пароль введён неверно");

        }
    }
}
