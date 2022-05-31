using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.SqlClient;

namespace HumanResourcesProject.MainPanels.HRchildpanels
{
    public partial class projects : Form
    {
        DataBase DT = new DataBase();
        string query;

        public projects()
        {
            InitializeComponent();
        }

        private void P1_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_PROJECT.projeID=7878";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();       
        }

        private void P2_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_PROJECT.projeID=8689";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query,DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();
        }

        private void P3_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_WORKER.projeID=7321";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();
        }

        private void P4_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_WORKER.projeID=3435";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();
        }

        private void P5_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_WORKER.projeID=9498";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();
        }

        private void P6_Click(object sender, EventArgs e)
        {
            query = "select Firstname, Lastname, Major, Position, projeName, projeDescribe from tbl_WORKER inner join tbl_PROJECT on tbl_WORKER.projeID = tbl_PROJECT.projeID where tbl_WORKER.projeID=2592";
            DT.sqlCon.Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, DT.sqlCon);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            richTextBox1.Text = dt.Rows[0][5].ToString();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            DT.sqlCon.Close();
        }
    }
}
