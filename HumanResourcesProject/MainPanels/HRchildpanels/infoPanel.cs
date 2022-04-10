using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesProject.LoginPanels;
using System.Data.SqlClient;


namespace HumanResourcesProject.MainPanels.HRpanels
{
    public partial class infoPanel : Form
    {
        DataBase DT = new DataBase();
        public string idKeeper2;
        
        public infoPanel()
        {
            InitializeComponent();
        }

        private void infoPanel_Load(object sender, EventArgs e)
        {
            
            // Retrieving user data from tbl_USER   
            DT.sqlCon.Open();
            string query = "select * from tbl_USER where perID=@id";
            SqlCommand cmd = new SqlCommand(query,DT.sqlCon);
            cmd.Parameters.AddWithValue("id", idKeeper2);

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtNAME.Text = dr[3].ToString();
                txtSURNAME.Text = dr[4].ToString();
                txtPHONE.Text = dr[6].ToString();
                txtID.Text = dr[1].ToString();
                txtSTATU.Text = dr[7].ToString();
                txtPASSWRD.Text = dr[2].ToString();
            }
            DT.sqlCon.Close();

            // Check line 29.
            lockBox1.Checked = true;           
        }

        private void lockBox1_CheckedChanged(object sender, EventArgs e)
        {
            // To unable to change information when lockBox1 is active.
            if (lockBox1.Checked == true)
            {
                txtSURNAME.Enabled = false;
                txtPHONE.Enabled = false;
                txtID.Enabled = false;
                txtPASSWRD.Enabled = false;
                txtSTATU.Enabled = false;
            }
            if (lockBox1.Checked == false)
            {
                txtSURNAME.Enabled = true;
                txtPHONE.Enabled = true;
                txtID.Enabled = true;
                txtPASSWRD.Enabled = true;
                txtSTATU.Enabled = true;
            }
        }

        private void updteBTN_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcnt = new SqlConnection("Data Source=DESKTOP-OF07IF9;Initial Catalog=HRmanagement;Integrated Security=True");
            sqlcnt.Open();

            // To 
            SqlCommand cmd1 = new SqlCommand("select ID from tbl_USER where PerId=@p1",sqlcnt);
            cmd1.Parameters.AddWithValue("@p1", idKeeper2);
            SqlDataAdapter dr = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            string uniqID = dt.Rows[0][0].ToString();

            // To
            SqlCommand cmd2 = new SqlCommand("update tbl_USER set Lastname=@p2,Phone = @p3, perID=@p4,Title =@p5, Password=@p6 where ID = @p1", sqlcnt);
            cmd2.Parameters.AddWithValue("@p1", uniqID);
            cmd2.Parameters.AddWithValue("@p2", txtSURNAME.Text);
            cmd2.Parameters.AddWithValue("@p3", txtPHONE.Text);
            cmd2.Parameters.AddWithValue("@p4", txtID.Text);
            cmd2.Parameters.AddWithValue("@p5", txtSTATU.Text);
            cmd2.Parameters.AddWithValue("@p6", txtPASSWRD.Text); 
            cmd2.ExecuteNonQuery();
            sqlcnt.Close();

            // To 
            label5.Visible = true;
            label5.Text = "Güncellendi!";

        }
    }
}



/* 
            SqlCommand cmd = new SqlCommand("insert into tbl_USER (Firstname, Lastname, Phone, PerID, Title, Password) values (@p1,@p2,@p3,@p4,@p5,@p6)",sqlcnt);
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2",textBox2.Text);
            cmd.Parameters.AddWithValue("@p3",textBox3.Text);
            cmd.Parameters.AddWithValue("@p4",textBox4.Text);
            cmd.Parameters.AddWithValue("@p5",textBox7.Text);
            cmd.Parameters.AddWithValue("@p6",textBox6.Text);
            cmd.ExecuteNonQuery();
            sqlcnt.Close(); 
 
 
            SqlConnection sqlcnt = new SqlConnection("Data Source=DESKTOP-OF07IF9;Initial Catalog=HRmanagement;Integrated Security=True");
            sqlcnt.Open();
            SqlCommand cmd = new SqlCommand("update tbl_USER set Lastname = @p2, Phone = @p3, Title =@p5, Password=@p6 where Firstname = @p1", sqlcnt);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", textBox7.Text);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);
          //cmd.Parameters.AddWithValue("@p7", idKeeper2);  
            cmd.ExecuteNonQuery();
            sqlcnt.Close();
            MessageBox.Show("-__-");
 
 
 
 */