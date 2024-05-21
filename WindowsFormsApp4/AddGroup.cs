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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class AddGroup : Form
    {
        // private Class1 SelectM;
        private InsertM InsertM;
        private UpdateMcs UpdateMcs;
        private DeleteM DeleteM;
        private Class1 SelectM;
        private DB db;
        private string connectionString;
        string gn;

        bool admin, moder, viwer;
        public AddGroup(string groupname, bool admin, bool moder, bool viewer)
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            //   SelectM = new Class1("server=localhost;uid=root;pwd=root;database=fr;");
            InsertM = new InsertM(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
            SelectM = new Class1(connectionString);
            //  SelectM.LoadYearsComboBox(comboBox1);
            dataGridView2.DataSource = SelectM.GetInfoByGroup(groupname);
            SelectM.FillComboBoxWithStudentsName(guna2ComboBox1, groupname);
            SelectM.FillComboBoxWithStudentsName(guna2ComboBox2, groupname);
            gn = groupname;

            this.admin = admin;
            this.moder = moder;
            this.viwer = viewer;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string combo = "";
            string combo2 = "";

            if (guna2ComboBox1.SelectedIndex != -1)
            {
                combo = guna2ComboBox1.SelectedItem.ToString();
            }

            if (guna2ComboBox2.SelectedIndex != -1)
            {
                combo2 = guna2ComboBox2.SelectedItem.ToString();
            }

            UpdateMcs.UpdateGroupInfo(SelectM.GetGroupIdByName(gn), guna2TextBox1.Text, guna2TextBox2.Text, combo, combo2, guna2TextBox3.Text);
            dataGridView2.DataSource = SelectM.GetInfoByGroup(gn);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertM.AddNewGroup(guna2TextBox5.Text, guna2TextBox4.Text);
            dataGridView2.DataSource = SelectM.GetInfoByGroup(gn);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string selectedGroup = gn;
            DialogResult result = MessageBox.Show($"Вы точно хотите удалить группу {selectedGroup}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteM.RemoveGroup(SelectM.GetGroupIdByName(selectedGroup));
                dataGridView2.DataSource = SelectM.GetInfoByGroup(gn);
                MessageBox.Show("Группа успешно удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
