using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_bookingMap : EntityTypeConfiguration<t_booking>
    {
        public t_bookingMap()
        {
            // Primary Key
            this.HasKey(t => t.bookingId);

            // Properties
            // Table & Column Mappings
            this.ToTable("t_booking", "medtravdb");
            this.Property(t => t.bookingId).HasColumnName("bookingId");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.clinicBooking_clinicId).HasColumnName("clinicBooking_clinicId");
            this.Property(t => t.clinicBooking_patientId).HasColumnName("clinicBooking_patientId");
            this.Property(t => t.doctorPatient_doctorId).HasColumnName("doctorPatient_doctorId");
            this.Property(t => t.doctorPatient_patientId).HasColumnName("doctorPatient_patientId");
            this.Property(t => t.flight_flightId).HasColumnName("flight_flightId");
            this.Property(t => t.hotelBooking_hotelId).HasColumnName("hotelBooking_hotelId");
            this.Property(t => t.hotelBooking_patientId).HasColumnName("hotelBooking_patientId");
            this.Property(t => t.surgeryPatient_idPatient).HasColumnName("surgeryPatient_idPatient");
            this.Property(t => t.surgeryPatient_idSurgery).HasColumnName("surgeryPatient_idSurgery");

            // Relationships
            this.HasOptional(t => t.t_surgerypatient)
                .WithMany(t => t.t_booking)
                .HasForeignKey(d => new { d.surgeryPatient_idPatient, d.surgeryPatient_idSurgery });
            this.HasOptional(t => t.t_hotelbooking)
                .WithMany(t => t.t_booking)
                .HasForeignKey(d => new { d.hotelBooking_hotelId, d.hotelBooking_patientId });
            this.HasOptional(t => t.t_flight)
                .WithMany(t => t.t_booking)
                .HasForeignKey(d => d.flight_flightId);
            this.HasOptional(t => t.t_clinicbooking)
                .WithMany(t => t.t_booking)
                .HasForeignKey(d => new { d.clinicBooking_clinicId, d.clinicBooking_patientId });
            this.HasOptional(t => t.t_doctorpatient)
                .WithMany(t => t.t_booking)
                .HasForeignKey(d => new { d.doctorPatient_doctorId, d.doctorPatient_patientId });

        }
    }
}
