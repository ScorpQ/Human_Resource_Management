using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesProject.MainPanels;
using HumanResourcesProject.LoginPanels;

namespace HumanResourcesProject.LoginPanels
{
    public partial class Login_HR : Form
    {

        public Login_HR()
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

            // To check incoming info from TextBoxes.
            if (DTB.login(id1.Text, password1.Text,"hr") == 0)
            {
                // To open the panelHR
                panelHR GP1 = new panelHR();
                LogIn F1 = (LogIn)Application.OpenForms["LogIn"];
                GP1.idKeeper1 = id1.Text;
                F1.Hide();
                GP1.Show();
                
            }
            else if (DTB.login(id1.Text, password1.Text, "hr") == 1)
            {
                // Unvisible warning label. (it appears when informations invalid.)
                invalidLbl.Visible = true;
                invalidLbl.Text = "Invalid account information.";
            }
            else if (DTB.login(id1.Text, password1.Text, "hr") == 2)
            {
                // FOR try-catch(Exception). This catch() returns 2.
                invalidLbl.Visible = true;
                invalidLbl.Text = "Format Error.";
            }
        }
    }
}
