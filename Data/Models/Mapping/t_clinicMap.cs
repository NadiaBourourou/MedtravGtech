using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_clinicMap : EntityTypeConfiguration<t_clinic>
    {
        public t_clinicMap()
        {
            // Primary Key
            this.HasKey(t => t.clinicId);

            // Properties
            this.Property(t => t.address)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.professionalism)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_clinic", "medtravdb");
            this.Property(t => t.clinicId).HasColumnName("clinicId");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.priceSimple).HasColumnName("priceSimple");
            this.Property(t => t.priceSingle).HasColumnName("priceSingle");
            this.Property(t => t.professionalism).HasColumnName("professionalism");
        }
    }
}
