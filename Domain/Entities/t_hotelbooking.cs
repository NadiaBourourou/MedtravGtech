using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_hotelbooking
    {
        public t_hotelbooking()
        {
            this.t_booking = new List<t_booking>();
        }

        public int hotelId { get; set; }
        public int patientId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> numNights { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> roomType { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_hotel t_hotel { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
