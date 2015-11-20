using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_surgery
    {
        public t_surgery()
        {
            this.t_surgerypatient = new List<t_surgerypatient>();
        }

        public int surgeryId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> doctor_userId { get; set; }
        public Nullable<int> procedure_id { get; set; }
        public virtual t_procedure t_procedure { get; set; }
        public virtual ICollection<t_surgerypatient> t_surgerypatient { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
