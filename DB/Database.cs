using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewHowardSchedulerApp.DB
{
    public static class Database
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

        public static DataClasses.User Login(string username, string password)
        {
            DataClasses.User user = new DataClasses.User();

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
                            user = null;
                        }
                        else
                        {
                            user.UserID = int.Parse(foundID);
                            user.Username = foundUsername;
                            user.Password = foundPassword;
                            user.CreateDate = (DateTime)foundCreateDate;
                            user.CreatedBy = foundCreatedBy;
                            user.LastUpdated = (DateTime)foundLastUpdate;
                            user.LastUpdatedBy = foundLastUpdateBy;


                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex);
            }

            Disconnect();
            return user;

        }

        public static DataTable GetAppointments(int userID)
        {
            DataTable appoinmentsTable = new DataTable();

            //Add columns to datatable
            if (!appoinmentsTable.Columns.Contains("Title")) { appoinmentsTable.Columns.Add("Title", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Customer")) { appoinmentsTable.Columns.Add("Customer", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Type")) { appoinmentsTable.Columns.Add("Type", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("Start")) { appoinmentsTable.Columns.Add("Start", typeof(string)); }
            if (!appoinmentsTable.Columns.Contains("End")) { appoinmentsTable.Columns.Add("End", typeof(string)); }

            try
            {

                Connect();
                var selectAppointment = "select appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userID + "';";
                MySqlCommand command = new MySqlCommand(selectAppointment, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appoinmentsTable.Rows.Add(reader["title"], reader["customerName"], reader["type"], reader["start"], reader["end"]);
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

    }
}
