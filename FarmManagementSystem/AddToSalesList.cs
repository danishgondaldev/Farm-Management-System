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
    public partial class AddToSalesList : Form
    {
        public AddToSalesList()
        {
            InitializeComponent();
            updatePriceGV.DataSource = OrganismDL.Org_data;
            updatePriceGV.Columns["fodder"].Visible = false;
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
            txtPrice.Text = "";
        }

        public void dataBind()
        {
            updatePriceGV.DataSource = null;
            updatePriceGV.DataSource = OrganismDL.Org_data;
            updatePriceGV.Columns["fodder"].Visible = false;
            updatePriceGV.Refresh();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            int i = OrganismDL.chkName(txtName.Text);
            if (i > -1)
            {
                OrganismDL.Org_data[i].Price = int.Parse(txtPrice.Text);
                OrganismDL.saveOrganismUpdate();
                MessageBox.Show("Price Updated!");
                dataBind();
            }
            else
            {
                MessageBox.Show("Invalid Data! Try Again");
                clearDataFromForm();
            }
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
