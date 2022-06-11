using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmManagementSystem
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnAddOrganism_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddOrganism organism = new AddOrganism();
            organism.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser user = new AddUser();
            user.Show();
        }

        private void btnUpdateHealth_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateHealth organism = new UpdateHealth();
            organism.Show();
        }

        private void btnUpdateWeight_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateWeight organism = new UpdateWeight();
            organism.Show();
        }

        private void btnAddToSalesList_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddToSalesList organism = new AddToSalesList();
            organism.Show();
        }

        private void btnVetAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            VetAppointment organism = new VetAppointment();
            organism.Show();
        }

        private void btnAllocateFood_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllocateFodder organism = new AllocateFodder();
            organism.Show();
        }

        private void btnFoodCost_Click(object sender, EventArgs e)
        {
            this.Hide();
            FodderCost organism = new FodderCost();
            organism.Show();
        }

        private void btnAddEggs_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEggs eggs = new AddEggs();
            eggs.Show();
        }

        private void btnTotalWorth_Click(object sender, EventArgs e)
        {
            this.Hide();
            TotalWorth worth = new TotalWorth();
            worth.Show();
        }

        private void btnSortIncreasing_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListIncreasing organism = new ListIncreasing();
            organism.Show();
        }

        private void btnSortDecreasing_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListDecreasing organism = new ListDecreasing();
            organism.Show();
        }

        private void btnAddMilk_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMilk milk = new AddMilk();
            milk.Show();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form oForm in Application.OpenForms)
            {
                if (oForm is HomePage)
                {
                    oForm.Close();
                    break;
                }
            }
            this.Close();
        }
    }
}
