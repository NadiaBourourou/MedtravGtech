using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_hotelbookingMap : EntityTypeConfiguration<t_hotelbooking>
    {
        public t_hotelbookingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.hotelId, t.patientId });

            // Properties
            this.Property(t => t.hotelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.patientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("t_hotelbooking", "medtravdb");
            this.Property(t => t.hotelId).HasColumnName("hotelId");
            this.Property(t => t.patientId).HasColumnName("patientId");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.numNights).HasColumnName("numNights");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.roomType).HasColumnName("roomType");

            // Relationships
            this.HasRequired(t => t.t_hotel)
                .WithMany(t => t.t_hotelbooking)
                .HasForeignKey(d => d.hotelId);
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_hotelbooking)
                .HasForeignKey(d => d.patientId);

        }
    }
}
