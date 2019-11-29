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
    public partial class LMS : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        public LMS()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            choice.Items.Add("Admin");
            choice.Items.Add("Member");
            MS.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                if (choice.SelectedItem.ToString() == "Admin")
                {
                   
                    if (uname.Text == "" || pass.Text == "")
                    {
                        MessageBox.Show("Fields cannot be left blank.");
                    }
                    else
                    {
                        if (uname.Text != "admin")
                        {
                            MessageBox.Show("Username Incorrect.");
                        }
                        else if (pass.Text != "admin")
                        {
                            MessageBox.Show("Password Incorrect");
                        }
                        else
                        {
                            Form2 frm = new Form2();
                            frm.Show();
                        }
                    }
                }
                else
                {
                    if (choice.SelectedItem.ToString() == "Member")
                    {

                        conn.Open();
                        cmd.Connection = conn;
                        if (uname.Text == "" || pass.Text == "")
                        {
                            MessageBox.Show("Fields cannot be left blank.");
                        }
                        else
                        {
                            if (uname.Text != "member")
                            {
                                MessageBox.Show("Username Incorrect.");
                            }
                            else if (pass.Text != "member")
                            {
                                MessageBox.Show("Password Incorrect");
                            }
                            else
                            {
                                Form3 frm = new Form3();
                                frm.Show();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MS_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void choice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choice.SelectedItem.ToString() == "Admin")
            {
                MS.Hide();
            }
            else
            {
                MS.Show();
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void uname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
