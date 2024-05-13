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
    public partial class AddGroup : Form
    {
        // private Class1 SelectM;
        private InsertM InsertM;
        private DB db;
        private string connectionString;
        public AddGroup()
        {
            InitializeComponent();
            db = new DB();
            connectionString = db.connectionString;
         //   SelectM = new Class1("server=localhost;uid=root;pwd=root;database=fr;");
            InsertM = new InsertM(connectionString);
          //  SelectM.LoadYearsComboBox(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertM.AddNewGroup(textBox1.Text, maskedTextBox1.Text);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
