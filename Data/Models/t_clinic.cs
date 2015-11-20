using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_clinic
    {
        public t_clinic()
        {
            this.t_clinicbooking = new List<t_clinicbooking>();
        }

        public int clinicId { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Nullable<int> phoneNumber { get; set; }
        public Nullable<double> priceSimple { get; set; }
        public Nullable<double> priceSingle { get; set; }
        public string professionalism { get; set; }
        public virtual ICollection<t_clinicbooking> t_clinicbooking { get; set; }
    }
}
