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
using FarmManagementSystem.DL;

namespace FarmManagementSystem
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();

            if (CredentialsDL.readDataFromFile() && OrganismDL.readOrganismData() && FarmDataDL.readDataFromFile())
            {
                MessageBox.Show("Data Loaded!");
            }
            else
            {
                MessageBox.Show("Data Is Not Loaded! ");
            }
        }
        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (radioBtnSignIn.Checked)
            {
                SignIn ob = new SignIn();
                this.Hide();
                ob.Show();

            }
            else if (radioBtnSignUp.Checked)
            {
                SignUp ob = new SignUp();
                ob.ShowDialog();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
