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
    public partial class AddTeacher : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private InsertM InsertM;
        private DB db;
        string connectionString;

        int tid;
        public AddTeacher(int tid)
        {
            InitializeComponent();
            db = new DB();
            this.tid = tid;
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
        }

       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertM.Teacher(guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text, guna2CheckBox1.Checked, guna2CheckBox2.Checked, guna2CheckBox3.Checked);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (tid <= 0)
            {
                MessageBox.Show("Выберите запись в таблице!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UpdateMcs.UpdateTeacherInfo(tid, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text, guna2CheckBox1.Checked, guna2CheckBox2.Checked, guna2CheckBox3.Checked);
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView2.CurrentRow.Selected = true;
                tid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                MessageBox.Show("Вы выбрали учителя под номером: " + tid);
            }
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
