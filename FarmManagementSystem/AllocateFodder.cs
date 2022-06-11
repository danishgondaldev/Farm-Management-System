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
    public partial class AllocateFodder : Form
    {
        public AllocateFodder()
        {
            InitializeComponent();
            allocateFodderGV.DataSource = OrganismDL.Org_data;
            allocateFodderGV.Columns["price"].Visible = false;
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
            txtFood.Text = "";
        }

        public void dataBind()
        {
            allocateFodderGV.DataSource = null;
            allocateFodderGV.DataSource = OrganismDL.Org_data;
            allocateFodderGV.Columns["price"].Visible = false;
            allocateFodderGV.Refresh();
        }
        private void btnAllocateFood_Click(object sender, EventArgs e)
        {
            int i = OrganismDL.chkName(txtName.Text);
            if (i > -1)
            {
                if (OrganismDL.Org_data[i].Fodder > 0)
                {
                    MessageBox.Show("Food Has Already Been Allocated To This Organism !!!");
                }
                else
                {
                    if (OrganismDL.Org_data[i].Species == "Animal")
                    {
                        OrganismDL.Org_data[i].Fodder = int.Parse(txtFood.Text);
                        FarmDataDL.Data.Fodder_animals = FarmDataDL.Data.Fodder_animals + int.Parse(txtFood.Text);
                        FarmDataDL.Data.Fodder_counter++;
                    }

                    else
                    {
                        OrganismDL.Org_data[i].Fodder = int.Parse(txtFood.Text);
                        FarmDataDL.Data.Fodder_birds = FarmDataDL.Data.Fodder_birds + int.Parse(txtFood.Text);
                        FarmDataDL.Data.Fodder_counter++;
                    }
                    MessageBox.Show("Food Allocated!");
                    OrganismDL.saveOrganismUpdate();
                    FarmDataDL.storeFarmDataIntoFile();
                    
                }
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
