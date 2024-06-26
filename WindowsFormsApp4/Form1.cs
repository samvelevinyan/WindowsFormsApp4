﻿using Guna.UI2.WinForms;
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

        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var login = guna2TextBox1.Text;
            var pass = guna2TextBox2.Text;

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
            {
                guna2MessageDialog1.Show("Логин или пароль введён неверно");
            }
             //   MessageBox.Show("Логин или пароль введён неверно");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
            
        }
    }
}
