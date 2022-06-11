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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void clearDataFromForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;
            string role = lblRoleAdmin.Text;
            CredentialsBL user = new CredentialsBL(name, password, role);
            if (CredentialsDL.chkName(user))
            {
                CredentialsDL.addUserIntoList(user);
                CredentialsDL.storeUserIntoFile(user);
                MessageBox.Show("Data Added Successfully!");
            }
            else
            {
                MessageBox.Show("This name already exists! Please try with another name!");
            }
            clearDataFromForm();
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form oForm in Application.OpenForms)
            {
                if (oForm is AdminMenu)
                {
                    oForm.Show();
                    break;
                }
            }
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
