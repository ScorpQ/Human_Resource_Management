using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// To use SQL Commands
using System.Data.SqlClient;

namespace HumanResourcesProject
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // To go back through Login Panel.
            LogIn LOGIN = new LogIn();
            this.Hide();
            LOGIN.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close the app.
            Application.Exit();
        }
    }
}
