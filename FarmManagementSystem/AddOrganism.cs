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
    public partial class AddOrganism : Form
    {
        public AddOrganism()
        {
            InitializeComponent();
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
            txtWeight.Text = "";
            comboBoxHealth.SelectedText = "";
            comboBoxSpecies.SelectedText = "";
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int weight = int.Parse(txtWeight.Text);
            string species = comboBoxSpecies.Text;
            string health = comboBoxHealth.Text;
            OrganismBL organism = new OrganismBL(name, weight, species, health);
            if (OrganismDL.chkName(organism))
            {
                OrganismDL.addOrganismToList(organism);
                MessageBox.Show("Data Added Successfully!");
            }
            else
            {
                MessageBox.Show("This name already exists! Please try with another name!");
            }
            clearDataFromForm();
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
