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
    public partial class Form4 : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/pass.accdb";
        

        public Form4()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (pass1.Text != cpass1.Text)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                string us = Convert.ToString(usern.Text);
                string pw = Convert.ToString(pass1.Text);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO passdb (usernm,passw) VALUES('" + @us + "','" + @pw + "')";
                int temp = cmd.ExecuteNonQuery();
                if (temp > 0)
                {
                    pass1.Text = null;
                    MessageBox.Show("Account created successfully!");
                }
                else
                {
                    MessageBox.Show("Account failed to create!");

                }
            }
            string name = Convert.ToString(nm.Text);
            string dt = Convert.ToString(dob.Value.ToShortDateString());
            string us1 = Convert.ToString(usern.Text);
            cmd.CommandText = "UPDATE passdb SET m_name=('" +@name + "'),dtob=('" + @dt + "') WHERE usernm=('" + @us1 + "')";
            int temp1 = cmd.ExecuteNonQuery();
            if (temp1 > 0)
            {
                nm.Text = null;
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not Done");

            }
            conn.Close();
        }

    }

    }

