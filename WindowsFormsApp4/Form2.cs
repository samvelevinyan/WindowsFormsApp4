using Guna.UI2.WinForms;
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
        private int studentid;
        private string gs = "";


        private string login;
             
        bool admin, moder, viewer;
        public Form2(bool admin, bool moder, bool verwer, string login)
        {

            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            // SelectM.LoadYears(comboBox2);
            SelectM.LoadYears(guna2ComboBox1);
            this.login = login;
            this.admin = admin;
            this.moder = moder;
            viewer = verwer;

            guna2ComboBox2.Visible = false;
            guna2Button1.Visible = false;
            label2.Visible = false;


            if (admin == false || moder == false)
            {
                guna2Button3.Enabled = false;
                guna2Button2.Enabled = false;
            }

        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    studentid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    MessageBox.Show("Вы выбрали студента под номером: " + studentid);
                }
            }
            // Убедитесь, что клик произошел по строке, а не по заголовку столбца
            
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                   // dataGridView1.CurrentRow.Selected = true;
                   // studentid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    gs = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MessageBox.Show("Вы выбрали группу под названием: " + gs);
                    SelectM.GetStudentsByGroup(dataGridView2, gs);
                }
            }
            
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedGroup = guna2ComboBox1.SelectedItem.ToString();
               // SelectM.LoadGroupsForYear(guna2ComboBox2, selectedGroup);
                SelectM.GetInfoByGroupByYear(dataGridView1, guna2ComboBox1.SelectedItem.ToString());
                gs = "";
                try
                {
                    
                    SelectM.GetStudentsByGroup(dataGridView2, dataGridView1.Rows[0].Cells[1].Value.ToString());
                }
                catch {
                    return;
                }

                // SelectM.GetInfoByGroup(dataGridView1, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = guna2ComboBox2.SelectedItem.ToString();
            //   dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
         // !  SelectM.GetInfoByGroup(dataGridView1, selectedGroup);
            //  dataGridView2.DataSource = SelectM.GetStudentsByGroup(selectedGroup);
            SelectM.GetStudentsByGroup(dataGridView2, selectedGroup);
            // dataGridView2.Columns["student_id"].Visible = false;

            // dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (gs == "")
            {
                MessageBox.Show("Выберите группу в табилце, кликнув по строке", "Студент не выбран!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           // string selectedGroup = guna2ComboBox2.SelectedItem.ToString();


            AddGroup addform = new AddGroup(gs, admin, moder, viewer, guna2ComboBox1.SelectedItem.ToString());
            addform.ShowDialog(); // Показать Form2
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (gs == "")
            {
                MessageBox.Show("Выберите группу в табилце, кликнув по строке", "Студент не выбран!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          //  string selectedGroup = guna2ComboBox2.SelectedItem.ToString();
            AddStudent f2 = new AddStudent(gs);
            f2.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Группа не выбрана", "Выберите группу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedGroup = guna2ComboBox2.SelectedItem.ToString();
            //  dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);
            SelectM.GetInfoByGroup(dataGridView1, selectedGroup);
            //   dataGridView2.DataSource = SelectM.GetStudentsByGroup(selectedGroup);
            SelectM.GetStudentsByGroup(dataGridView2, selectedGroup);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    studentid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    MessageBox.Show("Вы выбрали студента под номером: " + studentid);
                }
            }
            // Убедитесь, что клик произошел по строке, а не по заголовку столбца
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SelectM.LoadYears(guna2ComboBox1);
        }
    }



}
