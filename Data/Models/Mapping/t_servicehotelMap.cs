using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_servicehotelMap : EntityTypeConfiguration<t_servicehotel>
    {
        public t_servicehotelMap()
        {
            // Primary Key
            this.HasKey(t => t.serviceHotelId);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_servicehotel", "medtravdb");
            this.Property(t => t.serviceHotelId).HasColumnName("serviceHotelId");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.hotel_hotelId).HasColumnName("hotel_hotelId");

            // Relationships
            this.HasOptional(t => t.t_hotel)
                .WithMany(t => t.t_servicehotel)
                .HasForeignKey(d => d.hotel_hotelId);

        }
    }
}
