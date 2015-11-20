using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_user
    {
        public t_user()
        {
            this.t_clinicbooking = new List<t_clinicbooking>();
            this.t_doctorpatient = new List<t_doctorpatient>();
            this.t_doctorpatient1 = new List<t_doctorpatient>();
            this.t_flight = new List<t_flight>();
            this.t_hotelbooking = new List<t_hotelbooking>();
            this.t_medicalrecords = new List<t_medicalrecords>();
            this.t_question = new List<t_question>();
            this.t_surgery = new List<t_surgery>();
            this.t_surgerypatient = new List<t_surgerypatient>();
            this.t_testimony = new List<t_testimony>();
        }

        public string DTYPE { get; set; }
        public int userId { get; set; }
        public string cin { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public Nullable<int> role { get; set; }
        public Nullable<int> sexe { get; set; }
        public Nullable<bool> confirmed { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public Nullable<int> numPassport { get; set; }
        public Nullable<int> state { get; set; }
        public string description { get; set; }
        public string specialty { get; set; }
        public virtual ICollection<t_clinicbooking> t_clinicbooking { get; set; }
        public virtual ICollection<t_doctorpatient> t_doctorpatient { get; set; }
        public virtual ICollection<t_doctorpatient> t_doctorpatient1 { get; set; }
        public virtual ICollection<t_flight> t_flight { get; set; }
        public virtual ICollection<t_hotelbooking> t_hotelbooking { get; set; }
        public virtual ICollection<t_medicalrecords> t_medicalrecords { get; set; }
        public virtual ICollection<t_question> t_question { get; set; }
        public virtual ICollection<t_surgery> t_surgery { get; set; }
        public virtual ICollection<t_surgerypatient> t_surgerypatient { get; set; }
        public virtual ICollection<t_testimony> t_testimony { get; set; }
    }
}
