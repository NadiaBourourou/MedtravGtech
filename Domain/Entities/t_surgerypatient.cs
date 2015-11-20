using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_surgerypatient
    {
        public t_surgerypatient()
        {
            this.t_booking = new List<t_booking>();
        }

        public int idPatient { get; set; }
        public int idSurgery { get; set; }
        public string commentaire { get; set; }
        public string price { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_surgery t_surgery { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
