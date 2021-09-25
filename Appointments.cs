using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndrewHowardSchedulerApp
{
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
            apptDayViewRadio.Checked = true;
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers Customers = new Customers();
            Customers.ShowDialog();
            this.Close();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports Reports = new Reports();
            Reports.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void apptMonthViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            apptTitle.Text = "Appointments This Month";
        }

        private void apptWeekViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            apptTitle.Text = "Appointments This Week";

        }

        private void apptDayViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            apptTitle.Text = "Appointments Today";

        }
    }
}
