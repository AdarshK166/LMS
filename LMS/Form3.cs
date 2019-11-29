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
    public partial class Form3 : Form
    {
        private OleDbConnection conn;
        private OleDbConnection conn1;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        private String conStr1 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/pass.accdb";
        public Form3()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
            conn1 = new OleDbConnection(conStr1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM bookdb";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "bookdb");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "bookdb";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(bookid.Text);
            string nm =Convert.ToString(usrnm.Text);
            conn1.Open();
            cmd.Connection = conn1;
            cmd.CommandText = "UPDATE passdb SET req_book=('"+id+"') WHERE usernm=('"+nm+"')";
            int temp = cmd.ExecuteNonQuery();
            if (temp > 0)
            {
                bookid.Text = null;
                usrnm.Text = null;
                MessageBox.Show("Request successfull!");
            }
            else
            {
                MessageBox.Show("Request failed!");

            }
            conn.Close();
        }
    }
}
