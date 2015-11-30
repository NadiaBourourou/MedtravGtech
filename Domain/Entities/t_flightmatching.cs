using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Data.Models
{
    public partial class t_flightmatching
    {
        public int idFlightMatching { get; set; }

        [Display(Name = "Airline")]
        public string airline { get; set; }

        [Display(Name = "Arrival location")]
        public string arrival { get; set; }

        [Display(Name = "Arrival date")]
        public string dateFlightMatchingArr { get; set; }

        [Display(Name = "Departure date")]
        public string dateFlightMatchingDep { get; set; }

        [Display(Name = "Departure location")]
        public string departure { get; set; }

        [Display(Name = "Flight number")]
        public string numFlight { get; set; }
        public Nullable<int> numberOfSits { get; set; }

        [Display(Name = "Price")]
        public Nullable<double> price { get; set; }

        [Display(Name = "Arrival time")]
        public string timeFlightMatchingArr { get; set; }

        [Display(Name = "Departure time")]
        public string timeFlightMatchingDep { get; set; }

        public static explicit operator t_flightmatching(List<IGrouping<string, t_flightmatching>> v)
        {
            throw new NotImplementedException();
        }
    }
}
