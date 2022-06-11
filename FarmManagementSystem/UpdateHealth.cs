using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmManagementSystem.DL;

namespace FarmManagementSystem
{
    public partial class UpdateHealth : Form
    {
        public UpdateHealth()
        {
            InitializeComponent();
            updateHealthGV.DataSource = OrganismDL.Org_data;
            updateHealthGV.Columns["price"].Visible = false;
            updateHealthGV.Columns["fodder"].Visible = false;
        }
        private void clearDataFromForm()
        {
            txtName.Text = "";
            comboBoxHealth.SelectedItem = "";
        }

        public void dataBind()
        {
            updateHealthGV.DataSource = null;
            updateHealthGV.DataSource = OrganismDL.Org_data;
            updateHealthGV.Columns["price"].Visible = false;
            updateHealthGV.Columns["fodder"].Visible = false;
            updateHealthGV.Refresh();
        }


        private void btnUpdateHealth_Click(object sender, EventArgs e)
        {
           int i = OrganismDL.chkName(txtName.Text);
           if (i > -1)
            {
                MessageBox.Show("Health Updated!");
                OrganismDL.Org_data[i].Health = comboBoxHealth.Text;
                OrganismDL.saveOrganismUpdate();
                dataBind();
            }
           else
            {
                MessageBox.Show("Invalid Data! Try Again");
                clearDataFromForm();
            }
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
    }
}
