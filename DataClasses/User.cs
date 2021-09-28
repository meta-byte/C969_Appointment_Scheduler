using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewHowardSchedulerApp.DataClasses
{
    public static class User
    {
        //private
        private static int userID;
        private static string username;
        private static string password;
        private static bool active;
        private static DateTime createDate;
        private static string createdBy;
        private static DateTime lastUpdate;
        private static string lastUpdateBy;

        //public
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static bool Active { get; set; }
        public static DateTime CreateDate { get; set; }
        public static string CreatedBy { get; set; }
        public static DateTime LastUpdated { get; set; }
        public static string LastUpdatedBy { get; set; }


        //public static User(int userID, string username, string password, bool active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        //{
        //    UserID = userID;
        //    Username = username;
        //    Password = password;
        //    Active = active;
        //    CreateDate = createDate;
        //    CreatedBy = createdBy;
        //    LastUpdated = lastUpdate;
        //    LastUpdatedBy = lastUpdateBy;
        //}
    }


}
