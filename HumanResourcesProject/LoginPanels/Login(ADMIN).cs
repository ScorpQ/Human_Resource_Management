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

namespace HumanResourcesProject.LoginPanels
{
    public partial class Login_ADMIN_ : Form
    {
        public Login_ADMIN_()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // To close the application.
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DataBase DTB = new DataBase();

           if(DTB.login(id1.Text,password1.Text,"admin")== 0)
            {
                PanelUSER GP1 = new PanelUSER();
                LogIn F1 = (LogIn)Application.OpenForms["LogIn"];
                F1.Hide();
                GP1.Show();          
            }
           else if(DTB.login(id1.Text, password1.Text,"admin") == 1)
            {
                // Unvisible warning label. (it appears when informations invalid.)
                invalidLbl.Visible = true;
                invalidLbl.Text = "Invalid account information.";
            }
           else
            {
                // FOR try-catch(Exception). This catch() returns 2.
                invalidLbl.Visible = true;
                invalidLbl.Text = "Format Error.";
            }
           
        }
    }
}
