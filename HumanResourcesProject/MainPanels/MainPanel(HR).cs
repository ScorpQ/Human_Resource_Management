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
using HumanResourcesProject.MainPanels.HRpanels;
using System.Data.SqlClient;
using HumanResourcesProject.MainPanels.HRchildpanels;

namespace HumanResourcesProject.MainPanels
{
    public partial class panelHR : Form
    {
        DataBase DT = new DataBase();
        infoPanel ip1 = new infoPanel();
        candidatePanel cp1 = new candidatePanel();
        workerPanel wp1 = new workerPanel();
        passwordCheckPanel ch1 = new passwordCheckPanel();
        projects pj1 = new projects();
        public string idKeeper1;


        public panelHR()
        {
            InitializeComponent();         
        }

        private void panelHR_Load(object sender, EventArgs e)
        { 
            // label to name and anothers
            label1.Text = idKeeper1;
            ch1.idKeeper3 = idKeeper1;

           string query = "select Firstname from tbl_USER where PerId=@id";
            SqlCommand cmd1 = new SqlCommand(query,DT.sqlCon);
            cmd1.Parameters.AddWithValue("@id", label1.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);  


            // to        
            if (DateTime.Now >= Convert.ToDateTime("06:30"))
            {
                label1.Text = "İyi Akşamlar " + dt.Rows[0][0].ToString();
            }
            else
            {
                label1.Text = "Günaydın " + dt.Rows[0][0].ToString();
            }

            ip1.idKeeper2 = idKeeper1;
            
            // follow appears when launch panel
            panel2.Controls.Clear();
            cp1 = new candidatePanel();
            cp1.TopLevel = false;
            panel2.Controls.Add(cp1);
            cp1.Show(); 

        }

        private void cndidateBTN_Click(object sender, EventArgs e)
        {
            // To show panel of "candidate".
            panel2.Controls.Clear();
            cp1 = new candidatePanel();
            cp1.TopLevel = false;
            panel2.Controls.Add(cp1);
            cp1.Show();
            cndidateBTN.BackColor =Color.FromArgb(25, 35, 50);

            // button's background color set default instead of current button.
            cndidateBTN.BackColor = Color.FromArgb(25, 35, 50);
            workerBTN.BackColor = Color.FromArgb(25, 35, 65);
            infoBTN.BackColor = Color.FromArgb(25, 35, 65);
            prjctBTN.BackColor = Color.FromArgb(25, 35, 65);
        }

        private void workerBTN_Click(object sender, EventArgs e)
        {
            // To show panel of "workers".
            panel2.Controls.Clear();
            wp1 = new workerPanel();
            wp1.TopLevel = false;
            panel2.Controls.Add(wp1);
            wp1.Show();

            // button's background color set default instead of current button.
            workerBTN.BackColor = Color.FromArgb(25, 35, 50);
            infoBTN.BackColor = Color.FromArgb(25, 35, 65);
            prjctBTN.BackColor = Color.FromArgb(25, 35, 65);
            cndidateBTN.BackColor = Color.FromArgb(25, 35, 65);
        }

        private void infoBTN_Click(object sender, EventArgs e)
        {
            // confirm current password to access panel of "Bilgilerim"
            panel2.Controls.Clear();
            ch1.TopLevel = false;
            panel2.Controls.Add(ch1);
            ch1.Show();

            ip1.TopLevel = false;
            panel2.Controls.Add(ip1);
            ip1.Show();

            // button's background color set default instead of current button.
            infoBTN.BackColor = Color.FromArgb(25, 35, 50);
            prjctBTN.BackColor = Color.FromArgb(25, 35, 65);
            workerBTN.BackColor = Color.FromArgb(25, 35, 65);
            cndidateBTN.BackColor = Color.FromArgb(25, 35, 65);
        }

        private void prjctBTN_Click(object sender, EventArgs e)
        {
            // To show panel of "projects".
            panel2.Controls.Clear();
            pj1 = new projects();
            pj1.TopLevel = false;
            panel2.Controls.Add(pj1);
            pj1.Show();

            // button's background color set default instead of current button.
            prjctBTN.BackColor = Color.FromArgb(25, 35, 50);
            infoBTN.BackColor = Color.FromArgb(25, 35, 65);
            workerBTN.BackColor = Color.FromArgb(25, 35, 65);
            cndidateBTN.BackColor = Color.FromArgb(25, 35, 65);
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak istediğinden emin misin?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // To close application
                Application.Exit();
            }
            else
            {
                // do nothing
            }
        }
    }
}

