using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_clinicbookingMap : EntityTypeConfiguration<t_clinicbooking>
    {
        public t_clinicbookingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.clinicId, t.patientId });

            // Properties
            this.Property(t => t.clinicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.patientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.commentaire)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_clinicbooking", "medtravdb");
            this.Property(t => t.clinicId).HasColumnName("clinicId");
            this.Property(t => t.patientId).HasColumnName("patientId");
            this.Property(t => t.commentaire).HasColumnName("commentaire");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.typeRoom).HasColumnName("typeRoom");

            // Relationships
            this.HasRequired(t => t.t_clinic)
                .WithMany(t => t.t_clinicbooking)
                .HasForeignKey(d => d.clinicId);
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_clinicbooking)
                .HasForeignKey(d => d.patientId);

        }
    }
}
