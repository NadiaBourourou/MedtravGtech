using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_flightMap : EntityTypeConfiguration<t_flight>
    {
        public t_flightMap()
        {
            // Primary Key
            this.HasKey(t => t.flightId);

            // Properties
            this.Property(t => t.airline)
                .HasMaxLength(255);

            this.Property(t => t.arrivalDate)
                .HasMaxLength(255);

            this.Property(t => t.arrivalLocation)
                .HasMaxLength(255);

            this.Property(t => t.departureDate)
                .HasMaxLength(255);

            this.Property(t => t.departureLocation)
                .HasMaxLength(255);

            this.Property(t => t.numFlight)
                .HasMaxLength(255);

            this.Property(t => t.timeFlightMatchingArr)
                .HasMaxLength(255);

            this.Property(t => t.timeFlightMatchingDep)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_flight", "medtravdb");
            this.Property(t => t.flightId).HasColumnName("flightId");
            this.Property(t => t.airline).HasColumnName("airline");
            this.Property(t => t.arrivalDate).HasColumnName("arrivalDate");
            this.Property(t => t.arrivalLocation).HasColumnName("arrivalLocation");
            this.Property(t => t.departureDate).HasColumnName("departureDate");
            this.Property(t => t.departureLocation).HasColumnName("departureLocation");
            this.Property(t => t.nbSits).HasColumnName("nbSits");
            this.Property(t => t.numFlight).HasColumnName("numFlight");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.timeFlightMatchingArr).HasColumnName("timeFlightMatchingArr");
            this.Property(t => t.timeFlightMatchingDep).HasColumnName("timeFlightMatchingDep");
            this.Property(t => t.patient_userId).HasColumnName("patient_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_flight)
                .HasForeignKey(d => d.patient_userId);

        }
    }
}
