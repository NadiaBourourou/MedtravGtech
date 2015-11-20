using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_hotelMap : EntityTypeConfiguration<t_hotel>
    {
        public t_hotelMap()
        {
            // Primary Key
            this.HasKey(t => t.hotelId);

            // Properties
            this.Property(t => t.address)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_hotel", "medtravdb");
            this.Property(t => t.hotelId).HasColumnName("hotelId");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.priceSingle).HasColumnName("priceSingle");
            this.Property(t => t.priceSuite).HasColumnName("priceSuite");
            this.Property(t => t.stars).HasColumnName("stars");
            this.Property(t => t.state).HasColumnName("state");
        }
    }
}
