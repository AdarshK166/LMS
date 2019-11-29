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
    public partial class Form2 : Form
    {
        private OleDbConnection conn;
        private OleDbConnection conn1;
        private OleDbCommand cmd = new OleDbCommand();
        private String conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/Books.accdb";
        private String conStr1 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/chira/Desktop/Adarsh/pass.accdb";

        public Form2()
        {
            InitializeComponent();
            conn = new OleDbConnection(conStr);
            conn1 = new OleDbConnection(conStr1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addf frm = new Addf();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updt frm = new Updt();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delt frm = new delt();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void View_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM passdb";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            conn1.Open();
            da.Fill(ds, "passdb");
            conn.Close();
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "passdb";
            conn1.Close();
        }

        private void delm_Click(object sender, EventArgs e)
        {
            string un = Convert.ToString(delbox.Text);
            conn1.Open();
            cmd.Connection = conn1;
            cmd.CommandText = "DELETE FROM passdb WHERE usernm ='" + un + "' ";
            int temp = cmd.ExecuteNonQuery();
            if (temp > 0)
            {
                delbox.Text = null;
                MessageBox.Show("Record deleted successfully!");
            }
            else
            {
                MessageBox.Show("Record failed to delete!");

            }
            conn1.Close();
        }
    }
}
