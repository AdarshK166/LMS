using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LMS
{
    
    public partial class delt : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        public delt()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
        }

        private void dell_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(id3.Text);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "delete from bookdb where b_id ='" + id + "' ";
            int temp = cmd.ExecuteNonQuery();
            if (temp > 0)
            {
                id3.Text = null;
                MessageBox.Show("Record deleted successfully!");
            }
            else
            {
                MessageBox.Show("Record failed to delete!");

            }
            conn.Close();

        }
    }
}
