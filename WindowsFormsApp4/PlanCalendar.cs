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
    public partial class PlanCalendar : Form
    {
        private Class1 SelectM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private InsertM InsertM;
        private DB db;
        string connectionString;
        public PlanCalendar()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            SelectM = new Class1(connectionString);
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);

            SelectM.LoadYears(guna2ComboBox2);
        }

        

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectM.DisplayPlanCalendar(dataGridView2, SelectM.GetGroupIdByName(guna2ComboBox2.SelectedItem.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddPlanCalendarcs addNewPenalt = new AddPlanCalendarcs(SelectM.GetGroupIdByName(guna2ComboBox2.SelectedItem.ToString()), guna2ComboBox2.SelectedItem.ToString());
            addNewPenalt.ShowDialog();
            this.Visible = true;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectM.LoadGroupsForYear(guna2ComboBox2, guna2ComboBox1.SelectedItem.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
