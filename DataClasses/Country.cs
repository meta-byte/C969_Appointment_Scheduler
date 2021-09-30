using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewHowardSchedulerApp.DataClasses
{
    public class Country
    {
        //private
        private int countryID;
        private string country;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        //public
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Country()
        {

        }

        public Country(int countryID, string country, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CountryID = countryID;
            CountryName = country;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}
