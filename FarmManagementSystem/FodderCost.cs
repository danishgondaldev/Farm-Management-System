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
    public partial class FodderCost : Form
    {
        public FodderCost()
        {
            InitializeComponent();
        }
        private void btnTotalCost_Click(object sender, EventArgs e)
        {
            int animal_cost = int.Parse(txtAnimals.Text);
            int bird_cost = int.Parse(txtAnimals.Text);

            if (FarmDataDL.Data.Fodder_counter == OrganismDL.Org_data.Count)
            {
                int total = animal_cost * FarmDataDL.Data.Fodder_animals + bird_cost * FarmDataDL.Data.Fodder_birds;
                lblTotal.Text = total.ToString();
            }

            else
            {
                MessageBox.Show("Food Has Not Been Allocated To All Organisms !!!");
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
