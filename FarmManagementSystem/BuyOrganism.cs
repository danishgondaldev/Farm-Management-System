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
    public partial class BuyOrganism : Form
    {
        public BuyOrganism()
        {
            InitializeComponent();
            buyOrganismGV.DataSource = OrganismDL.Org_data;
            buyOrganismGV.Columns["fodder"].Visible = false;
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
        }

        public void dataBind()
        {
            buyOrganismGV.DataSource = null;
            buyOrganismGV.DataSource = OrganismDL.Org_data;
            buyOrganismGV.Columns["fodder"].Visible = false;
            buyOrganismGV.Refresh();
        }
        private void btnBuyOrganism_Click(object sender, EventArgs e)
        {
            int i = OrganismDL.chkName(txtName.Text);
            if (i > -1)
            {
                MessageBox.Show("Successfuly Bought Organism!");
                FarmDataDL.Data.Farm_sales = FarmDataDL.Data.Farm_sales + OrganismDL.Org_data[i].Price;
                FarmDataDL.storeFarmDataIntoFile();
                OrganismDL.Org_data.RemoveAt(i);
                OrganismDL.saveOrganismUpdate();
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
                if (oForm is CustomerMenu)
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
