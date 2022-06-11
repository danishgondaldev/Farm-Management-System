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
    public partial class ListDecreasing : Form
    {
        public ListDecreasing()
        {
            InitializeComponent();
            OrganismDL.sortingDecreasing();
            sortingDecreasingGV.DataSource = OrganismDL.Org_data_decreasing;
            sortingDecreasingGV.Columns["price"].Visible = false;
            sortingDecreasingGV.Columns["fodder"].Visible = false;
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
