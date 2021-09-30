using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewHowardSchedulerApp
{
    public class City
    {
        //private
        private int cityID;
        private string city;
        private int countryID;
        private DateTime createDate;
        private string createdBy;
        private DateTime lastUpdate;
        private string lastUpdateBy;

        //public
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public City()
        {

        }

        public City(int cityID, string cityName, int countryID, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CityID = cityID;
            CityName = cityName;
            CountryID = countryID;
            CreatedDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}
