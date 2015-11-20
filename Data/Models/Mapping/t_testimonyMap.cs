using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_testimonyMap : EntityTypeConfiguration<t_testimony>
    {
        public t_testimonyMap()
        {
            // Primary Key
            this.HasKey(t => t.testimonyId);

            // Properties
            this.Property(t => t.testimonyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_testimony", "medtravdb");
            this.Property(t => t.testimonyId).HasColumnName("testimonyId");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.patient_userId).HasColumnName("patient_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_testimony)
                .HasForeignKey(d => d.patient_userId);

        }
    }
}
