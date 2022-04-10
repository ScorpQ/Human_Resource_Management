using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesProject.LoginPanels
{
    public partial class Login_USER : Form
    {
        public Login_USER()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DataBase DTB = new DataBase();

            // To check incoming info from TextBoxes.
              if (DTB.login(id1.Text, password1.Text,"user") == 0)
              {
                // To open the GeneralPanel
                PanelUSER GP1 = new PanelUSER();
                LogIn F1 = (LogIn)Application.OpenForms["LogIn"];
                F1.Hide();
                GP1.Show();
              }
              else if (DTB.login(id1.Text,password1.Text, "user") == 1)
              {
                  // Unvisible warning label. (it appears when informations invalid.)
                  invalidLbl.Visible = true;
                  invalidLbl.Text = "Invalid account information.";
              }
              else if(DTB.login(id1.Text,password1.Text, "user") == 2)
              {
                  // FOR try-catch(Exception). This catch() returns 2.
                  invalidLbl.Visible = true;
                  invalidLbl.Text = "Format Error.";
              }   
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // To close the application.
            Application.Exit();
        }

        private void signupLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // To open Sign Up's form.
            SignUp SU = new SignUp();
            SU.Show();
            this.Hide();
        }

        private void Login_HR__Load(object sender, EventArgs e)
        {
            // To remove underline of linklabel.
            signupLbl.LinkBehavior = LinkBehavior.NeverUnderline;
        }
    }
}
