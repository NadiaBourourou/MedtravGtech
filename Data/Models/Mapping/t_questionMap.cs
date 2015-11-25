using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_questionMap : EntityTypeConfiguration<t_question>
    {
        public t_questionMap()
        {
            // Primary Key
            this.HasKey(t => t.questionId);

            // Properties
            this.Property(t => t.questionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.response)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_question", "medtravdb");
            this.Property(t => t.questionId).HasColumnName("questionId");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.response).HasColumnName("response");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.patient_userId).HasColumnName("patient_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_question)
                .HasForeignKey(d => d.patient_userId);

        }
    }
}
