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
    public partial class BuyEggs : Form
    {
        public BuyEggs()
        {
            InitializeComponent();
        }

        private void clearDataFromForm()
        {
            txtEggs.Text = "";
            lblTotal.Text = "";
        }

        private void txtEggs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string eggs_number = txtEggs.Text;
                int eggs = int.Parse(eggs_number);
                string bill = (eggs * FarmDataDL.Data.Eggs_price).ToString();
                lblTotal.Text = bill;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Shop Again!");
            }
           
        }

        private void btnBuyEggs_Click(object sender, EventArgs e)
        {
            int eggs = int.Parse(txtEggs.Text);
            if (eggs > FarmDataDL.Data.Eggs)
            {
                MessageBox.Show("This much eggs are not available on farm !!!");
            }
            else
            {
                MessageBox.Show("Successfuly Bought!");
                int new_eggs = FarmDataDL.Data.Eggs;
                new_eggs = new_eggs - eggs;
                FarmDataDL.Data.Eggs = new_eggs;
                FarmDataDL.Data.Farm_sales = FarmDataDL.Data.Farm_sales + int.Parse(lblTotal.Text);
                FarmDataDL.storeFarmDataIntoFile();
            }
            clearDataFromForm();
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
