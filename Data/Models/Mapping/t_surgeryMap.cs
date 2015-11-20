using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_surgeryMap : EntityTypeConfiguration<t_surgery>
    {
        public t_surgeryMap()
        {
            // Primary Key
            this.HasKey(t => t.surgeryId);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_surgery", "medtravdb");
            this.Property(t => t.surgeryId).HasColumnName("surgeryId");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.doctor_userId).HasColumnName("doctor_userId");
            this.Property(t => t.procedure_id).HasColumnName("procedure_id");

            // Relationships
            this.HasOptional(t => t.t_procedure)
                .WithMany(t => t.t_surgery)
                .HasForeignKey(d => d.procedure_id);
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_surgery)
                .HasForeignKey(d => d.doctor_userId);

        }
    }
}
