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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            var user = new DataClasses.User();

            this.Hide();
            Appointments Appointments = new Appointments(user);
            Appointments.ShowDialog();
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
    }
}
