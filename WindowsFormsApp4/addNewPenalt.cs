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
    public partial class addNewPenalt : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private InsertM InsertM;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;

        int zid;
        int sid;
        public addNewPenalt(int zid, int studentid)
        {
            InitializeComponent();
            db = new DB();
            this.zid = zid;
            sid = studentid;
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.DisplayPenalties(dataGridView2, studentid);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    zid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    sid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value);
                    string sname = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    MessageBox.Show($"Вы выбрали студента {sname}");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                InsertM.Penalties(sid, guna2DateTimePicker1.Value, guna2TextBox4.Text);
                SelectM.DisplayPenalties(dataGridView2, sid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdateMcs.UpdatePenaltinfo(zid, sid, guna2DateTimePicker1.Value, guna2TextBox4.Text);
            SelectM.DisplayPenalties(dataGridView2, sid);
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
