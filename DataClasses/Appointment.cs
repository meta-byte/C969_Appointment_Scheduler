using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewHowardSchedulerApp.DataClasses
{
    public class Appointment
    {
        //private
        private int appointmentID;
        private int customerID;
        private int userID;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string type;
        private string url;
        private DateTime start;
        private DateTime end;
        private DateTime createDate;
        private string createdBy;
        private DateTime lastUpdate;
        private string lastUpdateBy;


        //public
        public int AppointmentID;
        public int CustomerID;
        public int UserID;
        public string Title;
        public string Description;
        public string Location;
        public string Contact;
        public string Type;
        public string Url;
        public DateTime Start;
        public DateTime End;
        public DateTime CreateDate;
        public string CreatedBy;
        public DateTime LastUpdate;
        public string LastUpdateBy;


        public Appointment(int appointmentID, int customerID, int userID, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            AppointmentID = appointmentID;
            CustomerID = customerID;
            UserID = userID;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            Url = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;

        }
    }
}
