﻿using System;
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
        string requestKeeper;
        string idKeeper;

        public workerPanel()
        {
            InitializeComponent();
        }

        private void workerPanel_Load(object sender, EventArgs e)
        {
            // print tbl_CANDIDATE to DataGrid1
            string query_SHOW = "select ID, Firstname, Lastname, Major, Working, Salary, startPermisson, endPermission, request from TBL_WORKER";
            DT.list(dataGridView1, query_SHOW);


            // dateTime configrations...
            dateTimePicker1.CustomFormat = "MMMM dddd yyyy";
            dateTimePicker2.CustomFormat = "MMMM dddd yyyy";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            richTextBox1.Text = row.Cells[8].Value.ToString();
        }

        private void saveDate_Click(object sender, EventArgs e)
        {
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            string query_SHOW = "update tbl_WORKER set startPermisson=@u1, endPermission=@u2 where ID=@u3";
            DT.sqlCon.Open();
            SqlCommand CMD = new SqlCommand(query_SHOW,DT.sqlCon);
            CMD.Parameters.AddWithValue("@u1",dateTimePicker1.Value);
            CMD.Parameters.AddWithValue("@u2",dateTimePicker2.Value);
            CMD.Parameters.AddWithValue("@u3", selectedValue);
            CMD.ExecuteNonQuery();
            DT.sqlCon.Close();

            // Reflesh
            DT.list(dataGridView1, "select ID, Firstname, Lastname, Major, Working, Salary, startPermisson, endPermission, request from tbl_WORKER");
        }

        private void salaryBTN_Click(object sender, EventArgs e)
        {
            // set new salary.
            string selectedValue = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            DT.sqlCon.Open();
            string query_SHOW = "update tbl_WORKER set Salary=@u1 where ID=@u2";
            SqlCommand CMD = new SqlCommand(query_SHOW ,DT.sqlCon);
            CMD.Parameters.AddWithValue("@u1", salaryTXT.Text);
            CMD.Parameters.AddWithValue("@u2", selectedValue);
            CMD.ExecuteNonQuery();
            DT.sqlCon.Close();


            // Show new table.
            string query_SHOW2 = "select * from tbl_WORKER";
            DT.list(dataGridView1, query_SHOW2);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            // search by name
            string query_SHOW = "select * from tbl_WORKER where Firstname + Lastname like '%" + nameBox.Text + "%'";
            DT.list(dataGridView1, query_SHOW);
        }
    }
}
