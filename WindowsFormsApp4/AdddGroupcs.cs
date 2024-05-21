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
    public partial class AdddGroupcs : Form
    {
        private InsertM InsertM;
        private DB db;
        private string connectionString;
        public AdddGroupcs()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
            InsertM = new InsertM(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertM.AddNewGroup(textBox1.Text, maskedTextBox1.Text);
        }
    }
}
