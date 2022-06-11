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
    public partial class UpdateWeight : Form
    {
        public UpdateWeight()
        {
            InitializeComponent();
            updateWeightGV.DataSource = OrganismDL.Org_data;
            updateWeightGV.Columns["price"].Visible = false;
            updateWeightGV.Columns["fodder"].Visible = false;
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
            txtWeight.Text = "";
        }

        public void dataBind()
        {
            updateWeightGV.DataSource = null;
            updateWeightGV.DataSource = OrganismDL.Org_data;
            updateWeightGV.Columns["price"].Visible = false;
            updateWeightGV.Columns["fodder"].Visible = false;
            updateWeightGV.Refresh();
        }

        private void btnUpdateWeight_Click(object sender, EventArgs e)
        {
            int i = OrganismDL.chkName(txtName.Text);
            if (i > -1)
            {
                MessageBox.Show("Weight Updated!");
                OrganismDL.Org_data[i].Weight = int.Parse(txtWeight.Text);
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
