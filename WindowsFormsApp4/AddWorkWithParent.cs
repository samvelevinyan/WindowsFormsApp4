using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{

    public partial class AddWorkWithParent : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private InsertM InsertM;
        private DB db;
        string connectionString;

        int workid;
        int studentid;
        int parentid;
        public AddWorkWithParent(int workid, int studentid, int parentid)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
          //  SelectM.LoadYears(comboBox1);
            this.parentid = parentid;
            this.studentid = studentid;
            this. workid = workid;
            SelectM.DisplayWorkWithParentInfo(dataGridView2, parentid);

        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (studentid < 1 || parentid < 1)
            {
                MessageBox.Show("Выберите запись в таблице!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                InsertM.WorkWithParent(parentid, studentid, guna2ComboBox1.SelectedItem.ToString(), guna2TextBox4.Text);
                SelectM.DisplayWorkWithParentInfo(dataGridView2, parentid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Запись не добавлена. Причина: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (workid < 1)
            {
                MessageBox.Show("Выберите запись в таблице!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string combo = "";
            if (guna2ComboBox1.SelectedIndex != -1)
            {
                combo = guna2ComboBox1.SelectedItem.ToString();
            }

            UpdateMcs.UpdateWorkWithParentsInfo(workid, combo, guna2TextBox4.Text);
            SelectM.DisplayWorkWithParentInfo(dataGridView2, parentid);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    workid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    parentid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value);
                    studentid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value);
                    MessageBox.Show($"Вы выбрали запись под номером {workid}, номер студента {studentid}, номер родителя {parentid}");
                }
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
