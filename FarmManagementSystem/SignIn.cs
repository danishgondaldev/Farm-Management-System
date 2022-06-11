using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmManagementSystem.BL;

namespace FarmManagementSystem
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void clearDataFromForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            CredentialsBL user = new CredentialsBL(txtUsername.Text, txtPassword.Text);
            CredentialsBL validUser = CredentialsDL.SignIn(user);
            if (validUser != null)
            {
                if (validUser.UserRole == "Admin")
                {
                    this.Hide();
                    AdminMenu menu = new AdminMenu();
                    menu.Show();
                    this.Close();
                }
                else if (validUser.UserRole == "Customer")
                {
                    this.Hide();
                    CustomerMenu menu = new CustomerMenu();
                    menu.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credentials!");
            }
            clearDataFromForm();
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form oForm in Application.OpenForms)
            {
                if (oForm is HomePage)
                {
                    oForm.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}
