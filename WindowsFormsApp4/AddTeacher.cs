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
        public AddTeacher()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
            SelectM = new Class1(connectionString);
            UpdateMcs = new UpdateMcs(connectionString);
            DeleteM = new DeleteM(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertM.Teacher(textBox1.Text,textBox2.Text,textBox3.Text, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
        }
    }
}
