using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_flightmatchingMap : EntityTypeConfiguration<t_flightmatching>
    {
        public t_flightmatchingMap()
        {
            // Primary Key
            this.HasKey(t => t.idFlightMatching);

            // Properties
            this.Property(t => t.airline)
                .HasMaxLength(255);

            this.Property(t => t.arrival)
                .HasMaxLength(255);

            this.Property(t => t.dateFlightMatchingArr)
                .HasMaxLength(255);

            this.Property(t => t.dateFlightMatchingDep)
                .HasMaxLength(255);

            this.Property(t => t.departure)
                .HasMaxLength(255);

            this.Property(t => t.numFlight)
                .HasMaxLength(255);

            this.Property(t => t.timeFlightMatchingArr)
                .HasMaxLength(255);

            this.Property(t => t.timeFlightMatchingDep)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_flightmatching", "medtravdb");
            this.Property(t => t.idFlightMatching).HasColumnName("idFlightMatching");
            this.Property(t => t.airline).HasColumnName("airline");
            this.Property(t => t.arrival).HasColumnName("arrival");
            this.Property(t => t.dateFlightMatchingArr).HasColumnName("dateFlightMatchingArr");
            this.Property(t => t.dateFlightMatchingDep).HasColumnName("dateFlightMatchingDep");
            this.Property(t => t.departure).HasColumnName("departure");
            this.Property(t => t.numFlight).HasColumnName("numFlight");
            this.Property(t => t.numberOfSits).HasColumnName("numberOfSits");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.timeFlightMatchingArr).HasColumnName("timeFlightMatchingArr");
            this.Property(t => t.timeFlightMatchingDep).HasColumnName("timeFlightMatchingDep");
        }
    }
}
