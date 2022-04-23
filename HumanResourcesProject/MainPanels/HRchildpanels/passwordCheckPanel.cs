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
    public partial class passwordCheckPanel : Form
    {

        DataBase DT = new DataBase();
        public string idKeeper3;
        int result;

        public passwordCheckPanel()
        {

            InitializeComponent();
        }

        private void checkBTN_Click(object sender, EventArgs e)
        {
            DT.sqlCon.Open();
            SqlCommand cmd = new SqlCommand("select Password from tbl_USER where PerID=@p1", DT.sqlCon);
            cmd.Parameters.AddWithValue("@p1", idKeeper3);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == txtPassword.Text && txtCPT.Text == result.ToString())
            {
                this.passwordCheckPanel_Load(sender, e);
                this.Hide();
                DT.sqlCon.Close();
            }
            else if (dt.Rows[0][0].ToString() == txtPassword.Text && txtCPT.Text != result.ToString())
            {
                true1.Visible = true;
                false1.Visible = false;
                true2.Visible = false;
                false2.Visible = true;
                DT.sqlCon.Close();
            }
            else if (dt.Rows[0][0].ToString() != txtPassword.Text && txtCPT.Text == result.ToString())
            {
                true1.Visible = false;
                false1.Visible = true;
                true2.Visible = true;
                false2.Visible = false;
                DT.sqlCon.Close();
            }
            else
            {
                true1.Visible = false;
                false1.Visible = true;
                true2.Visible = false;
                false2.Visible = true;
                DT.sqlCon.Close();
            }


        }

        private void passwordCheckPanel_Load(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtCPT.Clear();

            // Captcha
            Random R = new Random();
            int first = R.Next(0, 100);
            int second = R.Next(0, 100);
            result = first + second;
            lblCPT.Text = first + " + " + second + " = ";
        }
    }
}
