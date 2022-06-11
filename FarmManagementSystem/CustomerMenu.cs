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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void btnBuyOrganism_Click(object sender, EventArgs e)
        {
            BuyOrganism organism = new BuyOrganism();
            organism.ShowDialog();
        }

        private void btnBuyEggs_Click(object sender, EventArgs e)
        {
            BuyEggs egg = new BuyEggs();
            egg.ShowDialog();
        }

        private void btnBuyMilk_Click(object sender, EventArgs e)
        {
            BuyMilk milk = new BuyMilk();
            milk.ShowDialog();
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
