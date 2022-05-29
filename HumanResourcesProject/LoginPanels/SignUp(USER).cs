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
        DataBase DT = new DataBase();
        SqlCommand CMD;
        string genderKeeper;

        public SignUp()
        {
            InitializeComponent();
        }

        private void firstTXT_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(firstTXT.Text, "^[a-zA-Z ]*$"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                firstTXT.Text.Remove(firstTXT.Text.Length - 1);
            }
        }

        private void lastTXT_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(firstTXT.Text, "^[a-zA-Z ]*$"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                firstTXT.Text.Remove(firstTXT.Text.Length - 1);
            }
        }

        private void passwordTXT_TextChanged(object sender, EventArgs e)
        {
            if (passwordTXT.Text.Length > 6)
            {
                MessageBox.Show("Only 6 characters!");
                passwordTXT.Text = passwordTXT.Text.Remove(passwordTXT.Text.Length - 1);
            }
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Male";
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            genderKeeper = "Female";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // To go back through Login Panel.
            LogIn LOGIN = new LogIn();
            this.Hide();
            LOGIN.Show();
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            // Close the app.
            Application.Exit();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            // part of Checking process
            bool invalidPerId = false;

            // Check for PerID if same id exist in tbl_USER 
            DT.sqlCon.Open();
            CMD = new SqlCommand("select PerID from tbl_USER",DT.sqlCon);
            SqlDataReader DR = CMD.ExecuteReader();
            while(DR.Read())
            { 
                if (DR["PerID"].ToString() == idText.Text)
                { 
                    MessageBox.Show("Bu ID'ye sahip başka bir personel var!");
                    DT.sqlCon.Close();
                    invalidPerId = true; // overwatch line 99.
                    break;
                } 
            }
            DT.sqlCon.Close();


            if (invalidPerId == false)
            {
                DT.sqlCon.Open();
                SqlCommand CMD2 = new SqlCommand("insert into tbl_USER (Firstname, Lastname, PerID, Password, Gender, Phone, Title) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7) ", DT.sqlCon);
                CMD2.Parameters.AddWithValue("@p1", firstTXT.Text);
                CMD2.Parameters.AddWithValue("@p2", lastTXT.Text);
                CMD2.Parameters.AddWithValue("@p3", idText.Text);
                CMD2.Parameters.AddWithValue("@p4", passwordTXT.Text);
                CMD2.Parameters.AddWithValue("@p5", genderKeeper);
                CMD2.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
                CMD2.Parameters.AddWithValue("@p7", "user");
                CMD2.ExecuteNonQuery();
                DT.sqlCon.Close();

                label5.ForeColor = Color.Green;
                label5.Text = "You are";
                label7.ForeColor = Color.Green;
                label7.Text = "Hired!";
                veritfyIcon.Visible = true;
            }
        }

        private void idText_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(idText.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                idText.Text = idText.Text.Remove(idText.Text.Length - 1);
            }

            if (idText.Text.Length > 6)
            {
                MessageBox.Show("Only 6 characters!");
                idText.Text = idText.Text.Remove(idText.Text.Length - 1);
            }
        }
    }
}



               
                    
               