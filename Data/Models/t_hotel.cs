using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_hotel
    {
        public t_hotel()
        {
            this.t_servicehotel = new List<t_servicehotel>();
            this.t_hotelbooking = new List<t_hotelbooking>();
        }

        public int hotelId { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Nullable<double> priceSingle { get; set; }
        public Nullable<double> priceSuite { get; set; }
        public Nullable<int> stars { get; set; }
        public Nullable<int> state { get; set; }
        public virtual ICollection<t_servicehotel> t_servicehotel { get; set; }
        public virtual ICollection<t_hotelbooking> t_hotelbooking { get; set; }
    }
}
