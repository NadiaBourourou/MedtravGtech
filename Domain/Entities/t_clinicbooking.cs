using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_clinicbooking
    {
        public t_clinicbooking()
        {
            this.t_booking = new List<t_booking>();
        }

        public int clinicId { get; set; }
        public int patientId { get; set; }
        public string commentaire { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<TypeRoom> typeRoom { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_clinic t_clinic { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
