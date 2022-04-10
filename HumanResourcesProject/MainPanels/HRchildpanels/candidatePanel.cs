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

        // To
        string genderKeeper;


        public candidatePanel()
        {
            InitializeComponent();
        }

        private void candidatePanel_Load(object sender, EventArgs e)
        {
            // Before 

            DT.DataGrid_CANDIDATE(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // CV

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //gets a collection that contains all the rows
            nameBox.Text = row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString();
            mjrBox.Text = row.Cells[5].Value.ToString();
        }

        private void addToGrid_Click(object sender, EventArgs e)
        {
            //       
            DT.sqlCon.Open();
            string query = "insert into tbl_CANDIDATE (Firstname, Lastname, Major, Phone, Gender,Hire) values (@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlCommand cmd = new SqlCommand(query, DT.sqlCon);
            cmd.Parameters.AddWithValue("@p1", fllnameBox.Text);
            cmd.Parameters.AddWithValue("@p2", lstnameBox.Text);
            cmd.Parameters.AddWithValue("@p3", mjrBox2.Text);
            cmd.Parameters.AddWithValue("@p4", phneBox.Text);
            cmd.Parameters.AddWithValue("@p5", genderKeeper);
            cmd.Parameters.AddWithValue("@p6", "waiting");
            cmd.ExecuteNonQuery();
            DT.sqlCon.Close();
            
            DT.DataGrid_CANDIDATE(dataGridView1);
            
            
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Male";
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Female";
        }

        private void hire_changeBTN_Click(object sender, EventArgs e)
        { 
            // To change 
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            DT.change_Hire_To_waitingforapproval(selectedValue);

            // To
            DT.DataGrid_CANDIDATE(dataGridView1);
        }

        private void eliminatedBTN_Click(object sender, EventArgs e)
        {
            //
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            DT.eliminate_the_candidate(selectedValue);

            // updated datagrid
            DT.DataGrid_CANDIDATE(dataGridView1);
        }
    }
}
