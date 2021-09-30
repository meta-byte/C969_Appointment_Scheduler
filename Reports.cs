using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using AndrewHowardSchedulerApp.DataClasses;
using AndrewHowardSchedulerApp.DB;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndrewHowardSchedulerApp
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            LoadReports();
        }

        public void LoadReports()
        {
            var userTable = DataOperations.GetUsers();
            var userList = (from DataRow row in userTable.Rows select row["UserName"]).ToList();
            rptUserComboBox.DataSource = userList;
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            int currentUser = User.UserID;
            this.Hide();
            Appointments Appointments = new Appointments(currentUser);
            Appointments.ShowDialog();
            this.Close();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            int currentUser = User.UserID;
            this.Hide();
            Customers Customers = new Customers(currentUser);
            Customers.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rptAppointmentTypesRadio_CheckedChanged(object sender, EventArgs e)
        {
            rptTextBox.Text = string.Empty;
            var report = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                List<string> list = DataOperations.GetApptsByMonth(User.UserID, i);
                report.AppendLine(Environment.NewLine + DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
                var query = from type in list
                        group type by type into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };

                foreach (var type in query)
                {
                    report.AppendLine("     " + type.Value + ": "+ type.Count);
                }
            }

            rptTextBox.Text = report.ToString();
        }

        private void rptConsultantScheduleRadio_CheckedChanged(object sender, EventArgs e)
        {
            rptTextBox.Text = string.Empty;
            var report = new StringBuilder();
            string user = rptUserComboBox.Text;
            int userId = int.Parse(DataOperations.GetUserId(user));
            List<Appointment> appts = DataOperations.GetUserAppts(userId);

            
            //var query = from appt in appts
            //            group appt by appt into g
            //            let count = g.Count()
            //            orderby count descending
            //            select new { Value = g.Key, Count = count };

            foreach (var appt in appts)
            {
                report.AppendLine(appt.Title + Environment.NewLine + "     " + appt.Start + Environment.NewLine + "     " + appt.End + Environment.NewLine);
            }

            rptTextBox.Text = report.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
