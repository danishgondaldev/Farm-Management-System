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
    public partial class VetAppointment : Form
    {
        public VetAppointment()
        {
            InitializeComponent();
            vetAppointmentGV.DataSource = OrganismDL.Org_data;
            vetAppointmentGV.Columns["price"].Visible = false;
            vetAppointmentGV.Columns["fodder"].Visible = false;
        }

        private void clearDataFromForm()
        {
            txtName.Text = "";
            comboBoxDate.SelectedItem = "";
            comboBoxMonth.SelectedItem = "";
        }

        public void dataBind()
        {
            vetAppointmentGV.DataSource = null;
            vetAppointmentGV.DataSource = OrganismDL.Org_data;
            vetAppointmentGV.Columns["price"].Visible = false;
            vetAppointmentGV.Columns["fodder"].Visible = false;
            vetAppointmentGV.Refresh();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            int i = OrganismDL.chkName(txtName.Text);
            if (i > -1)
            {
                if (!OrganismDL.Org_data[i].checkHealth())
                {
                    MessageBox.Show("Appointment Booked! You can go and see doctor!");
                }
                else
                {
                    MessageBox.Show("Appointment Can't Be Booked! Organism Is In Good Health! ");
                }
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
                if (oForm is AdminMenu)
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
