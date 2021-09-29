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

            var countriesTable = DataOperations.GetCountries();
            var countriesList = (from DataRow row in countriesTable.Rows select row["Country"]).ToList();
            custCountryComboBox.DataSource = countriesList;

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

        private void custAddButton_Click(object sender, EventArgs e)
        {
            string selectedCity = custCityComboBox.SelectedItem.ToString();
            int cityId = int.Parse(DataOperations.GetCity(selectedCity));

            Address address = new Address();

            address.Address1 = custAddressField.Text;
            address.Address2 = custAddressFieldTwo.Text;
            address.PostalCode = custZipField.Text;
            address.Phone = custPhoneField.Text;
            address.CityID = cityId;

            DataOperations.AddAddress(address);
            int addressId = int.Parse(DataOperations.GetAddress(address.Address1));

            Customer customer = new Customer();

            customer.CustomerName = custNameField.Text;
            customer.AddressID = addressId;
            customer.Active = 1;


            DataOperations.AddCustomer(customer);

            LoadCustomers();
        }

        private void custEditButton_Click(object sender, EventArgs e)
        {

        }

        private void custDeleteButton_Click(object sender, EventArgs e)
        {
            string customerName = custDataGrid.CurrentRow.Cells[1].Value.ToString();
            int.TryParse(DataOperations.GetCustomer(customerName), out int customerID);

            DataOperations.DeleteCustomer(customerID);

        }

        private void custCountryBox_SelectionChanged(object sender, EventArgs e)
        {
            string selectedCountry = custCountryComboBox.SelectedItem.ToString();
            int countryId = int.Parse(DataOperations.GetCountry(selectedCountry));

            var citiesTable = DataOperations.GetCities(countryId);
            var citiesList = (from DataRow row in citiesTable.Rows select row["City"]).ToList();
            custCityComboBox.DataSource = citiesList;
        }

    }
}
