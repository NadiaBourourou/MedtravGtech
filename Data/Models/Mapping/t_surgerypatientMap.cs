using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_surgerypatientMap : EntityTypeConfiguration<t_surgerypatient>
    {
        public t_surgerypatientMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idPatient, t.idSurgery });

            // Properties
            this.Property(t => t.idPatient)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idSurgery)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.commentaire)
                .HasMaxLength(255);

            this.Property(t => t.price)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_surgerypatient", "medtravdb");
            this.Property(t => t.idPatient).HasColumnName("idPatient");
            this.Property(t => t.idSurgery).HasColumnName("idSurgery");
            this.Property(t => t.commentaire).HasColumnName("commentaire");
            this.Property(t => t.price).HasColumnName("price");

            // Relationships
            this.HasRequired(t => t.t_surgery)
                .WithMany(t => t.t_surgerypatient)
                .HasForeignKey(d => d.idSurgery);
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_surgerypatient)
                .HasForeignKey(d => d.idPatient);

        }
    }
}
