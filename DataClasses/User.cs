using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewHowardSchedulerApp.DataClasses
{
    public class User
    {
        //private
        private int userID;
        private string username;
        private string password;
        private bool active;
        private DateTime createDate;
        private string createdBy;
        private DateTime lastUpdate;
        private string lastUpdateBy;

        //public
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }

        public User(int userID, string username, string password, bool active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdate;
            LastUpdatedBy = lastUpdateBy;
        }
    }


}
