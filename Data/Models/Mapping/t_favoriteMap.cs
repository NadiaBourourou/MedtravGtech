using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Data.Models.Mapping
{
    public class t_favoriteMap : EntityTypeConfiguration<t_favorite>
    {
        public t_favoriteMap()
        {
            // Primary Key
            this.HasKey(t => t.idFavorite);

            // Properties
            this.Property(t => t.idFavorite);

            this.Property(t => t.nameFavorite)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_favorite", "medtravdb");
            this.Property(t => t.idFavorite).HasColumnName("favoriteId");
            this.Property(t => t.nameFavorite).HasColumnName("nameFavorite");
            this.Property(t => t.patient_userId).HasColumnName("patient_userId");

            // Relationships
            this.HasOptional(t => t.t_user)
                .WithMany(t => t.t_favorite)
                .HasForeignKey(d => d.patient_userId);

            //Many to Many configuration
            HasMany(p => p.tips)
            .WithMany(v => v.favorites)
            .Map(m =>
            {
                m.ToTable("t_tipFavorite");   //Table d'association
                m.MapLeftKey("t_favorite");
                m.MapRightKey("t_tip");
            });

        }
    }
}
