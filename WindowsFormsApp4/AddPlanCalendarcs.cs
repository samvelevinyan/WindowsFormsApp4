using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddPlanCalendarcs : Form
    {
        private InsertM InsertM;
        private Class1 SelectM;
        private UpdateMcs UpdateM;
        private DB db;
        private string connectionString;
        int gid;
        int sid;
        int zid;
        public AddPlanCalendarcs(int groupid, string groupname)
        {
            InitializeComponent();
            db = new DB();
            gid = groupid;
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
            UpdateM = new UpdateMcs(connectionString);
            SelectM = new Class1(connectionString);

            SelectM.DisplayPlanCalendar(dataGridView2, gid);
            SelectM.FillComboBoxWithStudentsName(guna2ComboBox2, groupname);
          

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    sid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value);
                    zid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    string gnamee = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    MessageBox.Show($"Вы выбрали группу {gnamee}");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string combo2 = "";


            if (guna2ComboBox2.SelectedIndex != -1)
            {
                combo2 = guna2ComboBox2.SelectedItem.ToString();
            }
            InsertM.PlanCalendar(gid, guna2DateTimePicker1.Value, guna2DateTimePicker2.Value, combo2, guna2TextBox7.Text, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text);
            SelectM.DisplayPlanCalendar(dataGridView2, gid);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (sid <= 0)
            {
                MessageBox.Show("Выберите группу в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string combo = "";


            if (guna2ComboBox2.SelectedIndex != -1)
            {
                combo = guna2ComboBox2.SelectedItem.ToString();
            }

            UpdateM.UpdatePlanCalendar(zid, guna2DateTimePicker1.Value, guna2DateTimePicker2.Value, combo, guna2TextBox7.Text, guna2TextBox6.Text, guna2TextBox5.Text, guna2TextBox4.Text);
            SelectM.DisplayPlanCalendar(dataGridView2, gid);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
