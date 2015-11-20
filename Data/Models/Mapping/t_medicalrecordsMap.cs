using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_medicalrecordsMap : EntityTypeConfiguration<t_medicalrecords>
    {
        public t_medicalrecordsMap()
        {
            // Primary Key
            this.HasKey(t => t.medicalRecordsId);

            // Properties
            // Table & Column Mappings
            this.ToTable("t_medicalrecords", "medtravdb");
            this.Property(t => t.medicalRecordsId).HasColumnName("medicalRecordsId");
            this.Property(t => t.analysis).HasColumnName("analysis");
            this.Property(t => t.patientFile).HasColumnName("patientFile");
            this.Property(t => t.patient_userId).HasColumnName("patient_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_medicalrecords)
                .HasForeignKey(d => d.patient_userId);

        }
    }
}
