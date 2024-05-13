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
    public partial class Teachers : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        
        string connectionString;
        public Teachers()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.DisplayTeachers(dataGridView1);
            SelectM.FillComboBoxWithTeachers(comboBox1);

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTeacher f2 = new AddTeacher(); //Form2 - название формы, КОТОРАЯ откроется, f2 - переменная, краткое название формы для обращения к нейthis.Hide(); //второй вариант скрытия текущей формы
            f2.ShowDialog(); //запуск второй формы. Дальнейший код не сработает, пока не закроется форма
            this.Visible = true; //показать форму
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherFIO(textBox1.Text, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherLogin(textBox2.Text, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherPass(textBox3.Text, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherRoleAdmin(checkBox1.Checked, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherRoleModer(checkBox2.Checked, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateMcs.TeacherRoleViewer(checkBox3.Checked, (Convert.ToInt32(comboBox1.SelectedValue)));
            SelectM.DisplayTeachers(dataGridView1);
        }
    }
}
