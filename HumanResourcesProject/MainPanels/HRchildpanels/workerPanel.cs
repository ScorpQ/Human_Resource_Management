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
    public partial class workerPanel : Form
    {
        DataBase DT = new DataBase();
        string idKeeper;

        public workerPanel()
        {
            InitializeComponent();
        }

        private void workerPanel_Load(object sender, EventArgs e)
        {
            // print tbl_CANDIDATE to DataGrid1
            string query_SHOW = "select * from TBL_WORKER";
            DT.list(dataGridView1, query_SHOW);


            // dateTime configrations...
            dateTimePicker1.CustomFormat = "MMMM dddd yyyy";
            dateTimePicker2.CustomFormat = "MMMM dddd yyyy";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            idKeeper = row.Cells[0].Value.ToString();
            richTextBox1.Text = idKeeper;
        }

        private void saveDate_Click(object sender, EventArgs e)
        {
            string query_SHOW = "update tbl_WORKER set startPermisson=@u1, endPermission=@u2 where ID=@u3";
            DT.sqlCon.Open();
            SqlCommand CMD = new SqlCommand(query_SHOW,DT.sqlCon);
            CMD.Parameters.AddWithValue("@u1",dateTimePicker1.Value);
            CMD.Parameters.AddWithValue("@u2",dateTimePicker2.Value);
            CMD.Parameters.AddWithValue("@u3", idKeeper);
            CMD.ExecuteNonQuery();
            DT.sqlCon.Close();
        }
    }
}
