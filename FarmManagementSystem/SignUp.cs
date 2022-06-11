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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void clearDataFromForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

       
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            CredentialsBL user = new CredentialsBL(txtUsername.Text, txtPassword.Text, "Customer");
            if (CredentialsDL.chkName(user))
            {
                CredentialsDL.addUserIntoList(user);
                CredentialsDL.storeUserIntoFile(user);
                MessageBox.Show("Sign Up Successful! Sign In to Continue");
            }
            else
            {
                MessageBox.Show("This username already exists! Please try with another name!");
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
