using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_doctorpatientMap : EntityTypeConfiguration<t_doctorpatient>
    {
        public t_doctorpatientMap()
        {
            // Primary Key
            this.HasKey(t => new { t.doctorId, t.patientId });

            // Properties
            this.Property(t => t.doctorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.patientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("t_doctorpatient", "medtravdb");
            this.Property(t => t.doctorId).HasColumnName("doctorId");
            this.Property(t => t.patientId).HasColumnName("patientId");

            // Relationships
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_doctorpatient)
                .HasForeignKey(d => d.patientId);
            this.HasRequired(t => t.t_user1)
                .WithMany(t => t.t_doctorpatient1)
                .HasForeignKey(d => d.doctorId);

        }
    }
}
