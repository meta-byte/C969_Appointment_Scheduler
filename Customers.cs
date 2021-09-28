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
    public partial class Customers : Form
    {
        public Customers(int userID)
        {
            InitializeComponent();
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            var customerTable = DataOperations.GetCustomers();
            var customerSource = new BindingSource();
            customerSource.DataSource = customerTable;

            custDataGrid.RowHeadersVisible = false;
            custDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            custDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            custDataGrid.MultiSelect = false;
            custDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
            custDataGrid.DataSource = null;
            custDataGrid.DataSource = customerSource;


        }
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {

            int currentUser = User.UserID;
            this.Hide();
            Appointments Appointments = new Appointments(currentUser);
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
