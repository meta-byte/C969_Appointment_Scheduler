using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AndrewHowardSchedulerApp.DataClasses;

namespace AndrewHowardSchedulerApp.DB
{
    public static class DataOperations
    {
        //private
        private const string server = "localhost";
        private const string database = "client_schedule";
        private const string username = "sqlUser";
        private const string password = "passw0rd!";
        private const string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "Uid=" + username+ ";" + "password =" + password + ";" + "SslMode=None";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        //public

        //Remember to try and catch here
        public static void Connect()
        {
            if(connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return;
        }

        public static void Disconnect()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
            return;
        }

        public static void Login(string username, string password)
        {
            
            try
            {

                Connect();
                var selectUser = "SELECT * FROM user WHERE userName='" + username + "' AND password='" + password + "';";
                MySqlCommand command = new MySqlCommand(selectUser, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var foundID = reader["userId"].ToString();
                        var foundUsername = reader["userName"].ToString();
                        var foundPassword = reader["password"].ToString();
                        var foundCreateDate = reader["createDate"];
                        var foundCreatedBy = reader["createdBy"].ToString();
                        var foundLastUpdate = reader["lastUpdate"];
                        var foundLastUpdateBy = reader["lastUpdateBy"].ToString();


                        if (foundUsername != username || foundPassword != password)
                        {
                            User.UserID = 0;

                            return;
                        }
                        else
                        {
                            User.UserID = int.Parse(foundID);
                            User.Username = foundUsername;
                            User.Password = foundPassword;
                            User.CreateDate = (DateTime)foundCreateDate;
                            User.CreatedBy = foundCreatedBy;
                            User.LastUpdated = (DateTime)foundLastUpdate;
                            User.LastUpdatedBy = foundLastUpdateBy;


                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex);
            }

            Disconnect();
            return;

        }

        public static DataTable GetAppointments(int userID)
        {
            DataTable appoinmentsTable = new DataTable();

            //Add columns to datatable
            if (!appoinmentsTable.Columns.Contains("ID")) { appoinmentsTable.Columns.Add("ID", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Title")) { appoinmentsTable.Columns.Add("Title", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Customer")) { appoinmentsTable.Columns.Add("Customer", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Type")) { appoinmentsTable.Columns.Add("Type", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Start")) { appoinmentsTable.Columns.Add("Start", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("End")) { appoinmentsTable.Columns.Add("End", typeof(string)); }

            try
            {

                Connect();
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "';";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appoinmentsTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], reader["start"], reader["end"]);
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error getting appointments: " + ex);
            }

            Disconnect();
            return appoinmentsTable;
        }

        public static void AddAppointment(Appointment appointment)
        {
            int customerId = appointment.CustomerID;
            int userId = User.UserID;
            string title = appointment.Title;
            string description = appointment.Description;
            string location = appointment.Location;
            string contact = appointment.Contact;
            string type = appointment.Type;
            string url = appointment.Url;
            string start = appointment.Start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string end = appointment.End.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.Username;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;
            try
            {
                Connect();
                var insertAppointment = "insert into appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + customerId + "', '" + userId + "', '" + title + "', '" + description + "','" + location + "', '" + contact + "', '" + type + "', '" + url + "', '" + start + "', '" + end + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "' );";
                MySqlCommand command = new MySqlCommand(insertAppointment, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding appointment: " + ex);

            }
            Disconnect();
        }

        public static void EditAppointment(Appointment appointment)
        {
            int appointmentId = appointment.AppointmentID;
            int customerId = appointment.CustomerID;
            int userId = User.UserID;
            string title = appointment.Title;
            string description = appointment.Description;
            string location = appointment.Location;
            string contact = appointment.Contact;
            string type = appointment.Type;
            string url = appointment.Url;
            string start = appointment.Start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string end = appointment.End.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;
            try
            {
                Connect();
                var updateAppointment = "update appointment set customerId = '" + customerId + "', userId = '" + userId + "', title = '" + title + "', description = '" + description + "', location = '" + location + "', contact = '" + contact + "', url = '" + url + "', start = '" + start + "', end = '" + end + "', lastUpdate = '" + lastUpdate + "', lastUpdateBy = '" + lastUpdateBy + "' where appointmentId = '" + appointmentId + "';";
                MySqlCommand command = new MySqlCommand(updateAppointment, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating appointment: " + ex);

            }
            Disconnect();
        }

        public static void DeleteAppointment(int appointmentId)
        {

            try
            {
                Connect();
                var deleteAppointment = "delete from appointment where appointmentId = '" + appointmentId + "';";
                MySqlCommand command = new MySqlCommand(deleteAppointment, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting appointment: " + ex);

            }
            Disconnect();
        }

        public static string GetCustomer(string name)
        {
            string customerID = null;

            try
            {
                Connect();
                var selectCustomer = "select customerId from customer where customerName = '"+ name +"';";

                MySqlCommand command = new MySqlCommand(selectCustomer, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerID = reader["customerId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting customerId: " + ex);

            }

            Disconnect();
            return customerID;
        }

        public static DataTable GetCustomers()
        {
            DataTable customersTable = new DataTable();

            //Add columns to datatable
            if (!customersTable.Columns.Contains("ID")) { customersTable.Columns.Add("ID", typeof(string)); }
            if (!customersTable.Columns.Contains("Name")) { customersTable.Columns.Add("Name", typeof(string)); }
            if (!customersTable.Columns.Contains("Address")) { customersTable.Columns.Add("Address", typeof(string)); }
            if (!customersTable.Columns.Contains("Address_Cont")) { customersTable.Columns.Add("Address_Cont", typeof(string)); }
            if (!customersTable.Columns.Contains("City")) { customersTable.Columns.Add("City", typeof(string)); }
            if (!customersTable.Columns.Contains("Postal Code")) { customersTable.Columns.Add("Postal Code", typeof(string)); }
            if (!customersTable.Columns.Contains("Country")) { customersTable.Columns.Add("Country", typeof(string)); }
            if (!customersTable.Columns.Contains("Phone")) { customersTable.Columns.Add("Phone", typeof(string)); }

            try
            {

                Connect();
                var selectCustomer = "select customer.customerId, customer.customerName, address.address, address.address2, city.city, address.postalCode, country.country, address.phone from customer join address on customer.addressId = address.addressId join city on address.cityId = city.cityId join country on city.countryId = country.countryId; ";
                MySqlCommand command = new MySqlCommand(selectCustomer, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customersTable.Rows.Add(reader["customerId"], reader["customerName"], reader["address"], reader["address2"], reader["city"], reader["postalCode"], reader["country"], reader["phone"]);
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error getting appointments: " + ex);
            }

            Disconnect();
            return customersTable;
        }



    }

}

