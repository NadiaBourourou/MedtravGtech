using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_question
    {
        public int questionId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string response { get; set; }
        public string title { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
