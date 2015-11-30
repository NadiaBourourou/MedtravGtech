using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> numNights { get; set; }

        public Nullable<double> price { get; set; }
        public Nullable<RoomType> roomType { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_hotel t_hotel { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
