using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_doctorpatient
    {
        public t_doctorpatient()
        {
            this.t_booking = new List<t_booking>();
        }

        public int doctorId { get; set; }
        public int patientId { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_user t_user { get; set; }
        public virtual t_user t_user1 { get; set; }
    }
}
