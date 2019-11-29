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
    public partial class Addf : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        int count;
        public Addf()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (bid.Text == "" || bname.Text == "" || auth.Text == "")
                {
                    MessageBox.Show("Fields cannot be left blank!");
                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(bname.Text.Length); i++)
                    {
                        if (!(bname.Text.All(char.IsLetter)))
                        {
                            count = 1;
                        }
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Enter only characters for name!");
                    }
                }
                string id1 = bid.Text;
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

                int id = Convert.ToInt32(bid.Text);
                string nm = bname.Text;
                string ad = auth.Text;
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "insert into bookdb (b_id,Book_nm,Book_author) values ('" + id + "','" + nm + "','" + ad + "')";
                int temp = cmd.ExecuteNonQuery();
                if (temp > 0)
                {
                    bid.Text = null;
                    bname.Text = null;
                    auth.Text = null;
                    MessageBox.Show("Record added successfully!");
                }
                else
                {
                    MessageBox.Show("Record failed to add!");

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
