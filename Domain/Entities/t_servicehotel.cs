using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_servicehotel
    {
        public int serviceHotelId { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Nullable<int> hotel_hotelId { get; set; }
        public virtual t_hotel t_hotel { get; set; }
    }
}
