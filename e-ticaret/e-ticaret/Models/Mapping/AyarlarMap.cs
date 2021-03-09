using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class AyarlarMap : EntityTypeConfiguration<Ayarlar>
    {
        public AyarlarMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DilID, t.AcilisDili });

            // Properties
            this.Property(t => t.GoogleClientID)
                .HasMaxLength(150);

            this.Property(t => t.GoogleClientSecret)
                .HasMaxLength(150);

            this.Property(t => t.FacebookAppID)
                .HasMaxLength(150);

            this.Property(t => t.FacebookSecret)
                .HasMaxLength(150);

            this.Property(t => t.TwitterApiID)
                .HasMaxLength(150);

            this.Property(t => t.TwitterSecret)
                .HasMaxLength(150);

            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AcilisDili)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.InstagramID)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Ayarlar");
            this.Property(t => t.SatisAktif).HasColumnName("SatisAktif");
            this.Property(t => t.BlogAktif).HasColumnName("BlogAktif");
            this.Property(t => t.UyeliksizSatis).HasColumnName("UyeliksizSatis");
            this.Property(t => t.UyelikZorunlu).HasColumnName("UyelikZorunlu");
            this.Property(t => t.GoogleClientID).HasColumnName("GoogleClientID");
            this.Property(t => t.GoogleClientSecret).HasColumnName("GoogleClientSecret");
            this.Property(t => t.FacebookAppID).HasColumnName("FacebookAppID");
            this.Property(t => t.FacebookSecret).HasColumnName("FacebookSecret");
            this.Property(t => t.TwitterApiID).HasColumnName("TwitterApiID");
            this.Property(t => t.TwitterSecret).HasColumnName("TwitterSecret");
            this.Property(t => t.DilID).HasColumnName("DilID");
            this.Property(t => t.AcilisDili).HasColumnName("AcilisDili");
            this.Property(t => t.InstagramID).HasColumnName("InstagramID");

            // Relationships
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.Ayarlars)
                .HasForeignKey(d => d.DilID);

        }
    }
}
