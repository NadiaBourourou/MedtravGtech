using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_flightmatching
    {
        public int idFlightMatching { get; set; }
        public string airline { get; set; }
        public string arrival { get; set; }
        public string dateFlightMatchingArr { get; set; }
        public string dateFlightMatchingDep { get; set; }
        public string departure { get; set; }
        public string numFlight { get; set; }
        public Nullable<int> numberOfSits { get; set; }
        public Nullable<double> price { get; set; }
        public string timeFlightMatchingArr { get; set; }
        public string timeFlightMatchingDep { get; set; }
    }
}
