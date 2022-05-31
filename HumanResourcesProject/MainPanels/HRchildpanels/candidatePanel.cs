using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HumanResourcesProject.MainPanels.HRchildpanels
{
    public partial class candidatePanel : Form
    {
        DataBase DT = new DataBase();
        // sql transactions for the person who man or woman. Check line 93 & 98.
        string genderKeeper;
        // 


        public candidatePanel()
        {
            InitializeComponent();
        }

        private void candidatePanel_Load(object sender, EventArgs e)
        {
            // print tbl_CANDIDATE to DataGrid1
            string query_SHOW = "select * from tbl_CANDIDATE";
            DT.list(dataGridView1, query_SHOW);

            // Check line XX
            radioAll.Checked = true;
        }

        private void addToGrid_Click(object sender, EventArgs e)
        {
            // Add new candidate to TBL_CANDIDATE      
            DT.sqlCon.Open();
            string query = "insert into tbl_CANDIDATE (Firstname, Lastname, Major, Phone, Gender,Hire) values (@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlCommand cmd = new SqlCommand(query, DT.sqlCon);
            cmd.Parameters.AddWithValue("@p1", fllnameBox.Text);
            cmd.Parameters.AddWithValue("@p2", " " + lstnameBox.Text);
            cmd.Parameters.AddWithValue("@p3", mjrBox2.Text);
            cmd.Parameters.AddWithValue("@p4", phneBox.Text);
            cmd.Parameters.AddWithValue("@p5", genderKeeper);
            cmd.Parameters.AddWithValue("@p6", "Waiting");
            cmd.ExecuteNonQuery();
            DT.sqlCon.Close();

            // CV
            openFileDialog1.ShowDialog();

            // Print new table
            string query_SHOW = "select * from tbl_CANDIDATE";
            DT.list(dataGridView1, query_SHOW);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            //DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //gets a collection that contains all the rows
            //nameBox.Text = row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString();
            //mjrBox.Text = row.Cells[5].Value.ToString();
        }

        private void hire_changeBTN_Click(object sender, EventArgs e)
        {
            // To change status of specific candidate to "Waiting For Approval".
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            DT.change_Hire_To_waitingforapproval(selectedValue);

            // Show new table.
            string query_SHOW = "select * from tbl_CANDIDATE";
            DT.list(dataGridView1, query_SHOW);
        }

        private void eliminatedBTN_Click(object sender, EventArgs e)
        {
            // To change status of specific candidate to "Eliminated"...
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            DT.eliminate_the_candidate(selectedValue);

            // Show new table.
            string query_SHOW = "select * from tbl_CANDIDATE";
            DT.list(dataGridView1, query_SHOW);
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Male";
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Female";
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            // show all in dataGrid
            string query_SHOW = "select * from tbl_CANDIDATE";
            DT.list(dataGridView1, query_SHOW);
        }

        private void radioWaitApprvl_CheckedChanged(object sender, EventArgs e)
        {
            // show only approved in dataGrid
            string query_SHOW = "select * from tbl_CANDIDATE where Hire ='Approved'";
            DT.list(dataGridView1, query_SHOW);
        }

        private void radioWait_CheckedChanged(object sender, EventArgs e)
        {
            // show only waiting for interview in dataGrid
            string query_SHOW = "select * from tbl_CANDIDATE where Hire ='Waiting'";
            DT.list(dataGridView1, query_SHOW);
        }

        private void radioElimtd_CheckedChanged(object sender, EventArgs e)
        {
            // show all eliminated candidates in dataGrid
            string query_SHOW = "select * from tbl_CANDIDATE where Hire ='Eliminated'";
            DT.list(dataGridView1, query_SHOW);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            // search by name
            string query_SHOW = "select * from tbl_CANDIDATE where Firstname + Lastname like '%" + nameBox.Text + "%'";
            DT.list(dataGridView1, query_SHOW);
        }

        private void mjrBox_TextChanged(object sender, EventArgs e)
        {
            // search by major
            string query_SHOW = "select * from tbl_CANDIDATE where Major like '%" + mjrBox.Text + "%'";
            DT.list(dataGridView1, query_SHOW);
        }
    }
}
