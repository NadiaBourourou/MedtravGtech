using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            this.t_tip = new List<t_tip>();
        }

        public string DTYPE { get; set; }
        public int userId { get; set; }
        [Required(ErrorMessage = "The patient CIN is required."), Display(Name = "C.I.N.")]
        public string cin { get; set; }
        [Required(ErrorMessage = "The patient name is required."), Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "The patient name is required."), Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "The user name is required."), Display(Name = "User Name")]
        public string login { get; set; }
        [Required(ErrorMessage = "The patient mail is required. We need it to contact you."), Display(Name = "Mail")]
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }
        [Required(ErrorMessage = "The patient password is required.  You will need it to login."), Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public Nullable<int> role { get; set; }
        [Display(Name = "Sexe")]
        public SexeType? sexe { get; set; }
        public Nullable<bool> confirmed { get; set; }
       
        public string ImageName { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        [Display(Name = "Passport")]
     
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
        public virtual ICollection<t_tip> t_tip { get; set; }

    }
}
