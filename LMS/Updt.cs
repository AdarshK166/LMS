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
    public partial class Updt : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        int count;
        public Updt()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (bid1.Text == "" || bname2.Text == "")
            {
                MessageBox.Show("Fields cannot be left blank!");
            }
            else
            {
                for (int i = 0; i < Convert.ToInt32(bname2.Text.Length); i++)
                {
                    if (!(bname2.Text.All(char.IsLetter)))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    MessageBox.Show("Enter only characters for name!");
                }
            }
            string id1 = bid1.Text;
            foreach (char c in id1)
            {
                if (!(char.IsDigit(c)))
                {
                    count = 1;
                }
            }
            if (count == 1)
            {
                MessageBox.Show("Enter only digits for ID!");
            }

            string nm = bname2.Text;
            int id = Convert.ToInt32(bid1.Text);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE bookdb SET Book_nm='" + nm + "' WHERE b_id='" + id + "'";
            int temp = cmd.ExecuteNonQuery();
            if (temp > 0)
            {
                bid1.Text = null;
                bname2.Text = null;
                MessageBox.Show("Record updated successfully!");
            }
            else
            {
                MessageBox.Show("Record failed to update!");
            }
            conn.Close();

        }
    }
}
