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
    public partial class BuyMilk : Form
    {
        public BuyMilk()
        {
            InitializeComponent();
        }

        private void clearDataFromForm()
        {
            txtMilk.Text = "";
            lblTotal.Text = "";
        }
        private void txtMilk_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string milk_number = txtMilk.Text;
                int milk = int.Parse(milk_number);
                string bill = (milk * FarmDataDL.Data.Milk_price).ToString();
                lblTotal.Text = bill;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Shop Again!");
            }
        }

        private void btnBuyMilk_Click(object sender, EventArgs e)
        {
            int milk = int.Parse(txtMilk.Text);
            if (milk > FarmDataDL.Data.Milk)
            {
                MessageBox.Show("This much milk is not available on farm !!!");
            }
            else
            {
                MessageBox.Show("Successfuly Bought!");
                int new_milk = FarmDataDL.Data.Milk;
                new_milk = new_milk - milk;
                FarmDataDL.Data.Milk = new_milk;
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
