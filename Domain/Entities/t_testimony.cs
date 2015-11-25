using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class t_testimony
    {
        
        public int testimonyId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string title { get; set; }
        [StringLength(255, MinimumLength = 5)]
        [Required]
        public string description { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
