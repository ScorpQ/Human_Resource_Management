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
//TO use SQL commands
using System.Data.SqlClient;


namespace HumanResourcesProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void userBTN_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Login_USER HRform = new Login_USER();
            HRform.TopLevel = false;
            panel1.Controls.Add(HRform);
            HRform.Show();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Login_USER HRform = new Login_USER();
            HRform.TopLevel = false;
            panel1.Controls.Add(HRform);
            HRform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Login_ADMIN_ ADMINform = new Login_ADMIN_();
            ADMINform.TopLevel = false;
            panel1.Controls.Add(ADMINform);
            ADMINform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Login_HR ADMINform = new Login_HR();
            ADMINform.TopLevel = false;
            panel1.Controls.Add(ADMINform);
            ADMINform.Show();
        }
    }

}
