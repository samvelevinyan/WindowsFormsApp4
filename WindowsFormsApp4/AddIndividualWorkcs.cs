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
    public partial class AddIndividualWorkcs : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private InsertM InsertM;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;
        int sid;
        int zid;
        public AddIndividualWorkcs(int studentid, int workid)
        {
            InitializeComponent();
            sid = studentid;
            zid = workid;
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.DisplayIndividual(dataGridView2, studentid);

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
                    MessageBox.Show($"Вы выбрали студента №{sid} и запись №{zid}");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {

                InsertM.Individual(sid, guna2DateTimePicker1.Value, guna2TextBox4.Text);
                SelectM.DisplayIndividual(dataGridView2, sid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateMcs.UpdateIndWorkinfo(zid, sid, guna2DateTimePicker1.Value, guna2TextBox4.Text);
                SelectM.DisplayIndividual(dataGridView2, sid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
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
