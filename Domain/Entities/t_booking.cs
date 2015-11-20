using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_booking
    {
        public int bookingId { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> clinicBooking_clinicId { get; set; }
        public Nullable<int> clinicBooking_patientId { get; set; }
        public Nullable<int> doctorPatient_doctorId { get; set; }
        public Nullable<int> doctorPatient_patientId { get; set; }
        public Nullable<int> flight_flightId { get; set; }
        public Nullable<int> hotelBooking_hotelId { get; set; }
        public Nullable<int> hotelBooking_patientId { get; set; }
        public Nullable<int> surgeryPatient_idPatient { get; set; }
        public Nullable<int> surgeryPatient_idSurgery { get; set; }
        public virtual t_surgerypatient t_surgerypatient { get; set; }
        public virtual t_hotelbooking t_hotelbooking { get; set; }
        public virtual t_flight t_flight { get; set; }
        public virtual t_clinicbooking t_clinicbooking { get; set; }
        public virtual t_doctorpatient t_doctorpatient { get; set; }
    }
}
