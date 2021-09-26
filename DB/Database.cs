using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static DataClasses.User Login(string username, string password)
        {
            DataClasses.User user = new DataClasses.User();

            Connect();
            var selectUser = "SELECT * FROM user WHERE userName='" + username + "' AND password='" + password + "';";
            MySqlCommand cmd = new MySqlCommand(selectUser, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows){
                while (rdr.Read())
                {
                    var foundID = rdr["userId"].ToString();
                    var foundUsername = rdr["userName"].ToString();
                    var foundPassword = rdr["password"].ToString();
                    var foundCreateDate = rdr["createDate"];
                    var foundCreatedBy = rdr["createdBy"].ToString();
                    var foundLastUpdate = rdr["lastUpdate"];
                    var foundLastUpdateBy = rdr["lastUpdateBy"].ToString();


                    if (foundUsername != username || foundPassword != password)
                    {
                        user = null;
                        return user;
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

                        return user;
                    }

                }
            }

            user = null;
            return user; 
        }

        public static void GetAppointments(string userID)
        {
            Connect();
            var selectAppointment = "select * from appointment where userId = '" + userID + "';";
            MySqlCommand cmd = new MySqlCommand(selectAppointment, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            
            
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                }
            }

        }

    }
}
