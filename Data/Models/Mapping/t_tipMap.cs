using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_tipMap : EntityTypeConfiguration<t_tip>
    {
        public t_tipMap()
        {
            // Primary Key
            this.HasKey(t => t.idTip);

            // Properties
            this.Property(t => t.idTip)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.body)
               .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_tip", "medtravdb");
            this.Property(t => t.idTip).HasColumnName("tipId");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.liked).HasColumnName("liked");
            this.Property(t => t.disliked).HasColumnName("disliked");
            this.Property(t => t.idPatientVoted).HasColumnName("idPatientVoted");
            this.Property(t => t.administrator_userId).HasColumnName("administrator_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_tip)
                .HasForeignKey(d => d.administrator_userId);

        }
    }
}
