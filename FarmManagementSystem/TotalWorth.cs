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
    public partial class TotalWorth : Form
    {
        public TotalWorth()
        {
            InitializeComponent();
            lblTotal.Text = (FarmDataDL.Data.Farm_sales).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblTotal.Text = (0).ToString();
            FarmDataDL.Data.Farm_sales = 0;
            FarmDataDL.storeFarmDataIntoFile();
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
