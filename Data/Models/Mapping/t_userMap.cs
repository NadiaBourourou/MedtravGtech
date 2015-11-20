using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_userMap : EntityTypeConfiguration<t_user>
    {
        public t_userMap()
        {
            // Primary Key
            this.HasKey(t => t.userId);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.cin)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.mail)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.specialty)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_user", "medtravdb");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.userId).HasColumnName("userId");
            this.Property(t => t.cin).HasColumnName("cin");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.mail).HasColumnName("mail");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.sexe).HasColumnName("sexe");
            this.Property(t => t.confirmed).HasColumnName("confirmed");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.dateOfBirth).HasColumnName("dateOfBirth");
            this.Property(t => t.numPassport).HasColumnName("numPassport");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.specialty).HasColumnName("specialty");
        }
    }
}
