using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using AndrewHowardSchedulerApp.DataClasses;
using AndrewHowardSchedulerApp.DB;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndrewHowardSchedulerApp
{
    public partial class Appointments : Form
    {

        public Appointments(int userID)
        {
            InitializeComponent();
            LoadAppointments(userID);
        }

        public void LoadAppointments(int userID)
        {
            apptDayViewRadio.Checked = true;
            var appointmentsTable = DataOperations.GetAppointments(userID);
            var appointmentsSource = new BindingSource();
            appointmentsSource.DataSource = appointmentsTable;

            apptDataGrid.RowHeadersVisible = false;
            apptDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            apptDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptDataGrid.MultiSelect = false;
            apptDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
            apptDataGrid.DataSource = null;
            apptDataGrid.DataSource = appointmentsSource;


        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            int currentUser = User.UserID;
            Customers Customers = new Customers(currentUser);
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
