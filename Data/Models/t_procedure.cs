using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_procedure
    {
        public t_procedure()
        {
            this.t_surgery = new List<t_surgery>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<t_surgery> t_surgery { get; set; }
    }
}
