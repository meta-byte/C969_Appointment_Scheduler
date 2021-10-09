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
        private const string server = "127.0.0.1";
        private const string database = "client_schedule";
        private const string username = "sqlUser";
        private const string password = "Passw0rd!";
        private const string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "Uid=" + username + ";" + "password =" + password + ";" + "SslMode=None";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        //public

        //Remember to try and catch here
        public static void Connect()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return;
        }

        public static void Disconnect()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
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

        public static DataTable GetAppointmentsMonth(int userID)
        {
            DataTable appoinmentsTable = new DataTable();
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

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
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "' and month(start) = " + month + " and year(start) = " + year + ";";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appoinmentsTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime(), Convert.ToDateTime(reader["end"]).ToLocalTime());
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

        public static DataTable GetAppointmentsWeek(int userID)
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
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "' and yearweek(start) =  yearweek(current_date);";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appoinmentsTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime(), Convert.ToDateTime(reader["end"]).ToLocalTime());
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

        public static DataTable GetAppointmentsDay(int userID)
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
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "' and date(start) = utc_date();";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appoinmentsTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime() , Convert.ToDateTime(reader["end"]).ToLocalTime()); ;
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

        public static bool AppointmentsFifteenMinutes(int userID)
        {

            try
            {

                Connect();
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "' and start between utc_timestamp() and (utc_timestamp() + interval 15 minute);";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error getting fifteen minute appointments: " + ex);
            }

            Disconnect();
            return false;
        }

        public static bool OverlapAppointments(int userID, DateTime start, DateTime end)
        {
            string startTime = start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string endTime = end.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            try
            {

                Connect();
                var selectAppointment = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where start <= '" + endTime + "' AND end >= '" + startTime + "' and userId = '" + userID + "' ;";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error checking overlapping appointments: " + ex);
            }

            Disconnect();
            return false;
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
            string createDate = DateTime.Now.ToLocalTime().ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
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
                var selectCustomer = "select customerId from customer where customerName = '" + name + "';";

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

        public static void AddCustomer(Customer customer)
        {
            string customerName = customer.CustomerName;
            int addressId = customer.AddressID;
            int active = customer.Active;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.Username;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var insertCustomer = "insert into customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + customerName + "', '" + addressId + "', '" + active + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "' );";
                MySqlCommand command = new MySqlCommand(insertCustomer, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding customer: " + ex);

            }
            Disconnect();
        }

        public static void EditCustomer(Customer customer)
        {
            int customerId = customer.CustomerID;
            string customerName = customer.CustomerName;
            int addressId = customer.AddressID;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var updateCustomer = "update customer set customerName = '" + customerName + "', addressId = '" + addressId + "', lastUpdate = '" + lastUpdate + "', lastUpdateBy = '" + lastUpdateBy + "' where customerId = '" + customerId + "';";
                MySqlCommand command = new MySqlCommand(updateCustomer, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating customer: " + ex);

            }
            Disconnect();
        }

        public static void DeleteCustomer(int customerId)
        {

            try
            {
                Connect();
                var deleteCustomer = "delete from customer where customerId = '" + customerId + "';";
                MySqlCommand command = new MySqlCommand(deleteCustomer, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting customer: " + ex);

            }
            Disconnect();
        }

        public static void AddCountry(Country country)
        {
            string countryName = country.CountryName;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.Username;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var insertCountry = "insert into country(country, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + countryName + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "' );";
                MySqlCommand command = new MySqlCommand(insertCountry, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding country: " + ex);

            }
            Disconnect();
        }

        public static string GetCountry(string countryName)
        {
            string countryID = "0";

            try
            {
                Connect();
                var selectCountry = "select countryId from country where country = '" + countryName + "';";

                MySqlCommand command = new MySqlCommand(selectCountry, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countryID = reader["countryId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting countryId: " + ex);

            }

            Disconnect();
            return countryID;
        }

        public static void AddCity(City city)
        {
            string cityName = city.CityName;
            int countryId = city.CountryID;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.Username;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var insertCity = "insert into city(city, countryId, createDate,  createdBy, lastUpdate, lastUpdateBy) values('" + cityName + "', '" + countryId + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "' );";
                MySqlCommand command = new MySqlCommand(insertCity, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding city: " + ex);

            }
            Disconnect();
        }

        public static string GetCity(string city)
        {
            string cityId = "0";

            try
            {
                Connect();
                var selectCity = "select cityId from city where city = '" + city + "';";

                MySqlCommand command = new MySqlCommand(selectCity, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cityId = reader["cityId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting cityId: " + ex);

            }

            Disconnect();
            return cityId;
        }

        public static void AddAddress(Address address)
        {
            string address1 = address.Address1;
            string address2 = address.Address2;
            int cityId = address.CityID;
            string postalCode = address.PostalCode;
            string phone = address.Phone;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.Username;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var insertAddress = "insert into address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + address1 + "', '" + address2 + "', '" + cityId + "', '" + postalCode + "', '" + phone + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "' );";
                MySqlCommand command = new MySqlCommand(insertAddress, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding address: " + ex);

            }
            Disconnect();
        }

        public static void EditAddress(Address address)
        {
            int addressId = address.AddressID;
            string address1 = address.Address1;
            string address2 = address.Address2;
            int cityId = address.CityID;
            string postalCode = address.PostalCode;
            string phone = address.Phone;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.Username;

            try
            {
                Connect();
                var updateAddress = "update address set address = '" + address1 + "', address2 = '" + address2 + "', cityId = '" + cityId + "', postalCode = '" + postalCode + "', phone = '" + phone + "', lastUpdate = '" + lastUpdate + "', lastUpdateBy = '" + lastUpdateBy + "' where addressId = '" + addressId + "';";
                MySqlCommand command = new MySqlCommand(updateAddress, connection);
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating address: " + ex);

            }
            Disconnect();
        }

        public static string GetAddress(string address)
        {
            string addressId = "0";

            try
            {
                Connect();
                var selectAddress = "select addressId from address where address = '" + address + "';";

                MySqlCommand command = new MySqlCommand(selectAddress, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        addressId = reader["addressId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting addressId: " + ex);

            }

            Disconnect();
            return addressId;
        }

        public static DataTable GetUsers()
        {
            DataTable usersTable = new DataTable();

            //Add columns to datatable
            if (!usersTable.Columns.Contains("ID")) { usersTable.Columns.Add("ID", typeof(string)); }
            if (!usersTable.Columns.Contains("UserName")) { usersTable.Columns.Add("UserName", typeof(string)); }


            try
            {

                Connect();
                var selectUsers = "select * from user;";
                MySqlCommand command = new MySqlCommand(selectUsers, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usersTable.Rows.Add(reader["userId"], reader["userName"]);
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error getting users: " + ex);
            }

            Disconnect();
            return usersTable;
        }

        public static string GetUserId(string userName)
        {
            string userId = "0";

            try
            {
                Connect();
                var selectUser = "select userId from user where userName = '" + userName + "';";

                MySqlCommand command = new MySqlCommand(selectUser, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userId = reader["userId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting userId: " + ex);

            }

            Disconnect();
            return userId;
        }

        public static void LogActivity(string username, string text)
        {
            DirectoryInfo info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string path = info + "\\log.txt";
            Console.WriteLine(path);

            string log = username + " : " + text + " : " + DateTime.Now.ToString();
            try
            {

                if (!File.Exists(path))
                {
                    using (StreamWriter writer = File.CreateText(path))
                    {
                        writer.WriteLine(log);
                        writer.Close();

                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.WriteLine(log);
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing log: " + ex);

            }
            Disconnect();

        }

        public static List<string> GetApptsByMonth(int userId, int month)
        {
            List<string> apptTypesList = new List<string>();

            try
            {
                Connect();

                var selectApptTypes = "select type, count(type) from appointment where userId = '" + userId + "' and month(start) = '" + month + "';";
                MySqlCommand command = new MySqlCommand(selectApptTypes, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string typeCount = reader["type"].ToString() + ":" + reader["count(type)"].ToString();
                    apptTypesList.Add(typeCount);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error getting appointments " + ex);
            }

            Disconnect();
            return apptTypesList;
        }

        public static List<Appointment> GetUserAppts(int userId)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                Connect();

                var selectApptTypes = "select title, start, end from appointment where userId = '" + userId + "';";
                MySqlCommand command = new MySqlCommand(selectApptTypes, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointments.Add(new Appointment()
                    {
                        Title = reader["title"].ToString(),
                        Start = Convert.ToDateTime(reader["start"]).ToLocalTime(),
                        End = Convert.ToDateTime(reader["end"]).ToLocalTime()
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting user appointments " + ex);
            }

            Disconnect();
            return appointments;
        }

        public static List<string> GetApptCountsCustomer()
        {
            List<string> custApptList = new List<string>();

            try
            {
                Connect();

                var selectCustAppts = "select customer.customerName as customer , count(appointment.appointmentId) as count from appointment join customer on appointment.customerId = customer.customerId group by customer.customerName;";
                MySqlCommand command = new MySqlCommand(selectCustAppts, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string customer = reader["customer"].ToString() + ": " + reader["count"].ToString();
                    custApptList.Add(customer);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" error getting appt count " + ex);
            }

            Disconnect();
            return custApptList;
        }

    }

}



