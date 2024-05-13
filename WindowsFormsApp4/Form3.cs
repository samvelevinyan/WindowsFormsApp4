using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        private Class1 methods;
        private DB db;
        public string connectionString;
        string login2;
        
        public Form3(string login)
        {
            InitializeComponent();
            login2 = login;
            db = new DB();
            connectionString = db.connectionString;
            methods = new Class1(connectionString);

            PersonalData personalData = new PersonalData(connectionString);
            personalData.LoadUser(login);
            if (personalData.IsAdmin == false || personalData.IsViewer == false)
            {
                button6.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(login2); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorksWithParentscs f2 = new WorksWithParentscs(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void button3_Click(object sender, EventArgs e)
        {
            penalties f2 = new penalties(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IndividualWork f2 = new IndividualWork(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlanCalendar f2 = new PlanCalendar(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teachers f2 = new Teachers(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к ней
            this.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        


    }
}
