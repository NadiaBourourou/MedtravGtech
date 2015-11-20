using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_flight
    {
        public t_flight()
        {
            this.t_booking = new List<t_booking>();
        }

        public int flightId { get; set; }
        public string airline { get; set; }
        public string arrivalDate { get; set; }
        public string arrivalLocation { get; set; }
        public string departureDate { get; set; }
        public string departureLocation { get; set; }
        public Nullable<int> nbSits { get; set; }
        public string numFlight { get; set; }
        public Nullable<double> price { get; set; }
        public string timeFlightMatchingArr { get; set; }
        public string timeFlightMatchingDep { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
