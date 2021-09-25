﻿using System;
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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments Appointments = new Appointments();
            Appointments.ShowDialog();
            this.Close();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers Customers = new Customers();
            Customers.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}