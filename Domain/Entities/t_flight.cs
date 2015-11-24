using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_flight
    {
        public t_flight()
        {
            this.t_booking = new List<t_booking>();
        }

        public int flightId { get; set; }
        public string airline { get; set; }

        [Display(Name = "Arrival date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public string arrivalDate { get; set; }

        [Display(Name = "To")]
        [Required]
        public string arrivalLocation { get; set; }

        [Display(Name = "Departure date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public string departureDate { get; set; }

        [Display(Name = "From")]
        [Required]
        public string departureLocation { get; set; }

        [Display(Name = "Number of sits")]
        [Required]
        public Nullable<int> nbSits { get; set; }
        public string numFlight { get; set; }
        public Nullable<double> price { get; set; }
        public string timeFlightMatchingArr { get; set; }
        public string timeFlightMatchingDep { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
