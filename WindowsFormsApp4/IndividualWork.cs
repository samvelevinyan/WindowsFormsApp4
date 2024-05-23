using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class IndividualWork : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;

        int sid;
        int zid;
        public IndividualWork(bool isadmin, bool ismoderator, bool isviewer)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(guna2ComboBox1);

            if (isadmin == false || ismoderator == false)
            {
                guna2Button3.Enabled = false;

            }
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedGroup = guna2ComboBox1.SelectedItem.ToString();
                SelectM.LoadGroupsForYear(guna2ComboBox2, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = guna2ComboBox2.SelectedItem.ToString();

            try
            {
                SelectM.FillComboBoxWithStudents(guna2ComboBox3, selectedGroup);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedGroup = guna2ComboBox3.SelectedItem.ToString();
                SelectM.DisplayIndividual(dataGridView2, Convert.ToInt32(guna2ComboBox3.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    string sname = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    MessageBox.Show($"Вы выбрали студента {sname}");
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (sid <= 0)
            {
                MessageBox.Show($"Выберите студента в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddIndividualWorkcs addNewPenalt = new AddIndividualWorkcs(sid, zid);
            addNewPenalt.ShowDialog();
            this.Visible = true;
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
