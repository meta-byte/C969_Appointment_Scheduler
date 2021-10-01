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
            NotifyAppointments();
        }

        public void LoadAppointments(int userID)
        {
            apptDayViewRadio.Checked = true;
            ToolTip toolTip = new ToolTip();

            //Appointment Data Grid
            apptDataGrid.RowHeadersVisible = false;
            apptDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            apptDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptDataGrid.MultiSelect = false;
            apptDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
            apptDataGrid.DataSource = null;
            apptTitle.Text = "Appointments Today";
            var appointmentsTable = DataOperations.GetAppointmentsDay(User.UserID);
            var appointmentsSource = new BindingSource();
            appointmentsSource.DataSource = appointmentsTable;
            apptDataGrid.DataSource = appointmentsSource;
            apptDataGrid.Columns["ID"].Visible = false;


            //Combo Boxes Pickers and Text Boxes
            apptTypeComboBox.DataSource = new[]{ "Scrum", "Presentation", "Interview", "Coffee", "Consulation", "Office Party" };
            var customerTable = DataOperations.GetCustomers();
            var customerList = (from DataRow row in customerTable.Rows select row["Name"]).ToList();
            apptCustomerComboBox.DataSource = customerList;
            DateTime now = DateTime.Now;
            apptStartPicker.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            apptEndPicker.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);


        }

        public void NotifyAppointments(){

            if (DataOperations.AppointmentsFifteenMinutes(User.UserID) == true)
            {
                MessageBox.Show("Your scheduled appointment is starting soon!", "Appointment in 15 minutes", MessageBoxButtons.OK);

            }
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
            var appointmentsTable = DataOperations.GetAppointmentsMonth(User.UserID);
            var appointmentsSource = new BindingSource();
            appointmentsSource.DataSource = appointmentsTable;
            apptDataGrid.DataSource = appointmentsSource;
            apptDataGrid.Columns["ID"].Visible = false;


        }

        private void apptWeekViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            apptTitle.Text = "Appointments This Week";
            var appointmentsTable = DataOperations.GetAppointmentsWeek(User.UserID);
            var appointmentsSource = new BindingSource();
            appointmentsSource.DataSource = appointmentsTable;
            apptDataGrid.DataSource = appointmentsSource;
            apptDataGrid.Columns["ID"].Visible = false;


        }

        private void apptDayViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            //Displays appointments for the day based on UTC currentdate
            apptTitle.Text = "Appointments Today";
            var appointmentsTable = DataOperations.GetAppointmentsDay(User.UserID);
            var appointmentsSource = new BindingSource();
            appointmentsSource.DataSource = appointmentsTable;
            apptDataGrid.DataSource = appointmentsSource;
            apptDataGrid.Columns["ID"].Visible = false;

        }

        private void apptAddButton_Click(object sender, EventArgs e)
        {
            //Require important fields 
            ToolTip toolTip = new ToolTip();

            if (string.IsNullOrWhiteSpace(apptTitleField.Text))
            {
                toolTip.Show("Title is required", apptTitleField);
                return;
            }

            if (string.IsNullOrWhiteSpace(apptTypeComboBox.Text))
            {
                toolTip.Show("Please select a type", apptTypeComboBox);
                return;
            }

            if (string.IsNullOrWhiteSpace(apptCustomerComboBox.Text))
            {
                toolTip.Show("Please select a customer", apptCustomerComboBox);
                return;
            }

            if (apptStartPicker.Value > apptEndPicker.Value)
            {
                toolTip.Show("start time must be before end time", apptStartPicker);
                return;

            }

            else
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
                DataOperations.LogActivity(User.Username, "Added an appointment with ID " + appointment.AppointmentID);

                //see what was checked and reload that data
                if (apptDayViewRadio.Checked == true){
                    LoadAppointments(User.UserID);
                    apptDayViewRadio.Checked = true;
                }
                if (apptWeekViewRadio.Checked == true)
                {
                    LoadAppointments(User.UserID);
                    apptWeekViewRadio.Checked = true;
                }
                if (apptMonthViewRadio.Checked == true)
                {
                    LoadAppointments(User.UserID);
                    apptMonthViewRadio.Checked = true;
                }


            }

        }

        private void apptEditButton_Click(object sender, EventArgs e)
        {
            //Require important fields 
            ToolTip toolTip = new ToolTip();

            if (string.IsNullOrWhiteSpace(apptTitleField.Text))
            {
                toolTip.Show("Title is required", apptTitleField);
                return;
            }

            if (string.IsNullOrWhiteSpace(apptTypeComboBox.Text))
            {
                toolTip.Show("Please select a type", apptTypeComboBox);
                return;
            }

            if (string.IsNullOrWhiteSpace(apptCustomerComboBox.Text))
            {
                toolTip.Show("Please select a customer", apptCustomerComboBox);
                return;
            }

            if (apptStartPicker.Value > apptEndPicker.Value){
                toolTip.Show("start time must be before end time", apptStartPicker);
                return;

            }

            else
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
                DataOperations.LogActivity(User.Username, "Edited an appointment with ID " + selectedAppointmentId);


                //see what was checked and reload that data
                if (apptDayViewRadio.Checked == true)
                {
                    LoadAppointments(User.UserID);
                    apptDayViewRadio.Checked = true;
                }
                if (apptWeekViewRadio.Checked == true)
                {
                    LoadAppointments(User.UserID);
                    apptWeekViewRadio.Checked = true;
                }
                if (apptMonthViewRadio.Checked == true)
                {
                    LoadAppointments(User.UserID);
                    apptMonthViewRadio.Checked = true;
                }

            }

        }

        private void apptDeleteButton_Click(object sender, EventArgs e)
        {

            var confirm = MessageBox.Show("Are you sure to delete this item?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                int selectedAppointmentId = int.Parse(apptDataGrid.CurrentRow.Cells[0].Value.ToString());
                DataOperations.DeleteAppointment(selectedAppointmentId);
                DataOperations.LogActivity(User.Username, "Deleted an appointment with ID " + selectedAppointmentId);
            }


            //see what was checked and reload that data
            if (apptDayViewRadio.Checked == true)
            {
                LoadAppointments(User.UserID);
                apptDayViewRadio.Checked = true;
            }
            if (apptWeekViewRadio.Checked == true)
            {
                LoadAppointments(User.UserID);
                apptWeekViewRadio.Checked = true;
            }
            if (apptMonthViewRadio.Checked == true)
            {
                LoadAppointments(User.UserID);
                apptMonthViewRadio.Checked = true;
            }
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
