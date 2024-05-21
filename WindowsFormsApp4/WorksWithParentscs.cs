using Guna.UI2.WinForms;
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
    public partial class WorksWithParentscs : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private DB db;
        string connectionString;

        private int workid = 0;
        private int studentid;
        private int parentid;
        public WorksWithParentscs()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM.LoadYears(guna2ComboBox1);
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
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = guna2ComboBox2.SelectedItem.ToString();
            int studentId = Convert.ToInt32(guna2ComboBox3.SelectedValue);
            //  dataGridView1.DataSource = SelectM.GetInfoByGroup(selectedGroup);

            try
            {
                SelectM.FillComboBoxWithStudents(guna2ComboBox3, selectedGroup);



                // SelectM.FillComboBoxWithStudents(comboBox6, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox4, selectedGroup);
                // SelectM.FillComboBoxWithStudentsName(comboBox5, selectedGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedValue != null)
            {
                int studentId = Convert.ToInt32(guna2ComboBox3.SelectedValue);
                SelectM.FillComboBoxWithParents(guna2ComboBox4, studentId);

                SelectM.DisplayWorkWithParentInfo(dataGridView2, Convert.ToInt32(guna2ComboBox4.SelectedValue));
            }
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.DisplayWorkWithParentInfo(dataGridView2, Convert.ToInt32(guna2ComboBox4.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (workid <= 0)
            {
                MessageBox.Show("Выберите запись в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddWorkWithParent f2 = new AddWorkWithParent(workid, studentid, parentid); 

            f2.ShowDialog(); 
            this.Visible = true; 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

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
