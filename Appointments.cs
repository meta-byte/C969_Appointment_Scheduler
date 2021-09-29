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

            //Appointment Data Grid
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
            apptDataGrid.Columns["ID"].Visible = false;


            //Combo Boxes Pickers and Text Boxes
            apptTypeComboBox.DataSource = new[]{ "Scrum", "Presentation", "Interview" };
            var customerTable = DataOperations.GetCustomers();
            var customerList = (from DataRow row in customerTable.Rows select row["Name"]).ToList();
            apptCustomerComboBox.DataSource = customerList;
            DateTime now = DateTime.Now;
            apptStartPicker.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            apptEndPicker.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);

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

        private void apptAddButton_Click(object sender, EventArgs e)
        {

            string customerName = apptCustomerComboBox.Text;
            int.TryParse(DataOperations.GetCustomer(customerName), out int customerID);

            Appointment appointment = new Appointment();

            appointment.Title = apptTitleField.Text;
            appointment.CustomerID = customerID;
            appointment.UserID = User.UserID;
            appointment.Type = apptTypeComboBox.Text;
            appointment.Start = apptStartPicker.Value;
            appointment.End = apptEndPicker.Value;

            DataOperations.AddAppointment(appointment);
            DataOperations.GetAppointments(User.UserID);
            LoadAppointments(User.UserID);
        }

        private void apptEditButton_Click(object sender, EventArgs e)
        {
            string customerName = apptCustomerComboBox.Text;
            int.TryParse(DataOperations.GetCustomer(customerName), out int customerID);

            var selectedAppointmentId = apptDataGrid.CurrentRow.Cells[0].Value;

            Appointment appointment = new Appointment();

            appointment.AppointmentID = int.Parse((string)selectedAppointmentId);
            appointment.Title = apptTitleField.Text;
            appointment.CustomerID = customerID;
            appointment.UserID = User.UserID;
            appointment.Type = apptTypeComboBox.Text;
            appointment.Start = apptStartPicker.Value;
            appointment.End = apptEndPicker.Value;

            DataOperations.EditAppointment(appointment);
            DataOperations.GetAppointments(User.UserID);
            LoadAppointments(User.UserID);
        }

        private void apptDeleteButton_Click(object sender, EventArgs e)
        {
            int selectedAppointmentId = int.Parse(apptDataGrid.CurrentRow.Cells[0].Value.ToString());
            DataOperations.DeleteAppointment(selectedAppointmentId);

            DataOperations.GetAppointments(User.UserID);
            LoadAppointments(User.UserID);
        }

        private void apptDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            apptTitleField.Text = apptDataGrid.CurrentRow.Cells[1].Value.ToString();
            apptCustomerComboBox.SelectedItem = apptDataGrid.CurrentRow.Cells[2].Value.ToString();
            apptTypeComboBox.SelectedItem = apptDataGrid.CurrentRow.Cells[3].Value.ToString();
            apptStartPicker.Value = DateTime.Parse(apptDataGrid.CurrentRow.Cells[4].Value.ToString());
            apptEndPicker.Value = DateTime.Parse(apptDataGrid.CurrentRow.Cells[5].Value.ToString());

        }
    }
}
