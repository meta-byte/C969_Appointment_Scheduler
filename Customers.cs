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

        private void custAddButton_Click(object sender, EventArgs e)
        {
            //Find or add country
            string countryName = custCountryField.Text.ToString();
            Country country = new Country();
            country.CountryName = countryName;
            int countryId = int.Parse(DataOperations.GetCountry(countryName));
            if (countryId == 0)
            {
                DataOperations.AddCountry(country);

            }

            //Find or add city
            string cityName = custCityField.Text.ToString();
            City city = new City();
            countryId = int.Parse(DataOperations.GetCountry(countryName));
            city.CityName = cityName;
            city.CountryID = countryId;
            int cityId = int.Parse(DataOperations.GetCity(cityName));
            if (cityId == 0)
            {
                DataOperations.AddCity(city);
            }


            //Find or add address
            Address address = new Address();
            cityId = int.Parse(DataOperations.GetCity(cityName));
            string customerAddress = custAddressField.Text.ToString();
            address.Address1 = custAddressField.Text;
            address.Address2 = custAddressFieldTwo.Text;
            address.PostalCode = custZipField.Text;
            address.Phone = custPhoneField.Text;
            address.CityID = cityId;
            int addressId = int.Parse(DataOperations.GetAddress(customerAddress));
            if (addressId == 0)
            {
                DataOperations.AddAddress(address);
            }

            //Add the customer
            addressId = int.Parse(DataOperations.GetAddress(customerAddress));
            Customer customer = new Customer();
            customer.CustomerName = custNameField.Text;
            customer.AddressID = addressId;
            DataOperations.AddCustomer(customer);

            DataOperations.LogActivity(User.Username, "Added customer " + customer.CustomerName);


            LoadCustomers();
        }

        private void custEditButton_Click(object sender, EventArgs e)
        {
            //Find or add country
            string countryName = custCountryField.Text.ToString();
            Country country = new Country();
            country.CountryName = countryName;
            int countryId = int.Parse(DataOperations.GetCountry(countryName));
            if (countryId == 0)
            {
                DataOperations.AddCountry(country);

            }

            //Find or add city
            string cityName = custCityField.Text.ToString();
            City city = new City();
            countryId = int.Parse(DataOperations.GetCountry(countryName));
            city.CityName = cityName;
            city.CountryID = countryId;
            int cityId = int.Parse(DataOperations.GetCity(cityName));
            if (cityId == 0)
            {
                DataOperations.AddCity(city);
            }

            //Find or add address
            Address address = new Address();
            cityId = int.Parse(DataOperations.GetCity(cityName));
            string customerAddress = custAddressField.Text.ToString();
            address.Address1 = custAddressField.Text;
            address.Address2 = custAddressFieldTwo.Text;
            address.PostalCode = custZipField.Text;
            address.Phone = custPhoneField.Text;
            address.CityID = cityId;
            int addressId = int.Parse(DataOperations.GetAddress(customerAddress));
            if (addressId == 0)
            {
                DataOperations.AddAddress(address);
            }


            //Edit the customer
            var customerId = custDataGrid.CurrentRow.Cells[0].Value;
            addressId = int.Parse(DataOperations.GetAddress(customerAddress));
            Customer customer = new Customer();
            customer.CustomerID = int.Parse((string)customerId);
            customer.CustomerName = custNameField.Text;
            customer.AddressID = addressId;
            DataOperations.EditCustomer(customer);

            DataOperations.LogActivity(User.Username, "Edited customer " + customer.CustomerName);


            LoadCustomers();

        }

        private void custDeleteButton_Click(object sender, EventArgs e)
        {
            int customerID = int.Parse(custDataGrid.CurrentRow.Cells[0].Value.ToString());

            DataOperations.DeleteCustomer(customerID);
            DataOperations.LogActivity(User.Username, "Deleted customer with ID " + customerID);

            LoadCustomers();
        }

        private void custDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            custNameField.Text = custDataGrid.CurrentRow.Cells[1].Value.ToString();
            custAddressField.Text = custDataGrid.CurrentRow.Cells[2].Value.ToString();
            custAddressFieldTwo.Text = custDataGrid.CurrentRow.Cells[3].Value.ToString();
            custCityField.Text = custDataGrid.CurrentRow.Cells[4].Value.ToString();
            custZipField.Text = custDataGrid.CurrentRow.Cells[5].Value.ToString();
            custCountryField.Text = custDataGrid.CurrentRow.Cells[6].Value.ToString();
            custPhoneField.Text = custDataGrid.CurrentRow.Cells[7].Value.ToString();

        }

    }
}
