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

        [Display(Name = "Flight ID")]
        public int flightId { get; set; }

        [Display(Name = "Airline")]
        public string airline { get; set; }

        [Display(Name = "Arrival date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The arrival date is required")]
        public string arrivalDate { get; set; }

        [Display(Name = "Arrival location")]
        [Required(ErrorMessage = "The arrival location is required")]
        public string arrivalLocation { get; set; }

        [Display(Name = "Departure date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The departure date is required")]
        public string departureDate { get; set; }

        [Display(Name = "Departure location")]
        [Required(ErrorMessage = "The departure location is required")]
        public string departureLocation { get; set; }

        [Display(Name = "Number of sits")]
        [Required(ErrorMessage = "The number of sits is required")]
        public Nullable<int> nbSits { get; set; }

        [Display(Name = "Flight number")]
        public string numFlight { get; set; }

        [Display(Name = "Price")]
        public Nullable<double> price { get; set; }

        [Display(Name = "Arrival time")]
        public string timeFlightMatchingArr { get; set; }

        [Display(Name = "Depature time")]
        public string timeFlightMatchingDep { get; set; }

        [Display(Name = "Patient ID")]
        public Nullable<int> patient_userId { get; set; }
        public virtual ICollection<t_booking> t_booking { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
