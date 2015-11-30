using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_clinic
    {
        public t_clinic()
        {
            this.t_clinicbooking = new List<t_clinicbooking>();
        }

        public int clinicId { get; set; }
        [Required(ErrorMessage = "The address of the clinic is required."), Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "The mail is required"), Display(Name = "Mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "The clinic name is required."), Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Phone number")]
        public Nullable<int> phoneNumber { get; set; }
        [Display(Name = "Price Simple")]
        [DataType(DataType.Currency)]
        public Nullable<double> priceSimple { get; set; }
        [Display(Name = "Price Single")]
        [DataType(DataType.Currency)]
        public Nullable<double> priceSingle { get; set; }

        [Display(Name = "Professionalism")]
        public string professionalism { get; set; }
        [Display(Name = "Picture")]
        public string ImgName { get; set; }
        public virtual ICollection<t_clinicbooking> t_clinicbooking { get; set; }
    }
}
